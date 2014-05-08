using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class ServerListRequestPacket : Packet {
		public ServerListRequestPacket(string user) : base(PacketType.LIST_REQUEST, NetUtils.stringToBytes(user)){
		}

		public string getUser(){
			return NetUtils.bytesToString(base.getDataSection(0));
		}
	}
}