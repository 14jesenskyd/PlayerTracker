using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Util {
	public class Attachment {
		private DateTime datetime;
		private string id;

		public Attachment(DateTime dt, string id){
			this.id = id;
			this.datetime = dt;
		}

		public DateTime getDateTime() {
			return this.datetime;
		}

		public string getID() {
			return this.id;
		}

		public bool Equals(Attachment a) {
			return a != null && a.id != null && a.id.Equals(this.id) && a.datetime != null && (a.datetime.ToShortDateString() + " " + a.datetime.ToLongTimeString()).Equals(this.datetime.ToShortDateString() + " " + this.datetime.ToLongTimeString());
		}
	}
}