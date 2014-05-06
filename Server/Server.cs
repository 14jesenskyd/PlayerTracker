using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerTracker.Common.Util;
using PlayerTracker.Common.Net;
using PlayerTracker.Server.Util;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace PlayerTracker.Server {
	public class Server {
		private static Server singletonInstance = null;
		private ConnectionManager connectionManager;
		private DatabaseManager dbMan;
		private Logger log;
		private DataManager dataMan;
		private Configuration config;

		private Server()
			: base() {
			try {
				this.log = new Logger("log.log");
			} catch (IOException e) {
				Console.WriteLine(e.Message);
			}
			try {
				this.loadConfiguration("config");
				//this.connectionManager.start();
				this.dataMan = new DataManager();
				//this.dataMan.start();


				//this.connectionManager = new ConnectionManager("127.0.0.1", 1534);
				//this.dbMan = new DatabaseManager("127.0.0.1", 3306, "root", "root", "playertracker");
				//            this.dbMan.connect();
				//
				//            ResultSet r;
				//            PreparedStatement s = this.dbMan.prepareStatement("SELECT * FROM information_schema.tables WHERE table_schema = 'playertracker' AND table_name = 'users' LIMIT 1;");
				//            s.execute();
				//            r = s.getResultSet();
				//            if (!r.first()) {
				//                /*sql to create user table:
				//                create table `"+this.dbMan.getDatabase()+"`.`users`(
				//                    id int not null auto_increment,
				//                    firstName text not null,
				//                    lastName text not null,
				//                    email text not null,
				//                    username text not null,
				//                    pass text not null,
				//                    primary key(id)
				//                );
				//                 */
				//                PreparedStatement statement = this.dbMan.prepareStatement("create table `" + this.dbMan.getDatabase() + "`.`users`(id int not null auto_increment, firstName text not null, lastName text not null, email text not null, username text not null, pass text not null, primary key(id));");
				//                try {
				//                    statement.execute();
				//                } catch (SQLException ex) {
				//                    this.log.error(ex.getMessage());
				//                } finally {
				//                    statement.close();
				//                }
				//            }
				//            s.close();
				//            r.close();
				//
				//            s = this.dbMan.prepareStatement("SELECT * FROM information_schema.tables WHERE table_schema = 'playertracker' AND table_name = 'players' LIMIT 1;");
				//            s.execute();
				//            r = s.getResultSet();
				//            if (!r.first()) {
				//                //TODO create table
				//            }
				//            s.close();
				//            r.close();
			} catch (IOException e) {
				this.log.error(e.Message);
			}
		}

		public static Logger getLogger() {
			return Server.getSingleton()._getLogger();
		}

		public static Server getSingleton() {
			if (Server.singletonInstance == null)
				Server.singletonInstance = new Server();
			return Server.singletonInstance;
		}

		//public static void main(string[] args) {
		//    Server singleton = Server.getSingleton();
		//    ServerGUI gui = new ServerGUI();
		//    singleton.getConnectionManager().registerConnectionListener((evt) -> gui.setConnections(singleton.getConnectionManager().getConnections().size()));
		//}

		private Logger _getLogger() {
			return this.log;
		}

		public ConnectionManager getConnectionManager() {
			return this.connectionManager;
		}

		public DatabaseManager getDbManager() {
			return this.dbMan;
		}

		public Dictionary<IPAddress, Connection> getConnections() {
			return this.connectionManager.getConnections();
		}

		private void loadConfiguration(string filename) {
			if (File.Exists(filename))
				this.config = Configuration.load(filename);
			else
				this.config = new Configuration();
			this.connectionManager = new ConnectionManager(this.config.getValue<int>("port", 1534), this.config.getValue<string>("hostname", "127.0.0.1"));
			this.dbMan = new DatabaseManager(this.config.getValue<string>("db-hostname", "127.0.0.1"), this.config.getValue<int>("db-port", 3306), this.config.getValue<string>("db-user", "root"), this.config.getValue<string>("db-password", "root"), this.config.getValue<string>("db-database", "playertracker"));
		}

		public override string ToString() {
			return "Server[" + this.getConnectionManager().ToString() + "]";
		}
	}
}