using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class LoginPacket : Packet {

		public LoginPacket(String user, String pass)
			: base(PacketType.LOGIN, getBytesFromInformation(user, pass)) {
		}

		private static byte[] getBytesFromInformation(String user, String pass) {
			List<byte> b = new List<byte>();
			foreach (byte z in NetUtils.stringToBytes(user))
				b.Add(z);
			b.Add((byte)0x0);
			foreach (Byte z in NetUtils.getMD5Hash(NetUtils.stringToBytes(pass)))
				b.Add(z);
			return NetUtils.byteListToArray(b);
		}

	}
}