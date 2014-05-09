using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class RegistrationPacket : Packet{
		public RegistrationPacket(string user, string pass, string first, string last, string key) : base(PacketType.REGISTRATION, getBytesFromData(user, pass, first, last, key)){
		}

		public RegistrationPacket(Packet p) : base(p) {
		}

		private static byte[] getBytesFromData(string user, string pass, string first, string last, string key){
			List<byte> bytes = new List<byte>();
			foreach(byte b in NetUtils.stringToBytes(user))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(pass))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(first))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(last))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(key))
				bytes.Add(b);

			return NetUtils.byteListToArray(bytes);
		}

		public string getUsername(){
			return NetUtils.bytesToString(base.getDataSection(0));
		}

		public string getPasswordHash(){
			return NetUtils.bytesToString(base.getDataSection(1));
		}

		public string getFirstName(){
			return NetUtils.bytesToString(base.getDataSection(2));
		}

		public string getLastName(){
			return NetUtils.bytesToString(base.getDataSection(3));
		}

		public string getRegistrationKey(){
			return NetUtils.bytesToString(base.getDataSection(4));
		}
	}
}