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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvFileList = new System.Windows.Forms.DataGridView();
            this.ColNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PbStatus = new System.Windows.Forms.ProgressBar();
            this.LbStatus = new System.Windows.Forms.Label();
            this.LbTitle = new System.Windows.Forms.Label();
            this.LbRetry = new System.Windows.Forms.Label();
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
            this.ColUpdate});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvFileList.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvFileList.Location = new System.Drawing.Point(11, 124);
            this.DgvFileList.Name = "DgvFileList";
            this.DgvFileList.ReadOnly = true;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFileList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvFileList.RowHeadersVisible = false;
            this.DgvFileList.RowTemplate.Height = 23;
            this.DgvFileList.Size = new System.Drawing.Size(379, 252);
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
            // ColUpdate
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColUpdate.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColUpdate.FillWeight = 10F;
            this.ColUpdate.HeaderText = "更新";
            this.ColUpdate.Name = "ColUpdate";
            this.ColUpdate.ReadOnly = true;
            this.ColUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PbStatus
            // 
            this.PbStatus.Location = new System.Drawing.Point(12, 40);
            this.PbStatus.Name = "PbStatus";
            this.PbStatus.Size = new System.Drawing.Size(379, 16);
            this.PbStatus.TabIndex = 15;
            // 
            // LbStatus
            // 
            this.LbStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LbStatus.Location = new System.Drawing.Point(12, 73);
            this.LbStatus.Name = "LbStatus";
            this.LbStatus.Size = new System.Drawing.Size(378, 23);
            this.LbStatus.TabIndex = 16;
            this.LbStatus.Text = "更新状态";
            this.LbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LbStatus.DoubleClick += new System.EventHandler(this.LbStatus_DoubleClick);
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Location = new System.Drawing.Point(12, 13);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(71, 12);
            this.LbTitle.TabIndex = 17;
            this.LbTitle.Text = "正在更新...";
            // 
            // LbRetry
            // 
            this.LbRetry.AutoSize = true;
            this.LbRetry.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LbRetry.Location = new System.Drawing.Point(349, 13);
            this.LbRetry.Name = "LbRetry";
            this.LbRetry.Size = new System.Drawing.Size(29, 12);
            this.LbRetry.TabIndex = 18;
            this.LbRetry.Text = "重试";
            this.LbRetry.Click += new System.EventHandler(this.LbRetry_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 381);
            this.Controls.Add(this.LbRetry);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.LbStatus);
            this.Controls.Add(this.PbStatus);
            this.Controls.Add(this.DgvFileList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "更新程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFileList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvFileList;
        private System.Windows.Forms.ProgressBar PbStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColUpdate;
        private System.Windows.Forms.Label LbStatus;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Label LbRetry;
    }
}

