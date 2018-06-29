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
            http://api.map.baidu.com/geocoder/v2/?location=36.1981373852607,120.390842831702&output=json&ak=iAe652kYOgleRHUYQkW1E8MIHEptnMb5
            Console.ReadLine();
        }
    }
}
