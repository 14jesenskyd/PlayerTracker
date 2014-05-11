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

namespace PlayerTracker.Client.Forms {
	public partial class frmPlayerInformation : Form {
        private string id;

		public frmPlayerInformation(string name, string server, string notes, string violations, UserViolationLevel vl, string id) {
			InitializeComponent();
			this.txtNotes.Text = notes;
			this.txtInfractions.Text = violations;
			this.setViolationLevel(vl);
			this.lblPlayer.Text = name;
			this.lblServer.Text = server;
            this.id = id;
		}

		private void btnSave_Click(object sender, EventArgs e) {
            DataUpdatePacket p = new DataUpdatePacket(this.lblPlayer.Text, this.lblServer.Text, this.txtNotes.Text, this.txtInfractions.Text, this.getViolationLevel(), this.id);
            p.sendData(Client.getClient().getConnection());
            this.Close();
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			if(MessageBox.Show("Are you sure you'd like to delete this player?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes){
				//TODO create and send a delete packet
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		private UserViolationLevel getViolationLevel(){
			if(this.radGood.Checked)
				return UserViolationLevel.GOOD;
			else if(this.radWarned.Checked)
				return UserViolationLevel.WARN;
			else if (this.radWarned.Checked)
				return UserViolationLevel.SEVERE;
			return UserViolationLevel.BANNED;
		}

		private void setViolationLevel(UserViolationLevel vl){
			if(vl.Equals(UserViolationLevel.GOOD)){
				this.radGood.Checked = true;
			}else if(vl.Equals(UserViolationLevel.WARN)){
				this.radWarned.Checked = true;
			}else if(vl.Equals(UserViolationLevel.SEVERE)){
				this.radSevere.Checked = true;
			}else{
				this.radBanned.Checked = true;
			}
		}
	}
}
