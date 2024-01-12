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
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using static System.Reflection.Metadata.BlobBuilder;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int blocksCount;
        RequestsHandler handler;
        Regex regex = new Regex(@"[A-Z]");
        MatchCollection matches;
        List<string> blocksRU = new List<string> { "������", "�������� ������",
            "�������� �������", "DOI", "���", "���", "�������", "�������� ��� �����"};        
        List<string> blocksEN = new List<string> { "Author(s)", "Article title",
            "Journal title", "DOI", "Year", "Thome", "Issue", "Page(s) or article number"};
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

            DOIinput.Text = "https://doi.org/10.15826/chimtech.2020.7.1.02";

            Block1.Items.Clear(); Block2.Items.Clear(); Block3.Items.Clear();
            Block4.Items.Clear(); Block5.Items.Clear(); Block6.Items.Clear();
            Block7.Items.Clear(); Block8.Items.Clear(); 

            Block1.Items.AddRange(blocksRU.ToArray()); Block2.Items.AddRange(blocksRU.ToArray());
            Block3.Items.AddRange(blocksRU.ToArray()); Block4.Items.AddRange(blocksRU.ToArray());
            Block5.Items.AddRange(blocksRU.ToArray()); Block6.Items.AddRange(blocksRU.ToArray());
            Block7.Items.AddRange(blocksRU.ToArray()); Block8.Items.AddRange(blocksRU.ToArray());

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
                richTextBox1.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    richTextBox1.AppendText("������, ������ ����.");
                }
                else
                {
                    richTextBox1.AppendText("Error, empty field.");
                }
                richTextBox1.SelectionColor = System.Drawing.Color.Black;
                return;
            }

            Response1 res = await handler.GetMetadata(DOIinput.Text);
            res.DOI = DOIinput.Text.Replace("https://doi.org/", "").TrimEnd(' ').TrimStart(' ');

            if (res.status == "error")
            {
                richTextBox1.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    richTextBox1.AppendText("������, ������������ ����.");
                }
                else
                {
                    richTextBox1.AppendText("Error, wrong input.");
                }
                richTextBox1.SelectionColor = System.Drawing.Color.Black;
                return;
            }

            if (Block1.Text != "" && Block1.Enabled)
                CheckBlock(Block1.Text, res);

            if (Block2.Text != "" && Block2.Enabled)
            {
                if (richTextBox1.Text.Last() == '.')
                    richTextBox1.AppendText(Divider1.Text.Trim('"').Replace(".", ""));
                else
                    richTextBox1.AppendText(Divider1.Text.Trim('"'));

                CheckBlock(Block2.Text, res);
            }

            if (Block3.Text != "" && Block3.Enabled)
            {
                if (richTextBox1.Text.Last() == '.')
                    richTextBox1.AppendText(Divider2.Text.Trim('"').Replace(".", ""));
                else
                    richTextBox1.AppendText(Divider2.Text.Trim('"'));

                CheckBlock(Block3.Text, res);
            }

            if (Block4.Text != "" && Block4.Enabled)
            {
                if (richTextBox1.Text.Last() == '.')
                    richTextBox1.AppendText(Divider3.Text.Trim('"').Replace(".", ""));
                else
                    richTextBox1.AppendText(Divider3.Text.Trim('"'));

                CheckBlock(Block4.Text, res);
            }

            if (Block5.Text != "" && Block5.Enabled)
            {
                if (richTextBox1.Text.Last() == '.')
                    richTextBox1.AppendText(Divider4.Text.Trim('"').Replace(".", ""));
                else
                    richTextBox1.AppendText(Divider4.Text.Trim('"'));

                CheckBlock(Block5.Text, res);
            }

            if (Block6.Text != "" && Block6.Enabled)
            {
                if (richTextBox1.Text.Last() == '.')
                    richTextBox1.AppendText(Divider5.Text.Trim('"').Replace(".", ""));
                else
                    richTextBox1.AppendText(Divider5.Text.Trim('"'));

                CheckBlock(Block6.Text, res);
            }

            if (Block7.Text != "" && Block7.Enabled)
            {
                if (richTextBox1.Text.Last() == '.')
                    richTextBox1.AppendText(Divider6.Text.Trim('"').Replace(".", ""));
                else
                    richTextBox1.AppendText(Divider6.Text.Trim('"'));

                CheckBlock(Block7.Text, res);
            }

            if (Block8.Text != "" && Block8.Enabled)
            {
                if (richTextBox1.Text.Last() == '.')
                    richTextBox1.AppendText(Divider7.Text.Trim('"').Replace(".", ""));
                else
                    richTextBox1.AppendText(Divider7.Text.Trim('"'));

                CheckBlock(Block8.Text, res);
            }

            if (ButtonChangeLang.Text == "EN")
            {
                if (End.Text != "�����������")
                    richTextBox1.AppendText(End.Text.Trim('"'));
            }
            else
            {
                if (End.Text != "n/a")
                    richTextBox1.AppendText(End.Text.Trim('"'));
            }
        }

        private void AuthsLimitCheck_Click(object sender, EventArgs e)
        {
            if (AuthsLimitCheck.Checked)
            {
                AuthorsNumber.Enabled = true;
                AuthorsLimiter.Enabled = true;
                AndCheck.Enabled = false;
                AndCheck.Checked = false;
            }
            else
            {
                AuthorsNumber.Enabled = false;
                AuthorsLimiter.Enabled = false;
                AndCheck.Enabled = true;
            }
        }

        async void FormAuthorsList(Response1 response, RichTextBox rtb)
        {
            var authors = response.message.author;

            if (authors.Length == 0 || authors == null)
            {
                rtb.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    rtb.AppendText("��������� ������ � ����� \"������\"");
                }
                else
                {
                    rtb.AppendText("Error in block \"Author(s)\"");
                }
                rtb.SelectionColor = System.Drawing.Color.Black;
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

            if (AuthPosDropList.Text == "��������/�������" || AuthPosDropList.Text == "Initials/Surname")
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
            if (response.message.title.Length == 0 || response.message.title == null)
            {
                rtb.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    rtb.AppendText("��������� ������ � ����� \"�������� ������\"");
                }
                else
                {
                    rtb.AppendText("Error in block \"Article title\"");
                }
                rtb.SelectionColor = System.Drawing.Color.Black;
                return;
            }

            string title = response.message.title[0];

            if (title == "")
            {
                rtb.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    rtb.AppendText("��������� ������ � ����� \"�������� ������\"");
                }
                else
                {
                    rtb.AppendText("Error in block \"Article title\"");
                }
                rtb.SelectionColor = System.Drawing.Color.Black;
                return;
            }

            //title = Regex.Replace(title.Replace("\n", ""), @"\s\s+", "");

            switch (ArticleNameDropList.SelectedItem)
            {
                case "�������� � ������ ��������":
                case "Lower-case words":
                    title = Regex.Replace(title, @"\W[A-Z][a-z]+\s", m => m.Value.ToLower());
                    break;      

                case "�������� � ���������� �������":
                case "Upper-case words":
                    title = (Regex.Replace(Regex.Replace(title, @"\b(\w)", m => m.Value.ToUpper()),
                        @"(\s(of|in|by|and|the|a|an|at|on|under|above|between|to|into|out of|from|through|along|across|before|after|till|until|ago|during|since|for|because of|due to|thanks to|in accordance with|against|behind|below|around|towards|back to|in front of|outside|on account of|upon)|\'[st])\b",
                        m => m.Value.ToLower(), RegexOptions.IgnoreCase));
                    break;

                default:
                    break;
            }

            title = Regex.Replace(title, @"<.*?>|</.*?>", "");
            title = Regex.Replace(title, @"\[sub .+?\]", m => m.Value.Replace("[sub ", "").Replace("]", ""));
            rtb.AppendText(title);
        }

        async void FormJournalName(Response1 response, RichTextBox rtb)
        {
            if (response.message.container_title.Length == 0 || response.message.container_title == null)
            {
                rtb.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    rtb.AppendText("��������� ������ � ����� \"�������� �������\"");
                }
                else
                {
                    rtb.AppendText("Error in block \"Journal title\"");
                }
                rtb.SelectionColor = System.Drawing.Color.Black;
                return;
            }

            var journal = response.message.container_title[0];

            journal = Regex.Replace(journal, @"&amp;", "&");

            if (journal == "" || journal == null)
            {
                rtb.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    rtb.AppendText("��������� ������ � ����� \"�������� �������\"");
                }
                else
                {
                    rtb.AppendText("Error in block \"Journal title\"");
                }
                rtb.SelectionColor = System.Drawing.Color.Black;
                return;
            }

            if (JournalTitleItalic.Checked)
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Italic);

            switch (JournalNameDropList.SelectedItem)
            {
                case "������":
                case "Full name":
                    rtb.AppendText(journal);
                    rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
                    return;

                case "������������":
                case "Abbr":
                    Aspose.Cells.Workbook wb = new Aspose.Cells.Workbook("Journals.xlsx");
                    Aspose.Cells.Worksheet worksheet = wb.Worksheets[0];
                    Dictionary<int, string> pairs = new Dictionary<int, string>();
                    journal = Regex.Replace(journal, @"(\b(of|in|by|and|the|an|at|on|under|above|between|to|into|out of|from|through|along|across|before|after|till|until|ago|during|since|for|because of|due to|thanks to|in accordance with|against|behind|below|around|towards|back to|in front of|outside|on account of|upon)\b) | \ba\s",
                        "", RegexOptions.IgnoreCase);
                    journal = Regex.Replace(journal.TrimStart(' ', '-', '�').TrimEnd(' ', '-', '�'), @"\s\s+", " ");

                    if (journal.Split(' ', '-', '�').Length == 1)
                    {
                        rtb.AppendText(journal);
                        rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
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
                    rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
                    return;

                default:
                    rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
                    return;
            }
        }

        async void FormDOI(Response1 res, RichTextBox rtb)
        {
            var DOI = res.DOI;

            switch (DOIDropList.SelectedItem)
            {
                case "��� url-������":
                case "url-type":
                    rtb.AppendText($"https://doi.org/{DOI}");
                    return;

                case "�����������":
                case "short":
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
                    rtb.SelectionColor = System.Drawing.Color.Red;
                    if (ButtonChangeLang.Text == "EN")
                    {
                        rtb.AppendText("��������� ������ � ����� \"���\"");
                    }
                    else
                    {
                        rtb.AppendText("Error in block \"Year\"");
                    }
                    rtb.SelectionColor = System.Drawing.Color.Black;
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
                rtb.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    rtb.AppendText("��������� ������ � ����� \"���\"");
                }
                else
                {
                    rtb.AppendText("Error in block \"Thome\"");
                }
                rtb.SelectionColor = System.Drawing.Color.Black;
                return;
            }

            if (IssueThomePart.Checked)
            {
                if (response.message.issue != null && response.message.issue != "")
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
                rtb.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    rtb.AppendText("��������� ������ � ����� \"�������\"");
                }
                else
                {
                    rtb.AppendText("Error in block \"Issue\"");
                }
                rtb.SelectionColor = System.Drawing.Color.Black;
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
                rtb.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    rtb.AppendText("��������� ���� ������ ������");
                }
                else
                {
                    rtb.AppendText("It is necessary to enter the article number");
                }
                rtb.SelectionColor = System.Drawing.Color.Black;
                return;
            }

            if (PageOnePage.Checked)
            {
                int divInd = page.IndexOf('-');
                if (divInd == -1)
                {
                    divInd = page.IndexOf('�');
                }

                if (divInd != -1)
                    page = page.Substring(0, divInd);
            }

            if (PagesDivider.Text == "����� ����" || PagesDivider.Text == "With dash")
                page = page.Replace("-", "�");

            else if (PagesDivider.Text == "����� �����" || PagesDivider.Text == "With hyphen")
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
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Add("������");
                }
                else
                {
                    blocksEN.Add("Author(s)");
                }
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Remove("������");
                    ClearBlock("������");
                }
                else
                {
                    blocksEN.Remove("Author(s)");
                    ClearBlock("Author(s)");
                }
            }

            FormBlockList();
        }

        private void TitleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (TitleCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Add("�������� ������");
                }
                else
                {
                    blocksEN.Add("Article title");
                }
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Remove("�������� ������");
                    ClearBlock("�������� ������");
                }
                else
                {
                    blocksEN.Remove("Article title");
                    ClearBlock("Article title");
                }
            }

            FormBlockList();
        }

        private void JournalCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (JournalCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Add("�������� �������");
                }
                else
                {
                    blocksEN.Add("Journal title");
                }
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Remove("�������� �������");
                    ClearBlock("�������� �������");
                }
                else
                {
                    blocksEN.Remove("Journal title");
                    ClearBlock("Journal title");
                }
            }

            FormBlockList();
        }

        private void DOICheck_CheckedChanged(object sender, EventArgs e)
        {
            if (DOICheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Add("DOI");
                }
                else
                {
                    blocksEN.Add("DOI");
                }
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Remove("DOI");
                    ClearBlock("DOI");
                }
                else
                {
                    blocksEN.Remove("DOI");
                    ClearBlock("DOI");
                }
            }

            FormBlockList();
        }

        private void YearCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (YearCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Add("���");
                }
                else
                {
                    blocksEN.Add("Year");
                }
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Remove("���");
                    ClearBlock("���");
                }
                else
                {
                    blocksEN.Remove("Year");
                    ClearBlock("Year");
                }
            }

            FormBlockList();
        }

        private void ThomeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ThomeCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Add("���");
                }
                else
                {
                    blocksEN.Add("Thome");
                }
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Remove("���");
                    ClearBlock("���");
                }
                else
                {
                    blocksEN.Remove("Thome");
                    ClearBlock("Thome");
                }
            }

            FormBlockList();
        }

        private void IssueCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (IssueCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Add("�������");
                }
                else
                {
                    blocksEN.Add("Issue");
                }
            }
            else if (!IssueCheck.Checked)
            {
                if (!IssueThomePart.Checked)
                    blocksCount -= 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Remove("�������");
                    ClearBlock("�������");
                }
                else
                {
                    blocksEN.Remove("Issue");
                    ClearBlock("Issue");
                }
            }

            FormBlockList();
        }

        private void PageCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PageCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Add("�������� ��� �����");
                }
                else
                {
                    blocksEN.Add("Page(s) or article number");
                }
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                if (ButtonChangeLang.Text == "EN")
                {
                    blocksRU.Remove("�������� ��� �����");
                    ClearBlock("�������� ��� �����");
                }
                else
                {
                    blocksEN.Remove("Page(s) or article number");
                    ClearBlock("Page(s) or article number");
                }
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
                case "Author(s)":
                    FormAuthorsList(res, richTextBox1);
                    break;

                case "�������� ������":
                case "Article title":
                    FormTitle(res, richTextBox1);
                    break;

                case "�������� �������":
                case "Journal title":
                    FormJournalName(res, richTextBox1);
                    break;

                case "DOI":
                    FormDOI(res, richTextBox1);
                    break;

                case "���":
                case "Year":
                    FormYear(res, richTextBox1);
                    break;

                case "���":
                case "Thome":
                    FormThome(res, richTextBox1);
                    break;

                case "�������":
                case "Issue":
                    FormIssue(res, richTextBox1);
                    break;

                case "�������� ��� �����":
                case "Page(s) or article number":
                    FormPage(res, richTextBox1);
                    break;
            }
        }

        private void FormBlockList()
        {
            if (ButtonChangeLang.Text == "EN")
            {
                Block1.Items.Clear(); Block2.Items.Clear();
                Block3.Items.Clear(); Block4.Items.Clear();
                Block5.Items.Clear(); Block6.Items.Clear();
                Block7.Items.Clear(); Block8.Items.Clear();

                Block1.Items.AddRange(blocksRU.ToArray()); Block2.Items.AddRange(blocksRU.ToArray());
                Block3.Items.AddRange(blocksRU.ToArray()); Block4.Items.AddRange(blocksRU.ToArray());
                Block5.Items.AddRange(blocksRU.ToArray()); Block6.Items.AddRange(blocksRU.ToArray());
                Block7.Items.AddRange(blocksRU.ToArray()); Block8.Items.AddRange(blocksRU.ToArray());
            }
            else
            {
                Block1.Items.Clear(); Block2.Items.Clear();
                Block3.Items.Clear(); Block4.Items.Clear();
                Block5.Items.Clear(); Block6.Items.Clear();
                Block7.Items.Clear(); Block8.Items.Clear();

                Block1.Items.AddRange(blocksEN.ToArray()); Block2.Items.AddRange(blocksEN.ToArray());
                Block3.Items.AddRange(blocksEN.ToArray()); Block4.Items.AddRange(blocksEN.ToArray());
                Block5.Items.AddRange(blocksEN.ToArray()); Block6.Items.AddRange(blocksEN.ToArray());
                Block7.Items.AddRange(blocksEN.ToArray()); Block8.Items.AddRange(blocksEN.ToArray());
            }
        }

        private void ClearBlock(string s)
        {
            if (Block1.Text == s)
                Block1.Text = "";
            if (Block2.Text == s)
                Block2.Text = "";
            if (Block3.Text == s)
                Block3.Text = "";
            if (Block4.Text == s)
                Block4.Text = "";
            if (Block5.Text == s)
                Block5.Text = "";
            if (Block6.Text == s)
                Block6.Text = "";
            if (Block7.Text == s)
                Block7.Text = "";
            if (Block8.Text == s)
                Block8.Text = "";
        }

        //LOAD FILE

        //����� ����������� ������ 

        private async Task OutputLoadFilesAsync()
        {

            richTextBox1.Text = "";

            if (doiContentList.Count == 0)
            {
                richTextBox1.SelectionColor = System.Drawing.Color.Red;
                if (ButtonChangeLang.Text == "EN")
                {
                    richTextBox1.AppendText("������, ������ ������ ��� �������� ����.");
                }
                else
                {
                    richTextBox1.AppendText("Error, empty list or wrong input.");
                }
                richTextBox1.SelectionColor = System.Drawing.Color.Black;
                return;
            }

            for (int i = 0; i < doiContentList.Count; i++)
            {
                Response1 res = await handler.GetMetadata(doiContentList[i]);
                res.DOI = doiContentList[i].Replace("https://doi.org/", "").TrimEnd(' ').TrimStart(' ');

                if (res.status == "error")
                {
                    richTextBox1.SelectionColor = System.Drawing.Color.Red;
                    if (ButtonChangeLang.Text == "EN")
                    {
                        richTextBox1.AppendText("������, �������� ����.");
                    }
                    else
                    {
                        richTextBox1.AppendText("Error, wrong input.");
                    }
                    richTextBox1.SelectionColor = System.Drawing.Color.Black;
                    richTextBox1.AppendText("\n");
                    continue;
                }

                if (Block1.Text != "" && Block1.Enabled)
                    CheckBlock(Block1.Text, res);

                if (Block2.Text != "" && Block2.Enabled)
                {
                    if (richTextBox1.Text.Last() == '.')
                        richTextBox1.AppendText(Divider1.Text.Trim('"').Replace(".", ""));
                    else
                        richTextBox1.AppendText(Divider1.Text.Trim('"'));

                    CheckBlock(Block2.Text, res);
                }

                if (Block3.Text != "" && Block3.Enabled)
                {
                    if (richTextBox1.Text.Last() == '.')
                        richTextBox1.AppendText(Divider2.Text.Trim('"').Replace(".", ""));
                    else
                        richTextBox1.AppendText(Divider2.Text.Trim('"'));

                    CheckBlock(Block3.Text, res);
                }

                if (Block4.Text != "" && Block4.Enabled)
                {
                    if (richTextBox1.Text.Last() == '.')
                        richTextBox1.AppendText(Divider3.Text.Trim('"').Replace(".", ""));
                    else
                        richTextBox1.AppendText(Divider3.Text.Trim('"'));

                    CheckBlock(Block4.Text, res);
                }

                if (Block5.Text != "" && Block5.Enabled)
                {
                    if (richTextBox1.Text.Last() == '.')
                        richTextBox1.AppendText(Divider4.Text.Trim('"').Replace(".", ""));
                    else
                        richTextBox1.AppendText(Divider4.Text.Trim('"'));

                    CheckBlock(Block5.Text, res);
                }

                if (Block6.Text != "" && Block6.Enabled)
                {
                    if (richTextBox1.Text.Last() == '.')
                        richTextBox1.AppendText(Divider5.Text.Trim('"').Replace(".", ""));
                    else
                        richTextBox1.AppendText(Divider5.Text.Trim('"'));

                    CheckBlock(Block6.Text, res);
                }

                if (Block7.Text != "" && Block7.Enabled)
                {
                    if (richTextBox1.Text.Last() == '.')
                        richTextBox1.AppendText(Divider6.Text.Trim('"').Replace(".", ""));
                    else
                        richTextBox1.AppendText(Divider6.Text.Trim('"'));

                    CheckBlock(Block7.Text, res);
                }

                if (Block8.Text != "" && Block8.Enabled)
                {
                    if (richTextBox1.Text.Last() == '.')
                        richTextBox1.AppendText(Divider7.Text.Trim('"').Replace(".", ""));
                    else
                        richTextBox1.AppendText(Divider7.Text.Trim('"'));

                    CheckBlock(Block8.Text, res);
                }

                if (ButtonChangeLang.Text == "EN")
                {
                    if (End.Text != "�����������")
                        richTextBox1.AppendText(End.Text.Trim('"'));
                }
                else
                {
                    if (End.Text != "n/a")
                        richTextBox1.AppendText(End.Text.Trim('"'));
                }

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

                if (ButtonChangeLang.Text == "EN")
                {
                    openFileDialog.Filter = "��������� ����� (*.txt;*.docx)|*.txt;*.docx|��� ����� (*.*)|*.*";
                }
                else
                {
                    openFileDialog.Filter = "Text files (*.txt;*.docx)|*.txt;*.docx|All files (*.*)|*.*";
                }

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
                if (ButtonChangeLang.Text == "EN")
                {
                    panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
                }
                else
                {
                    panelLabel.Text = "Drag and drop file here";
                }
            }
        }

        //Drag and drop
        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (ButtonChangeLang.Text == "EN")
                {
                    panelLabel.Text = "���������� ���� ����";
                }
                else
                {
                    panelLabel.Text = "Drag file here";
                }

                e.Effect = DragDropEffects.Copy;
            }
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
            }
            else
            {
                panelLabel.Text = "Drag and drop file here";
            }
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

            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "���������...";
            }
            else
            {
                panelLabel.Text = "Wait...";
            }

            await OutputLoadFilesAsync();

            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
            }
            else
            {
                panelLabel.Text = "Drag and drop file here";
            }
        }

        async private void panel1_Click(object sender, EventArgs e)
        {
            doiContentList.Clear();

            openFileDialog();

            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "���������...";
            }
            else
            {
                panelLabel.Text = "Wait...";
            }

            await OutputLoadFilesAsync();

            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
            }
            else
            {
                panelLabel.Text = "Drag and drop file here";
            }
        }

        async private void panelLabel_Click(object sender, EventArgs e)
        {
            doiContentList.Clear();

            openFileDialog();

            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "���������...";
            }
            else
            {
                panelLabel.Text = "Wait...";
            }

            await OutputLoadFilesAsync();

            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
            }
            else
            {
                panelLabel.Text = "Drag and drop file here";
            }
        }

        async private void button1_Click_1(object sender, EventArgs e)
        {
            doiContentList.Clear();

            openFileDialog();

            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "���������...";
            }
            else
            {
                panelLabel.Text = "Wait...";
            }

            await OutputLoadFilesAsync();

            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
            }
            else
            {
                panelLabel.Text = "Drag and drop file here";
            }
        }

        async private void RepeatButton_Click(object sender, EventArgs e)
        {
            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "���������...";
            }
            else
            {
                panelLabel.Text = "Wait...";
            }

            await OutputLoadFilesAsync();

            if (ButtonChangeLang.Text == "EN")
            {
                panelLabel.Text = "�������, ����� ������� ����(�)\n ��� ���������� � ��� ����";
            }
            else
            {
                panelLabel.Text = "Drag and drop file here";
            }
        }

        private void ButtonChangeLang_Click(object sender, EventArgs e)
        {
            if (ButtonChangeLang.Text == "EN")
            {
                ButtonChangeLang.Text = "RU";

                DOIInputButton.Text = "Input";


                AuthorsCheck.Text = "Author(s)";
                authorsBox.Text = "Author(s)";

                AuthorsPosition.Text = "Position";
                AuthPosDropList.Items.Clear();
                AuthPosDropList.Items.Add("Initials/Surname");
                AuthPosDropList.Items.Add("Surname/Initials");

                InitialsDotCheck.Text = "Dot(s) after initials";
                InitialsSpaceCheck.Text = "Space(s) between initials";
                AndCheck.Text = "'and' between penultimate and last";

                //AuthsLimitCheck.Text = "";
                //byte AuthsLimitCheckY = 147;
                AuthsLimitCheck.Location = new Point(8, 133);

                AuthorsDividingInitialsSurname.Text = "dividing mark \nbetween initials \nand surname";
                AuthorsDividingAuthors.Text = "dividing mark \nbetween authors";
                AuthorsNumber.Text = "Authors' number";

                Output.Text = "Output";

                articleBox.Text = "Article title";
                TitleCheck.Text = "Article title";
                ArticleNameDropList.Items.Clear();
                ArticleNameDropList.Items.Add("Lower-case words");
                ArticleNameDropList.Items.Add("Upper-case words");

                journalBox.Text = "Journal title";
                JournalCheck.Text = "Journal title";
                JournalNameDropList.Items.Clear();
                JournalNameDropList.Items.Add("Full name");
                JournalNameDropList.Items.Add("Abbr");
                checkDots.Text = "without dots";
                JournalTitleItalic.Text = "Italic";

                DOIDropList.Items.Clear();
                DOIDropList.Items.Add("short");
                DOIDropList.Items.Add("url-type");

                YearBox.Text = "Year";
                YearCheck.Text = "Year";
                YearBold.Text = "Bold";
                YearItalic.Text = "Italic";
                YearBrackets.Text = "In parentheses";

                ThomeBox.Text = "Volume";
                ThomeCheck.Text = "Volume";
                ThomeBold.Text = "Bold";
                ThomeItalic.Text = "Italic";

                IssueBox.Text = "Issue";
                IssueBox.Size = new Size(170, 91);
                IssueCheck.Text = "Issue";
                IssueThomePart.Text = "To link with volume";
                IssueBold.Text = "Bold";
                IssueBold.Location = new Point(5, 43);
                IssueItalic.Text = "Italic";
                IssueItalic.Location = new Point(5, 66);


                PageBox.Location = new Point(476, 227);
                PageBox.Text = "Page(s) or article number";
                PageCheck.Text = "Page(s) or article number";
                PageBold.Text = "Bold";
                PageItalic.Text = "Italic";
                PageOnePage.Text = "First page only";
                PagesDivider.Items.Clear();
                PagesDivider.Items.Add("With dash");
                PagesDivider.Items.Add("With hyphen");

                BlockLabel.Text = "Blocks";

                Block1.Items.Clear(); Block2.Items.Clear(); Block3.Items.Clear();
                Block4.Items.Clear(); Block5.Items.Clear(); Block6.Items.Clear();
                Block7.Items.Clear(); Block8.Items.Clear();

                Block1.Items.AddRange(blocksEN.ToArray()); Block2.Items.AddRange(blocksEN.ToArray());
                Block3.Items.AddRange(blocksEN.ToArray()); Block4.Items.AddRange(blocksEN.ToArray());
                Block5.Items.AddRange(blocksEN.ToArray()); Block6.Items.AddRange(blocksEN.ToArray());
                Block7.Items.AddRange(blocksEN.ToArray()); Block8.Items.AddRange(blocksEN.ToArray());

                DividingLabel.Text = "Dividing marks";

                EndingLabel.Text = "Ending character";
                End.Items.Clear();
                End.Items.Add("n/a");
                End.Items.Add(";");
                End.Items.Add(".");

                FileSelection.Text = "File selection";
                SupportedFiles.Text = "Supported files:";
                SupportedFormats.Location = new Point(1115, 49);
                panelLabel.Text = "Drag and drop file here";
                ChooseFileButton.Text = "Choose file";
                RepeatButton.Text = "Refresh references";

                AuthPosDropList.SelectedItem = AuthPosDropList.Items[0];
                NameSepDropList.SelectedItem = NameSepDropList.Items[0];
                AuthSepDropList.SelectedItem = AuthSepDropList.Items[0];
                ArticleNameDropList.SelectedItem = ArticleNameDropList.Items[0];
                JournalNameDropList.SelectedItem = JournalNameDropList.Items[0];
                DOIDropList.SelectedItem = DOIDropList.Items[0];
                PagesDivider.SelectedItem = PagesDivider.Items[0];

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

            else if (ButtonChangeLang.Text == "RU")
            {
                //����� ������� �� �������... �����-������.....
            }
        }
    }
}
