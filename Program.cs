using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading; // Added this line
using System.Runtime.InteropServices;

namespace EratronicsPhone
{
    static class Program
    {
        private const string MutexName = "{EC0E6B50-9AEE-4983-BB1E-6CD3B022D3A3}";
        private const string WindowMessage = "EratronicsPhoneShowWindow";
        private static readonly int WM_SHOWME = RegisterWindowMessage(WindowMessage);

        [STAThread]
        static void Main()
        {
            bool createdNew;
            using (Mutex mutex = new Mutex(true, MutexName, out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                else
                {
                    PostMessage((IntPtr)HWND_BROADCAST, WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
                }
            }
        }

        [DllImport("user32")]
        private static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string message);

        private const int HWND_BROADCAST = 0xffff;
    }

    static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public const int SW_RESTORE = 9;
    }
}