using Oreo.VersionUpdate.Commons;
using Oreo.VersionUpdate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Y.Utils.DataUtils.Collections;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.WindowsUtils.ProcessUtils;

namespace Oreo.VersionUpdate.Helpers
{
    public class ProcessHelper
    {
        public static void BeforeUpdate(VersionModel vm)
        {
            if (ListTool.HasElements(vm.BeforeUpdateKillProcess))
            {
                foreach (var p in vm.BeforeUpdateKillProcess)
                {
                    ProcessTool.KillProcess(p);
                }
            }
            if (ListTool.HasElements(vm.BeforeUpdateStartProcess))
            {
                foreach (var p in vm.BeforeUpdateStartProcess)
                {
                    string file = DirTool.IsDriver(p) ? p : DirTool.Combine(R.Paths.ProjectRoot, p);
                    ProcessTool.StartProcess(file);
                }
            }
        }
        public static void AfterUpdate(List<string> killProcess, List<string> startProcess)
        {
            if (ListTool.HasElements(killProcess))
            {
                foreach (var p in killProcess)
                {
                    ProcessTool.KillProcess(p);
                }
            }
            if (ListTool.HasElements(startProcess))
            {
                foreach (var p in startProcess)
                {
                    string file = DirTool.IsDriver(p) ? p : DirTool.Combine(R.Paths.ProjectRoot, p);
                    ProcessTool.StartProcess(file);
                }
            }
        }
    }
}
