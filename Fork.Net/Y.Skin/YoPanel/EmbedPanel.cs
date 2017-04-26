using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Y.Skin.YoPanel
{
    public partial class EmbedPanel : Panel
    {
        Action<object, EventArgs> appIdleAction = null;
        EventHandler appIdleEvent = null;
        public EmbedPanel()
        {
            InitializeComponent();
            appIdleAction = new Action<object, EventArgs>(Application_Idle);
            appIdleEvent = new EventHandler(appIdleAction);
        }
        public EmbedPanel(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            appIdleAction = new Action<object, EventArgs>(Application_Idle);
            appIdleEvent = new EventHandler(appIdleAction);
        }

        /// <summary>
        /// 确保应用程序嵌入此容器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_Idle(object sender, EventArgs e)
        {
            if (m_AppProcess == null || m_AppProcess.HasExited)
            {
                m_AppProcess = null;
                Application.Idle -= appIdleEvent;
                return;
            }
            if (m_AppProcess.MainWindowHandle == IntPtr.Zero) return;
            Application.Idle -= appIdleEvent;
            EmbedProcess(m_AppProcess, this);
        }
        /// <summary>
        /// 应用程序结束运行时要清除这里的标识
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_AppProcess_Exited(object sender, EventArgs e)
        {
            m_AppProcess = null;
        }





        #region 属性
        /// <summary>
        /// application process
        /// </summary>
        Process m_AppProcess = null;
        public Process AppProcess
        {
            get { return this.m_AppProcess; }
            set { this.m_AppProcess = value; }
        }

        /// <summary>
        /// 要嵌入的程序文件名
        /// </summary>
        private string m_AppFilename = "";
        /// <summary>
        /// 要嵌入的程序文件名
        /// </summary>
        [Category("Data")]
        [Description("要嵌入的程序文件名")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[Editor(typeof(AppFilenameEditor), typeof(UITypeEditor))]
        public string AppFilename
        {
            get
            {
                return m_AppFilename;
            }
            set
            {
                if (value == null || value == m_AppFilename) return;
                var self = Application.ExecutablePath;
                if (value.ToLower() == self.ToLower())
                {
                    MessageBox.Show("不能自己嵌入自己！", "SmileWei.EmbeddedApp");
                    return;
                }
                if (!value.ToLower().EndsWith(".exe"))
                {
                    MessageBox.Show("要嵌入的文件扩展名不是exe！", "SmileWei.EmbeddedApp");
                }
                if (!File.Exists(value))
                {
                    MessageBox.Show("要嵌入的程序不存在！", "SmileWei.EmbeddedApp");
                    return;
                }
                m_AppFilename = value;
            }
        }
        /// <summary>
        /// 标识内嵌程序是否已经启动
        /// </summary>
        public bool IsStarted { get { return (m_AppProcess != null); } }
        #endregion 属性


        /// <summary>
        /// 启动嵌入程序并嵌入到控件
        /// </summary>
        /// <param name="appFilename"></param>
        public void Start(string appFilename)
        {
            AppFilename = appFilename;
            Start();
        }
        public void Start()
        {
            //停止正在运行的进程
            if (m_AppProcess != null) Stop();
            try
            {
                ProcessStartInfo info = new ProcessStartInfo(m_AppFilename);
                info.UseShellExecute = true;
                info.WindowStyle = ProcessWindowStyle.Minimized;
                //info.WindowStyle = ProcessWindowStyle.Hidden;
                m_AppProcess = Process.Start(info);
                //等待创建进程
                m_AppProcess.WaitForInputIdle();
                //todo:下面这两句会引发 NullReferenceException 异常，不知道怎么回事                
                //m_AppProcess.Exited += new EventHandler(m_AppProcess_Exited);
                //m_AppProcess.EnableRaisingEvents = true;
                Application.Idle += appIdleEvent;
                //EmbedProcess(m_AppProcess, this);
            }
            catch (Exception ex)
            {
                //嵌入失败杀死进程
                if (m_AppProcess != null)
                {
                    if (!m_AppProcess.HasExited)
                        m_AppProcess.Kill();
                    m_AppProcess = null;
                }
            }
        }
        /// <summary>
        /// 重新嵌入
        /// </summary>
        public void ReEmbed()
        {
            EmbedProcess(m_AppProcess, this);
        }
        /// <summary>
        /// 退出嵌入的程序
        /// </summary>
        public void Stop()
        {
            if (m_AppProcess != null)// && m_AppProcess.MainWindowHandle != IntPtr.Zero)
            {
                try
                {
                    if (!m_AppProcess.HasExited)
                        m_AppProcess.Kill();
                }
                catch (Exception) { }
                m_AppProcess = null;
            }
        }

        /// <summary>
        /// 将程序嵌入控件
        /// </summary>
        /// <param name="app">嵌入程序</param>
        /// <param name="control">指定控件</param>
        private void EmbedProcess(Process app, Control control)
        {
            //验证程序和控件非空
            if (app == null || app.MainWindowHandle == IntPtr.Zero || control == null) return;
            try
            {
                //核心代码：嵌入程序
                SetParent(app.MainWindowHandle, control.Handle);
            }
            catch (Exception) { }
            try
            {
                //移除嵌入的窗口的窗口标题栏
                SetWindowLong(new HandleRef(this, app.MainWindowHandle), GWL_STYLE, WS_VISIBLE);
            }
            catch (Exception) { }
            try
            {
                //将嵌入的窗口欧放置到合适位置，填满宽高
                MoveWindow(app.MainWindowHandle, 0, 0, control.Width, control.Height, true);
            }
            catch (Exception) { }
        }

        #region 重写部分方法
        /// <summary>
        /// 窗体句柄销毁
        /// </summary>
        /// <param name="e"></param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            Stop();//将应用关闭
            base.OnHandleDestroyed(e);
        }
        /// <summary>
        /// 窗体大小修改
        /// </summary>
        /// <param name="eventargs"></param>
        protected override void OnResize(EventArgs eventargs)
        {
            if (m_AppProcess != null)
            {
                MoveWindow(m_AppProcess.MainWindowHandle, 0, 0, this.Width, this.Height, true);
            }
            base.OnResize(eventargs);
        }
        /// <summary>
        /// 窗台属性修改
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnSizeChanged(e);
        }
        #endregion
        #region Win32 API 常量
        private const int SWP_NOOWNERZORDER = 0x200;
        private const int SWP_NOREDRAW = 0x8;
        private const int SWP_NOZORDER = 0x4;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int WS_EX_MDICHILD = 0x40;
        private const int SWP_FRAMECHANGED = 0x20;
        private const int SWP_NOACTIVATE = 0x10;
        private const int SWP_ASYNCWINDOWPOS = 0x4000;
        private const int SWP_NOMOVE = 0x2;
        private const int SWP_NOSIZE = 0x1;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CLOSE = 0x10;
        private const int WS_CHILD = 0x40000000;

        private const int SW_HIDE = 0; //{隐藏, 并且任务栏也没有最小化图标}
        private const int SW_SHOWNORMAL = 1; //{用最近的大小和位置显示, 激活}
        private const int SW_NORMAL = 1; //{同 SW_SHOWNORMAL}
        private const int SW_SHOWMINIMIZED = 2; //{最小化, 激活}
        private const int SW_SHOWMAXIMIZED = 3; //{最大化, 激活}
        private const int SW_MAXIMIZE = 3; //{同 SW_SHOWMAXIMIZED}
        private const int SW_SHOWNOACTIVATE = 4; //{用最近的大小和位置显示, 不激活}
        private const int SW_SHOW = 5; //{同 SW_SHOWNORMAL}
        private const int SW_MINIMIZE = 6; //{最小化, 不激活}
        private const int SW_SHOWMINNOACTIVE = 7; //{同 SW_MINIMIZE}
        private const int SW_SHOWNA = 8; //{同 SW_SHOWNOACTIVATE}
        private const int SW_RESTORE = 9; //{同 SW_SHOWNORMAL}
        private const int SW_SHOWDEFAULT = 10; //{同 SW_SHOWNORMAL}
        private const int SW_MAX = 10; //{同 SW_SHOWNORMAL}
        #endregion
        #region Win32 API 方法声明
        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
            CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern long GetWindowLong(IntPtr hwnd, int nIndex);

        public static IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
            }
            return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hwnd, uint Msg, uint wParam, uint lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetParent(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        #endregion Win32 API
    }
}
