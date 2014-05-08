using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;
using PlayerTracker.Common.Net;
using PlayerTracker.Common.Net.Packets;
using PlayerTracker.Common.Util;
using PlayerTracker.Common.Exceptions;

namespace PlayerTracker.Client.Util {
	class RequestManager {
		private Queue<Packet> responses;
		private bool accepting;
		private Thread thread;

		public RequestManager() {
			this.responses = new Queue<Packet>();
		}

		public void start() {
			this.accepting = true;
			new Thread(new ThreadStart(run)).Start();
		}

		public void stop() {
			this.accepting = false;
			this.thread.Abort();
		}

		public void run() {
			this.thread = Thread.CurrentThread;
			while (this.accepting) {
				try {
					if (Client.getClient().getConnection().dataRemaining()) {
						Packet p = Client.getClient().getConnection().readData();

						if (p.getType().Equals(PacketType.LOGIN_RESPONSE)) {
							this.responses.Enqueue(new LoginResponsePacket(p));
						} else if (p.getType().Equals(PacketType.DATA_RESPONSE)) {
							this.responses.Enqueue(new DataResponsePacket(p));
						} else if (p.getType().Equals(PacketType.LIST_RESPONSE)) {
							this.responses.Enqueue(new ServerListResponsePacket(p));
						}
					}
				} catch (InvalidPacketException e) {
					Client.getLogger().error(e.Message);
				} catch (IOException e) {
					Client.getLogger().error(e.Message);
				}
				Thread.Sleep(35);
			}
		}

		public bool hasResponse() {
			return this.responses.Count != 0;
		}

		public Packet getResponse() {
			return this.responses.Dequeue();
		}
	}
}