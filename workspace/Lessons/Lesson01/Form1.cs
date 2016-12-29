using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Math;
namespace Lesson01
{
    public partial class Form1 : Form
    {
        Dictionary<string, MethodInfo> exampleMethods = new Dictionary<string, MethodInfo>();
        Graphics g = null;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            initComboBox();            
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
        }

        ~Form1()
        {
            g.Dispose();
        }

        private void initComboBox()
        {
            Type t = GetType();
            List<MethodInfo> methods = new List<MethodInfo>(t.GetMethods());
            foreach (MethodInfo mi in methods.FindAll(m => m.Name.StartsWith("example")))
            {
                comboBox1.Items.Add(mi.Name);
                exampleMethods.Add(mi.Name, mi);
            }
            //comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string methodName = comboBox1.SelectedItem.ToString();
            if (exampleMethods.ContainsKey(methodName))
            {
                if(worker.IsBusy)
                {
                    worker.CancelAsync();
                    Thread.Sleep(100);
                }


                exampleMethods[methodName].Invoke(this, new object[] { });
            }            
        }

        public void example1()
        {
            g.Clear(Color.Black);

            Rectangle rect = new Rectangle(0, 0, panel1.Width, panel1.Height);

            g.DrawEllipse(Pens.White, rect);

            Pen pen = new Pen(Brushes.Blue, 5);
            pen.DashStyle = DashStyle.Dot;
            g.DrawRectangle(pen, rect);

            pen.Width = 6;
            pen.Color = Color.Brown;
            pen.DashStyle = DashStyle.DashDot;
            g.DrawLines(pen, new Point[] { new Point(0, 0), new Point(panel1.Width, panel1.Height) });

            Font font = new Font("Verdana", 35, FontStyle.Bold);

            g.DrawString("Hello, GDI+", font, Brushes.Yellow, 20, 20);

        }

        public void example2()
        {
            g.Clear(Color.White);
            int offset = 10;
            int width = panel1.Width - 2 * offset;
            int height = panel1.Height / 3 - 2 * offset;
            Rectangle rect = new Rectangle(10, 10, width, height);

            LinearGradientBrush lgBrush = new LinearGradientBrush(rect, Color.Blue, Color.Yellow, LinearGradientMode.Horizontal);
            g.DrawRectangle(Pens.Black, rect);
            g.FillRectangle(lgBrush, rect);

            HatchBrush hBrush = new HatchBrush(HatchStyle.Cross, Color.Yellow, Color.Blue);
            rect.Y += offset + height;
            g.FillRectangle(hBrush, rect);
            string textureFile = "texture.jpg";
            if (!File.Exists(textureFile))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile("http://www.bittbox.com/wp-content/uploads/2010/08/making_a_photoshop_brush_4.jpg", "texture.jpg");
            }
            Image img = Image.FromFile(textureFile);
            TextureBrush tBrush = new TextureBrush(img);
            rect.Y += offset + height;
            g.FillRectangle(tBrush, rect);
        }

        public void example3()
        {
            g.Clear(Color.White);
            Font font = new Font("Verdana", 35, FontStyle.Bold);
            Point origin = new Point(panel1.Width / 2, panel1.Height / 2);

            g.DrawString("Hello", font, Brushes.Blue, origin);
        }

        public void example4()
        {
            g.Clear(Color.White);
            string imgFile = "image.png";
            if (!File.Exists(imgFile))
            {
                WebClient client = new WebClient();
                client.DownloadFile("http://lugansk.itstep.org/pko/images/programmer/comps/step-center-logo.png", imgFile);
            }
            Image img = Image.FromFile(imgFile);
            Rectangle rect = panel1.ClientRectangle;
            rect.Width = rect.Height;
            g.DrawImage(img, rect);
        }

        private void drawText(string text, int x, int y)
        {
            Font font = new Font("Verdana", 10);            
            SizeF sizeText = g.MeasureString(text, font);
            g.DrawString(text, font, Brushes.Black, x - sizeText.Width / 2, y);
        }

        public void example5()
        {
            g.Clear(Color.White);

            int offset = 10;
            int panelHeight = panel1.Height;
            int panelWidth = panel1.Width;

            int sectionHeight = panelHeight / 4 - offset;
            int halfHeightOfSection = sectionHeight / 2;
            int quarterWidthOfSection = (panelWidth - 2 * offset) / 4;

            Pen linePen = new Pen(Brushes.Gray);
            linePen.DashStyle = DashStyle.Dash;
            linePen.Width = 2;

            Rectangle rect1 = new Rectangle(offset, offset, quarterWidthOfSection * 3, halfHeightOfSection);
            Rectangle rect2 = new Rectangle(offset + quarterWidthOfSection, halfHeightOfSection- offset, quarterWidthOfSection*3, halfHeightOfSection);
            g.DrawRectangle(Pens.Blue, rect1);
            g.DrawRectangle(Pens.Red, rect2);

            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Пересечение
            rgn1.Intersect(rgn2);
            g.FillRegion(Brushes.BlueViolet, rgn1);

            drawText("Intersect", panelWidth / 2, panelHeight / 4 - 20);
            g.DrawLine(linePen, 0, panelHeight / 4, panelWidth, panelHeight / 4);

            rect1.Y += sectionHeight + offset;
            rect2.Y += sectionHeight + offset;
            g.DrawRectangle(Pens.Blue, rect1);
            g.DrawRectangle(Pens.Red, rect2);

            rgn1 = new Region(rect1);
            rgn2 = new Region(rect2);
            
            // Исключение
            rgn1.Exclude(rgn2);
            g.FillRegion(Brushes.BlueViolet, rgn1);
                        
            drawText("Exclude", panelWidth / 2, panelHeight / 2 - 20);
            g.DrawLine(linePen, 0, panelHeight / 2, panelWidth, panelHeight / 2);

            rect1.Y += sectionHeight + offset;
            rect2.Y += sectionHeight + offset;
            g.DrawRectangle(Pens.Blue, rect1);
            g.DrawRectangle(Pens.Red, rect2);

            rgn1 = new Region(rect1);
            rgn2 = new Region(rect2);
            // Объединение
            rgn1.Union(rgn2);
            g.FillRegion(Brushes.BlueViolet, rgn1);

            drawText("Union", panelWidth / 2, panelHeight * 3 / 4 - 20);
            g.DrawLine(linePen, 0, panelHeight * 3 / 4, panelWidth, panelHeight * 3 / 4);

            rect1.Y += sectionHeight + offset;
            rect2.Y += sectionHeight + offset;
            g.DrawRectangle(Pens.Blue, rect1);
            g.DrawRectangle(Pens.Red, rect2);

            rgn1 = new Region(rect1);
            rgn2 = new Region(rect2);
            // Исключающее или
            rgn1.Xor(rgn2);
            g.FillRegion(Brushes.BlueViolet, rgn1);

            drawText("Xor", panelWidth / 2, panelHeight - 20);
        }

        public void example6()
        {
            g.Clear(Color.White);
            Point[] points = { new Point(5, 10), new Point(23, 130), new Point(130, 37) };

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddEllipse(170, 170, 100, 50);
            
            g.FillPath(Brushes.Aqua, path);

            path.AddCurve(points, 0.5f);
            path.AddArc(100, 50, 100, 100, 0, 120);
            path.AddLine(50, 150, 50, 220);
            path.CloseFigure();

            path.StartFigure();
            path.AddArc(180, 30, 60, 60, 0, -170);
            
            g.DrawPath(new Pen(Color.Blue, 3), path);
        }

        public void example7()
        {
            g.Clear(Color.White);

            int width = panel1.Width;
            int heigth = panel1.Height;
            Pen clockPen =  new Pen(Color.Blue, 3);
            Pen tickPen = new Pen(Color.Blue, 3);
            int x = (width - heigth) / 2;
            g.DrawEllipse(clockPen, x, 0, heigth, heigth);

            g.TranslateTransform(width/2, heigth/2);
            for (int i = 0; i < 12; i++)
            {
                g.DrawLine(new Pen(Color.Blue, 3), heigth / 2 - 20, 0, heigth/2, 0);
                g.RotateTransform(360/12);
            }
            
            Pen minuteLine = new Pen(Color.Black, 6);
            minuteLine.StartCap = LineCap.DiamondAnchor;
            minuteLine.EndCap = LineCap.ArrowAnchor;
                        
            g.DrawLine(minuteLine, 0, 0, heigth / 2 - 30, 0);

            g.RotateTransform(45);

            g.DrawLine(minuteLine, 0, 0, heigth / 2 - 50, 0);

            g.ResetTransform();            
            
        }

        public void example8()
        {
            g.Clear(Color.Black);
            Action draw = () =>
            {
                int x = 0;
                int y = 0;
                Random rand = new Random();
                for (int i = 0; i <= 100000; i++)
                {
                    int r = rand.Next(1, 4);
                    int ux = 30;
                    int uy = 0;
                    if (r == 1)
                    {
                        ux = 30;
                        uy = 1000;
                    }
                    if (r == 2)
                    {
                        ux = 1000;
                        uy = 1000;
                    }
                    x = (x + ux) / 2;
                    y = (y + uy) / 2;

                    g.FillEllipse(Brushes.LightGreen, x, y, 2, 2);
                }
            };
            this.Invalidate();           
            worker.DoWork += worker_DoWork;            
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int x = 0;
            int y = 0;
            Random rand = new Random();
            for (int i = 0; i <= 100000; i++)
            {
               
                int r = rand.Next(1, 4);
                int ux = 30;
                int uy = 0;
                if (r == 1)
                {
                    ux = 30;
                    uy = 1000;
                }
                if (r == 2)
                {
                    ux = 1000;
                    uy = 1000;
                }
                x = (x + ux) / 2;
                y = (y + uy) / 2;

                if (worker.CancellationPending)
                {
                    break;
                }
                g.FillEllipse(Brushes.LightGreen, x, y, 2, 2);
            }
        }

        public void example9()
        {
            g.Clear(Color.White);
            
            Bitmap img = new Bitmap("btn.bmp");
            Graphics bg = Graphics.FromImage(img);
            Font font = new Font("Verdana", 10, FontStyle.Italic);
            string text = DateTime.Now.ToString();
            SizeF sizeFont = bg.MeasureString(text, font);

            bg.DrawString(text, font, Brushes.LightPink, (img.Width - sizeFont.Width) / 2, (img.Height - sizeFont.Height) / 2);
            
            img.Save("btn_new.bmp");
            g.DrawImage(img, 10, 10);
        }

        public void example10()
        {
            g.Clear(Color.White);
            g.FillPolygon(Brushes.LightSeaGreen, new Point[] {
                new Point(10, 10), new Point(10, 50), new Point(50, 50), 
                new Point(10, 10)
            });
        }

        public void example11()
        {
            g.Clear(Color.White);

            GraphicsPath path = new GraphicsPath();
            path.AddLine(100, 100, 220, 220);

            Matrix m = new Matrix();
            m.RotateAt(-30, new Point(0, 0));
            path.Transform(m);

            g.DrawPath(new Pen(Color.SeaGreen, 5), path);            
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public BackgroundWorker worker { get; set; }
    }
}
