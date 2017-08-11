namespace Y.Test.Views
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
            this.ChineseCalendarForm = new System.Windows.Forms.Button();
            this.TestComputerInfoForm = new System.Windows.Forms.Button();
            this.TestUpdateForm = new System.Windows.Forms.Button();
            this.TestPackForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChineseCalendarForm
            // 
            this.ChineseCalendarForm.Location = new System.Drawing.Point(70, 80);
            this.ChineseCalendarForm.Name = "ChineseCalendarForm";
            this.ChineseCalendarForm.Size = new System.Drawing.Size(262, 23);
            this.ChineseCalendarForm.TabIndex = 0;
            this.ChineseCalendarForm.Text = "ChineseCalendarForm";
            this.ChineseCalendarForm.UseVisualStyleBackColor = true;
            this.ChineseCalendarForm.Click += new System.EventHandler(this.ChineseCalendarForm_Click);
            // 
            // TestComputerInfoForm
            // 
            this.TestComputerInfoForm.Location = new System.Drawing.Point(70, 149);
            this.TestComputerInfoForm.Name = "TestComputerInfoForm";
            this.TestComputerInfoForm.Size = new System.Drawing.Size(262, 23);
            this.TestComputerInfoForm.TabIndex = 1;
            this.TestComputerInfoForm.Text = "TestComputerInfoForm";
            this.TestComputerInfoForm.UseVisualStyleBackColor = true;
            this.TestComputerInfoForm.Click += new System.EventHandler(this.TestComputerInfoForm_Click);
            // 
            // TestUpdateForm
            // 
            this.TestUpdateForm.Location = new System.Drawing.Point(70, 206);
            this.TestUpdateForm.Name = "TestUpdateForm";
            this.TestUpdateForm.Size = new System.Drawing.Size(262, 23);
            this.TestUpdateForm.TabIndex = 2;
            this.TestUpdateForm.Text = "TestUpdateForm";
            this.TestUpdateForm.UseVisualStyleBackColor = true;
            this.TestUpdateForm.Click += new System.EventHandler(this.TestUpdateForm_Click);
            // 
            // TestPackForm
            // 
            this.TestPackForm.Location = new System.Drawing.Point(70, 267);
            this.TestPackForm.Name = "TestPackForm";
            this.TestPackForm.Size = new System.Drawing.Size(262, 23);
            this.TestPackForm.TabIndex = 3;
            this.TestPackForm.Text = "TestPackForm";
            this.TestPackForm.UseVisualStyleBackColor = true;
            this.TestPackForm.Click += new System.EventHandler(this.TestPackForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 427);
            this.Controls.Add(this.TestPackForm);
            this.Controls.Add(this.TestUpdateForm);
            this.Controls.Add(this.TestComputerInfoForm);
            this.Controls.Add(this.ChineseCalendarForm);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChineseCalendarForm;
        private System.Windows.Forms.Button TestComputerInfoForm;
        private System.Windows.Forms.Button TestUpdateForm;
        private System.Windows.Forms.Button TestPackForm;
    }
}