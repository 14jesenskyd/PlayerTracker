using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using PlayerTracker.Common.Util;
using PlayerTracker.Common.Net;
using PlayerTracker.Common.Net.Packets;

namespace PlayerTracker.Client.Forms {
	public partial class frmLogin : Form {
		public frmLogin() {
			InitializeComponent();
			Client.getClient();
		}

		private void btnLogin_Click(object sender, EventArgs e) {
			Client.getClient().connect();
			Packet p = new LoginPacket(txtUsername.Text, txtPassword.Text);
			Client.getClient().getConnection().send(p);
		}

		private void btnExit_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
