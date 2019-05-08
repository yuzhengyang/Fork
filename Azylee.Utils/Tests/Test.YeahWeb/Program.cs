using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Core.IOUtils.ImageUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.BaiDuWebAPI.dwz;
using Azylee.YeahWeb.BaiDuWebAPI.GPSAPI;
using Azylee.YeahWeb.TencentWebAPI.PictureAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.YeahWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            var rs = DwzTool.Create("", "http://www.baidu.com");
            Console.WriteLine(Json.Object2String(rs));
            //PictureScener.GetInfo(1107006764,(int)TimeStampTool.Get(), "",);

            //if (GPSConverter.DeviceGPSToBaiduGPS("", 120.379235583333, 36.19172925, out double x, out double y))
            //{
            //    Console.WriteLine($"120.379235583333 - 36.19172925");
            //    Console.WriteLine($"{x} - {y}");
            //}


            //GPSInfoWebModel model = GPSInfoTool.GetInfo("", 40.039669, 252.129464);
            //if (model != null)
            //{
            //    GPSInfoModel info = model.ToGPSInfoModel();
            //    Console.WriteLine(info);
            //}
            Console.ReadLine();
        }
    }
}
