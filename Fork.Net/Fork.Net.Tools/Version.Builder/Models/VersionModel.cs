using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Builder.Models
{
    public class VersionModel
    {
        public string Number { get; set; }
        public string ServerPath { get; set; }
        public bool DoClean { get; set; }
        public string[] BeginCloseProcess { get; set; }
        public string[] EndRunProcess { get; set; }
        public List<VersionFile> FileList { get; set; }
    }
    public class VersionFile
    {
        public string File { get; set; }
        public string MD5 { get; set; }
    }
}
