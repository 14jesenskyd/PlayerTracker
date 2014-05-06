using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Net;

namespace PlayerTracker.Server.Events {
	public class DataTransmissionEvent {
		private byte[] data;
		private Connection connection;

		public DataTransmissionEvent(Connection connection, params byte[] data) {
			this.data = data;
			this.connection = connection;
		}

		public Connection getConnection() {
			return this.connection;
		}

		public byte[] getData() {
			return this.data;
		}
	}
}