using Oreo.FileMan.DatabaseEngine;
using Oreo.FileMan.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y.FileQueryEngine.QueryEngine;
using Y.Utils.DataUtils.Collections;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.IOUtils.PathUtils;

namespace Oreo.FileMan.Helpers
{
    public class FileHelper
    {
        public static void GetAllFileToDb()
        {
            var drives = FileQueryEngine.GetReadyNtfsDrives().OrderByDescending(x => x.Name);
            if (ListTool.HasElements(drives))
            {
                foreach (var drive in drives)
                {
                    var allFiles = FileQueryEngine.GetAllFiles(drive);
                    if (ListTool.HasElements(allFiles))
                    {
                        using (var db = new Muse())
                        {
                            int addcount = 0;
                            foreach (var file in allFiles)
                            {
                                if (!db.Set<Files>().Any(x => x.FullPath == file))
                                {
                                    var a = db.Set<Files>().Add(
                                        new Files()
                                        {
                                            FullPath = file,
                                            FileName = Path.GetFileName(file),
                                            ExtName = Path.GetExtension(file),
                                            Size = FileTool.Size(file),
                                        });
                                    addcount++;
                                }
                                if (addcount >= 500)
                                {
                                    addcount = 0;
                                    db.SaveChanges();
                                }
                            }
                            int count = db.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
