namespace Test.TcpServerApp
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
            this.BTStart = new System.Windows.Forms.Button();
            this.TBText = new System.Windows.Forms.TextBox();
            this.TBPort = new System.Windows.Forms.TextBox();
            this.BTStop = new System.Windows.Forms.Button();
            this.TBType = new System.Windows.Forms.TextBox();
            this.TBMessage = new System.Windows.Forms.TextBox();
            this.BTSend = new System.Windows.Forms.Button();
            this.CBHost = new System.Windows.Forms.ComboBox();
            this.LBLine1 = new System.Windows.Forms.Label();
            this.LBMessageLength = new System.Windows.Forms.Label();
            this.LBTextLength = new System.Windows.Forms.Label();
            this.LBConnect = new System.Windows.Forms.Label();
            this.BTClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTStart
            // 
            this.BTStart.Location = new System.Drawing.Point(73, 10);
            this.BTStart.Name = "BTStart";
            this.BTStart.Size = new System.Drawing.Size(67, 23);
            this.BTStart.TabIndex = 0;
            this.BTStart.Text = "启动";
            this.BTStart.UseVisualStyleBackColor = true;
            this.BTStart.Click += new System.EventHandler(this.BTStart_Click);
            // 
            // TBText
            // 
            this.TBText.Enabled = false;
            this.TBText.Location = new System.Drawing.Point(12, 41);
            this.TBText.Multiline = true;
            this.TBText.Name = "TBText";
            this.TBText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBText.Size = new System.Drawing.Size(311, 200);
            this.TBText.TabIndex = 1;
            this.TBText.TextChanged += new System.EventHandler(this.TBText_TextChanged);
            // 
            // TBPort
            // 
            this.TBPort.Location = new System.Drawing.Point(12, 12);
            this.TBPort.Name = "TBPort";
            this.TBPort.Size = new System.Drawing.Size(55, 21);
            this.TBPort.TabIndex = 2;
            this.TBPort.Text = "52801";
            // 
            // BTStop
            // 
            this.BTStop.Location = new System.Drawing.Point(146, 10);
            this.BTStop.Name = "BTStop";
            this.BTStop.Size = new System.Drawing.Size(66, 23);
            this.BTStop.TabIndex = 3;
            this.BTStop.Text = "停止";
            this.BTStop.UseVisualStyleBackColor = true;
            this.BTStop.Click += new System.EventHandler(this.BTStop_Click);
            // 
            // TBType
            // 
            this.TBType.Location = new System.Drawing.Point(359, 12);
            this.TBType.Name = "TBType";
            this.TBType.Size = new System.Drawing.Size(53, 21);
            this.TBType.TabIndex = 4;
            this.TBType.Text = "1000";
            // 
            // TBMessage
            // 
            this.TBMessage.Location = new System.Drawing.Point(359, 41);
            this.TBMessage.Multiline = true;
            this.TBMessage.Name = "TBMessage";
            this.TBMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBMessage.Size = new System.Drawing.Size(259, 200);
            this.TBMessage.TabIndex = 5;
            this.TBMessage.TextChanged += new System.EventHandler(this.TBMessage_TextChanged);
            // 
            // BTSend
            // 
            this.BTSend.Location = new System.Drawing.Point(551, 12);
            this.BTSend.Name = "BTSend";
            this.BTSend.Size = new System.Drawing.Size(67, 23);
            this.BTSend.TabIndex = 6;
            this.BTSend.Text = "发送";
            this.BTSend.UseVisualStyleBackColor = true;
            this.BTSend.Click += new System.EventHandler(this.BTSend_Click);
            // 
            // CBHost
            // 
            this.CBHost.FormattingEnabled = true;
            this.CBHost.Location = new System.Drawing.Point(418, 13);
            this.CBHost.Name = "CBHost";
            this.CBHost.Size = new System.Drawing.Size(121, 20);
            this.CBHost.TabIndex = 8;
            // 
            // LBLine1
            // 
            this.LBLine1.BackColor = System.Drawing.Color.Black;
            this.LBLine1.Location = new System.Drawing.Point(340, 7);
            this.LBLine1.Name = "LBLine1";
            this.LBLine1.Size = new System.Drawing.Size(1, 247);
            this.LBLine1.TabIndex = 17;
            // 
            // LBMessageLength
            // 
            this.LBMessageLength.AutoSize = true;
            this.LBMessageLength.Location = new System.Drawing.Point(359, 244);
            this.LBMessageLength.Name = "LBMessageLength";
            this.LBMessageLength.Size = new System.Drawing.Size(11, 12);
            this.LBMessageLength.TabIndex = 16;
            this.LBMessageLength.Text = "0";
            // 
            // LBTextLength
            // 
            this.LBTextLength.AutoSize = true;
            this.LBTextLength.Location = new System.Drawing.Point(12, 244);
            this.LBTextLength.Name = "LBTextLength";
            this.LBTextLength.Size = new System.Drawing.Size(11, 12);
            this.LBTextLength.TabIndex = 15;
            this.LBTextLength.Text = "0";
            // 
            // LBConnect
            // 
            this.LBConnect.AutoSize = true;
            this.LBConnect.Location = new System.Drawing.Point(312, 17);
            this.LBConnect.Name = "LBConnect";
            this.LBConnect.Size = new System.Drawing.Size(11, 12);
            this.LBConnect.TabIndex = 18;
            this.LBConnect.Text = "0";
            // 
            // BTClear
            // 
            this.BTClear.Location = new System.Drawing.Point(218, 11);
            this.BTClear.Name = "BTClear";
            this.BTClear.Size = new System.Drawing.Size(66, 23);
            this.BTClear.TabIndex = 19;
            this.BTClear.Text = "清空";
            this.BTClear.UseVisualStyleBackColor = true;
            this.BTClear.Click += new System.EventHandler(this.BTClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(626, 262);
            this.Controls.Add(this.BTClear);
            this.Controls.Add(this.LBConnect);
            this.Controls.Add(this.LBLine1);
            this.Controls.Add(this.LBMessageLength);
            this.Controls.Add(this.LBTextLength);
            this.Controls.Add(this.CBHost);
            this.Controls.Add(this.BTSend);
            this.Controls.Add(this.TBMessage);
            this.Controls.Add(this.TBType);
            this.Controls.Add(this.BTStop);
            this.Controls.Add(this.TBPort);
            this.Controls.Add(this.TBText);
            this.Controls.Add(this.BTStart);
            this.Name = "MainForm";
            this.Text = "Tcp服务端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTStart;
        private System.Windows.Forms.TextBox TBText;
        private System.Windows.Forms.TextBox TBPort;
        private System.Windows.Forms.Button BTStop;
        private System.Windows.Forms.TextBox TBType;
        private System.Windows.Forms.TextBox TBMessage;
        private System.Windows.Forms.Button BTSend;
        private System.Windows.Forms.ComboBox CBHost;
        private System.Windows.Forms.Label LBLine1;
        private System.Windows.Forms.Label LBMessageLength;
        private System.Windows.Forms.Label LBTextLength;
        private System.Windows.Forms.Label LBConnect;
        private System.Windows.Forms.Button BTClear;
    }
}

