using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace PlayerTracker.Common.Net {
	public sealed class NetUtils {
		private NetUtils() {
		}

		public static byte[] byteListToArray(List<Byte> bytes) {
			byte[] b = new byte[bytes.Count];
			for (int i = 0; i < b.Length; i++)
				b[i] = bytes[i];
			return b;
		}

		public static string getMD5Hash(byte[] b) {
			MD5 md5 = MD5.Create();
			StringBuilder sb = new StringBuilder();
			byte[] hash = md5.ComputeHash(b);

			for(int i = 0; i < hash.Length; i++){
				sb.Append(hash[i].ToString("X2"));
			}

			return sb.ToString();
		}

		public static string getMD5Hash(string s){
			return NetUtils.getMD5Hash(NetUtils.stringToBytes(s));
		}

		public static byte[] stringToBytes(String s) {
			return System.Text.Encoding.UTF8.GetBytes(s);
		}

		public static String bytesToString(byte[] b) {
			return System.Text.Encoding.UTF8.GetString(b);
		}
	}
}