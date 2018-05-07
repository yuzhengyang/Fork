using Azylee.WinformSkin.APIUtils;
using Azylee.WinformSkin.FormUI.NoTitle;
using Azylee.WinformSkin.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Azylee.WinformSkin.FormUI.Toast
{
    public partial class ToastForm : NoTitleForm
    {
        private static ToastForm form = new ToastForm();
        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="type">类型：w,e,i</param>
        /// <param name="time">显示时间：ms</param>
        public static void Display(string title, string text, char type, int time)
        {
            try
            {
                if (form == null || form.IsDisposed)
                    form = new ToastForm();

                form.SetContent(title, text, type, time);
                form.Toast();
            }
            catch { }
        }

        private int TimeSpend = 0;
        private int SlowTime = 8;
        private int SlowStep = 10;
        private ToastForm()
        {
            InitializeComponent();
        }
        private void ToastForm_Load(object sender, EventArgs e)
        {
            SetPosition();//设置初始位置为右下角，开始栏上方12px
            ShowInTaskbar = false;//不在任务栏显示
            TopMost = true;//显示到最上层窗体
        }
        private void Toast()
        {
            Show();//显示窗口
            TMHideAnim.Enabled = false;//隐藏动画禁用（防止冲突）
            TMHide.Enabled = false;//隐藏计时器禁用（防止冲突）
            TMShowAnim.Enabled = true;//启动显示动画
            TMHide.Enabled = true;//开始隐藏倒计时
        }
        #region 初始化设置
        /// <summary>
        /// 初始化设置，设置要显示的内容
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="type">类型：w,e,i</param>
        /// <param name="time">显示时间：ms</param>
        private void SetContent(string title, string text, char type, int time)
        {
            TimeSpend = 0;//初始化运行时间，每次执行动画++
            SetPosition();//设置初始位置
            TMShowAnim.Interval = 10;//设置显示动画执行间隔

            Text = title;//设置程序标题
            LBTitle.Text = title;//设置显示标题
            LBText.Text = text;//设置内容
            SetType(type);//设置消息类型
            TMHide.Interval = time;//设置显示时长
        }
        /// <summary>
        /// 设置消息类型
        /// </summary>
        /// <param name="type"></param>
        private void SetType(char type)
        {
            switch (type)
            {
                case 'w':
                case 'W':
                    PBIcon.Image = Resources.toast_warning;
                    break;
                case 'e':
                case 'E':
                    PBIcon.Image = Resources.toast_error;
                    break;
                case 'i':
                case 'I':
                default:
                    PBIcon.Image = Resources.toast_info;
                    break;
            }
        }
        /// <summary>
        /// 设置初始位置
        /// </summary>
        private void SetPosition()
        {
            Left = Screen.PrimaryScreen.WorkingArea.Width;
            Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 12;
        }
        #endregion

        #region 显示提示框
        private void TMShowAnim_Tick(object sender, EventArgs e)
        {
            if (Left > Screen.PrimaryScreen.WorkingArea.Width - Width)
            {
                Left -= 30;
                if (TimeSpend++ > SlowTime) TMShowAnim.Interval += SlowStep;
            }
            else
            {
                TMShowAnim.Enabled = false;
            }
        }
        #endregion
        #region 隐藏提示框
        /// <summary>
        /// 执行隐藏窗口动画
        /// </summary>
        private void HideForm()
        {
            TimeSpend = 0;
            TMShowAnim.Enabled = false;
            TMHide.Enabled = false;
            TMHideAnim.Enabled = true;//执行隐藏窗口动画
            TMHideAnim.Interval = 10;
        }
        private void PBIcon_Click(object sender, EventArgs e)
        {
            HideForm();
        }
        private void LBTitle_Click(object sender, EventArgs e)
        {
            HideForm();
        }
        private void LBText_Click(object sender, EventArgs e)
        {
            HideForm();
        }
        private void TMHide_Tick(object sender, EventArgs e)
        {
            HideForm();
        }
        private void TMHideAnim_Tick(object sender, EventArgs e)
        {
            if (Left < Screen.PrimaryScreen.WorkingArea.Width)
            {
                Left += 30;
                if (TimeSpend++ > SlowTime) TMShowAnim.Interval += SlowStep;
            }
            else
            {
                TMHideAnim.Enabled = false;
                Hide();
                Close();
            }
        }
        #endregion
    }
}
