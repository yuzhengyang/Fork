using Azylee.Core.DataUtils.DateTimeUtils;
using Azylee.Core.IOUtils.ImageUtils;
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
            PictureScener.GetInfo(1107006764,(int)TimeStampTool.Get(), "fa577ce340859f9fe",);

            //if (GPSConverter.DeviceGPSToBaiduGPS("iAe652kYOgleRHUYQkW1E8MIHEptnMb5", 120.379235583333, 36.19172925, out double x, out double y))
            //{
            //    Console.WriteLine($"120.379235583333 - 36.19172925");
            //    Console.WriteLine($"{x} - {y}");
            //}

          
            //GPSInfoWebModel model = GPSInfoTool.GetInfo("iAe652kYOgleRHUYQkW1E8MIHEptnMb5", 40.039669, 252.129464);
            //if (model != null)
            //{
            //    GPSInfoModel info = model.ToGPSInfoModel();
            //    Console.WriteLine(info);
            //}
            Console.ReadLine();
        }
    }
}
