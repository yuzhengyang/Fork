using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
