﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Net;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PlayerTracker.Server.Util {
	public class DatabaseManager : IDisposable {
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
			this.connection = new MySqlConnection("Server=" + this.host + ";Port=" + this.port + ";UID=" + this.username + ";Password=" + this.password + ";SslMode=Preferred;Database="+this.db);
			this.connection.Open();
		}

		public String getDatabase() {
			return this.db;
		}

		public object executeScalar(string sql) {
			this.reconnect();
			MySqlCommand command = new MySqlCommand(sql, this.connection);
			return command.ExecuteScalar();
		}

		public object executeScalar(MySqlCommand cmd) {
			this.reconnect();
			cmd.Connection = this.connection;
			return cmd.ExecuteScalar();
		}

		public int executeNonQuery(string sql) {
            this.reconnect();
			MySqlCommand command = new MySqlCommand(sql, this.connection);
			return command.ExecuteNonQuery();
		}

		public int executeNonQuery(MySqlCommand cmd){
			this.reconnect();
			cmd.Connection = this.connection;
			return cmd.ExecuteNonQuery();
		}

		public MySqlDataReader executeReader(string sql) {
			this.reconnect();
			MySqlCommand command = new MySqlCommand(sql, this.connection);
			return command.ExecuteReader();
		}

		public MySqlDataReader executeReader(MySqlCommand cmd) {
			this.reconnect();
			cmd.Connection = this.connection;
			return cmd.ExecuteReader();
		}

        private void reconnect() {
            if (this.connection.State != System.Data.ConnectionState.Open)
                this.connect();
        }

		public void Dispose() {
			this.Dispose(true);
		}

		protected virtual void Dispose(bool managed) {
			if (managed) {
				this.connection.Dispose();
			}
		}
	}
}