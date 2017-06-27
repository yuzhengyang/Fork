using System;
using System.Windows.Forms;
using Y.Skin.YoForm.NoTitle;

namespace Oreo.FaultLog.Views
{
    public partial class MainForm : NoTitleForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LbAppVersion.Text = string.Format("当前版本：{0}", Application.ProductVersion);
        }

        private void BtMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
