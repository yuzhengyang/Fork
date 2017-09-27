using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y.Test.Models
{
    public class UpdateModel
    {
        public string platformVersion { get; set; }

        public List<UpdateContent> list { get; set; }
    }
    public class UpdateContent
    {
        public string md5 { get; set; }

        public int id { get; set; }

        public int pid { get; set; }

        public string fileName { get; set; }

        public string parent { get; set; }

        public string lastModify { get; set; }
    }
}
