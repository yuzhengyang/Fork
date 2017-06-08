using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.CleverDog.Models
{
    public class Frisbee
    {
        #region 判断执行的依据
        public string[] ExistFile { get; set; }
        public string[] ExistProcess { get; set; }
        public string[] ExistControl { get; set; }
        public DateTime Term { get; set; }
        public string Any3264 { get; set; }
        #endregion

        #region 下载并执行
        public string Url { get; set; }
        public string FileName { get; set; }
        public string SuccUrl { get; set; }
        public bool AutoRun { get; set; }
        #endregion

        #region 任务前关闭程序
        public string[] KillProcess { get; set; }
        #endregion

        #region 任务后运行程序
        public string[] RunProcess { get; set; }
        #endregion
    }
}
