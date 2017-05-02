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
            this.LbTitle = new System.Windows.Forms.Label();
            this.TbPath = new System.Windows.Forms.TextBox();
            this.BtBuild = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbResult
            // 
            this.LbResult.BackColor = System.Drawing.Color.White;
            this.LbResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LbResult.Location = new System.Drawing.Point(23, 132);
            this.LbResult.Name = "LbResult";
            this.LbResult.Size = new System.Drawing.Size(453, 23);
            this.LbResult.TabIndex = 7;
            this.LbResult.Text = "就绪";
            this.LbResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Location = new System.Drawing.Point(21, 19);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(77, 12);
            this.LbTitle.TabIndex = 6;
            this.LbTitle.Text = "请输入路径：";
            // 
            // TbPath
            // 
            this.TbPath.Location = new System.Drawing.Point(23, 47);
            this.TbPath.Name = "TbPath";
            this.TbPath.Size = new System.Drawing.Size(453, 21);
            this.TbPath.TabIndex = 5;
            // 
            // BtBuild
            // 
            this.BtBuild.Location = new System.Drawing.Point(401, 87);
            this.BtBuild.Name = "BtBuild";
            this.BtBuild.Size = new System.Drawing.Size(75, 23);
            this.BtBuild.TabIndex = 4;
            this.BtBuild.Text = "生成";
            this.BtBuild.UseVisualStyleBackColor = true;
            this.BtBuild.Click += new System.EventHandler(this.BtBuild_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 185);
            this.Controls.Add(this.LbResult);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.TbPath);
            this.Controls.Add(this.BtBuild);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbResult;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.TextBox TbPath;
        private System.Windows.Forms.Button BtBuild;
    }
}

