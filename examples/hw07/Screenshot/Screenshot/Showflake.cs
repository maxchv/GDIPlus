using System.Drawing;

namespace Screenshot
{
    internal class Showflake
    {
        public Point Location { get; set; }
        public Image Image { get; set; }
        public int Speed { get; set; }
        public int Where { get; set; }

        public Showflake(Point p, Image img, int s, int w)
        {
            Location = p;
            Image = img;
            Speed = s;
            Where = w;
        }
    }
}