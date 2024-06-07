partial class RegistrationForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ComboBox ComboBoxTransport;
    private System.Windows.Forms.TextBox TextBoxUserName;
    private System.Windows.Forms.TextBox TextBoxPassword;
    private System.Windows.Forms.TextBox TextBoxServer;
    private System.Windows.Forms.TextBox TextBoxServerPort;
    private System.Windows.Forms.TextBox TextBoxDomain;
    private System.Windows.Forms.TextBox TextBoxDisplayName;
    private System.Windows.Forms.TextBox TextBoxAuthName;
    private System.Windows.Forms.ListBox ListBoxSIPLog;
    private System.Windows.Forms.Button ButtonRegister;
    private System.Windows.Forms.Label LabelTransport;
    private System.Windows.Forms.Label LabelUserName;
    private System.Windows.Forms.Label LabelPassword;
    private System.Windows.Forms.Label LabelServer;
    private System.Windows.Forms.Label LabelServerPort;
    private System.Windows.Forms.Label LabelDomain;
    private System.Windows.Forms.Label LabelDisplayName;
    private System.Windows.Forms.Label LabelAuthName;

    // Example of adding TextBox controls manually if they are missing
    private System.Windows.Forms.TextBox TextBoxStunPort;
    private System.Windows.Forms.TextBox TextBoxStunServer;

    private void InitializeComponent()
    {
            this.ComboBoxTransport = new System.Windows.Forms.ComboBox();
            this.TextBoxUserName = new System.Windows.Forms.TextBox();
            this.TextBoxPassword = new System.Windows.Forms.TextBox();
            this.TextBoxServer = new System.Windows.Forms.TextBox();
            this.TextBoxServerPort = new System.Windows.Forms.TextBox();
            this.TextBoxDomain = new System.Windows.Forms.TextBox();
            this.TextBoxDisplayName = new System.Windows.Forms.TextBox();
            this.TextBoxAuthName = new System.Windows.Forms.TextBox();
            this.ListBoxSIPLog = new System.Windows.Forms.ListBox();
            this.ButtonRegister = new System.Windows.Forms.Button();
            this.LabelTransport = new System.Windows.Forms.Label();
            this.LabelUserName = new System.Windows.Forms.Label();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.LabelServer = new System.Windows.Forms.Label();
            this.LabelServerPort = new System.Windows.Forms.Label();
            this.LabelDomain = new System.Windows.Forms.Label();
            this.LabelDisplayName = new System.Windows.Forms.Label();
            this.LabelAuthName = new System.Windows.Forms.Label();
            this.TextBoxStunPort = new System.Windows.Forms.TextBox();
            this.TextBoxStunServer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ComboBoxTransport
            // 
            this.ComboBoxTransport.FormattingEnabled = true;
            this.ComboBoxTransport.Location = new System.Drawing.Point(89, 12);
            this.ComboBoxTransport.Name = "ComboBoxTransport";
            this.ComboBoxTransport.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxTransport.TabIndex = 0;
            // 
            // TextBoxUserName
            // 
            this.TextBoxUserName.Location = new System.Drawing.Point(89, 39);
            this.TextBoxUserName.Name = "TextBoxUserName";
            this.TextBoxUserName.Size = new System.Drawing.Size(121, 20);
            this.TextBoxUserName.TabIndex = 1;
            // 
            // TextBoxPassword
            // 
            this.TextBoxPassword.Location = new System.Drawing.Point(89, 65);
            this.TextBoxPassword.Name = "TextBoxPassword";
            this.TextBoxPassword.Size = new System.Drawing.Size(121, 20);
            this.TextBoxPassword.TabIndex = 2;
            // 
            // TextBoxServer
            // 
            this.TextBoxServer.Location = new System.Drawing.Point(89, 91);
            this.TextBoxServer.Name = "TextBoxServer";
            this.TextBoxServer.Size = new System.Drawing.Size(121, 20);
            this.TextBoxServer.TabIndex = 3;
            // 
            // TextBoxServerPort
            // 
            this.TextBoxServerPort.Location = new System.Drawing.Point(89, 117);
            this.TextBoxServerPort.Name = "TextBoxServerPort";
            this.TextBoxServerPort.Size = new System.Drawing.Size(121, 20);
            this.TextBoxServerPort.TabIndex = 4;
            // 
            // TextBoxDomain
            // 
            this.TextBoxDomain.Location = new System.Drawing.Point(89, 143);
            this.TextBoxDomain.Name = "TextBoxDomain";
            this.TextBoxDomain.Size = new System.Drawing.Size(121, 20);
            this.TextBoxDomain.TabIndex = 5;
            // 
            // TextBoxDisplayName
            // 
            this.TextBoxDisplayName.Location = new System.Drawing.Point(89, 169);
            this.TextBoxDisplayName.Name = "TextBoxDisplayName";
            this.TextBoxDisplayName.Size = new System.Drawing.Size(121, 20);
            this.TextBoxDisplayName.TabIndex = 6;
            // 
            // TextBoxAuthName
            // 
            this.TextBoxAuthName.Location = new System.Drawing.Point(89, 195);
            this.TextBoxAuthName.Name = "TextBoxAuthName";
            this.TextBoxAuthName.Size = new System.Drawing.Size(121, 20);
            this.TextBoxAuthName.TabIndex = 7;
            // 
            // ListBoxSIPLog
            // 
            this.ListBoxSIPLog.FormattingEnabled = true;
            this.ListBoxSIPLog.Location = new System.Drawing.Point(12, 221);
            this.ListBoxSIPLog.Name = "ListBoxSIPLog";
            this.ListBoxSIPLog.Size = new System.Drawing.Size(260, 95);
            this.ListBoxSIPLog.TabIndex = 8;
            // 
            // ButtonRegister
            // 
            this.ButtonRegister.Location = new System.Drawing.Point(12, 322);
            this.ButtonRegister.Name = "ButtonRegister";
            this.ButtonRegister.Size = new System.Drawing.Size(75, 23);
            this.ButtonRegister.TabIndex = 9;
            this.ButtonRegister.Text = "Register";
            this.ButtonRegister.UseVisualStyleBackColor = true;
            this.ButtonRegister.Click += new System.EventHandler(this.ButtonRegister_Click);
            // 
            // LabelTransport
            // 
            this.LabelTransport.AutoSize = true;
            this.LabelTransport.Location = new System.Drawing.Point(9, 20);
            this.LabelTransport.Name = "LabelTransport";
            this.LabelTransport.Size = new System.Drawing.Size(55, 13);
            this.LabelTransport.TabIndex = 10;
            this.LabelTransport.Text = "Transport:";
            // 
            // LabelUserName
            // 
            this.LabelUserName.AutoSize = true;
            this.LabelUserName.Location = new System.Drawing.Point(9, 42);
            this.LabelUserName.Name = "LabelUserName";
            this.LabelUserName.Size = new System.Drawing.Size(63, 13);
            this.LabelUserName.TabIndex = 11;
            this.LabelUserName.Text = "User Name:";
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.Location = new System.Drawing.Point(12, 68);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(56, 13);
            this.LabelPassword.TabIndex = 12;
            this.LabelPassword.Text = "Password:";
            // 
            // LabelServer
            // 
            this.LabelServer.AutoSize = true;
            this.LabelServer.Location = new System.Drawing.Point(12, 90);
            this.LabelServer.Name = "LabelServer";
            this.LabelServer.Size = new System.Drawing.Size(41, 13);
            this.LabelServer.TabIndex = 13;
            this.LabelServer.Text = "Server:";
            // 
            // LabelServerPort
            // 
            this.LabelServerPort.AutoSize = true;
            this.LabelServerPort.Location = new System.Drawing.Point(12, 116);
            this.LabelServerPort.Name = "LabelServerPort";
            this.LabelServerPort.Size = new System.Drawing.Size(63, 13);
            this.LabelServerPort.TabIndex = 14;
            this.LabelServerPort.Text = "Server Port:";
            // 
            // LabelDomain
            // 
            this.LabelDomain.AutoSize = true;
            this.LabelDomain.Location = new System.Drawing.Point(12, 142);
            this.LabelDomain.Name = "LabelDomain";
            this.LabelDomain.Size = new System.Drawing.Size(46, 13);
            this.LabelDomain.TabIndex = 15;
            this.LabelDomain.Text = "Domain:";
            // 
            // LabelDisplayName
            // 
            this.LabelDisplayName.AutoSize = true;
            this.LabelDisplayName.Location = new System.Drawing.Point(12, 172);
            this.LabelDisplayName.Name = "LabelDisplayName";
            this.LabelDisplayName.Size = new System.Drawing.Size(75, 13);
            this.LabelDisplayName.TabIndex = 16;
            this.LabelDisplayName.Text = "Display Name:";
            // 
            // LabelAuthName
            // 
            this.LabelAuthName.AutoSize = true;
            this.LabelAuthName.Location = new System.Drawing.Point(12, 194);
            this.LabelAuthName.Name = "LabelAuthName";
            this.LabelAuthName.Size = new System.Drawing.Size(63, 13);
            this.LabelAuthName.TabIndex = 17;
            this.LabelAuthName.Text = "Auth Name:";
            // 
            // TextBoxStunPort
            // 
            this.TextBoxStunPort.Location = new System.Drawing.Point(12, 351);
            this.TextBoxStunPort.Name = "TextBoxStunPort";
            this.TextBoxStunPort.Size = new System.Drawing.Size(100, 20);
            this.TextBoxStunPort.TabIndex = 0;
            // 
            // TextBoxStunServer
            // 
            this.TextBoxStunServer.Location = new System.Drawing.Point(12, 377);
            this.TextBoxStunServer.Name = "TextBoxStunServer";
            this.TextBoxStunServer.Size = new System.Drawing.Size(100, 20);
            this.TextBoxStunServer.TabIndex = 1;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 481);
            this.Controls.Add(this.TextBoxStunPort);
            this.Controls.Add(this.TextBoxStunServer);
            this.Controls.Add(this.LabelAuthName);
            this.Controls.Add(this.LabelDisplayName);
            this.Controls.Add(this.LabelDomain);
            this.Controls.Add(this.LabelServerPort);
            this.Controls.Add(this.LabelServer);
            this.Controls.Add(this.LabelPassword);
            this.Controls.Add(this.LabelUserName);
            this.Controls.Add(this.LabelTransport);
            this.Controls.Add(this.ButtonRegister);
            this.Controls.Add(this.ListBoxSIPLog);
            this.Controls.Add(this.TextBoxAuthName);
            this.Controls.Add(this.TextBoxDisplayName);
            this.Controls.Add(this.TextBoxDomain);
            this.Controls.Add(this.TextBoxServerPort);
            this.Controls.Add(this.TextBoxServer);
            this.Controls.Add(this.TextBoxPassword);
            this.Controls.Add(this.TextBoxUserName);
            this.Controls.Add(this.ComboBoxTransport);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}