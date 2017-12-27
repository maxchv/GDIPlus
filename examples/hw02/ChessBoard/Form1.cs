using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessBoard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawChessBoard();
        }

        private void DrawChessBoard()
        {
            int size = 8;
            bool isWhite    = true;
            bool isChecker  = false;
            int indent      = 40;
                        
            int sizeHeightRectangle = (ClientSize.Height - (indent * 2)) / 8;

            if((sizeHeightRectangle * 8) + (indent * 3) > Size.Width)
            {
                Size = new Size((sizeHeightRectangle * 8) + (indent * 3), Size.Height);
            }

            Graphics graphics   = this.CreateGraphics();
            Brush brush         = new SolidBrush(Color.FromArgb(64, 0, 0));

            int fontSize = (sizeHeightRectangle * 25) / 100;
            DrawLetters(indent, 0, sizeHeightRectangle, graphics, fontSize);
            DrawLetters(indent, ClientSize.Height - (indent), sizeHeightRectangle, graphics, fontSize);

            DrawNumbers(0, indent, sizeHeightRectangle, graphics, fontSize);
            DrawNumbers((sizeHeightRectangle * 8) + indent + 10, indent, sizeHeightRectangle, graphics, fontSize);
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Rectangle rectangle = new Rectangle(i * sizeHeightRectangle + indent, j * sizeHeightRectangle + indent, sizeHeightRectangle, sizeHeightRectangle);

                    if (isWhite)
                    {
                        graphics.DrawRectangle(Pens.White, rectangle);
                        graphics.FillRectangle(Brushes.White, rectangle);
                    }
                    else
                    {
                        graphics.DrawRectangle(Pens.Black, rectangle);
                        graphics.FillRectangle(brush, rectangle);
                    }

                    int x = (i * sizeHeightRectangle + indent);
                    int y = (j * sizeHeightRectangle + indent);
                    if(isChecker && j < 3)
                    {
                        graphics.FillEllipse(Brushes.Black, x, y, sizeHeightRectangle, sizeHeightRectangle);
                    }
                    else if(isChecker && j > (size / 2))
                    {
                        graphics.FillEllipse(Brushes.AntiqueWhite, x, y, sizeHeightRectangle, sizeHeightRectangle);
                    }

                    isWhite = !isWhite;
                    isChecker = !isChecker;
                }

                isWhite = !isWhite;
                isChecker = !isChecker;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            DrawChessBoard();
            Invalidate();
        }

        private void DrawLetters(int x, int y, int width, Graphics graphics, int fontSize)
        {
            Brush brush         = new SolidBrush(Color.FromArgb(64, 0, 0));
            Font font           = new Font("Arial", fontSize);
            int startX = x;

            for (int i = 1, l = 'a'; i <= 8; i++)
            {
                graphics.DrawString(Convert.ToChar(l++).ToString(), font, brush, startX + (width / 3), y);
                startX += width;
            }
        }

        private void DrawNumbers(int x, int y, int height, Graphics graphics, int fontSize)
        {
            Brush brush = new SolidBrush(Color.FromArgb(64, 0, 0));
            Font font = new Font("Arial", fontSize);
            int startY = y;

            for (int i = 8; i >= 1; i--)
            {
                graphics.DrawString(i.ToString(), font, brush, x, startY + (height / 3));
                startY += height;
            }
        }
    }
}