namespace Oreo.FileMan.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TpFIleType = new System.Windows.Forms.TabPage();
            this.fileTypePartial1 = new Oreo.FileMan.Partials.FileTypePartial();
            this.TpFileEncrypt = new System.Windows.Forms.TabPage();
            this.fileEncryptPartial1 = new Oreo.FileMan.Partials.FileEncryptPartial();
            this.TpFileDecrypt = new System.Windows.Forms.TabPage();
            this.fileDecryptPartial1 = new Oreo.FileMan.Partials.FileDecryptPartial();
            this.TpFileBackup = new System.Windows.Forms.TabPage();
            this.fileBackupPartial1 = new Oreo.FileMan.Partials.FileBackupPartial();
            this.LbFileType = new System.Windows.Forms.Label();
            this.LbFileBackup = new System.Windows.Forms.Label();
            this.LbFileEncrypt = new System.Windows.Forms.Label();
            this.LbTitle = new System.Windows.Forms.Label();
            this.BtClose = new System.Windows.Forms.Button();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.LbAppVersion = new System.Windows.Forms.Label();
            this.BTSettings = new System.Windows.Forms.Button();
            this.LbFileDecrypt = new System.Windows.Forms.Label();
            this.PnBody = new System.Windows.Forms.Panel();
            this.NiMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.CmsNiMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CmsNiMainShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CmsNiMainExit = new System.Windows.Forms.ToolStripMenuItem();
            this.PnMain = new System.Windows.Forms.Panel();
            this.PnBotton = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.TpFIleType.SuspendLayout();
            this.TpFileEncrypt.SuspendLayout();
            this.TpFileDecrypt.SuspendLayout();
            this.TpFileBackup.SuspendLayout();
            this.PnBody.SuspendLayout();
            this.CmsNiMain.SuspendLayout();
            this.PnMain.SuspendLayout();
            this.PnBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TpFIleType);
            this.tabControl1.Controls.Add(this.TpFileEncrypt);
            this.tabControl1.Controls.Add(this.TpFileDecrypt);
            this.tabControl1.Controls.Add(this.TpFileBackup);
            this.tabControl1.Location = new System.Drawing.Point(-5, -24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 358);
            this.tabControl1.TabIndex = 13;
            // 
            // TpFIleType
            // 
            this.TpFIleType.Controls.Add(this.fileTypePartial1);
            this.TpFIleType.Location = new System.Drawing.Point(4, 22);
            this.TpFIleType.Name = "TpFIleType";
            this.TpFIleType.Padding = new System.Windows.Forms.Padding(3);
            this.TpFIleType.Size = new System.Drawing.Size(652, 332);
            this.TpFIleType.TabIndex = 0;
            this.TpFIleType.Text = "文件分类";
            this.TpFIleType.UseVisualStyleBackColor = true;
            // 
            // fileTypePartial1
            // 
            this.fileTypePartial1.BackColor = System.Drawing.Color.White;
            this.fileTypePartial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTypePartial1.Location = new System.Drawing.Point(3, 3);
            this.fileTypePartial1.Name = "fileTypePartial1";
            this.fileTypePartial1.Size = new System.Drawing.Size(646, 326);
            this.fileTypePartial1.TabIndex = 0;
            // 
            // TpFileEncrypt
            // 
            this.TpFileEncrypt.Controls.Add(this.fileEncryptPartial1);
            this.TpFileEncrypt.Location = new System.Drawing.Point(4, 22);
            this.TpFileEncrypt.Name = "TpFileEncrypt";
            this.TpFileEncrypt.Padding = new System.Windows.Forms.Padding(3);
            this.TpFileEncrypt.Size = new System.Drawing.Size(652, 332);
            this.TpFileEncrypt.TabIndex = 2;
            this.TpFileEncrypt.Text = "文件加密";
            this.TpFileEncrypt.UseVisualStyleBackColor = true;
            // 
            // fileEncryptPartial1
            // 
            this.fileEncryptPartial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileEncryptPartial1.Location = new System.Drawing.Point(3, 3);
            this.fileEncryptPartial1.Name = "fileEncryptPartial1";
            this.fileEncryptPartial1.Size = new System.Drawing.Size(646, 326);
            this.fileEncryptPartial1.TabIndex = 0;
            // 
            // TpFileDecrypt
            // 
            this.TpFileDecrypt.Controls.Add(this.fileDecryptPartial1);
            this.TpFileDecrypt.Location = new System.Drawing.Point(4, 22);
            this.TpFileDecrypt.Name = "TpFileDecrypt";
            this.TpFileDecrypt.Padding = new System.Windows.Forms.Padding(3);
            this.TpFileDecrypt.Size = new System.Drawing.Size(652, 332);
            this.TpFileDecrypt.TabIndex = 4;
            this.TpFileDecrypt.Text = "文件解密";
            this.TpFileDecrypt.UseVisualStyleBackColor = true;
            // 
            // fileDecryptPartial1
            // 
            this.fileDecryptPartial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileDecryptPartial1.Location = new System.Drawing.Point(3, 3);
            this.fileDecryptPartial1.Name = "fileDecryptPartial1";
            this.fileDecryptPartial1.Size = new System.Drawing.Size(646, 326);
            this.fileDecryptPartial1.TabIndex = 0;
            // 
            // TpFileBackup
            // 
            this.TpFileBackup.Controls.Add(this.fileBackupPartial1);
            this.TpFileBackup.Location = new System.Drawing.Point(4, 22);
            this.TpFileBackup.Name = "TpFileBackup";
            this.TpFileBackup.Padding = new System.Windows.Forms.Padding(3);
            this.TpFileBackup.Size = new System.Drawing.Size(652, 332);
            this.TpFileBackup.TabIndex = 3;
            this.TpFileBackup.Text = "文件备份";
            this.TpFileBackup.UseVisualStyleBackColor = true;
            // 
            // fileBackupPartial1
            // 
            this.fileBackupPartial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBackupPartial1.Location = new System.Drawing.Point(3, 3);
            this.fileBackupPartial1.Name = "fileBackupPartial1";
            this.fileBackupPartial1.Size = new System.Drawing.Size(646, 326);
            this.fileBackupPartial1.TabIndex = 0;
            // 
            // LbFileType
            // 
            this.LbFileType.AutoSize = true;
            this.LbFileType.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbFileType.ForeColor = System.Drawing.Color.White;
            this.LbFileType.Location = new System.Drawing.Point(365, 42);
            this.LbFileType.Name = "LbFileType";
            this.LbFileType.Size = new System.Drawing.Size(52, 27);
            this.LbFileType.TabIndex = 14;
            this.LbFileType.Text = "分类";
            this.LbFileType.Click += new System.EventHandler(this.LbFileType_Click);
            // 
            // LbFileBackup
            // 
            this.LbFileBackup.AutoSize = true;
            this.LbFileBackup.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbFileBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(161)))), ((int)(((byte)(213)))));
            this.LbFileBackup.Location = new System.Drawing.Point(586, 42);
            this.LbFileBackup.Name = "LbFileBackup";
            this.LbFileBackup.Size = new System.Drawing.Size(52, 27);
            this.LbFileBackup.TabIndex = 16;
            this.LbFileBackup.Text = "备份";
            this.LbFileBackup.Click += new System.EventHandler(this.LbFileBackup_Click);
            // 
            // LbFileEncrypt
            // 
            this.LbFileEncrypt.AutoSize = true;
            this.LbFileEncrypt.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbFileEncrypt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(161)))), ((int)(((byte)(213)))));
            this.LbFileEncrypt.Location = new System.Drawing.Point(447, 42);
            this.LbFileEncrypt.Name = "LbFileEncrypt";
            this.LbFileEncrypt.Size = new System.Drawing.Size(52, 27);
            this.LbFileEncrypt.TabIndex = 15;
            this.LbFileEncrypt.Text = "加密";
            this.LbFileEncrypt.Click += new System.EventHandler(this.LbFileEncrypt_Click);
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbTitle.ForeColor = System.Drawing.Color.White;
            this.LbTitle.Location = new System.Drawing.Point(69, 22);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(107, 25);
            this.LbTitle.TabIndex = 18;
            this.LbTitle.Text = "文件管理器";
            // 
            // BtClose
            // 
            this.BtClose.FlatAppearance.BorderSize = 0;
            this.BtClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtClose.ForeColor = System.Drawing.Color.White;
            this.BtClose.Location = new System.Drawing.Point(615, 7);
            this.BtClose.Name = "BtClose";
            this.BtClose.Size = new System.Drawing.Size(30, 23);
            this.BtClose.TabIndex = 19;
            this.BtClose.Text = "X";
            this.tip.SetToolTip(this.BtClose, "关闭");
            this.BtClose.UseVisualStyleBackColor = true;
            this.BtClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // LbAppVersion
            // 
            this.LbAppVersion.ForeColor = System.Drawing.Color.Gray;
            this.LbAppVersion.Location = new System.Drawing.Point(501, 4);
            this.LbAppVersion.Name = "LbAppVersion";
            this.LbAppVersion.Size = new System.Drawing.Size(140, 19);
            this.LbAppVersion.TabIndex = 0;
            this.LbAppVersion.Text = "当前版本：99.99.99.99";
            this.LbAppVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tip.SetToolTip(this.LbAppVersion, "当前软件版本");
            // 
            // BTSettings
            // 
            this.BTSettings.FlatAppearance.BorderSize = 0;
            this.BTSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTSettings.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTSettings.ForeColor = System.Drawing.Color.White;
            this.BTSettings.Location = new System.Drawing.Point(583, 7);
            this.BTSettings.Name = "BTSettings";
            this.BTSettings.Size = new System.Drawing.Size(30, 23);
            this.BTSettings.TabIndex = 23;
            this.BTSettings.Text = "✿";
            this.tip.SetToolTip(this.BTSettings, "设置");
            this.BTSettings.UseVisualStyleBackColor = true;
            this.BTSettings.Click += new System.EventHandler(this.BTSettings_Click);
            // 
            // LbFileDecrypt
            // 
            this.LbFileDecrypt.AutoSize = true;
            this.LbFileDecrypt.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbFileDecrypt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(161)))), ((int)(((byte)(213)))));
            this.LbFileDecrypt.Location = new System.Drawing.Point(493, 42);
            this.LbFileDecrypt.Name = "LbFileDecrypt";
            this.LbFileDecrypt.Size = new System.Drawing.Size(67, 27);
            this.LbFileDecrypt.TabIndex = 20;
            this.LbFileDecrypt.Text = "/ 解密";
            this.LbFileDecrypt.Click += new System.EventHandler(this.LbFileDecrypt_Click);
            // 
            // PnBody
            // 
            this.PnBody.Controls.Add(this.tabControl1);
            this.PnBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnBody.Location = new System.Drawing.Point(0, 0);
            this.PnBody.Name = "PnBody";
            this.PnBody.Size = new System.Drawing.Size(650, 356);
            this.PnBody.TabIndex = 21;
            // 
            // NiMain
            // 
            this.NiMain.ContextMenuStrip = this.CmsNiMain;
            this.NiMain.Icon = ((System.Drawing.Icon)(resources.GetObject("NiMain.Icon")));
            this.NiMain.Text = "文件管理器";
            this.NiMain.Visible = true;
            this.NiMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NiMain_MouseDoubleClick);
            // 
            // CmsNiMain
            // 
            this.CmsNiMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsNiMainShow,
            this.toolStripSeparator1,
            this.CmsNiMainExit});
            this.CmsNiMain.Name = "CmsNiMain";
            this.CmsNiMain.Size = new System.Drawing.Size(137, 54);
            // 
            // CmsNiMainShow
            // 
            this.CmsNiMainShow.Name = "CmsNiMainShow";
            this.CmsNiMainShow.Size = new System.Drawing.Size(136, 22);
            this.CmsNiMainShow.Text = "显示主界面";
            this.CmsNiMainShow.Click += new System.EventHandler(this.CmsNiMainShow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // CmsNiMainExit
            // 
            this.CmsNiMainExit.Name = "CmsNiMainExit";
            this.CmsNiMainExit.Size = new System.Drawing.Size(136, 22);
            this.CmsNiMainExit.Text = "退出";
            this.CmsNiMainExit.Click += new System.EventHandler(this.CmsNiMainExit_Click);
            // 
            // PnMain
            // 
            this.PnMain.Controls.Add(this.PnBotton);
            this.PnMain.Controls.Add(this.PnBody);
            this.PnMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnMain.Location = new System.Drawing.Point(0, 70);
            this.PnMain.Name = "PnMain";
            this.PnMain.Size = new System.Drawing.Size(650, 356);
            this.PnMain.TabIndex = 22;
            // 
            // PnBotton
            // 
            this.PnBotton.Controls.Add(this.LbAppVersion);
            this.PnBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnBotton.Location = new System.Drawing.Point(0, 329);
            this.PnBotton.Name = "PnBotton";
            this.PnBotton.Size = new System.Drawing.Size(650, 27);
            this.PnBotton.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(650, 426);
            this.Controls.Add(this.BTSettings);
            this.Controls.Add(this.PnMain);
            this.Controls.Add(this.LbFileDecrypt);
            this.Controls.Add(this.BtClose);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LbFileBackup);
            this.Controls.Add(this.LbFileEncrypt);
            this.Controls.Add(this.LbFileType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.TpFIleType.ResumeLayout(false);
            this.TpFileEncrypt.ResumeLayout(false);
            this.TpFileDecrypt.ResumeLayout(false);
            this.TpFileBackup.ResumeLayout(false);
            this.PnBody.ResumeLayout(false);
            this.CmsNiMain.ResumeLayout(false);
            this.PnMain.ResumeLayout(false);
            this.PnBotton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TpFIleType;
        private System.Windows.Forms.Label LbFileType;
        private System.Windows.Forms.Label LbFileBackup;
        private System.Windows.Forms.Label LbFileEncrypt;
        private System.Windows.Forms.TabPage TpFileEncrypt;
        private System.Windows.Forms.TabPage TpFileBackup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Button BtClose;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.TabPage TpFileDecrypt;
        private System.Windows.Forms.Label LbFileDecrypt;
        private System.Windows.Forms.Panel PnBody;
        private Partials.FileEncryptPartial fileEncryptPartial1;
        private Partials.FileDecryptPartial fileDecryptPartial1;
        private Partials.FileTypePartial fileTypePartial1;
        private System.Windows.Forms.NotifyIcon NiMain;
        private System.Windows.Forms.Panel PnMain;
        private System.Windows.Forms.Panel PnBotton;
        private System.Windows.Forms.Label LbAppVersion;
        private System.Windows.Forms.Button BTSettings;
        private Partials.FileBackupPartial fileBackupPartial1;
        private System.Windows.Forms.ContextMenuStrip CmsNiMain;
        private System.Windows.Forms.ToolStripMenuItem CmsNiMainShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem CmsNiMainExit;
    }
}