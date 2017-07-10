using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.FileMan.Models
{
    public class BackupFiles
    {
        public int Id { get; set; }
        /// <summary>
        /// 原路径
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// 备份路径
        /// </summary>
        public string BackupFullPath { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// 备份时间
        /// </summary>
        public string BackupTime { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public string LastWriteTime { get; set; }
        /// <summary>
        /// Md5
        /// </summary>
        public string Md5 { get; set; }
    }
}
