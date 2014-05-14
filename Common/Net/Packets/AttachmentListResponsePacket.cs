using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Util;

namespace PlayerTracker.Common.Net.Packets {
	public class AttachmentListResponsePacket : Packet {
		public AttachmentListResponsePacket(List<Attachment> attachments)
			: base(PacketType.ATTACHMENT_LIST_RESP, getData(attachments)){
		}

		public AttachmentListResponsePacket(Packet p)
			: base(p) {
		}

		private static byte[] getData(List<Attachment> attachments){
			List<byte> bytes = new List<byte>();

			foreach (Attachment a in attachments) {
				foreach(byte b in NetUtils.stringToBytes(a.getDateTime().ToShortDateString() + " " + a.getDateTime().ToLongTimeString()))
					bytes.Add(b);
				bytes.Add(0x0);

				foreach (byte b in NetUtils.stringToBytes(a.getID()))
					bytes.Add(b);
				bytes.Add(0x0);

				foreach (byte b in NetUtils.stringToBytes(a.getUploadingUser()))
					bytes.Add(b);
				bytes.Add(0x0);
			}
			if(bytes.Count > 1)
				bytes.RemoveAt(bytes.Count-1);

			return NetUtils.byteListToArray(bytes);
		}

		public List<Attachment> getAttachments() {
			List<Attachment> a = new List<Attachment>();
			int i = 0;

			while (base.hasDataSection(i)) {
				a.Add(new Attachment(DateTime.Parse(NetUtils.bytesToString(base.getDataSection(i++))), NetUtils.bytesToString(base.getDataSection(i++)), NetUtils.bytesToString(base.getDataSection(i++))));
			}

			return a;
		}
	}
}