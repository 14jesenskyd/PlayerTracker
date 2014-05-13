﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PlayerTracker.Client.Forms {
	public partial class WaitDialog : Form {
		public WaitDialog(string text = "Action is being performed...") {
			InitializeComponent();
			this.lblText.Text = text;
		}
	}
}
