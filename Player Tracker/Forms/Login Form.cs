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

namespace PlayerTracker.Forms {
	public partial class frmLogin : Form {
		public frmLogin() {
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e) {
			Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			
		}

		private void btnExit_Click(object sender, EventArgs e) {
			this.Close();
		}
	}
}
