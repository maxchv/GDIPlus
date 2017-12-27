using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class EllipseFigure
    {
        public Rectangle Rectangle { get; set; }

        public Pen Pen { get; set; }
        
        public Brush FillBrush { get; set; }

        public LinearGradientBrush GradientBrush { get; set; }

        public bool IsFill { get; set; }

        public bool IsGradient { get; set; }
    }
}