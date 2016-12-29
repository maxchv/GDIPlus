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

namespace GDILesson04
{
    public partial class Form1 : Form
    {
        Color color = Color.White;
        HatchStyle hatchStyle = HatchStyle.BackwardDiagonal;
        WrapMode wrapMode = WrapMode.Clamp;

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;

            comboBox1.Items.AddRange(Enum.GetNames(typeof(HatchStyle)));
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(Enum.GetNames(typeof(WrapMode)));
            comboBox2.SelectedIndex = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue, new RectangleF(10, 10, 250, 150));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(10, 10, 250, 150));

            SolidBrush brush = new SolidBrush(color);
            e.Graphics.FillRectangle(brush, new RectangleF(10, 170, 250, 150));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(10, 170, 250, 150));

            Rectangle rect = new Rectangle(10, 330, 250, 150);
            e.Graphics.DrawRectangle(Pens.Black, rect);
            LinearGradientBrush linearBrush = new LinearGradientBrush(rect, Color.Red, Color.Orange, LinearGradientMode.Horizontal);
            //linearBrush.Blend = new Blend(2);
            linearBrush.LinearColors = new Color[] { Color.Blue, Color.Red, Color.White };
            //linearBrush.WrapMode = wrapMode;
                        
            e.Graphics.FillRectangle(linearBrush, rect);

            HatchBrush hatchBrush = new HatchBrush(hatchStyle, Color.Black, Color.Yellow);
            e.Graphics.FillRectangle(hatchBrush, new RectangleF(270, 10, 250, 150));
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(270, 10, 250, 150));

            Image img = Image.FromFile("snowflake.png");
            Rectangle rect2 = new Rectangle(270, 170, 500, 500);
            e.Graphics.DrawRectangle(Pens.Black, rect2);
            TextureBrush textureBrush = new TextureBrush(img, wrapMode);            
            e.Graphics.FillRectangle(textureBrush, rect2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                color = dlg.Color;
                Invalidate();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            hatchStyle = (HatchStyle)Enum.Parse(typeof(HatchStyle), comboBox1.SelectedItem.ToString());
            Invalidate();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            wrapMode = (WrapMode)Enum.Parse(typeof(WrapMode), comboBox2.SelectedItem.ToString());
            Invalidate();
        }
    }
}
