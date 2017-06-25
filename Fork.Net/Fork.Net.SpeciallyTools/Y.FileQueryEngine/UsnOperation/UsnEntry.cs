using System;
using Y.FileQueryEngine.Win32.Constants;
using Y.FileQueryEngine.Win32.Structures;

namespace Y.FileQueryEngine.UsnOperation
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UsnEntry
    {
        public uint RecordLength { get; private set; }
        public ulong FileReferenceNumber { get; private set; }

        /// <summary>
        /// Gets the parent file reference number.
        /// When its values is 1407374883553285(0x5000000000005L), it means this file/folder is under drive root
        /// </summary>
        /// <value>
        /// The parent file reference number.
        /// </value>
        public ulong ParentFileReferenceNumber { get; private set; }
        public long Usn { get; private set; }
        public uint Reason { get; private set; }
        public uint FileAttributes { get; private set; }
        public int FileNameLength { get; private set; }
        public int FileNameOffset { get; private set; }
        public string FileName { get; private set; }
        public bool IsFolder
        {
            get
            {
                return (this.FileAttributes & Win32ApiConstant.FILE_ATTRIBUTE_DIRECTORY) != 0;
            }
        }

        public UsnEntry(USN_RECORD_V2 usnRecord)
        {
            this.RecordLength = usnRecord.RecordLength;
            this.FileReferenceNumber = usnRecord.FileReferenceNumber;
            this.ParentFileReferenceNumber = usnRecord.ParentFileReferenceNumber;
            this.Usn = usnRecord.Usn;
            this.Reason = usnRecord.Reason;
            this.FileAttributes = usnRecord.FileAttributes;
            this.FileNameLength = usnRecord.FileNameLength;
            this.FileNameOffset = usnRecord.FileNameOffset;
            this.FileName = usnRecord.FileName;
        }
    }
}
