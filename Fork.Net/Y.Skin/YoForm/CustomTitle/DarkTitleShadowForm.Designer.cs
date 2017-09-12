namespace Y.Skin.YoForm.CustomTitle
{
    partial class DarkTitleShadowForm
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
            this.PNHead = new System.Windows.Forms.Panel();
            this.PNHeadTitle = new System.Windows.Forms.Panel();
            this.LBHeadTitle = new System.Windows.Forms.Label();
            this.PNHeadButton = new System.Windows.Forms.Panel();
            this.BTFormMinBox = new System.Windows.Forms.Button();
            this.BTFormMaxBox = new System.Windows.Forms.Button();
            this.BTFormCloseBox = new System.Windows.Forms.Button();
            this.PNHeadIcon = new System.Windows.Forms.Panel();
            this.PBHeadIcon = new System.Windows.Forms.PictureBox();
            this.PNHead.SuspendLayout();
            this.PNHeadTitle.SuspendLayout();
            this.PNHeadButton.SuspendLayout();
            this.PNHeadIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBHeadIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // PNHead
            // 
            this.PNHead.Controls.Add(this.PNHeadTitle);
            this.PNHead.Controls.Add(this.PNHeadButton);
            this.PNHead.Controls.Add(this.PNHeadIcon);
            this.PNHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.PNHead.Location = new System.Drawing.Point(0, 0);
            this.PNHead.Name = "PNHead";
            this.PNHead.Size = new System.Drawing.Size(1370, 52);
            this.PNHead.TabIndex = 4;
            // 
            // PNHeadTitle
            // 
            this.PNHeadTitle.Controls.Add(this.LBHeadTitle);
            this.PNHeadTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNHeadTitle.Location = new System.Drawing.Point(52, 0);
            this.PNHeadTitle.Name = "PNHeadTitle";
            this.PNHeadTitle.Size = new System.Drawing.Size(1201, 52);
            this.PNHeadTitle.TabIndex = 7;
            // 
            // LBHeadTitle
            // 
            this.LBHeadTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBHeadTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBHeadTitle.ForeColor = System.Drawing.Color.White;
            this.LBHeadTitle.Location = new System.Drawing.Point(0, 0);
            this.LBHeadTitle.Name = "LBHeadTitle";
            this.LBHeadTitle.Size = new System.Drawing.Size(1201, 52);
            this.LBHeadTitle.TabIndex = 0;
            this.LBHeadTitle.Text = "DarkTitleForm";
            this.LBHeadTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBHeadTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LBHeadTitle_MouseMove);
            // 
            // PNHeadButton
            // 
            this.PNHeadButton.Controls.Add(this.BTFormMinBox);
            this.PNHeadButton.Controls.Add(this.BTFormMaxBox);
            this.PNHeadButton.Controls.Add(this.BTFormCloseBox);
            this.PNHeadButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.PNHeadButton.Location = new System.Drawing.Point(1253, 0);
            this.PNHeadButton.Name = "PNHeadButton";
            this.PNHeadButton.Size = new System.Drawing.Size(117, 52);
            this.PNHeadButton.TabIndex = 6;
            // 
            // BTFormMinBox
            // 
            this.BTFormMinBox.FlatAppearance.BorderSize = 0;
            this.BTFormMinBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTFormMinBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTFormMinBox.ForeColor = System.Drawing.Color.White;
            this.BTFormMinBox.Location = new System.Drawing.Point(6, 7);
            this.BTFormMinBox.Name = "BTFormMinBox";
            this.BTFormMinBox.Size = new System.Drawing.Size(32, 26);
            this.BTFormMinBox.TabIndex = 2;
            this.BTFormMinBox.Text = "-";
            this.BTFormMinBox.UseVisualStyleBackColor = true;
            this.BTFormMinBox.Click += new System.EventHandler(this.BTFormMinBox_Click);
            // 
            // BTFormMaxBox
            // 
            this.BTFormMaxBox.FlatAppearance.BorderSize = 0;
            this.BTFormMaxBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTFormMaxBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTFormMaxBox.ForeColor = System.Drawing.Color.White;
            this.BTFormMaxBox.Location = new System.Drawing.Point(44, 7);
            this.BTFormMaxBox.Name = "BTFormMaxBox";
            this.BTFormMaxBox.Size = new System.Drawing.Size(32, 26);
            this.BTFormMaxBox.TabIndex = 1;
            this.BTFormMaxBox.Text = "□";
            this.BTFormMaxBox.UseVisualStyleBackColor = true;
            this.BTFormMaxBox.Click += new System.EventHandler(this.BTFormMaxBox_Click);
            // 
            // BTFormCloseBox
            // 
            this.BTFormCloseBox.FlatAppearance.BorderSize = 0;
            this.BTFormCloseBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTFormCloseBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTFormCloseBox.ForeColor = System.Drawing.Color.White;
            this.BTFormCloseBox.Location = new System.Drawing.Point(82, 7);
            this.BTFormCloseBox.Name = "BTFormCloseBox";
            this.BTFormCloseBox.Size = new System.Drawing.Size(32, 26);
            this.BTFormCloseBox.TabIndex = 0;
            this.BTFormCloseBox.Text = "×";
            this.BTFormCloseBox.UseVisualStyleBackColor = true;
            this.BTFormCloseBox.Click += new System.EventHandler(this.BTFormCloseBox_Click);
            // 
            // PNHeadIcon
            // 
            this.PNHeadIcon.Controls.Add(this.PBHeadIcon);
            this.PNHeadIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.PNHeadIcon.Location = new System.Drawing.Point(0, 0);
            this.PNHeadIcon.Name = "PNHeadIcon";
            this.PNHeadIcon.Size = new System.Drawing.Size(52, 52);
            this.PNHeadIcon.TabIndex = 5;
            // 
            // PBHeadIcon
            // 
            this.PBHeadIcon.BackColor = System.Drawing.Color.Transparent;
            this.PBHeadIcon.Location = new System.Drawing.Point(10, 10);
            this.PBHeadIcon.Name = "PBHeadIcon";
            this.PBHeadIcon.Size = new System.Drawing.Size(32, 32);
            this.PBHeadIcon.TabIndex = 0;
            this.PBHeadIcon.TabStop = false;
            // 
            // DarkTitleShadowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1370, 772);
            this.Controls.Add(this.PNHead);
            this.Name = "DarkTitleShadowForm";
            this.Text = "DarkTitleForm";
            this.Load += new System.EventHandler(this.DarkTitleForm_Load);
            this.SizeChanged += new System.EventHandler(this.DarkTitleShadowForm_SizeChanged);
            this.PNHead.ResumeLayout(false);
            this.PNHeadTitle.ResumeLayout(false);
            this.PNHeadButton.ResumeLayout(false);
            this.PNHeadIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBHeadIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNHead;
        private System.Windows.Forms.Panel PNHeadButton;
        private System.Windows.Forms.Panel PNHeadIcon;
        private System.Windows.Forms.Panel PNHeadTitle;
        private System.Windows.Forms.PictureBox PBHeadIcon;
        private System.Windows.Forms.Button BTFormMinBox;
        private System.Windows.Forms.Button BTFormMaxBox;
        private System.Windows.Forms.Button BTFormCloseBox;
        public System.Windows.Forms.Label LBHeadTitle;
    }
}