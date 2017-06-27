namespace Oreo.FaultLog.Views
{
    partial class ModifyForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtSave = new System.Windows.Forms.Button();
            this.faultLogModifyPartial1 = new Oreo.FaultLog.Partials.FaultLogModifyPartial();
            this.BtCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 328);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 33);
            this.panel1.TabIndex = 5;
            // 
            // BtSave
            // 
            this.BtSave.FlatAppearance.BorderSize = 0;
            this.BtSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtSave.ForeColor = System.Drawing.Color.White;
            this.BtSave.Location = new System.Drawing.Point(223, 6);
            this.BtSave.Name = "BtSave";
            this.BtSave.Size = new System.Drawing.Size(301, 23);
            this.BtSave.TabIndex = 0;
            this.BtSave.Text = "保存";
            this.BtSave.UseVisualStyleBackColor = true;
            this.BtSave.Click += new System.EventHandler(this.BtSave_Click);
            // 
            // faultLogModifyPartial1
            // 
            this.faultLogModifyPartial1.BackColor = System.Drawing.Color.White;
            this.faultLogModifyPartial1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.faultLogModifyPartial1.Id = 0;
            this.faultLogModifyPartial1.Location = new System.Drawing.Point(0, 57);
            this.faultLogModifyPartial1.Name = "faultLogModifyPartial1";
            this.faultLogModifyPartial1.Size = new System.Drawing.Size(700, 271);
            this.faultLogModifyPartial1.TabIndex = 6;
            // 
            // BtCancel
            // 
            this.BtCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtCancel.FlatAppearance.BorderSize = 0;
            this.BtCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtCancel.ForeColor = System.Drawing.Color.White;
            this.BtCancel.Location = new System.Drawing.Point(657, 12);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(31, 23);
            this.BtCancel.TabIndex = 1;
            this.BtCancel.Text = "X";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // ModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.CancelButton = this.BtCancel;
            this.ClientSize = new System.Drawing.Size(700, 361);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.faultLogModifyPartial1);
            this.Controls.Add(this.panel1);
            this.Name = "ModifyForm";
            this.Text = "ModifyForm";
            this.Load += new System.EventHandler(this.ModifyForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtSave;
        private Partials.FaultLogModifyPartial faultLogModifyPartial1;
        private System.Windows.Forms.Button BtCancel;
    }
}