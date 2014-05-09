using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Exceptions;
using PlayerTracker.Common.Util;

namespace PlayerTracker.Common.Net.Packets {
	public class DataResponsePacket : Packet {
		public DataResponsePacket(params byte[] data)
			: base(PacketType.DATA_RESPONSE, data) {
		}

        public DataResponsePacket(Packet p) : base(p) {
        }

		public DataResponsePacket(string name, string server, string notes, string violations, UserViolationLevel vl, string id)
			: base(PacketType.DATA_RESPONSE, getBytesFromData(name, server, notes, violations, vl, id)){
		}

		public String getName() {
			return NetUtils.bytesToString(base.getDataSection(0));
		}

		public String getNotes() {
			return NetUtils.bytesToString(base.getDataSection(1));
		}

		public String getViolations() {
			return NetUtils.bytesToString(base.getDataSection(2));
		}

		public string getServer(){
			return NetUtils.bytesToString(base.getDataSection(4));
		}

		public string getID(){
			return NetUtils.bytesToString(base.getDataSection(5));
		}

		public UserViolationLevel getViolationLevel() {
			try {
				return UserViolationLevel.getViolationLevelFromByte(base.getDataSection(3)[0]);
			} catch (InvalidArgumentException e) {
				throw new InvalidPacketException(e.Message);
			}
		}

		public static byte[] getBytesFromData(string name, string server, string notes, string violations, UserViolationLevel vl, string id){
			List<byte> bytes = new List<byte>();

			foreach (byte b in NetUtils.stringToBytes(name))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach(byte b in NetUtils.stringToBytes(notes))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach(byte b in NetUtils.stringToBytes(violations))
				bytes.Add(b);
			bytes.Add(0x0);

			bytes.Add(vl.getByteIdentity());
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(server))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(id))
				bytes.Add(b);

			return NetUtils.byteListToArray(bytes);
		}
	}
}
