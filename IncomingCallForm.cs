using System;
using System.Windows.Forms;
using PortSIP;
using ComponentFactory.Krypton.Toolkit;

namespace EratronicsPhone
{
    public partial class IncomingCallForm : KryptonForm
    {
        private int _sessionId;
        private PortSIPLib _sdkLib;

        public IncomingCallForm(int sessionId, string callerDisplayName, PortSIPLib sdkLib)
        {
            InitializeComponent();
            _sessionId = sessionId;
            _sdkLib = sdkLib;
            lblCaller.Text = $"Incoming call from {callerDisplayName}";

            // Subscribe to the public event handler for call termination
            _sdkLib.OnInviteClosedPublic += OnRemoteHangUp;
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

        // Event handler for remote hang up
        private void OnRemoteHangUp(int sessionId)
        {
            if (sessionId == _sessionId)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    //MessageBox.Show("Call ended by remote user.");
                    this.Close();
                });
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Unsubscribe from the public event handler when the form is closing
            _sdkLib.OnInviteClosedPublic -= OnRemoteHangUp;
        }
    }
}