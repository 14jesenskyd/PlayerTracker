using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Exceptions {
	[Serializable]
	public class InvalidArgumentException : Exception {
		public InvalidArgumentException() : base("Invalid argument!"){
		}
		public InvalidArgumentException(string s) : base(s){
		}
	}
}
