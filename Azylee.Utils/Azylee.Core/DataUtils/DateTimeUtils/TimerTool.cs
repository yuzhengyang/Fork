//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azylee.Core.DataUtils.DateTimeUtils
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
