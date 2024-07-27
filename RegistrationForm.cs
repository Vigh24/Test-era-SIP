using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PortSIP;
using ComponentFactory.Krypton.Toolkit;

namespace EratronicsPhone
{
    public partial class RegistrationForm : KryptonForm, SIPCallbackEvents
    {
        private Form1 _mainForm;
        private PortSIPLib _sdkLib;
        private bool _SIPInited = false;
        private static bool _SIPLogined = false;
        private IncomingCallForm _incomingCallForm;

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

            ComboBoxTransport.Items.AddRange(new object[] { "UDP", "TLS", "TCP", "PERS" });
            ComboBoxTransport.SelectedIndex = 0;

            LoadSettings();

            this.Shown += new EventHandler(RegistrationForm_Shown);
        }

        public RegistrationForm(Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void LoadSettings()
        {
            UserName = Properties.Settings.Default.UserName;
            Password = Properties.Settings.Default.Password;
            ServerAddress = Properties.Settings.Default.ServerAddress;
            ServerPort = int.TryParse(Properties.Settings.Default.ServerPort, out int serverPort) ? serverPort : 0;
            StunServer = Properties.Settings.Default.StunServer;
            StunServerPort = int.TryParse(Properties.Settings.Default.StunServerPort, out int stunServerPort) ? stunServerPort : 0;

            // Populate the form fields with the loaded settings
            TextBoxUserName.Text = UserName;
            TextBoxPassword.Text = Password;
            TextBoxServer.Text = ServerAddress;
            TextBoxServerPort.Text = ServerPort > 0 ? ServerPort.ToString() : "";
            TextBoxStunServer.Text = StunServer;
            TextBoxStunPort.Text = StunServerPort > 0 ? StunServerPort.ToString() : "";
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.UserName = TextBoxUserName.Text;
            Properties.Settings.Default.Password = TextBoxPassword.Text;
            Properties.Settings.Default.ServerAddress = TextBoxServer.Text;
            Properties.Settings.Default.ServerPort = TextBoxServerPort.Text;
            Properties.Settings.Default.StunServer = TextBoxStunServer.Text;
            Properties.Settings.Default.StunServerPort = TextBoxStunPort.Text;
            Properties.Settings.Default.Save();
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
                AutoClosingMessageBox.Show("SIP is not initialized.", "Error", 3000);
                return;
            }

            int rt = _sdkLib.unRegisterServer(1000); // Adjust the timeout as needed
            if (rt != 0)
            {
                AutoClosingMessageBox.Show($"Failed to deregister. Error code: {rt}", "Error", 3000);
            }
            else
            {
                AutoClosingMessageBox.Show("Deregistration succeeded.", "Information", 3000);
                _SIPLogined = false; // Update the login status
                _SIPInited = false;
                _mainForm.SetSIPLogined(false);
                _mainForm.SetSIPInited(false);
                EnableInputFields(); // Enable the input fields after deregistration
            }
        }

        private void EnableInputFields()
        {
            TextBoxUserName.Enabled = true;
            TextBoxPassword.Enabled = true;
            TextBoxServer.Enabled = true;
            TextBoxServerPort.Enabled = true;
            TextBoxStunServer.Enabled = true;
            TextBoxStunPort.Enabled = true;
            ComboBoxTransport.Enabled = true;
            ButtonRegister.Enabled = true;
            btnDeregister.Enabled = false; // Disable the deregister button
        }

        private void RegistrationForm_Shown(object sender, EventArgs e)
        {
            TextBoxUserName.Text = UserName;
            TextBoxPassword.Text = Password;
            TextBoxServer.Text = ServerAddress;
            TextBoxServerPort.Text = ServerPort > 0 ? ServerPort.ToString() : "";
            TextBoxStunServer.Text = StunServer;
            TextBoxStunPort.Text = StunServerPort > 0 ? StunServerPort.ToString() : "";
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            PerformRegistration();
        }

        private bool PerformRegistration()
        {
            // Check if already logged in
            if (Form1.GetSIPLogined())
            {
                AutoClosingMessageBox.Show("Already registered.", "Warning", 3000);
                return false;
            }

            if (_SIPInited)
            {
                AutoClosingMessageBox.Show("SDK already initialized.", "Warning", 3000);
                return false;
            }

            // Debugging: Check if any TextBox is null
            if (TextBoxUserName == null) AutoClosingMessageBox.Show("TextBoxUserName is null", "Error", 3000);
            if (TextBoxPassword == null) AutoClosingMessageBox.Show("TextBoxPassword is null", "Error", 3000);
            if (TextBoxServer == null) AutoClosingMessageBox.Show("TextBoxServer is null", "Error", 3000);
            if (TextBoxServerPort == null) AutoClosingMessageBox.Show("TextBoxServerPort is null", "Error", 3000);

            // Ensure all TextBoxes are initialized and not empty
            if (TextBoxUserName == null || string.IsNullOrWhiteSpace(TextBoxUserName.Text) ||
                TextBoxPassword == null || string.IsNullOrWhiteSpace(TextBoxPassword.Text) ||
                TextBoxServer == null || string.IsNullOrWhiteSpace(TextBoxServer.Text) ||
                TextBoxServerPort == null || string.IsNullOrWhiteSpace(TextBoxServerPort.Text))
            {
                AutoClosingMessageBox.Show("Please fill in all required fields.", "Error", 3000);
                return false;
            }

            int SIPServerPort;
            if (!int.TryParse(TextBoxServerPort.Text, out SIPServerPort))
            {
                AutoClosingMessageBox.Show("Invalid Server Port.", "Error", 3000);
                return false;
            }

            int StunServerPort = 0;
            if (!string.IsNullOrWhiteSpace(TextBoxStunPort.Text))
            {
                if (!int.TryParse(TextBoxStunPort.Text, out StunServerPort) || StunServerPort > 65535 || StunServerPort < 0)
                {
                    AutoClosingMessageBox.Show("The Stun server port is out of range.", "Information", 3000);
                    return false;
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
                    AutoClosingMessageBox.Show("The transport is wrong.", "Information", 3000);
                    return false;
            }

            // Initialize the SDK
            _sdkLib = new PortSIPLib(this);
            _sdkLib.createCallbackHandlers();
            string logFilePath = "d:\\PortSIPLog.txt";  // Ensure this path exists
            int rt = _sdkLib.initialize(transportType, "0.0.0.0", LocalSIPPort, PORTSIP_LOG_LEVEL.PORTSIP_LOG_NONE, logFilePath, 8, "PortSIP VoIP SDK", 0, 0, "/", "", false);

            if (rt != 0)
            {
                AutoClosingMessageBox.Show($"Failed to initialize SDK. Error code: {rt}", "Error", 3000);
                return false;
            }

            _SIPInited = true;

            // Set user credentials
            rt = _sdkLib.setUser(TextBoxUserName.Text, "", "", TextBoxPassword.Text, "", TextBoxServer.Text, SIPServerPort, TextBoxStunServer.Text, StunServerPort, "", 0);
            if (rt != 0)
            {
                _sdkLib.unInitialize();
                AutoClosingMessageBox.Show($"Failed to set user information. Error code: {rt}", "Error", 3000);
                return false;
            }

            // Set the license key
            string licenseKey = "PORTSIP_TEST_LICENSE";  // Replace with your actual license key
            rt = _sdkLib.setLicenseKey(licenseKey);
            if (rt == PortSIP_Errors.ECoreTrialVersionLicenseKey)
            {
                //AutoClosingMessageBox.Show("Thank you for using our Eratronics Softphone Application.", "Registration Successful", 1000); // 3000 ms = 3 seconds
            }
            else if (rt == PortSIP_Errors.ECoreWrongLicenseKey)
            {
                AutoClosingMessageBox.Show("The wrong license key was detected, please check with sales@portsip.com or support@portsip.com", "Error", 3000);
            }
            else if (rt != 0)
            {
                _sdkLib.unInitialize();
                AutoClosingMessageBox.Show($"Failed to set license key. Error code: {rt}", "Error", 3000);
                return false;
            }

            // Register with the server
            rt = _sdkLib.registerServer(120, 0);
            if (rt != 0)
            {
                _sdkLib.unInitialize();
                AutoClosingMessageBox.Show($"Failed to register with the server. Error code: {rt}", "Error", 3000);
                return false;
            }

            _SIPLogined = true;
            //AutoClosingMessageBox.Show("Registration succeeded.", "Information", 1000);

            // After successful registration, update the main form's _sdkLib instance
            _mainForm.UpdateSdkLib(_sdkLib);
            _mainForm.SetSIPInited(true);
            _mainForm.SetSIPLogined(true);

            // Initialize SIP in the main form
            _mainForm.InitializeSIP();

            // Save settings after successful registration
            SaveSettings();

            // Update the username in Form1
            _mainForm.SetSIPLogined(true, TextBoxUserName.Text);

            // Optionally, you can hide the registration form here
            this.Hide();

            // After successful registration
            _mainForm.UpdateUsername(UserName); // Assuming UserName is the variable holding the registered username

            return true;
        }

        public void AutoRegisterSilently()
        {
            LoadSettings();

            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ServerAddress))
            {
                // Perform registration without showing the form
                if (PerformRegistration())
                {
                    DisableInputFields();
                    btnDeregister.Enabled = true;
                }
            }
            else
            {
                // Show the form on the UI thread when it's safe to do so
                ShowRegistrationForm();
            }
        }

        private void ShowRegistrationForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ShowRegistrationForm));
            }
            else
            {
                this.Show();
                MessageBox.Show("Please enter your SIP account details and click Register.", "Registration Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            if (this.IsHandleCreated)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    AutoClosingMessageBox.Show("Thank you for using our Eratronics Softphone Application.", "Registration Successful", 3000);

                    _SIPLogined = true;
                    _SIPInited = true;
                    _mainForm.SetSIPLogined(true, UserName);
                    _mainForm.SetSIPInited(true);
                    _mainForm.InitializeSIP();
                    DisableInputFields();
                    btnDeregister.Enabled = true; // Enable the deregister button

                    // Update the username in the main form
                    _mainForm.UpdateUsername(UserName);

                    // Hide this form
                    this.Hide();
                });
            }
            else
            {
                // Handle the case when the form is not yet created
                _SIPLogined = true;
                _SIPInited = true;
                _mainForm.SetSIPLogined(true, UserName);
                _mainForm.SetSIPInited(true);
                _mainForm.InitializeSIP();

                // Update the username in the main form
                _mainForm.UpdateUsername(UserName);
            }
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
            Console.WriteLine($"Incoming call received: SessionID = {sessionId}");

            Action handleIncomingCall = () =>
            {
                if (_mainForm.IsDNDActive)
                {
                    _sdkLib.rejectCall(sessionId, 486);
                    AutoClosingMessageBox.Show("Call rejected due to DND mode.", "Information", 3000);
                }
                else
                {
                    // Find a free line and set the session
                    int lineIndex = _mainForm.findFreeLineIndex();
                    if (lineIndex != -1)
                    {
                        _mainForm.SetCallSession(lineIndex, sessionId, true, existsAudio, existsVideo);
                        Console.WriteLine($"Set session for incoming call: SessionID = {sessionId}, LineIndex = {lineIndex}");

                        IncomingCallForm incomingCallForm = new IncomingCallForm(sessionId, callerDisplayName, _sdkLib, _mainForm, this);
                        incomingCallForm.Show();

                        if (_mainForm.AutoAnswerEnabled)
                        {
                            incomingCallForm.AutoAnswerCall();
                        }
                        else
                        {
                            if (!existsAudio)
                            {
                                System.Media.SoundPlayer player = new System.Media.SoundPlayer("C:\\Users\\Administrator\\Downloads\\call.wav");
                                player.Play();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No free line available for incoming call");
                        _sdkLib.rejectCall(sessionId, 486);
                    }
                }
            };

            if (this.IsHandleCreated)
            {
                this.Invoke(handleIncomingCall);
            }
            else
            {
                // If the form handle is not created, we need to handle this differently
                // One option is to use BeginInvoke on the main form, which should be created
                _mainForm.BeginInvoke(handleIncomingCall);
            }

            _mainForm.LogCall($"Incoming call from {callerDisplayName} ({caller}) at {DateTime.Now}");
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
            Console.WriteLine($"Call answered: SessionID = {sessionId}, Caller = {callerDisplayName}, Callee = {calleeDisplayName}");

            InvokeOnUIThread(() =>
            {
                if (ListBoxSIPLog != null && ListBoxSIPLog.IsHandleCreated)
                {
                    ListBoxSIPLog.Items.Add($"Call answered by {calleeDisplayName}");
                }
                _mainForm.StartCallTimer();  // Assuming StartCallTimer is a method in Form1 that starts the timer
            });

            _mainForm.LogCall($"Call answered for session {sessionId} at {DateTime.Now}");
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
            Console.WriteLine($"Call closed: SessionID = {sessionId}");

            Action handleClosedCall = () =>
            {
                if (ListBoxSIPLog != null && ListBoxSIPLog.IsHandleCreated)
                {
                    ListBoxSIPLog.Items.Add("Call closed");
                }
                _mainForm.UpdateCallState(sessionId, false);
            };

            if (this.InvokeRequired)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(handleClosedCall);
                }
                else
                {
                    // If RegistrationForm's handle is not created, use the main form
                    _mainForm.BeginInvoke(handleClosedCall);
                }
            }
            else
            {
                handleClosedCall();
            }

            return 0;
        }

        public int onInviteConnected(int sessionId)
        {
            Console.WriteLine($"Call connected: SessionID = {sessionId}");

            Action handleConnectedCall = () =>
            {
                ListBoxSIPLog.Items.Add("Call connected");
                _mainForm.UpdateCallState(sessionId, true);
            };

            if (this.IsHandleCreated)
            {
                this.Invoke(handleConnectedCall);
            }
            else
            {
                // If the RegistrationForm handle is not created, use the main form
                _mainForm.BeginInvoke(handleConnectedCall);
            }

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
            Console.WriteLine($"Transfer trying: SessionID = {sessionId}");

            Action handleTransferTrying = () =>
            {
                if (ListBoxSIPLog != null && ListBoxSIPLog.IsHandleCreated)
                {
                    ListBoxSIPLog.Items.Add($"Transfer trying for session ID: {sessionId}");
                }
            };

            if (this.InvokeRequired)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(handleTransferTrying);
                }
                else
                {
                    // If RegistrationForm's handle is not created, use the main form
                    _mainForm.BeginInvoke(handleTransferTrying);
                }
            }
            else
            {
                handleTransferTrying();
            }

            return 0;
        }

        public int onTransferRinging(int sessionId)
        {
            Console.WriteLine($"Transfer ringing: SessionID = {sessionId}");

            InvokeOnUIThread(() =>
            {
                if (ListBoxSIPLog != null && ListBoxSIPLog.IsHandleCreated)
                {
                    ListBoxSIPLog.Items.Add($"Transfer ringing for session ID: {sessionId}");
                }
            });

            return 0;
        }

        public int onACTVTransferSuccess(int sessionId)
        {
            Console.WriteLine($"ACTV Transfer success: SessionID = {sessionId}");

            InvokeOnUIThread(() =>
            {
                if (ListBoxSIPLog != null && ListBoxSIPLog.IsHandleCreated)
                {
                    ListBoxSIPLog.Items.Add($"ACTV Transfer success for session ID: {sessionId}");
                }
            });

            return 0;
        }

        public int onACTVTransferFailure(int sessionId, string reason, int code)
        {
            Console.WriteLine($"ACTV Transfer failure: SessionID = {sessionId}, Reason = {reason}, Code = {code}");

            InvokeOnUIThread(() =>
            {
                if (ListBoxSIPLog != null && ListBoxSIPLog.IsHandleCreated)
                {
                    ListBoxSIPLog.Items.Add($"ACTV Transfer failure for session ID: {sessionId}, Reason: {reason}, Code: {code}");
                }
            });

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

        private void InvokeOnUIThread(Action action)
        {
            if (this.InvokeRequired)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(action);
                }
                else
                {
                    // If RegistrationForm's handle is not created, use the main form
                    _mainForm.BeginInvoke(action);
                }
            }
            else
            {
                action();
            }
        }

        public void UpdateCallState(int sessionId, bool isActive)
        {
            Action updateUI = () =>
            {
                if (isActive)
                {
                    // Call is active, update UI accordingly
                    if (ListBoxSIPLog != null && ListBoxSIPLog.IsHandleCreated)
                    {
                        ListBoxSIPLog.Items.Add($"Call active for session ID: {sessionId}");
                    }
                }
                else
                {
                    // Call is not active, update UI accordingly
                    if (ListBoxSIPLog != null && ListBoxSIPLog.IsHandleCreated)
                    {
                        ListBoxSIPLog.Items.Add($"Call ended for session ID: {sessionId}");
                    }
                }
            };

            if (this.InvokeRequired)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(updateUI);
                }
                else
                {
                    // If RegistrationForm's handle is not created, use the main form
                    _mainForm.BeginInvoke(updateUI);
                }
            }
            else
            {
                updateUI();
            }

            // Update the main form's call state
            _mainForm.UpdateCallState(sessionId, isActive);
        }

        public void ShowIncomingCallForm(int sessionId, string callerDisplayName)
        {
            _incomingCallForm = new IncomingCallForm(sessionId, callerDisplayName, _sdkLib, _mainForm, this);
            _incomingCallForm.Show();
        }

        private void DisableInputFields()
        {
            TextBoxUserName.Enabled = false;
            TextBoxPassword.Enabled = false;
            TextBoxServer.Enabled = false;
            TextBoxServerPort.Enabled = false;
            TextBoxStunServer.Enabled = false;
            TextBoxStunPort.Enabled = false;
            ComboBoxTransport.Enabled = false;
            ButtonRegister.Enabled = false;
        }
    } // This is the closing brace of the RegistrationForm class
} // This is the closing brace of the namespace
