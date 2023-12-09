namespace WinFormsApp1
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
            button1 = new Button();
            labelOutput = new Label();
            textBox1 = new TextBox();
            groupBox1 = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            label3 = new Label();
            comboBox3 = new ComboBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            comboBox2 = new ComboBox();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            comboBox4 = new ComboBox();
            pictureBox1 = new PictureBox();
            labelSuccess = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(56, 23);
            button1.TabIndex = 0;
            button1.Text = "Ввести";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Location = new Point(12, 408);
            labelOutput.MaximumSize = new Size(250, 0);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(70, 15);
            labelOutput.TabIndex = 1;
            labelOutput.Text = "labelOutput";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(74, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(246, 23);
            textBox1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(checkBox4);
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBox3);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(231, 349);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Авторы";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(134, 251);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(86, 23);
            numericUpDown1.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Location = new Point(9, 255);
            label4.Name = "label4";
            label4.Size = new Size(93, 15);
            label4.TabIndex = 18;
            label4.Text = "Кол-во авторов";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(9, 226);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(61, 19);
            checkBox4.TabIndex = 16;
            checkBox4.Text = "“et al.”";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.Click += checkBox4_Click;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(9, 291);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(128, 49);
            checkBox3.TabIndex = 15;
            checkBox3.Text = "Союз “and” между\r\nпоследним и \r\nпредпоследним";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 178);
            label3.Name = "label3";
            label3.Size = new Size(99, 30);
            label3.TabIndex = 14;
            label3.Text = "Разделитель\r\nмежду авторами";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { ",", ";" });
            comboBox3.Location = new Point(134, 182);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(86, 23);
            comboBox3.TabIndex = 13;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(9, 87);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(108, 34);
            checkBox2.TabIndex = 12;
            checkBox2.Text = "Пробел между\r\nинициалами";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(9, 47);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(94, 34);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Точка после\r\nинициалов";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "\"\"", "\" \"", "\",\"", "\", \"" });
            comboBox2.Location = new Point(134, 134);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(86, 23);
            comboBox2.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 125);
            label5.Name = "label5";
            label5.Size = new Size(116, 45);
            label5.TabIndex = 9;
            label5.Text = "Разделитель\r\nмежду инициалами\r\nи фамилией";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Инициалы/Фамилия", "Фамилия/Инициалы" });
            comboBox1.Location = new Point(87, 18);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(133, 23);
            comboBox1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 21);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 0;
            label2.Text = "Положение";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox4);
            groupBox2.Location = new Point(249, 50);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(201, 52);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Название статьи";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Без названия", "С названием", "Название с заглавными буквами" });
            comboBox4.Location = new Point(6, 18);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(189, 23);
            comboBox4.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = RefGenerator.Properties.Resources.copy1;
            pictureBox1.Location = new Point(249, 404);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(1);
            pictureBox1.Size = new Size(36, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // labelSuccess
            // 
            labelSuccess.AutoSize = true;
            labelSuccess.Location = new Point(291, 408);
            labelSuccess.Name = "labelSuccess";
            labelSuccess.Size = new Size(73, 15);
            labelSuccess.TabIndex = 6;
            labelSuccess.Text = "labelSuccess";
            labelSuccess.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 460);
            Controls.Add(labelSuccess);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(textBox1);
            Controls.Add(labelOutput);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label labelOutput;
        private TextBox textBox1;
        private GroupBox groupBox1;
        private Label label2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label5;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label3;
        private ComboBox comboBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private GroupBox groupBox2;
        private ComboBox comboBox4;
        private PictureBox pictureBox1;
        private Label labelSuccess;
    }
}