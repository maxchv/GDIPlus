using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDILesson07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath(FillMode.Alternate);
            path.AddLine(20, 20, 170, 20);
            path.AddLine(20, 20, 20, 100);

            path.StartFigure();
            path.AddLine(240, 140, 240, 50);
            path.AddLine(240, 140, 80, 140);

            path.AddEllipse(210, 55, 50, 50);

            path.AddRectangle(new RectangleF(30, 30, 200, 100));

            Pen pen = new Pen(Color.Blue, 3);

            Matrix m = new Matrix();
            m.Translate(50, 50);
            path.Transform(m);

            e.Graphics.DrawPath(pen, path);
            e.Graphics.FillPath(Brushes.Red, path);

            e.Graphics.DrawRectangle(Pens.Blue, 0, 0, 200, 100);
        }
    }
}
