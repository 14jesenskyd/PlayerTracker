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
			}
		}

		public static readonly PacketType LOGIN = new PacketType(new byte[] { 0x1, 0x0, 0x1 });
		public static readonly PacketType LOGIN_RESPONSE = new PacketType(new byte[] { 0x1, 0x0, 0x2 });
		public static readonly PacketType FETCH_DATA = new PacketType(new byte[] { 0x1, 0x0, 0x3 });
		public static readonly PacketType DATA_RESPONSE = new PacketType(new byte[] { 0x1, 0x0, 0x4 });
		public static readonly PacketType LIST_REQUEST = new PacketType(new byte[] { 0x1, 0x0, 0x5 });
		public static readonly PacketType LIST_RESPONSE = new PacketType(new byte[] { 0x1, 0x0, 0x6 });
	}
}
