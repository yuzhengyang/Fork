namespace Oreo.BigBirdDeployer.Parts
{
    partial class ProjectItemPart
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
            this.BTStartOrStop = new System.Windows.Forms.Button();
            this.BTConfig = new System.Windows.Forms.Button();
            this.LBProjectName = new System.Windows.Forms.Label();
            this.LBStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBCpu = new System.Windows.Forms.Label();
            this.LBRam = new System.Windows.Forms.Label();
            this.LBPort = new System.Windows.Forms.Label();
            this.BTAddNew = new System.Windows.Forms.Button();
            this.CBVersion = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTStartOrStop
            // 
            this.BTStartOrStop.Location = new System.Drawing.Point(266, 85);
            this.BTStartOrStop.Name = "BTStartOrStop";
            this.BTStartOrStop.Size = new System.Drawing.Size(47, 23);
            this.BTStartOrStop.TabIndex = 0;
            this.BTStartOrStop.Text = "启动";
            this.BTStartOrStop.UseVisualStyleBackColor = true;
            this.BTStartOrStop.Click += new System.EventHandler(this.BTStartOrStop_Click);
            // 
            // BTConfig
            // 
            this.BTConfig.Location = new System.Drawing.Point(266, 48);
            this.BTConfig.Name = "BTConfig";
            this.BTConfig.Size = new System.Drawing.Size(47, 23);
            this.BTConfig.TabIndex = 1;
            this.BTConfig.Text = "配置";
            this.BTConfig.UseVisualStyleBackColor = true;
            this.BTConfig.Click += new System.EventHandler(this.BTConfig_Click);
            // 
            // LBProjectName
            // 
            this.LBProjectName.BackColor = System.Drawing.Color.SandyBrown;
            this.LBProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBProjectName.ForeColor = System.Drawing.Color.White;
            this.LBProjectName.Location = new System.Drawing.Point(0, 0);
            this.LBProjectName.Name = "LBProjectName";
            this.LBProjectName.Size = new System.Drawing.Size(234, 28);
            this.LBProjectName.TabIndex = 2;
            this.LBProjectName.Text = "工程名称";
            this.LBProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LBStatus
            // 
            this.LBStatus.BackColor = System.Drawing.Color.MediumTurquoise;
            this.LBStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.LBStatus.ForeColor = System.Drawing.Color.White;
            this.LBStatus.Location = new System.Drawing.Point(234, 0);
            this.LBStatus.Name = "LBStatus";
            this.LBStatus.Size = new System.Drawing.Size(67, 28);
            this.LBStatus.TabIndex = 3;
            this.LBStatus.Text = "状态显示";
            this.LBStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LBProjectName);
            this.panel1.Controls.Add(this.LBStatus);
            this.panel1.Location = new System.Drawing.Point(12, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 28);
            this.panel1.TabIndex = 4;
            // 
            // LBCpu
            // 
            this.LBCpu.AutoSize = true;
            this.LBCpu.ForeColor = System.Drawing.Color.White;
            this.LBCpu.Location = new System.Drawing.Point(99, 53);
            this.LBCpu.Name = "LBCpu";
            this.LBCpu.Size = new System.Drawing.Size(65, 12);
            this.LBCpu.TabIndex = 8;
            this.LBCpu.Text = "CPU：100 %";
            // 
            // LBRam
            // 
            this.LBRam.AutoSize = true;
            this.LBRam.ForeColor = System.Drawing.Color.White;
            this.LBRam.Location = new System.Drawing.Point(173, 53);
            this.LBRam.Name = "LBRam";
            this.LBRam.Size = new System.Drawing.Size(83, 12);
            this.LBRam.TabIndex = 9;
            this.LBRam.Text = "内存：9999 MB";
            // 
            // LBPort
            // 
            this.LBPort.AutoSize = true;
            this.LBPort.ForeColor = System.Drawing.Color.White;
            this.LBPort.Location = new System.Drawing.Point(12, 53);
            this.LBPort.Name = "LBPort";
            this.LBPort.Size = new System.Drawing.Size(71, 12);
            this.LBPort.TabIndex = 11;
            this.LBPort.Text = "端口：10000";
            // 
            // BTAddNew
            // 
            this.BTAddNew.Location = new System.Drawing.Point(213, 85);
            this.BTAddNew.Name = "BTAddNew";
            this.BTAddNew.Size = new System.Drawing.Size(47, 23);
            this.BTAddNew.TabIndex = 12;
            this.BTAddNew.Text = "装载";
            this.BTAddNew.UseVisualStyleBackColor = true;
            this.BTAddNew.Click += new System.EventHandler(this.BTAddNew_Click);
            // 
            // CBVersion
            // 
            this.CBVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBVersion.FormattingEnabled = true;
            this.CBVersion.Location = new System.Drawing.Point(14, 87);
            this.CBVersion.Name = "CBVersion";
            this.CBVersion.Size = new System.Drawing.Size(189, 20);
            this.CBVersion.TabIndex = 14;
            this.CBVersion.SelectedIndexChanged += new System.EventHandler(this.CBVersion_SelectedIndexChanged);
            // 
            // ProjectItemPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.CBVersion);
            this.Controls.Add(this.BTAddNew);
            this.Controls.Add(this.LBPort);
            this.Controls.Add(this.LBRam);
            this.Controls.Add(this.LBCpu);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTConfig);
            this.Controls.Add(this.BTStartOrStop);
            this.Name = "ProjectItemPart";
            this.Size = new System.Drawing.Size(325, 123);
            this.Load += new System.EventHandler(this.ProjectItemPart_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTStartOrStop;
        private System.Windows.Forms.Button BTConfig;
        private System.Windows.Forms.Label LBProjectName;
        private System.Windows.Forms.Label LBStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBCpu;
        private System.Windows.Forms.Label LBRam;
        private System.Windows.Forms.Label LBPort;
        private System.Windows.Forms.Button BTAddNew;
        private System.Windows.Forms.ComboBox CBVersion;
    }
}
