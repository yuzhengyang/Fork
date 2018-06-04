//************************************************************************
//      author:     yuzhengyang
//      date:       2018.4.27 - 2018.4.27
//      desc:       CMD 网络工具
//      Copyright (c) yuzhengyang. All rights reserved.
//************************************************************************
using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Azylee.Core.WindowsUtils.CMDUtils
{
    public class CMDNetstatTool
    {
        /// <summary>
        /// 根据端口号查询列表,过滤pid0（item1：端口、item2：pid）
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="fuzzy">模糊匹配</param>
        /// <returns></returns>
        public static List<Tuple<int, int>> FindByPort(int port, bool fuzzy = true)
        {
            var list = Find(port.ToString());
            if (ListTool.HasElements(list))
            {
                try
                {
                    if (fuzzy)
                    {
                        return list.Where(x => x.Item1.ToString().Contains(port.ToString()) && x.Item2 != 0).ToList();
                    }
                    else
                    {
                        return list.Where(x => x.Item1 == port && x.Item2 != 0).ToList();
                    }
                }
                catch { }
            }
            return null;
        }
        /// <summary>
        /// 查询列表（item1：端口、item2：pid）
        /// </summary>
        /// <param name="content">查询内容</param>
        /// <returns></returns>
        public static List<Tuple<int, int>> Find(string content)
        {
            List<Tuple<int, int>> result = null;
            var list = CMDProcessTool.Execute($"netstat -ano|findstr \"{content}\"");
            if (ListTool.HasElements(list))
            {
                result = new List<Tuple<int, int>>();
                foreach (var item in list)
                {
                    if (!string.IsNullOrWhiteSpace(item) &&
                       (item.StartsWith("TCP") || item.StartsWith("UDP")))
                    {
                        try
                        {
                            Regex regex = new Regex(@"\s+");
                            string[] block = regex.Split(item);
                            if (ListTool.HasElements(block) && block.Length >= 3)
                            {
                                string[] s = block[1].Split(':');
                                if (ListTool.HasElements(s) && s.Length >= 2)
                                {
                                    int _port = int.Parse(s[s.Length - 1]);
                                    int _pid = int.Parse(block[block.Length - 1]);
                                    if (!result.Any(x => x.Item1 == _port && x.Item2 == _pid))
                                    {
                                        Tuple<int, int> _tuple = new Tuple<int, int>(_port, _pid);
                                        result.Add(_tuple);
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            return result;
        }
    }
}
