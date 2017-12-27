using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDIDrawingChessBoard
{

    partial class Form1
    {
        private int countClick = 0;
        private Checker firstSel = null;
        private Bitmap prevImg = null;
        private Square secondSel = null;
        private int darkScores = 0;     //Очки темных шашек
        private int lightScores = 0;    //Очки светлых шашек
        //Передвижение шашки
        private void MoveChecker()
        {
            if (step == Step.Light && firstSel.Color == ElementColor.Dark ||
                step == Step.Dark && firstSel.Color == ElementColor.Light)
            {
                return;
            }
            if (CheckMovement())
            {
                firstSel.Pos = new Point(secondSel.Pos.X, secondSel.Pos.Y);
                int iSel = -1;
                int jSel = -1;
                for (int i = 0; i < cells; i++)
                {
                    for (int j = 0; j < cells; j++)
                    {
                        if (secondSel.Pos.X == squares[i, j].Pos.X &&
                            secondSel.Pos.Y == squares[i, j].Pos.Y)
                        {
                            iSel = i;
                            jSel = j;
                        }
                    }
                }

                Checker checker = new Checker();
                checker.Bitmap = firstSel.Bitmap;
                checker.Parent_i = iSel;
                checker.Parent_j = jSel;
                checker.Pos = firstSel.Pos;
                checker.Color = firstSel.Color;
                checker.Size = firstSel.Size;

                checkers[firstSel.Parent_i, firstSel.Parent_j] = null;
                checkers[iSel, jSel] = checker;

                countClick = 0;
                //Проверка на победу
                if (CheckIsWinDark())
                {
                    MessageBox.Show($"Темные победили со счетом {darkScores}:{lightScores}", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartNewGame();
                }
                else if (CheckIsWinLight())
                {
                    MessageBox.Show($"Светлые победили со счетом {lightScores}:{darkScores}", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartNewGame();
                }

                if (step == Step.Light)
                {
                    //if (!ScanningField())
                    {
                        if (!SeveralHits())
                        {
                            step = Step.Dark;
                        }
                    }
                }
                else
                {
                    //if (!ScanningField())
                    {
                        step = Step.Light;
                    }
                }
                Invalidate();
            }
        }
        //Проверка на запрет передвижения шашки
        private bool CheckMovement()
        {
            //Ходьба по диоганали
            if (secondSel.SquareColor == ElementColor.Dark)
            {
                //Светлые
                //Запрет ходьбы назад для светлых
                //if (secondSel.Pos.Y > firstSel.Pos.Y && firstSel.Color == ElementColor.Light)
                if (firstSel.Color == ElementColor.Light)
                {
                    //Запрет ходьбы через 2+ ячейки
                    bool right = (firstSel.Pos.X + side == secondSel.Pos.X && firstSel.Pos.Y + side == secondSel.Pos.Y);
                    bool left = (firstSel.Pos.X - side == secondSel.Pos.X && firstSel.Pos.Y + side == secondSel.Pos.Y);
                    bool isKill = IsKillLight();
                    if (left || right || isKill)
                    {
                        //Проверка на отсутсвие шашки в выбранной клетке
                        if (!CheckIsChecker())
                        {
                            return true;
                        }
                    }
                }
                //Запрет ходьбы назад для черных
                //else if (firstSel.Pos.Y > secondSel.Pos.Y && firstSel.Color == ElementColor.Dark)
                else if (firstSel.Color == ElementColor.Dark)
                {
                    //Запрет ходьбы через 2+ ячейки
                    bool right = (firstSel.Pos.X + side == secondSel.Pos.X && firstSel.Pos.Y - side == secondSel.Pos.Y);
                    bool left = (firstSel.Pos.X - side == secondSel.Pos.X && firstSel.Pos.Y - side == secondSel.Pos.Y);
                    bool isKill = IsKillDark();
                    if (left || right || isKill)
                    {
                        //Проверка на отсутсвие шашки в выбранной клетке
                        if (!CheckIsChecker())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //Проверить наличие шашки в выбранной ячейке
        private bool CheckIsChecker()
        {
            for (int i = 0; i < cells; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    if (checkers[i, j] != null)
                    {
                        if (checkers[i, j].Pos.X == secondSel.Pos.X &&
                            checkers[i, j].Pos.Y == secondSel.Pos.Y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //Отслеживание удара для черных
        private bool IsKillDark()
        {
            if (firstSel.Color == ElementColor.Dark)
            {
                //Вперед
                //Удар вправо
                bool right = firstSel.Pos.X + side * 2 == secondSel.Pos.X && firstSel.Pos.Y - side * 2 == secondSel.Pos.Y;
                int x = firstSel.Pos.X + side;
                int y = firstSel.Pos.Y - side;
                //убиваемая шашка
                Checker kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Light)
                    {
                        if (right)
                        {
                            checkers[kill.Parent_i, kill.Parent_j] = null;
                            darkScores++;
                            return true;
                        }
                    }
                }
                //Удар влево
                bool left = firstSel.Pos.X - side * 2 == secondSel.Pos.X && firstSel.Pos.Y - side * 2 == secondSel.Pos.Y;
                x = firstSel.Pos.X - side;
                y = firstSel.Pos.Y - side;
                kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Light)
                    {
                        if (left)
                        {
                            checkers[kill.Parent_i, kill.Parent_j] = null;
                            darkScores++;
                            return true;
                        }
                    }
                }

                //Назад
                //Удар влево
                left = firstSel.Pos.X - side * 2 == secondSel.Pos.X && firstSel.Pos.Y + side * 2 == secondSel.Pos.Y;
                x = firstSel.Pos.X - side;
                y = firstSel.Pos.Y + side;
                kill = GetChecker(x, y);

                if (kill != null)
                {
                    if (kill.Color == ElementColor.Light)
                    {
                        if (left)
                        {
                            checkers[kill.Parent_i, kill.Parent_j] = null;
                            darkScores++;
                            return true;
                        }
                    }
                }
                //Удар вправо
                right = firstSel.Pos.X + side * 2 == secondSel.Pos.X && firstSel.Pos.Y + side * 2 == secondSel.Pos.Y;
                x = firstSel.Pos.X + side;
                y = firstSel.Pos.Y + side;
                kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Light)
                    {
                        if (right)
                        {
                            checkers[kill.Parent_i, kill.Parent_j] = null;
                            darkScores++;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //Отслеживание удара для белых
        private bool IsKillLight()
        {
            if (firstSel.Color == ElementColor.Light)
            {
                //Вперед
                //Удар вправо
                bool right = firstSel.Pos.X + side * 2 == secondSel.Pos.X && firstSel.Pos.Y + side * 2 == secondSel.Pos.Y;
                int x = firstSel.Pos.X + side;
                int y = firstSel.Pos.Y + side;
                //убиваемая шашка
                Checker kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Dark)
                    {
                        if (right)
                        {
                            checkers[kill.Parent_i, kill.Parent_j] = null;
                            lightScores++;
                            //Показ очков
                            ShowScores();
                            return true;
                        }
                    }
                }

                //Удар влево
                bool left = firstSel.Pos.X - side * 2 == secondSel.Pos.X && firstSel.Pos.Y + side * 2 == secondSel.Pos.Y;
                x = firstSel.Pos.X - side;
                y = firstSel.Pos.Y + side;
                kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Dark)
                    {
                        if (left)
                        {
                            checkers[kill.Parent_i, kill.Parent_j] = null;
                            lightScores++;
                            return true;
                        }
                    }
                }
                //Назад
                //Удар влево
                left = firstSel.Pos.X - side * 2 == secondSel.Pos.X && firstSel.Pos.Y - side * 2 == secondSel.Pos.Y;
                x = firstSel.Pos.X - side;
                y = firstSel.Pos.Y - side;
                kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Dark)
                    {
                        checkers[kill.Parent_i, kill.Parent_j] = null;
                        lightScores++;
                        return true;
                    }
                }
                //Удар вправо
                right = firstSel.Pos.X + side * 2 == secondSel.Pos.X && firstSel.Pos.Y - side * 2 == secondSel.Pos.Y;
                x = firstSel.Pos.X + side;
                y = firstSel.Pos.Y - side;
                kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Dark)
                    {
                        checkers[kill.Parent_i, kill.Parent_j] = null;
                        lightScores++;
                        return true;
                    }
                }

            }
            return false;
        }
        //Получение шашки по координатам
        private Checker GetChecker(int x, int y)
        {
            for (int i = 0; i < cells; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    if (checkers[i, j] != null)
                    {
                        if (checkers[i, j].Pos.X == x && checkers[i, j].Pos.Y == y)
                        {
                            return checkers[i, j];
                        }
                    }
                }
            }
            return null;
        }
        //проверка на наличие шашек
        private bool IsCheckers()
        {
            for (int i = 0; i < countRowsCheckers; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    if (checkers[i, j] != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //Проверка клика по шашке
        private Checker IsClickByChecker(int x, int y)
        {
            for (int i = 0; i < cells; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    if (checkers[i, j] != null)
                    {
                        int checkerX = checkers[i, j].Pos.X;
                        int checkerY = checkers[i, j].Pos.Y;
                        if (x >= checkerX && x <= checkerX + side &&
                            y >= checkerY && y <= checkerY + side)
                        {
                            return checkers[i, j];
                        }
                    }
                }
            }
            return null;
        }
        //Показ кто ходит в statusBar
        private void ShowWhoStep()
        {
            if (step == Step.Dark)
            {

                toolStripStatusLabelStep.BackColor = Color.Black;
                toolStripStatusLabelStep.ForeColor = Color.White;
            }
            else
            {

                toolStripStatusLabelStep.BackColor = Color.Wheat;
                toolStripStatusLabelStep.ForeColor = Color.Black;
            }
        }
        //Показ очков в statusBar
        private void ShowScores()
        {
            toolStripStatusLabelScores.Text = $"\tLight: {lightScores}  Dark: {darkScores}";
        }
        //Сканирование области вокруг шашки, которая бьет для 2+ удара
        private bool ScanningField()
        {
            //для светлых
            if (firstSel.Color == ElementColor.Light)
            {
                int x;
                int y;

                //Вперед 
                //Влево
                x = firstSel.Pos.X - side;
                y = firstSel.Pos.Y + side;
                Checker kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Dark)
                    {
                        x = firstSel.Pos.X - side * 2;
                        y = firstSel.Pos.Y + side * 2;
                        Checker checker = GetChecker(x, y);
                        if (checker == null)
                        {
                            return true;
                        }
                    }
                }
                //Вправо
                x = firstSel.Pos.X + side;
                y = firstSel.Pos.Y + side;
                kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Dark)
                    {
                        x = firstSel.Pos.X + side * 2;
                        y = firstSel.Pos.Y + side * 2;
                        Checker checker = GetChecker(x, y);
                        if (checker == null)
                        {
                            return true;
                        }
                    }
                }
            }
            //для темных
            else if (firstSel.Color == ElementColor.Dark)
            {
                int x;
                int y;
                //Вперед
                //Влево
                x = firstSel.Pos.X - side;
                y = firstSel.Pos.Y - side;
                Checker kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Light)
                    {
                        x = firstSel.Pos.X - side * 2;
                        y = firstSel.Pos.Y - side * 2;
                        Checker checker = GetChecker(x, y);
                        if (checker == null)
                        {
                            return true;
                        }
                    }
                }
                //Вправо
                x = firstSel.Pos.X + side;
                y = firstSel.Pos.Y - side;
                kill = GetChecker(x, y);
                if (kill != null)
                {
                    if (kill.Color == ElementColor.Light)
                    {
                        x = firstSel.Pos.X + side * 2;
                        y = firstSel.Pos.Y - side * 2;
                        Checker checker = GetChecker(x, y);
                        if (checker == null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //Проверка победы светлых
        private bool CheckIsWinLight()
        {
            for (int i = 0; i < cells; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    if (checkers[i, j] != null)
                    {
                        if (checkers[i, j].Color == ElementColor.Dark)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        //Проверка победы темных
        private bool CheckIsWinDark()
        {
            for (int i = 0; i < cells; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    if (checkers[i, j] != null)
                    {
                        if (checkers[i, j].Color == ElementColor.Light)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        //Начать игру заново
        private void StartNewGame()
        {
            DialogResult res = MessageBox.Show("Начать игру заново?", "Новая игра", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                darkScores = 0;
                lightScores = 0;
                for (int i = 0; i < cells; i++)
                {
                    for (int j = 0; j < cells; j++)
                    {
                        checkers[i, j] = null;
                    }
                }
                step = Step.Light;
                seconds = 0;
                Invalidate();
            }
            else
            {
                Close();
            }
        }
        //Подсказка ходов для светлых
        private void ShowStep()
        {

        }
 
        //Разрешение 2+ударов
        private bool SeveralHits()
        {
            if (firstSel.Color == ElementColor.Light)
            {
                //Верх
                //Влево
                int x = secondSel.Pos.X - side;
                int y = secondSel.Pos.Y - side;
                Checker checker = GetChecker(x, y);
                if (checker != null)
                {
                    if (checker.Color == ElementColor.Dark)
                    {
                        int x1 = secondSel.Pos.X - side * 2;
                        int y1 = secondSel.Pos.Y - side * 2;
                        if (GetChecker(x1, y1) == null)
                        {
                            return true;
                        }
                    }
                }
                //Вправо
                x = secondSel.Pos.X + side;
                y = secondSel.Pos.Y - side;
                checker = GetChecker(x, y);
                if (checker != null)
                {
                    if (checker.Color == ElementColor.Dark)
                    {
                        int x1 = secondSel.Pos.X + side * 2;
                        int y1 = secondSel.Pos.Y - side * 2;
                        if (GetChecker(x1, y1) == null)
                        {
                            return true;
                        }
                    }
                }
                //Низ
                //Влево
                x = secondSel.Pos.X - side;
                y = secondSel.Pos.Y + side;
                checker = GetChecker(x, y);
                if (checker != null)
                {
                    if (checker.Color == ElementColor.Dark)
                    {
                        int x1 = secondSel.Pos.X - side * 2;
                        int y1 = secondSel.Pos.Y + side * 2;
                        if (GetChecker(x1, y1) == null)
                        {
                            return true;
                        }
                    }
                }
                //Вправо
                x = secondSel.Pos.X + side;
                y = secondSel.Pos.Y + side;
                checker = GetChecker(x, y);
                if (checker != null)
                {
                    if (checker.Color == ElementColor.Dark)
                    {
                        int x1 = secondSel.Pos.X + side * 2;
                        int y1 = secondSel.Pos.Y + side * 2;
                        if (GetChecker(x1, y1) == null)
                        {
                            return true;
                        }
                    }
                }

            }
            else if (firstSel.Color == ElementColor.Dark)
            {

            }
            return false;
        }
    }
}