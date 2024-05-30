namespace SIPSample
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button ButtonAudioCodecs;
        private System.Windows.Forms.Button ButtonPlayAudio;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.ButtonAudioCodecs = new System.Windows.Forms.Button();
            this.ButtonPlayAudio = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // ButtonAudioCodecs
            // 
            this.ButtonAudioCodecs.Location = new System.Drawing.Point(150, 100);
            this.ButtonAudioCodecs.Name = "ButtonAudioCodecs";
            this.ButtonAudioCodecs.Size = new System.Drawing.Size(100, 30);
            this.ButtonAudioCodecs.TabIndex = 0;
            this.ButtonAudioCodecs.Text = "Audio Codecs";
            this.ButtonAudioCodecs.UseVisualStyleBackColor = true;
            this.ButtonAudioCodecs.Click += new System.EventHandler(this.ButtonAudioCodecs_Click);

            // 
            // ButtonPlayAudio
            // 
            this.ButtonPlayAudio.Location = new System.Drawing.Point(150, 150); // Adjust the location as needed
            this.ButtonPlayAudio.Name = "ButtonPlayAudio";
            this.ButtonPlayAudio.Size = new System.Drawing.Size(100, 30); // Adjust the size as needed
            this.ButtonPlayAudio.TabIndex = 1;
            this.ButtonPlayAudio.Text = "Play Audio";
            this.ButtonPlayAudio.UseVisualStyleBackColor = true;
            this.ButtonPlayAudio.Click += new System.EventHandler(this.ButtonPlayAudio_Click);

            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.ButtonPlayAudio);
            this.Controls.Add(this.ButtonAudioCodecs);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
        }
    }
}