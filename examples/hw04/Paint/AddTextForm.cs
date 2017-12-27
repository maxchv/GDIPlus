using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class AddTextForm : Form
    {
        public string CurrentText { get; set; }

        public Color Color { get; set; }

        public Font FontText { get; set; }

        public AddTextForm()
        {
            InitializeComponent();

            Color = Color.Black;
            FontText = new Font("Arial", 10);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }        

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;

            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color = colorDialog.Color;
            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            try
            {
                FontDialog fontDialog = new FontDialog();

                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    FontText = fontDialog.Font;
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CurrentText = textBox1.Text;
        }
    }
}
