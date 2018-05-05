namespace Oreo.BigBirdDeployer.Views
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BTSettings = new System.Windows.Forms.Button();
            this.project1 = new Oreo.BigBirdDeployer.Parts.ProjectItemPart();
            this.project4 = new Oreo.BigBirdDeployer.Parts.ProjectItemPart();
            this.project2 = new Oreo.BigBirdDeployer.Parts.ProjectItemPart();
            this.project3 = new Oreo.BigBirdDeployer.Parts.ProjectItemPart();
            this.project6 = new Oreo.BigBirdDeployer.Parts.ProjectItemPart();
            this.project5 = new Oreo.BigBirdDeployer.Parts.ProjectItemPart();
            this.project7 = new Oreo.BigBirdDeployer.Parts.ProjectItemPart();
            this.project8 = new Oreo.BigBirdDeployer.Parts.ProjectItemPart();
            ((System.ComponentModel.ISupportInitialize)(this.BigIconFormPBHeadIcon)).BeginInit();
            this.BigIconFormPNContainer.SuspendLayout();
            this.BigIconFormPNHead.SuspendLayout();
            this.BigIconFormPNHeadButton.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BigIconFormLBHeadTitle
            // 
            this.BigIconFormLBHeadTitle.Size = new System.Drawing.Size(508, 68);
            this.BigIconFormLBHeadTitle.Text = "Big Bird Deployer Java 服务启动管理工具";
            // 
            // BigIconFormPNContainer
            // 
            this.BigIconFormPNContainer.BackColor = System.Drawing.Color.White;
            this.BigIconFormPNContainer.Controls.Add(this.tabControl1);
            this.BigIconFormPNContainer.Size = new System.Drawing.Size(775, 445);
            // 
            // BigIconFormPNHead
            // 
            this.BigIconFormPNHead.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BigIconFormPNHead.Size = new System.Drawing.Size(775, 68);
            // 
            // BigIconFormPNHeadButton
            // 
            this.BigIconFormPNHeadButton.Location = new System.Drawing.Point(658, 0);
            // 
            // BigIconFormBTFormMinBox
            // 
            this.BigIconFormBTFormMinBox.FlatAppearance.BorderSize = 0;
            this.BigIconFormBTFormMinBox.Location = new System.Drawing.Point(44, 7);
            // 
            // BigIconFormBTFormMaxBox
            // 
            this.BigIconFormBTFormMaxBox.FlatAppearance.BorderSize = 0;
            this.BigIconFormBTFormMaxBox.Location = new System.Drawing.Point(82, 36);
            this.BigIconFormBTFormMaxBox.Visible = false;
            // 
            // BigIconFormBTFormCloseBox
            // 
            this.BigIconFormBTFormCloseBox.FlatAppearance.BorderSize = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 445);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.project1);
            this.tabPage1.Controls.Add(this.project4);
            this.tabPage1.Controls.Add(this.project2);
            this.tabPage1.Controls.Add(this.project3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(767, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " 【第一页】 ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.project6);
            this.tabPage2.Controls.Add(this.project5);
            this.tabPage2.Controls.Add(this.project7);
            this.tabPage2.Controls.Add(this.project8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(767, 419);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " 【不够再来一页】 ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BTSettings);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(767, 419);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = " 【设置】 ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BTSettings
            // 
            this.BTSettings.Location = new System.Drawing.Point(248, 134);
            this.BTSettings.Name = "BTSettings";
            this.BTSettings.Size = new System.Drawing.Size(288, 95);
            this.BTSettings.TabIndex = 4;
            this.BTSettings.Text = "惊不惊喜，意不意外";
            this.BTSettings.UseVisualStyleBackColor = true;
            this.BTSettings.Click += new System.EventHandler(this.BTSettings_Click);
            // 
            // project1
            // 
            this.project1.BackColor = System.Drawing.Color.DimGray;
            this.project1.Location = new System.Drawing.Point(35, 55);
            this.project1.Name = "project1";
            this.project1.Size = new System.Drawing.Size(324, 116);
            this.project1.TabIndex = 0;
            // 
            // project4
            // 
            this.project4.BackColor = System.Drawing.Color.DimGray;
            this.project4.Location = new System.Drawing.Point(403, 204);
            this.project4.Name = "project4";
            this.project4.Size = new System.Drawing.Size(324, 116);
            this.project4.TabIndex = 4;
            // 
            // project2
            // 
            this.project2.BackColor = System.Drawing.Color.DimGray;
            this.project2.Location = new System.Drawing.Point(403, 55);
            this.project2.Name = "project2";
            this.project2.Size = new System.Drawing.Size(324, 116);
            this.project2.TabIndex = 1;
            // 
            // project3
            // 
            this.project3.BackColor = System.Drawing.Color.DimGray;
            this.project3.Location = new System.Drawing.Point(35, 204);
            this.project3.Name = "project3";
            this.project3.Size = new System.Drawing.Size(324, 116);
            this.project3.TabIndex = 2;
            // 
            // project6
            // 
            this.project6.BackColor = System.Drawing.Color.DimGray;
            this.project6.Location = new System.Drawing.Point(403, 55);
            this.project6.Name = "project6";
            this.project6.Size = new System.Drawing.Size(324, 116);
            this.project6.TabIndex = 14;
            // 
            // project5
            // 
            this.project5.BackColor = System.Drawing.Color.DimGray;
            this.project5.Location = new System.Drawing.Point(35, 55);
            this.project5.Name = "project5";
            this.project5.Size = new System.Drawing.Size(324, 116);
            this.project5.TabIndex = 13;
            // 
            // project7
            // 
            this.project7.BackColor = System.Drawing.Color.DimGray;
            this.project7.Location = new System.Drawing.Point(35, 204);
            this.project7.Name = "project7";
            this.project7.Size = new System.Drawing.Size(324, 116);
            this.project7.TabIndex = 12;
            // 
            // project8
            // 
            this.project8.BackColor = System.Drawing.Color.DimGray;
            this.project8.Location = new System.Drawing.Point(403, 204);
            this.project8.Name = "project8";
            this.project8.Size = new System.Drawing.Size(324, 116);
            this.project8.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 513);
            this.DoubleClickMax = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Controls.SetChildIndex(this.BigIconFormPNHead, 0);
            this.Controls.SetChildIndex(this.BigIconFormPNContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.BigIconFormPBHeadIcon)).EndInit();
            this.BigIconFormPNContainer.ResumeLayout(false);
            this.BigIconFormPNHead.ResumeLayout(false);
            this.BigIconFormPNHeadButton.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Parts.ProjectItemPart project1;
        private Parts.ProjectItemPart project2;
        private Parts.ProjectItemPart project3;
        private Parts.ProjectItemPart project4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Parts.ProjectItemPart project7;
        private Parts.ProjectItemPart project8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button BTSettings;
        private Parts.ProjectItemPart project6;
        private Parts.ProjectItemPart project5;
    }
}