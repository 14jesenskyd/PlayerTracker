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

		public String getName() {
			return NetUtils.bytesToString(base.getDataSection(0));
		}

		public String getNotes() {
			return NetUtils.bytesToString(base.getDataSection(1));
		}

		public String getViolations() {
			return NetUtils.bytesToString(base.getDataSection(2));
		}

		public UserViolationLevel getViolationLevel() {
			try {
				return UserViolationLevel.getViolationLevelFromByte(base.getDataSection(3)[0]);
			} catch (InvalidArgumentException e) {
				throw new InvalidPacketException(e.Message);
			}
		}
	}
}
