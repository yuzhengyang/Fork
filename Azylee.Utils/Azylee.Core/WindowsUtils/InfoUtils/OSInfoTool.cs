//************************************************************************
//      author:     yuzhengyang
//      date:       2018.3.27 - 2018.6.3
//      desc:       工具描述
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.InfoUtils
{
    public static class OSInfoTool
    {

        public static OSName Caption()
        {
            try
            {
                OperatingSystem os = Environment.OSVersion;
                switch (os.Platform)
                {
                    case PlatformID.Win32Windows:
                        switch (os.Version.Minor)
                        {
                            case 0: return OSName.Windows95;
                            case 10: return OSName.Windows98;
                            case 90: return OSName.WindowsMe;
                        }
                        break;
                    case PlatformID.Win32NT:
                        switch (os.Version.Major)
                        {
                            case 3: return OSName.WindowsNT351;
                            case 4: return OSName.WindowsNT40;
                            case 5:
                                switch (os.Version.Minor)
                                {
                                    case 0: return OSName.Windows2000;
                                    case 1: return OSName.WindowsXP;
                                    case 2: return OSName.Windows2003;
                                }
                                break;
                            case 6:
                                switch (os.Version.Minor)
                                {
                                    case 0: return OSName.Windows2008;
                                    case 1: return OSName.Windows7;
                                    case 2: return OSName.Windows10;
                                }
                                break;
                        }
                        break;
                }
            }
            catch { }
            return OSName.Unknown;
        }
    }
}
