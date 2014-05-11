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
				this.lstServer.Items.Add(s);
		}

		private void frmSearch_FormClosed(object sender, FormClosedEventArgs e) {
			Client.getClient().stop();
		}

		private void btnExit_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void btnSearch_Click(object sender, EventArgs e) {
			FetchPacket packet = new FetchPacket(this.txtPlayer.Text, (string)this.lstServer.SelectedItem);
			packet.sendData(Client.getClient().getConnection());
			while(!Client.getClient().getRequestManager().hasResponse());
			DataResponsePacket p = (DataResponsePacket)Client.getClient().getRequestManager().getResponse();
			new frmPlayerInformation(p.getName(), p.getServer(), p.getNotes(), p.getViolations(), p.getViolationLevel(), p.getID()).ShowDialog();
		}
	}
}