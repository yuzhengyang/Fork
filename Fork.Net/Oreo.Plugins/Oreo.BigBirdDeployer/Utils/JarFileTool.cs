using Azylee.Core.IOUtils.DirUtils;
using Oreo.BigBirdDeployer.Commons;
using Oreo.BigBirdDeployer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oreo.BigBirdDeployer.Utils
{
    public static class JarFileTool
    {
        /// <summary>
        /// 执行Jar文件路径生成
        /// </summary>
        /// <returns></returns>
        public static string PathGenerate(ProjectModel project)
        {
            string file = DirTool.Combine(R.Paths.PublishStorage, project.Folder, project.CurrentVersion.ToString(), project.JarFile);
            return file;
        }
        /// <summary>
        /// 获取新添加的Jar文件
        /// </summary>
        /// <returns></returns>
        public static string GetNewPath(ProjectModel project)
        {
            string path = DirTool.Combine(R.Paths.NewStorage, project.Folder);
            return path;
        }

    }
}
