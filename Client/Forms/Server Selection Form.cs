using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlayerTracker.Client.Util;

namespace PlayerTracker.Client.Forms {
    public partial class frmServerSelection : Form {
        private List<Server> servers;

        public frmServerSelection(List<Server> servers) {
            InitializeComponent();
            this.servers = servers;
            this.updateList();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            frmServerProperties form = new frmServerProperties(this.getNames());
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.servers.Add(form.getServer());
                this.updateList();
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            base.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (this.lstServers.SelectedIndex == -1) {
                MessageBox.Show("Select a server first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> serverNames = this.getNames();
            serverNames.RemoveAt(this.lstServers.SelectedIndex);
            frmServerProperties form = new frmServerProperties(this.servers[this.lstServers.SelectedIndex], serverNames);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                this.servers[this.lstServers.SelectedIndex] = form.getServer();
                this.updateList();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            if (this.lstServers.SelectedIndex == -1) {
                MessageBox.Show("Select a server first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.servers.RemoveAt(this.lstServers.SelectedIndex);
            this.updateList();
        }

        private void updateList() {
            this.lstServers.Items.Clear();
            foreach (Server server in this.servers) {
                this.lstServers.Items.Add(server.Name + " (" + server.Host + ":" + server.Port.ToString() + ")");
            }
        }

        public Server getSelectedServer() {
            if (this.lstServers.SelectedIndex == -1)
                return null;
            return this.servers[this.lstServers.SelectedIndex];
        }

        private List<string> getNames() {
            List<string> serverNames = new List<string>();
            foreach (Server s in this.servers) {
                serverNames.Add(s.Name);
            }
            return serverNames;
        }

        public List<Server> getServers() {
            return this.servers;
        }
    }
}
