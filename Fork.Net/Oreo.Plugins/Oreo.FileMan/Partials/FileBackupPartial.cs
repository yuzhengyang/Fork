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
using Oreo.FileMan.Views;

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
            UIEnableButton(false);
            TmReadPaths.Enabled = true;
            TmStatus.Enabled = true;
        }

        #region Event
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
                                BackupPaths bp = new BackupPaths() { Path = path, Alias = Guid.NewGuid().ToString() };
                                if (db.Add(bp) > 0)
                                {
                                    R.Services.FBS.Paths.Add(bp);//添加到列表
                                    R.Services.FBS.AddToWatcherPath(bp.Path);//添加到监听
                                    UIDgvPathAdd(name, null);//添加到列表UI
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
        private void DgvPath_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowFileDetails(e.RowIndex);
        }
        private void DgvFile_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string filepath = DgvFile.Rows[e.RowIndex].Cells["DgvFilePath"].Value.ToString();
                new FileRestoreForm(filepath).ShowDialog();
            }
        }
        /// <summary>
        /// 读取备份文件目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmReadPaths_Tick(object sender, EventArgs e)
        {
            if (R.Services.FBS.StatusOfReadBackupPaths)
            {
                TmReadPaths.Enabled = false;
                Task.Factory.StartNew(() =>
                {
                    if (ListTool.HasElements(R.Services.FBS.Paths))
                    {
                        foreach (var p in R.Services.FBS.Paths)
                        {
                            using (var db = new Muse())
                            {
                                long size = db.Do<BackupFiles>().Where(x => x.FullPath.Contains(p.Path)).Sum(x => x.Size);
                                string name = DirTool.GetPathName(p.Path);//获取目录名称
                                UIDgvPathAdd(name, ByteConvertTool.Fmt(size));//添加到列表UI
                            }
                        }
                    }
                    UIEnableButton(true);
                });
            }
        }
        private void TmStatus_Tick(object sender, EventArgs e)
        {
            LbStatus.Text = R.Services.FBS.IsStart ?
                string.Format("文件备份已开启：已备份 {0} 个文件", R.Services.FBS.FileCount) : "文件监控已关闭";
            LbStatus.ForeColor = R.Services.FBS.IsStart ? Color.Green : Color.Red;
        }
        #endregion

        #region Function
        void ShowFileDetails(int row)
        {
            if (row >= 0)
            {
                string path = R.Services.FBS.Paths[row].Path;
                UIEnableButton(false);
                DgvFile.Rows.Clear();
                Task.Factory.StartNew(() =>
                {
                    using (var db = new Muse())
                    {
                        db.Context.Database.Log = (sql) =>
                        {
                            R.Log.i(sql);
                        };
                        try
                        {
                            var result = db.Do<BackupFiles>().
                                Where(x => x.FullPath.Contains(path)).
                                GroupBy(x => new { x.FullPath }).
                                Select(x => new
                                {
                                    Path = x.Max(o => o.FullPath),
                                    BackPath = x.Max(o => o.BackupFullPath),
                                    Count = x.Count(),
                                    Time = x.Max(o => o.LastWriteTime),
                                }).ToList();

                            if (ListTool.HasElements(result))
                            {
                                foreach (var item in result)
                                {
                                    //BackupFiles bkfile = bkfiles.FirstOrDefault(x => x.FullPath == file);
                                    //int versioncount = bkfiles.Count(x => x.FullPath == file);
                                    //string lastwritetime = bkfile != null ? bkfile.LastWriteTime : "-";
                                    string versiondesc = "第 " + item.Count + " 版";
                                    UIDgvFileAdd(Path.GetFileName(item.Path), item.Path, FileTool.SizeFormat(item.BackPath), versiondesc, item.Time);
                                }
                            }
                        }
                        catch (Exception e) { }

                        //List<BackupFiles> bkfiles = db.Gets<BackupFiles>(x => x.FullPath.Contains(path), null).ToList();
                        //List<string> files = FileTool.GetAllFile(path);
                        //if (ListTool.HasElements(files))
                        //{
                        //    foreach (var file in files)
                        //    {
                        //        BackupFiles bkfile = bkfiles.FirstOrDefault(x => x.FullPath == file);
                        //        int versioncount = bkfiles.Count(x => x.FullPath == file);
                        //        string versiondesc = "第 " + versioncount + " 版";
                        //        string lastwritetime = bkfile != null ? bkfile.LastWriteTime : "-";
                        //        UIDgvFileAdd(Path.GetFileName(file), file, FileTool.SizeFormat(file), versiondesc, lastwritetime);
                        //    }
                        //}
                    }
                    UIEnableButton(true);
                });
            }
        }
        #endregion

        #region UI
        /// <summary>
        /// 停用或启用所有按钮
        /// </summary>
        /// <param name="enable"></param>
        void UIEnableButton(bool enable)
        {
            BeginInvoke(new Action(() =>
            {
                BtAddPath.Enabled = enable;
                BtDelPath.Enabled = enable;
            }));
        }
        /// <summary>
        /// 添加到路径列表
        /// </summary>
        /// <param name="path"></param>
        void UIDgvPathAdd(string name, string size)
        {
            BeginInvoke(new Action(() =>
            {
                DgvPath.Rows.Add(new object[] { name, size ?? "-" });
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
        void UIDgvFileAdd(string file, string path, string size, string version, string lasttime)
        {
            BeginInvoke(new Action(() =>
            {
                DgvFile.Rows.Add(new object[] { file, size, version, lasttime, path });
                DgvFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }));
        }

        #endregion


    }
}
