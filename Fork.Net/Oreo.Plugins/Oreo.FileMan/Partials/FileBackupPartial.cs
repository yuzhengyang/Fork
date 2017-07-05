using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Y.Utils.IOUtils.FileUtils;
using Y.Utils.DataUtils.Collections;
using Y.Utils.DataUtils.UnitConvertUtils;
using Y.Utils.IOUtils.PathUtils;
using Oreo.FileMan.Models;
using Oreo.FileMan.DatabaseEngine;
using Y.Utils.IOUtils.FileManUtils;
using System.Windows.Threading;
using System.Threading;
using Y.Utils.DataUtils.DateTimeUtils;
using Oreo.FileMan.Commons;

namespace Oreo.FileMan.Partials
{
    public partial class FileBackupPartial : UserControl
    {
        public FileBackupPartial()
        {
            InitializeComponent();
        }
        private void FileBackupPartial_Load(object sender, EventArgs e)
        {
            if (ListTool.HasElements(R.Services.FBS.Paths))
            {
                foreach (var p in R.Services.FBS.Paths)
                {
                    UIDgvPathAdd(DirTool.GetPathName(p.Path));
                }
            }
        }

        private void BtAddPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择要备份的文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selPath = dialog.SelectedPath;//获取选中的目录 
                string path = DirTool.Combine(selPath, "\\");//格式化选中的目录
                string name = DirTool.GetPathName(selPath);//获取目录名称

                List<BackupPaths> clashPath = R.Services.FBS.Paths.Where(x => x.Path.Contains(path) || path.Contains(x.Path)).ToList();//查询冲突项
                if (ListTool.HasElements(clashPath))
                {
                    string cp = "";
                    clashPath.ForEach(x => cp += (x.Path + "；"));
                    //存在重合目录
                    MessageBox.Show(string.Format("您当前选择路径：{0}，与之前选择的目录：{1}，存在嵌套包含关系，请先从备份目录中移除，然后重新添加。", path, cp));
                }
                else
                {
                    UIEnableButton(false);
                    Task.Factory.StartNew(() =>
                    {
                        using (var db = new Muse())
                        {
                            if (!db.Do<BackupPaths>().Any(x => x.Path == path))
                            {
                                int row = DgvPath.Rows.Count;//当前目录列表总数 
                                BackupPaths bp = new BackupPaths() { Path = path, Alias = Guid.NewGuid().ToString() };
                                if (db.Add(bp) > 0)
                                {
                                    R.Services.FBS.Paths.Add(bp);//添加到列表
                                    R.Services.FBS.AddToWatcherPath(bp.Path);//添加到监听
                                    UIDgvPathAdd(name);//添加到列表UI

                                    long size = 0;//目录下的文件大小
                                    List<string> files = FileTool.GetAllFile(path);
                                    if (ListTool.HasElements(files))
                                    {
                                        foreach (var f in files)
                                        {
                                            size += FileTool.Size(f);
                                            UIDgvPathUpdate(row, name, ByteConvertTool.Fmt(size));//更新目录文件大小
                                        }
                                    }
                                }
                            }
                        }
                        UIEnableButton(true);
                    });
                }
            }
        }
        private void BtDelPath_Click(object sender, EventArgs e)
        {
            if (DgvPath.CurrentRow != null)
            {
                int row = DgvPath.CurrentRow.Index;
                string path = R.Services.FBS.Paths[row].Path;
                if (row >= 0)
                {
                    using (var db = new Muse())
                    {
                        BackupPaths bp = db.Get<BackupPaths>(x => x.Path == path, null);
                        if (bp != null) db.Del(bp, true);
                        R.Services.FBS.Paths.RemoveAt(row);
                    }
                    UIDgvPathDel(row);
                }
            }
        }
        private void DgvPath_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string path = R.Services.FBS.Paths[e.RowIndex].Path;
                UIEnableButton(false);
                DgvFile.Rows.Clear();
                Task.Factory.StartNew(() =>
                {
                    List<string> files = FileTool.GetAllFile(path);
                    if (ListTool.HasElements(files))
                    {
                        foreach (var file in files)
                        {
                            UIDgvFileAdd(Path.GetFileName(file), file, FileTool.SizeFormat(file));
                        }
                    }
                    UIEnableButton(true);
                });
            }
        }


        /// <summary>
        /// 停用或启用所有按钮
        /// </summary>
        /// <param name="enable"></param>
        void UIEnableButton(bool enable)
        {
            BeginInvoke(new Action(() =>
            {
                BtAddPath.Enabled = enable;
            }));
        }
        /// <summary>
        /// 添加到路径列表
        /// </summary>
        /// <param name="path"></param>
        void UIDgvPathAdd(string name)
        {
            BeginInvoke(new Action(() =>
            {
                DgvPath.Rows.Add(new object[] { name, "-" });
            }));
        }
        /// <summary>
        /// 从路径列表删除
        /// </summary>
        void UIDgvPathDel(int row)
        {
            BeginInvoke(new Action(() =>
            {
                DgvPath.Rows.RemoveAt(row);
            }));
        }
        /// <summary>
        /// 更新到路径列表
        /// </summary>
        /// <param name="row"></param>
        /// <param name="path"></param>
        /// <param name="size"></param>
        void UIDgvPathUpdate(int row, string path, string size)
        {
            BeginInvoke(new Action(() =>
            {
                DgvPath.Rows[row].SetValues(new object[] { Path.GetFileName(path), size });
            }));
        }
        /// <summary>
        /// 添加文件到列表
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <param name="size"></param>
        void UIDgvFileAdd(string file, string path, string size)
        {
            BeginInvoke(new Action(() =>
            {
                DgvFile.Rows.Add(new object[] { file, path, size });
            }));
        }
    }
}
