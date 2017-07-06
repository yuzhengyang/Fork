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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvPath = new System.Windows.Forms.DataGridView();
            this.DgvPathName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvPathSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtAddPath = new System.Windows.Forms.Button();
            this.DgvFile = new System.Windows.Forms.DataGridView();
            this.DgvFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileVersionHistory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFileLastBackupTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtDelPath = new System.Windows.Forms.Button();
            this.TmReadPaths = new System.Windows.Forms.Timer(this.components);
            this.LbStatus = new System.Windows.Forms.Label();
            this.TmStatus = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFile)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPath
            // 
            this.DgvPath.AllowUserToAddRows = false;
            this.DgvPath.AllowUserToDeleteRows = false;
            this.DgvPath.AllowUserToResizeColumns = false;
            this.DgvPath.AllowUserToResizeRows = false;
            this.DgvPath.BackgroundColor = System.Drawing.Color.White;
            this.DgvPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvPathName,
            this.DgvPathSize});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPath.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvPath.GridColor = System.Drawing.Color.Silver;
            this.DgvPath.Location = new System.Drawing.Point(3, 32);
            this.DgvPath.Name = "DgvPath";
            this.DgvPath.ReadOnly = true;
            this.DgvPath.RowHeadersVisible = false;
            this.DgvPath.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvPath.RowTemplate.Height = 23;
            this.DgvPath.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPath.Size = new System.Drawing.Size(191, 291);
            this.DgvPath.TabIndex = 0;
            this.DgvPath.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPath_CellClick);
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
            this.BtAddPath.Location = new System.Drawing.Point(3, 3);
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
            this.DgvFile.AllowUserToResizeColumns = false;
            this.DgvFile.AllowUserToResizeRows = false;
            this.DgvFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvFile.BackgroundColor = System.Drawing.Color.White;
            this.DgvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvFileName,
            this.DgvFileSize,
            this.DgvFileVersionHistory,
            this.DgvFileLastBackupTime,
            this.DgvFilePath});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvFile.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvFile.GridColor = System.Drawing.Color.Silver;
            this.DgvFile.Location = new System.Drawing.Point(200, 32);
            this.DgvFile.Name = "DgvFile";
            this.DgvFile.ReadOnly = true;
            this.DgvFile.RowHeadersVisible = false;
            this.DgvFile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvFile.RowTemplate.Height = 23;
            this.DgvFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFile.Size = new System.Drawing.Size(443, 291);
            this.DgvFile.TabIndex = 2;
            this.DgvFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFile_CellDoubleClick);
            // 
            // DgvFileName
            // 
            this.DgvFileName.HeaderText = "文件名";
            this.DgvFileName.Name = "DgvFileName";
            this.DgvFileName.ReadOnly = true;
            this.DgvFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvFileSize
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvFileSize.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvFileSize.HeaderText = "大小";
            this.DgvFileSize.Name = "DgvFileSize";
            this.DgvFileSize.ReadOnly = true;
            this.DgvFileSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvFileVersionHistory
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvFileVersionHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvFileVersionHistory.HeaderText = "历史版本";
            this.DgvFileVersionHistory.Name = "DgvFileVersionHistory";
            this.DgvFileVersionHistory.ReadOnly = true;
            this.DgvFileVersionHistory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvFileLastBackupTime
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvFileLastBackupTime.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvFileLastBackupTime.HeaderText = "最后备份时间";
            this.DgvFileLastBackupTime.Name = "DgvFileLastBackupTime";
            this.DgvFileLastBackupTime.ReadOnly = true;
            this.DgvFileLastBackupTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvFilePath
            // 
            this.DgvFilePath.HeaderText = "路径";
            this.DgvFilePath.Name = "DgvFilePath";
            this.DgvFilePath.ReadOnly = true;
            this.DgvFilePath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BtDelPath
            // 
            this.BtDelPath.Location = new System.Drawing.Point(119, 3);
            this.BtDelPath.Name = "BtDelPath";
            this.BtDelPath.Size = new System.Drawing.Size(75, 23);
            this.BtDelPath.TabIndex = 6;
            this.BtDelPath.Text = "删除目录";
            this.BtDelPath.UseVisualStyleBackColor = true;
            this.BtDelPath.Click += new System.EventHandler(this.BtDelPath_Click);
            // 
            // TmReadPaths
            // 
            this.TmReadPaths.Interval = 1000;
            this.TmReadPaths.Tick += new System.EventHandler(this.TmReadPaths_Tick);
            // 
            // LbStatus
            // 
            this.LbStatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbStatus.Location = new System.Drawing.Point(365, 6);
            this.LbStatus.Name = "LbStatus";
            this.LbStatus.Size = new System.Drawing.Size(266, 16);
            this.LbStatus.TabIndex = 7;
            this.LbStatus.Text = "文件备份已开启：已备份 - 个文件";
            this.LbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TmStatus
            // 
            this.TmStatus.Interval = 1000;
            this.TmStatus.Tick += new System.EventHandler(this.TmStatus_Tick);
            // 
            // FileBackupPartial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.LbStatus);
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
        private System.Windows.Forms.Timer TmReadPaths;
        private System.Windows.Forms.Label LbStatus;
        private System.Windows.Forms.Timer TmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileVersionHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFileLastBackupTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFilePath;
    }
}
