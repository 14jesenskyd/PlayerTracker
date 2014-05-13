using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Exceptions {
	[Serializable]
	public class NoSuchKeyException : Exception{
		public NoSuchKeyException()
			: base("Invalid key; no value corresponds."){
		}

		public NoSuchKeyException(String s)
			: base(s){
		}
	}
}
