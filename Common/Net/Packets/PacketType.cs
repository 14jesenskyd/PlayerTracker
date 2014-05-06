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
				if (Array.Equals(t.getHeader(), head))
					return t;
			}
			throw new InvalidPacketException("Header did not match any packet types.");
		}

		public byte[] getHeader() {
			return this.header;
		}

		public static IEnumerable<PacketType> Values {
			get {
				yield return LOGIN;
				yield return LOGIN_RESPONSE;
				yield return FETCH_DATA;
				yield return DATA_RESPONSE;
			}
		}

		public static readonly PacketType LOGIN = new PacketType(new byte[] { 0x1, 0x0, 0x1 });
		public static readonly PacketType LOGIN_RESPONSE = new PacketType(new byte[] { 0x1, 0x0, 0x2 });
		public static readonly PacketType FETCH_DATA = new PacketType(new byte[] { 0x1, 0x0, 0x3 });
		public static readonly PacketType DATA_RESPONSE = new PacketType(new byte[] { 0x1, 0x0, 0x4 });

	}
}
