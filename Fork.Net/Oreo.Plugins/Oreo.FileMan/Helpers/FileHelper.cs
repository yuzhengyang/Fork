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
            var drives = FileQueryEngine.GetReadyNtfsDrives();
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
                                if (!db.Set<Files>().Any(x => x.FullPath == file.FullFileName))
                                {
                                    var a = db.Set<Files>().Add(
                                        new Files()
                                        {
                                            FullPath = file.FullFileName,
                                            FileName = file.FileName,
                                            ExtName = Path.GetExtension(file.FullFileName),
                                            Size = FileTool.Size(file.FullFileName),
                                        });
                                    addcount++;
                                }
                                if (addcount >= 1000)
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

            DriveInfo[] allDirves = DriveInfo.GetDrives();
            if (ListTool.HasElements(allDirves))
            {
                foreach (var item in allDirves)
                {
                    if (item.IsReady)
                    {
                        using (var db = new Muse())
                        {
                            List<string> paths = DirTool.GetAllPath(item.Name);
                            if (ListTool.HasElements(paths))
                            {
                                paths.ForEach(path =>
                                {
                                    List<string> files = FileTool.GetFile(path);
                                    if (ListTool.HasElements(files))
                                    {
                                        files.ForEach(file =>
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
                                            }
                                        });
                                        int count = db.SaveChanges();
                                    }
                                });
                            }
                        }
                    }
                }
            }
        }
    }
}
