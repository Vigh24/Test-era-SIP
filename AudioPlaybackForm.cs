using System;
using System.Windows.Forms;
using PortSIP;

namespace SIPSample
{
    public partial class AudioPlaybackForm : Form
    {
        private PortSIPLib _sdkLib;
        private bool _SIPInited;
        private Session[] _CallSessions;
        private int _CurrentlyLine;

        public AudioPlaybackForm(PortSIPLib sdkLib, bool sipInited, Session[] callSessions, int currentlyLine)
        {
            InitializeComponent();
            _sdkLib = sdkLib;
            _SIPInited = sipInited;
            _CallSessions = callSessions;
            _CurrentlyLine = currentlyLine;
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TextBoxPlayFile.Text = OpenFileDialog1.FileName;
            }
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            if (_SIPInited == false)
            {
                MessageBox.Show("Please initialize the SDK first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (TextBoxPlayFile.Text.Length <= 0)
            {
                MessageBox.Show("The play file is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string waveFile = TextBoxPlayFile.Text;

            if (!System.IO.File.Exists(waveFile))
            {
                MessageBox.Show("The specified file does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int sessionId = _CallSessions[_CurrentlyLine].getSessionId();
            if (sessionId <= 0)
            {
                MessageBox.Show("Invalid session ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Check if the session is valid and active
            if (!_CallSessions[_CurrentlyLine].getSessionState())
            {
                MessageBox.Show("The session is not active.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Start playing the file to the remote party
            int result = _sdkLib.startPlayingFileToRemote(sessionId, waveFile, false, 1);
            if (result != 0)
            {
                MessageBox.Show("Failed to start playing the file. Error code: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Playing file to remote successfully started.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button23_Click(object sender, EventArgs e)
        {
            if (_SIPInited == false)
            {
                return;
            }
            _sdkLib.stopPlayingFileToRemote(_CallSessions[_CurrentlyLine].getSessionId());
        }
    }
}