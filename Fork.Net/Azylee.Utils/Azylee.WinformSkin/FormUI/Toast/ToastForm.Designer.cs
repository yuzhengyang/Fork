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
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PBIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PBIcon
            // 
            this.PBIcon.BackColor = System.Drawing.Color.Transparent;
            this.PBIcon.Image = global::Azylee.WinformSkin.Properties.Resources.toast_warning;
            this.PBIcon.Location = new System.Drawing.Point(16, 16);
            this.PBIcon.Name = "PBIcon";
            this.PBIcon.Size = new System.Drawing.Size(42, 41);
            this.PBIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBIcon.TabIndex = 4;
            this.PBIcon.TabStop = false;
            this.PBIcon.Click += new System.EventHandler(this.PBIcon_Click);
            // 
            // LBTitle
            // 
            this.LBTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBTitle.ForeColor = System.Drawing.Color.White;
            this.LBTitle.Location = new System.Drawing.Point(68, 7);
            this.LBTitle.Name = "LBTitle";
            this.LBTitle.Size = new System.Drawing.Size(270, 20);
            this.LBTitle.TabIndex = 5;
            this.LBTitle.Text = "测试标题测试标题测试标题测试标题";
            this.LBTitle.Click += new System.EventHandler(this.LBTitle_Click);
            // 
            // LBText
            // 
            this.LBText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.LBText.Location = new System.Drawing.Point(68, 30);
            this.LBText.Name = "LBText";
            this.LBText.Size = new System.Drawing.Size(270, 44);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.PBIcon);
            this.panel1.Controls.Add(this.LBTitle);
            this.panel1.Controls.Add(this.LBText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 80);
            this.panel1.TabIndex = 7;
            // 
            // ToastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(360, 80);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBIcon;
        private System.Windows.Forms.Label LBTitle;
        private System.Windows.Forms.Label LBText;
        private System.Windows.Forms.Timer TMHide;
        private System.Windows.Forms.Timer TMHideAnim;
        private System.Windows.Forms.Timer TMShowAnim;
        private System.Windows.Forms.Panel panel1;
    }
}