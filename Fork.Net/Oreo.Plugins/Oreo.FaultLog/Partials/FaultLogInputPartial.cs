using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Oreo.FaultLog.DatabaseEngine;
using Oreo.FaultLog.Models;
using System.Threading.Tasks;
using Oreo.FaultLog.Views;
using Y.Utils.DataUtils.Collections;

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
            UICleanInput();

            Task.Factory.StartNew(() =>
            {
                using (var db = new Muse())
                {
                    var first = db.Get<FaultLogs>(x => x.Id > 0, null);

                    List<FaultLogs> fls = db.Do<FaultLogs>().SqlQuery("SELECT * FROM faultlogs WHERE createtime LIKE @p0", DateTime.Now.ToString("yyyy-MM-dd") + "%").ToList();
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
                IsFinish = CbIsFinish.Checked,
                FinishTime = CbIsFinish.Checked ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : "",
            };

            UICleanInput();

            Task.Factory.StartNew(() =>
            {
                UIAddButton(false);
                using (var db = new Muse())
                {
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
        private void DgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //int id = (int)DgvData.Rows[e.RowIndex].Cells["DgvDataId"].Value;
                //MessageBox.Show(id.ToString());
                try
                {
                    int id = (int)DgvData.Rows[e.RowIndex].Cells["DgvDataId"].Value;
                    if (new ModifyForm(id).ShowDialog() == DialogResult.OK)
                    {
                        using (var db = new Muse())
                        {
                            FaultLogs f = db.Get<FaultLogs>(x => x.Id == id, null);
                            if (f != null) UIRefreshRow(e.RowIndex, f);
                        }
                    }
                }
                catch (Exception ex) { }
            }
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
                    f.Postscript,
                    f.Id
                });
            }));
        }
        void UIRefreshRow(int row, FaultLogs f)
        {
            BeginInvoke(new Action(() =>
            {
                DgvData.Rows[row].SetValues(new object[] {
                    DgvData.Rows.Count+1,
                    f.CreateTime,
                    f.FinishTime,
                    f.Ip,
                    f.Phone,
                    f.Address,
                    f.System,
                    f.Problem,
                    f.Solution,
                    f.Postscript,
                    f.Id
                });
            }));
            //            DgvData.Rows[row].Cells["DgvDataNo
            // DgvData.Rows[row].Cells["DgvDataCreateTime
            //DgvData.Rows[row].Cells["DgvDataFinishTime
            //DgvData.Rows[row].Cells["DgvDataIp
            //DgvData.Rows[row].Cells["DgvDataPhone
            //DgvData.Rows[row].Cells["DgvDataAddress
            //DgvData.Rows[row].Cells["DgvDataSystem
            //DgvData.Rows[row].Cells["DgvDataProblem
            //DgvData.Rows[row].Cells["DgvDataSolution
            //DgvData.Rows[row].Cells["DgvDataPostscript
            //DgvData.Rows[row].Cells["DgvDataId
        }
        void UIAddButton(bool enable)
        {
            BeginInvoke(new Action(() =>
            {
                BtAdd.Enabled = enable;
            }));
        }
        void UICleanInput()
        {
            BeginInvoke(new Action(() =>
            {
                TbIp.Text = "";
                TbPhone.Text = "";
                TbAddress.Text = "";
                TbProblem.Text = "";
                TbSolution.Text = "";
                TbPostscript.Text = "";
                CbIsFinish.Checked = false;
                CbSystem.Text = "";
                DgvData.Rows.Clear();
            }));
        }

    }
}
