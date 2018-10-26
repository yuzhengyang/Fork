using Azylee.YeahWeb.SocketUtils.TcpUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.TcpServerApp
{
    public partial class MainForm : Form
    {
        TcppServer tcpServer = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TBText_TextChanged(object sender, EventArgs e)
        {
            LBTextLength.Text = TBText.TextLength.ToString();
        }

        private void BTStart_Click(object sender, EventArgs e)
        {
            TBText.AppendText("正在监听:" + TBPort.Text + "\n");
            tcpServer = new TcppServer(int.Parse(TBPort.Text),
                ReceiveMessage, OnConnect, OnDisconnect);
            tcpServer?.Start();
        }

        private void BTStop_Click(object sender, EventArgs e)
        {
            tcpServer?.Stop();
            CBHost.Items.Clear();
        }


        private void BTSend_Click(object sender, EventArgs e)
        {
            try
            {
                string host = CBHost.SelectedItem.ToString();
                tcpServer.Write(host, new TcpDataModel()
                {
                    Type = 1000,
                    Data = Encoding.UTF8.GetBytes(TBMessage.Text)
                });
            }
            catch { }
        }

        #region Tcp 委托方法
        private void OnConnect(string host)
        {
            this.Invoke(new Action(() =>
            {
                TBText.AppendText($"Connect : {host}" + Environment.NewLine);
                CBHost.Items.Add(host);
                LBConnect.Text = tcpServer.ClientsCount().ToString();
            }));
        }
        private void OnDisconnect(string host)
        {
            this.Invoke(new Action(() =>
            {
                TBText.AppendText($"Disconnect : {host}" + Environment.NewLine);
                CBHost.Items.Remove(host);
            }));
        }
        private void ReceiveMessage(string host, TcpDataModel data)
        {
            this.Invoke(new Action(() =>
            {
                if (data.Type == 1000)
                {
                    string s = Encoding.UTF8.GetString(data.Data);
                    int l = s.Length;
                    TBText.AppendText(host + " : " + s);
                    TBText.AppendText(Environment.NewLine);
                }
            }));
        }
        #endregion

        private void TBMessage_TextChanged(object sender, EventArgs e)
        {
            LBMessageLength.Text = TBMessage.TextLength.ToString();
        }

        private void BTClear_Click(object sender, EventArgs e)
        {
            TBText.Clear();
        }
    }
}
