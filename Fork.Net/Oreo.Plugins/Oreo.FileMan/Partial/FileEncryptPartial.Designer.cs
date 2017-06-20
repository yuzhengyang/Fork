namespace Oreo.FileMan.Partial
{
    partial class FileEncryptPartial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvFileEncryptList = new System.Windows.Forms.DataGridView();
            this.CoFileEncryptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoFileEncryptStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbFileEncryptPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbFileEncryptDelete = new System.Windows.Forms.CheckBox();
            this.BtFileEncryptAdds = new System.Windows.Forms.Button();
            this.BtFileEncryptAdd = new System.Windows.Forms.Button();
            this.BtFileEncrypt = new System.Windows.Forms.Button();
            this.BtFileEncryptClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFileEncryptList)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvFileEncryptList
            // 
            this.DgvFileEncryptList.AllowUserToAddRows = false;
            this.DgvFileEncryptList.AllowUserToResizeColumns = false;
            this.DgvFileEncryptList.AllowUserToResizeRows = false;
            this.DgvFileEncryptList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFileEncryptList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvFileEncryptList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFileEncryptList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoFileEncryptName,
            this.CoFileEncryptStatus});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvFileEncryptList.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvFileEncryptList.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvFileEncryptList.Location = new System.Drawing.Point(0, 0);
            this.DgvFileEncryptList.Name = "DgvFileEncryptList";
            this.DgvFileEncryptList.ReadOnly = true;
            this.DgvFileEncryptList.RowHeadersVisible = false;
            this.DgvFileEncryptList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DgvFileEncryptList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvFileEncryptList.RowTemplate.Height = 23;
            this.DgvFileEncryptList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFileEncryptList.Size = new System.Drawing.Size(646, 275);
            this.DgvFileEncryptList.TabIndex = 17;
            // 
            // CoFileEncryptName
            // 
            this.CoFileEncryptName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CoFileEncryptName.DefaultCellStyle = dataGridViewCellStyle7;
            this.CoFileEncryptName.HeaderText = "文件";
            this.CoFileEncryptName.Name = "CoFileEncryptName";
            this.CoFileEncryptName.ReadOnly = true;
            this.CoFileEncryptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CoFileEncryptStatus
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CoFileEncryptStatus.DefaultCellStyle = dataGridViewCellStyle8;
            this.CoFileEncryptStatus.HeaderText = "状态";
            this.CoFileEncryptStatus.Name = "CoFileEncryptStatus";
            this.CoFileEncryptStatus.ReadOnly = true;
            this.CoFileEncryptStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TbFileEncryptPassword
            // 
            this.TbFileEncryptPassword.Location = new System.Drawing.Point(321, 292);
            this.TbFileEncryptPassword.Name = "TbFileEncryptPassword";
            this.TbFileEncryptPassword.PasswordChar = '*';
            this.TbFileEncryptPassword.Size = new System.Drawing.Size(100, 21);
            this.TbFileEncryptPassword.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "密码：";
            // 
            // CbFileEncryptDelete
            // 
            this.CbFileEncryptDelete.AutoSize = true;
            this.CbFileEncryptDelete.Location = new System.Drawing.Point(445, 294);
            this.CbFileEncryptDelete.Name = "CbFileEncryptDelete";
            this.CbFileEncryptDelete.Size = new System.Drawing.Size(120, 16);
            this.CbFileEncryptDelete.TabIndex = 26;
            this.CbFileEncryptDelete.Text = "加密后删除源文件";
            this.CbFileEncryptDelete.UseVisualStyleBackColor = true;
            // 
            // BtFileEncryptAdds
            // 
            this.BtFileEncryptAdds.Location = new System.Drawing.Point(88, 291);
            this.BtFileEncryptAdds.Name = "BtFileEncryptAdds";
            this.BtFileEncryptAdds.Size = new System.Drawing.Size(75, 23);
            this.BtFileEncryptAdds.TabIndex = 25;
            this.BtFileEncryptAdds.Text = "批量导入";
            this.BtFileEncryptAdds.UseVisualStyleBackColor = true;
            this.BtFileEncryptAdds.Click += new System.EventHandler(this.BtFileEncryptAdds_Click);
            // 
            // BtFileEncryptAdd
            // 
            this.BtFileEncryptAdd.Location = new System.Drawing.Point(5, 291);
            this.BtFileEncryptAdd.Name = "BtFileEncryptAdd";
            this.BtFileEncryptAdd.Size = new System.Drawing.Size(75, 23);
            this.BtFileEncryptAdd.TabIndex = 24;
            this.BtFileEncryptAdd.Text = "添加文件";
            this.BtFileEncryptAdd.UseVisualStyleBackColor = true;
            this.BtFileEncryptAdd.Click += new System.EventHandler(this.BtFileEncryptAdd_Click);
            // 
            // BtFileEncrypt
            // 
            this.BtFileEncrypt.Location = new System.Drawing.Point(565, 291);
            this.BtFileEncrypt.Name = "BtFileEncrypt";
            this.BtFileEncrypt.Size = new System.Drawing.Size(75, 23);
            this.BtFileEncrypt.TabIndex = 23;
            this.BtFileEncrypt.Text = "全部加密";
            this.BtFileEncrypt.UseVisualStyleBackColor = true;
            this.BtFileEncrypt.Click += new System.EventHandler(this.BtFileEncrypt_Click);
            // 
            // BtFileEncryptClear
            // 
            this.BtFileEncryptClear.Location = new System.Drawing.Point(169, 291);
            this.BtFileEncryptClear.Name = "BtFileEncryptClear";
            this.BtFileEncryptClear.Size = new System.Drawing.Size(75, 23);
            this.BtFileEncryptClear.TabIndex = 37;
            this.BtFileEncryptClear.Text = "清空列表";
            this.BtFileEncryptClear.UseVisualStyleBackColor = true;
            this.BtFileEncryptClear.Click += new System.EventHandler(this.BtFileEncryptClear_Click);
            // 
            // FileEncryptPartial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtFileEncryptClear);
            this.Controls.Add(this.TbFileEncryptPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbFileEncryptDelete);
            this.Controls.Add(this.BtFileEncryptAdds);
            this.Controls.Add(this.BtFileEncryptAdd);
            this.Controls.Add(this.BtFileEncrypt);
            this.Controls.Add(this.DgvFileEncryptList);
            this.Name = "FileEncryptPartial";
            this.Size = new System.Drawing.Size(646, 326);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFileEncryptList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvFileEncryptList;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoFileEncryptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoFileEncryptStatus;
        private System.Windows.Forms.TextBox TbFileEncryptPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CbFileEncryptDelete;
        private System.Windows.Forms.Button BtFileEncryptAdds;
        private System.Windows.Forms.Button BtFileEncryptAdd;
        private System.Windows.Forms.Button BtFileEncrypt;
        private System.Windows.Forms.Button BtFileEncryptClear;
    }
}
