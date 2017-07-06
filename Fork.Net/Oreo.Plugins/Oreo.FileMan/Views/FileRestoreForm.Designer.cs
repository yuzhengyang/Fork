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
            this.BtClose = new System.Windows.Forms.Button();
            this.DgvFiles = new System.Windows.Forms.DataGridView();
            this.DgvFilesLastWriteTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvFilesSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // BtClose
            // 
            this.BtClose.FlatAppearance.BorderSize = 0;
            this.BtClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtClose.ForeColor = System.Drawing.Color.White;
            this.BtClose.Location = new System.Drawing.Point(379, 12);
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
            this.DgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvFilesLastWriteTime,
            this.DgvFilesSize});
            this.DgvFiles.GridColor = System.Drawing.Color.Silver;
            this.DgvFiles.Location = new System.Drawing.Point(36, 54);
            this.DgvFiles.Name = "DgvFiles";
            this.DgvFiles.ReadOnly = true;
            this.DgvFiles.RowHeadersVisible = false;
            this.DgvFiles.RowTemplate.Height = 23;
            this.DgvFiles.Size = new System.Drawing.Size(352, 150);
            this.DgvFiles.TabIndex = 21;
            // 
            // DgvFilesLastWriteTime
            // 
            this.DgvFilesLastWriteTime.HeaderText = "最后修改时间";
            this.DgvFilesLastWriteTime.Name = "DgvFilesLastWriteTime";
            this.DgvFilesLastWriteTime.ReadOnly = true;
            // 
            // DgvFilesSize
            // 
            this.DgvFilesSize.HeaderText = "文件大小";
            this.DgvFilesSize.Name = "DgvFilesSize";
            this.DgvFilesSize.ReadOnly = true;
            // 
            // FileRestoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(421, 282);
            this.Controls.Add(this.DgvFiles);
            this.Controls.Add(this.BtClose);
            this.Name = "FileRestoreForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FileRestoreForm";
            this.Load += new System.EventHandler(this.FileRestoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtClose;
        private System.Windows.Forms.DataGridView DgvFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFilesLastWriteTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvFilesSize;
    }
}