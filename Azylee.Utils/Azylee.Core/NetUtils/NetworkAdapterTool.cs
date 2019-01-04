using Azylee.Core.DataUtils.StringUtils;
using Azylee.Core.WindowsUtils.InfoUtils;
using System;
using System.Collections.Generic;
using System.Management;

namespace Azylee.Core.NetUtils
{
    /// <summary>
    /// 网卡设备操作工具
    /// </summary>
    public static class NetcardControlTool
    {
        /// <summary>
        /// 使用WMI获取网卡列表
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public static List<string> GetList()
        {
            List<string> list = new List<string>();
            try
            {
                string manage = "SELECT * From Win32_NetworkAdapter";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject obj in collection)
                {
                    //foreach (var item in obj.Properties)
                    //{
                    //    Console.WriteLine(":::" + item.Name + ":::" + item.Value);
                    //}
                    list.Add(obj["Name"].ToString());
                }
            }
            catch { }
            return list;
        }
        /// <summary>
        /// 获取设备对象（XP无设备ID，请勿使用此方法）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ManagementObject GetNetWorkByGuid(Guid id)
        {
            string netState = "SELECT * From Win32_NetworkAdapter";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject manage in collection)
                {
                    try
                    {
                        //string current_mac = NetCardInfoTool.ShortMac(manage["MacAddress"].ToString());
                        //mac = NetCardInfoTool.ShortMac(mac);
                        //if (current_mac == mac) return manage;
                        Guid guid = Guid.NewGuid();
                        if (manage["GUID"] != null && Guid.TryParse(manage["GUID"].ToString(), out guid))
                        {
                            if (guid == id) return manage;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            catch { }
            return null;
        }
        /// <summary>
        /// 获取设备对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ManagementObject GetNetWorkByConnectId(string id)
        {
            string netState = "SELECT * From Win32_NetworkAdapter";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(netState);
                ManagementObjectCollection collection = searcher.Get();

                foreach (ManagementObject manage in collection)
                {
                    try
                    {
                        if (manage["NetConnectionID"] != null && Str.Ok(id))
                        {
                            if (manage["NetConnectionID"].ToString() == id) return manage;
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            catch { }
            return null;
        }
        /// <summary>
        /// 启用设备（不支持XP系统）
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public static bool Enable(ManagementObject network)
        {
            try
            {
                if (network != null)
                {
                    network.InvokeMethod("Enable", null);
                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
        }
        /// <summary>
        /// 禁用设备（不支持XP系统）
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        public static bool Disable(ManagementObject network)
        {
            try
            {
                if (network != null)
                {
                    network.InvokeMethod("Disable", null);
                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
        }
    }
}
