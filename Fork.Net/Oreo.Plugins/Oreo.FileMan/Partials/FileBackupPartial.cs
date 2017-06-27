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

namespace Oreo.FileMan.Partials
{
    public partial class FileBackupPartial : UserControl
    {
        List<BackupPaths> BackupPath = new List<BackupPaths>();
        public FileBackupPartial()
        {
            InitializeComponent();
        }
        private void FileBackupPartial_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                using (var db = new Muse())
                {
                    BackupPath = db.GetAll<BackupPaths>(null, false).ToList();
                    if (ListTool.HasElements(BackupPath))
                    {
                        foreach (var b in BackupPath)
                        {
                            UIDgvPathAdd(b.Name);
                        }
                    }
                }
            });
        }
        #region 目录操作
        private void BtAddPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择要备份的文件夹";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selPath = dialog.SelectedPath;//格式化选中的目录
                List<BackupPaths> clashPath = BackupPath.Where(x => x.Path.Contains(selPath + "\\") || (selPath + "\\").Contains(x.Path)).ToList();//查询冲突项
                if (ListTool.HasElements(clashPath))
                {
                    string cp = "";
                    clashPath.ForEach(x => cp += (x.Path + "；"));
                    //存在重合目录
                    MessageBox.Show(string.Format("您当前选择路径：{0}，与之前选择的目录：{1}，存在嵌套包含关系，请先从备份目录中移除，然后重新添加。", selPath, cp));
                }
                else
                {
                    long size = 0;//目录下的文件大小
                    int row = DgvPath.Rows.Count;//当前目录列表总数
                    BackupPaths bp = new BackupPaths() { Name = Path.GetFileName(selPath), Path = selPath + "\\", };
                    BackupPath.Add(bp);//添加到列表
                    UIDgvPathAdd(Path.GetFileName(selPath));//添加到列表UI

                    UIEnableButton(false);
                    Task.Factory.StartNew(() =>
                    {
                        using (var db = new Muse())
                        {
                            if (!db.Do<BackupPaths>().Any(x => x.Path == (selPath + "\\"))) db.Add(bp);//添加到数据库
                            List<string> files = FileTool.GetAllFile(selPath);
                            if (ListTool.HasElements(files))
                            {
                                foreach (var f in files)
                                {
                                    size += FileTool.Size(f);
                                    UIDgvPathUpdate(row, Path.GetFileName(selPath), ByteConvertTool.Fmt(size));//更新目录文件大小
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
                string path = BackupPath[row].Path;
                if (row >= 0)
                {
                    using (var db = new Muse())
                    {
                        BackupPaths bp = db.Get<BackupPaths>(x => x.Path == path, null);
                        if (bp != null) db.Del(bp, true);
                        BackupPath.RemoveAt(row);
                    }
                    UIDgvPathDel(row);
                }
            }
        }
        private void DgvPath_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string path = BackupPath[e.RowIndex].Path;
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
        #endregion

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
        #region 路径列表UI操作
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
        #endregion
        #region 文件列表UI操作
        void UIDgvFileAdd(string file, string path, string size)
        {
            BeginInvoke(new Action(() =>
            {
                DgvFile.Rows.Add(new object[] { file, path, size });
            }));
        }
        #endregion


    }
}
