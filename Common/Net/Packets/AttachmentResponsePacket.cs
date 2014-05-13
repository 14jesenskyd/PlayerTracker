using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class AttachmentResponsePacket : AbstractAttachmentPacket {
		public AttachmentResponsePacket(byte[] data)
			: base(PacketType.ATTACHMENT_RESPONSE, "", "", "", data) {
		}

		public AttachmentResponsePacket(string blobstring)
			: base(PacketType.ATTACHMENT_RESPONSE, "", "", "", NetUtils.stringToBytes(blobstring)) {
		}

		public AttachmentResponsePacket(Packet p)
			: base(p) {
		}
	}
}