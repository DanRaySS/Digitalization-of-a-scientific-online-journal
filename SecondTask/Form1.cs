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
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Vml.Office;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int blocksCount;
        RequestsHandler handler;
        Regex regex = new Regex(@"[A-Z]");
        MatchCollection matches;
        List<string> blocks = new List<string> { "������", "�������� ������",
            "�������� �������", "DOI", "���", "���", "�������", "�������� ��� �����", ""};
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

            Block1.SelectedItem = Block1.Items[0];
            Block2.SelectedItem = Block2.Items[1];
            Block3.SelectedItem = Block3.Items[2];
            Block4.SelectedItem = Block4.Items[3];
            Block5.SelectedItem = Block5.Items[4];
            Block6.SelectedItem = Block6.Items[5];
            Block7.SelectedItem = Block7.Items[6];
            Block8.SelectedItem = Block8.Items[7];
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
            res.DOI = DOIinput.Text.Replace("https://doi.org/", "");

            if (res.status == "error")
            {
                richTextBox1.Text = "Error, wrong input.";
                return;
            }

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

            if (End.Text != "�����������")
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
            var authors = response.message.author;

            if (authors.Length == 0 || authors == null)
            {
                rtb.AppendText("��������� ������ � ����� \"������\"");
                return;
            }

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

            int authorsLength = authors.Length;
            if (AuthsLimitCheck.Checked && authorsLength > (int)AuthorsLimiter.Value)
            {
                authorsLength = (int)AuthorsLimiter.Value;
                prevLarger = true;
            }
            List<string> authorsStr = new List<string>();

            if (AuthPosDropList.Text == "��������/�������")
            {
                for (int i = 0; i < authorsLength; i++)
                {
                    if (authors[i].given == null || authors[i].given == "")
                        firstW = "";
                    else
                    {
                        matches = regex.Matches(authors[i].given);
                        string[] initials = new string[matches.Count];
                        for (int j = 0; j < matches.Count(); j++)
                            initials[j] = $"{matches[j].Value}{initialEnd}";

                        firstW = String.Join(initialsSeparator, initials);
                    }

                    if (authors[i].family == null || authors[i].family == "")
                        secondW = "";
                    else
                        secondW = authors[i].family;

                    if (secondW == "")
                        if (firstW == "")
                            continue;
                        else
                            authorsStr.Add(firstW);
                    else if (firstW == "")
                        authorsStr.Add(secondW);
                    else
                        authorsStr.Add($"{firstW}{nameSeparator}{secondW}");
                }
            }
            else
            {
                for (int i = 0; i < authorsLength; i++)
                {
                    if (authors[i].given == null || authors[i].given == "")
                        secondW = "";
                    else
                    {
                        matches = regex.Matches(authors[i].given);
                        string[] initials = new string[matches.Count];
                        for (int j = 0; j < matches.Count(); j++)
                            initials[j] = $"{matches[j].Value}{initialEnd}";

                        secondW = String.Join(initialsSeparator, initials);
                    }

                    if (authors[i].family == null || authors[i].family == "")
                        firstW = "";
                    else
                        firstW = authors[i].family;

                    if (secondW == "")
                        if (firstW == "")
                            continue;
                        else
                            authorsStr.Add(firstW);
                    else if (firstW == "")
                        authorsStr.Add(secondW);
                    else
                        authorsStr.Add($"{firstW}{nameSeparator}{secondW}");
                }
            }

            if (AndCheck.Checked && authorsLength >= 2)
            {
                string lastAuthor = authorsStr.Last();
                List<string> tempAuthorsStr = new List<string>(authorsStr);
                tempAuthorsStr.RemoveAt(authorsLength - 1);
                authorsStr = tempAuthorsStr;
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
            if (response.message == null)
            {
                rtb.AppendText("��������� ������ � ����� \"�������� ������\"");
                return;
            }

            string title = response.message.title[0];

            if (title == "")
            {
                rtb.AppendText("��������� ������ � ����� \"�������� ������\"");
                return;
            }

            switch (ArticleNameDropList.SelectedItem)
            {
                case "�������� � ������ ��������":
                    title = Regex.Replace(title, @"\W[A-Z][a-z]+\s", m => m.Value.ToLower());
                    break;

                case "�������� � ���������� �������":
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
            if (response.message.container_title.Length == 0 || response.message.container_title == null)
            {
                rtb.AppendText("��������� ������ � ����� \"�������� �������\"");
                return;
            }

            var journal = response.message.container_title[0];

            journal = Regex.Replace(journal, @"&amp;", "&");

            if (journal == "" || journal == null)
            {
                rtb.AppendText("��������� ������ � ����� \"�������� �������\"");
                return;
            }

            switch (JournalNameDropList.SelectedItem)
            {
                case "������":
                    rtb.AppendText(journal);
                    return;

                case "������������":
                    Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook("Journals.xlsx");
                    Aspose.Cells.Worksheet worksheet = wb.Worksheets[0];
                    Dictionary<int, string> pairs = new Dictionary<int, string>();
                    journal = Regex.Replace(journal, @"(\b(of|in|by|and|the|an|at|on|under|above|between|to|into|out of|from|through|along|across|before|after|till|until|ago|during|since|for|because of|due to|thanks to|in accordance with|against|behind|below|around|towards|back to|in front of|outside|on account of|upon)\b) | \ba\s",
                        "", RegexOptions.IgnoreCase);
                    journal = Regex.Replace(journal.TrimStart(' ', '-', '�').TrimEnd(' ', '-', '�'), @"\s\s+", " ");

                    if (journal.Split(' ', '-', '�').Length == 1)
                    {
                        rtb.AppendText(journal);
                        return;
                    }

                    for (int i = 0; i < worksheet.Cells.MaxDataRow; i++)
                    {
                        string mask;

                        if (worksheet.Cells[i, 0].Value.ToString().Last() == '-')
                        {
                            mask = $@"\b({worksheet.Cells[i, 0].Value.ToString().TrimStart('=').TrimEnd('-')})\w*";
                        }
                        else mask = $@"\b({worksheet.Cells[i, 0].Value.ToString().TrimStart('=')})\b";

                        if (Regex.Match(journal, mask, RegexOptions.IgnoreCase).Value.ToString() != "")
                        {
                            if (Regex.Match(journal, mask, RegexOptions.IgnoreCase).Value.ToString().Length -
                                worksheet.Cells[i, 0].Value.ToString().TrimStart('=').TrimEnd('-').Length == 1
                                && worksheet.Cells[i, 1].Value.ToString().Length >=
                                Regex.Match(journal, mask, RegexOptions.IgnoreCase).Value.ToString().Length)
                                continue;
                            else
                                pairs.Add(i, mask);
                        }
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

        async void FormDOI(Response1 res, RichTextBox rtb)
        {
            var DOI = res.DOI;

            switch (DOIDropList.SelectedItem)
            {
                case "��� url-������":
                    rtb.AppendText($"https://doi.org/{DOI}");
                    return;

                case "�����������":
                    rtb.AppendText(DOI);
                    return;

                default:
                    return;
            }
        }

        async void FormYear(Response1 response, RichTextBox rtb)
        {
            string year;

            if (response.message.published_print == null)
                if (response.message.created == null)
                {
                    rtb.AppendText("��������� ������ � ����� \"���\"");
                    return;
                }
                else
                    year = response.message.created.date_parts[0][0].ToString();
            else
                year = response.message.published_print.date_parts[0][0].ToString();

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

            if (thome == "" || thome == null)
            {
                rtb.AppendText("��������� ������ � ����� \"���\"");
                return;
            }

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

        async void FormIssue(Response1 response, RichTextBox rtb)
        {
            var issue = response.message.issue;

            if (issue == "" || issue == null)
            {
                rtb.AppendText("��������� ������ � ����� \"�������\"");
                return;
            }

            if (IssueBold.Checked && IssueItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold | FontStyle.Italic);
                rtb.AppendText(issue);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else if (IssueBold.Checked && !IssueItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold);
                rtb.AppendText(issue);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else if (!IssueBold.Checked && IssueItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Italic);
                rtb.AppendText(issue);
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
            }
            else
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
                rtb.AppendText(issue);
            }
        }

        async void FormPage(Response1 response, RichTextBox rtb)
        {
            var page = response.message.page;

            if (page == null)
            {
                rtb.AppendText("��������� ���� ������ ������");
                return;
            }

            if (checkOnePage.Checked)
            {
                int divInd = page.IndexOf('-');
                if (divInd == -1)
                {
                    divInd = page.IndexOf('�');
                }

                if (divInd != -1)
                    page = page.Substring(0, divInd);
            }

            if (PagesDivider.Text == "����� ����")
                page = page.Replace("-", "�");

            else if (PagesDivider.Text == "����� �����")
                page = page.Replace("�", "-");

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
                blocks.Add("������");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("������");
            }

            FormBlockList();
        }

        private void TitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (TitleCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("�������� ������");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("�������� ������");
            }

            FormBlockList();
        }

        private void JournalCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (JournalCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("�������� �������");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("�������� �������");
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
                blocks.Add("���");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("���");
            }

            FormBlockList();
        }

        private void ThomeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ThomeCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("���");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("���");
            }

            FormBlockList();
        }

        private void IssueCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (IssueCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("�������");
            }
            else if (!IssueCheck.Checked)
            {
                if (!IssueThomePart.Checked)
                    blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("�������");
            }

            FormBlockList();
        }

        private void PageCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PageCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("�������� ��� �����");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("�������� ��� �����");
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
                case "������":
                    FormAuthorsList(res, richTextBox1);
                    break;

                case "�������� ������":
                    FormTitle(res, richTextBox1);
                    break;

                case "�������� �������":
                    FormJournalName(res, richTextBox1);
                    break;

                case "DOI":
                    FormDOI(res, richTextBox1);
                    break;

                case "���":
                    FormYear(res, richTextBox1);
                    break;

                case "���":
                    FormThome(res, richTextBox1);
                    break;

                case "�������":
                    FormIssue(res, richTextBox1);
                    break;

                case "�������� ��� �����":
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

        //����� ����������� ������ 

        private async Task OutputLoadFilesAsync()
        {

            richTextBox1.Text = "";

            if (doiContentList.Count == 0)
            {
                richTextBox1.Text = "Error, empty list or wrong input.";
                return;
            }

            for (int i = 0; i < doiContentList.Count; i++)
            {
                Response1 res = await handler.GetMetadata(doiContentList[i]);
                res.DOI = doiContentList[i].Replace("https://doi.org/", "");

                if (res.status == "error")
                {
                    richTextBox1.Text = "Error, wrong input.";
                    richTextBox1.AppendText("\n");
                    continue;
                }

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

                if (End.Text != "�����������")
                    richTextBox1.AppendText(End.Text.Trim('"'));

                richTextBox1.AppendText("\n");
            }
        }

        //�������� �� ��������� 

        private void CheckOnNumeration(string txtLine)
        {
            if (!char.IsDigit(txtLine[0]))
            {
                if (!char.IsDigit(txtLine[1]))
                {
                    doiContentList.Add(txtLine);
                    return;
                }
            }

            if (txtLine[1] != '.')
            {
                if (txtLine[1] != ')')
                {
                    if (txtLine[2] != '.')
                    {
                        if (txtLine[2] != ')')
                        {
                            doiContentList.Add(txtLine);
                            return;
                        }
                    }
                }
            }

            string doiTxtEl = string.Empty;

            if (txtLine[2] != ' ' && !string.IsNullOrWhiteSpace(txtLine[2].ToString()))
            {
                if (txtLine[3] != ' ' && !string.IsNullOrWhiteSpace(txtLine[3].ToString()))
                {
                    doiContentList.Add(txtLine);
                    return;
                }

                else
                {
                    doiTxtEl = txtLine.Substring(4);
                }
            }

            else
            {
                doiTxtEl = txtLine.Substring(3);
            }

            //������ �����. ������� � ����

            if (!txtLine.EndsWith('\r'))
            {
                if (!txtLine.EndsWith('\t'))
                {
                    doiContentList.Add(doiTxtEl);
                    return;
                }
            }

            if (txtLine.EndsWith('\r'))
            {
                doiTxtEl = doiTxtEl.TrimEnd('\r');
                if (doiTxtEl.EndsWith('\t'))
                {
                    doiTxtEl = doiTxtEl.TrimEnd('\t');
                    doiContentList.Add(doiTxtEl);
                    return;
                }
                doiContentList.Add(doiTxtEl);
                return;
            }

            else if (txtLine.EndsWith('\t'))
            {
                doiTxtEl = doiTxtEl.TrimEnd('\t');
                if (doiTxtEl.EndsWith('\r'))
                {
                    doiTxtEl = doiTxtEl.TrimEnd('\r');
                    doiContentList.Add(doiTxtEl);
                    return;
                }
                doiContentList.Add(doiTxtEl);
                return;
            }

            //���� ��� ����. ������, �� ������ �������� � ������

            doiContentList.Add(doiTxtEl);
        }

        //��� ��������� .docx
        private void ReadWordDocument(string filepath)
        {
            // Open a Document based on a filepath.

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
                    //�������� �� ������ � ������ ��� ��������.
                    if (bodyElements[i].InnerText != " " && bodyElements[i].InnerText != "")
                    {
                        //���� ��� ���������, �� ����� ��������

                        string bodyElement = bodyElements[i].InnerText.ToString();

                        CheckOnNumeration(bodyElement);

                    }
            }
        }

        private void GetDoiFromFileNames(string[] arrAllFiles)
        {
            var txtContent = string.Empty;

            for (int i = 0; i < arrAllFiles.Length; i++)
            {
                //��������, ���� ���� ������� .txt || .docx

                var pathOfFile = arrAllFiles[i];

                if (!pathOfFile.EndsWith(".txt") && !pathOfFile.EndsWith(".docx"))
                {
                    //���������������� ������ �����.

                    //panelLabel.Text = "���������������� ������ �����";

                    return;
                }

                if (pathOfFile.EndsWith(".docx"))
                {
                    ReadWordDocument(pathOfFile);
                }

                //����� ������� .txt

                else
                {

                    using (StreamReader reader = new StreamReader(pathOfFile))
                    {
                        txtContent = reader.ReadToEnd();
                    }

                    //���� ���������, ������ ������
                    string txtBody = Regex.Replace(txtContent, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);

                    //�������������� �������
                    //string resultTxtString = Regex.Replace(txtContent, @"^\s+", string.Empty, RegexOptions.Multiline);

                    //char[] delimiterChars = { '\r', '\n' };
                    //char[] delimiterChars = { '\n' };

                    string[] txtLines = txtBody.Split('\n');

                    foreach (var txtLine in txtLines)
                    {
                        //�������� �� ������ ������/������

                        if (txtLine == " " || txtLine == "")
                        {
                            continue;
                        }

                        //������ �������� �� ���������

                        CheckOnNumeration(txtLine);
                    }
                }
            }
        }

        //��� �������� ������ �����

        private void openFileDialog()
        {

            //richTextBox1.Size = new Size(200, 900);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //���������� ����, ������ ����� �����
                //openFileDialog.InitialDirectory = @"C:\Users\Admin\Desktop";

                openFileDialog.Filter = "��������� ����� (*.txt;*.docx)|*.txt;*.docx|��� ����� (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;

                //����� �� ��������� ����
                //openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {

                    //������ ������� ����� � ������
                    var fileStream = openFileDialog.OpenFile();

                    //FilePath | ���� �����
                    //string fileName = openFileDialog.FileName;z
                    string[] arrAllFiles = openFileDialog.FileNames; //used when Multiselect = true 

                    GetDoiFromFileNames(arrAllFiles);
                }
                panelLabel.Text = "�������, ����� ������� ���� ��� ���������� � ��� ����";
            }
        }

        //Drag and drop
        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                panelLabel.Text = "���������� ���� ����";
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            panelLabel.Text = "�������, ����� ������� ���� ��� ���������� � ��� ����";
        }

        async private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            doiContentList.Clear();

            //var allowedExtensions = new[] { ".text", ".docx", ".doc" };

            //��������� �� "���� ������ ���������" � "���� �������������� ����� � �������"

            var fileContent = string.Empty;

            List<string> paths = new List<string>();
            List<string> files = new List<string>();

            foreach (string obj in (string[])e.Data.GetData(DataFormats.FileDrop))

                //���� ����� c �������
                if (Directory.Exists(obj))
                {
                    paths.AddRange(Directory.GetFiles(obj, "*.txt", SearchOption.AllDirectories));
                    paths.AddRange(Directory.GetFiles(obj, "*.docx", SearchOption.AllDirectories));
                }

                //���� ��������� ����
                else
                {

                    //����� ��������� ���������
                    //string pattern = @"(?<=.)(txt|docx)(?=.|\z)";

                    paths.Add(obj);
                }

            string[] arrAllFiles = paths.ToArray();

            doiContentList.Clear();

            GetDoiFromFileNames(arrAllFiles);

            panelLabel.Text = "���������...";

            await OutputLoadFilesAsync();

            panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
        }

        async private void panel1_Click(object sender, EventArgs e)
        {
            doiContentList.Clear();

            openFileDialog();

            panelLabel.Text = "���������...";

            await OutputLoadFilesAsync();

            panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
        }

        async private void panelLabel_Click(object sender, EventArgs e)
        {
            doiContentList.Clear();

            openFileDialog();

            panelLabel.Text = "���������...";

            await OutputLoadFilesAsync();

            panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
        }

        async private void button1_Click_1(object sender, EventArgs e)
        {
            doiContentList.Clear();

            openFileDialog();

            panelLabel.Text = "���������...";

            await OutputLoadFilesAsync();

            panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
        }

        async private void RepeatButton_Click(object sender, EventArgs e)
        {
            panelLabel.Text = "���������...";

            await OutputLoadFilesAsync();

            panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
        }
    }
}
