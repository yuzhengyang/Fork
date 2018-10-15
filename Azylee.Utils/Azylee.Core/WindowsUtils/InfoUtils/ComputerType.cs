using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.Core.WindowsUtils.InfoUtils
{
    /// <summary>
    /// 计算机类型
    /// </summary>
    public enum ComputerType : int
    {
        Other = 1,
        Unknown = 2,
        Desktop = 3,
        Low_Profile_Desktop = 4,
        Pizza_Box = 5,
        Mini_Tower = 6,
        Tower = 7,
        Portable = 8,
        Laptop = 9,
        Notebook = 10,
        Hand_Held = 11,
        Docking_Station = 12,
        All_in_One = 13,
        Sub_Notebook = 14,
        Space_Saving = 15,
        Lunch_Box = 16,
        Main_System_Chassis = 17,
        Expansion_Chassis = 18,
        SubChassis = 19,
        Bus_Expansion_Chassis = 20,
        Peripheral_Chassis = 21,
        Storage_Chassis = 22,
        Rack_Mount_Chassis = 23,
        Sealed_Case_PC = 24,
        INVALID_ENUM_VALUE = 0,
    }
}
