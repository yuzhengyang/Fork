//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.WindowsUtils.APIUtils;
using System;
using System.Security.Principal;

namespace Azylee.Core.AppUtils
{
    public class PermissionTool
    {
        /// <summary>
        /// 当前登录用户是否为管理员
        /// 百万次执行时间：26947、28705、28244 ms
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        /// <summary>
        /// 当前登录用户是否为管理员
        /// 百万次执行时间：8063、9097、9755 ms
        /// </summary>
        /// <returns></returns>
        public static bool IsAdmin()
        {
            const int SECURITY_BUILTIN_DOMAIN_RID = 0x20;
            const int DOMAIN_ALIAS_RID_ADMINS = 0x220;

            byte[] NtAuthority = new byte[6];
            NtAuthority[5] = 5; // SECURITY_NT_AUTHORITY
            IntPtr AdministratorsGroup;
            int ret = PermissionAPI.AllocateAndInitializeSid(NtAuthority, 2, SECURITY_BUILTIN_DOMAIN_RID, DOMAIN_ALIAS_RID_ADMINS, 0, 0, 0, 0, 0, 0, out AdministratorsGroup);
            if (ret != 0)
            {
                if (PermissionAPI.CheckTokenMembership(IntPtr.Zero, AdministratorsGroup, ref ret) == 0)
                {
                    ret = 0;
                }
                PermissionAPI.FreeSid(AdministratorsGroup);
            }

            return (ret != 0);
        }
    }
}
