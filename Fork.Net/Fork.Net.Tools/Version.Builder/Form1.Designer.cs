namespace Version.Builder
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
            this.LbResult = new System.Windows.Forms.Label();
            this.LbPath = new System.Windows.Forms.Label();
            this.TbPath = new System.Windows.Forms.TextBox();
            this.BtBuild = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LbFtpPath = new System.Windows.Forms.Label();
            this.TbFtpPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LbBeginClose = new System.Windows.Forms.Label();
            this.LbEndRun = new System.Windows.Forms.Label();
            this.TbBeginClose = new System.Windows.Forms.TextBox();
            this.TbEndRun = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LbVersionNumber = new System.Windows.Forms.Label();
            this.TbVersionNumber = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbResult
            // 
            this.LbResult.BackColor = System.Drawing.Color.White;
            this.LbResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LbResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LbResult.Location = new System.Drawing.Point(0, 396);
            this.LbResult.Name = "LbResult";
            this.LbResult.Size = new System.Drawing.Size(515, 21);
            this.LbResult.TabIndex = 7;
            this.LbResult.Text = "就绪";
            this.LbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbPath
            // 
            this.LbPath.AutoSize = true;
            this.LbPath.Location = new System.Drawing.Point(20, 33);
            this.LbPath.Name = "LbPath";
            this.LbPath.Size = new System.Drawing.Size(65, 12);
            this.LbPath.TabIndex = 6;
            this.LbPath.Text = "文件路径：";
            // 
            // TbPath
            // 
            this.TbPath.Location = new System.Drawing.Point(91, 30);
            this.TbPath.Name = "TbPath";
            this.TbPath.Size = new System.Drawing.Size(384, 21);
            this.TbPath.TabIndex = 5;
            this.TbPath.Text = "D:\\FTP\\Application\\1.0";
            // 
            // BtBuild
            // 
            this.BtBuild.Location = new System.Drawing.Point(11, 355);
            this.BtBuild.Name = "BtBuild";
            this.BtBuild.Size = new System.Drawing.Size(490, 23);
            this.BtBuild.TabIndex = 4;
            this.BtBuild.Text = "生成";
            this.BtBuild.UseVisualStyleBackColor = true;
            this.BtBuild.Click += new System.EventHandler(this.BtBuild_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TbFtpPath);
            this.groupBox1.Controls.Add(this.LbFtpPath);
            this.groupBox1.Controls.Add(this.LbPath);
            this.groupBox1.Controls.Add(this.TbPath);
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 107);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件配置";
            // 
            // LbFtpPath
            // 
            this.LbFtpPath.AutoSize = true;
            this.LbFtpPath.Location = new System.Drawing.Point(20, 64);
            this.LbFtpPath.Name = "LbFtpPath";
            this.LbFtpPath.Size = new System.Drawing.Size(59, 12);
            this.LbFtpPath.TabIndex = 7;
            this.LbFtpPath.Text = "FTP目录：";
            // 
            // TbFtpPath
            // 
            this.TbFtpPath.Location = new System.Drawing.Point(91, 61);
            this.TbFtpPath.Name = "TbFtpPath";
            this.TbFtpPath.Size = new System.Drawing.Size(384, 21);
            this.TbFtpPath.TabIndex = 8;
            this.TbFtpPath.Text = "Application\\1.0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TbEndRun);
            this.groupBox2.Controls.Add(this.TbBeginClose);
            this.groupBox2.Controls.Add(this.LbEndRun);
            this.groupBox2.Controls.Add(this.LbBeginClose);
            this.groupBox2.Location = new System.Drawing.Point(12, 228);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(490, 108);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "高级设置";
            // 
            // LbBeginClose
            // 
            this.LbBeginClose.AutoSize = true;
            this.LbBeginClose.Location = new System.Drawing.Point(20, 35);
            this.LbBeginClose.Name = "LbBeginClose";
            this.LbBeginClose.Size = new System.Drawing.Size(101, 12);
            this.LbBeginClose.TabIndex = 0;
            this.LbBeginClose.Text = "更新前关闭进程：";
            // 
            // LbEndRun
            // 
            this.LbEndRun.AutoSize = true;
            this.LbEndRun.Location = new System.Drawing.Point(22, 69);
            this.LbEndRun.Name = "LbEndRun";
            this.LbEndRun.Size = new System.Drawing.Size(101, 12);
            this.LbEndRun.TabIndex = 1;
            this.LbEndRun.Text = "更新后启动程序：";
            // 
            // TbBeginClose
            // 
            this.TbBeginClose.Location = new System.Drawing.Point(127, 32);
            this.TbBeginClose.Name = "TbBeginClose";
            this.TbBeginClose.Size = new System.Drawing.Size(348, 21);
            this.TbBeginClose.TabIndex = 2;
            this.TbBeginClose.Text = "UDefrag;logreader;";
            // 
            // TbEndRun
            // 
            this.TbEndRun.Location = new System.Drawing.Point(127, 66);
            this.TbEndRun.Name = "TbEndRun";
            this.TbEndRun.Size = new System.Drawing.Size(348, 21);
            this.TbEndRun.TabIndex = 3;
            this.TbEndRun.Text = "笔记本键盘设置.EXE;DoubleForm\\磁盘碎片整理.exe";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LbVersionNumber);
            this.groupBox3.Controls.Add(this.TbVersionNumber);
            this.groupBox3.Location = new System.Drawing.Point(13, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 76);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "基础信息";
            // 
            // LbVersionNumber
            // 
            this.LbVersionNumber.AutoSize = true;
            this.LbVersionNumber.Location = new System.Drawing.Point(19, 35);
            this.LbVersionNumber.Name = "LbVersionNumber";
            this.LbVersionNumber.Size = new System.Drawing.Size(53, 12);
            this.LbVersionNumber.TabIndex = 8;
            this.LbVersionNumber.Text = "版本号：";
            // 
            // TbVersionNumber
            // 
            this.TbVersionNumber.Location = new System.Drawing.Point(90, 32);
            this.TbVersionNumber.Name = "TbVersionNumber";
            this.TbVersionNumber.Size = new System.Drawing.Size(384, 21);
            this.TbVersionNumber.TabIndex = 7;
            this.TbVersionNumber.Text = "1.0.0.0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 417);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LbResult);
            this.Controls.Add(this.BtBuild);
            this.Name = "Form1";
            this.Text = "版本文件生成器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbResult;
        private System.Windows.Forms.Label LbPath;
        private System.Windows.Forms.TextBox TbPath;
        private System.Windows.Forms.Button BtBuild;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TbFtpPath;
        private System.Windows.Forms.Label LbFtpPath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LbEndRun;
        private System.Windows.Forms.Label LbBeginClose;
        private System.Windows.Forms.TextBox TbEndRun;
        private System.Windows.Forms.TextBox TbBeginClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LbVersionNumber;
        private System.Windows.Forms.TextBox TbVersionNumber;
    }
}

