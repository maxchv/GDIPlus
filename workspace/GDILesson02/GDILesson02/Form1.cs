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

namespace GDILesson02
{
    public partial class Form1 : Form
    {
        DashStyle dashStyle = DashStyle.Solid;
        LineCap lineCap = LineCap.AnchorMask;
        private LineJoin lineJoin;
        private float widthLines;

        public Form1()
        {
            InitializeComponent();

            string[] dashStyles = Enum.GetNames(typeof(DashStyle));
            comboBox1.Items.AddRange(dashStyles);            
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            string[] lineCaps = Enum.GetNames(typeof(LineCap));
            comboBox2.Items.AddRange(lineCaps);
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            string[] lineJoins = Enum.GetNames(typeof(LineJoin));
            comboBox3.Items.AddRange(lineJoins);
            comboBox3.SelectedIndexChanged += ComboBox3_SelectedIndexChanged;
            comboBox3.SelectedIndex = 0;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            widthLines = float.Parse(numericUpDown1.Value.ToString());
            Invalidate();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            lineJoin = (LineJoin)Enum.Parse(typeof(LineJoin), comboBox3.SelectedItem.ToString());
            Invalidate();
        }
    

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lineCap = (LineCap)Enum.Parse(typeof(LineCap), comboBox2.SelectedItem.ToString());
            Invalidate();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dashStyle = (DashStyle)Enum.Parse(typeof(DashStyle), comboBox1.SelectedItem.ToString());
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //e.Graphics.MeasureString() -- замер размера текста

            Pen pen = new Pen(Color.Blue);
            pen.Width = widthLines;
            pen.DashStyle = dashStyle;
            pen.StartCap = lineCap;
            pen.EndCap = lineCap;
            pen.DashCap = DashCap.Triangle;
            pen.LineJoin = lineJoin;
            //pen.DashPattern = new float[]{ 5f, 15f};
            
            PointF[] points = { new PointF(50, 100), new PointF(600, 100), new PointF(50, 300) };
            e.Graphics.DrawCurve(pen, points, 0);
        }
    }

    
}
