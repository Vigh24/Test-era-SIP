using System;
namespace SIPSample
{
    partial class videoScreen
    {
        /// <summary>
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // videoScreen
            // 
            this.ClientSize = new System.Drawing.Size(401, 284);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "videoScreen";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }
    }
}
