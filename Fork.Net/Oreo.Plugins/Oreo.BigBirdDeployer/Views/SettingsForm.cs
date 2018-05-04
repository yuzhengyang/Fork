using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oreo.BigBirdDeployer.Views
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void BTSave_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
        }

        private void BTCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool Save()
        {
            return false;
        }
    }
}
