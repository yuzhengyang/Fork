using Oreo.PCMonitor.Commons;
using Oreo.PCMonitor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class NetDetailsWindow : Window, INotifyPropertyChanged
    {
        private string _Status = string.Empty;
        public string Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged("Status");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public NetDetailsWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
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
                    Status = string.Format("下载：{0}，上传：{1}（丢包：{2}）",
                        ByteConvertTool.Fmt(R.NFS.NetFlow.DownloadData),
                        ByteConvertTool.Fmt(R.NFS.NetFlow.UploadData),
                         R.NFS.LostPacketCount);

                    //label1.Text = "丢包数：" + R.NFS.LostPacketCount;
                    //LbStatus.Content = "下载：" + ByteConvertTool.Fmt(R.NFS.NetFlow.DownloadData) +
                    //                   " 上传：" + ByteConvertTool.Fmt(R.NFS.NetFlow.UploadData);
                    //R.NFS.NetProcessInfoList.ForEach(p =>
                    //{
                    //    bool isUpdate = false;
                    //    foreach (DataGridViewRow r in DgProcessDetail.Rows)
                    //    {
                    //        if (r.Cells["CoName"].Value.ToString() == p.ProcessName)
                    //        {
                    //            isUpdate = true;
                    //            r.Cells["CoDownload"].Value = ByteConvertTool.Fmt(p.DownloadData);
                    //            r.Cells["CoUpload"].Value = ByteConvertTool.Fmt(p.UploadData);
                    //            r.Cells["CoDownloadCount"].Value = ByteConvertTool.Fmt(p.DownloadDataCount);
                    //            r.Cells["CoUploadCount"].Value = ByteConvertTool.Fmt(p.UploadDataCount);
                    //            r.Cells["CoConnectionCount"].Value = p.ConnectCount;
                    //        }
                    //    }
                    //    if (!isUpdate)
                    //    {
                    //        DgProcessDetail.Rows.Add(new object[] {
                    //            p.ProcessIcon,p.ProcessName,
                    //            ByteConvertTool.Fmt(p.DownloadData),ByteConvertTool.Fmt(p.UploadData),
                    //            ByteConvertTool.Fmt(p.DownloadDataCount),ByteConvertTool.Fmt(p.UploadDataCount),
                    //           p.DownloadBagCount});
                    //    }
                    //});
                }
            }));
        }
        public List<NetProcessInfo> GetNetProcessInfoList()
        {
            return R.NFS.NetProcessInfoList;
        }
        public ObservableCollection<Tuple<int, string, string>> GetAllData()
        {
            return null;
        }
        public ObservableCollection<Tuple<int, string, string>> GetAllData2
        {
            get; set;
        }
    }
}
