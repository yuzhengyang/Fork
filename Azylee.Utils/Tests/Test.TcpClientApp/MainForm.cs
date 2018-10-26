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

namespace Test.TcpClientApp
{
    public partial class MainForm : Form
    {
        TcppClient tcpClient = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void BTConnect_Click(object sender, EventArgs e)
        {
            tcpClient = new TcppClient(TBIP.Text, int.Parse(TBPort.Text),
                     ReceiveMessage, OnConnect, OnDisconnect);
            bool flag = tcpClient.Connect();
            if (flag) MessageBox.Show("连接成功");
            else MessageBox.Show("连接失败");
        }
        private void OnConnect(string host)
        {
            this.Invoke(new Action(() =>
            {
                TBText.AppendText($"Connect : {host}" + Environment.NewLine);
            }));
        }
        private void OnDisconnect(string host)
        {
            this.Invoke(new Action(() =>
            {
                TBText.AppendText($"Disconnect : {host}" + Environment.NewLine);
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

        private void BTSend_Click(object sender, EventArgs e)
        {
            byte[] sb = Encoding.UTF8.GetBytes(TBMessage.Text);
            tcpClient.Write(new TcpDataModel()
            {
                Type = 1000,
                Data = Encoding.UTF8.GetBytes(TBMessage.Text)
            });
        }

        private void BTDisconnect_Click(object sender, EventArgs e)
        {
            tcpClient?.Disconnect();
        }

        private void TBText_TextChanged(object sender, EventArgs e)
        {
            LBTextLength.Text = TBText.TextLength.ToString();
        }

        private void TBMessage_TextChanged(object sender, EventArgs e)
        {
            LBMessageLength.Text = TBMessage.TextLength.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void BTClear_Click(object sender, EventArgs e)
        {
            TBText.Clear();
        }
    }
}
