using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlayerTracker.Client.Util;
using PlayerTracker.Common.Util;

namespace PlayerTracker.Client.Forms {
    public partial class frmConfiguration : Form {
        private Configuration config;

        public frmConfiguration() {
            InitializeComponent();
            this.config = Client.getClient().getConfiguration();
            this.lblServer.Text = this.config.getValue<Server>("activeServer", new Server("Default", "127.0.0.1", 1534)).Name;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Client.getClient().setConfiguration(this.config);
            Configuration.save(Client.CONFIG_FILE, this.config);
            base.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnChangeServer_Click(object sender, EventArgs e) {
            frmServerSelection form = new frmServerSelection(this.config.getValue<List<Server>>("serverList", new List<Server>()));
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.config.setValue<List<Server>>("serverList", form.getServers());
                if (form.getSelectedServer() == null) {
                    MessageBox.Show("Because you didn't select a server, default localhost settings will be used.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.config.setValue<Server>("activeServer", new Server("127.0.0.1", 1534));
                    this.lblServer.Text = "Default";
                } else {
                    this.lblServer.Text = form.getSelectedServer().Name;
                    this.config.setValue<Server>("activeServer", form.getSelectedServer());
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}