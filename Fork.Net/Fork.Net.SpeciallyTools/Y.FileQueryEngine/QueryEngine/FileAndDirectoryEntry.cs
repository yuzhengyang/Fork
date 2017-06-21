using System;
using Y.FileQueryEngine.UsnOperation;

namespace Y.FileQueryEngine.QueryEngine
{
    public class FileAndDirectoryEntry
    {
        protected UInt64 fileReferenceNumber;

        protected UInt64 parentFileReferenceNumber;

        protected string fileName;

        protected bool isFolder;

        protected string path;

        public UInt64 FileReferenceNumber
        {
            get
            {
                return this.fileReferenceNumber;
            }
        }

        public UInt64 ParentFileReferenceNumber
        {
            get
            {
                return this.parentFileReferenceNumber;
            }
        }

        public string FileName
        {
            get
            {
                return this.fileName;
            }
        }

        public string Path
        {
            get
            {
                return this.path;
            }
        }

        public string FullFileName
        {
            get
            {
                return string.Concat(this.path, "\\", this.fileName);
            }
        }

        public bool IsFolder
        {
            get
            {
                return this.isFolder;
            }
        }

        public FileAndDirectoryEntry(UsnEntry usnEntry, string path)
        {
            this.fileReferenceNumber = usnEntry.FileReferenceNumber;
            this.parentFileReferenceNumber = usnEntry.ParentFileReferenceNumber;
            this.fileName = usnEntry.FileName;
            this.isFolder = usnEntry.IsFolder;
            this.path = path;
        }
    }
}
