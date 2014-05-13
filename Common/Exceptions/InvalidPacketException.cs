using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Exceptions {
	[Serializable]
	public class InvalidPacketException : Exception {
		public InvalidPacketException()
			: base("Invalid packet! Perhaps the header is malformed, or the byte data does not constitute a packet of that type?") {
		}

		public InvalidPacketException(String s)
			: base(s) {
			
		}
	}
}