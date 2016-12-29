using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDILesson03
{
    public partial class Form1 : Form
    {
        private int xb;
        private int yb;
        private int d = 30;

        Timer timer = new Timer();
        int t;
        int dt;
        int dist;

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;

            MouseDown += Form1_MouseDown;

            int x0 = ClientRectangle.Width / 2;
            int y0 = ClientRectangle.Height / 2;

            xb = 50; //x0 - d / 2;
            yb = y0 - d / 2;

            t = 2000;
            dist = ClientRectangle.Width - xb;
            dt = 10;

            timer.Tick += Timer_Tick;
            timer.Interval = dt;
            DoubleBuffered = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            int dx = dist * dt / t;
            xb += dx;
            if(xb > ClientRectangle.Width)
            {
                timer.Stop();
            }
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(!timer.Enabled)
            {
                timer.Start();
            }
            //int xm = e.X;
            //int ym = e.Y;
            //xb = xm - d/2;
            //yb = ym - d/2;
            //Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {            
            DrawBall(e);
        }

        private void DrawBall(PaintEventArgs e)
        {            
            RectangleF rect = new RectangleF(xb, yb, d, d);
            e.Graphics.FillEllipse(Brushes.Red, rect);
        }
    }
}
