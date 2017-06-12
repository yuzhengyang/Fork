using System;
using System.Drawing;

namespace Y.Utils.NetUtils.NetManUtils
{
    public class NetProcessInfo
    {
        public string ProcessName { get; set; }
        public Icon ProcessIcon { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public int UploadData { get; set; }
        public int DownloadData { get; set; }
        public long UploadDataCount { get; set; }
        public long DownloadDataCount { get; set; }
        public int UploadBag { get; set; }
        public int DownloadBag { get; set; }
        public long UploadBagCount { get; set; }
        public long DownloadBagCount { get; set; }
        public int ConnectCount { get; set; }
    }
}
