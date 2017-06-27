using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.FileMan.Models
{
    public class BackupFiles
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public long Size { get; set; }
        public string UpdateTime { get; set; }
        public string BackupFileName { get; set; }
    }
}
