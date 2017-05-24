namespace Oreo.PCMonitor.Views
{
    partial class NetDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgProcessDetail = new System.Windows.Forms.DataGridView();
            this.CoIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.CoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoDownload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoUpload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoDownloadCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoUploadCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoConnectionCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgProcessDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // DgProcessDetail
            // 
            this.DgProcessDetail.AllowUserToAddRows = false;
            this.DgProcessDetail.AllowUserToDeleteRows = false;
            this.DgProcessDetail.AllowUserToResizeColumns = false;
            this.DgProcessDetail.AllowUserToResizeRows = false;
            this.DgProcessDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgProcessDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgProcessDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgProcessDetail.ColumnHeadersHeight = 40;
            this.DgProcessDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgProcessDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoIcon,
            this.CoName,
            this.CoDownload,
            this.CoUpload,
            this.CoDownloadCount,
            this.CoUploadCount,
            this.CoConnectionCount});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgProcessDetail.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgProcessDetail.Location = new System.Drawing.Point(11, 81);
            this.DgProcessDetail.Name = "DgProcessDetail";
            this.DgProcessDetail.ReadOnly = true;
            this.DgProcessDetail.RowHeadersVisible = false;
            this.DgProcessDetail.RowTemplate.Height = 40;
            this.DgProcessDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgProcessDetail.Size = new System.Drawing.Size(811, 406);
            this.DgProcessDetail.TabIndex = 24;
            // 
            // CoIcon
            // 
            this.CoIcon.HeaderText = "名称";
            this.CoIcon.Name = "CoIcon";
            this.CoIcon.ReadOnly = true;
            // 
            // CoName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CoName.DefaultCellStyle = dataGridViewCellStyle2;
            this.CoName.HeaderText = "";
            this.CoName.Name = "CoName";
            this.CoName.ReadOnly = true;
            // 
            // CoDownload
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CoDownload.DefaultCellStyle = dataGridViewCellStyle3;
            this.CoDownload.HeaderText = "下载速度";
            this.CoDownload.Name = "CoDownload";
            this.CoDownload.ReadOnly = true;
            // 
            // CoUpload
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CoUpload.DefaultCellStyle = dataGridViewCellStyle4;
            this.CoUpload.HeaderText = "上传速度";
            this.CoUpload.Name = "CoUpload";
            this.CoUpload.ReadOnly = true;
            // 
            // CoDownloadCount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CoDownloadCount.DefaultCellStyle = dataGridViewCellStyle5;
            this.CoDownloadCount.HeaderText = "已下载流量";
            this.CoDownloadCount.Name = "CoDownloadCount";
            this.CoDownloadCount.ReadOnly = true;
            // 
            // CoUploadCount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CoUploadCount.DefaultCellStyle = dataGridViewCellStyle6;
            this.CoUploadCount.HeaderText = "已上传流量";
            this.CoUploadCount.Name = "CoUploadCount";
            this.CoUploadCount.ReadOnly = true;
            // 
            // CoConnectionCount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CoConnectionCount.DefaultCellStyle = dataGridViewCellStyle7;
            this.CoConnectionCount.HeaderText = "连接数";
            this.CoConnectionCount.Name = "CoConnectionCount";
            this.CoConnectionCount.ReadOnly = true;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(14, 506);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(534, 42);
            this.status.TabIndex = 25;
            this.status.Text = "信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(720, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(506, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "label2";
            // 
            // NetDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgProcessDetail);
            this.Controls.Add(this.status);
            this.Name = "NetDetailForm";
            this.Text = "NetDetailForm";
            this.Load += new System.EventHandler(this.NetDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgProcessDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgProcessDetail;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn CoIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoUpload;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoDownloadCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoUploadCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoConnectionCount;
        private System.Windows.Forms.Label label2;
    }
}