namespace Test.TcpClientApp
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BTDisconnect = new System.Windows.Forms.Button();
            this.TBPort = new System.Windows.Forms.TextBox();
            this.TBText = new System.Windows.Forms.TextBox();
            this.BTConnect = new System.Windows.Forms.Button();
            this.TBType = new System.Windows.Forms.TextBox();
            this.TBMessage = new System.Windows.Forms.TextBox();
            this.BTSend = new System.Windows.Forms.Button();
            this.TBIP = new System.Windows.Forms.TextBox();
            this.LBTextLength = new System.Windows.Forms.Label();
            this.LBMessageLength = new System.Windows.Forms.Label();
            this.LBLine1 = new System.Windows.Forms.Label();
            this.BTClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTDisconnect
            // 
            this.BTDisconnect.Location = new System.Drawing.Point(259, 8);
            this.BTDisconnect.Name = "BTDisconnect";
            this.BTDisconnect.Size = new System.Drawing.Size(69, 23);
            this.BTDisconnect.TabIndex = 7;
            this.BTDisconnect.Text = "断开";
            this.BTDisconnect.UseVisualStyleBackColor = true;
            this.BTDisconnect.Click += new System.EventHandler(this.BTDisconnect_Click);
            // 
            // TBPort
            // 
            this.TBPort.Location = new System.Drawing.Point(128, 10);
            this.TBPort.Name = "TBPort";
            this.TBPort.Size = new System.Drawing.Size(50, 21);
            this.TBPort.TabIndex = 6;
            this.TBPort.Text = "52801";
            // 
            // TBText
            // 
            this.TBText.Enabled = false;
            this.TBText.Location = new System.Drawing.Point(12, 37);
            this.TBText.Multiline = true;
            this.TBText.Name = "TBText";
            this.TBText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBText.Size = new System.Drawing.Size(397, 75);
            this.TBText.TabIndex = 5;
            this.TBText.TextChanged += new System.EventHandler(this.TBText_TextChanged);
            // 
            // BTConnect
            // 
            this.BTConnect.Location = new System.Drawing.Point(184, 8);
            this.BTConnect.Name = "BTConnect";
            this.BTConnect.Size = new System.Drawing.Size(69, 23);
            this.BTConnect.TabIndex = 4;
            this.BTConnect.Text = "连接";
            this.BTConnect.UseVisualStyleBackColor = true;
            this.BTConnect.Click += new System.EventHandler(this.BTConnect_Click);
            // 
            // TBType
            // 
            this.TBType.Location = new System.Drawing.Point(447, 8);
            this.TBType.Name = "TBType";
            this.TBType.Size = new System.Drawing.Size(55, 21);
            this.TBType.TabIndex = 8;
            this.TBType.Text = "1000";
            // 
            // TBMessage
            // 
            this.TBMessage.Location = new System.Drawing.Point(447, 35);
            this.TBMessage.Multiline = true;
            this.TBMessage.Name = "TBMessage";
            this.TBMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBMessage.Size = new System.Drawing.Size(139, 77);
            this.TBMessage.TabIndex = 9;
            this.TBMessage.TextChanged += new System.EventHandler(this.TBMessage_TextChanged);
            // 
            // BTSend
            // 
            this.BTSend.Location = new System.Drawing.Point(517, 6);
            this.BTSend.Name = "BTSend";
            this.BTSend.Size = new System.Drawing.Size(69, 23);
            this.BTSend.TabIndex = 10;
            this.BTSend.Text = "发送";
            this.BTSend.UseVisualStyleBackColor = true;
            this.BTSend.Click += new System.EventHandler(this.BTSend_Click);
            // 
            // TBIP
            // 
            this.TBIP.Location = new System.Drawing.Point(12, 10);
            this.TBIP.Name = "TBIP";
            this.TBIP.Size = new System.Drawing.Size(109, 21);
            this.TBIP.TabIndex = 11;
            this.TBIP.Text = "127.0.0.1";
            // 
            // LBTextLength
            // 
            this.LBTextLength.AutoSize = true;
            this.LBTextLength.Location = new System.Drawing.Point(12, 115);
            this.LBTextLength.Name = "LBTextLength";
            this.LBTextLength.Size = new System.Drawing.Size(11, 12);
            this.LBTextLength.TabIndex = 12;
            this.LBTextLength.Text = "0";
            // 
            // LBMessageLength
            // 
            this.LBMessageLength.AutoSize = true;
            this.LBMessageLength.Location = new System.Drawing.Point(445, 115);
            this.LBMessageLength.Name = "LBMessageLength";
            this.LBMessageLength.Size = new System.Drawing.Size(11, 12);
            this.LBMessageLength.TabIndex = 13;
            this.LBMessageLength.Text = "0";
            // 
            // LBLine1
            // 
            this.LBLine1.BackColor = System.Drawing.Color.Black;
            this.LBLine1.Location = new System.Drawing.Point(427, 8);
            this.LBLine1.Name = "LBLine1";
            this.LBLine1.Size = new System.Drawing.Size(1, 106);
            this.LBLine1.TabIndex = 14;
            // 
            // BTClear
            // 
            this.BTClear.Location = new System.Drawing.Point(340, 6);
            this.BTClear.Name = "BTClear";
            this.BTClear.Size = new System.Drawing.Size(69, 23);
            this.BTClear.TabIndex = 15;
            this.BTClear.Text = "清空";
            this.BTClear.UseVisualStyleBackColor = true;
            this.BTClear.Click += new System.EventHandler(this.BTClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 136);
            this.Controls.Add(this.BTClear);
            this.Controls.Add(this.LBLine1);
            this.Controls.Add(this.LBMessageLength);
            this.Controls.Add(this.LBTextLength);
            this.Controls.Add(this.TBIP);
            this.Controls.Add(this.BTSend);
            this.Controls.Add(this.TBMessage);
            this.Controls.Add(this.TBType);
            this.Controls.Add(this.BTDisconnect);
            this.Controls.Add(this.TBPort);
            this.Controls.Add(this.TBText);
            this.Controls.Add(this.BTConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tcp客户端";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTDisconnect;
        private System.Windows.Forms.TextBox TBPort;
        private System.Windows.Forms.TextBox TBText;
        private System.Windows.Forms.Button BTConnect;
        private System.Windows.Forms.TextBox TBType;
        private System.Windows.Forms.TextBox TBMessage;
        private System.Windows.Forms.Button BTSend;
        private System.Windows.Forms.TextBox TBIP;
        private System.Windows.Forms.Label LBTextLength;
        private System.Windows.Forms.Label LBMessageLength;
        private System.Windows.Forms.Label LBLine1;
        private System.Windows.Forms.Button BTClear;
    }
}

