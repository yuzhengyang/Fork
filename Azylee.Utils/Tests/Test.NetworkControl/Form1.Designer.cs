namespace Test.NetworkControl
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
            this.BtnEnable = new System.Windows.Forms.Button();
            this.LbxNetworkList = new System.Windows.Forms.ListBox();
            this.BtnDisable = new System.Windows.Forms.Button();
            this.LbResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnTest = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnEnable
            // 
            this.BtnEnable.Location = new System.Drawing.Point(312, 12);
            this.BtnEnable.Name = "BtnEnable";
            this.BtnEnable.Size = new System.Drawing.Size(75, 23);
            this.BtnEnable.TabIndex = 0;
            this.BtnEnable.Text = "启用";
            this.BtnEnable.UseVisualStyleBackColor = true;
            this.BtnEnable.Click += new System.EventHandler(this.BtnEnable_Click);
            // 
            // LbxNetworkList
            // 
            this.LbxNetworkList.FormattingEnabled = true;
            this.LbxNetworkList.ItemHeight = 12;
            this.LbxNetworkList.Location = new System.Drawing.Point(12, 12);
            this.LbxNetworkList.Name = "LbxNetworkList";
            this.LbxNetworkList.Size = new System.Drawing.Size(274, 232);
            this.LbxNetworkList.TabIndex = 1;
            // 
            // BtnDisable
            // 
            this.BtnDisable.Location = new System.Drawing.Point(312, 41);
            this.BtnDisable.Name = "BtnDisable";
            this.BtnDisable.Size = new System.Drawing.Size(75, 23);
            this.BtnDisable.TabIndex = 2;
            this.BtnDisable.Text = "禁用";
            this.BtnDisable.UseVisualStyleBackColor = true;
            this.BtnDisable.Click += new System.EventHandler(this.BtnDisable_Click);
            // 
            // LbResult
            // 
            this.LbResult.AutoSize = true;
            this.LbResult.Location = new System.Drawing.Point(73, 259);
            this.LbResult.Name = "LbResult";
            this.LbResult.Size = new System.Drawing.Size(41, 12);
            this.LbResult.TabIndex = 4;
            this.LbResult.Text = "------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "输出：";
            // 
            // BtnTest
            // 
            this.BtnTest.Location = new System.Drawing.Point(312, 221);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(75, 23);
            this.BtnTest.TabIndex = 6;
            this.BtnTest.Text = "测试";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(312, 92);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(75, 23);
            this.BtnLoad.TabIndex = 7;
            this.BtnLoad.Text = "刷新";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 302);
            this.Controls.Add(this.BtnLoad);
            this.Controls.Add(this.BtnTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LbResult);
            this.Controls.Add(this.BtnDisable);
            this.Controls.Add(this.LbxNetworkList);
            this.Controls.Add(this.BtnEnable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEnable;
        private System.Windows.Forms.ListBox LbxNetworkList;
        private System.Windows.Forms.Button BtnDisable;
        private System.Windows.Forms.Label LbResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnTest;
        private System.Windows.Forms.Button BtnLoad;
    }
}

