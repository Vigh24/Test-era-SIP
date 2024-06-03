namespace SIPSample
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button ButtonAudioCodecs;

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
            this.SuspendLayout();
            // 
            // ButtonAudioCodecs
            // 
            this.ButtonAudioCodecs.Location = new System.Drawing.Point(12, 40);
            this.ButtonAudioCodecs.Name = "ButtonAudioCodecs";
            this.ButtonAudioCodecs.Size = new System.Drawing.Size(100, 30);
            this.ButtonAudioCodecs.TabIndex = 0;
            this.ButtonAudioCodecs.Text = "Audio Codecs";
            this.ButtonAudioCodecs.UseVisualStyleBackColor = true;
            this.ButtonAudioCodecs.Click += new System.EventHandler(this.ButtonAudioCodecs_Click);
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(210, 115);
            this.Controls.Add(this.ButtonAudioCodecs);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }
    }
}