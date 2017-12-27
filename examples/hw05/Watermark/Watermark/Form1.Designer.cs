namespace Watermark
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonSetMark = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watermarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createWatermarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxWatermark = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWatermark)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImage.Location = new System.Drawing.Point(12, 27);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(491, 413);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPrev.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonPrev.Enabled = false;
            this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPrev.Location = new System.Drawing.Point(139, 447);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(75, 23);
            this.buttonPrev.TabIndex = 1;
            this.buttonPrev.Text = "Пред.";
            this.buttonPrev.UseVisualStyleBackColor = false;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonNext.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonNext.Enabled = false;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNext.Location = new System.Drawing.Point(301, 447);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "След.";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonSetMark
            // 
            this.buttonSetMark.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSetMark.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonSetMark.Enabled = false;
            this.buttonSetMark.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSetMark.Location = new System.Drawing.Point(220, 447);
            this.buttonSetMark.Name = "buttonSetMark";
            this.buttonSetMark.Size = new System.Drawing.Size(75, 23);
            this.buttonSetMark.TabIndex = 1;
            this.buttonSetMark.Text = "Добавить";
            this.buttonSetMark.UseVisualStyleBackColor = false;
            this.buttonSetMark.Click += new System.EventHandler(this.buttonSetMark_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.watermarkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(514, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.LightBlue;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.BackColor = System.Drawing.Color.LightBlue;
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.openFolderToolStripMenuItem.Text = "Открыть папку...";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.BackColor = System.Drawing.Color.LightBlue;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.quitToolStripMenuItem.Text = "Выйти";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // watermarkToolStripMenuItem
            // 
            this.watermarkToolStripMenuItem.BackColor = System.Drawing.Color.LightBlue;
            this.watermarkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createWatermarkToolStripMenuItem,
            this.selectFileToolStripMenuItem});
            this.watermarkToolStripMenuItem.Name = "watermarkToolStripMenuItem";
            this.watermarkToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.watermarkToolStripMenuItem.Text = "Водянной знак";
            // 
            // createWatermarkToolStripMenuItem
            // 
            this.createWatermarkToolStripMenuItem.BackColor = System.Drawing.Color.LightBlue;
            this.createWatermarkToolStripMenuItem.Name = "createWatermarkToolStripMenuItem";
            this.createWatermarkToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.createWatermarkToolStripMenuItem.Text = "Создать...";
            this.createWatermarkToolStripMenuItem.Click += new System.EventHandler(this.createWatermarkToolStripMenuItem_Click);
            // 
            // selectFileToolStripMenuItem
            // 
            this.selectFileToolStripMenuItem.BackColor = System.Drawing.Color.LightBlue;
            this.selectFileToolStripMenuItem.Name = "selectFileToolStripMenuItem";
            this.selectFileToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.selectFileToolStripMenuItem.Text = "Выбрать изображение...";
            this.selectFileToolStripMenuItem.Click += new System.EventHandler(this.selectFileToolStripMenuItem_Click);
            // 
            // pictureBoxWatermark
            // 
            this.pictureBoxWatermark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxWatermark.Location = new System.Drawing.Point(352, 390);
            this.pictureBoxWatermark.Name = "pictureBoxWatermark";
            this.pictureBoxWatermark.Size = new System.Drawing.Size(150, 50);
            this.pictureBoxWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWatermark.TabIndex = 3;
            this.pictureBoxWatermark.TabStop = false;
            this.pictureBoxWatermark.Visible = false;
            this.pictureBoxWatermark.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWatermark_MouseDown);
            this.pictureBoxWatermark.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWatermark_MouseMove);
            this.pictureBoxWatermark.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxWatermark_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(514, 481);
            this.Controls.Add(this.pictureBoxWatermark);
            this.Controls.Add(this.buttonSetMark);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrev);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Водянной знак(Креатив жыш)";
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWatermark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonSetMark;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watermarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createWatermarkToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxWatermark;
        private System.Windows.Forms.ToolStripMenuItem selectFileToolStripMenuItem;
    }
}

