using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Util {
	public sealed class KVFactory {
		public static KeyValuePair<string, object> obj(string s, object o){
			return new KeyValuePair<string,object>(s, o);
		}
	}
}