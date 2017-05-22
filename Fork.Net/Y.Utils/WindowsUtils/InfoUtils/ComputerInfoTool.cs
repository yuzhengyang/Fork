//############################################################
//      https://github.com/yuzhengyang
//      author:yuzhengyang
//############################################################
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
        
    }
}
