namespace PlayerTracker.Server.Forms {
	partial class frmServer {
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
			this.lblStatus = new System.Windows.Forms.Label();
			this.btnToggleListening = new System.Windows.Forms.Button();
			this.btnViewConnections = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnConfigure = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(12, 18);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(153, 13);
			this.lblStatus.TabIndex = 0;
			this.lblStatus.Text = "Server is currently not listening.";
			// 
			// btnToggleListening
			// 
			this.btnToggleListening.Location = new System.Drawing.Point(195, 13);
			this.btnToggleListening.Name = "btnToggleListening";
			this.btnToggleListening.Size = new System.Drawing.Size(75, 23);
			this.btnToggleListening.TabIndex = 1;
			this.btnToggleListening.Text = "Toggle";
			this.btnToggleListening.UseVisualStyleBackColor = true;
			this.btnToggleListening.Click += new System.EventHandler(this.btnToggleListening_Click);
			// 
			// btnViewConnections
			// 
			this.btnViewConnections.Location = new System.Drawing.Point(195, 42);
			this.btnViewConnections.Name = "btnViewConnections";
			this.btnViewConnections.Size = new System.Drawing.Size(75, 23);
			this.btnViewConnections.TabIndex = 3;
			this.btnViewConnections.Text = "View all...";
			this.btnViewConnections.UseVisualStyleBackColor = true;
			this.btnViewConnections.Click += new System.EventHandler(this.btnViewConnections_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Current connections: 0";
			// 
			// btnConfigure
			// 
			this.btnConfigure.Location = new System.Drawing.Point(195, 71);
			this.btnConfigure.Name = "btnConfigure";
			this.btnConfigure.Size = new System.Drawing.Size(75, 23);
			this.btnConfigure.TabIndex = 4;
			this.btnConfigure.Text = "Configure...";
			this.btnConfigure.UseVisualStyleBackColor = true;
			this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
			// 
			// frmServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(282, 107);
			this.Controls.Add(this.btnConfigure);
			this.Controls.Add(this.btnViewConnections);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnToggleListening);
			this.Controls.Add(this.lblStatus);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmServer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Player Tracker Server";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Button btnToggleListening;
		private System.Windows.Forms.Button btnViewConnections;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnConfigure;
	}
}

