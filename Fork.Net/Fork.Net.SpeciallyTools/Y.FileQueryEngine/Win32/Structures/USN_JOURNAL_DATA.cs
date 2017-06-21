using System;
using System.Runtime.InteropServices;

namespace Y.FileQueryEngine.Win32.Structures
{
    /// <summary>
    /// USN Journal Data structure, contains USN Journal ID(64bits), First USN(64bits), Next USN(64bits),
    /// Lowest Valid USN(64bits), Max USN(64bits), Maximum Size(64bits) and Allocation Delta(64bits).
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct USN_JOURNAL_DATA
    {
        public UInt64 UsnJournalID;
        public Int64 FirstUsn;
        public Int64 NextUsn;
        public Int64 LowestValidUsn;
        public Int64 MaxUsn;
        public UInt64 MaximumSize;
        public UInt64 AllocationDelta;
    }
}
