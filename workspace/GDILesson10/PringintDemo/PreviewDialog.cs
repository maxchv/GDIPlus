using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PringintDemo
{
    public partial class PreviewDialog : Form
    {

        public PrintPreviewControl PrintPreviewControl
        {
            get { return printPreviewControl1; }
            set { printPreviewControl1 = value; }
        }

        public PreviewDialog()
        {
            InitializeComponent();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            printPreviewControl1.StartPage++;
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            printPreviewControl1.StartPage = printPreviewControl1.StartPage > 0 ? printPreviewControl1.StartPage - 1 : 0;
        }
    }
}
