using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Y.Utils.WindowsUtils.ProcessUtils
{
    public class ProcessInfoTool
    {
        #region 程序集信息
        struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.LPStr)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string szTypeName;
            public SHFILEINFO(bool b)
            {
                this.hIcon = IntPtr.Zero;
                this.iIcon = 0;
                this.dwAttributes = 0u;
                this.szDisplayName = "";
                this.szTypeName = "";
            }
        }
        enum SHGFI
        {
            SmallIcon = 1,
            LargeIcon = 0,
            Icon = 256,
            DisplayName = 512,
            Typename = 1024,
            SysIconIndex = 16384,
            UseFileAttributes = 16
        }
        #endregion
        [DllImport("Shell32.dll")]
        static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbfileInfo, SHGFI uFlags);
        static Icon GetIcon(string file, bool small)
        {
            try
            {
                SHFILEINFO sHFILEINFO = new SHFILEINFO(true);
                int cbfileInfo = Marshal.SizeOf(sHFILEINFO);
                SHGFI uFlags;
                if (small)
                {
                    uFlags = (SHGFI)273;
                }
                else
                {
                    uFlags = (SHGFI)272;
                }
                SHGetFileInfo(file, 256u, out sHFILEINFO, (uint)cbfileInfo, uFlags);
                return Icon.FromHandle(sHFILEINFO.hIcon);
            }
            catch { }
            return null;
        }
        public static Icon GetIcon(Process p, bool small)
        {
            return GetIcon(p.MainModule.FileName, small);
        }
        [Obsolete]
        public static Icon GetIcon(int pid, bool small)
        {
            Process p = Process.GetProcessById(pid);
            return GetIcon(p, small);
        }
        [Obsolete]
        public static string GetNameById(int pid)
        {
            string result = "";
            try
            {
                Process processById = Process.GetProcessById(pid);
                result = processById.ProcessName;
            }
            catch (Exception ex) { }
            return result.Trim();
        }
    }
}
