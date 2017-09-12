//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.9.12 - 2017.9.12
//      desc:       工具类验证
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Y.Utils.YUtils
{
    public class YUtilsAuth
    {
        private static bool IsStart = false;
        private static DateTime StartTime = DateTime.Now;
        /// <summary>
        /// 工具类验证
        /// </summary>
        public static void Start()
        {
            if (!IsStart)
            {
                IsStart = true;
                if (IsStart)
                {
                    StartTime = DateTime.Now;
                    Task.Factory.StartNew(() =>
                    {
                        CheckObsolete();
                    });
                }
            }
            if ((DateTime.Now - StartTime).TotalHours > 1) IsStart = false;
        }
        /// <summary>
        /// 验证有效期
        /// </summary>
        private static void CheckObsolete()
        {
            if (DateTime.Now > new DateTime(2018, 12, 2, 0, 0, 0))
                MessageBox.Show("工具组件超出有效期，请更新工具组件。（https://github.com/yuzhengyang）", "超出有效期");
        }
    }
}
