using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxIDE
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            label1.Text = "C# IDE, Version 1.0\r\n© Copyright Max Chesnokov 2016\r\nAll rights reserved";
        }
    }
}
