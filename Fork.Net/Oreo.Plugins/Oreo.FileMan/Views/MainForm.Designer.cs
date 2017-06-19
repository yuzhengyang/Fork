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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BtFileEncrypt = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.BtFileDecrypt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.imageButton4 = new Y.Controls.Buttons.ImageButton();
            this.imageButton3 = new Y.Controls.Buttons.ImageButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtFileEncrypt
            // 
            this.BtFileEncrypt.Location = new System.Drawing.Point(74, 44);
            this.BtFileEncrypt.Name = "BtFileEncrypt";
            this.BtFileEncrypt.Size = new System.Drawing.Size(75, 23);
            this.BtFileEncrypt.TabIndex = 0;
            this.BtFileEncrypt.Text = "文件加密";
            this.BtFileEncrypt.UseVisualStyleBackColor = true;
            this.BtFileEncrypt.Click += new System.EventHandler(this.BtFileEncrypt_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(74, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "文件夹加密";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(181, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "文件备份";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(74, 102);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "文件保险箱";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // BtFileDecrypt
            // 
            this.BtFileDecrypt.Location = new System.Drawing.Point(181, 44);
            this.BtFileDecrypt.Name = "BtFileDecrypt";
            this.BtFileDecrypt.Size = new System.Drawing.Size(75, 23);
            this.BtFileDecrypt.TabIndex = 4;
            this.BtFileDecrypt.Text = "文件解密";
            this.BtFileDecrypt.UseVisualStyleBackColor = true;
            this.BtFileDecrypt.Click += new System.EventHandler(this.BtFileDecrypt_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(35, 143);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(281, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(163, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // imageButton4
            // 
            this.imageButton4.DefaultImage = ((System.Drawing.Image)(resources.GetObject("imageButton4.DefaultImage")));
            this.imageButton4.Image = ((System.Drawing.Image)(resources.GetObject("imageButton4.Image")));
            this.imageButton4.Location = new System.Drawing.Point(161, 62);
            this.imageButton4.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("imageButton4.MouseDownImage")));
            this.imageButton4.MouseHoverImage = null;
            this.imageButton4.Name = "imageButton4";
            this.imageButton4.Size = new System.Drawing.Size(96, 96);
            this.imageButton4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton4.TabIndex = 12;
            this.imageButton4.TabStop = false;
            this.imageButton4.Click += new System.EventHandler(this.imageButton4_Click);
            // 
            // imageButton3
            // 
            this.imageButton3.DefaultImage = ((System.Drawing.Image)(resources.GetObject("imageButton3.DefaultImage")));
            this.imageButton3.Image = ((System.Drawing.Image)(resources.GetObject("imageButton3.Image")));
            this.imageButton3.Location = new System.Drawing.Point(59, 62);
            this.imageButton3.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("imageButton3.MouseDownImage")));
            this.imageButton3.MouseHoverImage = null;
            this.imageButton3.Name = "imageButton3";
            this.imageButton3.Size = new System.Drawing.Size(96, 96);
            this.imageButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton3.TabIndex = 11;
            this.imageButton3.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-5, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 356);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.imageButton3);
            this.tabPage1.Controls.Add(this.imageButton4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(652, 330);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.BtFileEncrypt);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.BtFileDecrypt);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(652, 330);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(161)))), ((int)(((byte)(213)))));
            this.label2.Location = new System.Drawing.Point(81, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 27);
            this.label2.TabIndex = 14;
            this.label2.Text = "分类";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-5, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 35);
            this.panel1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(161)))), ((int)(((byte)(213)))));
            this.label4.Location = new System.Drawing.Point(372, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 27);
            this.label4.TabIndex = 16;
            this.label4.Text = "备份";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(161)))), ((int)(((byte)(213)))));
            this.label3.Location = new System.Drawing.Point(224, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 27);
            this.label3.TabIndex = 15;
            this.label3.Text = "加密";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtFileEncrypt;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button BtFileDecrypt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private Y.Controls.Buttons.ImageButton imageButton3;
        private Y.Controls.Buttons.ImageButton imageButton4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}