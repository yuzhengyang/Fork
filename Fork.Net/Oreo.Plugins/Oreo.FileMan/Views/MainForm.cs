using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y.Skin.YoForm.NoTitle;
using Y.Utils.IOUtils.FileUtils;

namespace Oreo.FileMan.Views
{
    public partial class MainForm : NoTitleForm
    {
        Color TabLabelColor = Color.FromArgb(50, 161, 213);
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }


        #region 选项卡切换
        private void LbFileType_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("TpFileType");
            ChangeTabColor((Label)sender);
        }

        private void LbFileEncrypt_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("TpFileEncrypt");
            ChangeTabColor((Label)sender);
        }

        private void LbFileBackup_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("TpFileBackup");
            ChangeTabColor((Label)sender);
        }

        private void LbFileDecrypt_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("TpFileDecrypt");
            ChangeTabColor((Label)sender);
        }
        void ChangeTabColor(Label now)
        {
            LbFileType.ForeColor = TabLabelColor;
            LbFileEncrypt.ForeColor = TabLabelColor;
            LbFileDecrypt.ForeColor = TabLabelColor;
            LbFileBackup.ForeColor = TabLabelColor;

            now.ForeColor = Color.White;
        }
        #endregion
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtClose_Click(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() => { Close(); }));
        }
    }
}
