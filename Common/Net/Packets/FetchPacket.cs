using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class FetchPacket : Packet {
		public FetchPacket(params byte[] b)
			: base(PacketType.FETCH_DATA, b) {
		}

		public String getName() {
			return NetUtils.bytesToString(base.getDataSection(0));
		}
	}
}
