using System;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;

namespace Y.Utils.ComputerUtils
{
    public static class ComputerInfoTool
    {
        #region 获取CpuId
        public static string GetCpuId()
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
            catch
            {
                return "unknow";
            }
            finally
            {
                if (moc != null) moc.Dispose();
                if (mc != null) mc.Dispose();
            }
        }
        #endregion
        #region 获取CPU信息
        public static string GetCpuInfo()
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
            { return "unknown"; }
        }
        #endregion

        #region 获取网卡信息
        /// <summary>
        /// 获取网卡信息
        /// Item1：描述，Item2：物理地址（Mac），Item3：Ip地址
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<string, string, string>> GetNetworkCardInfo()
        {
            try
            {
                List<Tuple<string, string, string>> result = new List<Tuple<string, string, string>>();
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (var item in adapters)
                {
                    if (item.NetworkInterfaceType == NetworkInterfaceType.Ethernet || item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    {
                        result.Add(new Tuple<string, string, string>(
                            item.Description,
                            item.GetPhysicalAddress().ToString(),
                            item.GetIPProperties().UnicastAddresses[1].Address.ToString()));
                    }
                }
                return result;
            }
            catch (NetworkInformationException e)
            {
                return null;
            }
        }
        #endregion
    }
}
