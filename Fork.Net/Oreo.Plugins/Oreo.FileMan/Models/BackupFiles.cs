using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.FileMan.Models
{
    public class BackupFiles
    {
        public int Id { get; set; }
        public string FullPath { get; set; }
        public string BackupFullPath { get; set; }
        public long Size { get; set; }
        public string UpdateTime { get; set; }
    }
}
