//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
using System.Security.Principal;

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
    }
}
