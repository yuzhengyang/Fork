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
    public  class ProcessHelper
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
        public static void AfterUpdate(VersionModel vm)
        {
            if (ListTool.HasElements(vm.AfterUpdateKillProcess))
            {
                foreach (var p in vm.AfterUpdateKillProcess)
                {
                    ProcessTool.KillProcess(p);
                }
            }
            if (ListTool.HasElements(vm.AfterUpdateStartProcess))
            {
                foreach (var p in vm.AfterUpdateStartProcess)
                {
                    string file = DirTool.IsDriver(p) ? p : DirTool.Combine(R.Paths.ProjectRoot, p);
                    ProcessTool.StartProcess(file);
                }
            }
        }
    }
}
