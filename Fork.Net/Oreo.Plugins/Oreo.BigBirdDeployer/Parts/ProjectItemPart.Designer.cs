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
            this.PBLoading = new System.Windows.Forms.PictureBox();
            this.LBDesc = new System.Windows.Forms.Label();
            this.LBCpu = new System.Windows.Forms.Label();
            this.LBRam = new System.Windows.Forms.Label();
            this.TBConsole = new System.Windows.Forms.TextBox();
            this.LBProcessName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // BTStartOrStop
            // 
            this.BTStartOrStop.Location = new System.Drawing.Point(341, 14);
            this.BTStartOrStop.Name = "BTStartOrStop";
            this.BTStartOrStop.Size = new System.Drawing.Size(75, 44);
            this.BTStartOrStop.TabIndex = 0;
            this.BTStartOrStop.Text = "启动/停止";
            this.BTStartOrStop.UseVisualStyleBackColor = true;
            this.BTStartOrStop.Click += new System.EventHandler(this.BTStartOrStop_Click);
            // 
            // BTConfig
            // 
            this.BTConfig.Location = new System.Drawing.Point(427, 14);
            this.BTConfig.Name = "BTConfig";
            this.BTConfig.Size = new System.Drawing.Size(75, 44);
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
            this.LBProjectName.Size = new System.Drawing.Size(195, 44);
            this.LBProjectName.TabIndex = 2;
            this.LBProjectName.Text = "工程名称";
            this.LBProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LBStatus
            // 
            this.LBStatus.BackColor = System.Drawing.Color.MediumTurquoise;
            this.LBStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.LBStatus.ForeColor = System.Drawing.Color.White;
            this.LBStatus.Location = new System.Drawing.Point(195, 0);
            this.LBStatus.Name = "LBStatus";
            this.LBStatus.Size = new System.Drawing.Size(73, 44);
            this.LBStatus.TabIndex = 3;
            this.LBStatus.Text = "状态显示";
            this.LBStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LBProjectName);
            this.panel1.Controls.Add(this.LBStatus);
            this.panel1.Location = new System.Drawing.Point(13, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 44);
            this.panel1.TabIndex = 4;
            // 
            // PBLoading
            // 
            this.PBLoading.Location = new System.Drawing.Point(288, 14);
            this.PBLoading.Name = "PBLoading";
            this.PBLoading.Size = new System.Drawing.Size(47, 44);
            this.PBLoading.TabIndex = 5;
            this.PBLoading.TabStop = false;
            // 
            // LBDesc
            // 
            this.LBDesc.AutoSize = true;
            this.LBDesc.ForeColor = System.Drawing.Color.White;
            this.LBDesc.Location = new System.Drawing.Point(11, 73);
            this.LBDesc.Name = "LBDesc";
            this.LBDesc.Size = new System.Drawing.Size(29, 12);
            this.LBDesc.TabIndex = 7;
            this.LBDesc.Text = "描述";
            // 
            // LBCpu
            // 
            this.LBCpu.AutoSize = true;
            this.LBCpu.ForeColor = System.Drawing.Color.White;
            this.LBCpu.Location = new System.Drawing.Point(305, 73);
            this.LBCpu.Name = "LBCpu";
            this.LBCpu.Size = new System.Drawing.Size(53, 12);
            this.LBCpu.TabIndex = 8;
            this.LBCpu.Text = "CPU：0 %";
            // 
            // LBRam
            // 
            this.LBRam.AutoSize = true;
            this.LBRam.ForeColor = System.Drawing.Color.White;
            this.LBRam.Location = new System.Drawing.Point(387, 73);
            this.LBRam.Name = "LBRam";
            this.LBRam.Size = new System.Drawing.Size(65, 12);
            this.LBRam.TabIndex = 9;
            this.LBRam.Text = "内存：0 MB";
            // 
            // TBConsole
            // 
            this.TBConsole.Location = new System.Drawing.Point(13, 100);
            this.TBConsole.Multiline = true;
            this.TBConsole.Name = "TBConsole";
            this.TBConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBConsole.Size = new System.Drawing.Size(487, 240);
            this.TBConsole.TabIndex = 6;
            // 
            // LBProcessName
            // 
            this.LBProcessName.AutoSize = true;
            this.LBProcessName.ForeColor = System.Drawing.Color.White;
            this.LBProcessName.Location = new System.Drawing.Point(111, 73);
            this.LBProcessName.Name = "LBProcessName";
            this.LBProcessName.Size = new System.Drawing.Size(41, 12);
            this.LBProcessName.TabIndex = 10;
            this.LBProcessName.Text = "进程名";
            // 
            // ProjectItemPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.LBProcessName);
            this.Controls.Add(this.LBRam);
            this.Controls.Add(this.LBCpu);
            this.Controls.Add(this.LBDesc);
            this.Controls.Add(this.TBConsole);
            this.Controls.Add(this.PBLoading);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTConfig);
            this.Controls.Add(this.BTStartOrStop);
            this.Name = "ProjectItemPart";
            this.Size = new System.Drawing.Size(513, 95);
            this.Load += new System.EventHandler(this.ProjectItemPart_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTStartOrStop;
        private System.Windows.Forms.Button BTConfig;
        private System.Windows.Forms.Label LBProjectName;
        private System.Windows.Forms.Label LBStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PBLoading;
        private System.Windows.Forms.Label LBDesc;
        private System.Windows.Forms.Label LBCpu;
        private System.Windows.Forms.Label LBRam;
        private System.Windows.Forms.TextBox TBConsole;
        private System.Windows.Forms.Label LBProcessName;
    }
}
