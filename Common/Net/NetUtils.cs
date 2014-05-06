using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace PlayerTracker.Common.Net {
	public class NetUtils {
		private NetUtils() {
		}

		public static byte[] byteListToArray(List<Byte> bytes) {
			byte[] b = new byte[bytes.Count];
			for (int i = 0; i < b.Length; i++)
				b[i] = bytes[i];
			return b;
		}

		public static byte[] getMD5Hash(byte[] b) {
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
			return md5.ComputeHash(b);
		}

		public static byte[] stringToBytes(String s) {
			return System.Text.Encoding.UTF8.GetBytes(s);
		}

		public static String bytesToString(byte[] b) {
			return System.Text.Encoding.UTF8.GetString(b);
		}
	}
}