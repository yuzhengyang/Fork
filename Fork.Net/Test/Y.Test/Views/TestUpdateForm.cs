using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Y.Test.Commons;
using Y.Utils.AppUtils.UpdateUtils;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.DelegateUtils;
using Y.Utils.IOUtils.TxtUtils;

namespace Y.Test.Views
{
    public partial class TestUpdateForm : Form
    {
        public TestUpdateForm()
        {
            InitializeComponent();
        }

        private void TestUpdateForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppUpdateTool aut = new AppUpdateTool();
            aut.Update("Oreo.NetMan", new Version(Application.ProductVersion),
                "http://localhost:20001/Update/Get?name=lalala",
                R.Paths.Temp, R.Paths.Relative,
                UIDownProgress, null, UIUnpackProgress, null);
        }
        private void UIDownProgress(object sender, ProgressEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                progressBar1.Value = (int)(e.Current * 100 / e.Total);
            }));
        }
        private void UIUnpackProgress(object sender, ProgressEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                progressBar2.Value = (int)(e.Current * 100 / e.Total);
            }));
        }
    }
}
