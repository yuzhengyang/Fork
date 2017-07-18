using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Y.Utils.SoftwareUtils
{
    public class SoftwareModel
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Publisher { get; set; }
        public string HelpLink { get; set; }
        public string URLInfoAbout { get; set; }
        public int EstimatedSize { get; set; }
        public DateTime InstallDate { get; set; }
    }
}
