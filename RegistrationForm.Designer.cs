namespace SIPSample
{
    partial class RegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox ComboBoxTransport;
        private System.Windows.Forms.TextBox TextBoxUserName;
        private System.Windows.Forms.TextBox TextBoxPassword;
        private System.Windows.Forms.TextBox TextBoxServer;
        private System.Windows.Forms.TextBox TextBoxServerPort;
        private System.Windows.Forms.TextBox TextBoxStunServer;
        private System.Windows.Forms.TextBox TextBoxStunPort;
        private System.Windows.Forms.ListBox ListBoxSIPLog;
        private System.Windows.Forms.Button ButtonRegister;

        // Add label controls
        private System.Windows.Forms.Label LabelTransport;
        private System.Windows.Forms.Label LabelUserName;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.Label LabelServer;
        private System.Windows.Forms.Label LabelServerPort;
        private System.Windows.Forms.Label LabelStunServer;
        private System.Windows.Forms.Label LabelStunPort;

        private void InitializeComponent()
        {
            this.ComboBoxTransport = new System.Windows.Forms.ComboBox();
            this.TextBoxUserName = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.TextBoxServer = new System.Windows.Forms.TextBox();
            this.TextBoxServerPort = new System.Windows.Forms.TextBox();
            this.TextBoxStunServer = new System.Windows.Forms.TextBox();
            this.TextBoxStunPort = new System.Windows.Forms.TextBox();
            this.ListBoxSIPLog = new System.Windows.Forms.ListBox();
            this.ButtonRegister = new System.Windows.Forms.Button();

            // Initialize label controls
            this.LabelTransport = new System.Windows.Forms.Label();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.LabelServer = new System.Windows.Forms.Label();
            this.LabelServerPort = new System.Windows.Forms.Label();
            this.LabelStunServer = new System.Windows.Forms.Label();
            this.LabelStunPort = new System.Windows.Forms.Label();

            this.SuspendLayout();
            // 
            // ComboBoxTransport
            // 
            this.ComboBoxTransport.FormattingEnabled = true;
            this.ComboBoxTransport.Location = new System.Drawing.Point(120, 12);
            this.ComboBoxTransport.Name = "ComboBoxTransport";
            this.ComboBoxTransport.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxTransport.TabIndex = 0;
            // 
            // TextBoxUserName
            // 
            this.TextBoxUserName.Location = new System.Drawing.Point(120, 39);
            this.TextBoxUserName.Name = "TextBoxUserName";
            this.TextBoxUserName.Size = new System.Drawing.Size(100, 20);
            this.TextBoxUserName.TabIndex = 1;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(120, 65);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.TextBoxPassword.TabIndex = 2;
            // 
            // TextBoxServer
            // 
            this.TextBoxServer.Location = new System.Drawing.Point(120, 91);
            this.TextBoxServer.Name = "TextBoxServer";
            this.TextBoxServer.Size = new System.Drawing.Size(100, 20);
            this.TextBoxServer.TabIndex = 3;
            // 
            // TextBoxServerPort
            // 
            this.TextBoxServerPort.Location = new System.Drawing.Point(120, 117);
            this.TextBoxServerPort.Name = "TextBoxServerPort";
            this.TextBoxServerPort.Size = new System.Drawing.Size(100, 20);
            this.TextBoxServerPort.TabIndex = 4;
            // 
            // TextBoxStunServer
            // 
            this.TextBoxStunServer.Location = new System.Drawing.Point(120, 143);
            this.TextBoxStunServer.Name = "TextBoxStunServer";
            this.TextBoxStunServer.Size = new System.Drawing.Size(100, 20);
            this.TextBoxStunServer.TabIndex = 5;
            // 
            // TextBoxStunPort
            // 
            this.TextBoxStunPort.Location = new System.Drawing.Point(120, 169);
            this.TextBoxStunPort.Name = "TextBoxStunPort";
            this.TextBoxStunPort.Size = new System.Drawing.Size(100, 20);
            this.TextBoxStunPort.TabIndex = 6;
            // 
            // ListBoxSIPLog
            // 
            this.ListBoxSIPLog.FormattingEnabled = true;
            this.ListBoxSIPLog.Location = new System.Drawing.Point(12, 195);
            this.ListBoxSIPLog.Name = "ListBoxSIPLog";
            this.ListBoxSIPLog.Size = new System.Drawing.Size(260, 95);
            this.ListBoxSIPLog.TabIndex = 7;
            // 
            // ButtonRegister
            // 
            this.ButtonRegister.Location = new System.Drawing.Point(12, 296);
            this.ButtonRegister.Name = "ButtonRegister";
            this.ButtonRegister.Size = new System.Drawing.Size(75, 23);
            this.ButtonRegister.TabIndex = 8;
            this.ButtonRegister.Text = "Register";
            this.ButtonRegister.UseVisualStyleBackColor = true;
            this.ButtonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // LabelTransport
            // 
            this.LabelTransport.AutoSize = true;
            this.LabelTransport.Location = new System.Drawing.Point(12, 15);
            this.LabelTransport.Name = "LabelTransport";
            this.LabelTransport.Size = new System.Drawing.Size(52, 13);
            this.LabelTransport.TabIndex = 9;
            this.LabelTransport.Text = "Transport";
            // 
            // LabelUserName
            // 
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.Location = new System.Drawing.Point(12, 42);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(60, 13);
            this.LabelUserName.TabIndex = 10;
            this.LabelUserName.Text = "User Name";
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Location = new System.Drawing.Point(12, 68);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(53, 13);
            this.LabelPassword.TabIndex = 11;
            this.LabelPassword.Text = "Password";
            // 
            // LabelServer
            // 
            this.LabelServer.AutoSize = true;
            this.LabelServer.Location = new System.Drawing.Point(12, 94);
            this.LabelServer.Name = "LabelServer";
            this.LabelServer.Size = new System.Drawing.Size(38, 13);
            this.LabelServer.TabIndex = 12;
            this.LabelServer.Text = "Server";
            // 
            // LabelServerPort
            // 
            this.LabelServerPort.AutoSize = true;
            this.LabelServerPort.Location = new System.Drawing.Point(12, 120);
            this.LabelServerPort.Name = "LabelServerPort";
            this.LabelServerPort.Size = new System.Drawing.Size(61, 13);
            this.LabelServerPort.TabIndex = 13;
            this.LabelServerPort.Text = "Server Port";
            // 
            // LabelStunServer
            // 
            this.LabelStunServer.AutoSize = true;
            this.LabelStunServer.Location = new System.Drawing.Point(12, 146);
            this.LabelStunServer.Name = "LabelStunServer";
            this.LabelStunServer.Size = new System.Drawing.Size(66, 13);
            this.LabelStunServer.TabIndex = 14;
            this.LabelStunServer.Text = "STUN Server";
            // 
            // LabelStunPort
            // 
            this.LabelStunPort.AutoSize = true;
            this.LabelStunPort.Location = new System.Drawing.Point(12, 172);
            this.LabelStunPort.Name = "LabelStunPort";
            this.LabelStunPort.Size = new System.Drawing.Size(55, 13);
            this.LabelStunPort.TabIndex = 15;
            this.LabelStunPort.Text = "STUN Port";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 331);
            this.Controls.Add(this.ButtonRegister);
            this.Controls.Add(this.ListBoxSIPLog);
            this.Controls.Add(this.TextBoxStunPort);
            this.Controls.Add(this.TextBoxStunServer);
            this.Controls.Add(this.TextBoxServerPort);
            this.Controls.Add(this.TextBoxServer);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxUserName);
            this.Controls.Add(this.ComboBoxTransport);
            this.Controls.Add(this.LabelStunPort);
            this.Controls.Add(this.LabelStunServer);
            this.Controls.Add(this.LabelServerPort);
            this.Controls.Add(this.LabelServer);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.LabelUserName);
            this.Controls.Add(this.LabelTransport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
