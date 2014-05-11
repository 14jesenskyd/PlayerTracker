using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlayerTracker.Client.Util;

namespace PlayerTracker.Client.Forms {
    public partial class frmServerProperties : Form {
        private Server server;
        private List<string> names;

        public frmServerProperties() {
            InitializeComponent();
            this.names = new List<string>();
        }

        public frmServerProperties(List<string> serverNames) {
            InitializeComponent();
            this.names = serverNames;
        }

        public frmServerProperties(Server s, List<string> serverNames) {
            InitializeComponent();
            this.names = serverNames;
            this.txtServerName.Text = s.Name;
            this.txtServerHost.Text = s.Host;
            this.txtServerPort.Text = s.Port.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (this.names.Contains(this.txtServerName.Text)) {
                MessageBox.Show("A different server is already named that.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ushort port;
            if (ushort.TryParse(this.txtServerPort.Text, out port) && port != 0) {
                this.server = new Server(this.txtServerName.Text, this.txtServerHost.Text, port);
                base.DialogResult = System.Windows.Forms.DialogResult.OK;
            } else {
                MessageBox.Show("Enter a valid positive integer between 1 and 65,535, inclusive.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Server getServer() {
            return this.server;
        }
    }
}
