using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Exceptions;

namespace PlayerTracker.Common.Net.Packets {
	public class PacketType {
		private readonly byte[] header;

		PacketType(params byte[] data) {
			this.header = data;
		}

		public static PacketType getTypeFromHeader(params byte[] head) {
			foreach (PacketType t in PacketType.Values) {
				if (t.Equals(head))
					return t;
			}
			throw new InvalidPacketException("Header did not match any packet types.");
		}

		public byte[] getHeader() {
			return this.header;
		}

        public bool Equals(PacketType t) {
            if (t.getHeader().Length != this.header.Length)
                return false;
            for (int i = 0; i < t.getHeader().Length; i++)
                if (t.getHeader()[i] != this.header[i])
                    return false;
            return true;
        }
        public bool Equals(byte[] t) {
            if (t.Length != this.header.Length)
                return false;
            for (int i = 0; i < t.Length; i++)
                if (t[i] != this.header[i])
                    return false;
            return true;
        }

		public static IEnumerable<PacketType> Values {
			get {
				yield return LOGIN;
				yield return LOGIN_RESPONSE;
				yield return FETCH_DATA;
				yield return DATA_RESPONSE;
				yield return LIST_REQUEST;
				yield return LIST_RESPONSE;
				yield return REGISTRATION;
				yield return REGISTRATION_RESPONSE;
				yield return DATA_UPDATE;
				yield return ATTACHMENT_LIST_REQ;
				yield return ATTACHMENT_LIST_RESP;
				yield return ATTACHMENT_REQUEST;
				yield return ATTACHMENT_RESPONSE;
				yield return UPLOAD_ATTACHMENT;
			}
		}

		public static readonly PacketType LOGIN = new PacketType(new byte[] { 0x1, 0x0, 0x1 });
		public static readonly PacketType LOGIN_RESPONSE = new PacketType(new byte[] { 0x1, 0x0, 0x2 });
		public static readonly PacketType FETCH_DATA = new PacketType(new byte[] { 0x1, 0x0, 0x3 });
		public static readonly PacketType DATA_RESPONSE = new PacketType(new byte[] { 0x1, 0x0, 0x4 });
		public static readonly PacketType LIST_REQUEST = new PacketType(new byte[] { 0x1, 0x0, 0x5 });
		public static readonly PacketType LIST_RESPONSE = new PacketType(new byte[] { 0x1, 0x0, 0x6 });
		public static readonly PacketType REGISTRATION = new PacketType(new byte[] { 0x1, 0x0, 0x7 });
		public static readonly PacketType REGISTRATION_RESPONSE = new PacketType(new byte[] { 0x1, 0x0, 0x8 });
		public static readonly PacketType DATA_UPDATE = new PacketType(new byte[] { 0x1, 0x0, 0x9 });
		public static readonly PacketType ATTACHMENT_LIST_REQ = new PacketType(new byte[] { 0x1, 0x0, 0xA });
		public static readonly PacketType ATTACHMENT_LIST_RESP = new PacketType(new byte[] { 0x1, 0x0, 0xB });
		public static readonly PacketType ATTACHMENT_REQUEST = new PacketType(new byte[] { 0x1, 0x0, 0xC });
		public static readonly PacketType ATTACHMENT_RESPONSE = new PacketType(new byte[] { 0x1, 0x0, 0xD });
		public static readonly PacketType UPLOAD_ATTACHMENT = new PacketType(new byte[] { 0x1, 0x0, 0xE });
	}
}
