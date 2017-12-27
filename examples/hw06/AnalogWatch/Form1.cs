using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogWatch
{
    public partial class Form1 : Form
    {
        class Line
        {
            public PointF Start { get; set; }

            public PointF End { get; set; }
        }

        private Rectangle   m_Clock;
        private DateTime    m_Time;
        private Line        m_SecondLine;
        private Line        m_MinuteLine;
        private Line        m_HourLine;
        private int         m_RotateSecondLine;
        private int         m_RotateMinuteLine;
        private int         m_RotateHourLine;
        private int         m_SizeNumber;
        private Pen         m_SecondPen;
        private Pen         m_MinutePen;
        private Pen         m_HourPen;
        private Timer       m_Timer;
        private Font        m_NumbersFont;

        public Form1()
        {
            InitializeComponent();

            dateTimePickerEndDate.MinDate = DateTime.Now;
            DoubleBuffered = true;
            Paint += Form1_Paint;
            SizeChanged += Form1_SizeChanged;

            m_SecondPen = new Pen(Color.Red, 2);
            m_MinutePen = new Pen(Color.Aqua, 4);
            m_HourPen = new Pen(Color.GreenYellow, 4);

            m_Timer = new Timer();
            m_Timer.Interval = 1000;
            m_Timer.Tick += M_Timer_Tick;
            m_Timer.Start();

            SizeChangedWatch();

            SetRotateLines();
        }

        private void M_Timer_Tick(object sender, EventArgs e)
        {
            SetRotateLines();

            SetDate();
        }

        private void SetDate()
        {
            try
            {
                DateTime selectedDate = new DateTime(dateTimePickerEndDate.Value.Year, dateTimePickerEndDate.Value.Month, dateTimePickerEndDate.Value.Day, 23, 59, 00);
                DateTime currentDate = DateTime.Now;

                TimeSpan time = selectedDate - currentDate;

                int seconds = Convert.ToInt32(time.TotalSeconds);
                int minutes = seconds / 60;
                int hours = minutes / 60;
                int days = hours / 24;

                labelTimeLeft.Text = days.ToString() + " дней " + (hours - (days * 24)).ToString() + " ч. " + (minutes - (hours * 60)).ToString() + " мин. " + (seconds - ((hours * 60 * 60) + ((minutes - (hours * 60)) * 60))).ToString() + " сек.";
            } catch { }
        }

        private void SetRotateLines()
        {
            try
            {
                m_Time = DateTime.Now;

                m_RotateSecondLine = m_Time.Second * 6;
                m_RotateMinuteLine = m_Time.Minute * 6;

                int degree = 0;

                if (m_Time.Minute > 15 && m_Time.Minute <= 30)
                {
                    degree = 6;
                }
                else if (m_Time.Minute > 30 && m_Time.Minute <= 45)
                {
                    degree = 6 * 2;
                }
                else if (m_Time.Minute > 45 && m_Time.Minute <= 55)
                {
                    degree = 6 * 3;
                }
                else if (m_Time.Minute > 55 && m_Time.Minute <= 60)
                {
                    degree = 6 * 4;
                }

                m_RotateHourLine = (m_Time.Hour < 13) ? (m_Time.Hour * 30) + degree : (m_Time.Hour - 12) * 30 + degree;
            }
            catch { }

            Invalidate();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            SizeChangedWatch();

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(ClientRectangle.Width / 2f, ClientRectangle.Height / 2f);

            DrawWatch(e.Graphics);

            e.Graphics.RotateTransform(m_RotateSecondLine);
            e.Graphics.DrawLine(m_SecondPen, m_SecondLine.Start, m_SecondLine.End);

            e.Graphics.RotateTransform(m_RotateMinuteLine - m_RotateSecondLine);
            e.Graphics.DrawLine(m_MinutePen, m_MinuteLine.Start, m_MinuteLine.End);

            e.Graphics.RotateTransform(m_RotateHourLine - m_RotateMinuteLine);
            e.Graphics.DrawLine(m_HourPen, m_HourLine.Start, m_HourLine.End);
        }

        private void SizeChangedWatch()
        {
            try
            {
                int width = (70 * ClientRectangle.Width) / 100;
                int height = (70 * ClientRectangle.Height) / 100;

                int diameter = (width < height) ? width : height;
                m_SizeNumber = (5 * diameter) / 100;

                int x = (diameter / 2) * (-1);
                int y = (diameter / 2) * (-1);

                m_Clock = new Rectangle(x, y, diameter, diameter);
                m_SecondLine = new Line() { Start = new PointF(0, 0), End = new PointF(0, (diameter / 2.2f) * (-1)) };
                m_MinuteLine = new Line() { Start = new PointF(0, 0), End = new PointF(0, diameter / 3.0f * (-1)) };
                m_HourLine = new Line() { Start = new PointF(0, 0), End = new PointF(0, diameter / 4.5f * (-1)) };

                m_NumbersFont = new Font("Arial", (5 * diameter) / 100);
            } catch { }
        }

        private void DrawWatch(Graphics g)
        {
            try
            {
                g.DrawEllipse(new Pen(Color.Green, 5), m_Clock);

                int length = (int)(m_SecondLine.Start.Y - m_SecondLine.End.Y);
                int indent = (9 * length) / 100;
                for (int i = 0; i < 60; i++)
                {
                    g.RotateTransform(6);

                    PointF start = m_SecondLine.End;

                    start.Y = m_SecondLine.End.Y - indent;
                    g.DrawLine(new Pen(Color.Brown, 2), start, new PointF(m_SecondLine.End.X, m_SecondLine.End.Y - 5));
                }

                Pen pen = new Pen(Color.Black, 3);
                for (int i = 0; i < 12; i++)
                {
                    g.RotateTransform(30);

                    PointF start = m_SecondLine.End;
                    start.Y = m_SecondLine.End.Y - indent;
                    g.DrawLine(new Pen(Color.Brown, 2), start, new PointF(m_SecondLine.End.X, m_SecondLine.End.Y + indent - 5));
                }

                for (int i = 0; i < 12; i++)
                {
                    g.RotateTransform(30);

                    PointF start = m_SecondLine.End;
                    start.Y = m_SecondLine.End.Y + indent;
                    start.X = m_SecondLine.End.X - indent;

                    g.DrawString((i + 1).ToString(), m_NumbersFont, Brushes.DarkBlue, start);
                }
            } catch { }
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            SetDate();
        }
    }
}