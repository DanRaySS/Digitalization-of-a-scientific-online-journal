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
            DOIInputButton = new Button();
            labelOutput = new Label();
            DOIinput = new TextBox();
            authorsBox = new GroupBox();
            AuthorsLimiter = new NumericUpDown();
            label4 = new Label();
            AuthsLimitCheck = new CheckBox();
            AndCheck = new CheckBox();
            label3 = new Label();
            AuthSepDropList = new ComboBox();
            InitialsSpaceCheck = new CheckBox();
            InitialsDotCheck = new CheckBox();
            NameSepDropList = new ComboBox();
            label5 = new Label();
            AuthPosDropList = new ComboBox();
            label2 = new Label();
            articleBox = new GroupBox();
            ArticleNameDropList = new ComboBox();
            pictureBox1 = new PictureBox();
            labelSuccess = new Label();
            journalBox = new GroupBox();
            JournalNameDropList = new ComboBox();
            DOIBox = new GroupBox();
            DOIDropList = new ComboBox();
            PageBox = new GroupBox();
            PageItalic = new CheckBox();
            PageBold = new CheckBox();
            YearBox = new GroupBox();
            YearItalic = new CheckBox();
            YearBold = new CheckBox();
            ThomeBox = new GroupBox();
            ThomeItalic = new CheckBox();
            ThomeBold = new CheckBox();
            authorsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AuthorsLimiter).BeginInit();
            articleBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            journalBox.SuspendLayout();
            DOIBox.SuspendLayout();
            PageBox.SuspendLayout();
            YearBox.SuspendLayout();
            ThomeBox.SuspendLayout();
            SuspendLayout();
            // 
            // DOIInputButton
            // 
            DOIInputButton.Location = new Point(14, 16);
            DOIInputButton.Margin = new Padding(3, 4, 3, 4);
            DOIInputButton.Name = "DOIInputButton";
            DOIInputButton.Size = new Size(64, 31);
            DOIInputButton.TabIndex = 0;
            DOIInputButton.Text = "Ввести";
            DOIInputButton.UseVisualStyleBackColor = true;
            DOIInputButton.Click += button1_Click;
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Location = new Point(14, 544);
            labelOutput.MaximumSize = new Size(286, 0);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(88, 20);
            labelOutput.TabIndex = 1;
            labelOutput.Text = "labelOutput";
            // 
            // DOIinput
            // 
            DOIinput.Location = new Point(84, 18);
            DOIinput.Margin = new Padding(3, 4, 3, 4);
            DOIinput.Name = "DOIinput";
            DOIinput.Size = new Size(281, 27);
            DOIinput.TabIndex = 2;
            // 
            // authorsBox
            // 
            authorsBox.Controls.Add(AuthorsLimiter);
            authorsBox.Controls.Add(label4);
            authorsBox.Controls.Add(AuthsLimitCheck);
            authorsBox.Controls.Add(AndCheck);
            authorsBox.Controls.Add(label3);
            authorsBox.Controls.Add(AuthSepDropList);
            authorsBox.Controls.Add(InitialsSpaceCheck);
            authorsBox.Controls.Add(InitialsDotCheck);
            authorsBox.Controls.Add(NameSepDropList);
            authorsBox.Controls.Add(label5);
            authorsBox.Controls.Add(AuthPosDropList);
            authorsBox.Controls.Add(label2);
            authorsBox.Location = new Point(14, 67);
            authorsBox.Margin = new Padding(3, 4, 3, 4);
            authorsBox.Name = "authorsBox";
            authorsBox.Padding = new Padding(3, 4, 3, 4);
            authorsBox.Size = new Size(264, 465);
            authorsBox.TabIndex = 3;
            authorsBox.TabStop = false;
            authorsBox.Text = "Авторы";
            // 
            // AuthorsLimiter
            // 
            AuthorsLimiter.Enabled = false;
            AuthorsLimiter.Location = new Point(153, 335);
            AuthorsLimiter.Margin = new Padding(3, 4, 3, 4);
            AuthorsLimiter.Name = "AuthorsLimiter";
            AuthorsLimiter.Size = new Size(98, 27);
            AuthorsLimiter.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Location = new Point(10, 340);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 18;
            label4.Text = "Кол-во авторов";
            // 
            // AuthsLimitCheck
            // 
            AuthsLimitCheck.AutoSize = true;
            AuthsLimitCheck.Location = new Point(10, 301);
            AuthsLimitCheck.Margin = new Padding(3, 4, 3, 4);
            AuthsLimitCheck.Name = "AuthsLimitCheck";
            AuthsLimitCheck.Size = new Size(75, 24);
            AuthsLimitCheck.TabIndex = 16;
            AuthsLimitCheck.Text = "“et al.”";
            AuthsLimitCheck.UseVisualStyleBackColor = true;
            AuthsLimitCheck.Click += AuthsLimitCheck_Click;
            // 
            // AndCheck
            // 
            AndCheck.AutoSize = true;
            AndCheck.Location = new Point(10, 388);
            AndCheck.Margin = new Padding(3, 4, 3, 4);
            AndCheck.Name = "AndCheck";
            AndCheck.Size = new Size(158, 64);
            AndCheck.TabIndex = 15;
            AndCheck.Text = "Союз “and” между\r\nпоследним и \r\nпредпоследним";
            AndCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 237);
            label3.Name = "label3";
            label3.Size = new Size(126, 40);
            label3.TabIndex = 14;
            label3.Text = "Разделитель\r\nмежду авторами";
            // 
            // AuthSepDropList
            // 
            AuthSepDropList.FormattingEnabled = true;
            AuthSepDropList.Items.AddRange(new object[] { ",", ";" });
            AuthSepDropList.Location = new Point(153, 243);
            AuthSepDropList.Margin = new Padding(3, 4, 3, 4);
            AuthSepDropList.Name = "AuthSepDropList";
            AuthSepDropList.Size = new Size(98, 28);
            AuthSepDropList.TabIndex = 13;
            // 
            // InitialsSpaceCheck
            // 
            InitialsSpaceCheck.AutoSize = true;
            InitialsSpaceCheck.Location = new Point(10, 116);
            InitialsSpaceCheck.Margin = new Padding(3, 4, 3, 4);
            InitialsSpaceCheck.Name = "InitialsSpaceCheck";
            InitialsSpaceCheck.Size = new Size(134, 44);
            InitialsSpaceCheck.TabIndex = 12;
            InitialsSpaceCheck.Text = "Пробел между\r\nинициалами";
            InitialsSpaceCheck.UseVisualStyleBackColor = true;
            // 
            // InitialsDotCheck
            // 
            InitialsDotCheck.AutoSize = true;
            InitialsDotCheck.Location = new Point(10, 63);
            InitialsDotCheck.Margin = new Padding(3, 4, 3, 4);
            InitialsDotCheck.Name = "InitialsDotCheck";
            InitialsDotCheck.Size = new Size(116, 44);
            InitialsDotCheck.TabIndex = 11;
            InitialsDotCheck.Text = "Точка после\r\nинициалов";
            InitialsDotCheck.UseVisualStyleBackColor = true;
            // 
            // NameSepDropList
            // 
            NameSepDropList.FormattingEnabled = true;
            NameSepDropList.Items.AddRange(new object[] { "\"\"", "\" \"", "\",\"", "\", \"" });
            NameSepDropList.Location = new Point(153, 179);
            NameSepDropList.Margin = new Padding(3, 4, 3, 4);
            NameSepDropList.Name = "NameSepDropList";
            NameSepDropList.Size = new Size(98, 28);
            NameSepDropList.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 167);
            label5.Name = "label5";
            label5.Size = new Size(147, 60);
            label5.TabIndex = 9;
            label5.Text = "Разделитель\r\nмежду инициалами\r\nи фамилией";
            // 
            // AuthPosDropList
            // 
            AuthPosDropList.FormattingEnabled = true;
            AuthPosDropList.Items.AddRange(new object[] { "Инициалы/Фамилия", "Фамилия/Инициалы" });
            AuthPosDropList.Location = new Point(99, 24);
            AuthPosDropList.Margin = new Padding(3, 4, 3, 4);
            AuthPosDropList.Name = "AuthPosDropList";
            AuthPosDropList.Size = new Size(151, 28);
            AuthPosDropList.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 28);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 0;
            label2.Text = "Положение";
            // 
            // articleBox
            // 
            articleBox.Controls.Add(ArticleNameDropList);
            articleBox.Location = new Point(285, 67);
            articleBox.Margin = new Padding(3, 4, 3, 4);
            articleBox.Name = "articleBox";
            articleBox.Padding = new Padding(3, 4, 3, 4);
            articleBox.Size = new Size(230, 69);
            articleBox.TabIndex = 4;
            articleBox.TabStop = false;
            articleBox.Text = "Название статьи";
            // 
            // ArticleNameDropList
            // 
            ArticleNameDropList.FormattingEnabled = true;
            ArticleNameDropList.Items.AddRange(new object[] { "Без названия", "С названием", "Название с заглавными буквами" });
            ArticleNameDropList.Location = new Point(7, 24);
            ArticleNameDropList.Margin = new Padding(3, 4, 3, 4);
            ArticleNameDropList.Name = "ArticleNameDropList";
            ArticleNameDropList.Size = new Size(215, 28);
            ArticleNameDropList.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = RefGenerator.Properties.Resources.copy1;
            pictureBox1.Location = new Point(285, 539);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(1);
            pictureBox1.Size = new Size(41, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // labelSuccess
            // 
            labelSuccess.AutoSize = true;
            labelSuccess.Location = new Point(333, 544);
            labelSuccess.Name = "labelSuccess";
            labelSuccess.Size = new Size(92, 20);
            labelSuccess.TabIndex = 6;
            labelSuccess.Text = "labelSuccess";
            labelSuccess.Visible = false;
            // 
            // journalBox
            // 
            journalBox.Controls.Add(JournalNameDropList);
            journalBox.Location = new Point(285, 143);
            journalBox.Name = "journalBox";
            journalBox.Size = new Size(230, 71);
            journalBox.TabIndex = 7;
            journalBox.TabStop = false;
            journalBox.Text = "Название журнала";
            // 
            // JournalNameDropList
            // 
            JournalNameDropList.FormattingEnabled = true;
            JournalNameDropList.Items.AddRange(new object[] { "Полное", "Аббревиатура" });
            JournalNameDropList.Location = new Point(7, 26);
            JournalNameDropList.Name = "JournalNameDropList";
            JournalNameDropList.Size = new Size(215, 28);
            JournalNameDropList.TabIndex = 0;
            // 
            // DOIBox
            // 
            DOIBox.Controls.Add(DOIDropList);
            DOIBox.Location = new Point(285, 220);
            DOIBox.Name = "DOIBox";
            DOIBox.Size = new Size(230, 74);
            DOIBox.TabIndex = 8;
            DOIBox.TabStop = false;
            DOIBox.Text = "DOI";
            // 
            // DOIDropList
            // 
            DOIDropList.FormattingEnabled = true;
            DOIDropList.Items.AddRange(new object[] { "Без указания", "Сокращенное", "Как url-ссылка" });
            DOIDropList.Location = new Point(7, 26);
            DOIDropList.Name = "DOIDropList";
            DOIDropList.Size = new Size(215, 28);
            DOIDropList.TabIndex = 0;
            // 
            // PageBox
            // 
            PageBox.Controls.Add(PageItalic);
            PageBox.Controls.Add(PageBold);
            PageBox.Location = new Point(521, 67);
            PageBox.Name = "PageBox";
            PageBox.Size = new Size(230, 90);
            PageBox.TabIndex = 9;
            PageBox.TabStop = false;
            PageBox.Text = "Номер страницы";
            // 
            // PageItalic
            // 
            PageItalic.AutoSize = true;
            PageItalic.Location = new Point(6, 54);
            PageItalic.Name = "PageItalic";
            PageItalic.Size = new Size(80, 24);
            PageItalic.TabIndex = 1;
            PageItalic.Text = "Курсив";
            PageItalic.UseVisualStyleBackColor = true;
            // 
            // PageBold
            // 
            PageBold.AutoSize = true;
            PageBold.Location = new Point(6, 24);
            PageBold.Name = "PageBold";
            PageBold.Size = new Size(124, 24);
            PageBold.TabIndex = 0;
            PageBold.Text = "Полужирный";
            PageBold.UseVisualStyleBackColor = true;
            // 
            // YearBox
            // 
            YearBox.Controls.Add(YearItalic);
            YearBox.Controls.Add(YearBold);
            YearBox.Location = new Point(284, 300);
            YearBox.Name = "YearBox";
            YearBox.Size = new Size(231, 92);
            YearBox.TabIndex = 10;
            YearBox.TabStop = false;
            YearBox.Text = "Год";
            // 
            // YearItalic
            // 
            YearItalic.AutoSize = true;
            YearItalic.Location = new Point(8, 56);
            YearItalic.Name = "YearItalic";
            YearItalic.Size = new Size(80, 24);
            YearItalic.TabIndex = 1;
            YearItalic.Text = "Курсив";
            YearItalic.UseVisualStyleBackColor = true;
            // 
            // YearBold
            // 
            YearBold.AutoSize = true;
            YearBold.Location = new Point(8, 26);
            YearBold.Name = "YearBold";
            YearBold.Size = new Size(124, 24);
            YearBold.TabIndex = 0;
            YearBold.Text = "Полужирный";
            YearBold.UseVisualStyleBackColor = true;
            // 
            // ThomeBox
            // 
            ThomeBox.Controls.Add(ThomeItalic);
            ThomeBox.Controls.Add(ThomeBold);
            ThomeBox.Location = new Point(285, 398);
            ThomeBox.Name = "ThomeBox";
            ThomeBox.Size = new Size(231, 94);
            ThomeBox.TabIndex = 11;
            ThomeBox.TabStop = false;
            ThomeBox.Text = "Том";
            // 
            // ThomeItalic
            // 
            ThomeItalic.AutoSize = true;
            ThomeItalic.Location = new Point(7, 57);
            ThomeItalic.Name = "ThomeItalic";
            ThomeItalic.Size = new Size(80, 24);
            ThomeItalic.TabIndex = 1;
            ThomeItalic.Text = "Курсив";
            ThomeItalic.UseVisualStyleBackColor = true;
            // 
            // ThomeBold
            // 
            ThomeBold.AutoSize = true;
            ThomeBold.Location = new Point(7, 26);
            ThomeBold.Name = "ThomeBold";
            ThomeBold.Size = new Size(124, 24);
            ThomeBold.TabIndex = 0;
            ThomeBold.Text = "Полужирный";
            ThomeBold.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 791);
            Controls.Add(ThomeBox);
            Controls.Add(YearBox);
            Controls.Add(PageBox);
            Controls.Add(DOIBox);
            Controls.Add(journalBox);
            Controls.Add(labelSuccess);
            Controls.Add(pictureBox1);
            Controls.Add(articleBox);
            Controls.Add(authorsBox);
            Controls.Add(DOIinput);
            Controls.Add(labelOutput);
            Controls.Add(DOIInputButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            authorsBox.ResumeLayout(false);
            authorsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AuthorsLimiter).EndInit();
            articleBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            journalBox.ResumeLayout(false);
            DOIBox.ResumeLayout(false);
            PageBox.ResumeLayout(false);
            PageBox.PerformLayout();
            YearBox.ResumeLayout(false);
            YearBox.PerformLayout();
            ThomeBox.ResumeLayout(false);
            ThomeBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DOIInputButton;
        private Label labelOutput;
        private TextBox DOIinput;
        private GroupBox authorsBox;
        private Label label2;
        private ComboBox AuthPosDropList;
        private ComboBox NameSepDropList;
        private Label label5;
        private CheckBox InitialsSpaceCheck;
        private CheckBox InitialsDotCheck;
        private Label label3;
        private ComboBox AuthSepDropList;
        private CheckBox AuthsLimitCheck;
        private CheckBox AndCheck;
        private Label label4;
        private NumericUpDown AuthorsLimiter;
        private GroupBox articleBox;
        private ComboBox ArticleNameDropList;
        private PictureBox pictureBox1;
        private Label labelSuccess;
        private GroupBox journalBox;
        private ComboBox JournalNameDropList;
        private GroupBox DOIBox;
        private ComboBox DOIDropList;
        private GroupBox PageBox;
        private GroupBox YearBox;
        private GroupBox ThomeBox;
        private CheckBox YearItalic;
        private CheckBox YearBold;
        private CheckBox ThomeItalic;
        private CheckBox ThomeBold;
        private CheckBox PageItalic;
        private CheckBox PageBold;
    }
}