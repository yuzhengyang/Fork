using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.BaiDuWebAPI.GPSAPI
{
    public class GPSInfoModel
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Country: {Country}, " +
                 $"Province: {Province}, " +
                 $"City: {City}, " +
                 $"District: {District}, " +
                 $"Street: {Street}, " +
                 $"Address: {Address}";
        }
    }
}
