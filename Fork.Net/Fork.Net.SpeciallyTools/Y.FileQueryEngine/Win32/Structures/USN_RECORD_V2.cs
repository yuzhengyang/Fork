using System;
using System.Runtime.InteropServices;

namespace Y.FileQueryEngine.Win32.Structures
{
    /// <summary>
    /// Contains the USN Record Length(32bits), USN(64bits), File Reference Number(64bits), 
    /// Parent File Reference Number(64bits), Reason Code(32bits), File Attributes(32bits),
    /// File Name Length(32bits), the File Name Offset(32bits) and the File Name.
    /// </summary>
    public class USN_RECORD_V2
    {
        private const int FR_OFFSET = 8;
        private const int PFR_OFFSET = 16;
        private const int USN_OFFSET = 24;
        private const int REASON_OFFSET = 40;
        private const int FA_OFFSET = 52;
        private const int FNL_OFFSET = 56;
        private const int FN_OFFSET = 58;

        public UInt32 RecordLength { get; private set; }
        public UInt64 FileReferenceNumber { get; private set; }
        public UInt64 ParentFileReferenceNumber { get; private set; }
        public Int64 Usn { get; private set; }
        public UInt32 Reason { get; private set; }
        public UInt32 FileAttributes { get; private set; }
        public Int32 FileNameLength { get; private set; }
        public Int32 FileNameOffset { get; private set; }
        public string FileName { get; private set; }

        /// <summary>
        /// USN Record Constructor
        /// </summary>
        /// <param name="usnRecordPtr">Buffer of bytes representing the USN Record</param>
        public USN_RECORD_V2(IntPtr usnRecordPtr)
        {
            this.RecordLength = (UInt32)Marshal.ReadInt32(usnRecordPtr);
            this.FileReferenceNumber = (UInt64)Marshal.ReadInt64(usnRecordPtr, FR_OFFSET);
            this.ParentFileReferenceNumber = (UInt64)Marshal.ReadInt64(usnRecordPtr, PFR_OFFSET);
            this.Usn = Marshal.ReadInt64(usnRecordPtr, USN_OFFSET);
            this.Reason = (UInt32)Marshal.ReadInt32(usnRecordPtr, REASON_OFFSET);
            this.FileAttributes = (UInt32)Marshal.ReadInt32(usnRecordPtr, FA_OFFSET);
            this.FileNameLength = Marshal.ReadInt16(usnRecordPtr, FNL_OFFSET);
            this.FileNameOffset = Marshal.ReadInt16(usnRecordPtr, FN_OFFSET);
            this.FileName = Marshal.PtrToStringUni(new IntPtr(usnRecordPtr.ToInt64() + this.FileNameOffset), this.FileNameLength / sizeof(char));
        }
    }
}
