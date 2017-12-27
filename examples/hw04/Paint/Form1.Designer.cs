namespace Paint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonText = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxFillStyle = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxWidth = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxStyle = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonColors = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonColor1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonColor2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxGradientStyle = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1007, 522);
            this.panel1.TabIndex = 1;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLine,
            this.toolStripButtonText,
            this.toolStripSeparator1,
            this.toolStripButtonEllipse,
            this.toolStripButtonRectangle,
            this.toolStripComboBoxFillStyle,
            this.toolStripSeparator2,
            this.toolStripComboBoxWidth,
            this.toolStripComboBoxStyle,
            this.toolStripSeparator3,
            this.toolStripButtonColors,
            this.toolStripButton1,
            this.toolStripSeparator4,
            this.toolStripButtonFill,
            this.toolStripButtonColor1,
            this.toolStripButtonColor2,
            this.toolStripComboBoxGradientStyle,
            this.toolStripSeparator5,
            this.toolStripButtonClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1007, 39);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLine
            // 
            this.toolStripButtonLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLine.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLine.Image")));
            this.toolStripButtonLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLine.Name = "toolStripButtonLine";
            this.toolStripButtonLine.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonLine.Text = "Линия";
            this.toolStripButtonLine.Click += new System.EventHandler(this.toolStripButtonLine_Click);
            // 
            // toolStripButtonText
            // 
            this.toolStripButtonText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonText.Image")));
            this.toolStripButtonText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonText.Name = "toolStripButtonText";
            this.toolStripButtonText.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonText.Text = "Текст";
            this.toolStripButtonText.Click += new System.EventHandler(this.toolStripButtonText_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonEllipse
            // 
            this.toolStripButtonEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEllipse.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEllipse.Image")));
            this.toolStripButtonEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEllipse.Name = "toolStripButtonEllipse";
            this.toolStripButtonEllipse.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonEllipse.Text = "Эллипс";
            this.toolStripButtonEllipse.Click += new System.EventHandler(this.toolStripButtonEllipse_Click);
            // 
            // toolStripButtonRectangle
            // 
            this.toolStripButtonRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRectangle.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRectangle.Image")));
            this.toolStripButtonRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRectangle.Name = "toolStripButtonRectangle";
            this.toolStripButtonRectangle.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRectangle.Text = "Прямоугольник";
            this.toolStripButtonRectangle.Click += new System.EventHandler(this.toolStripButtonRectangle_Click);
            // 
            // toolStripComboBoxFillStyle
            // 
            this.toolStripComboBoxFillStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxFillStyle.Name = "toolStripComboBoxFillStyle";
            this.toolStripComboBoxFillStyle.Size = new System.Drawing.Size(160, 39);
            this.toolStripComboBoxFillStyle.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxFillStyle_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripComboBoxWidth
            // 
            this.toolStripComboBoxWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxWidth.Name = "toolStripComboBoxWidth";
            this.toolStripComboBoxWidth.Size = new System.Drawing.Size(121, 39);
            this.toolStripComboBoxWidth.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxWidth_SelectedIndexChanged);
            // 
            // toolStripComboBoxStyle
            // 
            this.toolStripComboBoxStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxStyle.Name = "toolStripComboBoxStyle";
            this.toolStripComboBoxStyle.Size = new System.Drawing.Size(121, 39);
            this.toolStripComboBoxStyle.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxStyle_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonColors
            // 
            this.toolStripButtonColors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonColors.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonColors.Image")));
            this.toolStripButtonColors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonColors.Name = "toolStripButtonColors";
            this.toolStripButtonColors.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonColors.Text = "Цвета";
            this.toolStripButtonColors.ToolTipText = "Нажмите чтобы выбрать цвет контура";
            this.toolStripButtonColors.Click += new System.EventHandler(this.toolStripButtonColors_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.Black;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(38, 36);
            this.toolStripButton1.Text = "         ";
            this.toolStripButton1.ToolTipText = "Цвет контура";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonFill
            // 
            this.toolStripButtonFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFill.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFill.Image")));
            this.toolStripButtonFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFill.Name = "toolStripButtonFill";
            this.toolStripButtonFill.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonFill.ToolTipText = "Нажмите чтобы выбрать заливку";
            this.toolStripButtonFill.Click += new System.EventHandler(this.toolStripButtonFill_Click);
            // 
            // toolStripButtonColor1
            // 
            this.toolStripButtonColor1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonColor1.Enabled = false;
            this.toolStripButtonColor1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonColor1.Name = "toolStripButtonColor1";
            this.toolStripButtonColor1.Size = new System.Drawing.Size(38, 36);
            this.toolStripButtonColor1.Text = "         ";
            this.toolStripButtonColor1.ToolTipText = "Цвет заливки";
            // 
            // toolStripButtonColor2
            // 
            this.toolStripButtonColor2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonColor2.Enabled = false;
            this.toolStripButtonColor2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonColor2.Name = "toolStripButtonColor2";
            this.toolStripButtonColor2.Size = new System.Drawing.Size(35, 36);
            this.toolStripButtonColor2.Text = "        ";
            this.toolStripButtonColor2.ToolTipText = "Дополнительный цвет заливки (используется для градиента)";
            // 
            // toolStripComboBoxGradientStyle
            // 
            this.toolStripComboBoxGradientStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxGradientStyle.Name = "toolStripComboBoxGradientStyle";
            this.toolStripComboBoxGradientStyle.Size = new System.Drawing.Size(121, 39);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClear.Image")));
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonClear.Text = "Очистить";
            this.toolStripButtonClear.Click += new System.EventHandler(this.toolStripButtonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1007, 561);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint++";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;        
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLine;
        private System.Windows.Forms.ToolStripButton toolStripButtonText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEllipse;
        private System.Windows.Forms.ToolStripButton toolStripButtonRectangle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxWidth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxStyle;
        private System.Windows.Forms.ToolStripButton toolStripButtonColors;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxFillStyle;
        private System.Windows.Forms.ToolStripButton toolStripButtonFill;
        private System.Windows.Forms.ToolStripButton toolStripButtonColor1;
        private System.Windows.Forms.ToolStripButton toolStripButtonColor2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxGradientStyle;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}

