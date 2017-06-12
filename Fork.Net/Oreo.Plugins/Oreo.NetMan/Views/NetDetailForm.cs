using Oreo.NetMan.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.UnitConvertUtils;
using Y.Utils.WindowsUtils.ProcessUtils;

namespace Oreo.NetMan.Views
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
                        //R.Log.v("IsNetFlowRun: " + R.NFS.IsNetFlowRun + " IsNetPacketRun: " + R.NFS.IsNetPacketRun +
                        //    " Upload: " + R.NFS.NetFlow.UploadData + " Download: " + R.NFS.NetFlow.DownloadData);
                        UIDgProcessDetailUpdate();
                        //UIDgConnectDetailUpdate();
                    }
                    Thread.Sleep(1000);
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
                    label2.Text = "下载：" + ByteConvertTool.Fmt(R.NFS.NetFlow.DownloadData) +
                                  " 上传：" + ByteConvertTool.Fmt(R.NFS.NetFlow.UploadData);
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
                               p.DownloadBagCount});
                        }
                    });
                }
            }));
        }
        private void UIDgConnectDetailUpdate()
        {
            if (IsDisposed) return;

            BeginInvoke(new Action(() =>
            {
                if (R.NFS != null && ListTool.HasElements(R.NFS.NetConnectionInfoList))
                {
                    R.NFS.NetConnectionInfoList.ForEach(conn =>
                    {
                        try
                        {
                            Process p = Process.GetProcessById(conn.ProcessId);
                            bool isUpdate = false;
                            foreach (DataGridViewRow r in DgvConnList.Rows)
                            {
                                if (r.Cells["DgvConnListProcess"].Value.ToString() == p.ProcessName &&
                                    r.Cells["DgvConnListLocalIP"].Value.ToString() == conn.LocalIP &&
                                    r.Cells["DgvConnListLocalPort"].Value.ToString() == conn.LocalPort.ToString())
                                {
                                    isUpdate = true;
                                    r.Cells["DgvConnListIcon"].Value = ProcessInfoTool.GetIcon(p, false);
                                    r.Cells["DgvConnListProcess"].Value = p.ProcessName;
                                    r.Cells["DgvConnListProtocol"].Value = conn.ProtocolName;
                                    r.Cells["DgvConnListLocalIP"].Value = conn.LocalIP;
                                    r.Cells["DgvConnListLocalPort"].Value = conn.LocalPort;
                                    r.Cells["DgvConnListRemoteIP"].Value = conn.RemoteIP;
                                    r.Cells["DgvConnListRemotePort"].Value = conn.RemotePort;
                                    r.Cells["DgvConnListStatus"].Value = conn.Status;
                                }
                            }
                            if (!isUpdate)
                            {
                                DgvConnList.Rows.Add(new object[] {
                                 ProcessInfoTool.GetIcon(p, false), p.ProcessName, conn.ProtocolName,
                                 conn.LocalIP, conn.LocalPort, conn.RemoteIP, conn.RemotePort, conn.Status
                            });
                            }
                        }
                        catch (Exception e) { }
                    });
                }
            }));
        }


    }
}
