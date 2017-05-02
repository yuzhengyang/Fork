namespace Version.Update
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvFileList = new System.Windows.Forms.DataGridView();
            this.ColNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRoll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtRollback = new System.Windows.Forms.Button();
            this.BtUpdate = new System.Windows.Forms.Button();
            this.BtBackup = new System.Windows.Forms.Button();
            this.BtDownload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFileList)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvFileList
            // 
            this.DgvFileList.AllowUserToAddRows = false;
            this.DgvFileList.AllowUserToDeleteRows = false;
            this.DgvFileList.AllowUserToResizeColumns = false;
            this.DgvFileList.AllowUserToResizeRows = false;
            this.DgvFileList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFileList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColNum,
            this.ColFile,
            this.ColDown,
            this.ColBack,
            this.ColUpdate,
            this.ColRoll});
            this.DgvFileList.Location = new System.Drawing.Point(12, 55);
            this.DgvFileList.Name = "DgvFileList";
            this.DgvFileList.ReadOnly = true;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFileList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvFileList.RowHeadersVisible = false;
            this.DgvFileList.RowTemplate.Height = 23;
            this.DgvFileList.Size = new System.Drawing.Size(699, 424);
            this.DgvFileList.TabIndex = 10;
            // 
            // ColNum
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColNum.FillWeight = 10F;
            this.ColNum.HeaderText = "序号";
            this.ColNum.Name = "ColNum";
            this.ColNum.ReadOnly = true;
            this.ColNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColFile
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColFile.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColFile.FillWeight = 40F;
            this.ColFile.HeaderText = "文件";
            this.ColFile.Name = "ColFile";
            this.ColFile.ReadOnly = true;
            this.ColFile.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDown
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColDown.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColDown.FillWeight = 10F;
            this.ColDown.HeaderText = "下载";
            this.ColDown.Name = "ColDown";
            this.ColDown.ReadOnly = true;
            this.ColDown.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColDown.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColBack
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColBack.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColBack.FillWeight = 10F;
            this.ColBack.HeaderText = "备份";
            this.ColBack.Name = "ColBack";
            this.ColBack.ReadOnly = true;
            this.ColBack.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColBack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColUpdate
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColUpdate.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColUpdate.FillWeight = 10F;
            this.ColUpdate.HeaderText = "更新";
            this.ColUpdate.Name = "ColUpdate";
            this.ColUpdate.ReadOnly = true;
            this.ColUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColRoll
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColRoll.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColRoll.FillWeight = 10F;
            this.ColRoll.HeaderText = "还原";
            this.ColRoll.Name = "ColRoll";
            this.ColRoll.ReadOnly = true;
            this.ColRoll.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColRoll.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BtRollback
            // 
            this.BtRollback.Location = new System.Drawing.Point(634, 22);
            this.BtRollback.Name = "BtRollback";
            this.BtRollback.Size = new System.Drawing.Size(75, 23);
            this.BtRollback.TabIndex = 14;
            this.BtRollback.Text = "还原";
            this.BtRollback.UseVisualStyleBackColor = true;
            this.BtRollback.Click += new System.EventHandler(this.BtRollback_Click);
            // 
            // BtUpdate
            // 
            this.BtUpdate.Location = new System.Drawing.Point(556, 22);
            this.BtUpdate.Name = "BtUpdate";
            this.BtUpdate.Size = new System.Drawing.Size(75, 23);
            this.BtUpdate.TabIndex = 13;
            this.BtUpdate.Text = "更新";
            this.BtUpdate.UseVisualStyleBackColor = true;
            this.BtUpdate.Click += new System.EventHandler(this.BtUpdate_Click);
            // 
            // BtBackup
            // 
            this.BtBackup.Location = new System.Drawing.Point(478, 22);
            this.BtBackup.Name = "BtBackup";
            this.BtBackup.Size = new System.Drawing.Size(75, 23);
            this.BtBackup.TabIndex = 12;
            this.BtBackup.Text = "备份";
            this.BtBackup.UseVisualStyleBackColor = true;
            this.BtBackup.Click += new System.EventHandler(this.BtBackup_Click);
            // 
            // BtDownload
            // 
            this.BtDownload.Location = new System.Drawing.Point(401, 22);
            this.BtDownload.Name = "BtDownload";
            this.BtDownload.Size = new System.Drawing.Size(75, 23);
            this.BtDownload.TabIndex = 11;
            this.BtDownload.Text = "下载";
            this.BtDownload.UseVisualStyleBackColor = true;
            this.BtDownload.Click += new System.EventHandler(this.BtDownload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 494);
            this.Controls.Add(this.DgvFileList);
            this.Controls.Add(this.BtRollback);
            this.Controls.Add(this.BtUpdate);
            this.Controls.Add(this.BtBackup);
            this.Controls.Add(this.BtDownload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFileList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvFileList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRoll;
        private System.Windows.Forms.Button BtRollback;
        private System.Windows.Forms.Button BtUpdate;
        private System.Windows.Forms.Button BtBackup;
        private System.Windows.Forms.Button BtDownload;
    }
}

