using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.X
{
    public class TaskSchedulerTool
    {
        ///// <summary>
        ///// get all tasks
        ///// </summary>
        //public static IRegisteredTaskCollection GetAllTasks()
        //{
        //    TaskSchedulerClass ts = new TaskSchedulerClass();
        //    ts.Connect(null, null, null, null);
        //    ITaskFolder folder = ts.GetFolder("\\");
        //    IRegisteredTaskCollection tasks_exists = folder.GetTasks(1);
        //    return tasks_exists;
        //}
        ///// <summary>
        ///// create task
        ///// </summary>
        ///// <param name="creator"></param>
        ///// <param name="taskName"></param>
        ///// <param name="path"></param>
        ///// <param name="interval"></param>
        ///// <returns>state</returns>
        //public static _TASK_STATE CreateTaskScheduler(string creator, string taskName, string path, string interval)
        //{
        //    try
        //    {
        //        Delete(taskName);

        //        //new scheduler
        //        TaskSchedulerClass scheduler = new TaskSchedulerClass();
        //        //pc-name/ip,username,domain,password
        //        scheduler.Connect(null, null, null, null);
        //        //get scheduler folder
        //        ITaskFolder folder = scheduler.GetFolder("\\");


        //        //set base attr 
        //        ITaskDefinition task = scheduler.NewTask(0);
        //        task.RegistrationInfo.Author = "McodsAdmin";//creator
        //        task.RegistrationInfo.Description = "...";//description

        //        //set trigger  (IDailyTrigger ITimeTrigger)
        //        ITimeTrigger tt = (ITimeTrigger)task.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);
        //        tt.Repetition.Interval = interval;// format PT1H1M==1小时1分钟 设置的值最终都会转成分钟加入到触发器
        //        tt.StartBoundary = "2015-04-09T14:27:25";//start time

        //        //set action
        //        IExecAction action = (IExecAction)task.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
        //        action.Path = path;

        //        task.Settings.ExecutionTimeLimit = "PT0S"; //运行任务时间超时停止任务吗? PTOS 不开启超时
        //        task.Settings.DisallowStartIfOnBatteries = false;//只有在交流电源下才执行
        //        task.Settings.RunOnlyIfIdle = false;//仅当计算机空闲下才执行

        //        IRegisteredTask regTask = folder.RegisterTaskDefinition(taskName, task,
        //                                                            (int)_TASK_CREATION.TASK_CREATE, null, //user
        //                                                            null, // password
        //                                                            _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN,
        //                                                            "");
        //        IRunningTask runTask = regTask.Run(null);
        //        return runTask.State;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //public static _TASK_STATE Create(string name, string file, string author, string desc)
        //{
        //    try
        //    {
        //        //删除重名任务
        //        Delete(name);
        //        //new scheduler
        //        TaskSchedulerClass scheduler = new TaskSchedulerClass();
        //        //pc-name/ip,username,domain,password
        //        scheduler.Connect(null, null, null, null);
        //        //get scheduler folder
        //        ITaskFolder folder = scheduler.GetFolder("\\");
        //        //set base attr 
        //        ITaskDefinition task = scheduler.NewTask(0);
        //        task.RegistrationInfo.Author = author;//创建者
        //        task.RegistrationInfo.Description = desc;//描述
        //                                                 //set trigger  (IDailyTrigger ITimeTrigger)
        //        task.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_LOGON);
        //        //set action
        //        IExecAction action = (IExecAction)task.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);
        //        action.Path = file;
        //        task.Settings.ExecutionTimeLimit = "PT0S"; //运行任务时间超时停止任务吗? PTOS 不开启超时
        //        task.Settings.DisallowStartIfOnBatteries = false;//只有在交流电源下才执行
        //        task.Settings.RunOnlyIfIdle = false;//仅当计算机空闲下才执行

        //        IRegisteredTask regTask =
        //            folder.RegisterTaskDefinition(name, task,
        //            (int)_TASK_CREATION.TASK_CREATE, null, //user
        //            null, // password
        //            _TASK_LOGON_TYPE.TASK_LOGON_INTERACTIVE_TOKEN,
        //            "");
        //        IRunningTask runTask = regTask.Run(null);
        //        return runTask.State;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static void Delete(string name)
        //{
        //    if (Exists(name))
        //    {
        //        TaskSchedulerClass ts = new TaskSchedulerClass();
        //        ts.Connect(null, null, null, null);
        //        ITaskFolder folder = ts.GetFolder("\\");
        //        folder.DeleteTask(name, 0);
        //    }
        //}
        //public static bool Exists(string name)
        //{
        //    var isExists = false;
        //    IRegisteredTaskCollection tasks_exists = GetAllTasks();
        //    for (int i = 1; i <= tasks_exists.Count; i++)
        //    {
        //        IRegisteredTask t = tasks_exists[i];
        //        if (t.Name.Equals(name))
        //        {
        //            isExists = true;
        //            break;
        //        }
        //    }
        //    return isExists;
        //}
    }
}
