using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.BigBirdDeployer.Models
{
    public class ProjectModel
    {
        /// <summary>
        /// 工程名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 文件夹名称
        /// </summary>
        public string Folder { get; set; }
        /// <summary>
        /// 运行Jar包名称
        /// </summary>
        public string JarFile { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 最新版本号
        /// </summary>
        public int LastVersion { get; set; }
        /// <summary>
        /// 当前运行版本号
        /// </summary>
        public int CurrentVersion { get; set; }
        /// <summary>
        /// 版本缓存个数（超出删除）
        /// </summary>
        public int VersionCache { get; set; }
        /// <summary>
        /// 所有版本列表
        /// </summary>
        public List<VersionModel> Versions { get; set; }
    }
}
