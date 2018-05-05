namespace Oreo.BigBirdDeployer.Views
{
    partial class SettingsForm
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
            this.BTSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBPublishStorage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBNewStorage = new System.Windows.Forms.TextBox();
            this.BTCancel = new System.Windows.Forms.Button();
            this.LBDesc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTSave
            // 
            this.BTSave.Location = new System.Drawing.Point(393, 254);
            this.BTSave.Name = "BTSave";
            this.BTSave.Size = new System.Drawing.Size(75, 23);
            this.BTSave.TabIndex = 0;
            this.BTSave.Text = "保存";
            this.BTSave.UseVisualStyleBackColor = true;
            this.BTSave.Click += new System.EventHandler(this.BTSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "发布资料库路径";
            // 
            // TBPublish
            // 
            this.TBPublishStorage.Location = new System.Drawing.Point(154, 39);
            this.TBPublishStorage.Name = "TBPublish";
            this.TBPublishStorage.Size = new System.Drawing.Size(235, 21);
            this.TBPublishStorage.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "新增资料库路径";
            // 
            // TBNew
            // 
            this.TBNewStorage.Location = new System.Drawing.Point(154, 94);
            this.TBNewStorage.Name = "TBNew";
            this.TBNewStorage.Size = new System.Drawing.Size(235, 21);
            this.TBNewStorage.TabIndex = 4;
            // 
            // BTCancel
            // 
            this.BTCancel.Location = new System.Drawing.Point(525, 254);
            this.BTCancel.Name = "BTCancel";
            this.BTCancel.Size = new System.Drawing.Size(75, 23);
            this.BTCancel.TabIndex = 5;
            this.BTCancel.Text = "取消";
            this.BTCancel.UseVisualStyleBackColor = true;
            this.BTCancel.Click += new System.EventHandler(this.BTCancel_Click);
            // 
            // LBDesc
            // 
            this.LBDesc.AutoSize = true;
            this.LBDesc.Location = new System.Drawing.Point(35, 180);
            this.LBDesc.Name = "LBDesc";
            this.LBDesc.Size = new System.Drawing.Size(77, 12);
            this.LBDesc.TabIndex = 14;
            this.LBDesc.Text = "执行结果描述";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(403, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "默认为程序目录下 Storage\\Publish";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(403, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "默认为程序目录下 Storage\\New";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 305);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LBDesc);
            this.Controls.Add(this.BTCancel);
            this.Controls.Add(this.TBNewStorage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBPublishStorage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBPublishStorage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBNewStorage;
        private System.Windows.Forms.Button BTCancel;
        private System.Windows.Forms.Label LBDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}