using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreo.FileMan.Models
{
    public class Files
    {
        public int Id { get; set; }
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public string ExtName { get; set; }
        public long Size { get; set; }
    }
}
