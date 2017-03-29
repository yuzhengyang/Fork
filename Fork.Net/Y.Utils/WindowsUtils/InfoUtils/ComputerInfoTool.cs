using System;
using System.Collections.Generic;
using System.Management;
using System.Net.NetworkInformation;

namespace Y.Utils.WindowsUtils.InfoUtils
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
        /// Item1：描述，Item2：物理地址（Mac），Item3：Ip地址，Item4：网关地址
        /// </summary>
        /// <returns></returns>
        public static List<Tuple<string, string, string, string>> GetNetworkCardInfo()
        {
            try
            {
                List<Tuple<string, string, string, string>> result = new List<Tuple<string, string, string, string>>();
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (var item in adapters)
                {
                    if (item.NetworkInterfaceType == NetworkInterfaceType.Ethernet || item.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                    {
                        string _desc = item.Description;
                        string _mac = item.GetPhysicalAddress().ToString();
                        string _ip = item.GetIPProperties().UnicastAddresses.Count >= 2 ?
                            item.GetIPProperties().UnicastAddresses[1].Address.ToString() : null;
                        string _gateway = item.GetIPProperties().GatewayAddresses.Count >= 1 ?
                            item.GetIPProperties().GatewayAddresses[0].Address.ToString() : null;
                        result.Add(new Tuple<string, string, string, string>(_desc, _mac, _ip, _gateway));
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
