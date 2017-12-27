namespace AnalogWatch
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
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTimeLeft = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDate.AutoSize = true;
            this.labelDate.BackColor = System.Drawing.Color.Transparent;
            this.labelDate.Location = new System.Drawing.Point(8, 433);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(33, 13);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "Дата";
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(44, 429);
            this.dateTimePickerEndDate.MaxDate = new System.DateTime(2017, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerEndDate.MinDate = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(138, 20);
            this.dateTimePickerEndDate.TabIndex = 1;
            this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.Transparent;
            this.labelTime.Location = new System.Drawing.Point(187, 433);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(150, 13);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "До указаной даты осталось";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTimeLeft
            // 
            this.labelTimeLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTimeLeft.AutoSize = true;
            this.labelTimeLeft.BackColor = System.Drawing.Color.Transparent;
            this.labelTimeLeft.Location = new System.Drawing.Point(343, 433);
            this.labelTimeLeft.Name = "labelTimeLeft";
            this.labelTimeLeft.Size = new System.Drawing.Size(0, 13);
            this.labelTimeLeft.TabIndex = 3;
            this.labelTimeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.labelTimeLeft);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.labelDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Analog Watch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelTimeLeft;
    }
}

