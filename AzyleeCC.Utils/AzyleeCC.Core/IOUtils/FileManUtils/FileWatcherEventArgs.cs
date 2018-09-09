using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AzyleeCC.Core.IOUtils.FileManUtils
{
    public class FileWatcherEventArgs
    {
        public FileWatcherEventArgs(WatcherChangeTypes type, string fullpath, string name, string oldfullpath, string oldname)
        {
            _ChangeType = type;
            _FullPath = fullpath;
            _Name = name;
            _OldFullPath = oldfullpath;
            _OldName = oldname;
        }

        private WatcherChangeTypes _ChangeType;
        public WatcherChangeTypes ChangeType { get { return _ChangeType; } }

        private string _FullPath;
        public string FullPath { get { return _FullPath; } }

        private string _Name;
        public string Name { get { return _Name; } }

        private string _OldFullPath;
        public string OldFullPath { get { return _OldFullPath; } }

        private string _OldName;
        public string OldName { get { return _OldName; } }
    }
}
