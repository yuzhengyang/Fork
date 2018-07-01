using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.BaiDuWebAPI.GPSAPI
{
    public class GPSPointWebModel
    {
        public int status { get; set; }
        public IList<BaiduGPSPointWebResult> result { get; set; }
    }
    public class BaiduGPSPointWebResult
    {
        public double x { get; set; }
        public double y { get; set; }
    }
}
