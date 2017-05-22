using Oreo.CleverDog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.TxtUtils;
using Y.Utils.NetUtils.HttpUtils;

namespace Oreo.CleverDog.Commons
{
    /// <summary>
    /// 配置信息
    /// </summary>
    public static class Settings
    {
        static string ServerUrl = "http://10.49.129.127:8001/noah/webservice/getDownloadSoftwareInfo";
        public static void Init()
        {
            ReadFromWeb();
            //ReadFromDemo();
        }
        public static Frisbee[] Frisbee { get; set; }
        public static void ReadFromDemo()
        {
            //string fb = JsonTool.ToStr(new Frisbee[]{
            //        new Frisbee() {
            //            Any3264 ="32",
            //            Term = DateTime.Parse("2017-7-1"),
            //            ExistControl=new string[] {"趋势科技防毒墙网络版客户端"},
            //            ExistFile=new string[] {},
            //            ExistProcess =new string[] { "PccNTMon"},
            //            Url = "http://10.49.129.127/file/soft/trend32.exe",
            //            FileName="trend32.exe",
            //            SuccUrl="",
            //            AutoRun=true,
            //            KillProcess=new string[] { },
            //            RunProcess=new string[] { }
            //        },
            //        new Frisbee() {
            //            Any3264 ="64",
            //            Term = DateTime.Parse("2017-7-1"),
            //            ExistControl=new string[] {"趋势科技防毒墙网络版客户端"},
            //            ExistFile=new string[] {},
            //            ExistProcess =new string[] { "PccNTMon"},
            //            Url = "http://10.49.129.127/file/soft/trend64.exe",
            //            FileName="trend64.exe",
            //            SuccUrl="",
            //            AutoRun=true,
            //            KillProcess=new string[] { },
            //            RunProcess=new string[] { }
            //        },
            //    });
            //TxtTool.Create(@"D:\Temp\Frisbee Data.txt", fb);
            Frisbee = JsonTool.ToObjFromFile<Frisbee[]>(@"D:\Temp\Frisbee Data.txt");
        }
        public static void ReadFromWeb()
        {
            Frisbee = HttpTool.Get<Frisbee[]>(ServerUrl);
        }
    }
}
