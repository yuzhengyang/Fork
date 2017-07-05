namespace Oreo.FileMan.Partials
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
            this.BtAddPath = new System.Windows.Forms.Button();
            this.DgvFile = new System.Windows.Forms.DataGridView();
            this.DgvFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileVersionHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileLastBackupTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtDelPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFile)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPath
            // 
            this.DgvPath.AllowUserToAddRows = false;
            this.DgvPath.AllowUserToDeleteRows = false;
            this.DgvPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvPathName,
            this.DgvPathSize});
            this.DgvPath.Location = new System.Drawing.Point(7, 38);
            this.DgvPath.Name = "DgvPath";
            this.DgvPath.ReadOnly = true;
            this.DgvPath.RowHeadersVisible = false;
            this.DgvPath.RowTemplate.Height = 23;
            this.DgvPath.Size = new System.Drawing.Size(214, 275);
            this.DgvPath.TabIndex = 0;
            this.DgvPath.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPath_CellDoubleClick);
            // 
            // DgvPathName
            // 
            this.DgvPathName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgvPathName.HeaderText = "文件夹";
            this.DgvPathName.Name = "DgvPathName";
            this.DgvPathName.ReadOnly = true;
            this.DgvPathName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvPathSize
            // 
            this.DgvPathSize.HeaderText = "大小";
            this.DgvPathSize.Name = "DgvPathSize";
            this.DgvPathSize.ReadOnly = true;
            this.DgvPathSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DgvPathSize.Width = 60;
            // 
            // BtAddPath
            // 
            this.BtAddPath.Location = new System.Drawing.Point(7, 6);
            this.BtAddPath.Name = "BtAddPath";
            this.BtAddPath.Size = new System.Drawing.Size(75, 23);
            this.BtAddPath.TabIndex = 1;
            this.BtAddPath.Text = "添加目录";
            this.BtAddPath.UseVisualStyleBackColor = true;
            this.BtAddPath.Click += new System.EventHandler(this.BtAddPath_Click);
            // 
            // DgvFile
            // 
            this.DgvFile.AllowUserToAddRows = false;
            this.DgvFile.AllowUserToDeleteRows = false;
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
            this.DgvFile.Size = new System.Drawing.Size(385, 275);
            this.DgvFile.TabIndex = 2;
            // 
            // DgvFileName
            // 
            this.DgvFileName.HeaderText = "文件名";
            this.DgvFileName.Name = "DgvFileName";
            this.DgvFileName.ReadOnly = true;
            this.DgvFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvFilePath
            // 
            this.DgvFilePath.HeaderText = "路径";
            this.DgvFilePath.Name = "DgvFilePath";
            this.DgvFilePath.ReadOnly = true;
            this.DgvFilePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvFileSize
            // 
            this.DgvFileSize.HeaderText = "大小";
            this.DgvFileSize.Name = "DgvFileSize";
            this.DgvFileSize.ReadOnly = true;
            this.DgvFileSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvFileVersionHistory
            // 
            this.DgvFileVersionHistory.HeaderText = "历史版本";
            this.DgvFileVersionHistory.Name = "DgvFileVersionHistory";
            this.DgvFileVersionHistory.ReadOnly = true;
            this.DgvFileVersionHistory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvFileLastBackupTime
            // 
            this.DgvFileLastBackupTime.HeaderText = "最后备份时间";
            this.DgvFileLastBackupTime.Name = "DgvFileLastBackupTime";
            this.DgvFileLastBackupTime.ReadOnly = true;
            this.DgvFileLastBackupTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BtDelPath
            // 
            this.BtDelPath.Location = new System.Drawing.Point(99, 6);
            this.BtDelPath.Name = "BtDelPath";
            this.BtDelPath.Size = new System.Drawing.Size(75, 23);
            this.BtDelPath.TabIndex = 6;
            this.BtDelPath.Text = "删除目录";
            this.BtDelPath.UseVisualStyleBackColor = true;
            this.BtDelPath.Click += new System.EventHandler(this.BtDelPath_Click);
            // 
            // FileBackupPartial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BtDelPath);
            this.Controls.Add(this.DgvFile);
            this.Controls.Add(this.BtAddPath);
            this.Controls.Add(this.DgvPath);
            this.Name = "FileBackupPartial";
            this.Size = new System.Drawing.Size(646, 326);
            this.Load += new System.EventHandler(this.FileBackupPartial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPath;
        private System.Windows.Forms.Button BtAddPath;
        private System.Windows.Forms.DataGridView DgvFile;
        private System.Windows.Forms.Button BtDelPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPathName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvPathSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileVersionHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileLastBackupTime;
    }
}
