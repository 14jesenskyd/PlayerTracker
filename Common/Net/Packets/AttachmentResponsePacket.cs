using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	class AttachmentResponsePacket : AbstractAttachmentPacket {
		public AttachmentResponsePacket(string playerId, string serverId, byte[] data)
			: base(PacketType.ATTACHMENT_RESPONSE, playerId, serverId, data){
		}

		public AttachmentResponsePacket(Packet p)
			: base(p) {
		}
	}
}