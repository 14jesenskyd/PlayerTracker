using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class AttachmentListRequestPacket : Packet {
		public AttachmentListRequestPacket(string playerId, string serverId)
			: base(PacketType.ATTACHMENT_LIST_REQ, getData(playerId, serverId)){
		}

		public AttachmentListRequestPacket(Packet p)
			: base(p) {
		}

		private static byte[] getData(string playerId, string serverId) {
			List<byte> bytes = new List<byte>();

			foreach (byte b in NetUtils.stringToBytes(playerId))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(serverId))
				bytes.Add(b);

			return NetUtils.byteListToArray(bytes);
		}

		public string getPlayerId() {
			return NetUtils.bytesToString(base.getDataSection(0));
		}

		public string getServerId() {
			return NetUtils.bytesToString(base.getDataSection(1));
		}
	}
}