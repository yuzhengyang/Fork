using Oreo.VersionUpdate.Commons;
using Oreo.VersionUpdate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.JsonUtils;
using Y.Utils.IOUtils.TxtUtils;
using Y.Utils.WindowsUtils.InfoUtils;

namespace Oreo.VersionUpdate.Helpers
{
    public class DataHelper
    {
        /// <summary>
        /// 获取要更新的插件列表
        /// </summary>
        /// <returns></returns>
        public static List<PluginModel> GetPluginList()
        {
            #region 读取本地插件列表
            List<PluginModel> localPluginList = new List<PluginModel>();
            try
            {
                XElement xe = XElement.Load(R.Files.Plugins);
                IEnumerable<XElement> elements = xe.Elements("Item");
                if (ListTool.HasElements(elements))
                {
                    foreach (var ele in elements)
                    {
                        PluginModel plug = new PluginModel()
                        {
                            Name = ele.Attribute("Name").Value,
                            Entry = ele.Attribute("Entry").Value,
                            Version = ele.Attribute("Version").Value
                        };
                        localPluginList.Add(plug);
                    }
                }
            }
            catch (Exception e) { }
            #endregion
            #region 读取服务器插件列表
            List<PluginModel> serverPluginList = new List<PluginModel>()
            {
                new PluginModel() { Name="yo",Version=Guid.NewGuid().ToString(),Entry="C:\\aa"},
                new PluginModel() { Name="yooo2",Version=Guid.NewGuid().ToString(),Entry="C:\\ab"}
            };
            #endregion
            #region 整理需要更新的插件列表
            List<PluginModel> rs = new List<PluginModel>();
            if (ListTool.HasElements(serverPluginList))
            {
                serverPluginList.ForEach(p =>
                {
                    var tmp = localPluginList.FirstOrDefault(x => x.Name == p.Name);
                    if (tmp == null)
                    {
                        //如果服务器有的插件，本地没有，则添加至需要更新的列表
                        rs.Add(p);
                    }
                    else
                    {
                        if (tmp.Version != p.Version)
                        {
                            //如果服务器插件版本和本机插件版本不同，则添加至需要更新列表
                            rs.Add(p);
                        }
                    }
                });
            }
            #endregion
            return rs;
        }
        /// <summary>
        /// 联网获取插件的最新版本
        /// </summary>
        /// <param name="pm"></param>
        /// <returns></returns>
        public static VersionModel GetPluginNewVersion(PluginModel pm)
        {
            VersionModel rs = JsonTool.ToObjFromFile<VersionModel>(@"D:\CoCo\GitHub\Fork\Fork.Net\Oreo.VersionBuilder\bin\Debug\VersionFile\0527112916.version");
            return rs;
        }
        /// <summary>
        /// 写入 Whatsnew
        /// </summary>
        /// <param name="vm"></param>
        public static void UpdateWhatsnew(VersionModel vm)
        {
            TxtTool.Append(R.Files.Whatsnew, string.Format("{0} {1} {2}",
            vm.CodeName, vm.VersionNumber, (vm.PluginName == "" ? "" : "For:" + vm.PluginName)));
            TxtTool.Append(R.Files.Whatsnew, vm.VersionDesc);
            TxtTool.Append(R.Files.Whatsnew, new string('=', 50));
        }
        /// <summary>
        /// 写入更新配置文件
        /// </summary>
        /// <param name="vm"></param>
        public static void UpdatePluginConfig(VersionModel vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.PluginName) && !string.IsNullOrWhiteSpace(vm.PluginEntry))
            {
                //插入更新的插件配置
                XElement insertXE = XElement.Load(R.Files.Plugins);
                XElement record = new XElement("Item", new XAttribute("Name", vm.PluginName), new XAttribute("Entry", vm.PluginEntry), new XAttribute("Version", vm.VersionNumber));
                insertXE.Add(record);
                insertXE.Save(R.Files.Plugins);
                //删除老版本插件配置
                XElement deleteXE = XElement.Load(R.Files.Plugins);
                IEnumerable<XElement> elements = from ele in deleteXE.Elements("book")
                                                 where (string)ele.Attribute("ISBN") == id
                                                 select ele;
                {
                    if (elements.Count() > 0)
                        elements.First().Remove();
                }
                deleteXE.Save(R.Files.Plugins);
            }
        }
        /// <summary>
        /// 更新注册表项
        /// </summary>
        /// <param name="vm"></param>
        private static void UpdateRegister(List<VersionRegister> vr)
        {
            if (ListTool.HasElements(vr))
            {
                foreach (var r in vr)
                {
                    if (r.IsClean)
                    {
                        //删除该注册表项
                        RegisterTool.DeleteValue(r.Key, r.Name);
                    }
                    else
                    {
                        //添加或修改该注册表项
                        RegisterTool.SetValue(r.Key, r.Name, r.Value);
                    }
                }
            }
        }
    }
}
