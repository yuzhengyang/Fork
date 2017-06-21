using System;

namespace Y.FileQueryEngine.QueryEngine
{
    internal class FrnFilePath
    {
        private UInt64 fileReferenceNumber;

        private UInt64? parentFileReferenceNumber;

        private string fileName;

        private string path;

        public UInt64 FileReferenceNumber { get { return this.fileReferenceNumber; } }

        public UInt64? ParentFileReferenceNumber { get { return this.parentFileReferenceNumber; } }

        public string FileName { get { return this.fileName; } }

        public string Path
        { 
            get
            {
                return this.path; 
            }
            set
            {
                this.path = value;
            }
        }

        public FrnFilePath(UInt64 fileReferenceNumber, UInt64? parentFileReferenceNumber, string fileName, string path = null)
        {
            this.fileReferenceNumber = fileReferenceNumber;
            this.parentFileReferenceNumber = parentFileReferenceNumber;
            this.fileName = fileName;
            this.path = path;
        }
    }
}
