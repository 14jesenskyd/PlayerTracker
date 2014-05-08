using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Net;
using PlayerTracker.Common.Exceptions;

namespace PlayerTracker.Common.Net.Packets {
	public class LoginResponsePacket : Packet {

		public LoginResponsePacket(LoginResponse response)
			: base(PacketType.LOGIN_RESPONSE, getBytes(response, "")) {
		}

		public LoginResponsePacket(Packet p)
			: base(p) {
		}

		public LoginResponsePacket(LoginResponse response, String uuid)
			: base(PacketType.LOGIN_RESPONSE, getBytes(response, uuid)) {
		}

		public LoginResponsePacket(params byte[] bytes)
			: base(PacketType.LOGIN_RESPONSE, bytes) {
		}

		private static byte[] getBytes(LoginResponse response, String uuid) {
			List<Byte> bytes = new List<byte>();

			bytes.Add(response.getResponse());
			bytes.Add((byte)0x0);
			foreach (byte b in NetUtils.stringToBytes(uuid))
				bytes.Add(b);

			return NetUtils.byteListToArray(bytes);
		}

		public String getUUID() {
			return "";
		}

		public LoginResponse getResponse() {
			return LoginResponse.getResponseFromByte(base.getAmmendedData()[3]);
		}

		public class LoginResponse {
			public static readonly LoginResponse SUCCESS = new LoginResponse((byte)0x1);
			public static readonly LoginResponse FAILURE = new LoginResponse((byte)0x0);
			private byte indicator;

			LoginResponse(byte indicator) {
				this.indicator = indicator;
			}

			public static LoginResponse getResponseFromByte(byte b) {
				foreach (LoginResponse r in LoginResponse.Values)
					if (r.getResponse() == b)
						return r;
				throw new InvalidArgumentException("Given byte does not correspond to any login responses.");
			}

			public static IEnumerable<LoginResponse> Values {
				get {
					yield return SUCCESS;
					yield return FAILURE;
				}
			}

			public byte getResponse() {
				return this.indicator;
			}

			public bool Equals(LoginResponse resp){
				return resp.getResponse() == this.getResponse();
			}

			public override string ToString() {
				return "LoginResponse[" + base.ToString() + "]";
			}
		}
	}
}
