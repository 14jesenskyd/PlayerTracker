using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PlayerTracker.Common.Net;
using PlayerTracker.Common.Net.Packets;
using PlayerTracker.Common.Util;

namespace PlayerTracker.Client.Forms {
	public partial class frmPlayerInformation : Form {
		string userId;
        private string playerId;
		private string serverId;

		public frmPlayerInformation(string name, string server, string notes, string violations, UserViolationLevel vl, string id, string serverId, string userId) {
			InitializeComponent();
			this.txtNotes.Text = notes;
			this.txtInfractions.Text = violations;
			this.setViolationLevel(vl);
			this.lblPlayer.Text = name;
			this.lblServer.Text = server;
            this.playerId = id;
			this.serverId = serverId;
			this.userId = userId;
		}

		private void btnSave_Click(object sender, EventArgs e) {
            DataUpdatePacket p = new DataUpdatePacket(this.lblPlayer.Text, this.lblServer.Text, this.txtNotes.Text, this.txtInfractions.Text, this.getViolationLevel(), this.playerId);
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

		private void btnRefresh_Click(object sender, EventArgs e) {
			this.refreshAttachments();
		}

		private void btnBrowse_Click(object sender, EventArgs e) {
			this.showOpen();
		}

		private void showOpen(){
			if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				this.txtPath.Text = open.FileName;
			}
		}

		private void btnUpload_Click(object sender, EventArgs e) {
			List<byte> bytes = new List<byte>();
			UploadAttachmentPacket packet = new UploadAttachmentPacket(this.playerId, this.serverId, this.userId, NetUtils.byteListToArray(bytes));
			packet.sendData(Client.getClient().getConnection());
			this.refreshAttachments();
		}

		private void playerData_SelectedIndexChanged(object sender, EventArgs e) {
			this.refreshAttachments();
		}

		private void txtPath_Click(object sender, EventArgs e) {
			this.showOpen();
		}

		private void btnDownload_Click(object sender, EventArgs e) {
			if(save.ShowDialog() == System.Windows.Forms.DialogResult.OK){
				AttachmentRequestPacket packet = new AttachmentRequestPacket(this.grdAttachments.SelectedRows[0].Cells[0].Value.ToString());
				packet.sendData(Client.getClient().getConnection());
			
				while(!Client.getClient().getRequestManager().hasResponse());
			
				AttachmentResponsePacket response = new AttachmentResponsePacket(Client.getClient().getRequestManager().getResponse());
				byte[] data = response.getAttachmentData();
				StreamWriter writer = new StreamWriter(save.FileName);

				for(int i = 0; i < data.Length; i++){
					writer.Write(NetUtils.bytesToString(data[i]));
				}
				writer.Close();
			}
		}

		private void btnDeleteSS_Click(object sender, EventArgs e) {

		}

		private void refreshAttachments(){
			if (playerData.SelectedIndex == 1) {
				//show wait dialog, thread waiting for list, join afterwards and kill the wait dialog
				AttachmentListRequestPacket packet = new AttachmentListRequestPacket(this.playerId, this.serverId);
				packet.sendData(Client.getClient().getConnection());

				while (!Client.getClient().getRequestManager().hasResponse()) ;

				AttachmentListResponsePacket resp = new AttachmentListResponsePacket(Client.getClient().getRequestManager().getResponse());
				List<Attachment> a = resp.getAttachments();

				foreach (Attachment z in a) {
					DataGridViewRow v = new DataGridViewRow();
					v.CreateCells(this.grdAttachments, z.getID(), z.getUploadingUser(), z.getDateTime().ToShortDateString() + " " + z.getDateTime().ToLongTimeString());
					this.grdAttachments.Rows.Add(v);
				}
			}
		}
	}
}