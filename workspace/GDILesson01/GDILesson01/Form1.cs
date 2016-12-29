using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDILesson01
{
    public partial class Form1 : Form
    {
        class Circle
        {
            public Point Center { get; set; }
            public int Radius { get; set; }
            public int Diameter { get { return Radius * 2; } }
        }

        int countPainted = 0;
        Random rnd = new Random();

        List<Circle> circles = new List<Circle>();

        public Form1()
        {
            InitializeComponent();

            Paint += Form1_Paint;
            SizeChanged += Form1_SizeChanged;
            MouseClick += Form1_MouseClick;         
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            circles.Add(new Circle() { Center = new Point(e.X, e.Y),
                                       Radius = rnd.Next(5, 10) });            
            Invalidate(); // вызывает событие Paint
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Text = "size: " + ClientRectangle.Width + "x" + ClientRectangle.Height;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach(Circle c in circles)
            {   
                int x = c.Center.X - c.Radius;
                int y = c.Center.Y - c.Radius;

                int r = rnd.Next(0, 255), g = rnd.Next(0, 255), b = rnd.Next(0, 255);

                Brush brush = new SolidBrush(Color.FromArgb(r, g, b));

                e.Graphics.FillEllipse(brush, x, y, c.Diameter, c.Diameter);
            }
            
            //e.Graphics.FillRectangle(Brushes.Black, 0, 140, 250, 140);
            //Font font = new Font("Arial", 22, FontStyle.Italic);
            //e.Graphics.DrawString("Hello GDI+", font, Brushes.Yellow, 50, 50);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //DrawRedRectangle();
            //e.Graphics.FillRectangle(Brushes.Red, 0, 0, 250, 140);
        }

        private void DrawRedRectangle()
        {
            Graphics g = CreateGraphics();
            Rectangle rect = new Rectangle(0, 0, 250, 140);
            //Brush redBrush = Brushes.Red; // new SolidBrush(Color.Red);            
            g.FillRectangle(Brushes.Red, rect);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        //public new Graphics CreateGraphics()
        //{
        //    return base.CreateGraphics();
        //}
    }
}
