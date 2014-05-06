using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Net;

namespace PlayerTracker.Server.Util {
	public class DatabaseManager {
		private Connection connection;
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
			/* TODO reimplement
		//        jdbc:mysql://[host][:port]/[database]
				//String c = "jdbc:mysql://"+this.host+":"+this.port+"/"+this.db+"?user="+this.username+"&password="+this.password+"&tcpKeepAlive=true&autoReconnect=true";
		//        String c = "jdbc:mysql://"+this.host+":"+this.port+"/"+this.db;
				MysqlDataSource d = new MysqlDataSource();
				//d.setConnectionCollation(c);
				d.setUser(this.username);
				d.setPassword(this.password);
				d.setServerName(this.host);
				d.setPort(this.port);
				d.setDatabaseName(this.db);
				this.connection = d.getConnection();
		//        this.connection = DriverManager.getConnection(c, username,  password);
			 */
		}

		public String getDatabase() {
			return this.db;
		}

		/* TODO reimplement
		public PreparedStatement prepareStatement(String sql) {
			return this.connection.prepareStatement(sql);
		}
		 */
	}
}