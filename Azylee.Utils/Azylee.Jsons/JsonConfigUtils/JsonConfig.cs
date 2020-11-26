using Azylee.Core.IOUtils.FileUtils;
using Azylee.Core.IOUtils.TxtUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Azylee.Jsons.JsonConfigUtils
{
    /// <summary>
    /// Json 配置管理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonConfig<T> where T : new()
    {
        private T Config { get; set; }
        private string FilePath { get; set; }
        private string FilePathBackup { get; set; }

        private JsonConfig() { }
        /// <summary>
        /// 构造配置管理器
        /// </summary>
        /// <param name="filepath">配置文件路径</param>
        public JsonConfig(string filepath)
        {
            this.FilePath = filepath;
            this.FilePathBackup = filepath + ".backup";

            // 读取默认配置文件
            if (File.Exists(this.FilePath))
            {
                this.Config = Json.File2Object<T>(this.FilePath);
            }
            // 读取备份的配置文件
            if (this.Config == null)
            {
                if (File.Exists(this.FilePathBackup))
                {
                    this.Config = Json.File2Object<T>(this.FilePathBackup);
                }
            }

            if (this.Config == null)
            {
                this.Config = new T();
            }
            Save();
        }
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public T Get()
        {
            return this.Config;
        }
        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            string s = Json.Object2String(this.Config);
            s = JsonFormat.Format(s);
            bool result = TxtTool.Create(this.FilePath, s);
            if (TxtTool.Create(this.FilePathBackup, s))
            {
                if (FileTool.Copy(this.FilePathBackup, this.FilePath, true))
                {
                    FileTool.Delete(this.FilePathBackup);
                }
            }
            return result;
        }
    }
}
