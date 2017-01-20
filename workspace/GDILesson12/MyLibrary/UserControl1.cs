using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary
{
    public partial class RoundButton: Button
    {
        Random rnd = new Random();
        public RoundButton()
        {
            InitializeComponent();
            backColor = Brushes.Red;
            BackColor = DefaultBackColor;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;

            StringFormat format = new StringFormat(StringFormatFlags.FitBlackBox);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            g.FillRectangle(new SolidBrush(DefaultBackColor), ClientRectangle);
            g.FillEllipse(backColor, ClientRectangle);
            g.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle, format);
        }
        
        protected override void OnClick(EventArgs e)
        {
            backColor = new SolidBrush(NextRandomColor());
            Refresh();
            base.OnClick(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            backColor = new SolidBrush(NextRandomColor());
            Refresh();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            backColor = new SolidBrush(NextRandomColor());
            Refresh();
            base.OnMouseLeave(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            backColor = Brushes.Gray;
            Refresh();
            base.OnGotFocus(e);
        }

        private Color NextRandomColor()
        {
            return Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }

        public Brush backColor;
    }
}
