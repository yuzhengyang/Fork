using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Y.Utils.ComputerUtils
{
    public class ComputerTool
    {
        public static string GetCpuId()
        {
            try
            {
                //获取CPU序列号代码     
                string cpuInfo = "";//cpu序列号     
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return cpuInfo;
            }
            catch
            {
                return "unknow";
            }
            finally
            {
            }
        }
    }
}
