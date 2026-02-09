namespace HyperMoose
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
            splitContainer1 = new SplitContainer();
            listBox1 = new ListBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox1 = new TextBox();
            btnSpeech = new Button();
            btnSocietyEdit = new Button();
            btnFriendEdit = new Button();
            listBox2 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(13, 13);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBox1);
            splitContainer1.Panel1.Padding = new Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(753, 448);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(3, 3);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(244, 442);
            listBox1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(textBox1, 0, 2);
            tableLayoutPanel1.Controls.Add(btnSpeech, 1, 2);
            tableLayoutPanel1.Controls.Add(btnSocietyEdit, 0, 0);
            tableLayoutPanel1.Controls.Add(btnFriendEdit, 0, 1);
            tableLayoutPanel1.Controls.Add(listBox2, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tableLayoutPanel1.Size = new Size(499, 448);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Location = new Point(3, 81);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(390, 30);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // btnSpeech
            // 
            btnSpeech.Location = new Point(399, 81);
            btnSpeech.Name = "btnSpeech";
            btnSpeech.Size = new Size(97, 33);
            btnSpeech.TabIndex = 2;
            btnSpeech.Text = "SPEECH";
            btnSpeech.UseVisualStyleBackColor = true;
            btnSpeech.Click += btnSpeech_Click;
            // 
            // btnSocietyEdit
            // 
            btnSocietyEdit.Location = new Point(3, 3);
            btnSocietyEdit.Name = "btnSocietyEdit";
            btnSocietyEdit.Size = new Size(163, 33);
            btnSocietyEdit.TabIndex = 3;
            btnSocietyEdit.Text = "SOCIETY EDIT";
            btnSocietyEdit.UseVisualStyleBackColor = true;
            btnSocietyEdit.Click += btnSocietyEdit_Click;
            // 
            // btnFriendEdit
            // 
            btnFriendEdit.Location = new Point(3, 42);
            btnFriendEdit.Name = "btnFriendEdit";
            btnFriendEdit.Size = new Size(163, 33);
            btnFriendEdit.TabIndex = 4;
            btnFriendEdit.Text = "FRIEND EDIT";
            btnFriendEdit.UseVisualStyleBackColor = true;
            btnFriendEdit.Click += btnFriendEdit_Click;
            // 
            // listBox2
            // 
            tableLayoutPanel1.SetColumnSpan(listBox2, 2);
            listBox2.Dock = DockStyle.Fill;
            listBox2.FormattingEnabled = true;
            listBox2.IntegralHeight = false;
            listBox2.Location = new Point(3, 120);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(493, 325);
            listBox2.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 474);
            Controls.Add(splitContainer1);
            Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form1";
            Padding = new Padding(13, 13, 13, 13);
            Text = "HYPER MOOSE";
            Activated += Form1_Activated;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox textBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSpeech;
        private ListBox listBox1;
        private Button btnSocietyEdit;
        private Button btnFriendEdit;
        private ListBox listBox2;
    }
}
