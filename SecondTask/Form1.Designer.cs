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
            AuthorsNumber = new Label();
            AuthsLimitCheck = new CheckBox();
            AndCheck = new CheckBox();
            AuthorsDividingAuthors = new Label();
            AuthSepDropList = new ComboBox();
            InitialsSpaceCheck = new CheckBox();
            InitialsDotCheck = new CheckBox();
            NameSepDropList = new ComboBox();
            AuthorsDividingInitialsSurname = new Label();
            AuthPosDropList = new ComboBox();
            AuthorsPosition = new Label();
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
            PageOnePage = new CheckBox();
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
            BlockLabel = new Label();
            DividingLabel = new Label();
            EndingLabel = new Label();
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
            IssueBox = new GroupBox();
            IssueCheck = new CheckBox();
            IssueItalic = new CheckBox();
            IssueBold = new CheckBox();
            IssueThomePart = new CheckBox();
            panel1 = new Panel();
            panelLabel = new Label();
            FileSelection = new Label();
            ChooseFileButton = new Button();
            SupportedFiles = new Label();
            SupportedFormats = new Label();
            Output = new Label();
            RepeatButton = new Button();
            ButtonChangeLang = new Button();
            authorsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AuthorsLimiter).BeginInit();
            articleBox.SuspendLayout();
            journalBox.SuspendLayout();
            DOIBox.SuspendLayout();
            PageBox.SuspendLayout();
            YearBox.SuspendLayout();
            ThomeBox.SuspendLayout();
            IssueBox.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // DOIInputButton
            // 
            DOIInputButton.Location = new Point(12, 14);
            DOIInputButton.Name = "DOIInputButton";
            DOIInputButton.Size = new Size(78, 30);
            DOIInputButton.TabIndex = 0;
            DOIInputButton.Text = "Ввести";
            DOIInputButton.UseVisualStyleBackColor = true;
            DOIInputButton.Click += button1_Click;
            // 
            // DOIinput
            // 
            DOIinput.Location = new Point(96, 18);
            DOIinput.Name = "DOIinput";
            DOIinput.PlaceholderText = "https://doi.org/10.1070/RCR4987";
            DOIinput.Size = new Size(378, 23);
            DOIinput.TabIndex = 2;
            // 
            // authorsBox
            // 
            authorsBox.Controls.Add(AuthorsCheck);
            authorsBox.Controls.Add(AuthorsLimiter);
            authorsBox.Controls.Add(AuthorsNumber);
            authorsBox.Controls.Add(AuthsLimitCheck);
            authorsBox.Controls.Add(AndCheck);
            authorsBox.Controls.Add(AuthorsDividingAuthors);
            authorsBox.Controls.Add(AuthSepDropList);
            authorsBox.Controls.Add(InitialsSpaceCheck);
            authorsBox.Controls.Add(InitialsDotCheck);
            authorsBox.Controls.Add(NameSepDropList);
            authorsBox.Controls.Add(AuthorsDividingInitialsSurname);
            authorsBox.Controls.Add(AuthPosDropList);
            authorsBox.Controls.Add(AuthorsPosition);
            authorsBox.Location = new Point(12, 50);
            authorsBox.Name = "authorsBox";
            authorsBox.Size = new Size(235, 318);
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
            AuthorsCheck.Location = new Point(5, 0);
            AuthorsCheck.Margin = new Padding(3, 2, 3, 2);
            AuthorsCheck.Name = "AuthorsCheck";
            AuthorsCheck.Size = new Size(68, 19);
            AuthorsCheck.TabIndex = 20;
            AuthorsCheck.Text = "Авторы";
            AuthorsCheck.UseVisualStyleBackColor = false;
            AuthorsCheck.CheckedChanged += AuthorsCheck_CheckedChanged;
            // 
            // AuthorsLimiter
            // 
            AuthorsLimiter.Enabled = false;
            AuthorsLimiter.Location = new Point(133, 283);
            AuthorsLimiter.Name = "AuthorsLimiter";
            AuthorsLimiter.Size = new Size(86, 23);
            AuthorsLimiter.TabIndex = 19;
            // 
            // AuthorsNumber
            // 
            AuthorsNumber.AutoSize = true;
            AuthorsNumber.Enabled = false;
            AuthorsNumber.Location = new Point(6, 286);
            AuthorsNumber.Name = "AuthorsNumber";
            AuthorsNumber.Size = new Size(93, 15);
            AuthorsNumber.TabIndex = 18;
            AuthorsNumber.Text = "Кол-во авторов";
            // 
            // AuthsLimitCheck
            // 
            AuthsLimitCheck.AutoSize = true;
            AuthsLimitCheck.Location = new Point(8, 149);
            AuthsLimitCheck.Name = "AuthsLimitCheck";
            AuthsLimitCheck.Size = new Size(61, 19);
            AuthsLimitCheck.TabIndex = 16;
            AuthsLimitCheck.Text = "“et al.”";
            AuthsLimitCheck.UseVisualStyleBackColor = true;
            AuthsLimitCheck.Click += AuthsLimitCheck_Click;
            // 
            // AndCheck
            // 
            AndCheck.AutoSize = true;
            AndCheck.Location = new Point(8, 108);
            AndCheck.Name = "AndCheck";
            AndCheck.Size = new Size(196, 34);
            AndCheck.TabIndex = 15;
            AndCheck.Text = "Союз “and” между последним \r\nи предпоследним";
            AndCheck.UseVisualStyleBackColor = true;
            // 
            // AuthorsDividingAuthors
            // 
            AuthorsDividingAuthors.AutoSize = true;
            AuthorsDividingAuthors.Location = new Point(6, 236);
            AuthorsDividingAuthors.Name = "AuthorsDividingAuthors";
            AuthorsDividingAuthors.Size = new Size(99, 30);
            AuthorsDividingAuthors.TabIndex = 14;
            AuthorsDividingAuthors.Text = "Разделитель\r\nмежду авторами";
            // 
            // AuthSepDropList
            // 
            AuthSepDropList.FormattingEnabled = true;
            AuthSepDropList.Items.AddRange(new object[] { ",", ";" });
            AuthSepDropList.Location = new Point(133, 240);
            AuthSepDropList.Name = "AuthSepDropList";
            AuthSepDropList.Size = new Size(86, 23);
            AuthSepDropList.TabIndex = 13;
            // 
            // InitialsSpaceCheck
            // 
            InitialsSpaceCheck.AutoSize = true;
            InitialsSpaceCheck.Location = new Point(8, 83);
            InitialsSpaceCheck.Name = "InitialsSpaceCheck";
            InitialsSpaceCheck.Size = new Size(181, 19);
            InitialsSpaceCheck.TabIndex = 12;
            InitialsSpaceCheck.Text = "Пробел между инициалами";
            InitialsSpaceCheck.UseVisualStyleBackColor = true;
            // 
            // InitialsDotCheck
            // 
            InitialsDotCheck.AutoSize = true;
            InitialsDotCheck.Location = new Point(8, 58);
            InitialsDotCheck.Name = "InitialsDotCheck";
            InitialsDotCheck.Size = new Size(158, 19);
            InitialsDotCheck.TabIndex = 11;
            InitialsDotCheck.Text = "Точка после инициалов";
            InitialsDotCheck.UseVisualStyleBackColor = true;
            // 
            // NameSepDropList
            // 
            NameSepDropList.FormattingEnabled = true;
            NameSepDropList.Items.AddRange(new object[] { "\"\"", "\" \"", "\",\"", "\", \"" });
            NameSepDropList.Location = new Point(133, 189);
            NameSepDropList.Name = "NameSepDropList";
            NameSepDropList.Size = new Size(86, 23);
            NameSepDropList.TabIndex = 10;
            // 
            // AuthorsDividingInitialsSurname
            // 
            AuthorsDividingInitialsSurname.AutoSize = true;
            AuthorsDividingInitialsSurname.Location = new Point(6, 177);
            AuthorsDividingInitialsSurname.Name = "AuthorsDividingInitialsSurname";
            AuthorsDividingInitialsSurname.Size = new Size(116, 45);
            AuthorsDividingInitialsSurname.TabIndex = 9;
            AuthorsDividingInitialsSurname.Text = "Разделитель\r\nмежду инициалами\r\nи фамилией";
            // 
            // AuthPosDropList
            // 
            AuthPosDropList.BackColor = SystemColors.Window;
            AuthPosDropList.DropDownStyle = ComboBoxStyle.DropDownList;
            AuthPosDropList.FormattingEnabled = true;
            AuthPosDropList.Items.AddRange(new object[] { "Инициалы/Фамилия", "Фамилия/Инициалы" });
            AuthPosDropList.Location = new Point(84, 24);
            AuthPosDropList.Name = "AuthPosDropList";
            AuthPosDropList.Size = new Size(145, 23);
            AuthPosDropList.TabIndex = 5;
            // 
            // AuthorsPosition
            // 
            AuthorsPosition.AutoSize = true;
            AuthorsPosition.Location = new Point(6, 27);
            AuthorsPosition.Name = "AuthorsPosition";
            AuthorsPosition.Size = new Size(72, 15);
            AuthorsPosition.TabIndex = 0;
            AuthorsPosition.Text = "Положение";
            // 
            // articleBox
            // 
            articleBox.Controls.Add(TitleCheck);
            articleBox.Controls.Add(ArticleNameDropList);
            articleBox.Location = new Point(256, 50);
            articleBox.Name = "articleBox";
            articleBox.Size = new Size(213, 52);
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
            TitleCheck.Location = new Point(6, 0);
            TitleCheck.Margin = new Padding(3, 2, 3, 2);
            TitleCheck.Name = "TitleCheck";
            TitleCheck.Size = new Size(116, 19);
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
            ArticleNameDropList.Location = new Point(6, 21);
            ArticleNameDropList.Name = "ArticleNameDropList";
            ArticleNameDropList.Size = new Size(201, 23);
            ArticleNameDropList.TabIndex = 0;
            // 
            // journalBox
            // 
            journalBox.Controls.Add(JournalTitleItalic);
            journalBox.Controls.Add(JournalCheck);
            journalBox.Controls.Add(checkDots);
            journalBox.Controls.Add(JournalNameDropList);
            journalBox.Location = new Point(255, 117);
            journalBox.Margin = new Padding(3, 2, 3, 2);
            journalBox.Name = "journalBox";
            journalBox.Padding = new Padding(3, 2, 3, 2);
            journalBox.Size = new Size(214, 94);
            journalBox.TabIndex = 7;
            journalBox.TabStop = false;
            journalBox.Text = "Название журнала";
            // 
            // JournalTitleItalic
            // 
            JournalTitleItalic.AutoSize = true;
            JournalTitleItalic.Location = new Point(6, 69);
            JournalTitleItalic.Margin = new Padding(3, 2, 3, 2);
            JournalTitleItalic.Name = "JournalTitleItalic";
            JournalTitleItalic.Size = new Size(65, 19);
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
            JournalCheck.Location = new Point(6, -1);
            JournalCheck.Margin = new Padding(3, 2, 3, 2);
            JournalCheck.Name = "JournalCheck";
            JournalCheck.Size = new Size(129, 19);
            JournalCheck.TabIndex = 3;
            JournalCheck.Text = "Название журнала";
            JournalCheck.UseVisualStyleBackColor = false;
            JournalCheck.CheckedChanged += JournalCheck_CheckedChanged;
            // 
            // checkDots
            // 
            checkDots.AutoSize = true;
            checkDots.Location = new Point(6, 47);
            checkDots.Margin = new Padding(3, 2, 3, 2);
            checkDots.Name = "checkDots";
            checkDots.Size = new Size(78, 19);
            checkDots.TabIndex = 2;
            checkDots.Text = "Без точек";
            checkDots.UseVisualStyleBackColor = true;
            // 
            // JournalNameDropList
            // 
            JournalNameDropList.DropDownStyle = ComboBoxStyle.DropDownList;
            JournalNameDropList.FormattingEnabled = true;
            JournalNameDropList.Items.AddRange(new object[] { "Полное", "Аббревиатура" });
            JournalNameDropList.Location = new Point(6, 20);
            JournalNameDropList.Margin = new Padding(3, 2, 3, 2);
            JournalNameDropList.Name = "JournalNameDropList";
            JournalNameDropList.Size = new Size(202, 23);
            JournalNameDropList.TabIndex = 0;
            // 
            // DOIBox
            // 
            DOIBox.Controls.Add(DOICheck);
            DOIBox.Controls.Add(DOIDropList);
            DOIBox.Location = new Point(254, 216);
            DOIBox.Margin = new Padding(3, 2, 3, 2);
            DOIBox.Name = "DOIBox";
            DOIBox.Padding = new Padding(3, 2, 3, 2);
            DOIBox.Size = new Size(215, 54);
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
            DOICheck.Location = new Point(6, 2);
            DOICheck.Margin = new Padding(3, 2, 3, 2);
            DOICheck.Name = "DOICheck";
            DOICheck.Size = new Size(46, 19);
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
            DOIDropList.Location = new Point(6, 23);
            DOIDropList.Margin = new Padding(3, 2, 3, 2);
            DOIDropList.Name = "DOIDropList";
            DOIDropList.Size = new Size(203, 23);
            DOIDropList.TabIndex = 0;
            // 
            // PageBox
            // 
            PageBox.Controls.Add(PageOnePage);
            PageBox.Controls.Add(PagesDivider);
            PageBox.Controls.Add(PageCheck);
            PageBox.Controls.Add(PageItalic);
            PageBox.Controls.Add(PageBold);
            PageBox.Location = new Point(476, 242);
            PageBox.Margin = new Padding(3, 2, 3, 2);
            PageBox.Name = "PageBox";
            PageBox.Padding = new Padding(3, 2, 3, 2);
            PageBox.Size = new Size(170, 126);
            PageBox.TabIndex = 9;
            PageBox.TabStop = false;
            PageBox.Text = "Страницы";
            // 
            // PageOnePage
            // 
            PageOnePage.AutoSize = true;
            PageOnePage.Location = new Point(6, 69);
            PageOnePage.Margin = new Padding(3, 2, 3, 2);
            PageOnePage.Name = "PageOnePage";
            PageOnePage.Size = new Size(108, 19);
            PageOnePage.TabIndex = 4;
            PageOnePage.Text = "Одна страница";
            PageOnePage.UseVisualStyleBackColor = true;
            // 
            // PagesDivider
            // 
            PagesDivider.DropDownStyle = ComboBoxStyle.DropDownList;
            PagesDivider.FormattingEnabled = true;
            PagesDivider.Items.AddRange(new object[] { "Через тире", "Через дефис" });
            PagesDivider.Location = new Point(5, 95);
            PagesDivider.Margin = new Padding(3, 2, 3, 2);
            PagesDivider.Name = "PagesDivider";
            PagesDivider.Size = new Size(158, 23);
            PagesDivider.TabIndex = 3;
            // 
            // PageCheck
            // 
            PageCheck.AutoSize = true;
            PageCheck.BackColor = SystemColors.ActiveCaption;
            PageCheck.Checked = true;
            PageCheck.CheckState = CheckState.Checked;
            PageCheck.Location = new Point(5, 0);
            PageCheck.Margin = new Padding(3, 2, 3, 2);
            PageCheck.Name = "PageCheck";
            PageCheck.Size = new Size(145, 19);
            PageCheck.TabIndex = 2;
            PageCheck.Text = "Страницы или номер";
            PageCheck.UseVisualStyleBackColor = false;
            PageCheck.CheckedChanged += PageCheck_CheckedChanged;
            // 
            // PageItalic
            // 
            PageItalic.AutoSize = true;
            PageItalic.Location = new Point(6, 46);
            PageItalic.Margin = new Padding(3, 2, 3, 2);
            PageItalic.Name = "PageItalic";
            PageItalic.Size = new Size(65, 19);
            PageItalic.TabIndex = 1;
            PageItalic.Text = "Курсив";
            PageItalic.UseVisualStyleBackColor = true;
            // 
            // PageBold
            // 
            PageBold.AutoSize = true;
            PageBold.Location = new Point(5, 24);
            PageBold.Margin = new Padding(3, 2, 3, 2);
            PageBold.Name = "PageBold";
            PageBold.Size = new Size(101, 19);
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
            YearBox.Location = new Point(254, 274);
            YearBox.Margin = new Padding(3, 2, 3, 2);
            YearBox.Name = "YearBox";
            YearBox.Padding = new Padding(3, 2, 3, 2);
            YearBox.Size = new Size(215, 94);
            YearBox.TabIndex = 10;
            YearBox.TabStop = false;
            YearBox.Text = "Год";
            // 
            // YearBrackets
            // 
            YearBrackets.AutoSize = true;
            YearBrackets.Location = new Point(7, 66);
            YearBrackets.Margin = new Padding(3, 2, 3, 2);
            YearBrackets.Name = "YearBrackets";
            YearBrackets.Size = new Size(80, 19);
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
            YearCheck.Location = new Point(7, 0);
            YearCheck.Margin = new Padding(3, 2, 3, 2);
            YearCheck.Name = "YearCheck";
            YearCheck.Size = new Size(45, 19);
            YearCheck.TabIndex = 2;
            YearCheck.Text = "Год";
            YearCheck.UseVisualStyleBackColor = false;
            YearCheck.CheckedChanged += YearCheck_CheckedChanged;
            // 
            // YearItalic
            // 
            YearItalic.AutoSize = true;
            YearItalic.Location = new Point(7, 44);
            YearItalic.Margin = new Padding(3, 2, 3, 2);
            YearItalic.Name = "YearItalic";
            YearItalic.Size = new Size(65, 19);
            YearItalic.TabIndex = 1;
            YearItalic.Text = "Курсив";
            YearItalic.UseVisualStyleBackColor = true;
            // 
            // YearBold
            // 
            YearBold.AutoSize = true;
            YearBold.Location = new Point(7, 22);
            YearBold.Margin = new Padding(3, 2, 3, 2);
            YearBold.Name = "YearBold";
            YearBold.Size = new Size(101, 19);
            YearBold.TabIndex = 0;
            YearBold.Text = "Полужирный";
            YearBold.UseVisualStyleBackColor = true;
            // 
            // ThomeBox
            // 
            ThomeBox.Controls.Add(ThomeCheck);
            ThomeBox.Controls.Add(ThomeItalic);
            ThomeBox.Controls.Add(ThomeBold);
            ThomeBox.Location = new Point(476, 50);
            ThomeBox.Margin = new Padding(3, 2, 3, 2);
            ThomeBox.Name = "ThomeBox";
            ThomeBox.Padding = new Padding(3, 2, 3, 2);
            ThomeBox.Size = new Size(170, 70);
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
            ThomeCheck.Location = new Point(6, 0);
            ThomeCheck.Margin = new Padding(3, 2, 3, 2);
            ThomeCheck.Name = "ThomeCheck";
            ThomeCheck.Size = new Size(48, 19);
            ThomeCheck.TabIndex = 2;
            ThomeCheck.Text = "Том";
            ThomeCheck.UseVisualStyleBackColor = false;
            ThomeCheck.CheckedChanged += ThomeCheck_CheckedChanged;
            // 
            // ThomeItalic
            // 
            ThomeItalic.AutoSize = true;
            ThomeItalic.Location = new Point(6, 43);
            ThomeItalic.Margin = new Padding(3, 2, 3, 2);
            ThomeItalic.Name = "ThomeItalic";
            ThomeItalic.Size = new Size(65, 19);
            ThomeItalic.TabIndex = 1;
            ThomeItalic.Text = "Курсив";
            ThomeItalic.UseVisualStyleBackColor = true;
            // 
            // ThomeBold
            // 
            ThomeBold.AutoSize = true;
            ThomeBold.Location = new Point(6, 20);
            ThomeBold.Margin = new Padding(3, 2, 3, 2);
            ThomeBold.Name = "ThomeBold";
            ThomeBold.Size = new Size(101, 19);
            ThomeBold.TabIndex = 0;
            ThomeBold.Text = "Полужирный";
            ThomeBold.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.Location = new Point(12, 407);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.MinimumSize = new Size(300, 20);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1364, 76);
            richTextBox1.TabIndex = 12;
            richTextBox1.Text = "";
            // 
            // Block1
            // 
            Block1.FormattingEnabled = true;
            Block1.Location = new Point(678, 89);
            Block1.Margin = new Padding(3, 2, 3, 2);
            Block1.Name = "Block1";
            Block1.Size = new Size(162, 23);
            Block1.TabIndex = 13;
            // 
            // Divider1
            // 
            Divider1.BackColor = Color.LightYellow;
            Divider1.ForeColor = SystemColors.ActiveCaptionText;
            Divider1.FormattingEnabled = true;
            Divider1.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider1.Location = new Point(857, 89);
            Divider1.Margin = new Padding(3, 2, 3, 2);
            Divider1.Name = "Divider1";
            Divider1.Size = new Size(133, 23);
            Divider1.TabIndex = 14;
            // 
            // Block2
            // 
            Block2.FormattingEnabled = true;
            Block2.Location = new Point(678, 115);
            Block2.Margin = new Padding(3, 2, 3, 2);
            Block2.Name = "Block2";
            Block2.Size = new Size(162, 23);
            Block2.TabIndex = 15;
            // 
            // Divider2
            // 
            Divider2.BackColor = Color.LightYellow;
            Divider2.FormattingEnabled = true;
            Divider2.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider2.Location = new Point(857, 115);
            Divider2.Margin = new Padding(3, 2, 3, 2);
            Divider2.Name = "Divider2";
            Divider2.Size = new Size(133, 23);
            Divider2.TabIndex = 16;
            // 
            // Block3
            // 
            Block3.FormattingEnabled = true;
            Block3.Location = new Point(678, 140);
            Block3.Margin = new Padding(3, 2, 3, 2);
            Block3.Name = "Block3";
            Block3.Size = new Size(162, 23);
            Block3.TabIndex = 17;
            // 
            // Divider3
            // 
            Divider3.BackColor = Color.LightYellow;
            Divider3.FormattingEnabled = true;
            Divider3.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider3.Location = new Point(857, 140);
            Divider3.Margin = new Padding(3, 2, 3, 2);
            Divider3.Name = "Divider3";
            Divider3.Size = new Size(133, 23);
            Divider3.TabIndex = 18;
            // 
            // Block4
            // 
            Block4.FormattingEnabled = true;
            Block4.Location = new Point(678, 166);
            Block4.Margin = new Padding(3, 2, 3, 2);
            Block4.Name = "Block4";
            Block4.Size = new Size(162, 23);
            Block4.TabIndex = 19;
            // 
            // Divider4
            // 
            Divider4.BackColor = Color.LightYellow;
            Divider4.FormattingEnabled = true;
            Divider4.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider4.Location = new Point(857, 166);
            Divider4.Margin = new Padding(3, 2, 3, 2);
            Divider4.Name = "Divider4";
            Divider4.Size = new Size(133, 23);
            Divider4.TabIndex = 20;
            // 
            // Block5
            // 
            Block5.FormattingEnabled = true;
            Block5.Location = new Point(678, 191);
            Block5.Margin = new Padding(3, 2, 3, 2);
            Block5.Name = "Block5";
            Block5.Size = new Size(162, 23);
            Block5.TabIndex = 21;
            // 
            // Divider5
            // 
            Divider5.BackColor = Color.LightYellow;
            Divider5.FormattingEnabled = true;
            Divider5.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider5.Location = new Point(857, 191);
            Divider5.Margin = new Padding(3, 2, 3, 2);
            Divider5.Name = "Divider5";
            Divider5.Size = new Size(133, 23);
            Divider5.TabIndex = 22;
            // 
            // Block6
            // 
            Block6.FormattingEnabled = true;
            Block6.Location = new Point(678, 217);
            Block6.Margin = new Padding(3, 2, 3, 2);
            Block6.Name = "Block6";
            Block6.Size = new Size(162, 23);
            Block6.TabIndex = 23;
            // 
            // Divider6
            // 
            Divider6.BackColor = Color.LightYellow;
            Divider6.FormattingEnabled = true;
            Divider6.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider6.Location = new Point(857, 217);
            Divider6.Margin = new Padding(3, 2, 3, 2);
            Divider6.Name = "Divider6";
            Divider6.Size = new Size(133, 23);
            Divider6.TabIndex = 24;
            // 
            // Block7
            // 
            Block7.FormattingEnabled = true;
            Block7.Location = new Point(678, 242);
            Block7.Margin = new Padding(3, 2, 3, 2);
            Block7.Name = "Block7";
            Block7.Size = new Size(162, 23);
            Block7.TabIndex = 25;
            // 
            // End
            // 
            End.BackColor = Color.LightCoral;
            End.FormattingEnabled = true;
            End.Items.AddRange(new object[] { "Отсутствует", ".", ";" });
            End.Location = new Point(764, 328);
            End.Margin = new Padding(3, 2, 3, 2);
            End.Name = "End";
            End.Size = new Size(133, 23);
            End.TabIndex = 26;
            // 
            // BlockLabel
            // 
            BlockLabel.AutoSize = true;
            BlockLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BlockLabel.Location = new Point(738, 65);
            BlockLabel.Name = "BlockLabel";
            BlockLabel.Size = new Size(41, 15);
            BlockLabel.TabIndex = 27;
            BlockLabel.Text = "Блоки";
            // 
            // DividingLabel
            // 
            DividingLabel.AutoSize = true;
            DividingLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DividingLabel.Location = new Point(885, 65);
            DividingLabel.Name = "DividingLabel";
            DividingLabel.Size = new Size(76, 15);
            DividingLabel.TabIndex = 28;
            DividingLabel.Text = "Разделители";
            // 
            // EndingLabel
            // 
            EndingLabel.AutoSize = true;
            EndingLabel.Location = new Point(774, 307);
            EndingLabel.Name = "EndingLabel";
            EndingLabel.Size = new Size(114, 15);
            EndingLabel.TabIndex = 29;
            EndingLabel.Text = "Символ окончания";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(659, 92);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 30;
            label8.Text = "1";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(659, 118);
            label9.Name = "label9";
            label9.Size = new Size(13, 15);
            label9.TabIndex = 31;
            label9.Text = "2";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(659, 143);
            label10.Name = "label10";
            label10.Size = new Size(13, 15);
            label10.TabIndex = 32;
            label10.Text = "3";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(659, 169);
            label11.Name = "label11";
            label11.Size = new Size(13, 15);
            label11.TabIndex = 33;
            label11.Text = "4";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(659, 194);
            label12.Name = "label12";
            label12.Size = new Size(13, 15);
            label12.TabIndex = 34;
            label12.Text = "5";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(659, 220);
            label13.Name = "label13";
            label13.Size = new Size(13, 15);
            label13.TabIndex = 35;
            label13.Text = "6";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(659, 245);
            label14.Name = "label14";
            label14.Size = new Size(13, 15);
            label14.TabIndex = 36;
            label14.Text = "7";
            // 
            // Block8
            // 
            Block8.FormattingEnabled = true;
            Block8.Location = new Point(678, 268);
            Block8.Margin = new Padding(3, 2, 3, 2);
            Block8.Name = "Block8";
            Block8.Size = new Size(162, 23);
            Block8.TabIndex = 37;
            // 
            // Divider7
            // 
            Divider7.BackColor = Color.LightYellow;
            Divider7.FormattingEnabled = true;
            Divider7.Items.AddRange(new object[] { "\" \"", "\", \"", "\". \"", "\"; \"", "\": \"", "\" / \"", "\" // \"", "\" – \"", "\". – \"" });
            Divider7.Location = new Point(857, 242);
            Divider7.Margin = new Padding(3, 2, 3, 2);
            Divider7.Name = "Divider7";
            Divider7.Size = new Size(133, 23);
            Divider7.TabIndex = 38;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(659, 271);
            label15.Name = "label15";
            label15.Size = new Size(13, 15);
            label15.TabIndex = 39;
            label15.Text = "8";
            // 
            // IssueBox
            // 
            IssueBox.Controls.Add(IssueCheck);
            IssueBox.Controls.Add(IssueItalic);
            IssueBox.Controls.Add(IssueBold);
            IssueBox.Controls.Add(IssueThomePart);
            IssueBox.Location = new Point(476, 126);
            IssueBox.Margin = new Padding(3, 2, 3, 2);
            IssueBox.Name = "IssueBox";
            IssueBox.Padding = new Padding(3, 2, 3, 2);
            IssueBox.Size = new Size(170, 106);
            IssueBox.TabIndex = 40;
            IssueBox.TabStop = false;
            IssueBox.Text = "Номер";
            // 
            // IssueCheck
            // 
            IssueCheck.AutoSize = true;
            IssueCheck.BackColor = SystemColors.ActiveCaption;
            IssueCheck.Checked = true;
            IssueCheck.CheckState = CheckState.Checked;
            IssueCheck.Location = new Point(5, 0);
            IssueCheck.Margin = new Padding(3, 2, 3, 2);
            IssueCheck.Name = "IssueCheck";
            IssueCheck.Size = new Size(72, 19);
            IssueCheck.TabIndex = 3;
            IssueCheck.Text = "Издание";
            IssueCheck.UseVisualStyleBackColor = false;
            IssueCheck.CheckedChanged += IssueCheck_CheckedChanged;
            // 
            // IssueItalic
            // 
            IssueItalic.AutoSize = true;
            IssueItalic.Location = new Point(5, 81);
            IssueItalic.Margin = new Padding(3, 2, 3, 2);
            IssueItalic.Name = "IssueItalic";
            IssueItalic.Size = new Size(65, 19);
            IssueItalic.TabIndex = 2;
            IssueItalic.Text = "Курсив";
            IssueItalic.UseVisualStyleBackColor = true;
            // 
            // IssueBold
            // 
            IssueBold.AutoSize = true;
            IssueBold.Location = new Point(5, 56);
            IssueBold.Margin = new Padding(3, 2, 3, 2);
            IssueBold.Name = "IssueBold";
            IssueBold.Size = new Size(101, 19);
            IssueBold.TabIndex = 1;
            IssueBold.Text = "Полужирный";
            IssueBold.UseVisualStyleBackColor = true;
            // 
            // IssueThomePart
            // 
            IssueThomePart.AutoSize = true;
            IssueThomePart.Location = new Point(5, 20);
            IssueThomePart.Margin = new Padding(3, 2, 3, 2);
            IssueThomePart.Name = "IssueThomePart";
            IssueThomePart.Size = new Size(113, 34);
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
            panel1.Location = new Point(1018, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(358, 261);
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
            panelLabel.Size = new Size(358, 260);
            panelLabel.TabIndex = 0;
            panelLabel.Text = "Нажмите, чтобы выбрать файл(ы) \r\nили перетащите в это поле";
            panelLabel.TextAlign = ContentAlignment.MiddleCenter;
            panelLabel.Click += panelLabel_Click;
            // 
            // FileSelection
            // 
            FileSelection.AutoSize = true;
            FileSelection.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            FileSelection.Location = new Point(1017, 22);
            FileSelection.Name = "FileSelection";
            FileSelection.Size = new Size(131, 19);
            FileSelection.TabIndex = 0;
            FileSelection.Text = "Выбор файла(ов)";
            // 
            // ChooseFileButton
            // 
            ChooseFileButton.Location = new Point(1018, 352);
            ChooseFileButton.Name = "ChooseFileButton";
            ChooseFileButton.Size = new Size(112, 41);
            ChooseFileButton.TabIndex = 1;
            ChooseFileButton.Text = "Выбрать файл(ы)";
            ChooseFileButton.UseVisualStyleBackColor = true;
            ChooseFileButton.Click += button1_Click_1;
            // 
            // SupportedFiles
            // 
            SupportedFiles.AutoSize = true;
            SupportedFiles.Location = new Point(1018, 49);
            SupportedFiles.Name = "SupportedFiles";
            SupportedFiles.Size = new Size(201, 15);
            SupportedFiles.TabIndex = 42;
            SupportedFiles.Text = "Поддерживаемый формат файлов:";
            // 
            // SupportedFormats
            // 
            SupportedFormats.AutoSize = true;
            SupportedFormats.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SupportedFormats.Location = new Point(1225, 49);
            SupportedFormats.Name = "SupportedFormats";
            SupportedFormats.Size = new Size(60, 15);
            SupportedFormats.TabIndex = 43;
            SupportedFormats.Text = ".txt .docx";
            // 
            // Output
            // 
            Output.AutoSize = true;
            Output.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            Output.Location = new Point(12, 378);
            Output.Name = "Output";
            Output.Size = new Size(55, 19);
            Output.TabIndex = 44;
            Output.Text = "Вывод";
            // 
            // RepeatButton
            // 
            RepeatButton.Location = new Point(1149, 352);
            RepeatButton.Margin = new Padding(3, 2, 3, 2);
            RepeatButton.Name = "RepeatButton";
            RepeatButton.Size = new Size(112, 41);
            RepeatButton.TabIndex = 45;
            RepeatButton.Text = "Обновить ссылки";
            RepeatButton.UseVisualStyleBackColor = true;
            RepeatButton.Click += RepeatButton_Click;
            // 
            // ButtonChangeLang
            // 
            ButtonChangeLang.Location = new Point(1335, 13);
            ButtonChangeLang.Name = "ButtonChangeLang";
            ButtonChangeLang.Size = new Size(41, 38);
            ButtonChangeLang.TabIndex = 46;
            ButtonChangeLang.Text = "EN";
            ButtonChangeLang.UseVisualStyleBackColor = true;
            ButtonChangeLang.Click += ButtonChangeLang_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1411, 490);
            Controls.Add(ButtonChangeLang);
            Controls.Add(RepeatButton);
            Controls.Add(Output);
            Controls.Add(SupportedFormats);
            Controls.Add(SupportedFiles);
            Controls.Add(ChooseFileButton);
            Controls.Add(FileSelection);
            Controls.Add(panel1);
            Controls.Add(IssueBox);
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
            Controls.Add(EndingLabel);
            Controls.Add(DividingLabel);
            Controls.Add(BlockLabel);
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
            Name = "Form1";
            Text = "Chimica Techno Acta reference generator";
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
            IssueBox.ResumeLayout(false);
            IssueBox.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button DOIInputButton;
        private TextBox DOIinput;
        private GroupBox authorsBox;
        private Label AuthorsPosition;
        private ComboBox AuthPosDropList;
        private ComboBox NameSepDropList;
        private Label AuthorsDividingInitialsSurname;
        private CheckBox InitialsSpaceCheck;
        private CheckBox InitialsDotCheck;
        private Label AuthorsDividingAuthors;
        private ComboBox AuthSepDropList;
        private CheckBox AuthsLimitCheck;
        private CheckBox AndCheck;
        private Label AuthorsNumber;
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
        private Label BlockLabel;
        private Label DividingLabel;
        private Label EndingLabel;
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
        private GroupBox IssueBox;
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
        private Label FileSelection;
        private Button ChooseFileButton;
        private Button RepeatButton;
        private Label SupportedFiles;
        private Label SupportedFormats;
        private Label Output;
        private CheckBox PageOnePage;
        private CheckBox JournalTitleItalic;
        private Button ButtonChangeLang;
    }
}