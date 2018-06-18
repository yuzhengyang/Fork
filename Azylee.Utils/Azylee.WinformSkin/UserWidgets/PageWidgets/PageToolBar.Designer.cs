namespace Azylee.WinformSkin.UserWidgets.PageWidgets
{
    partial class PageToolBar
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PNMain = new System.Windows.Forms.Panel();
            this.PNNumber = new System.Windows.Forms.Panel();
            this.LBPageDesc = new System.Windows.Forms.Label();
            this.PNPageUp = new System.Windows.Forms.Panel();
            this.PNPageUpOne = new System.Windows.Forms.Panel();
            this.BTPageUpOne = new System.Windows.Forms.Button();
            this.PNPageUpFirst = new System.Windows.Forms.Panel();
            this.BTPageUpFirst = new System.Windows.Forms.Button();
            this.PNPageDown = new System.Windows.Forms.Panel();
            this.PNPageDownOne = new System.Windows.Forms.Panel();
            this.BTPageDownOne = new System.Windows.Forms.Button();
            this.PNPageDownLast = new System.Windows.Forms.Panel();
            this.BTPageDownLast = new System.Windows.Forms.Button();
            this.PNMain.SuspendLayout();
            this.PNNumber.SuspendLayout();
            this.PNPageUp.SuspendLayout();
            this.PNPageUpOne.SuspendLayout();
            this.PNPageUpFirst.SuspendLayout();
            this.PNPageDown.SuspendLayout();
            this.PNPageDownOne.SuspendLayout();
            this.PNPageDownLast.SuspendLayout();
            this.SuspendLayout();
            // 
            // PNMain
            // 
            this.PNMain.Controls.Add(this.PNNumber);
            this.PNMain.Controls.Add(this.PNPageUp);
            this.PNMain.Controls.Add(this.PNPageDown);
            this.PNMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNMain.Location = new System.Drawing.Point(0, 0);
            this.PNMain.Name = "PNMain";
            this.PNMain.Size = new System.Drawing.Size(294, 20);
            this.PNMain.TabIndex = 0;
            // 
            // PNNumber
            // 
            this.PNNumber.Controls.Add(this.LBPageDesc);
            this.PNNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNNumber.Location = new System.Drawing.Point(56, 0);
            this.PNNumber.Name = "PNNumber";
            this.PNNumber.Size = new System.Drawing.Size(182, 20);
            this.PNNumber.TabIndex = 3;
            // 
            // LBPageDesc
            // 
            this.LBPageDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBPageDesc.Location = new System.Drawing.Point(0, 0);
            this.LBPageDesc.Name = "LBPageDesc";
            this.LBPageDesc.Size = new System.Drawing.Size(182, 20);
            this.LBPageDesc.TabIndex = 0;
            this.LBPageDesc.Text = "第 1 页，共 1 页";
            this.LBPageDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PNPageUp
            // 
            this.PNPageUp.Controls.Add(this.PNPageUpOne);
            this.PNPageUp.Controls.Add(this.PNPageUpFirst);
            this.PNPageUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.PNPageUp.Location = new System.Drawing.Point(0, 0);
            this.PNPageUp.Name = "PNPageUp";
            this.PNPageUp.Size = new System.Drawing.Size(56, 20);
            this.PNPageUp.TabIndex = 2;
            // 
            // PNPageUpOne
            // 
            this.PNPageUpOne.Controls.Add(this.BTPageUpOne);
            this.PNPageUpOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNPageUpOne.Location = new System.Drawing.Point(28, 0);
            this.PNPageUpOne.Name = "PNPageUpOne";
            this.PNPageUpOne.Size = new System.Drawing.Size(28, 20);
            this.PNPageUpOne.TabIndex = 6;
            // 
            // BTPageUpOne
            // 
            this.BTPageUpOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTPageUpOne.FlatAppearance.BorderSize = 0;
            this.BTPageUpOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPageUpOne.Location = new System.Drawing.Point(0, 0);
            this.BTPageUpOne.Name = "BTPageUpOne";
            this.BTPageUpOne.Size = new System.Drawing.Size(28, 20);
            this.BTPageUpOne.TabIndex = 2;
            this.BTPageUpOne.Text = "<";
            this.BTPageUpOne.UseVisualStyleBackColor = true;
            this.BTPageUpOne.Click += new System.EventHandler(this.BTPageUpOne_Click);
            // 
            // PNPageUpFirst
            // 
            this.PNPageUpFirst.Controls.Add(this.BTPageUpFirst);
            this.PNPageUpFirst.Dock = System.Windows.Forms.DockStyle.Left;
            this.PNPageUpFirst.Location = new System.Drawing.Point(0, 0);
            this.PNPageUpFirst.Name = "PNPageUpFirst";
            this.PNPageUpFirst.Size = new System.Drawing.Size(28, 20);
            this.PNPageUpFirst.TabIndex = 4;
            // 
            // BTPageUpFirst
            // 
            this.BTPageUpFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTPageUpFirst.FlatAppearance.BorderSize = 0;
            this.BTPageUpFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPageUpFirst.Location = new System.Drawing.Point(0, 0);
            this.BTPageUpFirst.Name = "BTPageUpFirst";
            this.BTPageUpFirst.Size = new System.Drawing.Size(28, 20);
            this.BTPageUpFirst.TabIndex = 1;
            this.BTPageUpFirst.Text = "<<";
            this.BTPageUpFirst.UseVisualStyleBackColor = true;
            this.BTPageUpFirst.Click += new System.EventHandler(this.BTPageUpFirst_Click);
            // 
            // PNPageDown
            // 
            this.PNPageDown.Controls.Add(this.PNPageDownOne);
            this.PNPageDown.Controls.Add(this.PNPageDownLast);
            this.PNPageDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.PNPageDown.Location = new System.Drawing.Point(238, 0);
            this.PNPageDown.Name = "PNPageDown";
            this.PNPageDown.Size = new System.Drawing.Size(56, 20);
            this.PNPageDown.TabIndex = 3;
            // 
            // PNPageDownOne
            // 
            this.PNPageDownOne.Controls.Add(this.BTPageDownOne);
            this.PNPageDownOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNPageDownOne.Location = new System.Drawing.Point(0, 0);
            this.PNPageDownOne.Name = "PNPageDownOne";
            this.PNPageDownOne.Size = new System.Drawing.Size(28, 20);
            this.PNPageDownOne.TabIndex = 6;
            // 
            // BTPageDownOne
            // 
            this.BTPageDownOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTPageDownOne.FlatAppearance.BorderSize = 0;
            this.BTPageDownOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPageDownOne.Location = new System.Drawing.Point(0, 0);
            this.BTPageDownOne.Name = "BTPageDownOne";
            this.BTPageDownOne.Size = new System.Drawing.Size(28, 20);
            this.BTPageDownOne.TabIndex = 3;
            this.BTPageDownOne.Text = ">";
            this.BTPageDownOne.UseVisualStyleBackColor = true;
            this.BTPageDownOne.Click += new System.EventHandler(this.BTPageDownOne_Click);
            // 
            // PNPageDownLast
            // 
            this.PNPageDownLast.Controls.Add(this.BTPageDownLast);
            this.PNPageDownLast.Dock = System.Windows.Forms.DockStyle.Right;
            this.PNPageDownLast.Location = new System.Drawing.Point(28, 0);
            this.PNPageDownLast.Name = "PNPageDownLast";
            this.PNPageDownLast.Size = new System.Drawing.Size(28, 20);
            this.PNPageDownLast.TabIndex = 7;
            // 
            // BTPageDownLast
            // 
            this.BTPageDownLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTPageDownLast.FlatAppearance.BorderSize = 0;
            this.BTPageDownLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTPageDownLast.Location = new System.Drawing.Point(0, 0);
            this.BTPageDownLast.Name = "BTPageDownLast";
            this.BTPageDownLast.Size = new System.Drawing.Size(28, 20);
            this.BTPageDownLast.TabIndex = 4;
            this.BTPageDownLast.Text = ">>";
            this.BTPageDownLast.UseVisualStyleBackColor = true;
            this.BTPageDownLast.Click += new System.EventHandler(this.BTPageDownLast_Click);
            // 
            // PageToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PNMain);
            this.Name = "PageToolBar";
            this.Size = new System.Drawing.Size(294, 20);
            this.Load += new System.EventHandler(this.PageToolBar_Load);
            this.PNMain.ResumeLayout(false);
            this.PNNumber.ResumeLayout(false);
            this.PNPageUp.ResumeLayout(false);
            this.PNPageUpOne.ResumeLayout(false);
            this.PNPageUpFirst.ResumeLayout(false);
            this.PNPageDown.ResumeLayout(false);
            this.PNPageDownOne.ResumeLayout(false);
            this.PNPageDownLast.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNMain;
        private System.Windows.Forms.Panel PNNumber;
        private System.Windows.Forms.Panel PNPageUp;
        private System.Windows.Forms.Panel PNPageUpOne;
        private System.Windows.Forms.Button BTPageUpOne;
        private System.Windows.Forms.Panel PNPageUpFirst;
        private System.Windows.Forms.Button BTPageUpFirst;
        private System.Windows.Forms.Panel PNPageDown;
        private System.Windows.Forms.Panel PNPageDownOne;
        private System.Windows.Forms.Button BTPageDownOne;
        private System.Windows.Forms.Panel PNPageDownLast;
        private System.Windows.Forms.Button BTPageDownLast;
        private System.Windows.Forms.Label LBPageDesc;
    }
}
