namespace Test.Runrun
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
            this.BTRun = new System.Windows.Forms.Button();
            this.TBUsername = new System.Windows.Forms.TextBox();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.TBApp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BTRun
            // 
            this.BTRun.Location = new System.Drawing.Point(263, 14);
            this.BTRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BTRun.Name = "BTRun";
            this.BTRun.Size = new System.Drawing.Size(100, 29);
            this.BTRun.TabIndex = 0;
            this.BTRun.Text = "运行";
            this.BTRun.UseVisualStyleBackColor = true;
            this.BTRun.Click += new System.EventHandler(this.BTRun_Click);
            // 
            // TBUsername
            // 
            this.TBUsername.Location = new System.Drawing.Point(17, 16);
            this.TBUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBUsername.Name = "TBUsername";
            this.TBUsername.Size = new System.Drawing.Size(132, 25);
            this.TBUsername.TabIndex = 1;
            // 
            // TBPassword
            // 
            this.TBPassword.Location = new System.Drawing.Point(17, 50);
            this.TBPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.Size = new System.Drawing.Size(132, 25);
            this.TBPassword.TabIndex = 2;
            // 
            // TBApp
            // 
            this.TBApp.Location = new System.Drawing.Point(16, 170);
            this.TBApp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TBApp.Multiline = true;
            this.TBApp.Name = "TBApp";
            this.TBApp.Size = new System.Drawing.Size(345, 124);
            this.TBApp.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 326);
            this.Controls.Add(this.TBApp);
            this.Controls.Add(this.TBPassword);
            this.Controls.Add(this.TBUsername);
            this.Controls.Add(this.BTRun);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTRun;
        private System.Windows.Forms.TextBox TBUsername;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.TextBox TBApp;
    }
}

