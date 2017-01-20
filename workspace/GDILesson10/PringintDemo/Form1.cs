using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PringintDemo
{
    public partial class Form1 : Form
    {
        private string _text;
        private PrintDocument _printDocument;

        public Form1()
        {
            
            InitializeComponent();
            if (File.Exists("lorem.txt"))
            {
                richTextBox1.LoadFile("lorem.txt", 
                                       RichTextBoxStreamType.PlainText);
            }
            _printDocument = new PrintDocument();
            _printDocument.PrintPage += PrintDocument_PrintPage;
            _printDocument.BeginPrint += PrintDocument_BeginPrint;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog {Font = richTextBox1.Font};
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var printDialog = new PrintDialog {Document = _printDocument};

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                _printDocument.Print();
            }
        }

        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            _text = richTextBox1.Text;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            
            var font = richTextBox1.Font;

            // получаем кол-во символов, которые вмещаются в область печати
            int characterFitted;
            // сткок текста на печати для текущей страницы
            int linesFitted;
            var format = new StringFormat(StringFormatFlags.LineLimit);
            g.MeasureString(_text, 
                            font, 
                            e.MarginBounds.Size, 
                            format, 
                            out characterFitted, out linesFitted);
            
            g.DrawRectangle(Pens.Black, e.MarginBounds);

            g.DrawString(_text.Substring(0, characterFitted), font, Brushes.Black, e.MarginBounds);
            _text = _text.Substring(characterFitted); // не напечатанный текст
            e.HasMorePages = _text.Length > 0;       // печатать на следующей странице если есть что печатать
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files|*.txt|Rtf files|*.rtf|All files|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog.FileName);
                _text = richTextBox1.Text;
            }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetup = new PageSetupDialog();
            pageSetup.Document = _printDocument;
            if (pageSetup.ShowDialog() == DialogResult.OK)
            {
                _printDocument.DefaultPageSettings = pageSetup.PageSettings;
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Предварительный просмотр документа перед печатью через стандартное диалоговое окно
            //PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            //previewDialog.Document = _printDocument;
            //previewDialog.ShowDialog();

            PreviewDialog previewDialog = new PreviewDialog();
            previewDialog.PrintPreviewControl.Document = _printDocument;
            previewDialog.ShowDialog();
        }
    }
}
