using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using PlayerTracker.Common.Util;
using PlayerTracker.Common.Net;
using PlayerTracker.Client.Util;

namespace PlayerTracker.Client {
    class Client : IDisposable {
        public const string CONFIG_FILE = "client.cfg";
		private static Client client = null;
		private Logger logger;
		private Connection connection;
		private RequestManager requestMan;
		private IPEndPoint iep;
		private string user;
		private string userId;
        private Configuration config;

		private Client() {
			this.logger = new Logger("log.log");
            this.config = null;
		}

		public static Logger getLogger() {
			return getClient()._getLogger();
		}

		public string getUser() {
			return this.user;
		}

		public void setUser(string user) {
			this.user = user;
		}

		public string getUserId() {
			return this.userId;
		}

		public void setUserId(string userId) {
			this.userId = userId;
		}

		public static Client getClient() {
			if (Client.client == null)
				try {
					client = new Client();
				} catch (IOException e) {
					Console.WriteLine(null, "Logging is disabled: " + e.Message);
				}
			return Client.client;
		}

        public void connect() {
			if(this.connection != null && !this.connection.isClosed())
				return;
            Server server = this.getConfiguration().getValue<Server>("activeServer", new Server("127.0.0.1", 1534));
            string ipstring = server.Host;
            byte[] ip = new byte[ipstring.Split('.').Length];
            int i = 0;
            foreach (string s in ipstring.Split('.'))
                ip[i++] = byte.Parse(s);
            this.iep = new IPEndPoint(new IPAddress(ip), server.Port);

			this.connection = new Connection(this.iep);
			this.requestMan = new RequestManager();
			this.requestMan.start();
		}

		public RequestManager getRequestManager() {
			return this.requestMan;
		}

		public Connection getConnection() {
			return this.connection;
		}

		private Logger _getLogger() {
			return this.logger;
		}

		public override string ToString() {
			return "Client[connected=" + this.connection.isClosed() + "]";
		}

		public void stop() {
			if (Client.getClient().getConnection() != null && !Client.getClient().getConnection().isClosed()) {
				Client.getClient().getRequestManager().stop();
				Client.getClient().getConnection().close();
			}
		}

        public Configuration getConfiguration() {
            if (this.config == null)
                this.config = Configuration.load(CONFIG_FILE);
            return this.config;
        }

        public void setConfiguration(Configuration config) {
            this.config = config;
        }

		public void Dispose() {

		}

		protected virtual void Dispose(bool managed) {
			if (managed) {
				this.connection.Dispose();
				this.logger.Dispose();
				this.requestMan.stop();
			}
		}
	}
}