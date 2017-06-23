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
            this.button1 = new System.Windows.Forms.Button();
            this.DgvPathName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvPathSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFile = new System.Windows.Forms.DataGridView();
            this.DgvFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileVersionHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileLastBackupTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.DgvPath.Location = new System.Drawing.Point(3, 32);
            this.DgvPath.Name = "DgvPath";
            this.DgvPath.ReadOnly = true;
            this.DgvPath.RowHeadersVisible = false;
            this.DgvPath.RowTemplate.Height = 23;
            this.DgvPath.Size = new System.Drawing.Size(218, 291);
            this.DgvPath.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
            this.DgvFile.Location = new System.Drawing.Point(252, 32);
            this.DgvFile.Name = "DgvFile";
            this.DgvFile.ReadOnly = true;
            this.DgvFile.RowHeadersVisible = false;
            this.DgvFile.RowTemplate.Height = 23;
            this.DgvFile.Size = new System.Drawing.Size(391, 291);
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
            // FileBackupPartial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DgvFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DgvPath);
            this.Name = "FileBackupPartial";
            this.Size = new System.Drawing.Size(646, 326);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPathName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPathSize;
        private System.Windows.Forms.DataGridView DgvFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileVersionHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileLastBackupTime;
    }
}
