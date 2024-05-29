using System;
using PortSIP;
using System.Windows.Forms;

namespace SIPSample
{
    public partial class AudioCodecsForm : Form
    {
        private PortSIPLib _sdkLib;
        private bool _SIPInited;

        public AudioCodecsForm(PortSIPLib sdkLib, bool sipInited)
        {
            InitializeComponent();
            _sdkLib = sdkLib;
            _SIPInited = sipInited;

            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        }

        // Properties for each checkbox
        public bool G711uLawEnabled
        {
            get { return checkBoxG711uLaw.Checked; }
            set { checkBoxG711uLaw.Checked = value; }
        }

        public bool G711aLawEnabled
        {
            get { return checkBoxG711aLaw.Checked; }
            set { checkBoxG711aLaw.Checked = value; }
        }

        public bool G729Enabled
        {
            get { return checkBoxG729.Checked; }
            set { checkBoxG729.Checked = value; }
        }

        public bool iLBCEnabled
        {
            get { return checkBoxiLBC.Checked; }
            set { checkBoxiLBC.Checked = value; }
        }

        public bool GSMEnabled
        {
            get { return checkBoxGSM.Checked; }
            set { checkBoxGSM.Checked = value; }
        }

        public bool AMREnabled
        {
            get { return checkBoxAMR.Checked; }
            set { checkBoxAMR.Checked = value; }
        }

        public bool G722Enabled
        {
            get { return checkBoxG722.Checked; }
            set { checkBoxG722.Checked = value; }
        }

        public bool SpeexEnabled
        {
            get { return checkBoxSpeex.Checked; }
            set { checkBoxSpeex.Checked = value; }
        }

        public bool AMRWBEnabled
        {
            get { return checkBoxAMRWB.Checked; }
            set { checkBoxAMRWB.Checked = value; }
        }

        public bool SpeexWBEnabled
        {
            get { return checkBoxSPEEXWB.Checked; }
            set { checkBoxSPEEXWB.Checked = value; }
        }

        public bool G7221Enabled
        {
            get { return checkBoxG7221.Checked; }
            set { checkBoxG7221.Checked = value; }
        }

        public bool OpusEnabled
        {
            get { return checkBoxOpus.Checked; }
            set { checkBoxOpus.Checked = value; }
        }

        public bool H264Enabled
        {
            get { return checkBoxH264.Checked; }
            set { checkBoxH264.Checked = value; }
        }

        public bool VP8Enabled
        {
            get { return checkBoxVP8.Checked; }
            set { checkBoxVP8.Checked = value; }
        }

        public bool VP9Enabled
        {
            get { return checkBoxVP9.Checked; }
            set { checkBoxVP9.Checked = value; }
        }

        private void UpdateAudioCodecs()
        {
            if (_SIPInited == false)
            {
                return;
            }

            _sdkLib.clearAudioCodec();

            if (checkBoxG711uLaw.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_PCMU);
            }

            if (checkBoxG711aLaw.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_PCMA);
            }

            if (checkBoxG729.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_G729);
            }

            if (checkBoxiLBC.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_ILBC);
            }

            if (checkBoxGSM.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_GSM);
            }

            if (checkBoxAMR.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_AMR);
            }

            if (checkBoxG722.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_G722);
            }

            if (checkBoxSpeex.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_SPEEX);
            }

            if (checkBoxAMRWB.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_AMRWB);
            }

            if (checkBoxSPEEXWB.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_SPEEXWB);
            }

            if (checkBoxG7221.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_G7221);
            }

            if (checkBoxOpus.Checked == true)
            {
                _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_OPUS);
            }

            _sdkLib.addAudioCodec(AUDIOCODEC_TYPE.AUDIOCODEC_DTMF);
        }

        private void UpdateVideoCodecs()
        {
            if (_SIPInited == false)
            {
                return;
            }

            _sdkLib.clearVideoCodec();

            if (checkBoxH264.Checked == true)
            {
                _sdkLib.addVideoCodec(VIDEOCODEC_TYPE.VIDEO_CODEC_H264);
            }

            if (checkBoxVP8.Checked == true)
            {
                _sdkLib.addVideoCodec(VIDEOCODEC_TYPE.VIDEO_CODEC_VP8);
            }

            if (checkBoxVP9.Checked == true)
            {
                _sdkLib.addVideoCodec(VIDEOCODEC_TYPE.VIDEO_CODEC_VP9);
            }
        }

        private void checkBoxG711uLaw_CheckedChanged(object sender, EventArgs e)
        {
            G711uLawEnabled = checkBoxG711uLaw.Checked;
            Console.WriteLine($"G711uLaw checkbox changed: {G711uLawEnabled}");
            UpdateAudioCodecs();
        }

        private void checkBoxG711aLaw_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxG729_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxiLBC_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxGSM_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxAMR_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxG722_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxG7221_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxAMRWB_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxSPEEXWB_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxSpeex_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxOpus_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAudioCodecs();
        }

        private void checkBoxH264_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVideoCodecs();
        }

        private void checkBoxVP8_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVideoCodecs();
        }

        private void checkBoxVP9_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVideoCodecs();
        }

        private void AudioCodecsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Log the state of each codec before closing the form
            Console.WriteLine($"AudioCodecsForm - Before closing: G711uLawEnabled={G711uLawEnabled}, G711aLawEnabled={G711aLawEnabled}, G729Enabled={G729Enabled}, iLBCEnabled={iLBCEnabled}, GSMEnabled={GSMEnabled}, AMREnabled={AMREnabled}, G722Enabled={G722Enabled}, SpeexEnabled={SpeexEnabled}, AMRWBEnabled={AMRWBEnabled}, SpeexWBEnabled={SpeexWBEnabled}, G7221Enabled={G7221Enabled}, OpusEnabled={OpusEnabled}, H264Enabled={H264Enabled}, VP8Enabled={VP8Enabled}, VP9Enabled={VP9Enabled}");

            // Set the DialogResult to OK to indicate that the form is closing after a successful operation
            this.DialogResult = DialogResult.OK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}