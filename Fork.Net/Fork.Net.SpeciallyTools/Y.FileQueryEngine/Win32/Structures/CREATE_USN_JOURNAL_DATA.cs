using System;
using System.Runtime.InteropServices;

namespace Y.FileQueryEngine.Win32.Structures
{
    /// <summary>
    /// Create USN Journal Data structure, contains Maximum Size(64bits) and Allocation Delta(64(bits).
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct CREATE_USN_JOURNAL_DATA
    {
        public UInt64 MaximumSize;
        public UInt64 AllocationDelta;
    }
}
