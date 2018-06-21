using System;
using System.Collections.Generic;
using System.Drawing;

namespace Azylee.Core.NetUtils
{
    public class NetProcessInfo
    {
        public int ProcessId { get; set; }
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
        public List<NetConnectionInfo> NetConnectionInfoList { get; set; }
    }
}
