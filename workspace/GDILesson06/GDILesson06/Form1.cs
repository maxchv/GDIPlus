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

namespace GDILesson06
{
    public partial class Form1 : Form
    {
        private Pen pen;
        private Pen pen_gray;
        private Pen pen_orange;
        private Pen pen_purple;
        private Pen pen_red;

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            pen = new Pen(Color.Blue, 3);
            pen_red = new Pen(Color.Red, 3);
            pen_gray = new Pen(Color.LightGray, 2);
            pen_gray.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            pen_purple = new Pen(Color.Purple, 5);
            pen_orange = new Pen(Color.Orange, 3);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, 200, 100);
            // Перемещение страничных координат по горизонтали на 50px
            // по вертикали - на 80px
            
            //e.Graphics.PageUnit = GraphicsUnit.Millimeter; - единицы изменения устройства
            //e.Graphics.TranslateTransform(50, 80);
            //e.Graphics.DrawRectangle(pen_gray, rect);
            //e.Graphics.DrawString("0, 0", new Font("Arial", 12), Brushes.Blue, -17, -20);
            //// поворот по часовой стрелке на 30 град
            //e.Graphics.RotateTransform(30);
            //e.Graphics.DrawRectangle(pen, rect);
            //// сохранение состояния координат
            //GraphicsState savedState = e.Graphics.Save();
            //// возврат страничных координат в исходное состояние, т.е. в мировые
            //e.Graphics.ResetTransform();
            //e.Graphics.DrawRectangle(pen_red, rect);
            //// Восстановление состояния координат сохраненного в savedState
            //e.Graphics.Restore(savedState);
            //// Масштабирование координат - отдель по оси х, отдельно по оси у
            //e.Graphics.ScaleTransform(0.5f, 1.5f);
            //e.Graphics.DrawRectangle(pen_purple, 10, 10, 200, 100);
            // Смещение
            e.Graphics.ResetTransform();            
            //e.Graphics.TranslateTransform(150, 150);
            //e.Graphics.DrawRectangle(pen_gray, rect);

            // Matrix
            Matrix m = e.Graphics.Transform;
            //m.Translate(50, 50);
            //m.RotateAt(30, new PointF(30, 0));
            //m.Scale(1.25f, 0.25f);
            //m.Shear(1.25f, 0.25f);
            m.Translate(ClientRectangle.Width / 2f, ClientRectangle.Height / 2f);
            Matrix mirrorMatrix = new Matrix(1, 0, 0, -1, 0, 0);
            m.Multiply(mirrorMatrix);
            e.Graphics.Transform = m;
            Pen arrow = new Pen(Color.Blue, 3);
            arrow.EndCap = LineCap.ArrowAnchor;
            //e.Graphics.DrawRectangle(pen_orange, rect);
            e.Graphics.DrawLine(arrow, 0, 0, ClientRectangle.Width / 2f - 5, 0);
            e.Graphics.DrawLine(arrow, 0, 0, 0, ClientRectangle.Height/2f - 5);
        }
    }
}
