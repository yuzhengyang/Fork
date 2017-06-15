namespace Oreo.FileMan.Views
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
            this.BtFileEncrypt = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.BtFileDecrypt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtFileEncrypt
            // 
            this.BtFileEncrypt.Location = new System.Drawing.Point(51, 35);
            this.BtFileEncrypt.Name = "BtFileEncrypt";
            this.BtFileEncrypt.Size = new System.Drawing.Size(75, 23);
            this.BtFileEncrypt.TabIndex = 0;
            this.BtFileEncrypt.Text = "文件加密";
            this.BtFileEncrypt.UseVisualStyleBackColor = true;
            this.BtFileEncrypt.Click += new System.EventHandler(this.BtFileEncrypt_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(51, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "文件夹加密";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(51, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "文件备份";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(51, 201);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "文件保险箱";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // BtFileDecrypt
            // 
            this.BtFileDecrypt.Location = new System.Drawing.Point(158, 35);
            this.BtFileDecrypt.Name = "BtFileDecrypt";
            this.BtFileDecrypt.Size = new System.Drawing.Size(75, 23);
            this.BtFileDecrypt.TabIndex = 4;
            this.BtFileDecrypt.Text = "文件解密";
            this.BtFileDecrypt.UseVisualStyleBackColor = true;
            this.BtFileDecrypt.Click += new System.EventHandler(this.BtFileDecrypt_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtFileDecrypt);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtFileEncrypt);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtFileEncrypt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button BtFileDecrypt;
        private System.Windows.Forms.Button button1;
    }
}