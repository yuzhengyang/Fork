using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.DateTimeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.LogUtils.StatusLogUtils
{
    /// <summary>
    /// 运行状态
    /// </summary>
    public class StatusLogModel
    {
        /// <summary>
        /// 日期时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 统计时长（单位：秒）
        /// </summary>
        public int Long { get; set; }
        /// <summary>
        /// 脱机时长（单位：秒）
        /// </summary>
        public long AFK { get; set; }
        /// <summary>
        /// Cpu使用率
        /// </summary>
        public int CpuPer { get; set; }
        /// <summary>
        /// 可用内存
        /// </summary>
        public long RamFree { get; set; }
        /// <summary>
        /// 可用系统盘容量
        /// </summary>
        public long SysDriveFree { get; set; }
        /// <summary>
        /// 应用程序Cpu使用率
        /// </summary>
        public int AppCpuPer { get; set; }
        /// <summary>
        /// 应用程序占用内存
        /// </summary>
        public double AppRamUsed { get; set; }

        public override string ToString()
        {
            string s = $"{DateTimeConvert.StandardString(Time)}|{Long}|{AFK}|{CpuPer}|" +
                $"{RamFree}|{SysDriveFree}|{AppCpuPer}|{AppRamUsed}";
            return s;
        }
        public StatusLogModel FromString(string s)
        {
            StatusLogModel model = new StatusLogModel();
            string[] elements = s.Split('|');
            if (ListTool.HasElements(elements))
            {
                try { if (elements.Length > 0) model.Time = DateTime.Parse(elements[0]); } catch { }
                try { if (elements.Length > 1) model.Long = int.Parse(elements[1]); } catch { }
                try { if (elements.Length > 2) model.AFK = long.Parse(elements[2]); } catch { }
                try { if (elements.Length > 3) model.CpuPer = int.Parse(elements[3]); } catch { }
                try { if (elements.Length > 5) model.RamFree = long.Parse(elements[5]); } catch { }
                try { if (elements.Length > 7) model.SysDriveFree = long.Parse(elements[7]); } catch { }
                try { if (elements.Length > 8) model.AppCpuPer = int.Parse(elements[8]); } catch { }
                try { if (elements.Length > 9) model.AppRamUsed = double.Parse(elements[9]); } catch { }
            }
            return model;
        }
    }
}
