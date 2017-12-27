using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDIDrawingChessBoard
{
    public class Checker
    {
        public static Image darkChecker = Image.FromFile(@"Checkers\BlackChecker.png");
        public static Image lightChecker = Image.FromFile(@"Checkers\WhiteChecker.png");
        public static Image selectedChecker = Image.FromFile(@"Checkers\SelectedChecker.png");

        public Size Size { get; set; }      //размер
        public Point Pos { get; set; }      //позиция
        public Bitmap Bitmap { get; set; }  //картинка
        public ElementColor Color { get; set; }
        public int Parent_i { get; set; }
        public int Parent_j { get; set; }
    }
}
