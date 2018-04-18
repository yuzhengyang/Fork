namespace Test.BlackBox
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
            this.BTStartBB = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BTStopBB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTStartBB
            // 
            this.BTStartBB.Location = new System.Drawing.Point(363, 54);
            this.BTStartBB.Name = "BTStartBB";
            this.BTStartBB.Size = new System.Drawing.Size(75, 23);
            this.BTStartBB.TabIndex = 0;
            this.BTStartBB.Text = "启动黑匣子";
            this.BTStartBB.UseVisualStyleBackColor = true;
            this.BTStartBB.Click += new System.EventHandler(this.BTStartBB_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 340);
            this.textBox1.TabIndex = 1;
            // 
            // BTStopBB
            // 
            this.BTStopBB.Location = new System.Drawing.Point(444, 54);
            this.BTStopBB.Name = "BTStopBB";
            this.BTStopBB.Size = new System.Drawing.Size(75, 23);
            this.BTStopBB.TabIndex = 2;
            this.BTStopBB.Text = "停止黑匣子";
            this.BTStopBB.UseVisualStyleBackColor = true;
            this.BTStopBB.Click += new System.EventHandler(this.BTStopBB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 365);
            this.Controls.Add(this.BTStopBB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BTStartBB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTStartBB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BTStopBB;
    }
}

