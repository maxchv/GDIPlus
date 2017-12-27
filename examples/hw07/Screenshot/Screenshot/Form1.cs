using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screenshot
{
    public partial class Form1 : Form
    {
        Image screen;
        Image elka = Image.FromFile("elka.png");
        List<Showflake> snow;

        Random rand = new Random();
        public Form1()
        {
            CreateScreenShot();
            InitializeComponent();
            snow = new List<Showflake>();

            int size;
            int img;
            for(int i = 0;i<50;i++)
            {
                size = rand.Next(10, 50);
                img = rand.Next(1, 4);
                Image imgSnow = new Bitmap(Image.FromFile("snow" + img + ".png"), new Size(size, size));
                snow.Add(new Showflake(new Point(rand.Next(0, screen.Width), 0), imgSnow, rand.Next(1, 10),rand.Next(0,screen.Width)));
            }           

            pictureBox1.Image = screen;
            MinMaxEd();

            Timer tm = new Timer();
            tm.Interval = 10;
            tm.Tick += Tm_Tick;
            tm.Start();

            Invalidate();
        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.F11)
            {
                MinMaxEd();

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MinMaxEd()
        {
            FormBorderStyle = WindowState == FormWindowState.Normal ? FormBorderStyle.None : FormBorderStyle.Sizable;
            BringToFront();
            WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void CreateScreenShot()
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;
            screen = new Bitmap(rect.Width, rect.Height);
            Graphics g = Graphics.FromImage(screen);
            g.CopyFromScreen(0, 0, 0, 0, rect.Size);
            g.Dispose();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawElka(e.Graphics);
            int xItem;
            int yItem;
            foreach (var item in snow)
            {
                e.Graphics.DrawImage(item.Image, item.Location);
                
                if (item.Location.X > item.Where)
                    xItem = item.Location.X - 1;
                else
                    xItem = item.Location.X + 1;

                yItem = item.Location.Y + item.Speed;

                if (item.Location.Y > ClientRectangle.Height)
                {
                    item.Location = new Point(rand.Next(0, ClientRectangle.Width), 0);
                }
                else
                {
                    item.Location = new Point(xItem, yItem);
                }
            }
        }

        private void DrawElka(Graphics g)
        {
            Image img = new Bitmap(elka, new Size(ClientRectangle.Width / 2, ClientRectangle.Height - 30));
            g.DrawImage(img, (ClientRectangle.Width / 2) - (img.Width / 2), 0);
        }
    }
}
