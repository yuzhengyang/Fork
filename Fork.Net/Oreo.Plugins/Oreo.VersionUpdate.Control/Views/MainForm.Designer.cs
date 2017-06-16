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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LbPluginName = new System.Windows.Forms.Label();
            this.LbUpdateDetail = new System.Windows.Forms.Label();
            this.LbCodeName = new System.Windows.Forms.Label();
            this.NiMini = new System.Windows.Forms.NotifyIcon(this.components);
            this.LbProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LbPluginName
            // 
            this.LbPluginName.BackColor = System.Drawing.Color.Transparent;
            this.LbPluginName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LbPluginName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbPluginName.ForeColor = System.Drawing.Color.White;
            this.LbPluginName.Location = new System.Drawing.Point(48, 100);
            this.LbPluginName.Name = "LbPluginName";
            this.LbPluginName.Size = new System.Drawing.Size(262, 17);
            this.LbPluginName.TabIndex = 5;
            this.LbPluginName.Text = "插件名称";
            this.LbPluginName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LbPluginName.Click += new System.EventHandler(this.LbPluginName_Click);
            // 
            // LbUpdateDetail
            // 
            this.LbUpdateDetail.BackColor = System.Drawing.Color.Transparent;
            this.LbUpdateDetail.ForeColor = System.Drawing.Color.White;
            this.LbUpdateDetail.Location = new System.Drawing.Point(85, 231);
            this.LbUpdateDetail.Name = "LbUpdateDetail";
            this.LbUpdateDetail.Size = new System.Drawing.Size(189, 41);
            this.LbUpdateDetail.TabIndex = 7;
            this.LbUpdateDetail.Text = "准备更新……";
            this.LbUpdateDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbCodeName
            // 
            this.LbCodeName.BackColor = System.Drawing.Color.Transparent;
            this.LbCodeName.ForeColor = System.Drawing.Color.White;
            this.LbCodeName.Location = new System.Drawing.Point(92, 55);
            this.LbCodeName.Name = "LbCodeName";
            this.LbCodeName.Size = new System.Drawing.Size(175, 17);
            this.LbCodeName.TabIndex = 9;
            this.LbCodeName.Text = "扬帆起航";
            this.LbCodeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NiMini
            // 
            this.NiMini.Icon = ((System.Drawing.Icon)(resources.GetObject("NiMini.Icon")));
            this.NiMini.Text = "正在更新……";
            this.NiMini.Visible = true;
            // 
            // LbProgress
            // 
            this.LbProgress.BackColor = System.Drawing.Color.Transparent;
            this.LbProgress.Font = new System.Drawing.Font("宋体", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbProgress.ForeColor = System.Drawing.Color.White;
            this.LbProgress.Location = new System.Drawing.Point(76, 134);
            this.LbProgress.Name = "LbProgress";
            this.LbProgress.Size = new System.Drawing.Size(225, 97);
            this.LbProgress.TabIndex = 11;
            this.LbProgress.Text = "100%";
            this.LbProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(360, 360);
            this.Controls.Add(this.LbProgress);
            this.Controls.Add(this.LbCodeName);
            this.Controls.Add(this.LbUpdateDetail);
            this.Controls.Add(this.LbPluginName);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正在准备升级……";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LbPluginName;
        private System.Windows.Forms.Label LbUpdateDetail;
        private System.Windows.Forms.Label LbCodeName;
        private System.Windows.Forms.NotifyIcon NiMini;
        private System.Windows.Forms.Label LbProgress;
    }
}