//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Azylee.Core.WindowsUtils.APIUtils
{
    public class PermissionAPI
    {
        /// <summary>
		/// The AllocateAndInitializeSid function allocates and initializes a security identifier (SID) with up to eight subauthorities.
		/// </summary>
		/// <param name="pIdentifierAuthority">Pointer to a SID_IDENTIFIER_AUTHORITY structure, giving the top-level identifier authority value to set in the SID.</param>
		/// <param name="nSubAuthorityCount">Specifies the number of subauthorities to place in the SID. This parameter also identifies how many of the subauthority parameters have meaningful values. This parameter must contain a value from 1 to 8.</param>
		/// <param name="dwSubAuthority0">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority1">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority2">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority3">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority4">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority5">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority6">Subauthority value to place in the SID.</param>
		/// <param name="dwSubAuthority7">Subauthority value to place in the SID.</param>
		/// <param name="pSid">Pointer to a variable that receives the pointer to the allocated and initialized SID structure.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[DllImport("advapi32.dll")]
        public  extern static int AllocateAndInitializeSid(byte[] pIdentifierAuthority, byte nSubAuthorityCount, int dwSubAuthority0, int dwSubAuthority1, int dwSubAuthority2, int dwSubAuthority3, int dwSubAuthority4, int dwSubAuthority5, int dwSubAuthority6, int dwSubAuthority7, out IntPtr pSid);
        /// <summary>
		/// The CheckTokenMembership function determines whether a specified SID is enabled in an access token.
		/// </summary>
		/// <param name="TokenHandle">Handle to an access token. The handle must have TOKEN_QUERY access to the token. The token must be an impersonation token.</param>
		/// <param name="SidToCheck">Pointer to a SID structure. The CheckTokenMembership function checks for the presence of this SID in the user and group SIDs of the access token.</param>
		/// <param name="IsMember">Pointer to a variable that receives the results of the check. If the SID is present and has the SE_GROUP_ENABLED attribute, IsMember returns TRUE; otherwise, it returns FALSE.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[DllImport("advapi32.dll")]
        public extern static int CheckTokenMembership(IntPtr TokenHandle, IntPtr SidToCheck, ref int IsMember);
        /// <summary>
        /// The FreeSid function frees a security identifier (SID) previously allocated by using the AllocateAndInitializeSid function.
        /// </summary>
        /// <param name="pSid">Pointer to the SID structure to free.</param>
        /// <returns>This function does not return a value.</returns>
        [DllImport("advapi32.dll")]
        public extern static IntPtr FreeSid(IntPtr pSid);
    }
}
