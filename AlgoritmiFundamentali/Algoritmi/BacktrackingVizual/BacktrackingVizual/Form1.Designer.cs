namespace BacktrackingVizual
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
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            label1 = new Label();
            solutionTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            existingTextBox = new TextBox();
            indexLabel = new Label();
            iLabel = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.White;
            listBox1.Font = new Font("Comic Sans MS", 20.1428585F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 65;
            listBox1.Location = new Point(1039, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(397, 979);
            listBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.White;
            textBox1.Font = new Font("Comic Sans MS", 20.1428585F, FontStyle.Bold);
            textBox1.Location = new Point(93, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 73);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 20.1428585F, FontStyle.Bold);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(75, 67);
            label1.TabIndex = 2;
            label1.Text = "n:";
            // 
            // solutionTextBox
            // 
            solutionTextBox.BackColor = Color.White;
            solutionTextBox.Font = new Font("Comic Sans MS", 20.1428585F, FontStyle.Bold);
            solutionTextBox.Location = new Point(240, 121);
            solutionTextBox.Name = "solutionTextBox";
            solutionTextBox.ReadOnly = true;
            solutionTextBox.Size = new Size(343, 73);
            solutionTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 20.1428585F, FontStyle.Bold);
            label2.Location = new Point(12, 124);
            label2.Name = "label2";
            label2.Size = new Size(222, 67);
            label2.TabIndex = 4;
            label2.Text = "solution:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 20.1428585F, FontStyle.Bold);
            label3.Location = new Point(12, 214);
            label3.Name = "label3";
            label3.Size = new Size(227, 67);
            label3.TabIndex = 6;
            label3.Text = "existing:";
            // 
            // existingTextBox
            // 
            existingTextBox.BackColor = Color.White;
            existingTextBox.Font = new Font("Comic Sans MS", 20.1428585F, FontStyle.Bold);
            existingTextBox.Location = new Point(240, 211);
            existingTextBox.Name = "existingTextBox";
            existingTextBox.ReadOnly = true;
            existingTextBox.Size = new Size(343, 73);
            existingTextBox.TabIndex = 5;
            // 
            // indexLabel
            // 
            indexLabel.AutoSize = true;
            indexLabel.Font = new Font("Comic Sans MS", 20.1428585F, FontStyle.Bold);
            indexLabel.Location = new Point(12, 331);
            indexLabel.Name = "indexLabel";
            indexLabel.Size = new Size(171, 67);
            indexLabel.TabIndex = 7;
            indexLabel.Text = "index:";
            // 
            // iLabel
            // 
            iLabel.AutoSize = true;
            iLabel.Font = new Font("Comic Sans MS", 20.1428585F, FontStyle.Bold);
            iLabel.Location = new Point(12, 398);
            iLabel.Name = "iLabel";
            iLabel.Size = new Size(63, 67);
            iLabel.TabIndex = 8;
            iLabel.Text = "i:";
            // 
            // button1
            // 
            button1.Font = new Font("Comic Sans MS", 20.1428585F, FontStyle.Bold);
            button1.Location = new Point(712, 331);
            button1.Name = "button1";
            button1.Size = new Size(294, 134);
            button1.TabIndex = 9;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 1005);
            Controls.Add(button1);
            Controls.Add(iLabel);
            Controls.Add(indexLabel);
            Controls.Add(label3);
            Controls.Add(existingTextBox);
            Controls.Add(label2);
            Controls.Add(solutionTextBox);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox textBox1;
        private Label label1;
        private TextBox solutionTextBox;
        private Label label2;
        private Label label3;
        private TextBox existingTextBox;
        private Label indexLabel;
        private Label iLabel;
        private Button button1;
    }
}
