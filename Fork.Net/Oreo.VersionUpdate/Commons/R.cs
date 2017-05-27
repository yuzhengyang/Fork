using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.IOUtils.LogUtils;

namespace Oreo.VersionUpdate.Commons
{
    public class R
    {
        public static Log Log = new Log();

        public static class Settings
        {
            public static class FTP
            {
                public static string Address = "ftp://192.168.3.56";
                public static string Account = "Administrator";
                public static string Password = "yuzhengyang";
            }
        }
    }
}
