using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Y.Utils.WindowsUtils.HookUtils
{
    public class UserActivityHook
    {

        private Module AppModule;

        /// <summary>
        /// Default constructor - starts hooks automatically
        /// </summary>
        public UserActivityHook(Module module)
        {
            AppModule = module;
            Start();
        }

        ~UserActivityHook()
        {
            Stop();
        }

        public event MouseEventHandler OnMouseActivity;
        public event KeyEventHandler KeyDown;
        public event KeyPressEventHandler KeyPress;
        public event KeyEventHandler KeyUp;

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        static int hMouseHook = 0; //Declare mouse hook handle as int.
        static int hKeyboardHook = 0; //Declare keyboard hook handle as int.

        //values from Winuser.h in Microsoft SDK.
        public const int WH_MOUSE_LL = 14;  //mouse hook constant
        public const int WH_KEYBOARD_LL = 13;   //keyboard hook constant	

        HookProc MouseHookProcedure; //Declare MouseHookProcedure as HookProc type.
        HookProc KeyboardHookProcedure; //Declare KeyboardHookProcedure as HookProc type.


        //Declare wrapper managed POINT class.
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        //Declare wrapper managed MouseHookStruct class.
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        //Declare wrapper managed KeyboardHookStruct class.
        [StructLayout(LayoutKind.Sequential)]
        public class KeyboardHookStruct
        {
            public int vkCode;  //Specifies a virtual-key code. The code must be a value in the range 1 to 254. 
            public int scanCode; // Specifies a hardware scan code for the key. 
            public int flags;  // Specifies the extended-key flag, event-injected flag, context code, and transition-state flag.
            public int time; // Specifies the time stamp for this message.
            public int dwExtraInfo; // Specifies extra information associated with the message. 
        }


        //Import for SetWindowsHookEx function.
        //Use this function to install a hook.
        [DllImport("user32.dll", CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn,
            IntPtr hInstance, int threadId);

        //Import for UnhookWindowsHookEx.
        //Call this function to uninstall the hook.
        [DllImport("user32.dll", CharSet = CharSet.Auto,
             CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        //Import for CallNextHookEx.
        //Use this function to pass the hook information to next hook procedure in chain.
        [DllImport("user32.dll", CharSet = CharSet.Auto,
             CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode,
            Int32 wParam, IntPtr lParam);

        public void Start()
        {
            // install Mouse hook 
            if (hMouseHook == 0)
            {
                // Create an instance of HookProc.
                MouseHookProcedure = new HookProc(MouseHookProc);

                hMouseHook = SetWindowsHookEx(WH_MOUSE_LL,
                    MouseHookProcedure,
                    Marshal.GetHINSTANCE(AppModule),
                    0);

                //If SetWindowsHookEx fails.
                if (hMouseHook == 0)
                {
                    Stop();
                    throw new Exception("SetWindowsHookEx failed.");
                }
            }

            // install Keyboard hook 
            if (hKeyboardHook == 0)
            {
                KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL,
                    KeyboardHookProcedure,
                    Marshal.GetHINSTANCE(AppModule),
                    0);

                //If SetWindowsHookEx fails.
                if (hKeyboardHook == 0)
                {
                    Stop();
                    throw new Exception("SetWindowsHookEx ist failed.");
                }
            }
        }

        public void Stop()
        {
            bool retMouse = true;
            bool retKeyboard = true;
            if (hMouseHook != 0)
            {
                retMouse = UnhookWindowsHookEx(hMouseHook);
                hMouseHook = 0;
            }

            if (hKeyboardHook != 0)
            {
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                hKeyboardHook = 0;
            }

            //If UnhookWindowsHookEx fails.
            if (!(retMouse && retKeyboard)) throw new Exception("UnhookWindowsHookEx failed.");
        }



        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDBLCLK = 0x209;

        private int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // if ok and someone listens to our events
            if ((nCode >= 0) && (OnMouseActivity != null))
            {

                MouseButtons button = MouseButtons.None;
                switch (wParam)
                {
                    case WM_LBUTTONDOWN:
                        //case WM_LBUTTONUP: 
                        //case WM_LBUTTONDBLCLK: 
                        button = MouseButtons.Left;
                        break;
                    case WM_RBUTTONDOWN:
                        //case WM_RBUTTONUP: 
                        //case WM_RBUTTONDBLCLK: 
                        button = MouseButtons.Right;
                        break;
                }
                int clickCount = 0;
                if (button != MouseButtons.None)
                    if (wParam == WM_LBUTTONDBLCLK || wParam == WM_RBUTTONDBLCLK) clickCount = 2;
                    else clickCount = 1;

                //Marshall the data from callback.
                MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                MouseEventArgs e = new MouseEventArgs(
                                                    button,
                                                    clickCount,
                                                    MyMouseHookStruct.pt.x,
                                                    MyMouseHookStruct.pt.y,
                                                    0);
                OnMouseActivity(this, e);
            }
            return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
        }


        //The ToAscii function translates the specified virtual-key code and keyboard state to the corresponding character or characters. The function translates the code using the input language and physical keyboard layout identified by the keyboard layout handle.
        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, //[in] Specifies the virtual-key code to be translated. 
                                         int uScanCode, // [in] Specifies the hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up (not pressed). 
                                         byte[] lpbKeyState, // [in] Pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of one key. If the high-order bit of a byte is set, the key is down (pressed). The low bit, if set, indicates that the key is toggled on. In this function, only the toggle bit of the CAPS LOCK key is relevant. The toggle state of the NUM LOCK and SCROLL LOCK keys is ignored.
                                         byte[] lpwTransKey, // [out] Pointer to the buffer that receives the translated character or characters. 
                                         int fuState); // [in] Specifies whether a menu is active. This parameter must be 1 if a menu is active, or 0 otherwise. 

        //The GetKeyboardState function copies the status of the 256 virtual keys to the specified buffer. 
        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x105;

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            // it was ok and someone listens to events
            if ((nCode >= 0) && (KeyDown != null || KeyUp != null || KeyPress != null))
            {
                KeyboardHookStruct MyKeyboardHookStruct = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));
                // raise KeyDown
                if (KeyDown != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyDown(this, e);
                }

                // raise KeyPress
                if (KeyPress != null && wParam == WM_KEYDOWN)
                {
                    byte[] keyState = new byte[256];
                    GetKeyboardState(keyState);

                    byte[] inBuffer = new byte[2];
                    if (ToAscii(MyKeyboardHookStruct.vkCode,
                            MyKeyboardHookStruct.scanCode,
                            keyState,
                            inBuffer,
                            MyKeyboardHookStruct.flags) == 1)
                    {
                        KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
                        KeyPress(this, e);
                    }
                }

                // raise KeyUp
                if (KeyUp != null && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))
                {
                    Keys keyData = (Keys)MyKeyboardHookStruct.vkCode;
                    KeyEventArgs e = new KeyEventArgs(keyData);
                    KeyUp(this, e);
                }

            }
            return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
        }
    }
}
