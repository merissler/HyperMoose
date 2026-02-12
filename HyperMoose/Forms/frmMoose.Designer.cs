namespace HyperMoose.Forms
{
    partial class frmMoose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoose));
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.moose;
            pictureBox1.Location = new Point(314, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(512, 495);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(10, 206);
            label2.Margin = new Padding(3);
            label2.Name = "label2";
            label2.Padding = new Padding(12);
            label2.Size = new Size(192, 49);
            label2.TabIndex = 2;
            label2.Text = "LEEEROY JENKINS";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(10, 258);
            label1.Margin = new Padding(3);
            label1.MaximumSize = new Size(826, 237);
            label1.Name = "label1";
            label1.Padding = new Padding(12);
            label1.Size = new Size(816, 118);
            label1.TabIndex = 1;
            label1.Text = resources.GetString("label1.Text");
            label1.SizeChanged += label1_SizeChanged;
            label1.DoubleClick += label1_DoubleClick;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(783, 211);
            button1.Name = "button1";
            button1.Padding = new Padding(6, 0, 6, 6);
            button1.Size = new Size(43, 41);
            button1.TabIndex = 3;
            button1.Text = "x";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // frmMoose
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Lime;
            ClientSize = new Size(826, 495);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmMoose";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Moose Message";
            TopMost = true;
            TransparencyKey = Color.Lime;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Button button1;
    }
}