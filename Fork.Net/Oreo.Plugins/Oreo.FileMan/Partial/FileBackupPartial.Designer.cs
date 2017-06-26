namespace Oreo.FileMan.Partial
{
    partial class FileBackupPartial
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.DgvPath = new System.Windows.Forms.DataGridView();
            this.DgvPathName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvPathSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtAddFolder = new System.Windows.Forms.Button();
            this.DgvFile = new System.Windows.Forms.DataGridView();
            this.DgvFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileVersionHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileLastBackupTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFile)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPath
            // 
            this.DgvPath.AllowUserToAddRows = false;
            this.DgvPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvPathName,
            this.DgvPathSize});
            this.DgvPath.Location = new System.Drawing.Point(7, 38);
            this.DgvPath.Name = "DgvPath";
            this.DgvPath.ReadOnly = true;
            this.DgvPath.RowHeadersVisible = false;
            this.DgvPath.RowTemplate.Height = 23;
            this.DgvPath.Size = new System.Drawing.Size(214, 249);
            this.DgvPath.TabIndex = 0;
            // 
            // DgvPathName
            // 
            this.DgvPathName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgvPathName.HeaderText = "文件夹";
            this.DgvPathName.Name = "DgvPathName";
            this.DgvPathName.ReadOnly = true;
            // 
            // DgvPathSize
            // 
            this.DgvPathSize.HeaderText = "大小";
            this.DgvPathSize.Name = "DgvPathSize";
            this.DgvPathSize.ReadOnly = true;
            this.DgvPathSize.Width = 60;
            // 
            // BtAddFolder
            // 
            this.BtAddFolder.Location = new System.Drawing.Point(7, 6);
            this.BtAddFolder.Name = "BtAddFolder";
            this.BtAddFolder.Size = new System.Drawing.Size(75, 23);
            this.BtAddFolder.TabIndex = 1;
            this.BtAddFolder.Text = "添加目录";
            this.BtAddFolder.UseVisualStyleBackColor = true;
            this.BtAddFolder.Click += new System.EventHandler(this.BtAddFolder_Click);
            // 
            // DgvFile
            // 
            this.DgvFile.AllowUserToAddRows = false;
            this.DgvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvFileName,
            this.DgvFilePath,
            this.DgvFileSize,
            this.DgvFileVersionHistory,
            this.DgvFileLastBackupTime});
            this.DgvFile.Location = new System.Drawing.Point(252, 38);
            this.DgvFile.Name = "DgvFile";
            this.DgvFile.ReadOnly = true;
            this.DgvFile.RowHeadersVisible = false;
            this.DgvFile.RowTemplate.Height = 23;
            this.DgvFile.Size = new System.Drawing.Size(385, 249);
            this.DgvFile.TabIndex = 2;
            // 
            // DgvFileName
            // 
            this.DgvFileName.HeaderText = "文件名";
            this.DgvFileName.Name = "DgvFileName";
            this.DgvFileName.ReadOnly = true;
            // 
            // DgvFilePath
            // 
            this.DgvFilePath.HeaderText = "路径";
            this.DgvFilePath.Name = "DgvFilePath";
            this.DgvFilePath.ReadOnly = true;
            // 
            // DgvFileSize
            // 
            this.DgvFileSize.HeaderText = "大小";
            this.DgvFileSize.Name = "DgvFileSize";
            this.DgvFileSize.ReadOnly = true;
            // 
            // DgvFileVersionHistory
            // 
            this.DgvFileVersionHistory.HeaderText = "历史版本";
            this.DgvFileVersionHistory.Name = "DgvFileVersionHistory";
            this.DgvFileVersionHistory.ReadOnly = true;
            // 
            // DgvFileLastBackupTime
            // 
            this.DgvFileLastBackupTime.HeaderText = "最后备份时间";
            this.DgvFileLastBackupTime.Name = "DgvFileLastBackupTime";
            this.DgvFileLastBackupTime.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(562, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(356, 297);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 21);
            this.textBox1.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(252, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "设置备份目录";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FileBackupPartial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DgvFile);
            this.Controls.Add(this.BtAddFolder);
            this.Controls.Add(this.DgvPath);
            this.Name = "FileBackupPartial";
            this.Size = new System.Drawing.Size(646, 326);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPath;
        private System.Windows.Forms.Button BtAddFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPathName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPathSize;
        private System.Windows.Forms.DataGridView DgvFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileVersionHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileLastBackupTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}
