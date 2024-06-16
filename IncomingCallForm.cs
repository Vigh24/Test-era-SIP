using System;
using System.Windows.Forms;
using PortSIP;

namespace EratronicsPhone
{
    public partial class IncomingCallForm : Form
    {
        private int _sessionId;
        private PortSIPLib _sdkLib;

        public IncomingCallForm(int sessionId, string callerDisplayName, PortSIPLib sdkLib)
        {
            InitializeComponent();
            _sessionId = sessionId;
            _sdkLib = sdkLib;
            lblCaller.Text = $"Incoming call from {callerDisplayName}";
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            _sdkLib.answerCall(_sessionId, false); // Answer the call without video
            MessageBox.Show("Call accepted.");
            btnHangUp.Enabled = true;
            btnAnswer.Enabled = false;
            btnReject.Enabled = false;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            _sdkLib.rejectCall(_sessionId, 486); // Reject the call
            MessageBox.Show("Call rejected.");
            this.Close();
        }

        private void btnHangUp_Click(object sender, EventArgs e)
        {
            _sdkLib.hangUp(_sessionId);
            MessageBox.Show("Call ended.");
            this.Close();
        }

        public void AutoAnswerCall()
        {
            btnAnswer_Click(this, EventArgs.Empty);
        }
    }
}