using System;
using System.Windows.Forms;
using Y.Utils.WindowsUtils.InfoUtils;

namespace Oreo.NetMonitor.Views
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }
        private void TestForm_Load(object sender, EventArgs e)
        {
            var a = NetProcessTool.GetTcpConn();
            var b = NetProcessTool.GetUdpConn();
        }
    }
}
