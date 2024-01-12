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
            DOIinput = new TextBox();
            authorsBox = new GroupBox();
            AuthorsCheck = new CheckBox();
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
            TitleCheck = new CheckBox();
            ArticleNameDropList = new ComboBox();
            journalBox = new GroupBox();
            JournalTitleItalic = new CheckBox();
            JournalCheck = new CheckBox();
            checkDots = new CheckBox();
            JournalNameDropList = new ComboBox();
            DOIBox = new GroupBox();
            DOICheck = new CheckBox();
            DOIDropList = new ComboBox();
            PageBox = new GroupBox();
            checkOnePage = new CheckBox();
            PagesDivider = new ComboBox();
            PageCheck = new CheckBox();
            PageItalic = new CheckBox();
            PageBold = new CheckBox();
            YearBox = new GroupBox();
            YearBrackets = new CheckBox();
            YearCheck = new CheckBox();
            YearItalic = new CheckBox();
            YearBold = new CheckBox();
            ThomeBox = new GroupBox();
            ThomeCheck = new CheckBox();
            ThomeItalic = new CheckBox();
            ThomeBold = new CheckBox();
            richTextBox1 = new RichTextBox();
            Block1 = new ComboBox();
            Divider1 = new ComboBox();
            Block2 = new ComboBox();
            Divider2 = new ComboBox();
            Block3 = new ComboBox();
            Divider3 = new ComboBox();
            Block4 = new ComboBox();
            Divider4 = new ComboBox();
            Block5 = new ComboBox();
            Divider5 = new ComboBox();
            Block6 = new ComboBox();
            Divider6 = new ComboBox();
            Block7 = new ComboBox();
            End = new ComboBox();
            label1 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            Block8 = new ComboBox();
            Divider7 = new ComboBox();
            label15 = new Label();
            numberBox = new GroupBox();
            IssueCheck = new CheckBox();
            IssueItalic = new CheckBox();
            IssueBold = new CheckBox();
            IssueThomePart = new CheckBox();
            panel1 = new Panel();
            panelLabel = new Label();
            label17 = new Label();
            button1 = new Button();
            label16 = new Label();
            label18 = new Label();
            label19 = new Label();
            RepeatButton = new Button();
            authorsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AuthorsLimiter).BeginInit();
            articleBox.SuspendLayout();
            journalBox.SuspendLayout();
            DOIBox.SuspendLayout();
            PageBox.SuspendLayout();
            YearBox.SuspendLayout();
            ThomeBox.SuspendLayout();
            numberBox.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // DOIInputButton
            // 
            DOIInputButton.Location = new Point(14, 19);
            DOIInputButton.Margin = new Padding(3, 4, 3, 4);
            DOIInputButton.Name = "DOIInputButton";
            DOIInputButton.Size = new Size(89, 40);
            DOIInputButton.TabIndex = 0;
            DOIInputButton.Text = "Ввести";
            DOIInputButton.UseVisualStyleBackColor = true;
            DOIInputButton.Click += button1_Click;
            // 
            // DOIinput
            // 
            DOIinput.Location = new Point(110, 24);
            DOIinput.Margin = new Padding(3, 4, 3, 4);
            DOIinput.Name = "DOIinput";
            DOIinput.PlaceholderText = "https://doi.org/10.1070/RCR4987";
            DOIinput.Size = new Size(431, 27);
            DOIinput.TabIndex = 2;
            // 
            // authorsBox
            // 
            authorsBox.Controls.Add(AuthorsCheck);
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
            authorsBox.Size = new Size(269, 424);
            authorsBox.TabIndex = 3;
            authorsBox.TabStop = false;
            authorsBox.Text = "Авторы";
            // 
            // AuthorsCheck
            // 
            AuthorsCheck.AutoSize = true;
            AuthorsCheck.BackColor = SystemColors.ActiveCaption;
            AuthorsCheck.BackgroundImageLayout = ImageLayout.None;
            AuthorsCheck.Checked = true;
            AuthorsCheck.CheckState = CheckState.Checked;
            AuthorsCheck.Location = new Point(6, 0);
            AuthorsCheck.Name = "AuthorsCheck";
            AuthorsCheck.Size = new Size(84, 24);
            AuthorsCheck.TabIndex = 20;
            AuthorsCheck.Text = "Авторы";
            AuthorsCheck.UseVisualStyleBackColor = false;
            AuthorsCheck.CheckedChanged += AuthorsCheck_CheckedChanged;
            // 
            // AuthorsLimiter
            // 
            AuthorsLimiter.Enabled = false;
            AuthorsLimiter.Location = new Point(152, 377);
            AuthorsLimiter.Margin = new Padding(3, 4, 3, 4);
            AuthorsLimiter.Name = "AuthorsLimiter";
            AuthorsLimiter.Size = new Size(98, 27);
            AuthorsLimiter.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Location = new Point(7, 381);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 18;
            label4.Text = "Кол-во авторов";
            // 
            // AuthsLimitCheck
            // 
            AuthsLimitCheck.AutoSize = true;
            AuthsLimitCheck.Location = new Point(9, 196);
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
            AndCheck.Location = new Point(9, 141);
            AndCheck.Margin = new Padding(3, 4, 3, 4);
            AndCheck.Name = "AndCheck";
            AndCheck.Size = new Size(244, 44);
            AndCheck.TabIndex = 15;
            AndCheck.Text = "Союз “and” между последним \r\nи предпоследним";
            AndCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 315);
            label3.Name = "label3";
            label3.Size = new Size(126, 40);
            label3.TabIndex = 14;
            label3.Text = "Разделитель\r\nмежду авторами";
            // 
            // AuthSepDropList
            // 
            AuthSepDropList.FormattingEnabled = true;
            AuthSepDropList.Items.AddRange(new object[] { ",", ";" });
            AuthSepDropList.Location = new Point(152, 320);
            AuthSepDropList.Margin = new Padding(3, 4, 3, 4);
            AuthSepDropList.Name = "AuthSepDropList";
            AuthSepDropList.Size = new Size(98, 28);
            AuthSepDropList.TabIndex = 13;
            // 
            // InitialsSpaceCheck
            // 
            InitialsSpaceCheck.AutoSize = true;
            InitialsSpaceCheck.Location = new Point(9, 108);
            InitialsSpaceCheck.Margin = new Padding(3, 4, 3, 4);
            InitialsSpaceCheck.Name = "InitialsSpaceCheck";
            InitialsSpaceCheck.Size = new Size(227, 24);
            InitialsSpaceCheck.TabIndex = 12;
            InitialsSpaceCheck.Text = "Пробел между инициалами";
            InitialsSpaceCheck.UseVisualStyleBackColor = true;
            // 
            // InitialsDotCheck
            // 
            InitialsDotCheck.AutoSize = true;
            InitialsDotCheck.Location = new Point(9, 75);
            InitialsDotCheck.Margin = new Padding(3, 4, 3, 4);
            InitialsDotCheck.Name = "InitialsDotCheck";
            InitialsDotCheck.Size = new Size(198, 24);
            InitialsDotCheck.TabIndex = 11;
            InitialsDotCheck.Text = "Точка после инициалов";
            InitialsDotCheck.UseVisualStyleBackColor = true;
            // 
            // NameSepDropList
            // 
            NameSepDropList.FormattingEnabled = true;
            NameSepDropList.Items.AddRange(new object[] { "\"\"", "\" \"", "\",\"", "\", \"" });
            NameSepDropList.Location = new Point(152, 252);
            NameSepDropList.Margin = new Padding(3, 4, 3, 4);
            NameSepDropList.Name = "NameSepDropList";
            NameSepDropList.Size = new Size(98, 28);
            NameSepDropList.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 236);
            label5.Name = "label5";
            label5.Size = new Size(147, 60);
            label5.TabIndex = 9;
            label5.Text = "Разделитель\r\nмежду инициалами\r\nи фамилией";
            // 
            // AuthPosDropList
            // 
            AuthPosDropList.BackColor = SystemColors.Window;
            AuthPosDropList.DropDownStyle = ComboBoxStyle.DropDownList;
            AuthPosDropList.FormattingEnabled = true;
            AuthPosDropList.Items.AddRange(new object[] { "Инициалы/Фамилия", "Фамилия/Инициалы" });
            AuthPosDropList.Location = new Point(105, 32);
            AuthPosDropList.Margin = new Padding(3, 4, 3, 4);
            AuthPosDropList.Name = "AuthPosDropList";
            AuthPosDropList.Size = new Size(154, 28);
            AuthPosDropList.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 36);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 0;
            label2.Text = "Положение";
            // 
            // articleBox
            // 
            articleBox.Controls.Add(TitleCheck);
            articleBox.Controls.Add(ArticleNameDropList);
            articleBox.Location = new Point(289, 67);
            articleBox.Margin = new Padding(3, 4, 3, 4);
            articleBox.Name = "articleBox";
            articleBox.Padding = new Padding(3, 4, 3, 4);
            articleBox.Size = new Size(230, 69);
            articleBox.TabIndex = 4;
            articleBox.TabStop = false;
            articleBox.Text = "Название статьи";
            // 
            // TitleCheck
            // 
            TitleCheck.AutoSize = true;
            TitleCheck.BackColor = SystemColors.ActiveCaption;
            TitleCheck.Checked = true;
            TitleCheck.CheckState = CheckState.Checked;
            TitleCheck.Location = new Point(7, 0);
            TitleCheck.Name = "TitleCheck";
            TitleCheck.Size = new Size(147, 24);
            TitleCheck.TabIndex = 1;
            TitleCheck.Text = "Название статьи";
            TitleCheck.UseVisualStyleBackColor = false;
            TitleCheck.CheckedChanged += TitleCheck_CheckedChanged;
            // 
            // ArticleNameDropList
            // 
            ArticleNameDropList.DropDownStyle = ComboBoxStyle.DropDownList;
            ArticleNameDropList.FormattingEnabled = true;
            ArticleNameDropList.Items.AddRange(new object[] { "Название в нижнем регистре", "Название с заглавными буквами" });
            ArticleNameDropList.Location = new Point(7, 28);
            ArticleNameDropList.Margin = new Padding(3, 4, 3, 4);
            ArticleNameDropList.Name = "ArticleNameDropList";
            ArticleNameDropList.Size = new Size(215, 28);
            ArticleNameDropList.TabIndex = 0;
            // 
            // journalBox
            // 
            journalBox.Controls.Add(JournalTitleItalic);
            journalBox.Controls.Add(JournalCheck);
            journalBox.Controls.Add(checkDots);
            journalBox.Controls.Add(JournalNameDropList);
            journalBox.Location = new Point(288, 156);
            journalBox.Name = "journalBox";
            journalBox.Size = new Size(230, 126);
            journalBox.TabIndex = 7;
            journalBox.TabStop = false;
            journalBox.Text = "Название журнала";
            // 
            // JournalTitleItalic
            // 
            JournalTitleItalic.AutoSize = true;
            JournalTitleItalic.Location = new Point(7, 92);
            JournalTitleItalic.Name = "JournalTitleItalic";
            JournalTitleItalic.Size = new Size(80, 24);
            JournalTitleItalic.TabIndex = 4;
            JournalTitleItalic.Text = "Курсив";
            JournalTitleItalic.UseVisualStyleBackColor = true;
            // 
            // JournalCheck
            // 
            JournalCheck.AutoSize = true;
            JournalCheck.BackColor = SystemColors.ActiveCaption;
            JournalCheck.Checked = true;
            JournalCheck.CheckState = CheckState.Checked;
            JournalCheck.Location = new Point(7, -1);
            JournalCheck.Name = "JournalCheck";
            JournalCheck.Size = new Size(163, 24);
            JournalCheck.TabIndex = 3;
            JournalCheck.Text = "Название журнала";
            JournalCheck.UseVisualStyleBackColor = false;
            JournalCheck.CheckedChanged += JournalCheck_CheckedChanged;
            // 
            // checkDots
            // 
            checkDots.AutoSize = true;
            checkDots.Location = new Point(7, 63);
            checkDots.Name = "checkDots";
            checkDots.Size = new Size(97, 24);
            checkDots.TabIndex = 2;
            checkDots.Text = "Без точек";
            checkDots.UseVisualStyleBackColor = true;
            // 
            // JournalNameDropList
            // 
            JournalNameDropList.DropDownStyle = ComboBoxStyle.DropDownList;
            JournalNameDropList.FormattingEnabled = true;
            JournalNameDropList.Items.AddRange(new object[] { "Полное", "Аббревиатура" });
            JournalNameDropList.Location = new Point(7, 27);
            JournalNameDropList.Name = "JournalNameDropList";
            JournalNameDropList.Size = new Size(215, 28);
            JournalNameDropList.TabIndex = 0;
            // 
            // DOIBox
            // 
            DOIBox.Controls.Add(DOICheck);
            DOIBox.Controls.Add(DOIDropList);
            DOIBox.Location = new Point(287, 288);
            DOIBox.Name = "DOIBox";
            DOIBox.Size = new Size(231, 72);
            DOIBox.TabIndex = 8;
            DOIBox.TabStop = false;
            DOIBox.Text = "DOI";
            // 
            // DOICheck
            // 
            DOICheck.AutoSize = true;
            DOICheck.BackColor = SystemColors.ActiveCaption;
            DOICheck.Checked = true;
            DOICheck.CheckState = CheckState.Checked;
            DOICheck.Location = new Point(7, 3);
            DOICheck.Name = "DOICheck";
            DOICheck.Size = new Size(57, 24);
            DOICheck.TabIndex = 1;
            DOICheck.Text = "DOI";
            DOICheck.UseVisualStyleBackColor = false;
            DOICheck.CheckedChanged += DOICheck_CheckedChanged;
            // 
            // DOIDropList
            // 
            DOIDropList.DropDownStyle = ComboBoxStyle.DropDownList;
            DOIDropList.FormattingEnabled = true;
            DOIDropList.Items.AddRange(new object[] { "Сокращенное", "Как url-ссылка" });
            DOIDropList.Location = new Point(7, 31);
            DOIDropList.Name = "DOIDropList";
            DOIDropList.Size = new Size(215, 28);
            DOIDropList.TabIndex = 0;
            // 
            // PageBox
            // 
            PageBox.Controls.Add(checkOnePage);
            PageBox.Controls.Add(PagesDivider);
            PageBox.Controls.Add(PageCheck);
            PageBox.Controls.Add(PageItalic);
            PageBox.Controls.Add(PageBold);
            PageBox.Location = new Point(526, 319);
            PageBox.Name = "PageBox";
            PageBox.Size = new Size(194, 161);
            PageBox.TabIndex = 9;
            PageBox.TabStop = false;
            PageBox.Text = "Страницы";
            // 
            // checkOnePage
            // 
            checkOnePage.AutoSize = true;
            checkOnePage.Location = new Point(7, 89);
            checkOnePage.Name = "checkOnePage";
            checkOnePage.Size = new Size(136, 24);
            checkOnePage.TabIndex = 4;
            checkOnePage.Text = "Одна страница";
            checkOnePage.UseVisualStyleBackColor = true;
            // 
            // PagesDivider
            // 
            PagesDivider.DropDownStyle = ComboBoxStyle.DropDownList;
            PagesDivider.FormattingEnabled = true;
            PagesDivider.Items.AddRange(new object[] { "Через тире", "Через дефис" });
            PagesDivider.Location = new Point(6, 124);
            PagesDivider.Name = "PagesDivider";
            PagesDivider.Size = new Size(180, 28);
            PagesDivider.TabIndex = 3;
            // 
            // PageCheck
            // 
            PageCheck.AutoSize = true;
            PageCheck.BackColor = SystemColors.ActiveCaption;
            PageCheck.Checked = true;
            PageCheck.CheckState = CheckState.Checked;
            PageCheck.Location = new Point(6, 0);
            PageCheck.Name = "PageCheck";
            PageCheck.Size = new Size(181, 24);
            PageCheck.TabIndex = 2;
            PageCheck.Text = "Страницы или номер";
            PageCheck.UseVisualStyleBackColor = false;
            PageCheck.CheckedChanged += PageCheck_CheckedChanged;
            // 
            // PageItalic
            // 
            PageItalic.AutoSize = true;
            PageItalic.Location = new Point(7, 59);
            PageItalic.Name = "PageItalic";
            PageItalic.Size = new Size(80, 24);
            PageItalic.TabIndex = 1;
            PageItalic.Text = "Курсив";
            PageItalic.UseVisualStyleBackColor = true;
            // 
            // PageBold
            // 
            PageBold.AutoSize = true;
            PageBold.Location = new Point(6, 29);
            PageBold.Name = "PageBold";
            PageBold.Size = new Size(124, 24);
            PageBold.TabIndex = 0;
            PageBold.Text = "Полужирный";
            PageBold.UseVisualStyleBackColor = true;
            // 
            // YearBox
            // 
            YearBox.Controls.Add(YearBrackets);
            YearBox.Controls.Add(YearCheck);
            YearBox.Controls.Add(YearItalic);
            YearBox.Controls.Add(YearBold);
            YearBox.Location = new Point(287, 366);
            YearBox.Name = "YearBox";
            YearBox.Size = new Size(231, 125);
            YearBox.TabIndex = 10;
            YearBox.TabStop = false;
            YearBox.Text = "Год";
            // 
            // YearBrackets
            // 
            YearBrackets.AutoSize = true;
            YearBrackets.Location = new Point(8, 88);
            YearBrackets.Name = "YearBrackets";
            YearBrackets.Size = new Size(98, 24);
            YearBrackets.TabIndex = 3;
            YearBrackets.Text = "В скобках";
            YearBrackets.UseVisualStyleBackColor = true;
            // 
            // YearCheck
            // 
            YearCheck.AutoSize = true;
            YearCheck.BackColor = SystemColors.ActiveCaption;
            YearCheck.Checked = true;
            YearCheck.CheckState = CheckState.Checked;
            YearCheck.Location = new Point(8, 0);
            YearCheck.Name = "YearCheck";
            YearCheck.Size = new Size(55, 24);
            YearCheck.TabIndex = 2;
            YearCheck.Text = "Год";
            YearCheck.UseVisualStyleBackColor = false;
            YearCheck.CheckedChanged += YearCheck_CheckedChanged;
            // 
            // YearItalic
            // 
            YearItalic.AutoSize = true;
            YearItalic.Location = new Point(8, 59);
            YearItalic.Name = "YearItalic";
            YearItalic.Size = new Size(80, 24);
            YearItalic.TabIndex = 1;
            YearItalic.Text = "Курсив";
            YearItalic.UseVisualStyleBackColor = true;
            // 
            // YearBold
            // 
            YearBold.AutoSize = true;
            YearBold.Location = new Point(8, 29);
            YearBold.Name = "YearBold";
            YearBold.Size = new Size(124, 24);
            YearBold.TabIndex = 0;
            YearBold.Text = "Полужирный";
            YearBold.UseVisualStyleBackColor = true;
            // 
            // ThomeBox
            // 
            ThomeBox.Controls.Add(ThomeCheck);
            ThomeBox.Controls.Add(ThomeItalic);
            ThomeBox.Controls.Add(ThomeBold);
            ThomeBox.Location = new Point(526, 67);
            ThomeBox.Name = "ThomeBox";
            ThomeBox.Size = new Size(194, 93);
            ThomeBox.TabIndex = 11;
            ThomeBox.TabStop = false;
            ThomeBox.Text = "Том";
            // 
            // ThomeCheck
            // 
            ThomeCheck.AutoSize = true;
            ThomeCheck.BackColor = SystemColors.ActiveCaption;
            ThomeCheck.Checked = true;
            ThomeCheck.CheckState = CheckState.Checked;
            ThomeCheck.Location = new Point(7, 0);
            ThomeCheck.Name = "ThomeCheck";
            ThomeCheck.Size = new Size(59, 24);
            ThomeCheck.TabIndex = 2;
            ThomeCheck.Text = "Том";
            ThomeCheck.UseVisualStyleBackColor = false;
            ThomeCheck.CheckedChanged += ThomeCheck_CheckedChanged;
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
            ThomeBold.Location = new Point(7, 27);
            ThomeBold.Name = "ThomeBold";
            ThomeBold.Size = new Size(124, 24);
            ThomeBold.TabIndex = 0;
            ThomeBold.Text = "Полужирный";
            ThomeBold.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Location = new Point(14, 543);
            richTextBox1.MinimumSize = new Size(342, 25);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1558, 100);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            // 
            // Block1
            // 
            Block1.FormattingEnabled = true;
            Block1.Location = new Point(766, 119);
            Block1.Name = "Block1";
            Block1.Size = new Size(185, 28);
            Block1.TabIndex = 13;
            // 
            // Divider1
            // 
            Divider1.BackColor = Color.LightYellow;
            Divider1.ForeColor = SystemColors.ActiveCaptionText;
            Divider1.FormattingEnabled = true;
            Divider1.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider1.Location = new Point(970, 119);
            Divider1.Name = "Divider1";
            Divider1.Size = new Size(151, 28);
            Divider1.TabIndex = 14;
            // 
            // Block2
            // 
            Block2.FormattingEnabled = true;
            Block2.Location = new Point(766, 153);
            Block2.Name = "Block2";
            Block2.Size = new Size(185, 28);
            Block2.TabIndex = 15;
            // 
            // Divider2
            // 
            Divider2.BackColor = Color.LightYellow;
            Divider2.FormattingEnabled = true;
            Divider2.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider2.Location = new Point(970, 153);
            Divider2.Name = "Divider2";
            Divider2.Size = new Size(151, 28);
            Divider2.TabIndex = 16;
            // 
            // Block3
            // 
            Block3.FormattingEnabled = true;
            Block3.Location = new Point(766, 187);
            Block3.Name = "Block3";
            Block3.Size = new Size(185, 28);
            Block3.TabIndex = 17;
            // 
            // Divider3
            // 
            Divider3.BackColor = Color.LightYellow;
            Divider3.FormattingEnabled = true;
            Divider3.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider3.Location = new Point(970, 187);
            Divider3.Name = "Divider3";
            Divider3.Size = new Size(151, 28);
            Divider3.TabIndex = 18;
            // 
            // Block4
            // 
            Block4.FormattingEnabled = true;
            Block4.Location = new Point(766, 221);
            Block4.Name = "Block4";
            Block4.Size = new Size(185, 28);
            Block4.TabIndex = 19;
            // 
            // Divider4
            // 
            Divider4.BackColor = Color.LightYellow;
            Divider4.FormattingEnabled = true;
            Divider4.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider4.Location = new Point(970, 221);
            Divider4.Name = "Divider4";
            Divider4.Size = new Size(151, 28);
            Divider4.TabIndex = 20;
            // 
            // Block5
            // 
            Block5.FormattingEnabled = true;
            Block5.Location = new Point(766, 255);
            Block5.Name = "Block5";
            Block5.Size = new Size(185, 28);
            Block5.TabIndex = 21;
            // 
            // Divider5
            // 
            Divider5.BackColor = Color.LightYellow;
            Divider5.FormattingEnabled = true;
            Divider5.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider5.Location = new Point(970, 255);
            Divider5.Name = "Divider5";
            Divider5.Size = new Size(151, 28);
            Divider5.TabIndex = 22;
            // 
            // Block6
            // 
            Block6.FormattingEnabled = true;
            Block6.Location = new Point(766, 289);
            Block6.Name = "Block6";
            Block6.Size = new Size(185, 28);
            Block6.TabIndex = 23;
            // 
            // Divider6
            // 
            Divider6.BackColor = Color.LightYellow;
            Divider6.FormattingEnabled = true;
            Divider6.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider6.Location = new Point(970, 289);
            Divider6.Name = "Divider6";
            Divider6.Size = new Size(151, 28);
            Divider6.TabIndex = 24;
            // 
            // Block7
            // 
            Block7.FormattingEnabled = true;
            Block7.Location = new Point(766, 323);
            Block7.Name = "Block7";
            Block7.Size = new Size(185, 28);
            Block7.TabIndex = 25;
            // 
            // End
            // 
            End.BackColor = Color.LightCoral;
            End.FormattingEnabled = true;
            End.Items.AddRange(new object[] { "Отсутствует", ".", ";" });
            End.Location = new Point(864, 437);
            End.Name = "End";
            End.Size = new Size(151, 28);
            End.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(766, 81);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 27;
            label1.Text = "Блоки";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(997, 81);
            label6.Name = "label6";
            label6.Size = new Size(96, 20);
            label6.TabIndex = 28;
            label6.Text = "Разделители";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(869, 400);
            label7.Name = "label7";
            label7.Size = new Size(143, 20);
            label7.TabIndex = 29;
            label7.Text = "Символ окончания";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(743, 123);
            label8.Name = "label8";
            label8.Size = new Size(17, 20);
            label8.TabIndex = 30;
            label8.Text = "1";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(743, 156);
            label9.Name = "label9";
            label9.Size = new Size(17, 20);
            label9.TabIndex = 31;
            label9.Text = "2";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(743, 191);
            label10.Name = "label10";
            label10.Size = new Size(17, 20);
            label10.TabIndex = 32;
            label10.Text = "3";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(743, 224);
            label11.Name = "label11";
            label11.Size = new Size(17, 20);
            label11.TabIndex = 33;
            label11.Text = "4";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(743, 259);
            label12.Name = "label12";
            label12.Size = new Size(17, 20);
            label12.TabIndex = 34;
            label12.Text = "5";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(743, 292);
            label13.Name = "label13";
            label13.Size = new Size(17, 20);
            label13.TabIndex = 35;
            label13.Text = "6";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(743, 325);
            label14.Name = "label14";
            label14.Size = new Size(17, 20);
            label14.TabIndex = 36;
            label14.Text = "7";
            // 
            // Block8
            // 
            Block8.FormattingEnabled = true;
            Block8.Location = new Point(766, 357);
            Block8.Name = "Block8";
            Block8.Size = new Size(185, 28);
            Block8.TabIndex = 37;
            // 
            // Divider7
            // 
            Divider7.BackColor = Color.LightYellow;
            Divider7.FormattingEnabled = true;
            Divider7.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider7.Location = new Point(970, 323);
            Divider7.Name = "Divider7";
            Divider7.Size = new Size(151, 28);
            Divider7.TabIndex = 38;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(743, 360);
            label15.Name = "label15";
            label15.Size = new Size(17, 20);
            label15.TabIndex = 39;
            label15.Text = "8";
            // 
            // numberBox
            // 
            numberBox.Controls.Add(IssueCheck);
            numberBox.Controls.Add(IssueItalic);
            numberBox.Controls.Add(IssueBold);
            numberBox.Controls.Add(IssueThomePart);
            numberBox.Location = new Point(526, 168);
            numberBox.Name = "numberBox";
            numberBox.Size = new Size(194, 141);
            numberBox.TabIndex = 40;
            numberBox.TabStop = false;
            numberBox.Text = "Номер";
            // 
            // IssueCheck
            // 
            IssueCheck.AutoSize = true;
            IssueCheck.BackColor = SystemColors.ActiveCaption;
            IssueCheck.Checked = true;
            IssueCheck.CheckState = CheckState.Checked;
            IssueCheck.Location = new Point(6, 0);
            IssueCheck.Name = "IssueCheck";
            IssueCheck.Size = new Size(91, 24);
            IssueCheck.TabIndex = 3;
            IssueCheck.Text = "Издание";
            IssueCheck.UseVisualStyleBackColor = false;
            IssueCheck.CheckedChanged += IssueCheck_CheckedChanged;
            // 
            // IssueItalic
            // 
            IssueItalic.AutoSize = true;
            IssueItalic.Location = new Point(6, 108);
            IssueItalic.Name = "IssueItalic";
            IssueItalic.Size = new Size(80, 24);
            IssueItalic.TabIndex = 2;
            IssueItalic.Text = "Курсив";
            IssueItalic.UseVisualStyleBackColor = true;
            // 
            // IssueBold
            // 
            IssueBold.AutoSize = true;
            IssueBold.Location = new Point(6, 75);
            IssueBold.Name = "IssueBold";
            IssueBold.Size = new Size(124, 24);
            IssueBold.TabIndex = 1;
            IssueBold.Text = "Полужирный";
            IssueBold.UseVisualStyleBackColor = true;
            // 
            // IssueThomePart
            // 
            IssueThomePart.AutoSize = true;
            IssueThomePart.Location = new Point(6, 27);
            IssueThomePart.Name = "IssueThomePart";
            IssueThomePart.Size = new Size(139, 44);
            IssueThomePart.TabIndex = 0;
            IssueThomePart.Text = "Сделать частью\r\nблока \"Том\"";
            IssueThomePart.UseVisualStyleBackColor = true;
            IssueThomePart.CheckedChanged += NumberThomePart_CheckedChanged;
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.BackColor = SystemColors.ControlLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panelLabel);
            panel1.Location = new Point(1163, 101);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(409, 347);
            panel1.TabIndex = 41;
            panel1.Click += panel1_Click;
            panel1.DragDrop += panel1_DragDrop;
            panel1.DragEnter += panel1_DragEnter;
            panel1.DragLeave += panel1_DragLeave;
            // 
            // panelLabel
            // 
            panelLabel.Location = new Point(-1, 0);
            panelLabel.Name = "panelLabel";
            panelLabel.Size = new Size(409, 347);
            panelLabel.TabIndex = 0;
            panelLabel.Text = "Нажмите, чтобы выбрать файл(ы) \r\nили перетащите в это поле";
            panelLabel.TextAlign = ContentAlignment.MiddleCenter;
            panelLabel.Click += panelLabel_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(1162, 29);
            label17.Name = "label17";
            label17.Size = new Size(155, 23);
            label17.TabIndex = 0;
            label17.Text = "Выбор файла(ов)";
            // 
            // button1
            // 
            button1.Location = new Point(1163, 469);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(128, 55);
            button1.TabIndex = 1;
            button1.Text = "Выбрать файл(ы)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(1163, 65);
            label16.Name = "label16";
            label16.Size = new Size(253, 20);
            label16.TabIndex = 42;
            label16.Text = "Поддерживаемый формат файлов:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(1415, 65);
            label18.Name = "label18";
            label18.Size = new Size(74, 20);
            label18.TabIndex = 43;
            label18.Text = ".txt .docx";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label19.Location = new Point(14, 504);
            label19.Name = "label19";
            label19.Size = new Size(66, 23);
            label19.TabIndex = 44;
            label19.Text = "Вывод";
            // 
            // RepeatButton
            // 
            RepeatButton.Location = new Point(1313, 469);
            RepeatButton.Name = "RepeatButton";
            RepeatButton.Size = new Size(128, 55);
            RepeatButton.TabIndex = 45;
            RepeatButton.Text = "Обновить ссылки";
            RepeatButton.UseVisualStyleBackColor = true;
            RepeatButton.Click += RepeatButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1613, 653);
            Controls.Add(RepeatButton);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label16);
            Controls.Add(button1);
            Controls.Add(label17);
            Controls.Add(panel1);
            Controls.Add(numberBox);
            Controls.Add(label15);
            Controls.Add(Divider7);
            Controls.Add(Block8);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(End);
            Controls.Add(Block7);
            Controls.Add(Divider6);
            Controls.Add(Block6);
            Controls.Add(Divider5);
            Controls.Add(Block5);
            Controls.Add(Divider4);
            Controls.Add(Block4);
            Controls.Add(Divider3);
            Controls.Add(Block3);
            Controls.Add(Divider2);
            Controls.Add(Block2);
            Controls.Add(Divider1);
            Controls.Add(Block1);
            Controls.Add(richTextBox1);
            Controls.Add(ThomeBox);
            Controls.Add(YearBox);
            Controls.Add(PageBox);
            Controls.Add(DOIBox);
            Controls.Add(journalBox);
            Controls.Add(articleBox);
            Controls.Add(authorsBox);
            Controls.Add(DOIinput);
            Controls.Add(DOIInputButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Chimica Techno Acta reference manager";
            authorsBox.ResumeLayout(false);
            authorsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AuthorsLimiter).EndInit();
            articleBox.ResumeLayout(false);
            articleBox.PerformLayout();
            journalBox.ResumeLayout(false);
            journalBox.PerformLayout();
            DOIBox.ResumeLayout(false);
            DOIBox.PerformLayout();
            PageBox.ResumeLayout(false);
            PageBox.PerformLayout();
            YearBox.ResumeLayout(false);
            YearBox.PerformLayout();
            ThomeBox.ResumeLayout(false);
            ThomeBox.PerformLayout();
            numberBox.ResumeLayout(false);
            numberBox.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DOIInputButton;
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
        private RichTextBox richTextBox1;
        private ComboBox Block1;
        private ComboBox Divider1;
        private ComboBox Block2;
        private ComboBox Divider2;
        private ComboBox Block3;
        private ComboBox Divider3;
        private ComboBox Block4;
        private ComboBox Divider4;
        private ComboBox Block5;
        private ComboBox Divider5;
        private ComboBox Block6;
        private ComboBox Divider6;
        private ComboBox Block7;
        private ComboBox End;
        private Label label1;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private CheckBox checkDots;
        private ComboBox Block8;
        private ComboBox Divider7;
        private Label label15;
        private GroupBox numberBox;
        private CheckBox IssueItalic;
        private CheckBox IssueBold;
        private CheckBox IssueThomePart;
        private CheckBox AuthorsCheck;
        private CheckBox TitleCheck;
        private CheckBox JournalCheck;
        private CheckBox DOICheck;
        private CheckBox YearCheck;
        private CheckBox ThomeCheck;
        private CheckBox PageCheck;
        private CheckBox IssueCheck;
        private CheckBox YearBrackets;
        private ComboBox PagesDivider;
        private Panel panel1;
        private Label panelLabel;
        private Label label17;
        private Button button1;
        private Button RepeatButton;
        private Label label16;
        private Label label18;
        private Label label19;
        private CheckBox checkOnePage;
        private CheckBox JournalTitleItalic;
    }
}