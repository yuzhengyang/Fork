using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Azylee.Core.DllUtils
{
    public class DllInvokeTool
    {
        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(String path);
        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr lib, String funcName);
        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr lib);
        private IntPtr hLib;
        public DllInvokeTool(String DLLPath)
        {
            hLib = LoadLibrary(DLLPath);
        }
        ~DllInvokeTool()
        {
            FreeLibrary(hLib);
        }
        //将要执行的函数转换为委托 
        public Delegate Invoke(String APIName, Type t)
        {
            IntPtr api = GetProcAddress(hLib, APIName);
            return (Delegate)Marshal.GetDelegateForFunctionPointer(api, t);
        }
    }
}
