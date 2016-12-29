using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDILesson08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F11)
            {
                TakeScreen();
            }
            else if(keyData == Keys.F12)
            {
                // FullScreen Mode
                FormBorderStyle = FormBorderStyle.None;
                BringToFront();
                WindowState = FormWindowState.Maximized;
            }
            else if(keyData == Keys.Escape)
            {
                // Normal Mode
                FormBorderStyle = FormBorderStyle.Sizable;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TakeScreen();
        }

        private void TakeScreen()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Image screenshot = new Bitmap(bounds.Width, bounds.Height);
            Graphics g = Graphics.FromImage(screenshot);
            g.CopyFromScreen(0, 0, 0, 0, bounds.Size);
            BackgroundImage = screenshot;
            //SaveFileDialog dlg = new SaveFileDialog();
            //dlg.Filter = "jpeg file|*.jpeg;*.jpg|All files|*.*";
            //if(dlg.ShowDialog() == DialogResult.OK)
            //{
            //    screenshot.Save(dlg.FileName);
            //}
            g.Dispose();
        }
    }
}
