using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.DataUtils.DateTimeUtils
{
    public class TimerTool
    {
        private DateTime BeginTime { get; set; }
        private DateTime EndTime { get; set; }
        private TimerTool() { }
        public TimerTool(bool isStart = false)
        {
            if (isStart)
                Begin();
        }
        public void Begin()
        {
            BeginTime = DateTime.Now;
        }
        public void End()
        {
            EndTime = DateTime.Now;
        }
        public double m
        {
            get
            {
                End();
                return (EndTime - BeginTime).TotalMinutes;
            }
        }
        public double s
        {
            get
            {
                End();
                return (EndTime - BeginTime).TotalSeconds;
            }
        }
        public double ms
        {
            get
            {
                End();
                return (EndTime - BeginTime).TotalMilliseconds;
            }
        }
    }
}
