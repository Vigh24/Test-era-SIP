using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EratronicsPhone
{
    public partial class videoScreen : Form
    {
        public videoScreen()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public IntPtr GetHandle()
        {
            return Handle;
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.Hide();//esc隐藏窗体
                        break;
                }
            }
            return false;
        }
    }
}
