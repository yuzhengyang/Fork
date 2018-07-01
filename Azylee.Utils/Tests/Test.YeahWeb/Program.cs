using Azylee.YeahWeb.BaiDuWebAPI.GPSAPI;
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
            if (GPSConverter.DeviceGPSToBaiduGPS("iAe652kYOgleRHUYQkW1E8MIHEptnMb5", 120.379235583333, 36.19172925, out double x, out double y))
            {
                Console.WriteLine($"120.379235583333 - 36.19172925");
                Console.WriteLine($"{x} - {y}");
            }

          
            GPSInfoWebModel model = GPSInfoTool.GetInfo("iAe652kYOgleRHUYQkW1E8MIHEptnMb5", 40.039669, 252.129464);
            if (model != null)
            {
                GPSInfoModel info = model.ToGPSInfoModel();
                Console.WriteLine(info);
            }
            Console.ReadLine();
        }
    }
}
