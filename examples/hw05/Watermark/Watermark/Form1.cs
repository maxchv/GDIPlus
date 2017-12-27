using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watermark
{
    public partial class Form1 : Form
    {
        List<string> names = new List<string>();
        List<Image> imgs = new List<Image>();
        List<bool> canAddWatermark = new List<bool>();
        int idxImgNow;

        WatermarkDialog dlgWater = new WatermarkDialog();

        bool waterMarkExist = false;

        bool canMove = false;
        Point newLocation;

        public bool WaterMarkExist
        {
            get { return waterMarkExist; }
            set
            {
                waterMarkExist = value;
                if (imgs.Count > 0)
                {
                    buttonSetMark.Enabled = waterMarkExist;
                    pictureBoxWatermark.Visible = waterMarkExist;
                }
                else
                    waterMarkExist = false;
            }
        }

        public int IdxImgNow
        {
            get { return idxImgNow; }
            set
            {
                idxImgNow = value;
                if (idxImgNow >= 0 && idxImgNow < imgs.Count)
                {
                    ShowImage();
                }
                else if (idxImgNow >= imgs.Count)
                    IdxImgNow = 0;
                else if (idxImgNow < 0)
                    IdxImgNow = imgs.Count - 1;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string []namesgiles = Directory.GetFiles(dlg.SelectedPath);
                imgs.Clear();
                canAddWatermark.Clear();
                foreach (string name in namesgiles)
                {
                    string ext = Path.GetExtension(name);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp")
                    {
                        names.Add(name);
                        imgs.Add(Image.FromFile(name));
                        canAddWatermark.Add(true);
                    }
                }

                if (imgs.Count > 0)
                {
                    IdxImgNow = 0;
                }
                else
                    pictureBoxImage.Image = null;


                if (imgs.Count > 1)
                {
                    buttonPrev.Enabled = true;
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonPrev.Enabled = false;
                    buttonNext.Enabled = false;
                }
            }
        }

        private void ShowImage()
        {
            pictureBoxImage.Image = imgs[IdxImgNow];
            //Text = $"pictbox = {pictureBoxImage.Width}x{pictureBoxImage.Height} img = {pictureBoxImage.Image.Width}x{pictureBoxImage.Image.Height}";
            Text = Path.GetFileNameWithoutExtension(names[IdxImgNow]);
            if (waterMarkExist)
            {
                buttonSetMark.Enabled = canAddWatermark[IdxImgNow];
            }
        }

        private void createWatermarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlgWater.ShowDialog() == DialogResult.OK)
            {
                CreatingWatermark();
                createWatermarkToolStripMenuItem.Text = "Изменить...";
                WaterMarkExist = true;
            }
        }

        private void CreatingWatermark()
        {
            Bitmap b;

            int widthSymb = (int)dlgWater.FontTextBox.GetHeight(dlgWater.FontTextBox.Height);

            if (dlgWater.WaterImage != null)
                b = new Bitmap(50 + (dlgWater.WaterText.Length * widthSymb), 50);
            else
                b = new Bitmap((dlgWater.WaterText.Length * widthSymb), 50);

            b.MakeTransparent();

            using (Graphics g = Graphics.FromImage(b))
            {
                if (dlgWater.WaterImage != null)
                {
                    g.DrawImage(dlgWater.WaterImage, 0, 0, 50, 50);
                    g.DrawString(dlgWater.WaterText, dlgWater.FontTextBox, Brushes.Black, 50, 3);
                }
                else
                    g.DrawString(dlgWater.WaterText, dlgWater.FontTextBox, Brushes.Black, 0, 3);

                b.Save("Watermark.bmp");
            }
            pictureBoxWatermark.Image = b;
            pictureBoxWatermark.Width = b.Width;
        }

        #region"События для претаскивания"
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            canMove = false;
        }

        private void pictureBoxWatermark_MouseDown(object sender, MouseEventArgs e)
        {
            canMove = true;
            newLocation = e.Location;
        }

        private void pictureBoxWatermark_MouseUp(object sender, MouseEventArgs e)
        {
            canMove = false;
        }

        private void pictureBoxWatermark_MouseMove(object sender, MouseEventArgs e)
        {
            if (canMove)
            {
                pictureBoxWatermark.Top += e.Y - newLocation.Y;
                pictureBoxWatermark.Left += e.X - newLocation.X;
            }
        }
        #endregion

        private void selectFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = ("Картинки|*.bmp;*.jpg;*.jpeg;*.png");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBoxWatermark.Image = Image.FromFile(dlg.FileName);
                WaterMarkExist = true;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            IdxImgNow++;
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            IdxImgNow--;
        }

        private void buttonSetMark_Click(object sender, EventArgs e)
        {
            float wfactor = (float)pictureBoxImage.Image.Width / pictureBoxImage.ClientSize.Width;
            float hfactor = (float)pictureBoxImage.Image.Height / pictureBoxImage.ClientSize.Height;

            float resizeFactor = Math.Max(wfactor, hfactor);
            //Size imageSize = new Size((int)(pictureBoxImage.Image.Width / resizeFactor), (int)(pictureBoxImage.Image.Height / resizeFactor));

            Bitmap selectionImage = new Bitmap(imgs[IdxImgNow], pictureBoxImage.Image.Size);

            selectionImage.MakeTransparent();
            using (Graphics g = Graphics.FromImage(selectionImage))
            {
                float x = (pictureBoxWatermark.Location.X - pictureBoxImage.Location.X) * wfactor;
                float y = (pictureBoxWatermark.Location.Y - pictureBoxImage.Location.Y) * hfactor;

                float width = pictureBoxWatermark.Width * wfactor;
                float height = pictureBoxWatermark.Height * hfactor;

                g.DrawImage(pictureBoxWatermark.Image, x, y, width, height);
            }
            string patnNewImage;

            int idxFile = 0;
            do
            {
                patnNewImage = names[IdxImgNow] + "WM" + (idxFile == 0 ? "" : idxFile + "") + Path.GetExtension(names[IdxImgNow]);
                idxFile++;
            } while (File.Exists(patnNewImage));

            selectionImage.Save(patnNewImage);

            canAddWatermark[IdxImgNow] = false;
            buttonSetMark.Enabled = canAddWatermark[IdxImgNow];
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
