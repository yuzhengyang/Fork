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
    }
}
