using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayerTracker.Client.Util {
    [Serializable]
    public class ServerAddress {
        private string name;
        private string hostname;
        private ushort port;

        public ServerAddress(string name, string hostname, ushort port) {
            this.name = name;
            this.hostname = hostname;
            this.port = port;
        }

        public ServerAddress(string hostname, ushort port) {
            this.name = "";
            this.hostname = hostname;
            this.port = port;
        }

        public string Name {
            get {
                return this.name;
            }
            set {
                this.name = value;
            }
        }

        public string Host {
            get {
                return this.hostname;
            }
            set {
                this.hostname = value;
            }
        }

        public ushort Port {
            get {
                return this.port;
            }
            set {
                this.port = value;
            }
        }
    }
}