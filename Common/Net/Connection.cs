using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;
using PlayerTracker.Common.Exceptions;
using PlayerTracker.Common.Net.Packets;

namespace PlayerTracker.Common.Net {
	public class Connection : IDisposable {
		private Socket sock;

		public Connection(IPEndPoint iep){
			this.sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			this.sock.Connect(iep);
		}

		public Connection(Socket sock) {
			if (sock == null || !sock.Connected)
				throw new InvalidArgumentException("Provided socket may not be null or closed!");
			this.sock = sock;
		}

		public void send(params byte[] i) {
			this.sock.Send(i, SocketFlags.None);
		}

		public void send(Packet p){
			this.send(p.getAmmendedData());
		}

		public Packet readData() {
			byte[] header = new byte[3];
			byte[] buffer = new byte[1];
			List<Byte> data = new List<Byte>();
			PacketType type;

			if (this.sock.Receive(header) < 3)
				throw new InvalidPacketException("Packet header was too short.");
			type = PacketType.getTypeFromHeader(header);

			while (this.dataRemaining()){
				this.sock.Receive(buffer);
				data.Add(buffer[0]);
			}

			return new Packet(type, NetUtils.byteListToArray(data));
		}

		public IPAddress getAddress(){
			return ((IPEndPoint)this.sock.RemoteEndPoint).Address;
		}

		public bool dataRemaining() {
			return this.sock.Available != 0;
		}

		public bool isClosed() {
			return !this.sock.Connected;
		}

		public void close() {
			this.sock.Close();
		}

		public String toString() {
			return this.sock.ToString();
		}

		public void Dispose() {
			this.Dispose(true);
		}

		protected virtual void Dispose(bool managed) {
			if (managed) {
				this.sock.Dispose();
			}
		}
	}
}