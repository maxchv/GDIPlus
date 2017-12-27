using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIDrawingChessBoard
{
    enum Step { Dark, Light };
    public partial class Form1 : Form
    {
        private Step step = Step.Light;     //определение кто ходит
        //Буквы для поля
        private readonly string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h" };
        //Цифры для поля
        private readonly int[] numbers = { 8, 7, 6, 5, 4, 3, 2, 1 };
        //Количество ячеек в ряду на поле
        private readonly int cells = 8;
        //Отступ с краю
        private readonly int indentFromEdge = 25;
        //Количество рядов шашек
        private readonly int countRowsCheckers = 3;
        //Цвет текста вокруг поля
        private readonly Brush darkBrush = Brushes.SaddleBrown;
        private readonly Brush lightBrush = Brushes.White;


        //Таймер игры
        private Timer timer = new Timer();
        private int seconds = 0;
        //клетки на поле
        private Square[,] squares;
        //шашки на поле
        private Checker[,] checkers;
        //размер стороны квадрата
        private int side;

        public Form1()
        {
            InitializeComponent();
            squares = new Square[cells, cells];
            checkers = new Checker[cells, cells];
            DoubleBuffered = true;
            Size = new Size(MinimumSize.Width, MinimumSize.Height);
            Color color = Color.FromArgb(28, 28, 28);
            statusStrip.BackColor = color;
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;

            int mins = seconds % 3600 / 60;
            int secs = seconds % 60;
            string time = string.Empty;
            if (mins < 10 && secs < 10)
            {
                time = $"Time game: 0{mins}:0{secs}";
            }
            else if (mins < 10 && secs >= 10)
            {
                time = $"Time game: 0{mins}:{secs}";
            }
            else if (mins >= 10 && secs < 10)
            {
                time = $"Time game: {mins}:0{secs}";
            }
            else
            {
                time = $"Time game: {mins}:{secs}";
            }
            toolStripStatusLabelTimeGame.Text = time;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawChessBoard(e);
            //На поле нет шашек
            if (!IsCheckers())
            {
                InitTopCheckers(e);
                InitBottomCheckers(e);
            }
            else
            {
                DrawCheckers(e);
            }

            //Показ кто ходит
            ShowWhoStep();

            //Показ очков
            ShowScores();
        }
        //Отрисовка поля
        private void DrawChessBoard(PaintEventArgs e)
        {
            int widthClient = ClientRectangle.Width - indentFromEdge;
            int heightClient = ClientRectangle.Height - indentFromEdge * 3;

            int imgWidth = widthClient / cells;
            int imgHeight = heightClient / cells;
            side = imgWidth < imgHeight ? imgWidth : imgHeight;

            Bitmap bmpWhiteCell = new Bitmap(Image.FromFile(@"Checkers\WhiteCell.png"), new Size(side, side));
            Bitmap bmpBrownCell = new Bitmap(Image.FromFile(@"Checkers\BrownCell.png"), new Size(side, side));

            int x = indentFromEdge;
            int y = indentFromEdge;

            int startDrawX = x;
            //шрифт для текста
            Font font = new Font("Arial", 14, FontStyle.Regular);


            for (int i = 0; i < cells; i++)
            {
                //Отрисовка цифры слева
                //темная цифра
                if (i % 2 == 0)
                {
                    e.Graphics.DrawString(numbers[i].ToString(), font, darkBrush, x - indentFromEdge + 4, y + side / 2 - font.Size);
                }
                //светлая цифра
                else
                {
                    e.Graphics.DrawString(numbers[i].ToString(), font, lightBrush, x - indentFromEdge + 4, y + side / 2 - font.Size);
                }
                //Отрисовка ряда клеток начинаю с белой
                if (i % 2 == 0)
                {
                    for (int j = 0; j < cells; j++)
                    {
                        //Отрисовка букв над полем
                        if (i == 0)
                        {
                            //темная буква
                            if (j % 2 == 0)
                            {
                                e.Graphics.DrawString(letters[j], font, darkBrush, new Point(x + side / 2 - (int)font.Size / 2, y - indentFromEdge));
                            }
                            //светлая буква
                            else
                            {
                                e.Graphics.DrawString(letters[j], font, lightBrush, new Point(x + side / 2 - (int)font.Size / 2, y - indentFromEdge));
                            }
                        }
                        Square square = new Square();
                        //светлая клетка
                        if (j % 2 == 0)
                        {
                            e.Graphics.DrawImage(bmpWhiteCell, x, y);
                            square.SquareColor = ElementColor.Light;
                        }
                        //темная клетка
                        else
                        {
                            e.Graphics.DrawImage(bmpBrownCell, x, y);
                            square.SquareColor = ElementColor.Dark;
                        }
                        square.Pos = new Point(x, y);
                        square.Size = new Size(side, side);
                        squares[i, j] = square;
                        x += side;
                    }
                }
                //Отрисовка ряда клеток начинаю с черной
                else
                {
                    for (int j = 0; j < cells; j++)
                    {
                        //Отрисовка букв под полем
                        if (i == cells - 1)
                        {
                            if (j % 2 != 0)
                            {
                                e.Graphics.DrawString(letters[j], font, darkBrush, new Point(x + side / 2 - (int)font.Size / 2, y + side));
                            }
                            else
                            {
                                e.Graphics.DrawString(letters[j], font, lightBrush, new Point(x + side / 2 - (int)font.Size / 2, y + side));
                            }
                        }
                        Square square = new Square();
                        //темная клетка
                        if (j % 2 == 0)
                        {
                            e.Graphics.DrawImage(bmpBrownCell, x, y);
                            square.SquareColor = ElementColor.Dark;

                        }
                        //светлая клетка
                        else
                        {
                            e.Graphics.DrawImage(bmpWhiteCell, x, y);
                            square.SquareColor = ElementColor.Light;

                        }
                        square.Pos = new Point(x, y);
                        square.Size = new Size(side, side);
                        squares[i, j] = square;
                        x += side;
                    }
                }
                //Отрисовка цифр справа
                //темная цифра
                if (i % 2 != 0)
                {
                    e.Graphics.DrawString(numbers[i].ToString(), font, darkBrush, x + 4, y + side / 2 - font.Size);
                }
                //светлая цифра
                else
                {
                    e.Graphics.DrawString(numbers[i].ToString(), font, lightBrush, x + 4, y + side / 2 - font.Size);
                }
                y += side;
                x = startDrawX;
            }
        }
        //Инициализация верхнего ряда шашек
        private void InitTopCheckers(PaintEventArgs e)
        {
            for (int i = 0; i < countRowsCheckers; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    //Квадрат темный
                    if (squares[i, j].SquareColor == ElementColor.Dark)
                    {
                        Checker checker = new Checker();
                        checker.Color = ElementColor.Light;
                        checker.Parent_i = i;
                        checker.Parent_j = j;
                        checker.Pos = squares[i, j].Pos;
                        checker.Size = squares[i, j].Size;
                        checker.Bitmap = new Bitmap(Checker.lightChecker, side - 1, side - 1);
                        checkers[i, j] = checker;
                        e.Graphics.DrawImage(checker.Bitmap, checker.Pos);
                    }
                }
            }
        }
        //Инициализация нижнего ряда шашек
        private void InitBottomCheckers(PaintEventArgs e)
        {
            for (int i = cells - countRowsCheckers; i < cells; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    //Квадрат темный
                    if (squares[i, j].SquareColor == ElementColor.Dark)
                    {
                        Checker checker = new Checker();
                        checker.Color = ElementColor.Dark;
                        checker.Parent_i = i;
                        checker.Parent_j = j;
                        checker.Pos = squares[i, j].Pos;
                        checker.Size = squares[i, j].Size;
                        checker.Bitmap = new Bitmap(Checker.darkChecker, side - 1, side - 1);
                        checkers[i, j] = checker;
                        e.Graphics.DrawImage(checker.Bitmap, checker.Pos);
                    }
                }
            }
        }

        private void DrawCheckers(PaintEventArgs e)
        {
            for (int i = 0; i < cells; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    if (checkers[i, j] != null)
                    {
                        int idx_i = checkers[i, j].Parent_i;
                        int idx_j = checkers[i, j].Parent_j;
                        Bitmap bmp = new Bitmap(checkers[i, j].Bitmap, side - 1, side - 1);
                        checkers[i, j].Pos = new Point(squares[idx_i, idx_j].Pos.X, squares[idx_i, idx_j].Pos.Y);
                        e.Graphics.DrawImage(bmp, squares[idx_i, idx_j].Pos);
                    }
                }
            }
        }
        //Изменение размеров окна
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
        
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (countClick == 0)
                {
                    //Клик был на шашке
                    firstSel = IsClickByChecker(e.X, e.Y);
                    if (firstSel != null)
                    {
                        int i = firstSel.Parent_i;
                        int j = firstSel.Parent_j;
                        prevImg = checkers[i, j].Bitmap.Clone() as Bitmap;
                        checkers[i, j].Bitmap = new Bitmap(Checker.selectedChecker, side - 1, side - 1);
                        Invalidate();
                        countClick++;
                    }
                }
                else if (countClick == 1)
                {
                    //Поиск квадрат по которому нажали
                    int mx = e.X;
                    int my = e.Y;

                    for (int i = 0; i < cells; i++)
                    {
                        for (int j = 0; j < cells; j++)
                        {
                            int x = squares[i, j].Pos.X;
                            int y = squares[i, j].Pos.Y;

                            if (mx >= x && mx <= x + side &&
                                my >= y && my <= y + side)
                            {
                                secondSel = squares[i, j];
                            }
                        }
                    }
                    firstSel.Bitmap = prevImg;
                    if (secondSel != null && firstSel != null)
                    {
                        MoveChecker();
                    }
                    countClick = 0;
                    Invalidate();
                }
            }
        }

    }
}