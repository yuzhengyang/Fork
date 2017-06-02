using System;
using System.Windows.Forms;

namespace Oreo.PCMonitor.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            new NetDetailForm().Show();
        }
    }
}
