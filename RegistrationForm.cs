using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PortSIP;

namespace SIPSample
{
    public partial class RegistrationForm : Form, SIPCallbackEvents
    {
        private Form1 _mainForm;
        private PortSIPLib _sdkLib;
        private bool _SIPInited = false;
        private bool _SIPLogined = false;

        private Button btnDeregister;

        // Properties to store user data
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServerAddress { get; set; }
        public int ServerPort { get; set; }
        public string StunServer { get; set; }
        public int StunServerPort { get; set; }

        public RegistrationForm(Form1 mainForm, PortSIPLib sdkLib)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _sdkLib = sdkLib;
            InitializeDeregisterButton();

            TextBoxPassword.PasswordChar = '*';

            // Populate the ComboBox with transport options
            ComboBoxTransport.Items.Add("UDP");
            ComboBoxTransport.Items.Add("TLS");
            ComboBoxTransport.Items.Add("TCP");
            ComboBoxTransport.Items.Add("PERS");
            ComboBoxTransport.SelectedIndex = 0; // Default to UDP

            // Initialize properties with default values or from configuration
            UserName = ""; // Default or loaded from configuration
            Password = "";
            ServerAddress = "";
            ServerPort = 0;
            StunServer = "";
            StunServerPort = 0;

            this.Shown += new EventHandler(RegistrationForm_Shown);
        }

        private void InitializeDeregisterButton()
        {
            btnDeregister = new Button();
            btnDeregister.Text = "Deregister";
            btnDeregister.Location = new Point(100, 296); // Adjust location according to your layout
            btnDeregister.Size = new Size(75, 23);
            btnDeregister.Click += new EventHandler(ButtonDeregister_Click);
            this.Controls.Add(btnDeregister);
        }

        private void ButtonDeregister_Click(object sender, EventArgs e)
        {
            if (!_SIPInited)
            {
                MessageBox.Show("SIP is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int rt = _sdkLib.unRegisterServer(1000); // Adjust the timeout as needed
            if (rt != 0)
            {
                MessageBox.Show($"Failed to deregister. Error code: {rt}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Deregistration succeeded.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _SIPLogined = false; // Update the login status
            }
        }

        private void RegistrationForm_Shown(object sender, EventArgs e)
        {
            // Repopulate fields if properties have values
            TextBoxUserName.Text = UserName;
            TextBoxPassword.Text = Password;
            TextBoxServer.Text = ServerAddress;
            TextBoxServerPort.Text = ServerPort > 0 ? ServerPort.ToString() : "";
            TextBoxStunServer.Text = StunServer;
            TextBoxStunPort.Text = StunServerPort > 0 ? StunServerPort.ToString() : "";
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (_SIPInited)
            {
                MessageBox.Show("SDK already initialized.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Debugging: Check if any TextBox is null
            if (TextBoxUserName == null) MessageBox.Show("TextBoxUserName is null");
            if (TextBoxPassword == null) MessageBox.Show("TextBoxPassword is null");
            if (TextBoxServer == null) MessageBox.Show("TextBoxServer is null");
            if (TextBoxServerPort == null) MessageBox.Show("TextBoxServerPort is null");

            // Ensure all TextBoxes are initialized and not empty
            if (TextBoxUserName == null || string.IsNullOrWhiteSpace(TextBoxUserName.Text) ||
                TextBoxPassword == null || string.IsNullOrWhiteSpace(TextBoxPassword.Text) ||
                TextBoxServer == null || string.IsNullOrWhiteSpace(TextBoxServer.Text) ||
                TextBoxServerPort == null || string.IsNullOrWhiteSpace(TextBoxServerPort.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int SIPServerPort;
            if (!int.TryParse(TextBoxServerPort.Text, out SIPServerPort))
            {
                MessageBox.Show("Invalid Server Port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int StunServerPort = 0;
            if (!string.IsNullOrWhiteSpace(TextBoxStunPort.Text))
            {
                if (!int.TryParse(TextBoxStunPort.Text, out StunServerPort) || StunServerPort > 65535 || StunServerPort <= 0)
                {
                    MessageBox.Show("The Stun server port is out of range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            // Random port for local SIP (similar to Form1.cs logic)
            Random rd = new Random();
            int LocalSIPPort = rd.Next(1000, 5000) + 4000;

            // Determine transport type based on user selection
            TRANSPORT_TYPE transportType = TRANSPORT_TYPE.TRANSPORT_UDP;
            switch (ComboBoxTransport.SelectedIndex)
            {
                case 0:
                    transportType = TRANSPORT_TYPE.TRANSPORT_UDP;
                    break;
                case 1:
                    transportType = TRANSPORT_TYPE.TRANSPORT_TLS;
                    break;
                case 2:
                    transportType = TRANSPORT_TYPE.TRANSPORT_TCP;
                    break;
                case 3:
                    transportType = TRANSPORT_TYPE.TRANSPORT_PERS;
                    break;
                default:
                    MessageBox.Show("The transport is wrong.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }

            // Initialize the SDK
            _sdkLib = new PortSIPLib(this);
            _sdkLib.createCallbackHandlers();
            string logFilePath = "d:\\PortSIPLog.txt";  // Ensure this path exists
            int rt = _sdkLib.initialize(transportType, "0.0.0.0", LocalSIPPort, PORTSIP_LOG_LEVEL.PORTSIP_LOG_NONE, logFilePath, 8, "PortSIP VoIP SDK", 0, 0, "/", "", false);

            if (rt != 0)
            {
                MessageBox.Show($"Failed to initialize SDK. Error code: {rt}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SIPInited = true;

            // Set user credentials
            rt = _sdkLib.setUser(TextBoxUserName.Text, "", "", TextBoxPassword.Text, "", TextBoxServer.Text, SIPServerPort, TextBoxStunServer.Text, StunServerPort, "", 0);
            if (rt != 0)
            {
                _sdkLib.unInitialize();
                MessageBox.Show($"Failed to set user information. Error code: {rt}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Set the license key
            string licenseKey = "PORTSIP_TEST_LICENSE";  // Replace with your actual license key
            rt = _sdkLib.setLicenseKey(licenseKey);
            if (rt == PortSIP_Errors.ECoreTrialVersionLicenseKey)
            {
                MessageBox.Show("This sample was built based on evaluation PortSIP VoIP SDK, which allows only three minutes conversation. The conversation will be cut off automatically after three minutes, then you can't hear anything. Feel free to contact us at: sales@portsip.com to purchase the official version.");
            }
            else if (rt == PortSIP_Errors.ECoreWrongLicenseKey)
            {
                MessageBox.Show("The wrong license key was detected, please check with sales@portsip.com or support@portsip.com");
            }
            else if (rt != 0)
            {
                _sdkLib.unInitialize();
                MessageBox.Show($"Failed to set license key. Error code: {rt}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Register with the server
            rt = _sdkLib.registerServer(120, 0);
            if (rt != 0)
            {
                _sdkLib.unInitialize();
                MessageBox.Show($"Failed to register with the server. Error code: {rt}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SIPLogined = true;
            MessageBox.Show("Registration succeeded.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // After successful registration, update the main form's _sdkLib instance
            _mainForm.UpdateSdkLib(_sdkLib);
            _mainForm.SetSIPInited(true);
            _mainForm.SetSIPLogined(true);

            // Initialize SIP in the main form
            _mainForm.InitializeSIP();

            MessageBox.Show("Registration succeeded.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TextBoxUserName_TextChanged(object sender, EventArgs e)
        {
            UserName = TextBoxUserName.Text;
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            Password = TextBoxPassword.Text;
        }

        private void TextBoxServer_TextChanged(object sender, EventArgs e)
        {
            ServerAddress = TextBoxServer.Text;
        }

        private void TextBoxServerPort_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TextBoxServerPort.Text, out int port))
            {
                ServerPort = port;
            }
        }

        private void TextBoxStunServer_TextChanged(object sender, EventArgs e)
        {
            StunServer = TextBoxStunServer.Text;
        }

        private void TextBoxStunPort_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TextBoxStunPort.Text, out int port))
            {
                StunServerPort = port;
            }
        }

        public int onRegisterSuccess(string statusText, int statusCode, StringBuilder sipMessage)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add("Registration succeeded");
            }));
            _SIPLogined = true;
            return 0;
        }

        public int onRegisterFailure(string statusText, int statusCode, StringBuilder sipMessage)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add("Registration failed");
            }));
            _SIPLogined = false;
            return 0;
        }

        public int onInviteTrying(int sessionId)
        {
            // Implementation code here
            return 0;
        }

        public int onInviteIncoming(int sessionId, string callerDisplayName, string caller, string calleeDisplayName, string callee, string audioCodecNames, string videoCodecNames, bool existsAudio, bool existsVideo, StringBuilder sipMessage)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Always show the IncomingCallForm
                IncomingCallForm incomingCallForm = new IncomingCallForm(sessionId, callerDisplayName, _sdkLib);
                incomingCallForm.Show();

                // Check if Auto Answer is enabled
                if (_mainForm.CheckBoxAA.Checked)
                {
                    incomingCallForm.AutoAnswerCall();
                }
            });
            return 0;
        }

        public int onInviteSessionProgress(int sessionId, string callerDisplayName, string caller, bool existsAudio, bool existsVideo, bool existsScreen, StringBuilder sipMessage)
        {
            // Implementation code here
            return 0;
        }

        public int onInviteRinging(int sessionId, string statusText, int statusCode, StringBuilder sipMessage)
        {
            // Implementation code here
            return 0;
        }

        public int onInviteAnswered(int sessionId, string callerDisplayName, string caller, string calleeDisplayName, string callee, string audioCodecNames, string videoCodecNames, bool existsAudio, bool existsVideo, StringBuilder sipMessage)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add($"Call answered by {calleeDisplayName}");
            }));
            return 0;
        }

        public int onInviteFailure(int sessionId, string reason, string statusText, string callerDisplayName, string caller, string calleeDisplayName, int statusCode, StringBuilder sipMessage)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add($"Call failed: {reason}");
            }));
            return 0;
        }

        public int onInviteUpdated(int sessionId, string audioCodecNames, string videoCodecNames, bool existsAudio, bool existsVideo, bool existsScreen, StringBuilder sipMessage)
        {
            // Implementation code here
            return 0;
        }

        public int onInviteClosed(int sessionId)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add($"Invite session closed for session ID: {sessionId}");
            }));
            return 0;
        }

        public int onInviteConnected(int sessionId)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add("Call connected");
            }));
            return 0;
        }

        public int onInviteBeginingForward(string forwardTo)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add($"Beginning to forward call to: {forwardTo}");
            }));
            return 0;
        }

        public int onDialogStateUpdated(string callid, string localTag, string remoteTag, string state)
        {
            // Implementation code here
            return 0;
        }

        public int onRemoteHold(int sessionId)
        {
            // Implementation code here
            return 0;
        }

        public int onRemoteUnHold(int sessionId, string audioCodecNames, string videoCodecNames, bool existsAudio, bool existsVideo)
        {
            // Implementation code here
            return 0;
        }

        public int onReceivedRefer(int sessionId, int referId, string to, string from, StringBuilder referSipMessage)
        {
            // Implementation code here
            return 0;
        }

        public int onReferAccepted(int referId)
        {
            // Implementation code here
            return 0;
        }

        public int onReferRejected(int referId, string reason, int code)
        {
            // Implementation code here
            return 0;
        }

        public int onTransferTrying(int sessionId)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add($"Transfer trying for session ID: {sessionId}");
            }));
            return 0;
        }

        public int onTransferRinging(int sessionId)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                ListBoxSIPLog.Items.Add($"Transfer ringing for session ID: {sessionId}");
            }));
            return 0;
        }

        public int onACTVTransferSuccess(int sessionId)
        {
            // Implementation code here
            return 0;
        }

        public int onACTVTransferFailure(int sessionId, string reason, int code)
        {
            // Implementation code here
            return 0;
        }

        public int onReceivedSignaling(int sessionId, StringBuilder signaling)
        {
            // Implementation code here
            return 0;
        }

        public int onSendingSignaling(int sessionId, StringBuilder signaling)
        {
            // Implementation code here
            return 0;
        }

        public int onWaitingVoiceMessage(string messageAccount, int urgentNewMessageCount, int urgentOldMessageCount, int newMessageCount, int oldMessageCount)
        {
            // Implementation code here
            return 0;
        }

        public int onWaitingFaxMessage(string messageAccount, int urgentNewMessageCount, int urgentOldMessageCount, int newMessageCount, int oldMessageCount)
        {
            // Implementation code here
            return 0;
        }

        public int onRecvDtmfTone(int sessionId, int tone)
        {
            // Implementation code here
            return 0;
        }

        public int onRecvOptions(StringBuilder optionsMessage)
        {
            // Implementation code here
            return 0;
        }

        public int onRecvInfo(StringBuilder infoMessage)
        {
            // Implementation code here
            return 0;
        }

        public int onRecvNotifyOfSubscription(int subscribeId, StringBuilder notifyMessage, byte[] messageData, int messageDataLength)
        {
            // Implementation code here
            return 0;
        }

        public int onSubscriptionFailure(int subscribeId, int statusCode)
        {
            // Implementation code here
            return 0;
        }

        public int onSubscriptionTerminated(int subscribeId)
        {
            // Implementation code here
            return 0;
        }

        public int onPresenceRecvSubscribe(int subscribeId, string fromDisplayName, string from, string subject)
        {
            // Implementation code here
            return 0;
        }

        public int onPresenceOnline(string fromDisplayName, string from, string stateText)
        {
            // Implementation code here
            return 0;
        }

        public int onPresenceOffline(string fromDisplayName, string from)
        {
            // Implementation code here
            return 0;
        }

        public int onRecvMessage(int sessionId, string mimeType, string subMimeType, byte[] messageData, int messageDataLength)
        {
            if (_SIPLogined)
            {
                _sdkLib.unRegisterServer(1000); // Adjust the timeout parameter as needed
                _sdkLib.unInitialize();
                _SIPLogined = false;
                _SIPInited = false;
            }
            else if (_SIPInited)
            {
                _sdkLib.unInitialize();
                _SIPInited = false;
            }
            return 0;
        }

        public int onRecvOutOfDialogMessage(string from, string to, string mimeType, string subMimeType, string subject, string contentType, byte[] messageData, int messageDataLength)
        {
            // Implementation code here
            return 0;
        }

        public int onSendMessageSuccess(int sessionId, int messageId)
        {
            // Implementation code here
            return 0;
        }

        public int onSendMessageFailure(int sessionId, int messageId, string reason, int code)
        {
            // Implementation code here
            return 0;
        }

        public int onSendOutOfDialogMessageSuccess(int messageId, string from, string to, string mimeType, string subMimeType)
        {
            // Implementation code here
            return 0;
        }

        public int onSendOutOfDialogMessageFailure(int messageId, string from, string to, string mimeType, string subMimeType, string reason, int code)
        {
            // Implementation code here
            return 0;
        }

        public int onPlayFileFinished(int sessionId, string fileName)
        {
            // Implementation code here
            return 0;
        }

        public int onStatistics(int sessionId, string statistics)
        {
            // Implementation code here
            return 0;
        }

        public int onRTPPacketCallback(IntPtr callbackObject, int callbackType, int sessionId, int isVideo, byte[] packet, int packetLength)
        {
            // Implementation code here
            return 0;
        }

        public int onAudioRawCallback(IntPtr callbackObject, int sessionId, int callbackType, byte[] data, int dataLength, int samplingFreqHz)
        {
            // Implementation code here
            return 0;
        }

        public int onVideoRawCallback(IntPtr callbackObject, int sessionId, int callbackType, int width, int height, byte[] data, int dataLength)
        {
            // Implementation code here
            return 0;
        }

        public int onScreenRawCallback(IntPtr callbackObject, int sessionId, int callbackType, int width, int height, byte[] data, int dataLength)
        {
            // Implementation code here
            return 0;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Prevent deregistration on form close
            if (_SIPInited)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
    }
}
