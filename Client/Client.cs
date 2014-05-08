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
	class Client {
		private static Client client = null;
		private Logger logger;
		private Connection connection;
		private RequestManager requestMan;
		private IPEndPoint iep;
		private string user;

		private Client() {
			this.logger = new Logger("log.log");
			Configuration c = Configuration.load("config.cfg");
			string ipstring = c.getValue<string>("serverhost", "127.0.0.1");
			byte[] ip = new byte[ipstring.Split('.').Length];
			int i = 0;
			foreach (string s in ipstring.Split('.'))
				ip[i++] = byte.Parse(s);
			this.iep = new IPEndPoint(new IPAddress(ip), c.getValue<int>("serverport", 1534));
		}

		public static Logger getLogger() {
			return getClient()._getLogger();
		}

		public string getUser(){
			return this.user;
		}

		public void setUser(string user){
			this.user = user;
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
	}
}