namespace Azylee.WinformSkin.FormUI.Toast
{
    partial class ToastForm
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
            this.PBIcon = new System.Windows.Forms.PictureBox();
            this.LBTitle = new System.Windows.Forms.Label();
            this.LBText = new System.Windows.Forms.Label();
            this.TMHide = new System.Windows.Forms.Timer(this.components);
            this.TMHideAnim = new System.Windows.Forms.Timer(this.components);
            this.TMShowAnim = new System.Windows.Forms.Timer(this.components);
            this.PNMain = new System.Windows.Forms.Panel();
            this.PNContainer = new System.Windows.Forms.Panel();
            this.PNText = new System.Windows.Forms.Panel();
            this.PNTitle = new System.Windows.Forms.Panel();
            this.PNIcon = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PBIcon)).BeginInit();
            this.PNMain.SuspendLayout();
            this.PNContainer.SuspendLayout();
            this.PNText.SuspendLayout();
            this.PNTitle.SuspendLayout();
            this.PNIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // PBIcon
            // 
            this.PBIcon.BackColor = System.Drawing.Color.Transparent;
            this.PBIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PBIcon.Image = global::Azylee.WinformSkin.Properties.Resources.toast_warning;
            this.PBIcon.Location = new System.Drawing.Point(13, 16);
            this.PBIcon.Name = "PBIcon";
            this.PBIcon.Size = new System.Drawing.Size(42, 41);
            this.PBIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PBIcon.TabIndex = 4;
            this.PBIcon.TabStop = false;
            this.PBIcon.Click += new System.EventHandler(this.PBIcon_Click);
            // 
            // LBTitle
            // 
            this.LBTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBTitle.ForeColor = System.Drawing.Color.White;
            this.LBTitle.Location = new System.Drawing.Point(3, 3);
            this.LBTitle.Name = "LBTitle";
            this.LBTitle.Size = new System.Drawing.Size(288, 20);
            this.LBTitle.TabIndex = 5;
            this.LBTitle.Text = "测试标题测试标题测试标题测试标题";
            this.LBTitle.Click += new System.EventHandler(this.LBTitle_Click);
            // 
            // LBText
            // 
            this.LBText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.LBText.Location = new System.Drawing.Point(3, 3);
            this.LBText.Name = "LBText";
            this.LBText.Size = new System.Drawing.Size(288, 52);
            this.LBText.TabIndex = 6;
            this.LBText.Text = "测试，内容。测试，内容。测试，内容。测试，内容。测试，内容。测试，内容。";
            this.LBText.Click += new System.EventHandler(this.LBText_Click);
            // 
            // TMHide
            // 
            this.TMHide.Tick += new System.EventHandler(this.TMHide_Tick);
            // 
            // TMHideAnim
            // 
            this.TMHideAnim.Interval = 10;
            this.TMHideAnim.Tick += new System.EventHandler(this.TMHideAnim_Tick);
            // 
            // TMShowAnim
            // 
            this.TMShowAnim.Interval = 10;
            this.TMShowAnim.Tick += new System.EventHandler(this.TMShowAnim_Tick);
            // 
            // PNMain
            // 
            this.PNMain.Controls.Add(this.PNContainer);
            this.PNMain.Controls.Add(this.PNIcon);
            this.PNMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNMain.Location = new System.Drawing.Point(0, 0);
            this.PNMain.Name = "PNMain";
            this.PNMain.Padding = new System.Windows.Forms.Padding(3);
            this.PNMain.Size = new System.Drawing.Size(360, 90);
            this.PNMain.TabIndex = 8;
            // 
            // PNContainer
            // 
            this.PNContainer.Controls.Add(this.PNText);
            this.PNContainer.Controls.Add(this.PNTitle);
            this.PNContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNContainer.Location = new System.Drawing.Point(63, 3);
            this.PNContainer.Name = "PNContainer";
            this.PNContainer.Size = new System.Drawing.Size(294, 84);
            this.PNContainer.TabIndex = 10;
            // 
            // PNText
            // 
            this.PNText.Controls.Add(this.LBText);
            this.PNText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNText.Location = new System.Drawing.Point(0, 26);
            this.PNText.Name = "PNText";
            this.PNText.Padding = new System.Windows.Forms.Padding(3);
            this.PNText.Size = new System.Drawing.Size(294, 58);
            this.PNText.TabIndex = 10;
            // 
            // PNTitle
            // 
            this.PNTitle.Controls.Add(this.LBTitle);
            this.PNTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNTitle.Location = new System.Drawing.Point(0, 0);
            this.PNTitle.Name = "PNTitle";
            this.PNTitle.Padding = new System.Windows.Forms.Padding(3);
            this.PNTitle.Size = new System.Drawing.Size(294, 26);
            this.PNTitle.TabIndex = 9;
            // 
            // PNIcon
            // 
            this.PNIcon.Controls.Add(this.PBIcon);
            this.PNIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PNIcon.Location = new System.Drawing.Point(3, 3);
            this.PNIcon.Name = "PNIcon";
            this.PNIcon.Size = new System.Drawing.Size(60, 84);
            this.PNIcon.TabIndex = 9;
            // 
            // ToastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(360, 90);
            this.Controls.Add(this.PNMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToastForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通知";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ToastForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBIcon)).EndInit();
            this.PNMain.ResumeLayout(false);
            this.PNContainer.ResumeLayout(false);
            this.PNText.ResumeLayout(false);
            this.PNTitle.ResumeLayout(false);
            this.PNIcon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBIcon;
        private System.Windows.Forms.Label LBTitle;
        private System.Windows.Forms.Label LBText;
        private System.Windows.Forms.Timer TMHide;
        private System.Windows.Forms.Timer TMHideAnim;
        private System.Windows.Forms.Timer TMShowAnim;
        private System.Windows.Forms.Panel PNMain;
        private System.Windows.Forms.Panel PNIcon;
        private System.Windows.Forms.Panel PNContainer;
        private System.Windows.Forms.Panel PNText;
        private System.Windows.Forms.Panel PNTitle;
    }
}