using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oreo.FaultLog.Models;
using Oreo.FaultLog.DatabaseEngine;

namespace Oreo.FaultLog.Partials
{
    public partial class FaultLogModifyPartial : UserControl
    {
        public int Id { get; set; }
        public FaultLogModifyPartial()
        {
            InitializeComponent();
        }

        private void FaultLogModifyPartial_Load(object sender, EventArgs e)
        {
        }
        public void InitInfo(int id)
        {
            Id = id;
            using (var db = new Muse())
            {
                FaultLogs faultLog = db.Get<FaultLogs>(x => x.Id == id, null);
                if (faultLog != null)
                {
                    TbIp.Text = faultLog.Ip;
                    TbPhone.Text = faultLog.Phone;
                    TbAddress.Text = faultLog.Address;
                    TbProblem.Text = faultLog.Problem;
                    TbSolution.Text = faultLog.Solution;
                    TbPostscript.Text = faultLog.Postscript;
                    CbSystem.Text = faultLog.System;
                    if (faultLog.IsFinish) CbIsFinish.Checked = true;
                }
            }
        }
        public bool SaveInfo()
        {
            using (var db = new Muse())
            {
                FaultLogs fl = db.Get<FaultLogs>(x => x.Id == Id, null);
                if (fl != null)
                {
                    fl.Address = TbAddress.Text;
                    fl.Ip = TbIp.Text;
                    fl.Phone = TbPhone.Text;
                    fl.Postscript = TbPostscript.Text;
                    fl.Problem = TbProblem.Text;
                    fl.Solution = TbSolution.Text;
                    fl.System = CbSystem.Text;
                    if (CbIsFinish.Checked && !fl.IsFinish)
                    {
                        fl.IsFinish = true;
                        fl.FinishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        fl.IsFinish = false;
                        fl.FinishTime = "";
                    }
                    int flag = db.Update(fl, true);
                    return flag > 0;
                }
            }
            return false;
        }
    }
}
