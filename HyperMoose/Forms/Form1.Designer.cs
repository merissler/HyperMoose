namespace HyperMoose.Forms
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
            btnFriendEdit = new Button();
            listBox2 = new ListBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(14, 14);
            splitContainer1.Margin = new Padding(4, 2, 4, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBox1);
            splitContainer1.Panel1.Padding = new Padding(4, 2, 4, 2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(853, 284);
            splitContainer1.SplitterDistance = 305;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.IntegralHeight = false;
            listBox1.Location = new Point(4, 2);
            listBox1.Margin = new Padding(4, 2, 4, 2);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(297, 280);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(textBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSpeech, 4, 1);
            tableLayoutPanel1.Controls.Add(btnFriendEdit, 0, 0);
            tableLayoutPanel1.Controls.Add(listBox2, 0, 2);
            tableLayoutPanel1.Controls.Add(numericUpDown1, 2, 0);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(comboBox1, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 2, 4, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel1.Size = new Size(543, 284);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.CharacterCasing = CharacterCasing.Upper;
            tableLayoutPanel1.SetColumnSpan(textBox1, 4);
            textBox1.Location = new Point(4, 39);
            textBox1.Margin = new Padding(4, 2, 4, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(431, 30);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // btnSpeech
            // 
            btnSpeech.Location = new Point(443, 39);
            btnSpeech.Margin = new Padding(4, 2, 4, 2);
            btnSpeech.Name = "btnSpeech";
            btnSpeech.Size = new Size(96, 32);
            btnSpeech.TabIndex = 2;
            btnSpeech.Text = "SPEECH";
            btnSpeech.UseVisualStyleBackColor = true;
            btnSpeech.Click += btnSpeech_Click;
            // 
            // btnFriendEdit
            // 
            btnFriendEdit.AutoSize = true;
            btnFriendEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFriendEdit.Location = new Point(4, 2);
            btnFriendEdit.Margin = new Padding(4, 2, 4, 2);
            btnFriendEdit.Name = "btnFriendEdit";
            btnFriendEdit.Size = new Size(108, 33);
            btnFriendEdit.TabIndex = 3;
            btnFriendEdit.Text = "BRETHREN";
            btnFriendEdit.UseVisualStyleBackColor = true;
            btnFriendEdit.Click += btnFriendEdit_Click;
            // 
            // listBox2
            // 
            tableLayoutPanel1.SetColumnSpan(listBox2, 5);
            listBox2.Dock = DockStyle.Fill;
            listBox2.FormattingEnabled = true;
            listBox2.IntegralHeight = false;
            listBox2.Location = new Point(4, 75);
            listBox2.Margin = new Padding(4, 2, 4, 2);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(535, 207);
            listBox2.TabIndex = 5;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(177, 2);
            numericUpDown1.Margin = new Padding(4, 2, 4, 2);
            numericUpDown1.Maximum = new decimal(new int[] { 49151, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(95, 30);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.Value = new decimal(new int[] { 7777, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(120, 7);
            label1.Margin = new Padding(4, 0, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(53, 23);
            label1.TabIndex = 7;
            label1.Text = "PORT";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(comboBox1, 2);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(280, 3);
            comboBox1.Margin = new Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(259, 31);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 312);
            Controls.Add(splitContainer1);
            Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 3, 5, 3);
            Name = "Form1";
            Padding = new Padding(14);
            Text = "HYPER MOOSE";
            Activated += Form1_Activated;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox textBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSpeech;
        private ListBox listBox1;
        private Button btnFriendEdit;
        private ListBox listBox2;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private ComboBox comboBox1;
    }
}
