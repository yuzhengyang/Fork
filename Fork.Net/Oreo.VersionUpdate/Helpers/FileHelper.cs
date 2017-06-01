using Oreo.VersionUpdate.Commons;
using Oreo.VersionUpdate.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.Utils.IOUtils.PathUtils;
using Y.Utils.IOUtils.TxtUtils;

namespace Oreo.VersionUpdate.Helpers
{
    public class FileHelper
    {
        public static void Clean(VersionModel vm)
        {
            //清理临时文件夹
            if (Directory.Exists(R.Paths.Temp))
            {
                try { Directory.Delete(R.Paths.Temp, true); } catch { }
            }
            //清理指定文件
            var cleanFile = vm.FileList.Where(x => x.IsClean == true);
            foreach (var file in cleanFile)
            {
                string fff = DirTool.IsDriver(file.LocalFile) ? file.LocalFile : R.Paths.ProjectRoot + file.LocalFile;
                if (File.Exists(fff))
                {
                    try { File.Delete(fff); } catch { }
                }
            }
        }
     
    }
}
