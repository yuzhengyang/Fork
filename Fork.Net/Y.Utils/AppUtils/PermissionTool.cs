//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System;
using System.Security.Principal;
using Y.Utils.WindowsUtils.APIUtils;

namespace Y.Utils.AppUtils
{
    public class PermissionTool
    {
        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
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
