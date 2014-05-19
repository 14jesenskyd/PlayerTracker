using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlayerTracker.Server.Util;
using PlayerTracker.Common.Util;

namespace PlayerTracker.Server.Forms {
	public partial class frmServer : Form {
		public frmServer() {
			InitializeComponent();
			Server.getSingleton();
		}

		private void btnToggleListening_Click(object sender, EventArgs e) {
			Server.getSingleton().toggleListening();
			this.lblStatus.Text = "Server is currently "+(Server.getSingleton().isAccepting() ? "" : "not ")+"accepting connections.";
		}

		private void btnViewConnections_Click(object sender, EventArgs e) {

		}

		private void btnConfigure_Click(object sender, EventArgs e) {
            new frmConfiguration().ShowDialog();
		}

		private void frmServer_FormClosed(object sender, FormClosedEventArgs e) {
			if(Server.getSingleton().isAccepting()){
			    Server.getSingleton().toggleListening();
				Server.getSingleton().getDbManager().Dispose();
			}
		}
	}
}