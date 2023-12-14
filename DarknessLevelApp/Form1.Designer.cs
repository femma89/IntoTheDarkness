namespace DarknessLevelApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            folderBrowserDialog1 = new FolderBrowserDialog();
            btnBrowse = new Button();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            lblBrightness = new Label();
            lblAverageDarkness = new Label();
            richTextBoxErrors = new RichTextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(12, 219);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(120, 23);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Seleccionar Carpeta";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 190);
            button1.Name = "button1";
            button1.Size = new Size(120, 23);
            button1.TabIndex = 1;
            button1.Text = "Seleccionar Imagen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnCalculateSingleImage_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblBrightness
            // 
            lblBrightness.AutoSize = true;
            lblBrightness.BackColor = SystemColors.HotTrack;
            lblBrightness.BorderStyle = BorderStyle.FixedSingle;
            lblBrightness.ForeColor = SystemColors.ButtonHighlight;
            lblBrightness.Location = new Point(137, 194);
            lblBrightness.Name = "lblBrightness";
            lblBrightness.Size = new Size(2, 17);
            lblBrightness.TabIndex = 2;
            // 
            // lblAverageDarkness
            // 
            lblAverageDarkness.AutoSize = true;
            lblAverageDarkness.BackColor = SystemColors.HotTrack;
            lblAverageDarkness.BorderStyle = BorderStyle.FixedSingle;
            lblAverageDarkness.ForeColor = SystemColors.ButtonHighlight;
            lblAverageDarkness.Location = new Point(137, 223);
            lblAverageDarkness.Name = "lblAverageDarkness";
            lblAverageDarkness.Size = new Size(2, 17);
            lblAverageDarkness.TabIndex = 3;
            // 
            // richTextBoxErrors
            // 
            richTextBoxErrors.BackColor = Color.DarkGray;
            richTextBoxErrors.BorderStyle = BorderStyle.None;
            richTextBoxErrors.ForeColor = Color.DarkRed;
            richTextBoxErrors.Location = new Point(12, 270);
            richTextBoxErrors.Name = "richTextBoxErrors";
            richTextBoxErrors.Size = new Size(388, 88);
            richTextBoxErrors.TabIndex = 5;
            richTextBoxErrors.Text = "";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(388, 172);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(325, 366);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 6;
            label1.Text = "by femma89";
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(412, 388);
            Controls.Add(label1);
            Controls.Add(richTextBoxErrors);
            Controls.Add(pictureBox1);
            Controls.Add(lblAverageDarkness);
            Controls.Add(lblBrightness);
            Controls.Add(button1);
            Controls.Add(btnBrowse);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Into The Darkness";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnBrowse;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Label lblBrightness;
        private Label lblAverageDarkness;
        private RichTextBox richTextBoxErrors;
        private PictureBox pictureBox1;
        private Label label1;
    }
}