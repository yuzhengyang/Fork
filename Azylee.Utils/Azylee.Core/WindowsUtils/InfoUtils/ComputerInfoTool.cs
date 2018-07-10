//************************************************************************
//      author:     yuzhengyang
//      date:       2017.3.29 - 2017.7.13
//      desc:       计算机信息
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;

namespace Azylee.Core.WindowsUtils.InfoUtils
{
    /// <summary>
    /// 计算机信息
    /// </summary>
    public static class ComputerInfoTool
    {
        const string UNKNOW = "unknow";

        /// <summary>
        /// CPU 信息
        /// 【序列号、型号】
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string> CpuInfo()
        {
            try
            {
                Tuple<string, string> result = null;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from  Win32_Processor");
                foreach (ManagementObject item in searcher.Get())
                {
                    result = new Tuple<string, string>(
                        item["ProcessorId"].ToString().Trim(),
                        item["Name"].ToString().Trim());
                    break;
                }
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        /// 网卡信息
        /// 【名称、描述、物理地址（Mac）、Ip地址、网关地址】
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<string, string, string, string, string>> NetworkCardInfo()
        {
            return NetCardInfoTool.GetNetworkCardInfo();
        }
        /// <summary>
        /// 显卡型号
        /// 【型号、RAM】
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<string, ulong>> GraphicsCardInfo()
        {
            try
            {
                List<Tuple<string, ulong>> rs = new List<Tuple<string, ulong>>();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from  Win32_VideoController");
                foreach (ManagementObject item in searcher.Get())
                {
                    string name = item["Name"].ToString().Trim();
                    string ram = item["AdapterRAM"].ToString().Trim();
                    ulong ramnumber;
                    ulong.TryParse(ram, out ramnumber);
                    rs.Add(new Tuple<string, ulong>(name, ramnumber));
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
                    rs.Add(item["Name"].ToString().Trim());
                }
                return rs;
            }
            catch
            { return null; }
        }
        /// <summary>
        /// 内存型号
        /// </summary>
        /// <returns></returns>
        public static List<string> RAMModel()
        {
            List<string> rs = new List<string>();
            try
            {
                ManagementClass mc = new ManagementClass("Win32_PhysicalMemory");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    //string temp = "";
                    //foreach (PropertyData m in mo.Properties)
                    //{
                    //    try
                    //    {
                    //        temp += m.Name.ToString() + " : " + m.Value.ToString() + "&&&&";
                    //    }
                    //    catch { }
                    //}
                    //rs.Add(temp);
                    try { rs.Add(mo["Manufacturer"].ToString().Trim() + " " + mo["PartNumber"].ToString().Trim()); } catch { }
                }
            }
            catch (Exception ex) { }
            return rs;
        }
        /// <summary>
        /// 物理内存（单位：KB）
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
                    break;
                }
            }
            catch { }
            if (size > 1024) size = size / 1024;
            return size;
        }
        /// <summary>
        /// 可用物理内存（单位：KB）
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
                    break;
                }
            }
            catch { }
            return size;
        }
        /// <summary>
        /// 硬盘信息
        /// 【序列号、型号】
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<string, string>> HardDiskInfo()
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            try
            {
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    result.Add(new Tuple<string, string>(
                        mo.Properties["SerialNumber"].Value.ToString().Trim(),
                        mo.Properties["Model"].Value.ToString().Trim()));
                }
                return result;
            }
            catch (Exception e)
            {
                return result;
            }
        }
        /// <summary>
        /// 计算机名
        /// </summary>
        /// <returns></returns>
        public static string MachineName()
        {
            try
            {
                return Environment.MachineName;
            }
            catch
            { return UNKNOW; }
        }
        /// <summary>
        /// 主板信息
        /// 【制造商、型号、序列号】
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string, string> BoardInfo()
        {
            try
            {
                Tuple<string, string, string> result = null;
                ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                foreach (ManagementObject MyObject in MySearcher.Get())
                {
                    result = new Tuple<string, string, string>(
                        MyObject["Manufacturer"].ToString().Trim(),
                        MyObject["Product"].ToString().Trim(),
                        MyObject["SerialNumber"].ToString().Trim());
                    break;
                }
                return result;
            }
            catch (Exception e)
            { return null; }
        }
        /// <summary>
        /// 操作系统信息
        /// 【系统名称、系统路劲、安装时间】
        /// </summary>
        /// <returns></returns>
        public static Tuple<string, string, DateTime> OsInfo()
        {
            try
            {
                Tuple<string, string, DateTime> result = null;
                ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                foreach (ManagementObject MyObject in MySearcher.Get())
                {
                    string caption = MyObject["Caption"].ToString().Trim();
                    string windowsdirectory = MyObject["WindowsDirectory"].ToString().Trim();
                    string installdate = MyObject["InstallDate"].ToString().Trim();
                    DateTime dtinstalldate = DateTime.Parse("2001-10-25");//设置初始值为WindowsXP发布日期

                    if (installdate.Length >= 14)
                    {
                        installdate = installdate.Substring(0, 14);
                        installdate = installdate.Insert(12, ":");
                        installdate = installdate.Insert(10, ":");
                        installdate = installdate.Insert(8, " ");
                        installdate = installdate.Insert(6, "-");
                        installdate = installdate.Insert(4, "-");
                        DateTime.TryParse(installdate, out dtinstalldate);
                    }
                    if (dtinstalldate.Year < 2001) dtinstalldate = DateTime.Parse("2001-10-25");

                    result = new Tuple<string, string, DateTime>(
                        caption, windowsdirectory, dtinstalldate);
                    break;
                }
                return result;
            }
            catch (Exception e)
            { return null; }
        }
        /// <summary>
        /// 系统类型
        /// </summary>
        /// <returns></returns>
        public static string SystemType()
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
        /// <summary>
        /// 当前用户名
        /// </summary>
        /// <returns></returns>
        public static string UserName()
        {
            return Environment.UserName;
        }
        /// <summary>
        /// 当前用户名
        /// </summary>
        /// <returns></returns>
        public static string UserName2()
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
        #region 获取所有用户名
        /// <summary>
        /// 所有用户名称
        /// </summary>
        /// <returns></returns>
        public static List<string> UserNames()
        {
            List<string> temp = new List<string>();
            try
            {
                IntPtr bufPtr;
                NetUserEnum(null, 0, 2, out bufPtr, -1, out int EntriesRead, out int TotalEntries, out int Resume);
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
            }
            catch { }
            return temp;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct USER_INFO_0
        {
            public string Username;
        }
        [DllImport("Netapi32.dll ")]
        extern static int NetUserEnum([MarshalAs(UnmanagedType.LPWStr)] string servername, int level, int filter, out IntPtr bufptr, int prefmaxlen, out int entriesread, out int totalentries, out int resume_handle);

        [DllImport("Netapi32.dll ")]
        extern static int NetApiBufferFree(IntPtr Buffer);
        #endregion

        /// <summary>
        /// 域名
        /// </summary>
        /// <returns></returns>
        public static string UserDomainName()
        {
            try
            {
                return Environment.UserDomainName;
            }
            catch
            { return UNKNOW; }
        }
        /// <summary>
        /// 系统启动后的毫秒数
        /// </summary>
        /// <returns></returns>
        public static int TickCount()
        {
            return Environment.TickCount;
        }
        /// <summary>
        /// 处理器数
        /// </summary>
        /// <returns></returns>
        public static int ProcessorCount()
        {
            return Environment.ProcessorCount;
        }
        /// <summary>
        /// 平台标识和版本号
        /// </summary>
        /// <returns></returns>
        public static string OSVersion()
        {
            try
            {
                return Environment.OSVersion.ToString();
            }
            catch
            { return UNKNOW; }
        }
        /// <summary>
        /// 64位操作系统
        /// </summary>
        /// <returns></returns>
        public static bool Is64BitOperatingSystem()
        {
            return Environment.Is64BitOperatingSystem;
        }
        /// <summary>
        /// 获取系统盘总容量（单位：KB）
        /// </summary>
        /// <returns></returns>
        public static long GetSystemDriveTotalSize()
        {
            try
            {
                DriveInfo Drive = new DriveInfo("C");//系统盘驱动器
                var osinfo = OsInfo();
                if (osinfo != null)
                {
                    string drive = osinfo.Item2.Substring(0, 1);
                    Drive = new DriveInfo(drive);
                }
                return Drive.TotalSize / 1024;
            }
            catch { }
            return 0;
        }
        /// <summary>
        /// 获取系统盘可用容量（单位：KB）
        /// </summary>
        /// <returns></returns>
        public static long GetSystemDriveAvailableSize()
        {
            long size = 0;
            try
            {
                var osinfo = OsInfo();
                if (osinfo != null)
                {
                    string drive = osinfo.Item2.Substring(0, 1);
                    DriveInfo Drive = new DriveInfo(drive);
                    size = Drive.TotalFreeSpace / 1024;
                }
            }
            catch { }
            return size;
        }
        /// <summary>
        /// 获取磁盘上次格式化时间
        /// </summary>
        /// <param name="dstr"></param>
        /// <returns></returns>
        public static DateTime GetLastFormatTime(string dstr)
        {
            DateTime result = DateTime.Now;
            string volInfo = dstr + "System Volume Information";
            if (Directory.Exists(volInfo))
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(volInfo);
                    result = di.CreationTime;
                }
                catch (Exception e) { }
            }
            return result;
        }
        /// <summary>
        /// 获取计算机共享文件
        /// </summary>
        /// <returns></returns>
        public static List<string> Share()
        {
            List<string> rs = new List<string>();
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from win32_share");
                foreach (ManagementObject share in searcher.Get())
                {
                    try
                    {
                        string name = share["Name"].ToString();
                        string path = share["Path"].ToString();
                        rs.Add(name + "->" + path);
                    }
                    catch { }
                }
            }
            catch { }
            return rs;
        }
    }
}
