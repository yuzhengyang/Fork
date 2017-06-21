using System;

namespace Y.FileQueryEngine.UsnOperation
{
    [Flags]
    internal enum UsnErrorCode
    {
        SUCCESS                          = 0,
        ERROR_INVALID_FUNCTION           = 0x1,
        ERROR_INVALID_PARAMETER          = 0x57,
        ERROR_JOURNAL_DELETE_IN_PROGRESS = 0x49A,
        ERROR_JOURNAL_NOT_ACTIVE         = 0x49B
    }
}
