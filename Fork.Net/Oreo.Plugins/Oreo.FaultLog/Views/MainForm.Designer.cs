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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PnMain = new System.Windows.Forms.Panel();
            this.PnBody = new System.Windows.Forms.Panel();
            this.PnBottom = new System.Windows.Forms.Panel();
            this.PnInfo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PnMain.SuspendLayout();
            this.PnBody.SuspendLayout();
            this.PnInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 198);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(600, 186);
            this.dataGridView1.TabIndex = 4;
            // 
            // PnMain
            // 
            this.PnMain.Controls.Add(this.PnBottom);
            this.PnMain.Controls.Add(this.PnBody);
            this.PnMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnMain.Location = new System.Drawing.Point(0, 40);
            this.PnMain.Name = "PnMain";
            this.PnMain.Size = new System.Drawing.Size(600, 410);
            this.PnMain.TabIndex = 5;
            // 
            // PnBody
            // 
            this.PnBody.Controls.Add(this.PnInfo);
            this.PnBody.Controls.Add(this.dataGridView1);
            this.PnBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnBody.Location = new System.Drawing.Point(0, 0);
            this.PnBody.Name = "PnBody";
            this.PnBody.Size = new System.Drawing.Size(600, 384);
            this.PnBody.TabIndex = 5;
            // 
            // PnBottom
            // 
            this.PnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnBottom.Location = new System.Drawing.Point(0, 382);
            this.PnBottom.Name = "PnBottom";
            this.PnBottom.Size = new System.Drawing.Size(600, 28);
            this.PnBottom.TabIndex = 6;
            // 
            // PnInfo
            // 
            this.PnInfo.Controls.Add(this.textBox8);
            this.PnInfo.Controls.Add(this.textBox7);
            this.PnInfo.Controls.Add(this.textBox6);
            this.PnInfo.Controls.Add(this.textBox5);
            this.PnInfo.Controls.Add(this.textBox3);
            this.PnInfo.Controls.Add(this.textBox2);
            this.PnInfo.Controls.Add(this.textBox1);
            this.PnInfo.Controls.Add(this.label8);
            this.PnInfo.Controls.Add(this.label7);
            this.PnInfo.Controls.Add(this.label6);
            this.PnInfo.Controls.Add(this.label5);
            this.PnInfo.Controls.Add(this.label3);
            this.PnInfo.Controls.Add(this.label2);
            this.PnInfo.Controls.Add(this.label1);
            this.PnInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnInfo.Location = new System.Drawing.Point(0, 0);
            this.PnInfo.Name = "PnInfo";
            this.PnInfo.Size = new System.Drawing.Size(600, 199);
            this.PnInfo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部门:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "解决:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "系统:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "备注:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "电话:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "问题:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(209, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(54, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(345, 58);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(225, 68);
            this.textBox3.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(527, 20);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(27, 21);
            this.textBox5.TabIndex = 13;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(54, 144);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(225, 36);
            this.textBox6.TabIndex = 14;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(374, 20);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 21);
            this.textBox7.TabIndex = 15;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(54, 58);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(225, 68);
            this.textBox8.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.PnMain);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PnMain.ResumeLayout(false);
            this.PnBody.ResumeLayout(false);
            this.PnInfo.ResumeLayout(false);
            this.PnInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel PnMain;
        private System.Windows.Forms.Panel PnBottom;
        private System.Windows.Forms.Panel PnBody;
        private System.Windows.Forms.Panel PnInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}