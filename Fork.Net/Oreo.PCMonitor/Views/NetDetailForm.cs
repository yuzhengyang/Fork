using Oreo.PCMonitor.Commons;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.UnitConvertUtils;

namespace Oreo.PCMonitor.Views
{
    public partial class NetDetailForm : Form
    {
        public NetDetailForm()
        {
            InitializeComponent();
        }
        private void NetDetailForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                while (true)
                {
                    if (R.NFS.IsNetFlowRun || R.NFS.IsNetPacketRun)
                    {
                        R.Log.v("IsNetFlowRun: " + R.NFS.IsNetFlowRun + " IsNetPacketRun: " + R.NFS.IsNetPacketRun +
                            " Upload: " + R.NFS.NetFlow.UploadData + " Download: " + R.NFS.NetFlow.DownloadData);
                        UIDgProcessDetailUpdate();
                    }
                    Thread.Sleep(10000);
                }
            });
        }

        private void UIDgProcessDetailUpdate()
        {
            if (IsDisposed) return;

            BeginInvoke(new Action(() =>
            {
                if (R.NFS != null && ListTool.HasElements(R.NFS.NetProcessInfoList))
                {
                    label1.Text = "丢包数：" + R.NFS.LostPacketCount;
                    R.NFS.NetProcessInfoList.ForEach(p =>
                    {
                        bool isUpdate = false;
                        foreach (DataGridViewRow r in DgProcessDetail.Rows)
                        {
                            if (r.Cells["CoName"].Value.ToString() == p.ProcessName)
                            {
                                isUpdate = true;
                                r.Cells["CoDownload"].Value = ByteConvertTool.Fmt(p.DownloadData);
                                r.Cells["CoUpload"].Value = ByteConvertTool.Fmt(p.UploadData);
                                r.Cells["CoDownloadCount"].Value = ByteConvertTool.Fmt(p.DownloadDataCount);
                                r.Cells["CoUploadCount"].Value = ByteConvertTool.Fmt(p.UploadDataCount);
                                r.Cells["CoConnectionCount"].Value = p.ConnectCount;
                            }
                        }
                        if (!isUpdate)
                        {
                            DgProcessDetail.Rows.Add(new object[] {
                                p.ProcessIcon,p.ProcessName,
                                ByteConvertTool.Fmt(p.DownloadData),ByteConvertTool.Fmt(p.UploadData),
                                ByteConvertTool.Fmt(p.DownloadDataCount),ByteConvertTool.Fmt(p.UploadDataCount),
                                p.ConnectCount});
                        }
                    });
                }
            }));
        }
    }
}
