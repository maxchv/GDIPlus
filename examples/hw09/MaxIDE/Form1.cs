using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxIDE
{
    public partial class Form1 : Form
    {
        private List<string> _keyWordsList = new List<string>()
        {
            "abstract", "as", "base", "bool", "break", "byte", "case", "catch",
            "char", "checked", "class", "const", "continue", "decimal", "default",
            "delegate", "do", "double", "else", "enum", "event", "explicit", "extern",
            "false", "finally", "fixed", "float", "for", "foreach", "goto", "if",
            "implicit", "in", "int", "interface", "internal", "is", "lock", "long",
            "namespace", "new", "null", "object", "operator", "out", "override",
            "params", "private", "protected", "public", "readonly", "ref", "return",
            "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string",
            "struct", "switch", "this", "throw", "true", "try", "typeof", "uint",
            "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void",
            "volatile", "while", "add", "alias", "ascending", "async", "await",
            "descending", "dynamic", "from", "get", "global", "group", "into",
            "join", "let", "orderby", "partial", "partial", "remove", "select",
            "set", "value", "var", "where", "yield"
        };
        private string _fileName = string.Empty;
        private int m_PageCount = 0;

        private int m_linePrinted = 0;
        private string[] lines;

        PrintDocument printDocument = new PrintDocument();
        private string documentContents = string.Empty;
        private string stringToPrint = string.Empty;
        private bool isShowLineNumber = true;
        private int m_StartIndex = 0;
        private int m_EndIndex = 0;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;

            printDocument.BeginPrint += PrintDocument_BeginPrint;
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.EndPrint += PrintDocument_EndPrint;

            timer1.Tick += Timer1_Tick;
            notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;

            richTextBox1.AllowDrop  = true;
            richTextBox1.DragEnter  += RichTextBox1_DragEnter;
            richTextBox1.DragDrop   += RichTextBox1_DragDrop;
        }

        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files  = e.Data.GetData(DataFormats.FileDrop) as string[];
            string filePath = string.Empty;

            foreach (string path in files)
            {
                if(File.Exists(path) && Path.GetExtension(path) == ".cs")
                {
                    filePath = path;
                }
            }

            if(filePath != string.Empty)
            {
                Reset();

                try
                {
                    richTextBox1.LoadFile(filePath, RichTextBoxStreamType.PlainText);
                    _fileName = filePath;
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = ex.Message;
                }
            }
        }

        private void RichTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            KeywordsBacklight(richTextBox1.Text);
            СommentsBacklight(richTextBox1.Text);
            TextBacklight(richTextBox1.Text);
        }

        private void KeywordsBacklight(string text)
        {
            int currentSelStart     = richTextBox1.SelectionStart;
            int currentSelLength    = richTextBox1.SelectionLength;

            foreach (string word in _keyWordsList)
            {
                string pattern = @"\b" + word + @"\b";
                Test(text, pattern, Color.Blue);
            }

            richTextBox1.Select(currentSelStart, currentSelLength);
            richTextBox1.SelectionColor = Color.Black;
        }

        private void СommentsBacklight(string text)
        {
            int currentSelStart     = richTextBox1.SelectionStart;
            int currentSelLength    = richTextBox1.SelectionLength;

            string single_linePattern   = @"\/\/.*";
            string multilinePattern     = @"\/\*([\s\S]*)\*\/";

            Test(text, single_linePattern, Color.Green);
            Test(text, multilinePattern, Color.Green);

            richTextBox1.Select(currentSelStart, currentSelLength);
            richTextBox1.SelectionColor = Color.Black;
        }

        private void TextBacklight(string text)
        {
            int currentSelStart     = richTextBox1.SelectionStart;
            int currentSelLength    = richTextBox1.SelectionLength;

            string textPattern = "@?\"(\\w*\\s+\" |:?)(.*?)\"";
            string symbolPattern = @"'.'";
            Test(text, textPattern, Color.Brown);
            Test(text, symbolPattern, Color.Brown);

            richTextBox1.Select(currentSelStart, currentSelLength);
            richTextBox1.SelectionColor = Color.Black;
        }

        private void Test(string text, string pattern, Color color)
        {
            try
            {
                MatchCollection matches = Regex.Matches(text, pattern);
                for (int i = 0; i < matches.Count; i++)
                {
                    richTextBox1.Select(matches[i].Index, matches[i].Length);
                    richTextBox1.SelectionColor = color;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            richTextBox1.Text   = string.Empty;
            textBox1.Text       = string.Empty;
            _fileName           = string.Empty;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "C# source file (*.cs)|*.cs";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                    _fileName = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = ex.Message;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_fileName != string.Empty)
            {
                richTextBox1.SaveFile(_fileName, RichTextBoxStreamType.PlainText);
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void buildToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BuildProject();
        }

        private void BuildProject()
        {
            try
            {
                _fileName = GetName(false);

                richTextBox1.SaveFile(_fileName, RichTextBoxStreamType.PlainText);

                if (File.Exists(_fileName))
                {
                    if (File.Exists(_fileName + ".exe"))
                    {
                        File.Delete(_fileName + ".exe");
                    }

                    string outputFile = GetName(true) + ".exe";

                    Process.Start(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe", " /target:exe /out:" + outputFile + " " + _fileName);

                    textBox1.Text = "1>------ Build started: Project: " + GetProjectName() + ", Configuration: Debug Any CPU ------\r\n1>------ " +
                                   GetProjectName() + @" -> " + outputFile + " \r\n";

                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunApplication(GetName(true) + ".exe", false);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new AboutForm();
            about.ShowDialog();
        }

        private void RunApplication(string fileName, bool isPrint)
        {
            if (File.Exists(fileName))
            {
                Process.Start(fileName);
            }

            if (isPrint)
            {
                textBox1.Text += (File.Exists(fileName) == true) ? "========== Build: 1 succeeded, 0 failed ========== " : "========== Build: 0 succeeded, 1 failed ========== ";
            }
        }

        private string GetName(bool isNotExtension)
        {
            string fileName = "Temp.cs";

            if(_fileName != string.Empty && Path.GetExtension(_fileName) == ".cs")
            {
                fileName = _fileName;
            }
            else
            {
                fileName = GetProjectName() + ".cs";
            }

            if(isNotExtension)
            {
                int index = -1;
                if((index = fileName.LastIndexOf(".cs")) != - 1)
                {
                    fileName = fileName.Substring(0, index);
                }
            }

            return fileName;
        }

        private string GetProjectName()
        {
            string projectName = "ConsoleApplication1";

            if (Regex.IsMatch(richTextBox1.Text, @"namespace\s?(\w*)"))
            {
                Match match = Regex.Match(richTextBox1.Text, @"namespace\s?(\w*)");

                if (match.Success)
                {
                    projectName = match.Groups[1].ToString() + ".cs";
                }
            }

            return projectName;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            RunApplication(GetName(true) + ".exe", true);
            timer1.Stop();
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Minimized) ? FormWindowState.Normal : FormWindowState.Minimized;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "C# source file (*.cs)|*.cs";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _fileName = saveFileDialog.FileName;
                    richTextBox1.SaveFile(_fileName, RichTextBoxStreamType.PlainText);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentContents = richTextBox1.Text;

            stringToPrint = documentContents;

            printDocument.Print();
        }

        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                char[] param = { '\n' };
                lines = richTextBox1.Text.Split(param);

                m_PageCount = 0;

                int i = 0;
                foreach (string s in lines)
                {
                    lines[i++] = s.TrimEnd('\r');
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;

                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;

                //if (_fileName == string.Empty || _fileName == null)
                //{
                //    g.DrawString("Default Project", new Font("Arial", 10), Brushes.Black, x, 50);
                //}
                //else
                //{
                //    g.DrawString(_fileName, new Font("Arial", 10), Brushes.Black, x, 50);
                //}

                g.DrawString(GetProjectName(), new Font("Arial", 10), Brushes.Black, x, 50);

                g.DrawString((++m_PageCount).ToString(), new Font("Arial", 10), Brushes.Black, e.MarginBounds.Right, 50);

                g.DrawLine(Pens.Black, new Point(e.MarginBounds.Left, 50 + new Font("Arial", 10).Height + 5), new Point(e.MarginBounds.Right + 15, 50 + new Font("Arial", 10).Height + 5));

                while (m_linePrinted < lines.Length)
                {
                    if (isShowLineNumber)
                    {
                        m_StartIndex = richTextBox1.Text.IndexOf(lines[m_linePrinted]);
                        m_EndIndex = m_StartIndex + lines[m_linePrinted++].Length;

                        g.DrawString((m_linePrinted).ToString() + "   ", richTextBox1.Font, Brushes.Black, x, y);
                        x += Convert.ToInt32(g.MeasureString((m_linePrinted + 1).ToString() + "   ", richTextBox1.Font).Width);
                    }
                    else
                    {
                        g.DrawString(new String(' ', 20), richTextBox1.Font, Brushes.Black, x, y);
                        x += 40;

                        isShowLineNumber = true;
                        m_linePrinted++;
                    }

                    for (int i = m_StartIndex; i < m_EndIndex; i++)
                    {
                        richTextBox1.Select(i, 1);
                        Brush brush = new SolidBrush(richTextBox1.SelectionColor);

                        g.DrawString(richTextBox1.Text[i].ToString(), richTextBox1.Font, brush, x, y);

                        x += Convert.ToInt32(g.MeasureString(richTextBox1.Text[i].ToString(), richTextBox1.Font).Width);

                        if ((x >= e.MarginBounds.Right) && (m_EndIndex - i > 5))
                        {
                            isShowLineNumber = false;

                            m_linePrinted--;
                            m_StartIndex = i + 1;

                            break;
                        }
                    }

                    x = e.MarginBounds.Left;
                    y += 15;
                    if (y >= e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }
                m_linePrinted = 0;

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            lines = null;

            isShowLineNumber = true;
            m_StartIndex = 0;
            m_EndIndex = 0;
        }
    }
}