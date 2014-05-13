using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class AttachmentRequestPacket : Packet {
		public AttachmentRequestPacket(string id)
			: base(PacketType.ATTACHMENT_REQUEST, getData(id)) {
		}

		public AttachmentRequestPacket(Packet p)
			: base(p) {
		}

		private static byte[] getData(string id){
			return NetUtils.stringToBytes(id);
		}
	}
}