using Oreo.NetMonitor.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.UnitConvertUtils;
using Y.Utils.NetUtils.NetInfoUtils;

namespace Oreo.NetMonitor.Views
{
    public partial class TestForm : Form
    {
        NetFlowTool nft = new NetFlowTool();
        List<NetPacketTool> npt = new List<NetPacketTool>();
        public TestForm()
        {
            InitializeComponent();
        }
        private void TestForm_Load(object sender, EventArgs e)
        {
            nft.Start();
            nft.DataMonitorEvent += DataMonitorEvent;

            List<IPAddress> hosts = NetCardInfoTool.GetIPv4Address();
            foreach (var host in hosts)
            {
                NetPacketTool p = new NetPacketTool(host);
                p.NewPacket += new NewPacketEventHandler(OnNewPacket);
                p.Start();
                npt.Add(p);
            }
        }
        public void DataMonitorEvent(NetFlowTool n)
        {
            R.Log.v("upload data: " + ByteConvertTool.Fmt(n.UploadData) +
                " download data: " + ByteConvertTool.Fmt(n.DownloadData));
        }
        private void OnNewPacket(NetPacketTool pm, Packet p)
        {
            R.Log.e(p.TotalLength);
        }
    }
}
