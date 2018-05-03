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
            this.projectItemPart1 = new Oreo.BigBirdDeployer.Parts.ProjectItemPart();
            this.projectItemPart2 = new Oreo.BigBirdDeployer.Parts.ProjectItemPart();
            ((System.ComponentModel.ISupportInitialize)(this.BigIconFormPBHeadIcon)).BeginInit();
            this.BigIconFormPNContainer.SuspendLayout();
            this.BigIconFormPNHead.SuspendLayout();
            this.BigIconFormPNHeadButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // BigIconFormLBHeadTitle
            // 
            this.BigIconFormLBHeadTitle.Size = new System.Drawing.Size(508, 68);
            // 
            // BigIconFormPNContainer
            // 
            this.BigIconFormPNContainer.Controls.Add(this.projectItemPart2);
            this.BigIconFormPNContainer.Controls.Add(this.projectItemPart1);
            this.BigIconFormPNContainer.Size = new System.Drawing.Size(775, 445);
            // 
            // BigIconFormPNHead
            // 
            this.BigIconFormPNHead.Size = new System.Drawing.Size(775, 68);
            // 
            // BigIconFormPNHeadButton
            // 
            this.BigIconFormPNHeadButton.Location = new System.Drawing.Point(658, 0);
            // 
            // BigIconFormBTFormMinBox
            // 
            this.BigIconFormBTFormMinBox.FlatAppearance.BorderSize = 0;
            // 
            // BigIconFormBTFormMaxBox
            // 
            this.BigIconFormBTFormMaxBox.FlatAppearance.BorderSize = 0;
            // 
            // BigIconFormBTFormCloseBox
            // 
            this.BigIconFormBTFormCloseBox.FlatAppearance.BorderSize = 0;
            // 
            // projectItemPart1
            // 
            this.projectItemPart1.BackColor = System.Drawing.Color.DimGray;
            this.projectItemPart1.Location = new System.Drawing.Point(12, 22);
            this.projectItemPart1.Name = "projectItemPart1";
            this.projectItemPart1.Size = new System.Drawing.Size(513, 95);
            this.projectItemPart1.TabIndex = 0;
            // 
            // projectItemPart2
            // 
            this.projectItemPart2.BackColor = System.Drawing.Color.DimGray;
            this.projectItemPart2.Location = new System.Drawing.Point(12, 134);
            this.projectItemPart2.Name = "projectItemPart2";
            this.projectItemPart2.Size = new System.Drawing.Size(513, 95);
            this.projectItemPart2.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 513);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Controls.SetChildIndex(this.BigIconFormPNHead, 0);
            this.Controls.SetChildIndex(this.BigIconFormPNContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.BigIconFormPBHeadIcon)).EndInit();
            this.BigIconFormPNContainer.ResumeLayout(false);
            this.BigIconFormPNHead.ResumeLayout(false);
            this.BigIconFormPNHeadButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Parts.ProjectItemPart projectItemPart1;
        private Parts.ProjectItemPart projectItemPart2;
    }
}