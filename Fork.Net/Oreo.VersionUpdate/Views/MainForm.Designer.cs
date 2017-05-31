namespace Oreo.VersionUpdate.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LbVersionNumber = new System.Windows.Forms.Label();
            this.LbPluginName = new System.Windows.Forms.Label();
            this.LbUpdateDetail = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LbCodeName = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "更新插件：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(236, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "新版本号：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbVersionNumber
            // 
            this.LbVersionNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LbVersionNumber.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbVersionNumber.ForeColor = System.Drawing.Color.White;
            this.LbVersionNumber.Location = new System.Drawing.Point(305, 9);
            this.LbVersionNumber.Name = "LbVersionNumber";
            this.LbVersionNumber.Size = new System.Drawing.Size(102, 12);
            this.LbVersionNumber.TabIndex = 4;
            this.LbVersionNumber.Text = "1.0.0.0";
            this.LbVersionNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LbVersionNumber.Click += new System.EventHandler(this.LbVersionNumber_Click);
            // 
            // LbPluginName
            // 
            this.LbPluginName.ForeColor = System.Drawing.Color.White;
            this.LbPluginName.Location = new System.Drawing.Point(81, 32);
            this.LbPluginName.Name = "LbPluginName";
            this.LbPluginName.Size = new System.Drawing.Size(326, 12);
            this.LbPluginName.TabIndex = 5;
            this.LbPluginName.Text = "无";
            this.LbPluginName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbUpdateDetail
            // 
            this.LbUpdateDetail.ForeColor = System.Drawing.Color.White;
            this.LbUpdateDetail.Location = new System.Drawing.Point(14, 93);
            this.LbUpdateDetail.Name = "LbUpdateDetail";
            this.LbUpdateDetail.Size = new System.Drawing.Size(395, 31);
            this.LbUpdateDetail.TabIndex = 7;
            this.LbUpdateDetail.Text = "准备更新……";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "更新代号：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbCodeName
            // 
            this.LbCodeName.ForeColor = System.Drawing.Color.White;
            this.LbCodeName.Location = new System.Drawing.Point(81, 9);
            this.LbCodeName.Name = "LbCodeName";
            this.LbCodeName.Size = new System.Drawing.Size(149, 12);
            this.LbCodeName.TabIndex = 9;
            this.LbCodeName.Text = "扬帆起航";
            this.LbCodeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 61);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(395, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(425, 135);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.LbCodeName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.LbUpdateDetail);
            this.Controls.Add(this.LbPluginName);
            this.Controls.Add(this.LbVersionNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正在准备升级……";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbVersionNumber;
        private System.Windows.Forms.Label LbPluginName;
        private System.Windows.Forms.Label LbUpdateDetail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LbCodeName;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}