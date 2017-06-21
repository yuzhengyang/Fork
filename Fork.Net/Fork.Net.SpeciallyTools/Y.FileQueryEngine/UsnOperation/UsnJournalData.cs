using System;
using System.IO;
using Y.FileQueryEngine.Win32.Structures;

namespace Y.FileQueryEngine.UsnOperation
{
    internal class UsnJournalData
    {
        public DriveInfo Drive { get; private set; }
        public UInt64 UsnJournalID { get; private set; }
        public Int64 FirstUsn { get; private set; }
        public Int64 NextUsn { get; private set; }
        public Int64 LowestValidUsn { get; private set; }
        public Int64 MaxUsn { get; private set; }
        public UInt64 MaximumSize { get; private set; }
        public UInt64 AllocationDelta { get; private set; }

        public UsnJournalData(DriveInfo drive, USN_JOURNAL_DATA ntfsUsnJournalData)
        {
            this.Drive = drive;
            this.UsnJournalID = ntfsUsnJournalData.UsnJournalID;
            this.FirstUsn = ntfsUsnJournalData.FirstUsn;
            this.NextUsn = ntfsUsnJournalData.NextUsn;
            this.LowestValidUsn = ntfsUsnJournalData.LowestValidUsn;
            this.MaxUsn = ntfsUsnJournalData.MaxUsn;
            this.MaximumSize = ntfsUsnJournalData.MaximumSize;
            this.AllocationDelta = ntfsUsnJournalData.AllocationDelta;
        }

        // pesudo-code for checking valid USN journal
        //private bool IsUsnJournalValid()
        //{

        //    bool isValid = true;
        //    //
        //    // is the JournalID from the previous state == JournalID from current state?
        //    //
        //    if (_previousUsnState.UsnJournalID == _currentUsnState.UsnJournalID)
        //    {
        //        //
        //        // is the next usn to process still available
        //        //
        //        if (_previousUsnState.NextUsn > _currentUsnState.FirstUsn && _previousUsnState.NextUsn < _currentUsnState.NextUsn)
        //        {
        //            isValid = true;
        //        }
        //        else
        //        {
        //            isValid = false;
        //        }
        //    }
        //    else
        //    {
        //        isValid = false;
        //    }

        //    return isValid;
        //}
    }
}
