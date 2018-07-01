using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.YeahWeb.HttpUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.BaiDuWebAPI.GPSAPI
{
    public class GPSConverter
    {
        /// <summary>
        /// 设备GPS定位转换为BaiduGPS信息
        /// </summary>
        /// <param name="ak"></param>
        /// <param name="longitude">经度（东经西经，纵向）</param>
        /// <param name="latitude">纬度（北纬南纬，横向）</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool DeviceGPSToBaiduGPS(string ak, double longitude, double latitude, out double x, out double y)
        {
            x = 0;
            y = 0;
            try
            {
                string url = $"http://api.map.baidu.com/geoconv/v1/?coords={longitude},{latitude}&from=1&to=5&ak={ak}";
                string rs = HttpTool.Get(url);
                GPSPointWebModel rsobj = JsonConvert.DeserializeObject<GPSPointWebModel>(rs);
                if (rsobj != null && ListTool.HasElements(rsobj.result))
                {
                    x = rsobj.result[0].x;
                    y = rsobj.result[0].y;
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}
