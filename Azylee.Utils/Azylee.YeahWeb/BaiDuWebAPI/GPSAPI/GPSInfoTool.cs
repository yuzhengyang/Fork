using Azylee.Jsons;
using Azylee.YeahWeb.HttpUtils;

namespace Azylee.YeahWeb.BaiDuWebAPI.GPSAPI
{
    public class GPSInfoTool
    {
        public static GPSInfoWebModel GetInfo(string ak, double longitude, double latitude)
        {
            try
            {
                string url = $"http://api.map.baidu.com/geocoder/v2/?location={latitude},{longitude}&coordtype=wgs84ll&output=json&ak={ak}";
                string rs = HttpTool.Get(url);
                GPSInfoWebModel obj = Json.String2Object<GPSInfoWebModel>(rs);
                if (obj != null) return obj;
            }
            catch { }
            return null;
        }
    }
}
