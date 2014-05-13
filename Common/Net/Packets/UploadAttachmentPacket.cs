using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class UploadAttachmentPacket : AbstractAttachmentPacket {
		private const int DATA_SECTION = 2;

		public UploadAttachmentPacket(string playerId, string serverId, byte[] data)
			: base(PacketType.UPLOAD_ATTACHMENT, playerId, serverId, data) {
		}

		public UploadAttachmentPacket(Packet p)
			: base(p) {
		}
	}
}