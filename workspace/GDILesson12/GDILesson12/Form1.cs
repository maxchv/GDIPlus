using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDILesson12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rc = new Rectangle(10, 10, 70, 25);
            ControlPaint.DrawButton(e.Graphics, rc, ButtonState.Normal);
            rc.Y += 30;
            ControlPaint.DrawButton(e.Graphics, rc, ButtonState.Checked);
            rc.Y += 30;
            ControlPaint.DrawButton(e.Graphics, rc, ButtonState.Flat);
            rc.Y += 30;
            ControlPaint.DrawButton(e.Graphics, rc, ButtonState.Inactive);
            rc.Y += 35;
            ControlPaint.DrawButton(e.Graphics, rc, ButtonState.Pushed);
            rc.Y += 35;
            rc.Width = 25;
            ControlPaint.DrawCaptionButton(e.Graphics, rc, CaptionButton.Help, ButtonState.Normal);
            rc.Y += 35;
            ControlPaint.DrawCaptionButton(e.Graphics, rc, CaptionButton.Maximize, ButtonState.Normal);
        }
    }
}
