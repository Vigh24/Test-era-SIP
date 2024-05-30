namespace SIPSample
{
    partial class AudioPlaybackForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button Button23;
        private System.Windows.Forms.Button Button21;
        private System.Windows.Forms.Button Button20;
        private System.Windows.Forms.TextBox TextBoxPlayFile;
        private System.Windows.Forms.Label Label27;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog1;

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
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.Button23 = new System.Windows.Forms.Button();
            this.Button21 = new System.Windows.Forms.Button();
            this.Button20 = new System.Windows.Forms.Button();
            this.TextBoxPlayFile = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.Button23);
            this.groupBox9.Controls.Add(this.Button21);
            this.groupBox9.Controls.Add(this.Button20);
            this.groupBox9.Controls.Add(this.TextBoxPlayFile);
            this.groupBox9.Controls.Add(this.Label27);
            this.groupBox9.Location = new System.Drawing.Point(12, 12);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(203, 118);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Play audio file(Wave)";
            // 
            // Button23
            // 
            this.Button23.Location = new System.Drawing.Point(108, 86);
            this.Button23.Name = "Button23";
            this.Button23.Size = new System.Drawing.Size(75, 22);
            this.Button23.TabIndex = 4;
            this.Button23.Text = "Stop";
            this.Button23.UseVisualStyleBackColor = true;
            this.Button23.Click += new System.EventHandler(this.Button23_Click);
            // 
            // Button21
            // 
            this.Button21.Location = new System.Drawing.Point(12, 86);
            this.Button21.Name = "Button21";
            this.Button21.Size = new System.Drawing.Size(75, 22);
            this.Button21.TabIndex = 3;
            this.Button21.Text = "Start";
            this.Button21.UseVisualStyleBackColor = true;
            this.Button21.Click += new System.EventHandler(this.Button21_Click);
            // 
            // Button20
            // 
            this.Button20.Location = new System.Drawing.Point(83, 18);
            this.Button20.Name = "Button20";
            this.Button20.Size = new System.Drawing.Size(69, 22);
            this.Button20.TabIndex = 2;
            this.Button20.Text = "...";
            this.Button20.UseVisualStyleBackColor = true;
            this.Button20.Click += new System.EventHandler(this.Button20_Click);
            // 
            // TextBoxPlayFile
            // 
            this.TextBoxPlayFile.Location = new System.Drawing.Point(6, 50);
            this.TextBoxPlayFile.Name = "TextBoxPlayFile";
            this.TextBoxPlayFile.ReadOnly = true;
            this.TextBoxPlayFile.Size = new System.Drawing.Size(182, 20);
            this.TextBoxPlayFile.TabIndex = 1;
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(10, 22);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(51, 13);
            this.Label27.TabIndex = 0;
            this.Label27.Text = "select file";
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.DefaultExt = "wav";
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            this.OpenFileDialog1.Title = "Select wave file";
            // 
            // AudioPlaybackForm
            // 
            this.ClientSize = new System.Drawing.Size(227, 142);
            this.Controls.Add(this.groupBox9);
            this.Name = "AudioPlaybackForm";
            this.Text = "Audio Playback";
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}