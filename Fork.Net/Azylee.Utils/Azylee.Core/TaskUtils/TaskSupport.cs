using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azylee.Core.TaskUtils
{
    public abstract class TaskSupport
    {
        private DateTime StartTime, LastRunTime;

        /// <summary>
        /// 通过运行时间判断是否运行
        /// </summary>
        public bool IsRun
        {
            get
            {
                if (LastRunTime.AddSeconds(Interval + 1000) > DateTime.Now)
                    return true;
                return false;
            }
        }
        /// <summary>
        /// 已启动
        /// </summary>
        public bool IsStart { get { return _IsStart; } }
        /// <summary>
        /// 已启动（Protect）
        /// </summary>
        protected bool _IsStart = false;
        /// <summary>
        /// 取消标志
        /// </summary>
        protected CancellationTokenSource CT = new CancellationTokenSource();
        /// <summary>
        /// 任务循环间隔
        /// </summary>
        protected int Interval = 1000;

        private bool IsDestroy = false;

        /// <summary>
        /// 设置任务间隔（0为不循环任务）
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int SetInterval(int i)
        {
            Interval = i;
            return Interval;
        }

        /// <summary>
        /// 启动服务任务
        /// </summary>
        public virtual void Start()
        {
            StartTime = DateTime.Now;
            if (!IsDestroy)
                Task.Factory.StartNew(() =>
                {
                    if (!IsStart)
                    {
                        _IsStart = true;
                        BeforeTODO();
                        do
                        {
                            LastRunTime = DateTime.Now;
                            TODO();
                            Thread.Sleep(Interval);

                        } while (!CT.IsCancellationRequested && Interval > 0);
                        AfterTODO();
                    }
                });
        }
        /// <summary>
        /// 提前干点啥
        /// </summary>
        public virtual void BeforeTODO() { }
        /// <summary>
        /// 干点啥
        /// </summary>
        public abstract void TODO();
        /// <summary>
        /// 完事儿干点啥
        /// </summary>
        public virtual void AfterTODO() { }
        /// <summary>
        /// 停止服务任务
        /// </summary>
        public virtual void Stop()
        {
            CT.Cancel();
            IsDestroy = true;
        }

    }
}
