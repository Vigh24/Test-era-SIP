namespace EratronicsPhone
{
    partial class IncomingCallDialog
    {
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Label lblCallerDetails;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomingCallDialog));
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.lblCallerDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(42, 106);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(75, 23);
            this.btnAnswer.TabIndex = 0;
            this.btnAnswer.Text = "Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(216, 106);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 1;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // lblCallerDetails
            // 
            this.lblCallerDetails.AutoSize = true;
            this.lblCallerDetails.Location = new System.Drawing.Point(30, 30);
            this.lblCallerDetails.Name = "lblCallerDetails";
            this.lblCallerDetails.Size = new System.Drawing.Size(0, 13);
            this.lblCallerDetails.TabIndex = 2;
            // 
            // IncomingCallDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 150);
            this.Controls.Add(this.lblCallerDetails);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAnswer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncomingCallDialog";
            this.Text = "Incoming Call";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}