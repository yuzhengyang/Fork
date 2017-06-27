namespace Oreo.FaultLog.Views
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
            this.PnMain = new System.Windows.Forms.Panel();
            this.PnBottom = new System.Windows.Forms.Panel();
            this.LbAppVersion = new System.Windows.Forms.Label();
            this.LbAppTitle = new System.Windows.Forms.Label();
            this.BtClose = new System.Windows.Forms.Button();
            this.BtMin = new System.Windows.Forms.Button();
            this.faultLogInputPartial1 = new Oreo.FaultLog.Partials.FaultLogInputPartial();
            this.PnMain.SuspendLayout();
            this.PnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnMain
            // 
            this.PnMain.Controls.Add(this.faultLogInputPartial1);
            this.PnMain.Controls.Add(this.PnBottom);
            this.PnMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnMain.Location = new System.Drawing.Point(0, 58);
            this.PnMain.Name = "PnMain";
            this.PnMain.Size = new System.Drawing.Size(700, 427);
            this.PnMain.TabIndex = 5;
            // 
            // PnBottom
            // 
            this.PnBottom.Controls.Add(this.LbAppVersion);
            this.PnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnBottom.Location = new System.Drawing.Point(0, 400);
            this.PnBottom.Name = "PnBottom";
            this.PnBottom.Size = new System.Drawing.Size(700, 27);
            this.PnBottom.TabIndex = 6;
            // 
            // LbAppVersion
            // 
            this.LbAppVersion.ForeColor = System.Drawing.Color.White;
            this.LbAppVersion.Location = new System.Drawing.Point(553, 4);
            this.LbAppVersion.Name = "LbAppVersion";
            this.LbAppVersion.Size = new System.Drawing.Size(140, 19);
            this.LbAppVersion.TabIndex = 0;
            this.LbAppVersion.Text = "当前版本：99.99.99.99";
            this.LbAppVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LbAppTitle
            // 
            this.LbAppTitle.AutoSize = true;
            this.LbAppTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbAppTitle.ForeColor = System.Drawing.Color.White;
            this.LbAppTitle.Location = new System.Drawing.Point(18, 15);
            this.LbAppTitle.Name = "LbAppTitle";
            this.LbAppTitle.Size = new System.Drawing.Size(68, 21);
            this.LbAppTitle.TabIndex = 1;
            this.LbAppTitle.Text = "Logggg";
            this.LbAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtClose
            // 
            this.BtClose.FlatAppearance.BorderSize = 0;
            this.BtClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtClose.ForeColor = System.Drawing.Color.White;
            this.BtClose.Location = new System.Drawing.Point(667, 9);
            this.BtClose.Name = "BtClose";
            this.BtClose.Size = new System.Drawing.Size(26, 23);
            this.BtClose.TabIndex = 6;
            this.BtClose.Text = "X";
            this.BtClose.UseVisualStyleBackColor = true;
            this.BtClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // BtMin
            // 
            this.BtMin.FlatAppearance.BorderSize = 0;
            this.BtMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtMin.ForeColor = System.Drawing.Color.White;
            this.BtMin.Location = new System.Drawing.Point(639, 9);
            this.BtMin.Name = "BtMin";
            this.BtMin.Size = new System.Drawing.Size(26, 23);
            this.BtMin.TabIndex = 7;
            this.BtMin.Text = "-";
            this.BtMin.UseVisualStyleBackColor = true;
            this.BtMin.Click += new System.EventHandler(this.BtMin_Click);
            // 
            // faultLogInputPartial1
            // 
            this.faultLogInputPartial1.BackColor = System.Drawing.Color.White;
            this.faultLogInputPartial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faultLogInputPartial1.Location = new System.Drawing.Point(0, 0);
            this.faultLogInputPartial1.Name = "faultLogInputPartial1";
            this.faultLogInputPartial1.Size = new System.Drawing.Size(700, 400);
            this.faultLogInputPartial1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(700, 485);
            this.Controls.Add(this.BtMin);
            this.Controls.Add(this.BtClose);
            this.Controls.Add(this.LbAppTitle);
            this.Controls.Add(this.PnMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PnMain.ResumeLayout(false);
            this.PnBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PnMain;
        private System.Windows.Forms.Panel PnBottom;
        private Partials.FaultLogInputPartial faultLogInputPartial1;
        private System.Windows.Forms.Label LbAppVersion;
        private System.Windows.Forms.Label LbAppTitle;
        private System.Windows.Forms.Button BtClose;
        private System.Windows.Forms.Button BtMin;
    }
}