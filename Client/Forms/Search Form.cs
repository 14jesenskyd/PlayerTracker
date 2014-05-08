using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlayerTracker.Common.Net;
using PlayerTracker.Common.Net.Packets;
using PlayerTracker.Common.Util;
using PlayerTracker.Client.Util;

namespace PlayerTracker.Client.Forms {
	public partial class frmSearch : Form {
		public frmSearch() {
			InitializeComponent();
		}

		private void frmSearch_Load(object sender, EventArgs e) {
			ServerListRequestPacket p = new ServerListRequestPacket(Client.getClient().getUser());
			p.sendData(Client.getClient().getConnection());
			while(!Client.getClient().getRequestManager().hasResponse());
			foreach(string s in ((ServerListResponsePacket)Client.getClient().getRequestManager().getResponse()).getServerList())
			MessageBox.Show(s);
		}

		private void frmSearch_FormClosed(object sender, FormClosedEventArgs e) {
			Client.getClient().stop();
		}
	}
}
