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
            while (!Client.getClient().getRequestManager().hasResponse()) ;
            LoginResponsePacket r = (LoginResponsePacket)Client.getClient().getRequestManager().getResponse();
			if(r.getResponse().Equals(LoginResponsePacket.LoginResponse.SUCCESS)){
				this.Hide();
				Client.getClient().setUser(txtUsername.Text);
				new frmSearch().ShowDialog();
			}else{
				MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void btnExit_Click(object sender, EventArgs e) {
			this.Close();
		}

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e) {
            if (Client.getClient().getConnection() != null && !Client.getClient().getConnection().isClosed()) {
                Client.getClient().getRequestManager().stop();
                Client.getClient().getConnection().close();
            }
        }
	}
}
