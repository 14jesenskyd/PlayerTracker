using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public abstract class AbstractAttachmentPacket : Packet {
		private const int DATA_SECTION = 3;

		public AbstractAttachmentPacket(PacketType type, string playerId, string serverId, string userId, byte[] data) 
			: base(type, getData(playerId, serverId, userId, data)){
		}

		public AbstractAttachmentPacket(Packet p)
			: base(p) {
		}

		public string getPlayerId() {
			return NetUtils.bytesToString(base.getDataSection(0));
		}

		public string getServerId() {
			return NetUtils.bytesToString(base.getDataSection(1));
		}

		public byte[] getAttachmentData() {
			return this.getDataSection(DATA_SECTION);
		}

		public string getUserId(){
			return NetUtils.bytesToString(base.getDataSection(2));
		}

		private static byte[] getData(string playerId, string serverId, string userId, byte[] data) {
			List<byte> bytes = new List<byte>();

			foreach (byte b in NetUtils.stringToBytes(playerId))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(serverId))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in NetUtils.stringToBytes(userId))
				bytes.Add(b);
			bytes.Add(0x0);

			foreach (byte b in data)
				bytes.Add(b);

			return NetUtils.byteListToArray(bytes);
		}

		//this method must be overridden for the purpose of sending the image data.
		//normally, an image file may contain a null byte, meaning the base class' implementation
		//would essentially corrupt the image data by taking out bytes and separating them.
		//the only modification is that it will ignore the special behaviour for 0x0 bytes when
		//the section is that which contains the image data.
		public override byte[] getDataSection(int section) {
			List<Byte> r = new List<Byte>();
			int iteration = 0, index = 0;
			bool t = true;

			while (t) {
				if (index > base.data.Length)
					break;
				if(base.data[index] == 0)
					iteration++;
				if (iteration == section) {
					if (section != 0)
						index++;
					while (t && index < base.data.Length) {
						if (base.data[index] == (byte)0x0 && section != DATA_SECTION) {
							t = false;
						} else {
							r.Add(base.data[index++]);
						}
						if (base.data.Length == index)
							t = false;
					}
				}
				index++;
			}
			return NetUtils.byteListToArray(r);
		}
	}
}