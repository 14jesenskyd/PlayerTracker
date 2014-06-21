namespace PlayerTracker.Client.Forms {
	partial class frmSearch {
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
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.lstServer = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.grpServer = new System.Windows.Forms.GroupBox();
			this.txtPlayer = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manageGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.grpServer.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(12, 135);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 0;
			this.btnSearch.Text = "&Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(146, 135);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 1;
			this.btnExit.Text = "E&xit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// lstServer
			// 
			this.lstServer.FormattingEnabled = true;
			this.lstServer.Location = new System.Drawing.Point(6, 19);
			this.lstServer.Name = "lstServer";
			this.lstServer.Size = new System.Drawing.Size(183, 108);
			this.lstServer.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "&Player:";
			// 
			// grpServer
			// 
			this.grpServer.Controls.Add(this.lstServer);
			this.grpServer.Location = new System.Drawing.Point(227, 31);
			this.grpServer.Name = "grpServer";
			this.grpServer.Size = new System.Drawing.Size(200, 139);
			this.grpServer.TabIndex = 5;
			this.grpServer.TabStop = false;
			this.grpServer.Text = "Server";
			// 
			// txtPlayer
			// 
			this.txtPlayer.Location = new System.Drawing.Point(80, 72);
			this.txtPlayer.Name = "txtPlayer";
			this.txtPlayer.Size = new System.Drawing.Size(115, 20);
			this.txtPlayer.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.adminToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(436, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			// 
			// adminToolStripMenuItem
			// 
			this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageGroupsToolStripMenuItem,
            this.manageUsersToolStripMenuItem});
			this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
			this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.adminToolStripMenuItem.Text = "Admin";
			this.adminToolStripMenuItem.Visible = false;
			// 
			// manageGroupsToolStripMenuItem
			// 
			this.manageGroupsToolStripMenuItem.Name = "manageGroupsToolStripMenuItem";
			this.manageGroupsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.manageGroupsToolStripMenuItem.Text = "Manage Groups...";
			this.manageGroupsToolStripMenuItem.Click += new System.EventHandler(this.manageGroupsToolStripMenuItem_Click);
			// 
			// manageUsersToolStripMenuItem
			// 
			this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
			this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.manageUsersToolStripMenuItem.Text = "Manage Users...";
			this.manageUsersToolStripMenuItem.Click += new System.EventHandler(this.manageUsersToolStripMenuItem_Click);
			// 
			// frmSearch
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(436, 189);
			this.Controls.Add(this.txtPlayer);
			this.Controls.Add(this.grpServer);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmSearch";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search People";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSearch_FormClosed);
			this.Load += new System.EventHandler(this.frmSearch_Load);
			this.grpServer.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.ListBox lstServer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpServer;
		private System.Windows.Forms.TextBox txtPlayer;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem manageGroupsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
	}
}