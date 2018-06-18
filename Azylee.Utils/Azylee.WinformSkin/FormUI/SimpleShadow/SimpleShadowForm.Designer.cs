namespace Azylee.WinformSkin.FormUI.SimpleShadow
{
    partial class SimpleShadowForm
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
            this.SuspendLayout();
            // 
            // SimpleShadowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SimpleShadowForm";
            this.Text = "SimpleShadowForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SimpleShadowForm_FormClosed);
            this.Load += new System.EventHandler(this.SimpleShadowForm_Load);
            this.Shown += new System.EventHandler(this.SimpleShadowForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}