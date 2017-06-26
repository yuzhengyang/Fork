namespace Oreo.FileMan.Partials
{
    partial class FileDecryptPartial
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
            this.DgvFileDecryptList = new System.Windows.Forms.DataGridView();
            this.CoFileDecryptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoFileDecryptStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbFileDecryptPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbFileDecryptDelete = new System.Windows.Forms.CheckBox();
            this.BtFileDecryptAdds = new System.Windows.Forms.Button();
            this.BtFileDecryptAdd = new System.Windows.Forms.Button();
            this.BtFileDecrypt = new System.Windows.Forms.Button();
            this.BtFileDecryptClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFileDecryptList)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvFileDecryptList
            // 
            this.DgvFileDecryptList.AllowUserToAddRows = false;
            this.DgvFileDecryptList.AllowUserToResizeColumns = false;
            this.DgvFileDecryptList.AllowUserToResizeRows = false;
            this.DgvFileDecryptList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFileDecryptList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvFileDecryptList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFileDecryptList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoFileDecryptName,
            this.CoFileDecryptStatus});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvFileDecryptList.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvFileDecryptList.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvFileDecryptList.Location = new System.Drawing.Point(0, 0);
            this.DgvFileDecryptList.Name = "DgvFileDecryptList";
            this.DgvFileDecryptList.ReadOnly = true;
            this.DgvFileDecryptList.RowHeadersVisible = false;
            this.DgvFileDecryptList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DgvFileDecryptList.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvFileDecryptList.RowTemplate.Height = 23;
            this.DgvFileDecryptList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFileDecryptList.Size = new System.Drawing.Size(646, 275);
            this.DgvFileDecryptList.TabIndex = 29;
            // 
            // CoFileDecryptName
            // 
            this.CoFileDecryptName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.CoFileDecryptName.DefaultCellStyle = dataGridViewCellStyle7;
            this.CoFileDecryptName.HeaderText = "文件";
            this.CoFileDecryptName.Name = "CoFileDecryptName";
            this.CoFileDecryptName.ReadOnly = true;
            this.CoFileDecryptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CoFileDecryptStatus
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CoFileDecryptStatus.DefaultCellStyle = dataGridViewCellStyle8;
            this.CoFileDecryptStatus.HeaderText = "状态";
            this.CoFileDecryptStatus.Name = "CoFileDecryptStatus";
            this.CoFileDecryptStatus.ReadOnly = true;
            this.CoFileDecryptStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TbFileDecryptPassword
            // 
            this.TbFileDecryptPassword.Location = new System.Drawing.Point(321, 292);
            this.TbFileDecryptPassword.Name = "TbFileDecryptPassword";
            this.TbFileDecryptPassword.PasswordChar = '*';
            this.TbFileDecryptPassword.Size = new System.Drawing.Size(100, 21);
            this.TbFileDecryptPassword.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "密码：";
            // 
            // CbFileDecryptDelete
            // 
            this.CbFileDecryptDelete.AutoSize = true;
            this.CbFileDecryptDelete.Location = new System.Drawing.Point(445, 294);
            this.CbFileDecryptDelete.Name = "CbFileDecryptDelete";
            this.CbFileDecryptDelete.Size = new System.Drawing.Size(120, 16);
            this.CbFileDecryptDelete.TabIndex = 33;
            this.CbFileDecryptDelete.Text = "解密后删除源文件";
            this.CbFileDecryptDelete.UseVisualStyleBackColor = true;
            // 
            // BtFileDecryptAdds
            // 
            this.BtFileDecryptAdds.Location = new System.Drawing.Point(88, 291);
            this.BtFileDecryptAdds.Name = "BtFileDecryptAdds";
            this.BtFileDecryptAdds.Size = new System.Drawing.Size(75, 23);
            this.BtFileDecryptAdds.TabIndex = 32;
            this.BtFileDecryptAdds.Text = "批量导入";
            this.BtFileDecryptAdds.UseVisualStyleBackColor = true;
            this.BtFileDecryptAdds.Click += new System.EventHandler(this.BtFileDecryptAdds_Click);
            // 
            // BtFileDecryptAdd
            // 
            this.BtFileDecryptAdd.Location = new System.Drawing.Point(5, 291);
            this.BtFileDecryptAdd.Name = "BtFileDecryptAdd";
            this.BtFileDecryptAdd.Size = new System.Drawing.Size(75, 23);
            this.BtFileDecryptAdd.TabIndex = 31;
            this.BtFileDecryptAdd.Text = "添加文件";
            this.BtFileDecryptAdd.UseVisualStyleBackColor = true;
            this.BtFileDecryptAdd.Click += new System.EventHandler(this.BtFileDecryptAdd_Click);
            // 
            // BtFileDecrypt
            // 
            this.BtFileDecrypt.Location = new System.Drawing.Point(565, 291);
            this.BtFileDecrypt.Name = "BtFileDecrypt";
            this.BtFileDecrypt.Size = new System.Drawing.Size(75, 23);
            this.BtFileDecrypt.TabIndex = 30;
            this.BtFileDecrypt.Text = "全部解密";
            this.BtFileDecrypt.UseVisualStyleBackColor = true;
            this.BtFileDecrypt.Click += new System.EventHandler(this.BtFileDecrypt_Click);
            // 
            // BtFileDecryptClear
            // 
            this.BtFileDecryptClear.Location = new System.Drawing.Point(169, 291);
            this.BtFileDecryptClear.Name = "BtFileDecryptClear";
            this.BtFileDecryptClear.Size = new System.Drawing.Size(75, 23);
            this.BtFileDecryptClear.TabIndex = 36;
            this.BtFileDecryptClear.Text = "清空列表";
            this.BtFileDecryptClear.UseVisualStyleBackColor = true;
            this.BtFileDecryptClear.Click += new System.EventHandler(this.BtFileDecryptClear_Click);
            // 
            // FileDecryptPartial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtFileDecryptClear);
            this.Controls.Add(this.DgvFileDecryptList);
            this.Controls.Add(this.TbFileDecryptPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbFileDecryptDelete);
            this.Controls.Add(this.BtFileDecryptAdds);
            this.Controls.Add(this.BtFileDecryptAdd);
            this.Controls.Add(this.BtFileDecrypt);
            this.Name = "FileDecryptPartial";
            this.Size = new System.Drawing.Size(646, 326);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFileDecryptList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvFileDecryptList;
        private System.Windows.Forms.TextBox TbFileDecryptPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CbFileDecryptDelete;
        private System.Windows.Forms.Button BtFileDecryptAdds;
        private System.Windows.Forms.Button BtFileDecryptAdd;
        private System.Windows.Forms.Button BtFileDecrypt;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoFileDecryptName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoFileDecryptStatus;
        private System.Windows.Forms.Button BtFileDecryptClear;
    }
}
