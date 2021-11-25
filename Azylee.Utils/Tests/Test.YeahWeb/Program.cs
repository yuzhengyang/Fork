using Azylee.Core.LogUtils.SimpleLogUtils;
using Azylee.Jsons;
using Azylee.YeahWeb.BaiDuWebAPI.dwz;
using Azylee.YeahWeb.BaiDuWebAPI.IPLocationAPI;
using System;

namespace Test.YeahWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            //Log log = new Log(true,LogLevel.All,LogLevel.All);





            var s = IPLocationTool.GetLocation();
            if (s != null)
            {

            }





            //var rs = DwzTool.Create("", "http://www.baidu.com");
            //Console.WriteLine(Json.Object2String(rs));


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
