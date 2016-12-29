using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegionDemo
{
    enum RegionOperations
    {
        Union, Complement, Intersect, Exclude, Xor
    }
    public partial class Form1 : Form
    {
        RegionOperations regionOperation = RegionOperations.Union;
        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;
            comboBox1.Items.AddRange(Enum.GetNames(typeof(RegionOperations)));
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            regionOperation = (RegionOperations)Enum.Parse(typeof(RegionOperations), comboBox1.SelectedItem.ToString());
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var rect1 = new Rectangle(100, 100, 120, 120);
            var rect2 = new Rectangle(70, 70, 120, 120);
            var rect3 = new Rectangle(120, 30, 140, 140);


            Region r1 = new Region(rect1);
            Region r2 = new Region(rect2);
            Region r3 = new Region(rect3);

            e.Graphics.DrawRectangle(Pens.Gray, rect1);
            e.Graphics.DrawRectangle(Pens.Blue, rect2);
            e.Graphics.DrawRectangle(Pens.Red, rect3);

            switch (regionOperation)
            {
                case RegionOperations.Union:
                    r1.Union(r2);
                    r1.Union(r3);
                    break;
                case RegionOperations.Complement:
                    r1.Complement(r2);
                    r1.Complement(r3);
                    break;
                case RegionOperations.Intersect:
                    r1.Intersect(r2);
                    r1.Intersect(r3);
                    break;
                case RegionOperations.Exclude:
                    r1.Exclude(r2);
                    r1.Exclude(r3);
                    break;
                case RegionOperations.Xor:
                    r1.Xor(r2);
                    r1.Xor(r3);
                    break;
                default:
                    break;
            }

            e.Graphics.FillRegion(Brushes.Green, r1);
           // e.Graphics.FillRegion(Brushes.Blue, r2);
        }
    }
}
