namespace EratronicsPhone
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncomingCallForm));
            this.lblCaller = new System.Windows.Forms.Label();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnHangUp = new System.Windows.Forms.Button();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
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
            this.btnAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.btnHangUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHangUp.Location = new System.Drawing.Point(177, 35);
            this.btnHangUp.Name = "btnHangUp";
            this.btnHangUp.Size = new System.Drawing.Size(75, 23);
            this.btnHangUp.TabIndex = 3;
            this.btnHangUp.Text = "Hang Up";
            this.btnHangUp.UseVisualStyleBackColor = true;
            this.btnHangUp.Click += new System.EventHandler(this.btnHangUp_Click);
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.kryptonPalette1.ButtonSpecs.FormClose.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.kryptonPalette1.ButtonSpecs.FormMax.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.kryptonPalette1.ButtonSpecs.FormMin.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 8;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.Transparent;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.Transparent;
            // 
            // IncomingCallForm
            // 
            this.ClientSize = new System.Drawing.Size(264, 71);
            this.Controls.Add(this.btnHangUp);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.lblCaller);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncomingCallForm";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.Text = "Incoming Call";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
    }
}