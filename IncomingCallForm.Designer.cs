namespace SIPSample
{
    partial class IncomingCallForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCaller;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnHangUp;

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
            this.lblCaller = new System.Windows.Forms.Label();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnHangUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCaller
            // 
            this.lblCaller.AutoSize = true;
            this.lblCaller.Location = new System.Drawing.Point(12, 9);
            this.lblCaller.Name = "lblCaller";
            this.lblCaller.Size = new System.Drawing.Size(35, 13);
            this.lblCaller.TabIndex = 0;
            this.lblCaller.Text = "label1";
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(15, 35);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(75, 23);
            this.btnAnswer.TabIndex = 1;
            this.btnAnswer.Text = "Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(96, 35);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 2;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnHangUp
            // 
            this.btnHangUp.Enabled = false;
            this.btnHangUp.Location = new System.Drawing.Point(177, 35);
            this.btnHangUp.Name = "btnHangUp";
            this.btnHangUp.Size = new System.Drawing.Size(75, 23);
            this.btnHangUp.TabIndex = 3;
            this.btnHangUp.Text = "Hang Up";
            this.btnHangUp.UseVisualStyleBackColor = true;
            this.btnHangUp.Click += new System.EventHandler(this.btnHangUp_Click);
            // 
            // IncomingCallForm
            // 
            this.ClientSize = new System.Drawing.Size(264, 71);
            this.Controls.Add(this.btnHangUp);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.lblCaller);
            this.Name = "IncomingCallForm";
            this.Text = "Incoming Call";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}