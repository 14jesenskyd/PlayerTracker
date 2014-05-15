using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class AttachmentResponsePacket : Packet {
		public AttachmentResponsePacket(byte[] data)
			: base(PacketType.ATTACHMENT_RESPONSE, getData(data)) {
		}

		public AttachmentResponsePacket(string blobstring)
			: base(PacketType.ATTACHMENT_RESPONSE, getData(NetUtils.stringToBytes(blobstring))) {
		}

		public AttachmentResponsePacket(Packet p)
			: base(p) {
		}

		private static byte[] getData(byte[] bytes){
			List<byte> z = new List<byte>();

			foreach(byte b in bytes)
				z.Add(b);
			
			return NetUtils.byteListToArray(z);
		}

		public byte[] getAttachmentData(){
			return base.data;
		}
	}
}