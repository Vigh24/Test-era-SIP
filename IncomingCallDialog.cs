using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIPSample
{
    // IncomingCallDialog.cs
    public partial class IncomingCallDialog : Form
    {
        public IncomingCallDialog()
        {
            InitializeComponent();
        }

        public event EventHandler AnswerClicked;
        public event EventHandler RejectClicked;

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            AnswerClicked?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            RejectClicked?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
