using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.InfoUtils
{
    public static class DriveTool
    {
        /// <summary>
        /// 获取系统盘总容量（单位：KB）
        /// </summary>
        /// <returns></returns>
        public static long GetSystemDriveTotalSize()
        {
            try
            {
                DriveInfo Drive = new DriveInfo("C");//系统盘驱动器
                var osinfo = ComputerInfoTool.OsInfo();
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
        /// 获取磁盘总容量（单位：KB）
        /// </summary>
        /// <returns></returns>
        public static long GetDriveTotalSize(string driveName)
        {
            try
            {
                string drive = driveName.Substring(0, 1);
                DriveInfo Drive = new DriveInfo(drive);
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
                var osinfo = ComputerInfoTool.OsInfo();
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
        /// 获取磁盘可用容量（单位：KB）
        /// </summary>
        /// <returns></returns>
        public static long GetDriveAvailableSize(string driveName)
        {
            long size = 0;
            try
            {
                string drive = driveName.Substring(0, 1);
                DriveInfo Drive = new DriveInfo(drive);
                size = Drive.TotalFreeSpace / 1024;
            }
            catch { }
            return size;
        }
    }
}
