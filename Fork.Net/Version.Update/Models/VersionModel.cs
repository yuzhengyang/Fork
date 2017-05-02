using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Version.Update.Models
{
    public class VersionModel
    {
        public int Number { get; set; }
        public string Path { get; set; }
        public bool Clean { get; set; }
        public List<VersionFile> FileList { get; set; }
    }
    public class VersionFile
    {
        public string File { get; set; }
        public string MD5 { get; set; }
    }
}
