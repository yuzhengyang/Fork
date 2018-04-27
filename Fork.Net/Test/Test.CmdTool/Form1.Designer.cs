namespace Test.CmdTool
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
            this.components = new System.ComponentModel.Container();
            this.BTFindPort = new System.Windows.Forms.Button();
            this.TBPort = new System.Windows.Forms.TextBox();
            this.TBRs = new System.Windows.Forms.TextBox();
            this.BTKillApp = new System.Windows.Forms.Button();
            this.BTStart = new System.Windows.Forms.Button();
            this.TMStatus = new System.Windows.Forms.Timer(this.components);
            this.LBStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTFindPort
            // 
            this.BTFindPort.Location = new System.Drawing.Point(153, 46);
            this.BTFindPort.Name = "BTFindPort";
            this.BTFindPort.Size = new System.Drawing.Size(120, 23);
            this.BTFindPort.TabIndex = 0;
            this.BTFindPort.Text = "查询端口和PID";
            this.BTFindPort.UseVisualStyleBackColor = true;
            this.BTFindPort.Click += new System.EventHandler(this.BTFindPort_Click);
            // 
            // TBPort
            // 
            this.TBPort.Location = new System.Drawing.Point(36, 46);
            this.TBPort.Name = "TBPort";
            this.TBPort.Size = new System.Drawing.Size(100, 21);
            this.TBPort.TabIndex = 1;
            // 
            // TBRs
            // 
            this.TBRs.Location = new System.Drawing.Point(25, 101);
            this.TBRs.Multiline = true;
            this.TBRs.Name = "TBRs";
            this.TBRs.Size = new System.Drawing.Size(631, 253);
            this.TBRs.TabIndex = 2;
            // 
            // BTKillApp
            // 
            this.BTKillApp.Location = new System.Drawing.Point(323, 46);
            this.BTKillApp.Name = "BTKillApp";
            this.BTKillApp.Size = new System.Drawing.Size(75, 23);
            this.BTKillApp.TabIndex = 3;
            this.BTKillApp.Text = "结束进程";
            this.BTKillApp.UseVisualStyleBackColor = true;
            this.BTKillApp.Click += new System.EventHandler(this.BTKillApp_Click);
            // 
            // BTStart
            // 
            this.BTStart.Location = new System.Drawing.Point(493, 46);
            this.BTStart.Name = "BTStart";
            this.BTStart.Size = new System.Drawing.Size(75, 23);
            this.BTStart.TabIndex = 4;
            this.BTStart.Text = "启动服务";
            this.BTStart.UseVisualStyleBackColor = true;
            this.BTStart.Click += new System.EventHandler(this.BTStart_Click);
            // 
            // TMStatus
            // 
            this.TMStatus.Enabled = true;
            this.TMStatus.Interval = 1000;
            this.TMStatus.Tick += new System.EventHandler(this.TMStatus_Tick);
            // 
            // LBStatus
            // 
            this.LBStatus.AutoSize = true;
            this.LBStatus.Location = new System.Drawing.Point(25, 377);
            this.LBStatus.Name = "LBStatus";
            this.LBStatus.Size = new System.Drawing.Size(41, 12);
            this.LBStatus.TabIndex = 5;
            this.LBStatus.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 396);
            this.Controls.Add(this.LBStatus);
            this.Controls.Add(this.BTStart);
            this.Controls.Add(this.BTKillApp);
            this.Controls.Add(this.TBRs);
            this.Controls.Add(this.TBPort);
            this.Controls.Add(this.BTFindPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTFindPort;
        private System.Windows.Forms.TextBox TBPort;
        private System.Windows.Forms.TextBox TBRs;
        private System.Windows.Forms.Button BTKillApp;
        private System.Windows.Forms.Button BTStart;
        private System.Windows.Forms.Timer TMStatus;
        private System.Windows.Forms.Label LBStatus;
    }
}

