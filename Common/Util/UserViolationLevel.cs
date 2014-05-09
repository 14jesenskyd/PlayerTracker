using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Exceptions;

namespace PlayerTracker.Common.Util {
	public sealed class UserViolationLevel {
		public static readonly UserViolationLevel GOOD = new UserViolationLevel((byte)0x1);
		public static readonly UserViolationLevel WARN = new UserViolationLevel((byte)0x2);
		public static readonly UserViolationLevel SEVERE = new UserViolationLevel((byte)0x3);
		public static readonly UserViolationLevel BANNED = new UserViolationLevel((byte)0x4);
		private byte ident;

		UserViolationLevel(byte ident) {
			this.ident = ident;
		}

		public static UserViolationLevel getViolationLevelFromByte(byte b) {
			foreach (UserViolationLevel l in UserViolationLevel.Values) {
				if (l.getByteIdentity() == b)
					return l;
			}
			throw new InvalidArgumentException("Byte " + b + " does not correspond to a UserViolationLevel.");
		}

		public static IEnumerable<UserViolationLevel> Values {
			get {
				yield return GOOD;
				yield return WARN;
				yield return SEVERE;
				yield return BANNED;
			}
		}

		public byte getByteIdentity() {
			return this.ident;
		}

		public bool Equals(UserViolationLevel vl){
			return this.ident == vl.ident;
		}
	}
}