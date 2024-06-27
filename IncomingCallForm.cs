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
        private Form1 _mainForm;
        private RegistrationForm _registrationForm;

        public event EventHandler<bool> CallStateChanged;

        public IncomingCallForm(int sessionId, string callerName, PortSIPLib sdkLib, Form1 mainForm, RegistrationForm registrationForm)
        {
            InitializeComponent();
            _sessionId = sessionId;
            _sdkLib = sdkLib;
            _mainForm = mainForm;
            _registrationForm = registrationForm;
            lblCaller.Text = $"Incoming call from: {callerName}";
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"Answering call for SessionID: {_sessionId}");
            _sdkLib.answerCall(_sessionId, false); // Answer the call without video
            MessageBox.Show("Call accepted.");
            CallStateChanged?.Invoke(this, true);
            _mainForm.UpdateCallState(_sessionId, true);
            _registrationForm.UpdateCallState(_sessionId, true);
            Console.WriteLine($"Call answered and state updated for SessionID: {_sessionId}");
            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            _sdkLib.rejectCall(_sessionId, 486);
            MessageBox.Show("Call rejected.");
            CallStateChanged?.Invoke(this, false);
            _mainForm.UpdateCallState(_sessionId, false);
            _registrationForm.UpdateCallState(_sessionId, false);
            this.Close();
        }

        private void btnHangUp_Click(object sender, EventArgs e)
        {
            _sdkLib.hangUp(_sessionId);
            MessageBox.Show("Call ended.");
            CallStateChanged?.Invoke(this, false);
            _mainForm.UpdateCallState(_sessionId, false);
            _registrationForm.UpdateCallState(_sessionId, false);
            this.Close();
        }

        public void AutoAnswerCall()
        {
            Console.WriteLine($"Auto-answering call for SessionID: {_sessionId}");
            _sdkLib.answerCall(_sessionId, false); // Answer the call without video
            CallStateChanged?.Invoke(this, true);
            _mainForm.UpdateCallState(_sessionId, true);
            _registrationForm.UpdateCallState(_sessionId, true);
            Console.WriteLine($"Call auto-answered and state updated for SessionID: {_sessionId}");
            this.Close();
        }
    }
}