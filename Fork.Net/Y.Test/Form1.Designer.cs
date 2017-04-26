namespace Y.Test
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.embedPanel1 = new Y.Skin.YoPanel.EmbedPanel(this.components);
            this.flexiblePanel1 = new Y.Skin.YoPanel.FlexiblePanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.flexiblePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // embedPanel1
            // 
            this.embedPanel1.AppProcess = null;
            this.embedPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.embedPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.embedPanel1.Location = new System.Drawing.Point(314, 0);
            this.embedPanel1.Name = "embedPanel1";
            this.embedPanel1.Size = new System.Drawing.Size(466, 413);
            this.embedPanel1.TabIndex = 2;
            // 
            // flexiblePanel1
            // 
            this.flexiblePanel1.Controls.Add(this.listBox1);
            this.flexiblePanel1.Controls.Add(this.label1);
            this.flexiblePanel1.Controls.Add(this.button1);
            this.flexiblePanel1.Location = new System.Drawing.Point(12, 12);
            this.flexiblePanel1.Name = "flexiblePanel1";
            this.flexiblePanel1.Size = new System.Drawing.Size(172, 369);
            this.flexiblePanel1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(17, 200);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 88);
            this.listBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 413);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.embedPanel1);
            this.Controls.Add(this.flexiblePanel1);
            this.Name = "Form1";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flexiblePanel1.ResumeLayout(false);
            this.flexiblePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Skin.YoPanel.FlexiblePanel flexiblePanel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private Skin.YoPanel.EmbedPanel embedPanel1;
        private System.Windows.Forms.Button button2;
    }
}

