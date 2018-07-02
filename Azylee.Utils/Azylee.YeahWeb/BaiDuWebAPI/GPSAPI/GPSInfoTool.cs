using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.YeahWeb.HttpUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.BaiDuWebAPI.GPSAPI
{
    public class GPSInfoTool
    {
        public static GPSInfoWebModel GetInfo(string ak, double longitude, double latitude )
        {
            try
            {
                string url = $"http://api.map.baidu.com/geocoder/v2/?location={latitude},{longitude}&coordtype=wgs84ll&output=json&ak={ak}";
                string rs = HttpTool.Get(url);
                GPSInfoWebModel obj = JsonConvert.DeserializeObject<GPSInfoWebModel>(rs);
                if (obj != null) return obj;
            }
            catch { }
            return null;
        }
    }
}
