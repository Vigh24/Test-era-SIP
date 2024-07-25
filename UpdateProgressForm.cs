using System;
using System.Windows.Forms;

namespace EratronicsPhone
{
    public partial class UpdateProgressForm : Form
    {
        public UpdateProgressForm()
        {
            InitializeComponent();
        }

        public void SetStatus(string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetStatus), status);
            }
            else
            {
                this.statusLabel.Text = status;
            }
        }
    }
}