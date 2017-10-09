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
        //1 焦点问题，焦点导致内外两个窗口标题栏颜色不一致；
        //2 有些应用嵌入不了，会直接被单独打开；
        //3 有些应用嵌入不正常，位置与预计的不同；
        //4 有些应用嵌入关闭时会在后台继续运行；
        //5 调试期间 vs 不能强行退出 否则嵌入的程序不会退出；

        //embedPanel1.ReEmbed();
        //embedPanel1.Start(@"D:\CoCo\GitHub\Temp\ClipboardMonitor\ClipboardMonitor\ClipboardMonitor\bin\Debug\ClipboardMonitor.exe");
        //embedPanel1.Start(@"D:\Soft\DisplayX.1034260498.exe");

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
        /// 嵌入程序（保证程序嵌入）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_Idle(object sender, EventArgs e)
        {
            if (_AppProcess == null || _AppProcess.HasExited)
            {
                _AppProcess = null;
                Application.Idle -= appIdleEvent;
                return;
            }
            if (_AppProcess.MainWindowHandle == IntPtr.Zero) return;
            Application.Idle -= appIdleEvent;
            EmbedProcess(_AppProcess, this);
        }

        #region 常规属性
        private string AppFile = "";
        private Process _AppProcess = null;
        public Process AppProcess
        {
            get { return _AppProcess; }
            set { _AppProcess = value; }
        }
        public bool IsStarted { get { return (_AppProcess != null); } }
        #endregion
        #region 控件面板属性

        #endregion

        /// <summary>
        /// 启动嵌入程序
        /// </summary>
        /// <param name="appFilename"></param>
        public void Start(string appFile)
        {
            if (appFile.ToLower() == Application.ExecutablePath.ToLower()) return;//禁止嵌入自己
            if (!appFile.ToLower().EndsWith(".exe")) return;//禁止嵌入非exe文件
            if (!File.Exists(appFile)) return;//禁止嵌入不存在文件

            AppFile = appFile;
            if (_AppProcess != null) Stop();//停止正在运行的进程
            try
            {
                ProcessStartInfo info = new ProcessStartInfo(AppFile);
                info.UseShellExecute = true;
                info.WindowStyle = ProcessWindowStyle.Minimized;
                //info.WindowStyle = ProcessWindowStyle.Hidden;
                _AppProcess = Process.Start(info);
                //等待创建进程
                _AppProcess.WaitForInputIdle();
                //todo:下面这两句会引发 NullReferenceException 异常，不知道怎么回事                
                //m_AppProcess.Exited += new EventHandler(m_AppProcess_Exited);
                //m_AppProcess.EnableRaisingEvents = true;
                Application.Idle += appIdleEvent;
            }
            catch (Exception ex)
            {
                //嵌入失败杀死进程
                if (_AppProcess != null)
                {
                    if (!_AppProcess.HasExited)
                        _AppProcess.Kill();
                    _AppProcess = null;
                }
            }
        }
        /// <summary>
        /// 重新嵌入
        /// </summary>
        public void ReEmbed()
        {
            EmbedProcess(_AppProcess, this);
        }
        /// <summary>
        /// 退出嵌入的程序
        /// </summary>
        public void Stop()
        {
            if (_AppProcess != null)// && m_AppProcess.MainWindowHandle != IntPtr.Zero)
            {
                try
                {
                    if (!_AppProcess.HasExited)
                        _AppProcess.Kill();
                }
                catch (Exception) { }
                _AppProcess = null;
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
            if (_AppProcess != null)
            {
                MoveWindow(_AppProcess.MainWindowHandle, 0, 0, this.Width, this.Height, true);
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
