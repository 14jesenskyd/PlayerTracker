using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Net;
using PlayerTracker.Common.Util;

namespace PlayerTracker.Server.Events {
	public class ConnectionEvent {
		private Connection connection;
		private String time;

		public ConnectionEvent(Connection c) {
			this.connection = c;
			this.time = TimeUtils.getTime();
		}

		public String getTimestamp() {
			return this.time;
		}

		public Connection getConnection() {
			return this.connection;
		}
	}
}