namespace Y.Skin.YoForm.Toast
{
    partial class ToastForm
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
            this.components = new System.ComponentModel.Container();
            this.LbMsg = new System.Windows.Forms.Label();
            this.TmActor = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // LbMsg
            // 
            this.LbMsg.BackColor = System.Drawing.Color.Gray;
            this.LbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbMsg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbMsg.ForeColor = System.Drawing.Color.White;
            this.LbMsg.Location = new System.Drawing.Point(0, 0);
            this.LbMsg.Name = "LbMsg";
            this.LbMsg.Size = new System.Drawing.Size(323, 107);
            this.LbMsg.TabIndex = 0;
            this.LbMsg.Text = "Toast";
            this.LbMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TmActor
            // 
            this.TmActor.Interval = 1000;
            this.TmActor.Tick += new System.EventHandler(this.TmActor_Tick);
            // 
            // ToastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 107);
            this.Controls.Add(this.LbMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToastForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToastForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ToastForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbMsg;
        private System.Windows.Forms.Timer TmActor;
    }
}