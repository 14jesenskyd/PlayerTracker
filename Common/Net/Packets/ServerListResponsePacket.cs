using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Net.Packets {
	public class ServerListResponsePacket : Packet {
		private string[] p;

		public ServerListResponsePacket(string[] servers)
			: base(PacketType.LIST_RESPONSE, getBytesFromData(servers)) {
		}

		public ServerListResponsePacket(Packet p) : base(p){
		}

		public IEnumerable<string> getServerList(){
			foreach(string server in NetUtils.bytesToString(base.getDataSection(0)).Split(';')){
				yield return server;
			}
		}

		private static byte[] getBytesFromData(string[] data){
			string list = "";
			foreach(string server in data){
				list+=server+";";
			}
			if(list.Length > 1)
				list = list.Substring(0, list.Length-1);
			return NetUtils.stringToBytes(list);
		}
	}
}