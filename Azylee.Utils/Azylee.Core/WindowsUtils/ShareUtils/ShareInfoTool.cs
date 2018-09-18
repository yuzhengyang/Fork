using Azylee.Core.DataUtils.CollectionUtils;
using Azylee.Core.DataUtils.StringUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Azylee.Core.WindowsUtils.ShareUtils
{
    public class ShareInfoTool
    {
        /// <summary>
        /// 获取计算机共享文件
        /// </summary>
        /// <returns></returns>
        public static List<string> GetList()
        {
            List<string> rs = new List<string>();
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from win32_share");
                foreach (ManagementObject share in searcher.Get())
                {
                    try
                    {
                        string name = share["Name"].ToString();
                        string path = share["Path"].ToString();
                        rs.Add(name + "->" + path);
                    }
                    catch { }
                }
            }
            catch { }
            return rs;
        }
        /// <summary>
        /// 存在共享（模糊匹配路径开头）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool ExistPath(string path)
        {
            if (Str.Ok(path))
            {
                try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from win32_share");
                    foreach (ManagementObject share in searcher.Get())
                    {
                        try
                        {
                            string _path = share["Path"].ToString().ToUpper();
                            if (_path.StartsWith(path.ToUpper())) return true;
                        }
                        catch { }
                    }
                }
                catch { }
            }
            return false;
        }
        /// <summary>
        /// 存在共享（匹配共享名称）
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool ExistName(string name)
        {
            if (Str.Ok(name))
            {
                try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from win32_share");
                    foreach (ManagementObject share in searcher.Get())
                    {
                        try
                        {
                            string _name = share["Name"].ToString().ToUpper();
                            if (_name == name.ToUpper()) return true;
                        }
                        catch { }
                    }
                }
                catch { }
            }
            return false;
        }

        public static bool ExistPaths(string[] paths)
        {
            if (Ls.ok(paths))
            {
                foreach (var p in paths)
                    if (ExistPath(p.Trim())) return true;
            }
            return false;
        }
        public static bool ExistNames(string[] names)
        {
            if (Ls.ok(names))
            {
                foreach (var n in names)
                    if (ExistName(n.Trim())) return true;
            }
            return false;
        }
    }
}
