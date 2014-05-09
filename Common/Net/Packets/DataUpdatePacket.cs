using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Util;

namespace PlayerTracker.Common.Net.Packets {
	public class DataUpdatePacket : Packet {
		public DataUpdatePacket(string user, string server, string notes, string violations, UserViolationLevel vl, string id)
			: base(PacketType.DATA_UPDATE, getBytesFromData(user, server, notes, violations, vl, id)) {
		}

		public DataUpdatePacket(Packet p) : base(p){
		}

		private static byte[] getBytesFromData(string user, string server, string notes, string violations, UserViolationLevel vl, string id) {
			List<byte> bytes = new List<byte>();

			foreach (byte b in NetUtils.stringToBytes(user))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(server))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(notes))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(violations))
				bytes.Add(b);
			bytes.Add(0x0);

			bytes.Add(vl.getByteIdentity());
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(id))
				bytes.Add(b);

			return NetUtils.byteListToArray(bytes);
		}

		public string getPlayer() {
			return NetUtils.bytesToString(base.getDataSection(0));
		}

		public string getServer() {

			return NetUtils.bytesToString(base.getDataSection(1));
		}

		public string getNotes() {
			return NetUtils.bytesToString(base.getDataSection(2));
		}

		public string getViolations() {
			return NetUtils.bytesToString(base.getDataSection(3));
		}

		public UserViolationLevel getViolationLevel() {
			return UserViolationLevel.getViolationLevelFromByte(base.getDataSection(4)[0]);
		}

		public string getID() {
			return base.getDataSection(5);
		}
	}
}