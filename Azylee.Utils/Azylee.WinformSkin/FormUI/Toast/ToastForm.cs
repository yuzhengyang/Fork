using Azylee.WinformSkin.APIUtils;
using Azylee.WinformSkin.FormUI.NoTitle;
using Azylee.WinformSkin.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Azylee.WinformSkin.FormUI.Toast
{
    public partial class ToastForm : NoTitleForm
    {
        public enum ToastType { warn, error, info }
        private static ToastForm form = new ToastForm();
        private Action ClickAction = null;

        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="type">类型：w,e,i</param>
        /// <param name="time">显示时间：毫秒</param>
        /// <param name="clickAction">点击触发动作反馈</param>
        public static void Display(string title, string text, char type, int time, Action clickAction = null)
        {
            try
            {
                if (form == null || form.IsDisposed)
                    form = new ToastForm();

                ToastType tt = ToastType.info;
                if (type == 'w' || type == 'W') tt = ToastType.warn;
                if (type == 'e' || type == 'E') tt = ToastType.error;

                form.SetContent(title, text, tt, time);//设置提示框：标题、文本、类型、时间
                form.ClickAction = clickAction;//设置单击触发事件
                form.Toast();
            }
            catch { }
        }
        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="type">类型</param>
        /// <param name="clickAction">点击动作</param>
        /// <param name="time">显示时间：秒</param>
        public static void Display(string title, string text, ToastType type = ToastType.info, Action clickAction = null, short time = 5)
        {
            try
            {
                if (form == null || form.IsDisposed)
                    form = new ToastForm();

                form.SetContent(title, text, type, time * 1000);//设置提示框：标题、文本、类型、时间
                form.ClickAction = clickAction;//设置单击触发事件
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
            FormHideAPI.HideTabAltMenu(this.Handle);
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
        private void SetContent(string title, string text, ToastType type, int time)
        {
            Text = title;//设置程序标题
            LBTitle.Text = title;//设置显示标题
            LBText.Text = text;//设置内容
            SetType(type);//设置消息类型
            TMHide.Interval = time;//设置显示时长

            Height = 80;
            try
            {
                int byte_len = Encoding.UTF8.GetBytes(LBText.Text).Length;
                if (byte_len > 105)
                {
                    byte_len -= 105;
                    Height = 100;

                    while ((byte_len = byte_len - 55) > 0) Height += 20;
                }
            }
            catch { }

            TimeSpend = 0;//初始化运行时间，每次执行动画++
            SetPosition();//设置初始位置
            TMShowAnim.Interval = 10;//设置显示动画执行间隔
            SetBorder();//重置边框（因窗口高度发生变化，刷新边框）
        }
        /// <summary>
        /// 设置消息类型
        /// </summary>
        /// <param name="type"></param>
        private void SetType(ToastType type)
        {
            switch (type)
            {
                case ToastType.warn:
                    PBIcon.Image = Resources.toast_warning;
                    break;
                case ToastType.error:
                    PBIcon.Image = Resources.toast_error;
                    break;
                case ToastType.info:
                    PBIcon.Image = Resources.toast_info;
                    break;
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

        #region 事件动作
        private void PBIcon_Click(object sender, EventArgs e)
        {
            ClickAction?.Invoke();
            ClickAction = null;

            HideForm();
        }
        private void LBTitle_Click(object sender, EventArgs e)
        {
            ClickAction?.Invoke();
            ClickAction = null;

            HideForm();
        }
        private void LBText_Click(object sender, EventArgs e)
        {
            ClickAction?.Invoke();
            ClickAction = null;

            HideForm();
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

        #region 在系统Win+Tab中隐藏窗口
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        const int WS_EX_APPWINDOW = 0x00040000;
        //        const int WS_EX_TOOLWINDOW = 0x00000080;

        //        CreateParams result = base.CreateParams;
        //        result.ExStyle = result.ExStyle & (~WS_EX_APPWINDOW);
        //        result.ExStyle = result.ExStyle | WS_EX_TOOLWINDOW;
        //        return result;
        //    }
        //} 
        #endregion
    } 
}
