using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Y.Utils.IOUtils.FileManUtils
{
    public class FileWatcherEventArgs
    {
        public WatcherChangeTypes ChangeType { get; }
        public string FullPath { get; }
        public string Name { get; }
        public string OldFullPath { get; }
        public string OldName { get; }
    }
}
