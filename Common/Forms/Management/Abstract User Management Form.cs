using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlayerTracker.Common.Forms.Management {
	public abstract partial class AbstractUserManagementForm : Form {
		public AbstractUserManagementForm() {
			InitializeComponent();
		}

		protected abstract void btnRemove_Click(object sender, EventArgs e);

		protected abstract void btnAdd_Click(object sender, EventArgs e);

		protected abstract void btnCancel_Click(object sender, EventArgs e);

		protected abstract void btnSave_Click(object sender, EventArgs e);

		protected abstract void FormLoad(object sender, EventArgs e);
	}
}
