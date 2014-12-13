using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PlayerTracker.Common.Forms.Management.Components {
	public partial class GroupComponent : System.Windows.Forms.Control {
		private System.Windows.Forms.Panel pnlGroups;

		public GroupComponent() {
			InitializeComponent();
		}

		public GroupComponent(IContainer container) {
			container.Add(this);

			InitializeComponent();
		}

		public bool isRemoveChecked() {
			return this.chkRemove.Checked;
		}

		public string getName() {
			return this.lblName.Text;
		}

		public bool hasManageUsers() {
			return this.chkManageUsers.Checked;
		}

		public bool hasManageServers() {
			return this.chkManageServers.Checked;
		}

		public bool hasManageGroups() {
			return this.chkManageGroups.Checked;
		}

		public bool hasRemovePlayers() {
			return this.chkDeletePlayers.Checked;
		}
	}
}
