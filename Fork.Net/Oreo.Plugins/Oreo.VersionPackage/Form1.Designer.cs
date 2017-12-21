namespace Oreo.VersionPackage
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbReleasePath = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbNecessary = new System.Windows.Forms.CheckBox();
            this.rbFtpMode = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbHttpUrl = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFtpIp = new System.Windows.Forms.TextBox();
            this.tbFtpAccount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbFtpPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbFtpFile = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label6 = new System.Windows.Forms.Label();
            this.rbHttpMode = new System.Windows.Forms.RadioButton();
            this.btPackage = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbVersion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbReleasePath);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cbNecessary);
            this.groupBox2.Location = new System.Drawing.Point(12, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 141);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基础信息";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "版本号：";
            // 
            // tbVersion
            // 
            this.tbVersion.Location = new System.Drawing.Point(114, 20);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(126, 21);
            this.tbVersion.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "必要升级：";
            // 
            // tbReleasePath
            // 
            this.tbReleasePath.Location = new System.Drawing.Point(114, 52);
            this.tbReleasePath.Name = "tbReleasePath";
            this.tbReleasePath.Size = new System.Drawing.Size(126, 21);
            this.tbReleasePath.TabIndex = 27;
            this.tbReleasePath.Text = "|AppRoot|";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "ReleasePath：";
            // 
            // cbNecessary
            // 
            this.cbNecessary.AutoSize = true;
            this.cbNecessary.Checked = true;
            this.cbNecessary.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNecessary.Location = new System.Drawing.Point(114, 90);
            this.cbNecessary.Name = "cbNecessary";
            this.cbNecessary.Size = new System.Drawing.Size(48, 16);
            this.cbNecessary.TabIndex = 33;
            this.cbNecessary.Text = "必要";
            this.cbNecessary.UseVisualStyleBackColor = true;
            // 
            // rbFtpMode
            // 
            this.rbFtpMode.AutoSize = true;
            this.rbFtpMode.Location = new System.Drawing.Point(171, 28);
            this.rbFtpMode.Name = "rbFtpMode";
            this.rbFtpMode.Size = new System.Drawing.Size(41, 16);
            this.rbFtpMode.TabIndex = 44;
            this.rbFtpMode.Text = "FTP";
            this.rbFtpMode.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbAuthor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDesc);
            this.groupBox1.Location = new System.Drawing.Point(308, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 141);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "描述信息";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "作者：";
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(80, 46);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(179, 21);
            this.tbAuthor.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "名称：";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(80, 20);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(179, 21);
            this.tbName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "描述：";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(80, 72);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(179, 48);
            this.tbDesc.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbHttpUrl);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(512, 129);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "HTTP 下载设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbHttpUrl
            // 
            this.tbHttpUrl.Location = new System.Drawing.Point(116, 21);
            this.tbHttpUrl.Name = "tbHttpUrl";
            this.tbHttpUrl.Size = new System.Drawing.Size(281, 21);
            this.tbHttpUrl.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "Http 文件链接：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbFtpIp);
            this.tabPage2.Controls.Add(this.tbFtpAccount);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tbFtpPassword);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tbFtpFile);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(512, 129);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FTP 下载设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "FtpIp：";
            // 
            // tbFtpIp
            // 
            this.tbFtpIp.Location = new System.Drawing.Point(113, 21);
            this.tbFtpIp.Name = "tbFtpIp";
            this.tbFtpIp.Size = new System.Drawing.Size(126, 21);
            this.tbFtpIp.TabIndex = 15;
            // 
            // tbFtpAccount
            // 
            this.tbFtpAccount.Location = new System.Drawing.Point(366, 21);
            this.tbFtpAccount.Name = "tbFtpAccount";
            this.tbFtpAccount.Size = new System.Drawing.Size(126, 21);
            this.tbFtpAccount.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(267, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "Ftp 账号：";
            // 
            // tbFtpPassword
            // 
            this.tbFtpPassword.Location = new System.Drawing.Point(366, 60);
            this.tbFtpPassword.Name = "tbFtpPassword";
            this.tbFtpPassword.Size = new System.Drawing.Size(126, 21);
            this.tbFtpPassword.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(267, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "Ftp 密码：";
            // 
            // tbFtpFile
            // 
            this.tbFtpFile.Location = new System.Drawing.Point(113, 60);
            this.tbFtpFile.Name = "tbFtpFile";
            this.tbFtpFile.Size = new System.Drawing.Size(126, 21);
            this.tbFtpFile.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "Ftp 文件路径：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 61);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 155);
            this.tabControl1.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "下载模式：";
            // 
            // rbHttpMode
            // 
            this.rbHttpMode.AutoSize = true;
            this.rbHttpMode.Checked = true;
            this.rbHttpMode.Location = new System.Drawing.Point(101, 28);
            this.rbHttpMode.Name = "rbHttpMode";
            this.rbHttpMode.Size = new System.Drawing.Size(47, 16);
            this.rbHttpMode.TabIndex = 45;
            this.rbHttpMode.TabStop = true;
            this.rbHttpMode.Text = "HTTP";
            this.rbHttpMode.UseVisualStyleBackColor = true;
            // 
            // btPackage
            // 
            this.btPackage.Location = new System.Drawing.Point(512, 460);
            this.btPackage.Name = "btPackage";
            this.btPackage.Size = new System.Drawing.Size(75, 23);
            this.btPackage.TabIndex = 39;
            this.btPackage.Text = "打包";
            this.btPackage.UseVisualStyleBackColor = true;
            this.btPackage.Click += new System.EventHandler(this.btPackage_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.rbHttpMode);
            this.groupBox3.Controls.Add(this.rbFtpMode);
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Location = new System.Drawing.Point(12, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 236);
            this.groupBox3.TabIndex = 47;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "下载信息";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(126, 12);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(441, 21);
            this.tbPath.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 49;
            this.label7.Text = "文件夹路径：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 495);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btPackage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbReleasePath;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cbNecessary;
        private System.Windows.Forms.RadioButton rbFtpMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tbHttpUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbFtpIp;
        private System.Windows.Forms.TextBox tbFtpAccount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbFtpPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbFtpFile;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbHttpMode;
        private System.Windows.Forms.Button btPackage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Label label7;
    }
}

