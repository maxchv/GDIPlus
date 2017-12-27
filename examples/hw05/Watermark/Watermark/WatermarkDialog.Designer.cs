namespace Watermark
{
    partial class WatermarkDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WatermarkDialog));
            this.pictureBoxImageWatermark = new System.Windows.Forms.PictureBox();
            this.buttonAddPicture = new System.Windows.Forms.Button();
            this.textBoxWatermark = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageWatermark)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImageWatermark
            // 
            this.pictureBoxImageWatermark.BackColor = System.Drawing.Color.MintCream;
            this.pictureBoxImageWatermark.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxImageWatermark.Name = "pictureBoxImageWatermark";
            this.pictureBoxImageWatermark.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxImageWatermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImageWatermark.TabIndex = 0;
            this.pictureBoxImageWatermark.TabStop = false;
            // 
            // buttonAddPicture
            // 
            this.buttonAddPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAddPicture.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddPicture.Location = new System.Drawing.Point(12, 67);
            this.buttonAddPicture.Name = "buttonAddPicture";
            this.buttonAddPicture.Size = new System.Drawing.Size(121, 23);
            this.buttonAddPicture.TabIndex = 1;
            this.buttonAddPicture.Text = "Добавить картинку";
            this.buttonAddPicture.UseVisualStyleBackColor = false;
            this.buttonAddPicture.Click += new System.EventHandler(this.buttonAddPicture_Click);
            // 
            // textBoxWatermark
            // 
            this.textBoxWatermark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWatermark.BackColor = System.Drawing.Color.Honeydew;
            this.textBoxWatermark.Font = new System.Drawing.Font("Arial Narrow", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxWatermark.Location = new System.Drawing.Point(68, 12);
            this.textBoxWatermark.Name = "textBoxWatermark";
            this.textBoxWatermark.Size = new System.Drawing.Size(232, 50);
            this.textBoxWatermark.TabIndex = 2;
            this.textBoxWatermark.TextChanged += new System.EventHandler(this.textBoxWatermark_TextChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOk.Location = new System.Drawing.Point(225, 67);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "Принять";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.Location = new System.Drawing.Point(144, 67);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // WatermarkDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(312, 102);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxWatermark);
            this.Controls.Add(this.buttonAddPicture);
            this.Controls.Add(this.pictureBoxImageWatermark);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(450, 141);
            this.MinimumSize = new System.Drawing.Size(328, 141);
            this.Name = "WatermarkDialog";
            this.Text = "Водянной знак";
            this.Resize += new System.EventHandler(this.WatermarkDialog_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImageWatermark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImageWatermark;
        private System.Windows.Forms.Button buttonAddPicture;
        private System.Windows.Forms.TextBox textBoxWatermark;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}