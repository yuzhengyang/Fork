using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.LogUtils.FormActiveLogUtils
{
    public class FormActiveLogModel
    {
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public long Duration { get { return (long)(EndTime - BeginTime).TotalSeconds; } }
        public string FormName { get; set; }
        public string FormText { get; set; }

        public FormActiveLogModel()
        {
            BeginTime = DateTime.Now;
            EndTime = DateTime.Now;
            FormName = "";
            FormText = "";
        }
        public override string ToString()
        {
            string s = $"{BeginTime}|{EndTime}|{Duration}|{FormName}|{FormText}";
            return s;
        }
    }
}
