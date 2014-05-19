namespace PlayerTracker.Client.Forms {
	partial class frmPlayerInformation {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.txtInfractions = new System.Windows.Forms.TextBox();
			this.playerData = new System.Windows.Forms.TabControl();
			this.tabPlayerInfo = new System.Windows.Forms.TabPage();
			this.grpStatus = new System.Windows.Forms.GroupBox();
			this.radBanned = new System.Windows.Forms.RadioButton();
			this.radSevere = new System.Windows.Forms.RadioButton();
			this.radWarned = new System.Windows.Forms.RadioButton();
			this.radGood = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabAttachments = new System.Windows.Forms.TabPage();
			this.btnDownload = new System.Windows.Forms.Button();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnDeleteSS = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnUpload = new System.Windows.Forms.Button();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.grdAttachments = new System.Windows.Forms.DataGridView();
			this.screenshotId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UploadingUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.screenshotDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.lblPlayer = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblServer = new System.Windows.Forms.Label();
			this.open = new System.Windows.Forms.OpenFileDialog();
			this.save = new System.Windows.Forms.SaveFileDialog();
			this.playerData.SuspendLayout();
			this.tabPlayerInfo.SuspendLayout();
			this.grpStatus.SuspendLayout();
			this.tabAttachments.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAttachments)).BeginInit();
			this.SuspendLayout();
			// 
			// txtNotes
			// 
			this.txtNotes.Location = new System.Drawing.Point(8, 22);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.Size = new System.Drawing.Size(260, 131);
			this.txtNotes.TabIndex = 1;
			// 
			// txtInfractions
			// 
			this.txtInfractions.Location = new System.Drawing.Point(274, 20);
			this.txtInfractions.Multiline = true;
			this.txtInfractions.Name = "txtInfractions";
			this.txtInfractions.Size = new System.Drawing.Size(183, 187);
			this.txtInfractions.TabIndex = 3;
			// 
			// playerData
			// 
			this.playerData.Controls.Add(this.tabPlayerInfo);
			this.playerData.Controls.Add(this.tabAttachments);
			this.playerData.Location = new System.Drawing.Point(12, 35);
			this.playerData.Name = "playerData";
			this.playerData.SelectedIndex = 0;
			this.playerData.Size = new System.Drawing.Size(470, 238);
			this.playerData.TabIndex = 4;
			this.playerData.SelectedIndexChanged += new System.EventHandler(this.playerData_SelectedIndexChanged);
			// 
			// tabPlayerInfo
			// 
			this.tabPlayerInfo.Controls.Add(this.grpStatus);
			this.tabPlayerInfo.Controls.Add(this.label2);
			this.tabPlayerInfo.Controls.Add(this.label1);
			this.tabPlayerInfo.Controls.Add(this.txtNotes);
			this.tabPlayerInfo.Controls.Add(this.txtInfractions);
			this.tabPlayerInfo.Location = new System.Drawing.Point(4, 22);
			this.tabPlayerInfo.Name = "tabPlayerInfo";
			this.tabPlayerInfo.Padding = new System.Windows.Forms.Padding(3);
			this.tabPlayerInfo.Size = new System.Drawing.Size(462, 212);
			this.tabPlayerInfo.TabIndex = 0;
			this.tabPlayerInfo.Text = "Player Information";
			this.tabPlayerInfo.UseVisualStyleBackColor = true;
			// 
			// grpStatus
			// 
			this.grpStatus.Controls.Add(this.radBanned);
			this.grpStatus.Controls.Add(this.radSevere);
			this.grpStatus.Controls.Add(this.radWarned);
			this.grpStatus.Controls.Add(this.radGood);
			this.grpStatus.Location = new System.Drawing.Point(8, 159);
			this.grpStatus.Name = "grpStatus";
			this.grpStatus.Size = new System.Drawing.Size(260, 50);
			this.grpStatus.TabIndex = 4;
			this.grpStatus.TabStop = false;
			this.grpStatus.Text = "&Account Status";
			// 
			// radBanned
			// 
			this.radBanned.AutoSize = true;
			this.radBanned.Location = new System.Drawing.Point(197, 19);
			this.radBanned.Name = "radBanned";
			this.radBanned.Size = new System.Drawing.Size(62, 17);
			this.radBanned.TabIndex = 3;
			this.radBanned.TabStop = true;
			this.radBanned.Text = "&Banned";
			this.radBanned.UseVisualStyleBackColor = true;
			// 
			// radSevere
			// 
			this.radSevere.AutoSize = true;
			this.radSevere.Location = new System.Drawing.Point(132, 19);
			this.radSevere.Name = "radSevere";
			this.radSevere.Size = new System.Drawing.Size(59, 17);
			this.radSevere.TabIndex = 2;
			this.radSevere.TabStop = true;
			this.radSevere.Text = "Se&vere";
			this.radSevere.UseVisualStyleBackColor = true;
			// 
			// radWarned
			// 
			this.radWarned.AutoSize = true;
			this.radWarned.Location = new System.Drawing.Point(63, 19);
			this.radWarned.Name = "radWarned";
			this.radWarned.Size = new System.Drawing.Size(63, 17);
			this.radWarned.TabIndex = 1;
			this.radWarned.TabStop = true;
			this.radWarned.Text = "&Warned";
			this.radWarned.UseVisualStyleBackColor = true;
			// 
			// radGood
			// 
			this.radGood.AutoSize = true;
			this.radGood.Location = new System.Drawing.Point(6, 19);
			this.radGood.Name = "radGood";
			this.radGood.Size = new System.Drawing.Size(51, 17);
			this.radGood.TabIndex = 0;
			this.radGood.TabStop = true;
			this.radGood.Text = "&Good";
			this.radGood.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(270, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "&Infractions:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Notes:";
			// 
			// tabAttachments
			// 
			this.tabAttachments.Controls.Add(this.btnDownload);
			this.tabAttachments.Controls.Add(this.txtPath);
			this.tabAttachments.Controls.Add(this.label4);
			this.tabAttachments.Controls.Add(this.btnDeleteSS);
			this.tabAttachments.Controls.Add(this.btnRefresh);
			this.tabAttachments.Controls.Add(this.btnUpload);
			this.tabAttachments.Controls.Add(this.btnBrowse);
			this.tabAttachments.Controls.Add(this.grdAttachments);
			this.tabAttachments.Location = new System.Drawing.Point(4, 22);
			this.tabAttachments.Name = "tabAttachments";
			this.tabAttachments.Padding = new System.Windows.Forms.Padding(3);
			this.tabAttachments.Size = new System.Drawing.Size(462, 212);
			this.tabAttachments.TabIndex = 1;
			this.tabAttachments.Text = "Attachments";
			this.tabAttachments.UseVisualStyleBackColor = true;
			// 
			// btnDownload
			// 
			this.btnDownload.Location = new System.Drawing.Point(177, 150);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(109, 23);
			this.btnDownload.TabIndex = 7;
			this.btnDownload.Text = "Download Selected";
			this.btnDownload.UseVisualStyleBackColor = true;
			this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(69, 31);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(209, 20);
			this.txtPath.TabIndex = 6;
			this.txtPath.Click += new System.EventHandler(this.txtPath_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(19, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Upload:";
			// 
			// btnDeleteSS
			// 
			this.btnDeleteSS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.btnDeleteSS.Location = new System.Drawing.Point(331, 150);
			this.btnDeleteSS.Name = "btnDeleteSS";
			this.btnDeleteSS.Size = new System.Drawing.Size(109, 23);
			this.btnDeleteSS.TabIndex = 4;
			this.btnDeleteSS.Text = "Delete Selected";
			this.btnDeleteSS.UseVisualStyleBackColor = true;
			this.btnDeleteSS.Visible = false;
			this.btnDeleteSS.Click += new System.EventHandler(this.btnDeleteSS_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(22, 150);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(109, 23);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnUpload
			// 
			this.btnUpload.Location = new System.Drawing.Point(365, 29);
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.Size = new System.Drawing.Size(75, 23);
			this.btnUpload.TabIndex = 2;
			this.btnUpload.Text = "Upload";
			this.btnUpload.UseVisualStyleBackColor = true;
			this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(284, 29);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// grdAttachments
			// 
			this.grdAttachments.AllowUserToAddRows = false;
			this.grdAttachments.AllowUserToDeleteRows = false;
			this.grdAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdAttachments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.screenshotId,
            this.UploadingUser,
            this.screenshotDate});
			this.grdAttachments.Location = new System.Drawing.Point(22, 58);
			this.grdAttachments.Name = "grdAttachments";
			this.grdAttachments.ReadOnly = true;
			this.grdAttachments.Size = new System.Drawing.Size(418, 86);
			this.grdAttachments.TabIndex = 0;
			// 
			// screenshotId
			// 
			this.screenshotId.HeaderText = "ID";
			this.screenshotId.Name = "screenshotId";
			this.screenshotId.ReadOnly = true;
			this.screenshotId.Width = 75;
			// 
			// UploadingUser
			// 
			this.UploadingUser.HeaderText = "uploadingUser";
			this.UploadingUser.Name = "UploadingUser";
			this.UploadingUser.ReadOnly = true;
			this.UploadingUser.Width = 150;
			// 
			// screenshotDate
			// 
			this.screenshotDate.HeaderText = "Date";
			this.screenshotDate.Name = "screenshotDate";
			this.screenshotDate.ReadOnly = true;
			this.screenshotDate.Width = 150;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(108, 280);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(89, 23);
			this.btnSave.TabIndex = 5;
			this.btnSave.Text = "&Save && Close";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.btnDelete.Location = new System.Drawing.Point(203, 280);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(89, 23);
			this.btnDelete.TabIndex = 6;
			this.btnDelete.Text = "&Delete Player";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Visible = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(298, 280);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(89, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Player:";
			// 
			// lblPlayer
			// 
			this.lblPlayer.AutoEllipsis = true;
			this.lblPlayer.Location = new System.Drawing.Point(57, 9);
			this.lblPlayer.Name = "lblPlayer";
			this.lblPlayer.Size = new System.Drawing.Size(181, 23);
			this.lblPlayer.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(244, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Server:";
			// 
			// lblServer
			// 
			this.lblServer.AutoEllipsis = true;
			this.lblServer.Location = new System.Drawing.Point(291, 9);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(191, 23);
			this.lblServer.TabIndex = 3;
			// 
			// open
			// 
			this.open.Filter = "PNG Images|*.png|JPEG Images|*.jpg,*.jpeg";
			this.open.Title = "Upload File";
			// 
			// frmPlayerInformation
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 316);
			this.Controls.Add(this.lblServer);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblPlayer);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.playerData);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmPlayerInformation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Player Information";
			this.playerData.ResumeLayout(false);
			this.tabPlayerInfo.ResumeLayout(false);
			this.tabPlayerInfo.PerformLayout();
			this.grpStatus.ResumeLayout(false);
			this.grpStatus.PerformLayout();
			this.tabAttachments.ResumeLayout(false);
			this.tabAttachments.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdAttachments)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.TextBox txtInfractions;
		private System.Windows.Forms.TabControl playerData;
		private System.Windows.Forms.TabPage tabPlayerInfo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabPage tabAttachments;
		private System.Windows.Forms.GroupBox grpStatus;
		private System.Windows.Forms.RadioButton radGood;
		private System.Windows.Forms.RadioButton radBanned;
		private System.Windows.Forms.RadioButton radSevere;
		private System.Windows.Forms.RadioButton radWarned;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblPlayer;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.DataGridView grdAttachments;
		private System.Windows.Forms.Button btnUpload;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button btnDeleteSS;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnDownload;
		private System.Windows.Forms.DataGridViewTextBoxColumn screenshotId;
		private System.Windows.Forms.DataGridViewTextBoxColumn UploadingUser;
		private System.Windows.Forms.DataGridViewTextBoxColumn screenshotDate;
		private System.Windows.Forms.OpenFileDialog open;
		private System.Windows.Forms.SaveFileDialog save;
	}
}