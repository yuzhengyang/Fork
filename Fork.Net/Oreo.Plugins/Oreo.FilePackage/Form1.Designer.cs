namespace Oreo.FilePackage
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
            this.BTPack = new System.Windows.Forms.Button();
            this.TBPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BTPack
            // 
            this.BTPack.Location = new System.Drawing.Point(402, 13);
            this.BTPack.Name = "BTPack";
            this.BTPack.Size = new System.Drawing.Size(75, 23);
            this.BTPack.TabIndex = 0;
            this.BTPack.Text = "打包";
            this.BTPack.UseVisualStyleBackColor = true;
            this.BTPack.Click += new System.EventHandler(this.BTPack_Click);
            // 
            // TBPath
            // 
            this.TBPath.Location = new System.Drawing.Point(13, 13);
            this.TBPath.Name = "TBPath";
            this.TBPath.Size = new System.Drawing.Size(358, 21);
            this.TBPath.TabIndex = 1;
            this.TBPath.TextChanged += new System.EventHandler(this.TBPath_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 182);
            this.Controls.Add(this.TBPath);
            this.Controls.Add(this.BTPack);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTPack;
        private System.Windows.Forms.TextBox TBPath;
    }
}

