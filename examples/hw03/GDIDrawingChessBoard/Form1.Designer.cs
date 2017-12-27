namespace GDIDrawingChessBoard
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelStep = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTimeGame = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelScores = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStrip.BackgroundImage")));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelStep,
            this.toolStripStatusLabelTimeGame,
            this.toolStripStatusLabelScores});
            this.statusStrip.Location = new System.Drawing.Point(0, 359);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(427, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelStep
            // 
            this.toolStripStatusLabelStep.AutoSize = false;
            this.toolStripStatusLabelStep.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelStep.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabelStep.Name = "toolStripStatusLabelStep";
            this.toolStripStatusLabelStep.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabelStep.Text = "  ";
            // 
            // toolStripStatusLabelTimeGame
            // 
            this.toolStripStatusLabelTimeGame.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelTimeGame.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabelTimeGame.Name = "toolStripStatusLabelTimeGame";
            this.toolStripStatusLabelTimeGame.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabelTimeGame.Text = "Time game:";
            // 
            // toolStripStatusLabelScores
            // 
            this.toolStripStatusLabelScores.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelScores.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabelScores.Name = "toolStripStatusLabelScores";
            this.toolStripStatusLabelScores.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelScores.Text = "toolStripStatusLabel2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(427, 381);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(370, 420);
            this.Name = "Form1";
            this.Text = "Checkers";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStep;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTimeGame;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelScores;
    }
}

