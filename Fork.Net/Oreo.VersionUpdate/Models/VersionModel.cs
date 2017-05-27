using System.Collections.Generic;

namespace Oreo.VersionUpdate.Models
{
    public class VersionModel
    {
        /// <summary>
        /// 更新代号
        /// </summary>
        public string CodeName { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public string VersionNumber { get; set; }
        /// <summary>
        /// 版本描述
        /// </summary>
        public string VersionDesc { get; set; }
        /// <summary>
        /// 服务器客户端文件根目录
        /// </summary>
        public string ServerPath { get; set; }
        /// <summary>
        /// 更新前 启动进程
        /// </summary>
        public string[] BeforeUpdateStartProcess { get; set; }
        /// <summary>
        /// 更新前 关闭进程
        /// </summary>
        public string[] BeforeUpdateKillProcess { get; set; }
        /// <summary>
        /// 更新后 启动进程
        /// </summary>
        public string[] AfterUpdateStartProcess { get; set; }
        /// <summary>
        /// 更新后 关闭进程
        /// </summary>
        public string[] AfterUpdateKillProcess { get; set; }
        /// <summary>
        /// 文件列表
        /// </summary>
        public List<VersionFile> FileList { get; set; }
        /// <summary>
        /// 插件名称
        /// </summary>
        public string PluginName { get; set; }
        /// <summary>
        /// 插件运行入口
        /// </summary>
        public string PluginEntry { get; set; }
    }
    public class VersionFile
    {
        /// <summary>
        /// 服务器根目录下文件相对位置
        /// </summary>
        public string ServerFile { get; set; }
        /// <summary>
        /// 更新到本地位置（绝对位置 或 相对于更新程序位置）
        /// </summary>
        public string LocalFile { get; set; }
        /// <summary>
        /// 文件MD5验证码
        /// </summary>
        public string FileMD5 { get; set; }
        /// <summary>
        /// 清理文件（用于清理冗余）
        /// </summary>
        public bool IsClean { get; set; }
    }
}
