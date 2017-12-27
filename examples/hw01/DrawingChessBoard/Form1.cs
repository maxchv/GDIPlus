using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingChessBoard
{
    public partial class Form1 : Form
    {
        bool bIsSimple;
        public Form1()
        {
            InitializeComponent();
            bIsSimple = false;
            Text = "Chessboard";
            DrawChessBoard();
            Resize += Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawChessBoard();
        }

        private void DrawChessBoard()
        {
            CreateGraphics().Clear(Color.White);

            int iWidthHeightCell;
            if (ClientSize.Width < ClientSize.Height)
                iWidthHeightCell = ClientSize.Width / (bIsSimple ? 8 : 10);
            else
                iWidthHeightCell = ClientSize.Height / (bIsSimple ? 8 : 10);

            //DarkGoldenrod
            //Wheat
            //SaddleBrown

            if (!bIsSimple)
                DrawVerticalCoords(iWidthHeightCell, new Point(iWidthHeightCell, 1));

            DrawCells(iWidthHeightCell);


            DrawVerticalCoords(iWidthHeightCell, new Point(iWidthHeightCell, iWidthHeightCell * 9));


            DrawBorders(iWidthHeightCell);
        }

        private void DrawBorders(int iWidthHeightCell)
        {            Graphics gField = CreateGraphics();
            for (int i = 0; i < (bIsSimple ? 8 : 10); i++)
                for (int j = 0; j < (bIsSimple ? 8 : 10); j++)
                    gField.DrawRectangle(Pens.SaddleBrown, 0 + i * iWidthHeightCell, 0 + j * iWidthHeightCell, iWidthHeightCell, iWidthHeightCell);

        }

        private void DrawVerticalCoords(int iWidthHeightCell, Point pStart)
        {
            if (!bIsSimple)
            {
                Graphics gField = CreateGraphics();
                gField.FillRectangle(Brushes.SaddleBrown, 0, pStart.Y, iWidthHeightCell, iWidthHeightCell);
                for (int i = 0; i < 8; i++)
                {
                    gField.FillRectangle(Brushes.DarkGoldenrod, iWidthHeightCell + i * iWidthHeightCell, pStart.Y, iWidthHeightCell, iWidthHeightCell);
                    gField.DrawString(((char)(65 + i)) + "", new Font("Arial", iWidthHeightCell / 2 + 5, FontStyle.Regular), Brushes.SaddleBrown, iWidthHeightCell + i * iWidthHeightCell, pStart.Y);
                }
                gField.FillRectangle(Brushes.SaddleBrown, 9 * iWidthHeightCell, pStart.Y, iWidthHeightCell, iWidthHeightCell);
            }
        }

        private void DrawCells(int iWidthHeightCell)
        {
            bool bIsEven = false;
            Graphics gField = CreateGraphics();

            for (int i = 0; i < 8; i++)
            {
                DrawHorizontalCoord(iWidthHeightCell, i, 0);

                for (int j = 0; j < 8; j++)
                {
                    gField.FillRectangle(bIsEven ? Brushes.Wheat : Brushes.DarkGoldenrod, (bIsSimple ? 0 : iWidthHeightCell) + i * iWidthHeightCell, (bIsSimple ? 0 : iWidthHeightCell) + j * iWidthHeightCell, iWidthHeightCell, iWidthHeightCell);
                    bIsEven = !bIsEven;
                }
                bIsEven = !bIsEven;

                DrawHorizontalCoord(iWidthHeightCell, i, iWidthHeightCell*9);
            }
        }

        private void DrawHorizontalCoord(int iWidthHeightCell, int i, int iX)
        {
            if (!bIsSimple)
            {
                Graphics gField = CreateGraphics();
                gField.FillRectangle(Brushes.DarkGoldenrod, iX, iWidthHeightCell + i * iWidthHeightCell, iWidthHeightCell, iWidthHeightCell);
                gField.DrawString((i + 1) + "", new Font("Arial", iWidthHeightCell / 2 + 5, FontStyle.Regular), Brushes.SaddleBrown, new Point(iX, iWidthHeightCell + i * iWidthHeightCell));
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            bIsSimple = checkBox.Checked;
            Invalidate();
        }
    }
}
