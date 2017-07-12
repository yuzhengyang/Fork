//************************************************************************
//      https://github.com/yuzhengyang
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.7.12
//      desc:       计算机信息
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Y.Utils.WindowsUtils.InfoUtils
{
    /// <summary>
    /// 计算机信息
    /// </summary>
    public static class ComputerInfoTool
    {
        const string UNKNOW = "unknow";
        /// <summary>
        /// CPU 序列号
        /// </summary>
        /// <returns></returns>
        public static string CPUID()
        {
            ManagementClass mc = null;
            ManagementObjectCollection moc = null;
            string ProcessorId = "";
            try
            {
                mc = new ManagementClass("Win32_Processor");
                moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    ProcessorId = mo.Properties["ProcessorId"].Value.ToString();
                }
                return ProcessorId;
            }
            catch (Exception e)
            {
                return UNKNOW;
            }
            finally
            {
                if (moc != null) moc.Dispose();
                if (mc != null) mc.Dispose();
            }
        }
        /// <summary>
        /// CPU 型号
        /// </summary>
        /// <returns></returns>
        public static string CPUModel()
        {
            try
            {
                string result = "";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from  Win32_Processor");
                foreach (ManagementObject item in searcher.Get())
                {
                    result = item["Name"].ToString();
                }
                return result;
            }
            catch
            { return UNKNOW; }
        }
        /// <summary>
        /// 显卡型号
        /// </summary>
        /// <returns></returns>
        public static List<string> GraphicsCardModel()
        {
            try
            {
                List<string> rs = new List<string>();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from  Win32_VideoController");
                foreach (ManagementObject item in searcher.Get())
                {
                    rs.Add(item["Name"].ToString());
                }
                return rs;
            }
            catch { return null; }
        }
        /// <summary>
        /// 声卡型号
        /// </summary>
        /// <returns></returns>
        public static List<string> SoundCardModel()
        {
            try
            {
                List<string> rs = new List<string>();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from  Win32_SoundDevice");
                foreach (ManagementObject item in searcher.Get())
                {
                    rs.Add(item["Name"].ToString());
                }
                return rs;
            }
            catch
            { return null; }
        }
        /// <summary>
        /// 物理内存
        /// </summary>
        /// <returns></returns>
        public static ulong TotalPhysicalMemory()
        {
            ulong size = 0;
            try
            {
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    ulong.TryParse(mo["TotalPhysicalMemory"].ToString(), out size);
                }
            }
            catch { }
            return size;
        }
        /// <summary>
        /// 可用物理内存
        /// </summary>
        /// <returns></returns>
        public static ulong AvailablePhysicalMemory()
        {
            ulong size = 0;
            try
            {
                ManagementClass mc = new ManagementClass("Win32_OperatingSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    ulong.TryParse(mo["FreePhysicalMemory"].ToString(), out size);
                }
            }
            catch { }
            return size;
        }
        /// <summary>
        /// 硬盘型号
        /// </summary>
        /// <returns></returns>
        public static List<string> HardDiskModel()
        {
            try
            {
                List<string> rs = new List<string>();
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    rs.Add(mo.Properties["Model"].Value.ToString() + "--" + mo.Properties["SerialNumber"].Value.ToString());
                    //result = (string);
                    //if (!result.ToLower().Contains("usb"))
                    //    return result;
                }
                return rs;
            }
            catch { return null; }
        }
        #region 获取硬盘ID
        public static string GetHDiskID(string hdModel)
        {
            try
            {
                string result = "";
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if (mo.Properties["Model"].Value.ToString().Contains(hdModel))
                    {
                        result = (string)mo.Properties["SerialNumber"].Value;
                    }
                }
                return result.Trim();
            }
            catch
            { return UNKNOW; }
        }
        #endregion
        #region 获取操作系统
        public static string GetOS()
        {
            try
            {
                string result = "";
                ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject MyObject in MySearcher.Get())
                {
                    result = MyObject["Caption"].ToString();
                }
                return result;
            }
            catch
            { return UNKNOW; }
        }
        #endregion
        #region 获取系统类型
        public static string GetSystemType()
        {
            try
            {
                string result = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    result = mo["SystemType"].ToString();

                }
                return result;
            }
            catch
            { return UNKNOW; }
        }
        #endregion
        #region 获取系统安装日期
        public static string GetSystemInstallDate()
        {
            try
            {
                string result = "";
                ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject MyObject in MySearcher.Get())
                {
                    result = MyObject["InstallDate"].ToString().Substring(0, 14);
                    result = result.Insert(12, ":");
                    result = result.Insert(10, ":");
                    result = result.Insert(8, " ");
                    result = result.Insert(6, "-");
                    result = result.Insert(4, "-");
                }
                return result;
            }
            catch
            { return UNKNOW; }
        }
        #endregion
        #region 获取登陆用户名
        public static string GetLoginUserName()
        {
            try
            {
                string result = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    result = mo["UserName"].ToString();
                }
                return result;
            }
            catch
            { return UNKNOW; }
        }
        #endregion
        #region 获取计算机名
        public static string GetComputerName()
        {
            try
            {
                string result = "";
                result = System.Environment.GetEnvironmentVariable("ComputerName");
                return result;
            }
            catch
            { return UNKNOW; }
        }
        #endregion
        #region 获取所有用户名
        public static List<string> GetSysUserNames()
        {
            int EntriesRead;
            int TotalEntries;
            int Resume;
            IntPtr bufPtr;
            List<string> temp = new List<string>();

            NetUserEnum(null, 0, 2, out bufPtr, -1, out EntriesRead, out TotalEntries, out Resume);
            if (EntriesRead > 0)
            {
                USER_INFO_0[] Users = new USER_INFO_0[EntriesRead];
                IntPtr iter = bufPtr;
                for (int i = 0; i < EntriesRead; i++)
                {
                    Users[i] = (USER_INFO_0)Marshal.PtrToStructure(iter, typeof(USER_INFO_0));
                    iter = (IntPtr)((long)iter + Marshal.SizeOf(typeof(USER_INFO_0)));
                    temp.Add(Users[i].Username);
                }
                NetApiBufferFree(bufPtr);
            }
            return temp;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct USER_INFO_0
        {
            public string Username;
        }
        [DllImport("Netapi32.dll ")]
        extern static int NetUserEnum([MarshalAs(UnmanagedType.LPWStr)]
        string servername,
                int level,
                int filter,
                out IntPtr bufptr,
                int prefmaxlen,
                out int entriesread,
                out int totalentries,
                out int resume_handle);

        [DllImport("Netapi32.dll ")]
        extern static int NetApiBufferFree(IntPtr Buffer);
        #endregion
        #region 获取主板制造商
        public static string GetBoardManufacturer()
        {
            try
            {
                string result = "";
                ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject MyObject in MySearcher.Get())
                {
                    result = MyObject["Manufacturer"].ToString();
                }
                return result;
            }
            catch
            { return UNKNOW; }
        }
        #endregion
        #region 获取主板型号
        public static string GetBoardProduct()
        {
            try
            {
                string result = "";
                ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject MyObject in MySearcher.Get())
                {
                    result = MyObject["Product"].ToString();
                }
                return result;
            }
            catch
            { return UNKNOW; }
        }
        #endregion
        #region 获取主板序列号
        public static string GetBoardSerialNumber()
        {
            try
            {
                string result = "";
                ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject MyObject in MySearcher.Get())
                {
                    result = MyObject["SerialNumber"].ToString();
                }
                return result;
            }
            catch
            { return UNKNOW; }
        }
        #endregion
    }
}
