using System;
using System.Windows.Forms;
using PortSIP;
using ComponentFactory.Krypton.Toolkit;
using System.Media;
using System.IO;
using System.Reflection;

namespace EratronicsPhone
{
    public partial class IncomingCallForm : KryptonForm
    {
        private int _sessionId;
        private PortSIPLib _sdkLib;
        private Form1 _mainForm;
        private RegistrationForm _registrationForm;
        private SoundPlayer _ringtonePlayer;

        public event EventHandler<bool> CallStateChanged;

        public IncomingCallForm(int sessionId, string callerName, PortSIPLib sdkLib, Form1 mainForm, RegistrationForm registrationForm)
        {
            InitializeComponent();
            _sessionId = sessionId;
            _sdkLib = sdkLib;
            _mainForm = mainForm;
            _registrationForm = registrationForm;
            lblCaller.Text = $"Incoming call from: {callerName}";

            // Subscribe to the call termination event
            _sdkLib.OnInviteClosedPublic += SdkLib_OnInviteClosed;

            // Initialize and play the ringtone
            InitializeRingtone();
        }

        private void InitializeRingtone()
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                string resourceName = $"{assembly.GetName().Name}.ringtone.wav";
                Console.WriteLine($"Attempting to load resource: {resourceName}");

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream == null)
                    {
                        Console.WriteLine("Ringtone resource not found. Available resources:");
                        foreach (var name in assembly.GetManifestResourceNames())
                        {
                            Console.WriteLine(name);
                        }
                        return;
                    }

                    Console.WriteLine("Ringtone resource found. Creating SoundPlayer...");
                    _ringtonePlayer = new SoundPlayer(stream);

                    Console.WriteLine("Loading ringtone...");
                    _ringtonePlayer.Load(); // Use synchronous loading for debugging

                    Console.WriteLine("Playing ringtone...");
                    _ringtonePlayer.PlayLooping();

                    // Alternative playback method using NAudio (you'll need to add the NAudio NuGet package)
                    /*
                    using (var ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        ms.Position = 0;
                        var waveOut = new NAudio.Wave.WaveOutEvent();
                        var waveStream = new NAudio.Wave.WaveFileReader(ms);
                        waveOut.Init(waveStream);
                        waveOut.Play();
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing ringtone: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        private void SdkLib_OnInviteClosed(int sessionId)
        {
            if (sessionId == _sessionId)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    StopRingtone();
                    MessageBox.Show("The caller has hung up.");
                    CallStateChanged?.Invoke(this, false);
                    _mainForm.UpdateCallState(_sessionId, false);
                    _registrationForm.UpdateCallState(_sessionId, false);
                    this.Close();
                });
            }
        }

        public void HandleCallTerminated(int sessionId)
        {
            if (sessionId == _sessionId)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    StopRingtone();
                    MessageBox.Show("The caller has hung up.");
                    CallStateChanged?.Invoke(this, false);
                    _mainForm.UpdateCallState(_sessionId, false);
                    _registrationForm.UpdateCallState(_sessionId, false);
                    this.Close();
                });
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            StopRingtone();
            _sdkLib.answerCall(_sessionId, false); // Answer the call without video
            CallStateChanged?.Invoke(this, true);
            _mainForm.UpdateCallState(_sessionId, true);
            _registrationForm.UpdateCallState(_sessionId, true);
            Console.WriteLine($"Call answered and state updated for SessionID: {_sessionId}");
            this.Close();
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            StopRingtone();
            _sdkLib.rejectCall(_sessionId, 486);
            MessageBox.Show("Call rejected.");
            CallStateChanged?.Invoke(this, false);
            _mainForm.UpdateCallState(_sessionId, false);
            _registrationForm.UpdateCallState(_sessionId, false);
            this.Close();
        }

        private void btnHangUp_Click(object sender, EventArgs e)
        {
            StopRingtone();
            _sdkLib.hangUp(_sessionId);
            MessageBox.Show("Call ended.");
            CallStateChanged?.Invoke(this, false);
            _mainForm.UpdateCallState(_sessionId, false);
            _registrationForm.UpdateCallState(_sessionId, false);
            this.Close();
        }

        public void AutoAnswerCall()
        {
            StopRingtone();
            Console.WriteLine($"Auto-answering call for SessionID: {_sessionId}");
            _sdkLib.answerCall(_sessionId, false); // Answer the call without video
            CallStateChanged?.Invoke(this, true);
            _mainForm.UpdateCallState(_sessionId, true);
            _registrationForm.UpdateCallState(_sessionId, true);
            Console.WriteLine($"Call auto-answered and state updated for SessionID: {_sessionId}");
            this.Close();
        }

        private void StopRingtone()
        {
            if (_ringtonePlayer != null)
            {
                _ringtonePlayer.Stop();
                _ringtonePlayer.Dispose();
                _ringtonePlayer = null;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            StopRingtone();
            _sdkLib.OnInviteClosedPublic -= SdkLib_OnInviteClosed;
            base.OnFormClosed(e);
        }
    }
}