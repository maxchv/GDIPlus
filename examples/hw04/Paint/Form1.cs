using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        private Graphics                m_Graphics;
        private Color                   m_CurrentColor;
        private Point                   m_CurrrentPoint;
        private Point                   m_PreviousPoint;
        private int                     m_Width;
        private DashStyle               m_PenDashStyle;
        private List<EllipseFigure>     m_ListEllipseFigures;
        private List<RectangleFigure>   m_ListRectangleFigures;
        private List<TextFigure>        m_ListTextFigures;
        private Color                   m_FillColor1;
        private Color                   m_FillColor2;
        private List<LineFigure>        m_ListLineFigure;

        public Form1()
        {
            InitializeComponent();
            Paint += Form1_Paint;

            m_Graphics              = panel1.CreateGraphics();
            m_CurrentColor          = Color.Black;
            m_CurrrentPoint         = new Point();
            m_PreviousPoint         = new Point();
            m_Width                 = 1;
            m_PenDashStyle          = DashStyle.Solid;
            m_ListEllipseFigures    = new List<EllipseFigure>();
            m_ListRectangleFigures  = new List<RectangleFigure>();
            m_ListTextFigures       = new List<TextFigure>();
            m_FillColor1            = Color.Red;
            m_FillColor2            = Color.Orange;
            m_ListLineFigure        = new List<LineFigure>();

            toolStripButtonColor1.BackColor = m_FillColor1;
            toolStripButtonColor2.BackColor = m_FillColor2;

            toolStripComboBoxFillStyle.Items.Add("Без заливки");
            toolStripComboBoxFillStyle.Items.Add("Заливка сплошным цветом");
            toolStripComboBoxFillStyle.Items.Add("Заливка градиентом");
            toolStripComboBoxFillStyle.SelectedIndex = 0;
            toolStripComboBoxFillStyle.Enabled = false;

            toolStripComboBoxWidth.Items.Add("1 px");
            toolStripComboBoxWidth.Items.Add("3 px");
            toolStripComboBoxWidth.Items.Add("5 px");
            toolStripComboBoxWidth.Items.Add("8 px");
            toolStripComboBoxWidth.SelectedIndex = 0;

            toolStripComboBoxStyle.Items.AddRange(Enum.GetNames(typeof(DashStyle)));
            toolStripComboBoxStyle.SelectedIndex = 0;

            toolStripComboBoxGradientStyle.Items.AddRange(Enum.GetNames(typeof(LinearGradientMode)));
            toolStripComboBoxGradientStyle.SelectedIndex = 0;
            toolStripComboBoxGradientStyle.Enabled = false;
        }
        
        private void toolStripButtonLine_Click(object sender, EventArgs e)
        {
            ToolStripButtonToolsChecked(!toolStripButtonLine.Checked, false);
            ToolStripButtonFigureChecked(false, false);            
            toolStripComboBoxFillStyle.Enabled = false;
            toolStripButtonFill.Enabled = false;
            toolStripComboBoxGradientStyle.Enabled = false;
        }

        private void toolStripButtonText_Click(object sender, EventArgs e)
        {
            ToolStripButtonToolsChecked(false, !toolStripButtonText.Checked);
            ToolStripButtonFigureChecked(false, false);            
            toolStripComboBoxFillStyle.Enabled = false;
            toolStripButtonFill.Enabled = false;
            toolStripComboBoxGradientStyle.Enabled = false;
        }

        private void ToolStripButtonToolsChecked(bool toolStripButtonPenChecked, bool toolStripButtonTextChecked)
        {
            toolStripButtonLine.Checked  = toolStripButtonPenChecked;
            toolStripButtonText.Checked = toolStripButtonTextChecked;
        }

        private void toolStripButtonEllipse_Click(object sender, EventArgs e)
        {
            ToolStripButtonFigureChecked(!toolStripButtonEllipse.Checked, false);
            ToolStripButtonToolsChecked(false, false);            
            toolStripComboBoxFillStyle.Enabled = toolStripButtonEllipse.Checked == true ? true : false;
            if (toolStripComboBoxFillStyle.SelectedItem.ToString() != "Без заливки")
            {
                toolStripButtonFill.Enabled = true;
            }

            if (toolStripComboBoxFillStyle.SelectedItem.ToString() == "Заливка градиентом")
            {
                toolStripComboBoxGradientStyle.Enabled = true;
            }
        }

        private void toolStripButtonRectangle_Click(object sender, EventArgs e)
        {
            ToolStripButtonFigureChecked(false, !toolStripButtonRectangle.Checked);
            ToolStripButtonToolsChecked(false, false);
            toolStripComboBoxFillStyle.Enabled = toolStripButtonRectangle.Checked == true ? true : false;
            if (toolStripComboBoxFillStyle.SelectedItem.ToString() != "Без заливки")
            {
                toolStripButtonFill.Enabled = true;
            }

            if (toolStripComboBoxFillStyle.SelectedItem.ToString() == "Заливка градиентом")
            {
                toolStripComboBoxGradientStyle.Enabled = true;
            }
        }

        private void ToolStripButtonFigureChecked(bool toolStripButtonEllipseChecked, bool toolStripButtonRectangleChecked)
        {
            toolStripButtonEllipse.Checked      = toolStripButtonEllipseChecked;
            toolStripButtonRectangle.Checked    = toolStripButtonRectangleChecked;
        }

        private void toolStripComboBoxWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxWidth.SelectedIndex != -1 && Regex.IsMatch(toolStripComboBoxWidth.SelectedItem.ToString(), "(\\d+)"))
            {
                string number = Regex.Match(toolStripComboBoxWidth.SelectedItem.ToString(), "(\\d+)").Groups[1].ToString();
                int.TryParse(number, out m_Width);
            }
        }

        private void toolStripComboBoxStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxStyle.SelectedIndex != -1)
            {
                Enum.TryParse(toolStripComboBoxStyle.SelectedItem.ToString(), out m_PenDashStyle);
            }
        }

        private void toolStripButtonColors_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                toolStripButton1.BackColor = m_CurrentColor = colorDialog.Color;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            m_PreviousPoint = m_CurrrentPoint;
            m_CurrrentPoint = e.Location;

            if (toolStripButtonLine.Checked)
            {
                LineDraw();
            }

            if (toolStripButtonEllipse.Checked)
            {
                EllipseDraw();
            }
            else if (toolStripButtonRectangle.Checked)
            {
                RectangleDraw();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            m_CurrrentPoint = e.Location;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (toolStripButtonText.Checked && e.Button == MouseButtons.Left)
                {
                    AddTextForm form = new AddTextForm();

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Brush brush = new SolidBrush(form.Color);
                        m_Graphics.DrawString(form.CurrentText, form.FontText, brush, e.Location);
                        m_ListTextFigures.Add(new TextFigure() { Text = form.CurrentText, Font = form.FontText, Brush = brush, StartPoint = e.Location });
                    }
                }
            } catch { }
        }

        private void LineDraw()
        {
            Pen pen         = new Pen(m_CurrentColor);
            pen.Width       = m_Width;
            pen.DashStyle   = m_PenDashStyle;

            m_Graphics.DrawLine(pen, m_PreviousPoint, m_CurrrentPoint);
            m_ListLineFigure.Add(new LineFigure() { StartPoint = m_PreviousPoint, EndPoint = m_CurrrentPoint, Pen = pen });
        }

        private void EllipseDraw()
        {
            try
            {
                Pen pen = new Pen(m_CurrentColor);
                pen.Width = m_Width;
                Size size = new Size(m_CurrrentPoint.X - m_PreviousPoint.X, m_CurrrentPoint.Y - m_PreviousPoint.Y);
                Rectangle rectangle = new Rectangle(m_PreviousPoint, size);

                m_Graphics.DrawEllipse(pen, rectangle);

                EllipseFigure ellipseFigure = new EllipseFigure();
                ellipseFigure.Rectangle = rectangle;
                ellipseFigure.Pen = pen;
                ellipseFigure.IsFill = false;
                ellipseFigure.IsGradient = false;

                if (toolStripComboBoxFillStyle.SelectedItem.ToString() == "Заливка сплошным цветом")
                {
                    Brush brush = new SolidBrush(m_FillColor1);
                    m_Graphics.FillEllipse(brush, rectangle);

                    ellipseFigure.IsFill = true;
                    ellipseFigure.FillBrush = brush;
                }
                else if (toolStripComboBoxFillStyle.SelectedItem.ToString() == "Заливка градиентом")
                {
                    LinearGradientMode mode;
                    Enum.TryParse(toolStripComboBoxGradientStyle.SelectedItem.ToString(), out mode);

                    LinearGradientBrush brush = new LinearGradientBrush(rectangle, m_FillColor1, m_FillColor2, mode);
                    m_Graphics.FillEllipse(brush, rectangle);

                    ellipseFigure.IsGradient = true;
                    ellipseFigure.GradientBrush = brush;
                }

                m_ListEllipseFigures.Add(ellipseFigure);
            }
            catch { }
        }

        private void RectangleDraw()
        {
            try
            {
                Pen pen = new Pen(m_CurrentColor);
                pen.Width = m_Width;

                Size size = new Size();
                Point point = new Point();

                if (m_PreviousPoint.X > m_CurrrentPoint.X)
                {
                    if (m_PreviousPoint.Y < m_CurrrentPoint.Y)
                    {
                        size = new Size(m_PreviousPoint.X - m_CurrrentPoint.X, m_CurrrentPoint.Y - m_PreviousPoint.Y);
                        point = new Point(m_CurrrentPoint.X, m_PreviousPoint.Y);
                    }
                    else
                    {
                        size = new Size(m_PreviousPoint.X - m_CurrrentPoint.X, m_PreviousPoint.Y - m_CurrrentPoint.Y);
                        point = new Point(m_CurrrentPoint.X, m_CurrrentPoint.Y);
                    }
                }
                else
                {
                    if (m_PreviousPoint.Y < m_CurrrentPoint.Y)
                    {
                        size = new Size(m_CurrrentPoint.X - m_PreviousPoint.X, m_CurrrentPoint.Y - m_PreviousPoint.Y);
                        point = m_PreviousPoint;
                    }
                    else
                    {
                        size = new Size(m_CurrrentPoint.X - m_PreviousPoint.X, m_PreviousPoint.Y - m_CurrrentPoint.Y);
                        point = new Point(m_PreviousPoint.X, m_CurrrentPoint.Y);
                    }

                }

                Rectangle rectangle = new Rectangle(point, size);
                m_Graphics.DrawRectangle(pen, rectangle);

                RectangleFigure rectangleFigure = new RectangleFigure();
                rectangleFigure.Rectangle = rectangle;
                rectangleFigure.Pen = pen;
                rectangleFigure.IsFill = false;
                rectangleFigure.IsGradient = false;

                if (toolStripComboBoxFillStyle.SelectedItem.ToString() == "Заливка сплошным цветом")
                {
                    Brush brush = new SolidBrush(m_FillColor1);
                    m_Graphics.FillRectangle(brush, rectangle);

                    rectangleFigure.IsFill = true;
                    rectangleFigure.FillBrush = brush;
                }
                else if (toolStripComboBoxFillStyle.SelectedItem.ToString() == "Заливка градиентом")
                {
                    LinearGradientMode mode;
                    Enum.TryParse(toolStripComboBoxGradientStyle.SelectedItem.ToString(), out mode);
                    LinearGradientBrush brush = new LinearGradientBrush(rectangle, m_FillColor1, m_FillColor2, mode);
                    m_Graphics.FillRectangle(brush, rectangle);

                    rectangleFigure.IsGradient = true;
                    rectangleFigure.GradientBrush = brush;
                }

                m_ListRectangleFigures.Add(rectangleFigure);
            } catch { }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach(LineFigure line in m_ListLineFigure)
            {
                m_Graphics.DrawLine(line.Pen, line.StartPoint, line.EndPoint);
            }

            foreach(EllipseFigure ellipse in m_ListEllipseFigures)
            {
                m_Graphics.DrawEllipse(ellipse.Pen, ellipse.Rectangle);

                if(ellipse.IsFill)
                {
                    m_Graphics.FillEllipse(ellipse.FillBrush, ellipse.Rectangle);
                }
                else if(ellipse.IsGradient)
                {
                    m_Graphics.FillEllipse(ellipse.GradientBrush, ellipse.Rectangle);
                }
            }

            foreach (RectangleFigure rectangle in m_ListRectangleFigures)
            {
                m_Graphics.DrawRectangle(rectangle.Pen, rectangle.Rectangle);

                if (rectangle.IsFill)
                {
                    m_Graphics.FillRectangle(rectangle.FillBrush, rectangle.Rectangle);
                }
                else if (rectangle.IsGradient)
                {
                    m_Graphics.FillRectangle(rectangle.GradientBrush, rectangle.Rectangle);
                }
            }

            foreach (TextFigure text in m_ListTextFigures)
            {
                m_Graphics.DrawString(text.Text, text.Font, text.Brush, text.StartPoint);
            }
        }       

        private void toolStripComboBoxFillStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(toolStripComboBoxFillStyle.SelectedIndex != -1)
            {
                if(toolStripComboBoxFillStyle.SelectedItem.ToString() == "Без заливки")
                {
                    toolStripButtonFill.Enabled = false;
                    toolStripComboBoxGradientStyle.Enabled = false;
                }
                else if (toolStripComboBoxFillStyle.SelectedItem.ToString() == "Заливка сплошным цветом")
                {
                    toolStripButtonFill.Enabled = true;
                    toolStripComboBoxGradientStyle.Enabled = false;
                }
                else if (toolStripComboBoxFillStyle.SelectedItem.ToString() == "Заливка градиентом")
                {
                    toolStripButtonFill.Enabled = true;                                       
                    toolStripComboBoxGradientStyle.Enabled = true;
                }
            }   
        }        

        private void toolStripButtonFill_Click(object sender, EventArgs e)
        {
            if (toolStripComboBoxFillStyle.SelectedItem.ToString() == "Заливка сплошным цветом")
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.FullOpen = true;

                if(colorDialog.ShowDialog() == DialogResult.OK)
                {
                    m_FillColor1 = colorDialog.Color;
                    toolStripButtonColor1.BackColor = colorDialog.Color;
                }
            }
            else if (toolStripComboBoxFillStyle.SelectedItem.ToString() == "Заливка градиентом")
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    m_FillColor1 = colorDialog.Color;
                    toolStripButtonColor1.BackColor = colorDialog.Color;
                }

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    m_FillColor2 = colorDialog.Color;
                    toolStripButtonColor2.BackColor = colorDialog.Color;
                }
            }
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            m_Graphics.Clear(Color.White);
            m_ListLineFigure.Clear();
            m_ListEllipseFigures.Clear();
            m_ListRectangleFigures.Clear();
            m_ListTextFigures.Clear();
        }        
    }
}
