namespace Oreo.FileMan.Views
{
    partial class FileRestoreForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtClose = new System.Windows.Forms.Button();
            this.DgvFiles = new System.Windows.Forms.DataGridView();
            this.DgvFilesVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFilesLastWriteTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFilesSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LbFileName = new System.Windows.Forms.Label();
            this.LbPath = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LbVersion = new System.Windows.Forms.Label();
            this.BtRestoreToOld = new System.Windows.Forms.Button();
            this.BtRestoreToNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TtLabel = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFiles)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtClose
            // 
            this.BtClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtClose.FlatAppearance.BorderSize = 0;
            this.BtClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtClose.ForeColor = System.Drawing.Color.White;
            this.BtClose.Location = new System.Drawing.Point(384, 4);
            this.BtClose.Name = "BtClose";
            this.BtClose.Size = new System.Drawing.Size(30, 23);
            this.BtClose.TabIndex = 20;
            this.BtClose.Text = "X";
            this.BtClose.UseVisualStyleBackColor = true;
            this.BtClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // DgvFiles
            // 
            this.DgvFiles.AllowUserToAddRows = false;
            this.DgvFiles.AllowUserToDeleteRows = false;
            this.DgvFiles.AllowUserToResizeColumns = false;
            this.DgvFiles.AllowUserToResizeRows = false;
            this.DgvFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvFiles.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFiles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvFilesVersion,
            this.DgvFilesLastWriteTime,
            this.DgvFilesSize});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvFiles.DefaultCellStyle = dataGridViewCellStyle5;
            this.DgvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvFiles.GridColor = System.Drawing.Color.Silver;
            this.DgvFiles.Location = new System.Drawing.Point(0, 0);
            this.DgvFiles.Name = "DgvFiles";
            this.DgvFiles.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFiles.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvFiles.RowHeadersVisible = false;
            this.DgvFiles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvFiles.RowTemplate.Height = 23;
            this.DgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvFiles.Size = new System.Drawing.Size(417, 207);
            this.DgvFiles.TabIndex = 21;
            // 
            // DgvFilesVersion
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvFilesVersion.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvFilesVersion.FillWeight = 50F;
            this.DgvFilesVersion.HeaderText = "版本";
            this.DgvFilesVersion.Name = "DgvFilesVersion";
            this.DgvFilesVersion.ReadOnly = true;
            // 
            // DgvFilesLastWriteTime
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvFilesLastWriteTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvFilesLastWriteTime.HeaderText = "最后修改时间";
            this.DgvFilesLastWriteTime.Name = "DgvFilesLastWriteTime";
            this.DgvFilesLastWriteTime.ReadOnly = true;
            this.DgvFilesLastWriteTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DgvFilesSize
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DgvFilesSize.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvFilesSize.FillWeight = 80F;
            this.DgvFilesSize.HeaderText = "文件大小";
            this.DgvFilesSize.Name = "DgvFilesSize";
            this.DgvFilesSize.ReadOnly = true;
            this.DgvFilesSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LbFileName
            // 
            this.LbFileName.ForeColor = System.Drawing.Color.White;
            this.LbFileName.Location = new System.Drawing.Point(90, 30);
            this.LbFileName.Name = "LbFileName";
            this.LbFileName.Size = new System.Drawing.Size(244, 12);
            this.LbFileName.TabIndex = 22;
            this.LbFileName.Text = "文件名";
            // 
            // LbPath
            // 
            this.LbPath.ForeColor = System.Drawing.Color.White;
            this.LbPath.Location = new System.Drawing.Point(90, 50);
            this.LbPath.Name = "LbPath";
            this.LbPath.Size = new System.Drawing.Size(244, 30);
            this.LbPath.TabIndex = 23;
            this.LbPath.Text = "路径\r\n路径";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "文件名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "路径：";
            // 
            // LbVersion
            // 
            this.LbVersion.AutoSize = true;
            this.LbVersion.ForeColor = System.Drawing.Color.White;
            this.LbVersion.Location = new System.Drawing.Point(362, 65);
            this.LbVersion.Name = "LbVersion";
            this.LbVersion.Size = new System.Drawing.Size(47, 12);
            this.LbVersion.TabIndex = 26;
            this.LbVersion.Text = "共 - 版";
            // 
            // BtRestoreToOld
            // 
            this.BtRestoreToOld.Location = new System.Drawing.Point(234, 11);
            this.BtRestoreToOld.Name = "BtRestoreToOld";
            this.BtRestoreToOld.Size = new System.Drawing.Size(150, 23);
            this.BtRestoreToOld.TabIndex = 28;
            this.BtRestoreToOld.Text = "还原到原始目录";
            this.BtRestoreToOld.UseVisualStyleBackColor = true;
            this.BtRestoreToOld.Click += new System.EventHandler(this.BtRestoreToOld_Click);
            // 
            // BtRestoreToNew
            // 
            this.BtRestoreToNew.Location = new System.Drawing.Point(32, 11);
            this.BtRestoreToNew.Name = "BtRestoreToNew";
            this.BtRestoreToNew.Size = new System.Drawing.Size(150, 23);
            this.BtRestoreToNew.TabIndex = 29;
            this.BtRestoreToNew.Text = "还原到指定目录...";
            this.BtRestoreToNew.UseVisualStyleBackColor = true;
            this.BtRestoreToNew.Click += new System.EventHandler(this.BtRestoreToNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtRestoreToOld);
            this.panel1.Controls.Add(this.BtRestoreToNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 288);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 47);
            this.panel1.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DgvFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 207);
            this.panel2.TabIndex = 31;
            // 
            // FileRestoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.CancelButton = this.BtClose;
            this.ClientSize = new System.Drawing.Size(417, 335);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LbVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbPath);
            this.Controls.Add(this.LbFileName);
            this.Controls.Add(this.BtClose);
            this.Name = "FileRestoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FileRestoreForm";
            this.Load += new System.EventHandler(this.FileRestoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFiles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtClose;
        private System.Windows.Forms.DataGridView DgvFiles;
        private System.Windows.Forms.Label LbFileName;
        private System.Windows.Forms.Label LbPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LbVersion;
        private System.Windows.Forms.Button BtRestoreToOld;
        private System.Windows.Forms.Button BtRestoreToNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFilesVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFilesLastWriteTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFilesSize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip TtLabel;
    }
}