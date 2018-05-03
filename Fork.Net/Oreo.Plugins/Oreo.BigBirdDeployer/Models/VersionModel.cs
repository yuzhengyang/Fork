using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.BigBirdDeployer.Models
{
    public class VersionModel
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// 相对路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
    }
}
