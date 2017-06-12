namespace Oreo.NetMan.Views
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DgProcessDetail = new System.Windows.Forms.DataGridView();
            this.CoIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.CoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoDownload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoUpload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoDownloadCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoUploadCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoConnectionCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgvConnList = new System.Windows.Forms.DataGridView();
            this.DgvConnListIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.DgvConnListProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvConnListProtocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvConnListLocalIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvConnListLocalPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvConnListRemoteIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvConnListRemotePort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvConnListStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgProcessDetail)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConnList)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "下载 / 上传";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(630, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "丢包";
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
            this.DgProcessDetail.Location = new System.Drawing.Point(0, 0);
            this.DgProcessDetail.Name = "DgProcessDetail";
            this.DgProcessDetail.ReadOnly = true;
            this.DgProcessDetail.RowHeadersVisible = false;
            this.DgProcessDetail.RowTemplate.Height = 40;
            this.DgProcessDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgProcessDetail.Size = new System.Drawing.Size(811, 406);
            this.DgProcessDetail.TabIndex = 28;
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
            this.status.Location = new System.Drawing.Point(6, 409);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(534, 42);
            this.status.TabIndex = 29;
            this.status.Text = "信息";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(819, 494);
            this.tabControl1.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DgProcessDetail);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.status);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(811, 468);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgvConnList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(811, 468);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DgvConnList
            // 
            this.DgvConnList.AllowUserToAddRows = false;
            this.DgvConnList.AllowUserToDeleteRows = false;
            this.DgvConnList.AllowUserToResizeColumns = false;
            this.DgvConnList.AllowUserToResizeRows = false;
            this.DgvConnList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvConnList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvConnList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvConnList.ColumnHeadersHeight = 40;
            this.DgvConnList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvConnList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvConnListIcon,
            this.DgvConnListProcess,
            this.DgvConnListProtocol,
            this.DgvConnListLocalIP,
            this.DgvConnListLocalPort,
            this.DgvConnListRemoteIP,
            this.DgvConnListRemotePort,
            this.DgvConnListStatus});
            this.DgvConnList.Location = new System.Drawing.Point(0, 0);
            this.DgvConnList.Name = "DgvConnList";
            this.DgvConnList.ReadOnly = true;
            this.DgvConnList.RowHeadersVisible = false;
            this.DgvConnList.RowTemplate.Height = 40;
            this.DgvConnList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvConnList.Size = new System.Drawing.Size(811, 468);
            this.DgvConnList.TabIndex = 0;
            // 
            // DgvConnListIcon
            // 
            this.DgvConnListIcon.HeaderText = "进程";
            this.DgvConnListIcon.Name = "DgvConnListIcon";
            this.DgvConnListIcon.ReadOnly = true;
            this.DgvConnListIcon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvConnListIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DgvConnListProcess
            // 
            this.DgvConnListProcess.HeaderText = "";
            this.DgvConnListProcess.Name = "DgvConnListProcess";
            this.DgvConnListProcess.ReadOnly = true;
            this.DgvConnListProcess.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DgvConnListProtocol
            // 
            this.DgvConnListProtocol.HeaderText = "协议";
            this.DgvConnListProtocol.Name = "DgvConnListProtocol";
            this.DgvConnListProtocol.ReadOnly = true;
            // 
            // DgvConnListLocalIP
            // 
            this.DgvConnListLocalIP.HeaderText = "本地IP";
            this.DgvConnListLocalIP.Name = "DgvConnListLocalIP";
            this.DgvConnListLocalIP.ReadOnly = true;
            // 
            // DgvConnListLocalPort
            // 
            this.DgvConnListLocalPort.HeaderText = "本地端口";
            this.DgvConnListLocalPort.Name = "DgvConnListLocalPort";
            this.DgvConnListLocalPort.ReadOnly = true;
            // 
            // DgvConnListRemoteIP
            // 
            this.DgvConnListRemoteIP.HeaderText = "目标IP";
            this.DgvConnListRemoteIP.Name = "DgvConnListRemoteIP";
            this.DgvConnListRemoteIP.ReadOnly = true;
            // 
            // DgvConnListRemotePort
            // 
            this.DgvConnListRemotePort.HeaderText = "目标端口";
            this.DgvConnListRemotePort.Name = "DgvConnListRemotePort";
            this.DgvConnListRemotePort.ReadOnly = true;
            // 
            // DgvConnListStatus
            // 
            this.DgvConnListStatus.HeaderText = "状态";
            this.DgvConnListStatus.Name = "DgvConnListStatus";
            this.DgvConnListStatus.ReadOnly = true;
            // 
            // NetDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 497);
            this.Controls.Add(this.tabControl1);
            this.Name = "NetDetailForm";
            this.Text = "NetDetailForm";
            this.Load += new System.EventHandler(this.NetDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgProcessDetail)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvConnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgProcessDetail;
        private System.Windows.Forms.DataGridViewImageColumn CoIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoUpload;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoDownloadCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoUploadCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoConnectionCount;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DgvConnList;
        private System.Windows.Forms.DataGridViewImageColumn DgvConnListIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvConnListProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvConnListProtocol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvConnListLocalIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvConnListLocalPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvConnListRemoteIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvConnListRemotePort;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvConnListStatus;
    }
}