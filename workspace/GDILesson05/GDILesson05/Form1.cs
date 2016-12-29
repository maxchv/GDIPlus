using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDILesson05
{
    public partial class Form1 : Form
    {
        Image img;
        Graphics gImg;
        List<Point> points = new List<Point>();

        public Form1()
        {
            InitializeComponent();

            Paint += Form1_Paint;
            MouseDown += Form1_MouseDown;
            MouseUp += Form1_MouseUp;

            DoubleBuffered = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.X <= img.Width && e.Y <= img.Height)
            {
                points.Add(e.Location);
            }
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //points.Add(e.Location);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(img != null && gImg != null)
            {   
                e.Graphics.DrawImage(img, 0, 0);
                Pen pen = new Pen(Color.Blue, 3);
                if (points.Count > 1)
                {
                    e.Graphics.DrawLines(pen, points.ToArray());
                    gImg.DrawLines(pen, points.ToArray());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {   
                img = Image.FromFile(dlg.FileName);
                gImg = Graphics.FromImage(img);
                gImg.SmoothingMode = SmoothingMode.HighSpeed;
                Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Jpeg files|*.jpg|Bmp files|*.bmp";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                string ext = Path.GetExtension(filename);
                switch(ext)
                {
                    case ".jpg":
                        img.Save(filename, ImageFormat.Jpeg);
                        break;
                    case ".bmp":
                        img.Save(filename, ImageFormat.Bmp);
                        break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int width = ClientRectangle.Width;
            int height = ClientRectangle.Height;
            img = new Bitmap(width, height);
            gImg = Graphics.FromImage(img);
            gImg.FillRectangle(Brushes.White, 0, 0, width, height);            
        }
    }
}
