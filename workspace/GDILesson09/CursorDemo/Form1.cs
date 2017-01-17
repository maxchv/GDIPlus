using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursorDemo
{
    public partial class Form1 : Form
    {
        readonly Image[] _duck;
        int _x, _y;
        int _frame;
        
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            _duck = new Image[3];
            _duck[0] = new Bitmap(@"assets\duck\duckleft1.png");
            _duck[1] = new Bitmap(@"assets\duck\duckleft2.png");
            _duck[2] = new Bitmap(@"assets\duck\duckleft3.png");
            var timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 500;
            _x = 10;
            _y = 250;
            timer.Start();
            _frame = 0;
            DoubleBuffered = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _x += 10;
            _y += -15;
            _frame++;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(_duck[_frame % _duck.Length], _x, _y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor = new Cursor("crosshair.cur");                        
        }
    }
}
