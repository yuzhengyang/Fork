using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.BaiDuWebAPI.GPSAPI
{
    public class BaiduGPSPointModel
    {
        public int status { get; set; }
        public IList<Result> result { get; set; }
    }
    public class Result
    {
        public double x { get; set; }
        public double y { get; set; }
    }
}
