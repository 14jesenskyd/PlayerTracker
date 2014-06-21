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
using PlayerTracker.Client.Forms.Management;

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
			if (this.lstServer.SelectedIndex == -1) {
				MessageBox.Show("Select a server to search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if(this.txtPlayer.Text.Length == 0){
				MessageBox.Show("Enter a player to search for.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			FetchPacket packet = new FetchPacket(this.txtPlayer.Text, (string)this.lstServer.SelectedItem);
			packet.sendData(Client.getClient().getConnection());
			while(!Client.getClient().getRequestManager().hasResponse());
			DataResponsePacket p = (DataResponsePacket)Client.getClient().getRequestManager().getResponse();
			new frmPlayerInformation(p.getName(), p.getServer(), p.getNotes(), p.getViolations(), p.getViolationLevel(), p.getID(), p.getServerId(), Client.getClient().getUserId()).ShowDialog();
		}

		private void manageGroupsToolStripMenuItem_Click(object sender, EventArgs e) {
			//TODO grab groups from server; pass them to the gui
			GroupManagementForm form = new GroupManagementForm();
			form.ShowDialog();
		}

		private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e) {
			//TODO grab users from server; pass them to the gui
			UserManagementForm form = new UserManagementForm();
			form.ShowDialog();
		}
	}
}