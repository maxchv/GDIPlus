using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuckHunt
{
    enum DuckState { Moving, Falling, Fall, FlyAway, FlewAway, None }
    class Duck
    {
        public int VerticalSpeed { get; set; }
        public int HorizontalSpeed { get; set; }

        public Point Location { get { return location; } set { location = value; } }

        internal DuckState State { get { return state; } set { state = value; } }

        Point location;

        List<Image> duckMoveAnim;
        int idxAnimation;
        Image duckImg;
        DuckState state;

        Image hitImg;
        Image fallImg;

        Timer moving = new Timer();
        Timer hit = new Timer();
        Timer sound = new Timer();
        Timer timeToKill = new Timer();


        public Duck(int clientWidth, int clientHeight)
        {
            Random rand = new Random();
            Location = new Point(rand.Next(clientWidth), rand.Next(250, clientHeight));

            State = DuckState.Moving;

            duckMoveAnim = new List<Image>();
            foreach (string path in Directory.GetFiles("source/duck/move"))
            {
                duckMoveAnim.Add(Image.FromFile(path));
            }

            VerticalSpeed = 5;
            HorizontalSpeed = 10;

            idxAnimation = 0;
            NextAnimation();

            moving.Interval = 100;
            moving.Tick += TimerMove_Tick;

            hit.Interval = 1000;
            hit.Tick += Dieng_Tick;

            sound.Interval = 1500;
            sound.Tick += Sound_Tick;

            timeToKill.Interval = 10000;
            timeToKill.Tick += TimeToKill_Tick;

            hitImg = Image.FromFile("source/duck/duckshot.png");
            fallImg = Image.FromFile("source/duck/duckfall.png");

            moving.Start();
            sound.Start();
            timeToKill.Start();
        }

        private void TimeToKill_Tick(object sender, EventArgs e)
        {
            FlyAway();
            timeToKill.Stop();
        }

        private void Sound_Tick(object sender, EventArgs e)
        {
            if (State == DuckState.Moving)
            {
                SoundPlayer sound = new SoundPlayer("source/ducksound.wav");
                sound.Play();
            }
            else
            {
                sound.Stop();
            }
        }

        private void Dieng_Tick(object sender, EventArgs e)
        {
            hit.Stop();
        }

        private void TimerMove_Tick(object sender, EventArgs e)
        {
            if (State == DuckState.Moving)
            {
                location.X += HorizontalSpeed;
                location.Y += VerticalSpeed;
                NextAnimation();
            }
            else if (State == DuckState.Falling)
            {
                if (hit.Enabled)
                {
                    duckImg = hitImg;
                }
                else
                {
                    location.Y += Math.Max(VerticalSpeed, -VerticalSpeed);
                    duckImg = fallImg;
                }
            }
            else if (State == DuckState.Fall)
            {
                moving.Stop();
            }
            else if (state == DuckState.FlyAway)
            {
                location.X += HorizontalSpeed;
                location.Y += VerticalSpeed;
                NextAnimation();
            }
        }

        private void NextAnimation()
        {
            if (idxAnimation < 0 || idxAnimation > 2)
                idxAnimation = 0;
            duckImg = HorizontalSpeed > 0 ? duckMoveAnim[idxAnimation] : duckMoveAnim[idxAnimation + 3];
            idxAnimation++;
        }

        public DuckState DrawDuck(Graphics g, int clientWidth, int clientHeight)
        {
            int x = Location.X + duckImg.Size.Width / 2;
            int y = Location.Y + duckImg.Size.Height / 2;

            switch (State)
            {
                case DuckState.Moving:
                    {
                        FieldLimits(clientWidth, clientHeight, x, y);
                    }
                    break;
                case DuckState.Falling:
                    {
                        if (y >= clientHeight - 30)
                            State = DuckState.Fall;
                    }
                    break;
                case DuckState.Fall:
                    {
                        SoundPlayer sound = new SoundPlayer("source/duckdrop.wav");
                        sound.Play();
                        State = DuckState.None;
                        moving.Stop();
                    }
                    break;
                case DuckState.FlyAway:
                    {
                        g.DrawImage(Image.FromFile("source/flyaway.png"),new Point(0,0));
                        if (x < -50 || x > clientWidth+50)
                            State = DuckState.FlewAway;
                    }
                    break;
                case DuckState.FlewAway:
                    {
                        SoundPlayer sound = new SoundPlayer("source/loseround.wav");
                        sound.Play();
                        State = DuckState.None;
                        moving.Stop();
                    }
                    break;
                case DuckState.None:
                    {
                        if (moving.Enabled)
                            moving.Stop();
                        if (hit.Enabled)
                            hit.Stop();
                        if (sound.Enabled)
                            sound.Stop();
                        if (timeToKill.Enabled)
                            timeToKill.Stop();
                    }
                    break;
            }

            g.DrawImage(duckImg, Location);
            return State;
        }

        private void FieldLimits(int clientWidth, int clientHeight, int x, int y)
        {
            int border = 50;
            if (x <= border)
                HorizontalSpeed = Math.Max(HorizontalSpeed, -HorizontalSpeed);
            else if (x >= clientWidth - border)
                HorizontalSpeed = Math.Min(HorizontalSpeed, -HorizontalSpeed);

            if (y <= border)
                VerticalSpeed = Math.Max(VerticalSpeed, -VerticalSpeed);
            else if (y >= clientHeight - border)
                VerticalSpeed = Math.Min(VerticalSpeed, -VerticalSpeed);
        }

        internal void FlyAway()
        {
            state = DuckState.FlyAway;
            duckMoveAnim.Clear();
            foreach (string path in Directory.GetFiles("source/duck/flayway"))
            {
                duckMoveAnim.Add(Image.FromFile(path));
            }
            VerticalSpeed = VerticalSpeed < 0 ? VerticalSpeed*2 : -VerticalSpeed*2;

        }

        public bool Shut(Point point)
        {

            bool isShut = false;

            SoundPlayer sound = new SoundPlayer("source/blast.wav");
            sound.Play();
            int x1 = Location.X;
            int y1 = Location.Y;
            int x2 = Location.X + duckImg.Size.Width;
            int y2 = Location.Y + duckImg.Size.Height;

            if ((point.X > x1 && point.X < x2) && (point.Y > y1 && point.Y < y2))
            {
                moving.Interval = 20;
                hit.Start();
                State = DuckState.Falling;
                isShut = true;
            }
            return isShut;
        }

    }
}
