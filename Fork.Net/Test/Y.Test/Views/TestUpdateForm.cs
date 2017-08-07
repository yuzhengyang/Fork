using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Test.Commons;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.DelegateUtils;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.TxtUtils;
using Y.Utils.UpdateUtils;

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
            FilePackageTool.Pack(@"D:\CoCo\Work\IMOS小助手\IMOS.Assistant\程序发布\1.0.0.0", @"D:\CoCo\Work\IMOS小助手\IMOS.Assistant\程序发布\所有版本打包\Assistant[1.0.0.0].udp");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                //AppUpdateTool aut = new AppUpdateTool();
                //int updateCode = aut.Update("Oreo.NetMan", new Version(Application.ProductVersion),
                //    "http://localhost:20001/Update/Get?name=lalala",
                //    R.Paths.Temp, R.Paths.Relative,
                //    UIDownProgress, null, UIUnpackProgress, null);
                //UIUpdateCode(updateCode);
            });
        }
        private void UIDownProgress(object sender, ProgressEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                progressBar1.Value = (int)(e.Current * 100 / e.Total);
                label1.Text = string.Format("{0} / {1}", e.Current, e.Total);
            }));
        }
        private void UIUnpackProgress(object sender, ProgressEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                progressBar2.Value = (int)(e.Current * 100 / e.Total);
                label2.Text = string.Format("{0} / {1}", e.Current, e.Total);
            }));
        }
        private void UIUpdateCode(int code)
        {
            BeginInvoke(new Action(() =>
            {
                label3.Text = code.ToString();
            }));
        }
    }
}
