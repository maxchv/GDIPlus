using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class TextFigure
    {
        public string Text { get; set; }

        public Font Font { get; set; }

        public Brush Brush { get; set; }

        public Point StartPoint { get; set; }
    }
}