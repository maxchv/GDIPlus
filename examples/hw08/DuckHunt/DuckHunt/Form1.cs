using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuckHunt
{
    public partial class Form1 : Form
    {
        Duck duck;
        Dog dog;
        Timer tRefreshDraw;
        Image background, costume;
        Timer tTime;

        DateTime timeGame;

        public int Round
        {
            get
            {
                return round;
            }

            set
            {
                round = value;
                labelRound.Text = round + "";
            }
        }
        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
                labelScore.Text = score + "";
            }
        }
        public int Shots
        {
            get
            {
                return shots;
            }

            set
            {
                shots = value;
                pictureBoxShots.Image = new Bitmap(shotsImgs[Shots], pictureBoxShots.Size);
            }
        }

        int round;
        int score;
        int shots;

        List<Image> shotsImgs;
        List<PictureBox> ducks;

        bool gameStarting = false;

        public Form1()
        {
            InitializeComponent();
            Size = Image.FromFile("source/background.png").Size;
            pictureBoxPrev.Visible = true;
            pictureBoxPrev.Image = new Bitmap(Image.FromFile("source/preview.png"), Size);
            //Start();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                pictureBoxPrev.Visible = false;
                Start();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Start()
        {
            gameStarting = true;
            InitializeFields();
            FillImages();
        }

        private void FillImages()
        {
            panelRound.BackgroundImage = new Bitmap(Image.FromFile("source/backinfo.png"), panelRound.Size);
            panelScore.BackgroundImage = new Bitmap(Image.FromFile("source/backinfo.png"), panelScore.Size);
            panelDucks.BackgroundImage = new Bitmap(Image.FromFile("source/backinfo.png"), panelDucks.Size);
            panelTime.BackgroundImage = new Bitmap(Image.FromFile("source/backinfo.png"), panelTime.Size);

            int x = (Size.Width - panelTime.Size.Width) / 2;
            int y = panelTime.Location.Y;
            panelTime.Location = new Point(x, y);
            foreach (var item in ducks)
            {
                item.Image = new Bitmap(Image.FromFile("source/duck.png"), pictureBox0.Size);
            }

        }

        public void StartRound()
        {
            Shots = 3;
            Round++;
            duck = new Duck(ClientRectangle.Width, ClientRectangle.Height);
        }

        private void InitializeFields()
        {
            Cursor = new Cursor("Crosshair.cur");
            shotsImgs = new List<Image>();
            for (int i = 0; i < 4; i++)
            {
                shotsImgs.Add(Image.FromFile("source/" + i + "shots.png"));
            }

            ducks = new List<PictureBox>();
            ducks.Add(pictureBox0);
            ducks.Add(pictureBox1);
            ducks.Add(pictureBox2);
            ducks.Add(pictureBox3);
            ducks.Add(pictureBox4);
            ducks.Add(pictureBox5);
            ducks.Add(pictureBox6);
            ducks.Add(pictureBox7);
            ducks.Add(pictureBox8);
            ducks.Add(pictureBox9);

            Round = 0;
            StartRound();
            background = Image.FromFile("source/background.png");
            costume = Image.FromFile("source/costume.png");

            Size = background.Size;

            dog = new Dog();
            tRefreshDraw = new Timer();
            tRefreshDraw.Interval = 1000 / 24;
            tRefreshDraw.Tick += Timer_Tick;

            timeGame = new DateTime();

            tTime = new Timer();
            tTime.Interval = 1000;
            tTime.Tick += TTime_Tick;
            tTime.Start();

            tRefreshDraw.Start();
        }

        private void TTime_Tick(object sender, EventArgs e)
        {
            timeGame += new TimeSpan(0, 0, 1);
            labelTime.Text = timeGame.Minute + ":" + timeGame.Second;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameStarting)
                ShowMeGame(e.Graphics);
        }

        private void ShowMeGame(Graphics g)
        {
            g.DrawImage(background, new Point(0, 0));

            duck.DrawDuck(g, ClientRectangle.Width, ClientRectangle.Height);


            if (duck.State == DuckState.Fall)
            {
                dog.Fowl(new Point((ClientRectangle.Width - 80) / 2, ClientRectangle.Height));
                Score += 100;
                ducks[round - 1].Image = new Bitmap(Image.FromFile("source/duck2.png"), pictureBox0.Size);
            }
            else if (duck.State == DuckState.FlewAway)
            {
                dog.Laugh(new Point((ClientRectangle.Width - 80) / 2, ClientRectangle.Height));
                background = Image.FromFile("source/background.png");
            }


            if (dog.Moving)
                dog.DrawDog(g);
            else if (duck.State == DuckState.None)
            {
                if (round < 10)
                    StartRound();
                else
                {
                    tRefreshDraw.Stop();
                    tTime.Stop();
                    if (score > 500)
                        MessageBox.Show("You Win Score:" + score + " Time:" + timeGame.Minute + ":" + timeGame.Second);
                    else
                        MessageBox.Show("You Lose Score:" + score + " Time:" + timeGame.Minute + ":" + timeGame.Second);

                    Close();
                }
            }

            g.DrawImage(costume, new Point(1, 250));



            Text = dog.Location + "";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameStarting)
            {
                if (duck.State == DuckState.Moving)
                {

                    duck.Shut(new Point(e.X + 16, e.Y + 16));
                    Shots--;
                    if (Shots <= 0)
                    {
                        duck.FlyAway();
                    }
                }
            }
        }


    }
}
