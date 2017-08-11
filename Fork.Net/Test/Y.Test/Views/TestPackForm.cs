using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Y.Utils.DelegateUtils;
using Y.Utils.IOUtils.FileUtils;

namespace Y.Test.Views
{
    public partial class TestPackForm : Form
    {
        public TestPackForm()
        {
            InitializeComponent();
        }
        private void BTPack_Click(object sender, EventArgs e)
        {
            FilePackageTool.Pack(TBFrom.Text, TBTo.Text, UIProgress);
        }
        private void BTUnpack_Click(object sender, EventArgs e)
        {
            FilePackageTool.Unpack(TBFrom.Text, TBTo.Text, UIProgress);
        }
        private void UIProgress(object sender, ProgressEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                progressBar1.Value = (int)(e.Current * 100 / e.Total);
                label1.Text = string.Format("{0} / {1}", e.Current, e.Total);
            }));
        }


    }
}
