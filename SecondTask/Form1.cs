using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Aspose.Cells;
using System.Collections.Generic;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics.Eventing.Reader;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections;
using System.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int blocksCount;
        RequestsHandler handler;
        Regex regex = new Regex(@"[A-Z]");
        MatchCollection matches;
        TextInfo textInfo = new CultureInfo("ru-RU").TextInfo;
        List<string> blocks = new List<string> { "Авторы", "Название статьи",
            "Название журнала", "DOI", "Год", "Том", "Издание", "Страницы или номер"};
        List<string> doiContentList = new List<string>();


        public Form1()
        {
            InitializeComponent();
            blocksCount = 8;
            handler = new RequestsHandler();
            AuthPosDropList.SelectedItem = AuthPosDropList.Items[0];
            NameSepDropList.SelectedItem = NameSepDropList.Items[0];
            AuthSepDropList.SelectedItem = AuthSepDropList.Items[0];
            ArticleNameDropList.SelectedItem = ArticleNameDropList.Items[0];
            JournalNameDropList.SelectedItem = JournalNameDropList.Items[0];
            DOIDropList.SelectedItem = DOIDropList.Items[0];
            PagesDivider.SelectedItem = PagesDivider.Items[0];
            DOIinput.Text = "https://doi.org/10.1070/RCR4987";
            Block1.Items.AddRange(blocks.ToArray()); Block2.Items.AddRange(blocks.ToArray());
            Block3.Items.AddRange(blocks.ToArray()); Block4.Items.AddRange(blocks.ToArray());
            Block5.Items.AddRange(blocks.ToArray()); Block6.Items.AddRange(blocks.ToArray());
            Block7.Items.AddRange(blocks.ToArray()); Block8.Items.AddRange(blocks.ToArray());
            Divider1.SelectedItem = Divider2.SelectedItem = Divider3.SelectedItem =
            Divider4.SelectedItem = Divider5.SelectedItem = Divider6.SelectedItem =
            Divider7.SelectedItem = Divider1.Items[0];

            End.SelectedItem = End.Items[0];
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (DOIinput.Text == "")
            {
                richTextBox1.Text = "Error, empty field.";
                return;
            }

            Response1 res = await handler.GetMetadata(DOIinput.Text);

            if (res.status == "error")
            {
                richTextBox1.Text = "Error, wrong input.";
                return;
            }

            int num = 0;

            if (Block1.Text != "" && Block1.Enabled)
                CheckBlock(Block1.Text, res);
            if (Divider1.Enabled)
                richTextBox1.AppendText(Divider1.Text.Trim('"'));

            if (Block2.Text != "" && Block2.Enabled)
                CheckBlock(Block2.Text, res);
            if (Divider2.Enabled)
                richTextBox1.AppendText(Divider2.Text.Trim('"'));

            if (Block3.Text != "" && Block3.Enabled)
                CheckBlock(Block3.Text, res);
            if (Divider3.Enabled)
                richTextBox1.AppendText(Divider3.Text.Trim('"'));

            if (Block4.Text != "" && Block4.Enabled)
                CheckBlock(Block4.Text, res);
            if (Divider4.Enabled)
                richTextBox1.AppendText(Divider4.Text.Trim('"'));

            if (Block5.Text != "" && Block5.Enabled)
                CheckBlock(Block5.Text, res);
            if (Divider5.Enabled)
                richTextBox1.AppendText(Divider5.Text.Trim('"'));

            if (Block6.Text != "" && Block6.Enabled)
                CheckBlock(Block6.Text, res);
            if (Divider6.Enabled)
                richTextBox1.AppendText(Divider6.Text.Trim('"'));

            if (Block7.Text != "" && Block7.Enabled)
                CheckBlock(Block7.Text, res);
            if (Divider7.Enabled)
                richTextBox1.AppendText(Divider7.Text.Trim('"'));

            if (Block8.Text != "" && Block8.Enabled)
                CheckBlock(Block8.Text, res);

            if (End.Text != "Отсутствует")
                richTextBox1.AppendText(End.Text.Trim('"'));
        }

        private void AuthsLimitCheck_Click(object sender, EventArgs e)
        {
            if (AuthsLimitCheck.Checked)
            {
                label4.Enabled = true;
                AuthorsLimiter.Enabled = true;
                AndCheck.Enabled = false;
                AndCheck.Checked = false;
            }
            else
            {
                label4.Enabled = false;
                AuthorsLimiter.Enabled = false;
                AndCheck.Enabled = true;
            }
        }

        async void FormAuthorsList(Response1 response, RichTextBox rtb)
        {
            string firstW, secondW, initialEnd, initialsSeparator;
            string nameSeparator = NameSepDropList.Text.Trim('"');
            string authorsSeparator = $"{AuthSepDropList.Text} ";
            bool prevLarger = false;

            if (InitialsDotCheck.Checked)
                initialEnd = ".";
            else
                initialEnd = "";

            if (InitialsSpaceCheck.Checked)
                initialsSeparator = " ";
            else
                initialsSeparator = "";


            var authors = response.message.author;
            int authorsLength = authors.Length;
            if (AuthsLimitCheck.Checked && authorsLength > (int)AuthorsLimiter.Value)
            {
                authorsLength = (int)AuthorsLimiter.Value;
                prevLarger = true;
            }
            string[] authorsStr = new string[authorsLength];

            if (AuthPosDropList.Text == "Инициалы/Фамилия")
            {
                for (int i = 0; i < authorsLength; i++)
                {
                    matches = regex.Matches(authors[i].given);
                    string[] initials = new string[matches.Count];
                    for (int j = 0; j < matches.Count(); j++)
                        initials[j] = $"{matches[j].Value}{initialEnd}";

                    firstW = String.Join(initialsSeparator, initials);
                    secondW = authors[i].family;

                    authorsStr[i] =
                        $"{firstW}{nameSeparator}{secondW}";
                }
            }
            else
            {
                for (int i = 0; i < authorsLength; i++)
                {
                    matches = regex.Matches(authors[i].given);
                    string[] initials = new string[matches.Count];
                    for (int j = 0; j < matches.Count(); j++)
                        initials[j] = $"{matches[j].Value}{initialEnd}";

                    firstW = authors[i].family;
                    secondW = String.Join(initialsSeparator, initials);

                    authorsStr[i] =
                        $"{firstW}{nameSeparator}{secondW}";
                }
            }

            if (AndCheck.Checked && authorsLength >= 2)
            {
                string lastAuthor = authorsStr.Last();
                List<string> tempAuthorsStr = new List<string>(authorsStr);
                tempAuthorsStr.RemoveAt(authorsLength - 1);
                authorsStr = tempAuthorsStr.ToArray();
                rtb.AppendText($"{String.Join(authorsSeparator, authorsStr)} and {lastAuthor}");
                return;
            }

            if (AuthsLimitCheck.Checked && prevLarger && (int)AuthorsLimiter.Value > 0)
            {
                rtb.AppendText($"{String.Join(authorsSeparator, authorsStr)} et al.");
                return;
            }

            rtb.AppendText(String.Join(authorsSeparator, authorsStr));
            return;
        }

        async void FormTitle(Response1 response, RichTextBox rtb)
        {
            string title = response.message.title[0];
            switch (ArticleNameDropList.SelectedItem)
            {
                case "Название в нижнем регистре":
                    title = Regex.Replace(title, @"\W[A-Z][a-z]+\s", m => m.Value.ToLower());
                    break;

                case "Название с заглавными буквами":
                    title = (Regex.Replace(Regex.Replace(title, @"\b(\w)", m => m.Value.ToUpper()),
                        @"(\s(of|in|by|and|the|a|an|at|on|under|above|between|to|into|out of|from|through|along|across|before|after|till|until|ago|during|since|for|because of|due to|thanks to|in accordance with|against|behind|below|around|towards|back to|in front of|outside|on account of|upon)|\'[st])\b",
                        m => m.Value.ToLower(), RegexOptions.IgnoreCase));
                    break;

                default:
                    break;
            }

            title = Regex.Replace(title, @"<\w*>|</\w*>", "");
            rtb.AppendText(title);
        }

        async void FormJournalName(Response1 response, RichTextBox rtb)
        {
            var journal = response.message.container_title[0];
            switch (JournalNameDropList.SelectedItem)
            {
                case "Полное":
                    rtb.AppendText(journal);
                    return;

                case "Аббревиатура":
                    Workbook wb = new Workbook("Journals.xlsx");
                    Worksheet worksheet = wb.Worksheets[0];
                    Dictionary<int, string> pairs = new Dictionary<int, string>();

                    for (int i = 0; i < worksheet.Cells.MaxDataRow; i++)
                    {
                        string mask;

                        if (worksheet.Cells[i, 0].Value.ToString().Last() == '-')
                        {
                            mask = $@"\b({worksheet.Cells[i, 0].Value.ToString().TrimStart('=').TrimEnd('-')})\w*";
                        }
                        else mask = $@"\b({worksheet.Cells[i, 0].Value.ToString().TrimStart('=')})\b";

                        if (Regex.Match(journal, mask, RegexOptions.IgnoreCase).Value.ToString() != "")
                            pairs.Add(i, mask);
                    }
                    foreach (var el in pairs)
                    {
                        if (worksheet.Cells[el.Key, 1].Value.ToString() != "n.a.")
                            journal = Regex.Replace(journal, el.Value,
                                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(worksheet.Cells[el.Key, 1].Value.ToString()),
                                RegexOptions.IgnoreCase);
                    }

                    if (checkDots.Checked)
                        journal = journal.Replace(".", "");

                    rtb.AppendText(journal);
                    return;

                default:
                    return;
            }
        }

        async void FormDOI(RichTextBox rtb)
        {
            var DOI = DOIinput.Text.Replace("https://doi.org/", "");

            switch (DOIDropList.SelectedItem)
            {
                case "Как url-ссылка":
                    rtb.AppendText($"https://doi.org/{DOI}");
                    return;

                case "Сокращенное":
                    rtb.AppendText(DOI);
                    return;

                default:
                    return;
            }
        }

        async void FormYear(Response1 response, RichTextBox rtb)
        {
            var year = response.message.license[0].start.date.Substring(0, 4);

            if (YearBrackets.Checked)
                year = $"({year})";

            if (YearBold.Checked && YearItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold | FontStyle.Italic);
                rtb.AppendText(year);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else if (YearBold.Checked && !YearItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold);
                rtb.AppendText(year);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else if (!YearBold.Checked && YearItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Italic);
                rtb.AppendText(year);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
                rtb.AppendText(year);
            }
        }

        async void FormThome(Response1 response, RichTextBox rtb)
        {
            var thome = response.message.volume;

            if (IssueThomePart.Checked)
            {
                thome = $"{thome}({response.message.issue})";
            }

            if (ThomeBold.Checked && ThomeItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold | FontStyle.Italic);
                rtb.AppendText(thome);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else if (ThomeBold.Checked && !ThomeItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold);
                rtb.AppendText(thome);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else if (!ThomeBold.Checked && ThomeItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Italic);
                rtb.AppendText(thome);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
                rtb.AppendText(thome);
            }
        }

        async void FormNumber(Response1 response, RichTextBox rtb)
        {
            var number = response.message.issue;

            if (IssueBold.Checked && IssueItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold | FontStyle.Italic);
                rtb.AppendText(number);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else if (IssueBold.Checked && !IssueItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold);
                rtb.AppendText(number);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else if (!IssueBold.Checked && IssueItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Italic);
                rtb.AppendText(number);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
                rtb.AppendText(number);
            }
        }

        async void FormPage(Response1 response, RichTextBox rtb)
        {
            var page = response.message.page;
            if (PagesDivider.Text == "Через тире")
                page = page.Replace("-", "–");

            else if (PagesDivider.Text == "Через дефис")
                page = page.Replace("–", "-");

            if (PageBold.Checked && PageItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold | FontStyle.Italic);
                rtb.AppendText(page);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else if (PageBold.Checked && !PageItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold);
                rtb.AppendText(page);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else if (!PageBold.Checked && PageItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Italic);
                rtb.AppendText(page);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
                rtb.AppendText(page);
            }
        }

        private void NumberThomePart_CheckedChanged(object sender, EventArgs e)
        {
            if (IssueThomePart.Checked)
            {
                if (IssueCheck.Checked)
                    blocksCount -= 1;

                IssueCheck.Enabled = false;
                IssueCheck.Checked = false;
                IssueBold.Enabled = false;
                IssueBold.Checked = false;
                IssueItalic.Enabled = false;
                IssueItalic.Checked = false;
                CheckBlocksNumber();
            }
            else if (!IssueThomePart.Checked)
            {
                IssueCheck.Enabled = true;
                IssueCheck.Checked = true;
                IssueBold.Enabled = true;
                IssueItalic.Enabled = true;
                CheckBlocksNumber();
            }
        }

        private void AuthorsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AuthorsCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("Авторы");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("Авторы");
            }

            FormBlockList();
        }

        private void TitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (TitleCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("Название статьи");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("Название статьи");
            }

            FormBlockList();
        }

        private void JournalCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (JournalCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("Название журнала");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("Название журнала");
            }

            FormBlockList();
        }

        private void DOICheck_CheckedChanged(object sender, EventArgs e)
        {
            if (DOICheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("DOI");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("DOI");
            }

            FormBlockList();
        }

        private void YearCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (YearCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("Год");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("Год");
            }

            FormBlockList();
        }

        private void ThomeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ThomeCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("Том");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("Том");
            }

            FormBlockList();
        }

        private void IssueCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (IssueCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("Издание");
            }
            else if (!IssueCheck.Checked)
            {
                if (!IssueThomePart.Checked)
                    blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("Издание");
            }

            FormBlockList();
        }

        private void PageCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PageCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("Страницы или номер");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("Страницы или номер");
            }

            FormBlockList();
        }

        private void CheckBlocksNumber()
        {
            switch (blocksCount)
            {
                case 8:
                    Block1.Enabled = Block2.Enabled = Block3.Enabled = Block4.Enabled = Block5.Enabled = Block6.Enabled = Block7.Enabled = Block8.Enabled = true;
                    Divider1.Enabled = Divider2.Enabled = Divider3.Enabled = Divider4.Enabled = Divider5.Enabled = Divider6.Enabled = Divider7.Enabled = true;
                    break;

                case 7:
                    Block1.Enabled = Block2.Enabled = Block3.Enabled = Block4.Enabled = Block5.Enabled = Block6.Enabled = Block7.Enabled = true;
                    Block8.Enabled = false;
                    Divider1.Enabled = Divider2.Enabled = Divider3.Enabled = Divider4.Enabled = Divider5.Enabled = Divider6.Enabled = true;
                    Divider7.Enabled = false;
                    break;

                case 6:
                    Block1.Enabled = Block2.Enabled = Block3.Enabled = Block4.Enabled = Block5.Enabled = Block6.Enabled = true;
                    Block8.Enabled = Block7.Enabled = false;
                    Divider1.Enabled = Divider2.Enabled = Divider3.Enabled = Divider4.Enabled = Divider5.Enabled = true;
                    Divider7.Enabled = Divider6.Enabled = false;
                    break;

                case 5:
                    Block1.Enabled = Block2.Enabled = Block3.Enabled = Block4.Enabled = Block5.Enabled = true;
                    Block8.Enabled = Block7.Enabled = Block6.Enabled = false;
                    Divider1.Enabled = Divider2.Enabled = Divider3.Enabled = Divider4.Enabled = true;
                    Divider7.Enabled = Divider6.Enabled = Divider5.Enabled = false;
                    break;

                case 4:
                    Block1.Enabled = Block2.Enabled = Block3.Enabled = Block4.Enabled = true;
                    Block8.Enabled = Block7.Enabled = Block6.Enabled = Block5.Enabled = false;
                    Divider1.Enabled = Divider2.Enabled = Divider3.Enabled = true;
                    Divider7.Enabled = Divider6.Enabled = Divider5.Enabled = Divider4.Enabled = false;
                    break;

                case 3:
                    Block1.Enabled = Block2.Enabled = Block3.Enabled = true;
                    Block8.Enabled = Block7.Enabled = Block6.Enabled = Block5.Enabled = Block4.Enabled = false;
                    Divider1.Enabled = Divider2.Enabled = true;
                    Divider7.Enabled = Divider6.Enabled = Divider5.Enabled = Divider4.Enabled = Divider3.Enabled = false;
                    break;

                case 2:
                    Block1.Enabled = Block2.Enabled = true;
                    Block8.Enabled = Block7.Enabled = Block6.Enabled = Block5.Enabled = Block4.Enabled = Block3.Enabled = false;
                    Divider1.Enabled = true;
                    Divider7.Enabled = Divider6.Enabled = Divider5.Enabled = Divider4.Enabled = Divider3.Enabled = Divider2.Enabled = false;
                    break;

                case 1:
                    Block1.Enabled = true;
                    Block8.Enabled = Block7.Enabled = Block6.Enabled = Block5.Enabled = Block4.Enabled = Block3.Enabled = Block2.Enabled = false;
                    Divider7.Enabled = Divider6.Enabled = Divider5.Enabled = Divider4.Enabled = Divider3.Enabled = Divider2.Enabled = Divider1.Enabled = false;
                    break;

                case 0:
                    Block8.Enabled = Block7.Enabled = Block6.Enabled = Block5.Enabled = Block4.Enabled = Block3.Enabled = Block2.Enabled = Block1.Enabled = false;
                    Divider7.Enabled = Divider6.Enabled = Divider5.Enabled = Divider4.Enabled = Divider3.Enabled = Divider2.Enabled = Divider1.Enabled = false;
                    break;

                default:
                    break;
            }
        }

        private void CheckBlock(string s, Response1 res)
        {
            switch (s)
            {
                case "Авторы":
                    FormAuthorsList(res, richTextBox1);
                    break;

                case "Название статьи":
                    FormTitle(res, richTextBox1);
                    break;

                case "Название журнала":
                    FormJournalName(res, richTextBox1);
                    break;

                case "DOI":
                    FormDOI(richTextBox1);
                    break;

                case "Год":
                    FormYear(res, richTextBox1);
                    break;

                case "Том":
                    FormThome(res, richTextBox1);
                    break;

                case "Издание":
                    FormNumber(res, richTextBox1);
                    break;

                case "Страницы или номер":
                    FormPage(res, richTextBox1);
                    break;
            }
        }

        private void FormBlockList()
        {
            Block1.Items.Clear(); Block2.Items.Clear();
            Block3.Items.Clear(); Block4.Items.Clear();
            Block5.Items.Clear(); Block6.Items.Clear();
            Block7.Items.Clear(); Block8.Items.Clear();

            Block1.Items.AddRange(blocks.ToArray()); Block2.Items.AddRange(blocks.ToArray());
            Block3.Items.AddRange(blocks.ToArray()); Block4.Items.AddRange(blocks.ToArray());
            Block5.Items.AddRange(blocks.ToArray()); Block6.Items.AddRange(blocks.ToArray());
            Block7.Items.AddRange(blocks.ToArray()); Block8.Items.AddRange(blocks.ToArray());
        }


        //LOAD FILE

        //Для обработки .doc | .docx
        private void OpenWordprocessingDocumentReadonly(string filepath)
        {
            // Open a WordprocessingDocument based on a filepath.

            using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Open(filepath, false))
            {
                // Assign a reference to the existing document body.  

                Body body = wordDocument.MainDocumentPart.Document.Body;

                if (body.InnerText == "")
                {
                    return;
                }

                //text of Docx file 
                //return body.InnerText.ToString();
                //List<string> result = new List<string>();
                var bodyElements = body.ChildElements;
                for (int i = 0; i < bodyElements.Count; i++)
                    //Проверка на пробел и строка без символов.
                    if (bodyElements[i].InnerText != " " && bodyElements[i].InnerText != "")
                    {
                        //Если нет нумерации, то сразу добавить

                        if (!char.IsDigit(bodyElements[i].InnerText[0]))
                        {
                            doiContentList.Add(bodyElements[i].InnerText.ToString());
                        }

                        //Начало проверки на нумерацию, проверка на первую цифру

                        else if (bodyElements[i].InnerText[1] == '.' || bodyElements[i].InnerText[1] == ')')
                        {
                            if (bodyElements[i].InnerText[2] == ' ' || 
                                bodyElements[i].InnerText[2].ToString() == " " ||
                                Char.IsWhiteSpace(bodyElements[i].InnerText[2]))
                            {
                                string doiWordEl = bodyElements[i].InnerText.Substring(3);

                                //Убрать возвр. коретки

                                if (bodyElements[i].InnerText.EndsWith('\r'))
                                {
                                    doiWordEl = doiWordEl.TrimEnd('\r');
                                    doiContentList.Add(doiWordEl);
                                }

                                //Убрать табы

                                else if (bodyElements[i].InnerText.EndsWith('\t'))
                                {
                                    doiWordEl = doiWordEl.TrimEnd('\t');
                                    doiContentList.Add(doiWordEl);
                                }

                                //Если нет спец. знаков, то просто добавить в список

                                else
                                {
                                    doiContentList.Add(doiWordEl);
                                }

                            }

                            else if (char.IsDigit(bodyElements[i].InnerText[1]))
                            {
                                if (bodyElements[i].InnerText[2] == '.' || bodyElements[i].InnerText[2] == ')')
                                {
                                    if (bodyElements[i].InnerText[3] == ' ' || 
                                        bodyElements[i].InnerText[3].ToString() == " " ||
                                        Char.IsWhiteSpace(bodyElements[i].InnerText[3]))
                                    {
                                        string doiWordEl = bodyElements[i].InnerText.Substring(4);

                                        //Убрать возвр. коретки

                                        if (bodyElements[i].InnerText.EndsWith('\r'))
                                        {
                                            doiWordEl = doiWordEl.TrimEnd('\r');

                                            doiContentList.Add(doiWordEl);
                                        }

                                        //Убрать табы

                                        else if (bodyElements[i].InnerText.EndsWith('\t'))
                                        {
                                            doiWordEl = doiWordEl.TrimEnd('\t');

                                            doiContentList.Add(doiWordEl);
                                        }

                                        //Если нет спец. знаков, то просто добавить в список

                                        else
                                        {
                                            doiContentList.Add(doiWordEl);
                                        }
                                    }
                                }
                            }
                        }
                    }
            }
        }

        private void GetDoiFromFileNames(string[] arrAllFiles)
        {
            var txtContent = string.Empty;

            for (int i = 0; i < arrAllFiles.Length; i++)
            {
                //Проверка, если файл формата .txt

                if (arrAllFiles[i].EndsWith(".txt"))
                {
                    using (StreamReader reader = new StreamReader(arrAllFiles[i]))
                    {
                        txtContent = reader.ReadToEnd();
                    }

                    //Юзаю регулярку, убираю лишнее
                    string txtBody = Regex.Replace(txtContent, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);

                    //Альтернативный вариант
                    //string resultTxtString = Regex.Replace(txtContent, @"^\s+", string.Empty, RegexOptions.Multiline);

                    //char[] delimiterChars = { '\r', '\n' };
                    //char[] delimiterChars = { '\n' };

                    string[] txtLines = txtBody.Split('\n');

                    foreach (var txtLine in txtLines)
                    {
                        //Проверка на пустую строку/пробел

                        if (txtLine == " " || txtLine == "")
                        {
                            continue;
                        }

                        //Начало проверки на нумерацию, проверка на первую цифру

                        if (char.IsDigit(txtLine[0]))
                        {
                            if (txtLine[1] == '.' || txtLine[1] == ')')
                            {
                                if (txtLine[2] == ' ')
                                {
                                    string doiTxtEl = txtLine.Substring(3);

                                    //Убрать возвр. коретки

                                    if (txtLine.EndsWith('\r'))
                                    {
                                        doiTxtEl = doiTxtEl.TrimEnd('\r');
                                        doiContentList.Add(doiTxtEl);
                                    }

                                    //Убрать табы

                                    else if (txtLine.EndsWith('\t'))
                                    {
                                        doiTxtEl = doiTxtEl.TrimEnd('\t');
                                        doiContentList.Add(doiTxtEl);
                                    }

                                    //Если нет спец. знаков, то просто добавить в список

                                    else
                                    {
                                        doiContentList.Add(doiTxtEl);
                                    }
                                }
                            }

                            else if (char.IsDigit(txtLine[1]))
                            {
                                if (txtLine[2] == '.' || txtLine[2] == ')')
                                {
                                    if (txtLine[3] == ' ')
                                    {
                                        string doiTxtEl = txtLine.Substring(4);

                                        //Убрать возвр. коретки

                                        if (txtLine.EndsWith('\r'))
                                        {
                                            doiTxtEl = doiTxtEl.TrimEnd('\r');
                                            doiContentList.Add(doiTxtEl);
                                        }

                                        //Убрать табы

                                        else if (txtLine.EndsWith('\t'))
                                        {
                                            doiTxtEl = doiTxtEl.TrimEnd('\t');
                                            doiContentList.Add(doiTxtEl);
                                        }

                                        //Если нет спец. знаков, то просто добавить в список

                                        else
                                        {
                                            doiContentList.Add(doiTxtEl);
                                        }
                                    }
                                    else
                                    {
                                        doiContentList.Add(txtLine);
                                    }
                                }
                            }
                        }

                        //Убрать возвр. коретки

                        else if (txtLine.EndsWith('\r'))
                        {
                            string doiTxtEl = txtLine.TrimEnd('\r');
                            doiContentList.Add(doiTxtEl);
                        }

                        //Убрать табы

                        else if (txtLine.EndsWith('\t'))
                        {
                            string doiTxtEl = txtLine.TrimEnd('\t');
                            doiContentList.Add(doiTxtEl);
                        }

                        //Если нет спец. знаков, то просто добавить в список

                        else
                        {
                            doiContentList.Add(txtLine);
                        }
                    }
                }

                //Проверка, если файл формата .docx | .doc

                else if (arrAllFiles[i].EndsWith(".docx") || arrAllFiles[i].EndsWith(".doc"))
                {
                    OpenWordprocessingDocumentReadonly(arrAllFiles[i]);
                }
            }
        }

        //Для открытия выбора файла

        private void openFileDialog()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //Деффолтный путь, откуда брать файлы
                //openFileDialog.InitialDirectory = @"C:\Users\Admin\Desktop";

                openFileDialog.Filter = "Текстовые файлы (*.txt;*.docx;*.doc)|*.txt;*.docx;*.doc|Все файлы (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;

                //Чтобы не запоминал путь
                //openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Читает контент файла в потоке
                    var fileStream = openFileDialog.OpenFile();

                    //FilePath | Путь файла
                    //string fileName = openFileDialog.FileName;
                    string[] arrAllFiles = openFileDialog.FileNames; //used when Multiselect = true 

                    GetDoiFromFileNames(arrAllFiles);
                }
            }

        }

        //Drag and drop
        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                panelLabel.Text = "Перетащите файл сюда";
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            panelLabel.Text = "Нажмите, чтобы выбрать файл или перетащите в это поле";
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {

            //var allowedExtensions = new[] { ".text", ".docx", ".doc" };

            //Обработка на "Если файлов несколько" и "Если перекидывается папка с файлами"

            var fileContent = string.Empty;

            List<string> paths = new List<string>();
            List<string> files = new List<string>();

            foreach (string obj in (string[])e.Data.GetData(DataFormats.FileDrop))

                //Если папка c файлами
                if (Directory.Exists(obj))
                {
                    paths.AddRange(Directory.GetFiles(obj, "*.txt", SearchOption.AllDirectories));
                    paths.AddRange(Directory.GetFiles(obj, "*.docx", SearchOption.AllDirectories));
                    paths.AddRange(Directory.GetFiles(obj, "*.doc", SearchOption.AllDirectories));
                }

                //Если одиночный файл
                else
                {

                    //Можно подцепить регулярку
                    //string pattern = @"(?<=.)(txt|doc|docx)(?=.|\z)";

                    paths.Add(obj);
                }

            string[] arrAllFiles = paths.ToArray();

            GetDoiFromFileNames(arrAllFiles);

            //Альтернативный вариант

            //Проверка
            //var formattedPaths = string.Join("\r\n", paths);

            //using (StreamReader reader = new StreamReader(formattedPaths))
            //{
            //    fileContent = reader.ReadToEnd();
            //}

            //doiContentList.Add(fileContent);

            ////Проверка
            //richTextBox1.Text = fileContent;

            panelLabel.Text = "Нажмите, чтобы выбрать файл или перетащите в это поле";
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            openFileDialog();
        }

        private void panelLabel_Click(object sender, EventArgs e)
        {
            openFileDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog();
        }
    }
}