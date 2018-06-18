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

namespace Azylee.Core.DataUtils.GuidUtils
{
    public class GuidTool
    {
        /// <summary>
        /// //短GUID：e0a953c3ee6040eaa9fae2b667060e09
        /// </summary>
        /// <returns></returns>
        public static string Short() { return Guid.NewGuid().ToString("N"); }
        /// <summary>
        /// //转换短GUID：e0a953c3ee6040eaa9fae2b667060e09
        /// </summary>
        /// <returns></returns>
        public static string Short(Guid guid) { return guid.ToString("N"); }
        /// <summary>
        /// //转换短GUID：e0a953c3ee6040eaa9fae2b667060e09
        /// </summary>
        /// <returns></returns>
        public static string Short(string guid) { return guid.Replace("-", ""); }

        //public static string Format()
        //{
        //    var uuid = Guid.NewGuid().ToString(); // 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12  

        //    var uuidN =

        //    var uuidD = Guid.NewGuid().ToString("D"); // 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12  

        //    var uuidB = Guid.NewGuid().ToString("B"); // {734fd453-a4f8-4c5d-9c98-3fe2d7079760}  

        //    var uuidP = Guid.NewGuid().ToString("P"); //  (ade24d16-db0f-40af-8794-1e08e2040df3)  

        //    var uuidX = Guid.NewGuid().ToString("X"); // {0x3fa412e3,0x8356,0x428f,{0xaa,0x34,0xb7,0x40,0xda,0xaf,0x45,0x6f}}  
        //}
    }
}
