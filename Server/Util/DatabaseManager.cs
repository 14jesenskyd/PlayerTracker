using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Net;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PlayerTracker.Server.Util {
	public class DatabaseManager {
		private MySqlConnection connection;
		private String host;
		private String username;
		private String password;
		private String db;
		private int port;

		public DatabaseManager(String host, int port, String user, String password, String db) {
			this.host = host;
			this.port = port;
			this.username = user;
			this.password = password;
			this.db = db;
		}

		public void connect() {
			this.connection = new MySqlConnection("Server=" + this.host + ";Port=" + this.port + ";Database=" + this.db + ";UID=" + this.username + ";Password=" + this.password + ";SslMode=Preferred;");
			this.connection.Open();
		}

		public String getDatabase() {
			return this.db;
		}

		public void executeScalar(string sql) {
			MySqlCommand command = new MySqlCommand(sql, this.connection);
			command.ExecuteScalar();
		}

		public void executeNonQuery(string sql) {
			MySqlCommand command = new MySqlCommand(sql, this.connection);
			command.ExecuteNonQuery();
		}

		public void executeReader(string sql) {
			MySqlCommand command = new MySqlCommand(sql, this.connection);
			command.ExecuteReader();
		}
	}
}