namespace SIPSample
{
    partial class LicenseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtLicenseKey; // TextBox for the license key
        private System.Windows.Forms.Button btnTrial; // Button to start trial
        private System.Windows.Forms.Button btnActivate; // Button to activate license
        private System.Windows.Forms.Button btnGetKey; // Button to get key

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LicenseForm));
            this.txtLicenseKey = new System.Windows.Forms.TextBox();
            this.btnTrial = new System.Windows.Forms.Button();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnGetKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLicenseKey
            // 
            this.txtLicenseKey.Location = new System.Drawing.Point(12, 15);
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.Size = new System.Drawing.Size(237, 20);
            this.txtLicenseKey.TabIndex = 0;
            // 
            // btnTrial
            // 
            this.btnTrial.Location = new System.Drawing.Point(12, 47);
            this.btnTrial.Name = "btnTrial";
            this.btnTrial.Size = new System.Drawing.Size(71, 20);
            this.btnTrial.TabIndex = 1;
            this.btnTrial.Text = "Start Trial";
            this.btnTrial.UseVisualStyleBackColor = true;
            this.btnTrial.Click += new System.EventHandler(this.btnTrial_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(89, 47);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(97, 20);
            this.btnActivate.TabIndex = 2;
            this.btnActivate.Text = "Activate License";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnGetKey
            // 
            this.btnGetKey.Location = new System.Drawing.Point(192, 47);
            this.btnGetKey.Name = "btnGetKey";
            this.btnGetKey.Size = new System.Drawing.Size(57, 20);
            this.btnGetKey.TabIndex = 3;
            this.btnGetKey.Text = "Get Key";
            this.btnGetKey.UseVisualStyleBackColor = true;
            this.btnGetKey.Click += new System.EventHandler(this.btnGetKey_Click);
            // 
            // LicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 74);
            this.Controls.Add(this.txtLicenseKey);
            this.Controls.Add(this.btnTrial);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.btnGetKey);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LicenseForm";
            this.Text = "LicenseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}