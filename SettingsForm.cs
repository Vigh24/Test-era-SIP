using System;
using System.Windows.Forms;
using PortSIP;

namespace SIPSample
{
    public partial class SettingsForm : Form
    {
        private PortSIPLib _sdkLib;
        private bool _SIPInited;
        private AudioCodecsForm _audioCodecsForm;
        private Session[] _CallSessions;
        private int _CurrentlyLine;

        public bool G711uLawEnabled { get; private set; }
        public bool G711aLawEnabled { get; private set; }
        public bool G729Enabled { get; private set; }
        public bool iLBCEnabled { get; private set; }
        public bool GSMEnabled { get; private set; }
        public bool AMREnabled { get; private set; }
        public bool G722Enabled { get; private set; }
        public bool SpeexEnabled { get; private set; }
        public bool AMRWBEnabled { get; private set; }
        public bool SpeexWBEnabled { get; private set; }
        public bool G7221Enabled { get; private set; }
        public bool OpusEnabled { get; private set; }
        public bool H264Enabled { get; private set; }
        public bool VP8Enabled { get; private set; }
        public bool VP9Enabled { get; private set; }

        public SettingsForm(PortSIPLib sdkLib, bool sipInited, Session[] callSessions, int currentlyLine, AudioCodecsForm audioCodecsForm,
    bool g711uLawEnabled, bool g711aLawEnabled, bool g729Enabled, bool iLBCEnabled, bool gsmEnabled,
    bool amrEnabled, bool g722Enabled, bool speexEnabled, bool amrwbEnabled, bool speexwbEnabled,
    bool g7221Enabled, bool opusEnabled, bool h264Enabled, bool vp8Enabled, bool vp9Enabled)
        {
            InitializeComponent();
            _sdkLib = sdkLib;
            _SIPInited = sipInited;
            _CallSessions = callSessions;
            _CurrentlyLine = currentlyLine;
            _audioCodecsForm = audioCodecsForm;

            G711uLawEnabled = g711uLawEnabled;
            G711aLawEnabled = g711aLawEnabled;
            G729Enabled = g729Enabled;
            iLBCEnabled = iLBCEnabled;
            GSMEnabled = gsmEnabled;
            AMREnabled = amrEnabled;
            G722Enabled = g722Enabled;
            SpeexEnabled = speexEnabled;
            AMRWBEnabled = amrwbEnabled;
            SpeexWBEnabled = speexwbEnabled;
            G7221Enabled = g7221Enabled;
            OpusEnabled = opusEnabled;
            H264Enabled = h264Enabled;
            VP8Enabled = vp8Enabled;
            VP9Enabled = vp9Enabled;
        }

        private void ButtonAudioCodecs_Click(object sender, EventArgs e)
        {
            // Log current codec states
            Console.WriteLine($"SettingsForm - Before opening AudioCodecsForm: G711uLawEnabled={G711uLawEnabled}, G711aLawEnabled={G711aLawEnabled}, G729Enabled={G729Enabled}, iLBCEnabled={iLBCEnabled}, GSMEnabled={GSMEnabled}, AMREnabled={AMREnabled}, G722Enabled={G722Enabled}, SpeexEnabled={SpeexEnabled}, AMRWBEnabled={AMRWBEnabled}, SpeexWBEnabled={SpeexWBEnabled}, G7221Enabled={G7221Enabled}, OpusEnabled={OpusEnabled}, H264Enabled={H264Enabled}, VP8Enabled={VP8Enabled}, VP9Enabled={VP9Enabled}");

            // Ensure the form is initialized with the current codec states
            _audioCodecsForm.G711uLawEnabled = G711uLawEnabled;
            _audioCodecsForm.G711aLawEnabled = G711aLawEnabled;
            _audioCodecsForm.G729Enabled = G729Enabled;
            _audioCodecsForm.iLBCEnabled = iLBCEnabled;
            _audioCodecsForm.GSMEnabled = GSMEnabled;
            _audioCodecsForm.AMREnabled = AMREnabled;
            _audioCodecsForm.G722Enabled = G722Enabled;
            _audioCodecsForm.SpeexEnabled = SpeexEnabled;
            _audioCodecsForm.AMRWBEnabled = AMRWBEnabled;
            _audioCodecsForm.SpeexWBEnabled = SpeexWBEnabled;
            _audioCodecsForm.G7221Enabled = G7221Enabled;
            _audioCodecsForm.OpusEnabled = OpusEnabled;
            _audioCodecsForm.H264Enabled = H264Enabled;
            _audioCodecsForm.VP8Enabled = VP8Enabled;
            _audioCodecsForm.VP9Enabled = VP9Enabled;

            // Show the form as a dialog
            if (_audioCodecsForm.ShowDialog() == DialogResult.OK)
            {
                // Update the codec states after the form is closed
                G711uLawEnabled = _audioCodecsForm.G711uLawEnabled;
                G711aLawEnabled = _audioCodecsForm.G711aLawEnabled;
                G729Enabled = _audioCodecsForm.G729Enabled;
                iLBCEnabled = _audioCodecsForm.iLBCEnabled;
                GSMEnabled = _audioCodecsForm.GSMEnabled;
                AMREnabled = _audioCodecsForm.AMREnabled;
                G722Enabled = _audioCodecsForm.G722Enabled;
                SpeexEnabled = _audioCodecsForm.SpeexEnabled;
                AMRWBEnabled = _audioCodecsForm.AMRWBEnabled;
                SpeexWBEnabled = _audioCodecsForm.SpeexWBEnabled;
                G7221Enabled = _audioCodecsForm.G7221Enabled;
                OpusEnabled = _audioCodecsForm.OpusEnabled;
                H264Enabled = _audioCodecsForm.H264Enabled;
                VP8Enabled = _audioCodecsForm.VP8Enabled;
                VP9Enabled = _audioCodecsForm.VP9Enabled;

                // Log updated codec states
                Console.WriteLine($"SettingsForm - After closing AudioCodecsForm: G711uLawEnabled={G711uLawEnabled}, G711aLawEnabled={G711aLawEnabled}, G729Enabled={G729Enabled}, iLBCEnabled={iLBCEnabled}, GSMEnabled={GSMEnabled}, AMREnabled={AMREnabled}, G722Enabled={G722Enabled}, SpeexEnabled={SpeexEnabled}, AMRWBEnabled={AMRWBEnabled}, SpeexWBEnabled={SpeexWBEnabled}, G7221Enabled={G7221Enabled}, OpusEnabled={OpusEnabled}, H264Enabled={H264Enabled}, VP8Enabled={VP8Enabled}, VP9Enabled={VP9Enabled}");
            }
        }

        private void ButtonPlayAudio_Click(object sender, EventArgs e)
        {
            AudioPlaybackForm audioPlaybackForm = new AudioPlaybackForm(_sdkLib, _SIPInited, _CallSessions, _CurrentlyLine);
            audioPlaybackForm.Show();
        }
    }
}