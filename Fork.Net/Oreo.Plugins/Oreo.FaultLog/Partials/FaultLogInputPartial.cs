using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oreo.FaultLog.DatabaseEngine;
using Oreo.FaultLog.Models;
using Y.Utils.DataUtils.Collections;
using System.Threading.Tasks;

namespace Oreo.FaultLog.Partials
{
    public partial class FaultLogInputPartial : UserControl
    {
        public FaultLogInputPartial()
        {
            InitializeComponent();
        }

        private void FaultLogInputPartial_Load(object sender, EventArgs e)
        {
            TbIp.Text = "";
            TbPhone.Text = "";
            TbAddress.Text = "";
            TbProblem.Text = "";
            TbSolution.Text = "";
            TbPostscript.Text = "";
            DgvData.Rows.Clear();

            Task.Factory.StartNew(() =>
            {
                using (var db = new Muse())
                {
                    var fls = db.Do<FaultLogs>().SqlQuery("SELECT * FROM faultlogs WHERE createtime LIKE @p0", DateTime.Now.ToString("yyyy-MM-dd") + "%");
                    if (ListTool.HasElements(fls))
                    {
                        foreach (var f in fls)
                        {
                            UIAddRow(f);
                        }
                    }
                }
            });
        }
        private void BtSearch_Click(object sender, EventArgs e)
        {
            string ip = string.Format("%{0}%", TbIp.Text); //TbIp.Text != "" ? string.Format("%{0}%", TbIp.Text) : Guid.NewGuid().ToString();
            string phone = string.Format("%{0}%", TbPhone.Text); //TbPhone.Text != "" ? string.Format("%{0}%", TbPhone.Text) : Guid.NewGuid().ToString();
            string address = string.Format("%{0}%", TbAddress.Text); //TbAddress.Text != "" ? string.Format("%{0}%", TbAddress.Text) : Guid.NewGuid().ToString();

            DgvData.Rows.Clear();
            Task.Factory.StartNew(() =>
            {
                UIAddButton(false);
                using (var db = new Muse())
                {

                    var fls = db.Do<FaultLogs>().SqlQuery("SELECT * FROM faultlogs WHERE ip LIKE @p0 and phone LIKE @p1 and address LIKE @p2", ip, phone, address);
                    if (ListTool.HasElements(fls))
                    {
                        foreach (var f in fls)
                        {
                            UIAddRow(f);
                        }
                    }
                }
                UIAddButton(true);
            });
        }
        private void BtToday_Click(object sender, EventArgs e)
        {
            DgvData.Rows.Clear();

            Task.Factory.StartNew(() =>
            {
                using (var db = new Muse())
                {
                    var fls = db.Do<FaultLogs>().SqlQuery("SELECT * FROM faultlogs WHERE createtime LIKE @p0", DateTime.Now.ToString("yyyy-MM-dd") + "%");
                    if (ListTool.HasElements(fls))
                    {
                        foreach (var f in fls)
                        {
                            UIAddRow(f);
                        }
                    }
                }
            });
        }
        private void BtAdd_Click(object sender, EventArgs e)
        {
            FaultLogs fl = new FaultLogs()
            {
                Ip = TbIp.Text,
                Phone = TbPhone.Text,
                Address = TbAddress.Text,
                Problem = TbProblem.Text,
                Solution = TbSolution.Text,
                Postscript = TbPostscript.Text,
                System = CbSystem.Text,
                CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            };
            DgvData.Rows.Clear();

            Task.Factory.StartNew(() =>
            {
                UIAddButton(false);
                using (var db = new Muse())
                {
                    if (CbIsFinish.Checked)
                    {
                        fl.IsFinish = true;
                        fl.FinishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    db.Add(fl);

                    var fls = db.Do<FaultLogs>().SqlQuery("SELECT * FROM faultlogs WHERE createtime LIKE @p0", DateTime.Now.ToString("yyyy-MM-dd") + "%");
                    if (ListTool.HasElements(fls))
                    {
                        foreach (var f in fls)
                        {
                            UIAddRow(f);
                        }
                    }
                }
                UIAddButton(true);
            });
        }


        void UIAddRow(FaultLogs f)
        {
            BeginInvoke(new Action(() =>
            {
                DgvData.Rows.Add(new object[] {
                    DgvData.Rows.Count+1,
                    f.CreateTime,
                    f.FinishTime,
                    f.Ip,
                    f.Phone,
                    f.Address,
                    f.System,
                    f.Problem,
                    f.Solution,
                    f.Postscript
                });
            }));
        }
        void UIAddButton(bool enable)
        {
            BeginInvoke(new Action(() =>
            {
                BtAdd.Enabled = enable;
            }));
        }


    }
}
