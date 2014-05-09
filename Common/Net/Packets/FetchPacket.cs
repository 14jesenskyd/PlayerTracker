using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class FetchPacket : Packet {
		public FetchPacket(string player, string server)
			: base(PacketType.FETCH_DATA, getBytesFromData(player, server)) {
		}

		public FetchPacket(Packet p) : base(p){
		}

		public String getName() {
			return NetUtils.bytesToString(base.getDataSection(0));
		}

		public string getServer(){
			return NetUtils.bytesToString(base.getDataSection(1));
		}

		private static byte[] getBytesFromData(string name, string server){
			List<byte> bytes = new List<byte>();

			foreach(byte b in NetUtils.stringToBytes(name))
				bytes.Add(b);
			bytes.Add(0x0);
			foreach(byte b in NetUtils.stringToBytes(server))
				bytes.Add(b);

			return NetUtils.byteListToArray(bytes);
		}
	}
}
