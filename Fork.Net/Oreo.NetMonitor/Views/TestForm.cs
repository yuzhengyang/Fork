using Oreo.NetMonitor.Commons;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.NetUtils.NetInfoUtils;

namespace Oreo.NetMonitor.Views
{
    public partial class TestForm : Form
    {
        NetflowTool nft = new NetflowTool();
        public TestForm()
        {
            InitializeComponent();
        }
        private void TestForm_Load(object sender, EventArgs e)
        {
            PerformanceCounterCategory performanceCounterCategory = new PerformanceCounterCategory("Network Interface");
            string[] instances = performanceCounterCategory.GetInstanceNames();

            var info = NetcardInfoTool.GetNetworkCardInfo();


            

            Task.Factory.StartNew(() =>
            {
                nft.InitNetcard("Intel[R] Dual Band Wireless-AC 3165");//Intel(R) Dual Band Wireless-AC 3165
                nft.InitSettings(1000, 1000);
                nft.StartDataMonitor();

                while (true)
                {
                    R.Log.v("upload data: " + nft.UploadData + " download data: " + nft.DownloadData);
                    Thread.Sleep(1000);
                }
            });



            //var a = NetProcessTool.GetTcpConn();
            //var b = NetProcessTool.GetUdpConn();
        }
    }
}
