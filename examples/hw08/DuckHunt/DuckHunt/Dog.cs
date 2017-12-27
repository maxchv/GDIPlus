using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuckHunt
{
    class Dog
    {
        Point location;
        Image imgDog;

        Timer moving = new Timer();
        Timer laugh = new Timer();
        
        int idxAnimation;
        int speed;

        bool dich = false;

        public bool Moving { get; set; }

        public Point Location { get { return location; } set { location = value; } }

        public Dog()
        {
            idxAnimation = 1;

            laugh.Interval = 100;
            laugh.Tick += Laugh_Tick;

            moving.Interval = 50;
            moving.Tick += Moving_Tick;

            speed = 4;
        }

        private void Moving_Tick(object sender, EventArgs e)
        {
            if (location.Y <= 200)
            {
                speed = Math.Min(speed, -speed);
                if(dich)
                {
                    SoundPlayer sp = new SoundPlayer("source/win.wav");
                    sp.Play();
                }
            }
            else if (location.Y > 360)
            {
                speed = Math.Max(speed, -speed);
                moving.Stop();
                if (laugh.Enabled)
                    laugh.Stop();
                Moving = false;
            }
            location.Y -= speed;
        }

        private void Laugh_Tick(object sender, EventArgs e)
        {
            NextAnimation();
        }

        private void NextAnimation()
        {
            if (idxAnimation > 2)
                idxAnimation = 1;
            imgDog = Image.FromFile("source/dog/doglaughing"+idxAnimation+".png");
            idxAnimation++;
        }

        public void Laugh(Point location)
        {
            dich = false;
            this.location = location;
            Moving = true;
            moving.Start();
            NextAnimation();
            laugh.Start();
        }


        public void Fowl(Point location)
        {
            dich = true;
            this.location = location;
            Moving = true;
            imgDog = Image.FromFile("source/dog/dogcaughtduck.png");
            moving.Start();
        }

        public void DrawDog(Graphics g)
        {
            g.DrawImage(imgDog, location);
        }

    }
}
