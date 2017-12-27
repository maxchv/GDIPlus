using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDIDrawingChessBoard
{
    public enum ElementColor { Dark, Light };
    public class Square
    {
        public Size Size { get; set; }
        public Point Pos { get; set; }
        public ElementColor SquareColor { get; set; }
    }
}
