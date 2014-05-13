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
    public class Server : IDisposable {
        public const string CONFIG_FILE = "server.cfg";
        private static volatile Server singletonInstance = null;
        private ConnectionManager connectionManager;
        private DatabaseManager dbMan;
        private Logger log;
        private DataManager dataMan;
        private Configuration config;
        private bool accepting;

        private Server()
            : base() {
            Server.singletonInstance = this;
            try {
                this.log = new Logger("log.log");
            } catch (IOException e) {
                Console.WriteLine(e.Message);
            }
            try {
                this.config = Configuration.load(CONFIG_FILE);
                this.connectionManager = new ConnectionManager(this.config.getValue<int>("port", 1534), this.config.getValue<string>("hostname", "127.0.0.1"));
                this.connectionManager.start();
                this.dbMan = new DatabaseManager(this.config.getValue<string>("db-hostname", "127.0.0.1"), this.config.getValue<int>("db-port", 3306), this.config.getValue<string>("db-user", "root"), this.config.getValue<string>("db-password", "root"), this.config.getValue<string>("db-database", "playertracker"));
                this.dbMan.connect();
                this.dataMan = new DataManager();
                this.dataMan.start();

                int rows = this.dbMan.executeNonQuery("SELECT * FROM information_schema.tables WHERE table_schema = 'playertracker' AND table_name = 'users' LIMIT 1;");


                if (rows < 1) {
                    string sql = "";
                    StreamReader reader = new StreamReader("tables.sql");
                    while (reader.Peek() != -1)
                        sql += reader.ReadLine() + "\n";
                    this.dbMan.executeNonQuery(sql);
                }
                this.accepting = true;
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

        public void toggleListening() {
            if (this.accepting) {
                this.connectionManager.stop();
                this.dataMan.stop();
                this.connectionManager.closeConnections();
                this.accepting = false;
            } else {
                this.connectionManager.start();
                this.dataMan.start();
                this.accepting = true;
            }
        }

        public bool isAccepting() {
            return this.accepting;
        }

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

        public override string ToString() {
            return "Server[" + this.getConnectionManager().ToString() + "]";
        }

		public void Dispose() {
			this.Dispose(true);
		}

		protected virtual void Dispose(bool managed) {
			this.config = null;
			this.accepting = false;
			if (managed) {
				this.dbMan.Dispose();
				this.dbMan = null;
				this.connectionManager.Dispose();
				this.connectionManager = null;
				this.dataMan.stop();
				this.log.Dispose();
				this.log = null;
			}
		}
    }
}