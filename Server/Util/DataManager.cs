using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Exceptions;
using PlayerTracker.Common.Util;
using PlayerTracker.Common.Net;
using PlayerTracker.Common.Net.Packets;
using PlayerTracker.Server.Events;
using PlayerTracker.Server.Listeners;

namespace PlayerTracker.Server.Util {
	public class DataManager {
		private List<DataTransmissionListener> listeners;

		public DataManager() {
			this.listeners = new List<DataTransmissionListener>();
		}

		public int registerDataTransmissionListener(DataTransmissionListener listener) {
			if (!this.listeners.Contains(listener))
				this.listeners.Add(listener);
			return this.listeners.IndexOf(listener);
		}

		private String generateUUID() {
			//TODO generate
			return "";
		}

		private bool attemptLogin(String user, String pass) {
			//TODO verify credentials
			Server.getSingleton().getDbManager();
			return false;
		}

		public void run() {
			while (true)
				foreach (Connection c in Server.getSingleton().getConnectionManager().getConnections().Values) {
					if (c.isClosed()) {
						Server.getSingleton().getConnectionManager().getConnections().Remove(c.getAddress());
					} else
						try {
							if (c.dataRemaining()) {
								Packet p = c.readData();
								Packet response = null;

								if(p.getType().Equals(PacketType.LOGIN)){
									response = new LoginResponsePacket(LoginResponsePacket.LoginResponse.SUCCESS);
								}else if(p.getType().Equals(PacketType.FETCH_DATA)){
										FetchPacket packet = (FetchPacket)p;
										String name, notes, violations;
										UserViolationLevel vl;
										//TODO query db for information on player
										response = new DataResponsePacket();
								}
								response.sendData(c);
							}
						} catch (InvalidPacketException e) {
							Server.getLogger().error(e.Message);
						}
				}
		}
	}
}