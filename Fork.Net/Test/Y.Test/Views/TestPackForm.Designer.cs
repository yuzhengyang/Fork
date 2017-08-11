namespace Y.Test.Views
{
    partial class TestPackForm
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
            this.BTPack = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.TBFrom = new System.Windows.Forms.TextBox();
            this.TBTo = new System.Windows.Forms.TextBox();
            this.BTUnpack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTPack
            // 
            this.BTPack.Location = new System.Drawing.Point(263, 235);
            this.BTPack.Name = "BTPack";
            this.BTPack.Size = new System.Drawing.Size(75, 23);
            this.BTPack.TabIndex = 0;
            this.BTPack.Text = "Pack";
            this.BTPack.UseVisualStyleBackColor = true;
            this.BTPack.Click += new System.EventHandler(this.BTPack_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 150);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(454, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // TBFrom
            // 
            this.TBFrom.Location = new System.Drawing.Point(15, 45);
            this.TBFrom.Name = "TBFrom";
            this.TBFrom.Size = new System.Drawing.Size(452, 21);
            this.TBFrom.TabIndex = 3;
            this.TBFrom.Text = "D:\\Temp\\测试打包\\bag1.bag";
            // 
            // TBTo
            // 
            this.TBTo.Location = new System.Drawing.Point(15, 87);
            this.TBTo.Name = "TBTo";
            this.TBTo.Size = new System.Drawing.Size(452, 21);
            this.TBTo.TabIndex = 4;
            this.TBTo.Text = "D:\\Temp\\测试打包\\unpack";
            // 
            // BTUnpack
            // 
            this.BTUnpack.Location = new System.Drawing.Point(391, 235);
            this.BTUnpack.Name = "BTUnpack";
            this.BTUnpack.Size = new System.Drawing.Size(75, 23);
            this.BTUnpack.TabIndex = 5;
            this.BTUnpack.Text = "Unpack";
            this.BTUnpack.UseVisualStyleBackColor = true;
            this.BTUnpack.Click += new System.EventHandler(this.BTUnpack_Click);
            // 
            // TestPackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 270);
            this.Controls.Add(this.BTUnpack);
            this.Controls.Add(this.TBTo);
            this.Controls.Add(this.TBFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BTPack);
            this.Name = "TestPackForm";
            this.Text = "TestPackForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTPack;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBFrom;
        private System.Windows.Forms.TextBox TBTo;
        private System.Windows.Forms.Button BTUnpack;
    }
}