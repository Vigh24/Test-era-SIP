using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace SIPSample
{
    public partial class LogsForm : KryptonForm
    {
        public LogsForm(List<string> logs)
        {
            InitializeComponent();
            foreach (var log in logs)
            {
                listBoxLogs.Items.Add(log);
            }
        }
    }
}

