using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watermark
{
    public partial class WatermarkDialog : Form
    {

        public Image WaterImage { get; private set; }
        public string WaterText { get; private set; }
        public int WidthTextBoxWatermark { get; private set; }
        public Font FontTextBox { get; private set; }

        public WatermarkDialog()
        {
            InitializeComponent();
            WaterImage = null;
            WaterText = "";
            WidthTextBoxWatermark = textBoxWatermark.Width;
            FontTextBox = textBoxWatermark.Font;
        }

        private void buttonAddPicture_Click(object sender, EventArgs e)
        {
            if (WaterImage == null)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = ("Картинки|*.bmp;*.jpg;*.jpeg;*.png");
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    WaterImage = Image.FromFile(dlg.FileName);
                    pictureBoxImageWatermark.Image = WaterImage;
                }
                buttonAddPicture.Text = "Удалить картинку";
            }
            else
            {
                pictureBoxImageWatermark.Image = null;
                WaterImage = null;
                buttonAddPicture.Text = "Добавить картинку";
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(textBoxWatermark.Text!="")
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void textBoxWatermark_TextChanged(object sender, EventArgs e)
        {
            WaterText = textBoxWatermark.Text;
        }

        private void WatermarkDialog_Resize(object sender, EventArgs e)
        {
            WidthTextBoxWatermark = textBoxWatermark.Width;
        }
    }
}
