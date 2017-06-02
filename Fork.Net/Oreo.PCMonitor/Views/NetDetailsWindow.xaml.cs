using Oreo.PCMonitor.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.UnitConvertUtils;

namespace Oreo.PCMonitor.Views
{
    /// <summary>
    /// NetDetailsWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NetDetailsWindow : Window
    {
        public NetDetailsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
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
                    }
                    Thread.Sleep(1000);
                }
            });
        }
        private void UIDgProcessDetailUpdate()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (R.NFS != null && ListTool.HasElements(R.NFS.NetProcessInfoList))
                {
                    //label1.Text = "丢包数：" + R.NFS.LostPacketCount;
                    LbStatus.Content = "下载：" + ByteConvertTool.Fmt(R.NFS.NetFlow.DownloadData) +
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
    }
}
