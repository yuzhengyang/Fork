using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.IOUtils.FileUtils;

namespace Oreo.FileMan.Models
{
    public class UsnFiles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFolder { get; set; }
        public string Number { get; set; }
        public string ParentNumber { get; set; }
        public string Drive { get; set; }
        public long Usn { get; set; }
        public string  CreateTime { get; set; }
    }
}
