using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Aspose.Cells;
using System.Collections.Generic;
using Microsoft.VisualBasic.Devices;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int blocksCount;
        RequestsHandler handler;
        Regex regex = new Regex(@"[A-Z]");
        MatchCollection matches;
        TextInfo textInfo = new CultureInfo("ru-RU").TextInfo;
        List<string> blocks = new List<string> { "������", "�������� ������",
            "�������� �������", "DOI", "���", "���", "�����", "��������"};


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

            if (End.Text != "�����������")
                richTextBox1.AppendText(End.Text.Trim('"'));

            //richTextBox1.Text = $"{await FormAuthorsList(res)} / {await FormTitle(res)}";
            //richTextBox1.Text = await FormJournalName(res);
            //FormJournalName(res, richTextBox1);
            //FormYear(res, richTextBox1);
            //richTextBox1.AppendText(", ");
            //AddThome(res, richTextBox1);
            //richTextBox1.AppendText(", ");
            //AddPage(res, richTextBox1);
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

            if (AuthPosDropList.Text == "��������/�������")
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
            switch (ArticleNameDropList.SelectedItem)
            {
                //case "��� ��������":
                //    return "";

                case "��������":
                    rtb.AppendText(response.message.title[0]);
                    return;
                //return Regex.Replace(response.message.title[0], @"\s(\w)", m => m.Value.ToLower());

                case "�������� � ���������� �������":
                    rtb.AppendText(Regex.Replace(Regex.Replace(response.message.title[0], @"\b(\w)", m => m.Value.ToUpper()),
                        @"(\s(of|in|by|and|the|a|an|at|on|under|above|between|to|into|out of|from|through|along|across|before|after|till|until|ago|during|since|for|because of|due to|thanks to|in accordance with|against|behind|below|around|towards|back to|in front of|outside|on account of|upon)|\'[st])\b",
                        m => m.Value.ToLower(), RegexOptions.IgnoreCase));
                    return;

                default:
                    return;
            }
        }

        async void FormJournalName(Response1 response, RichTextBox rtb)
        {
            var journal = response.message.container_title[0];
            switch (JournalNameDropList.SelectedItem)
            {
                case "������":
                    rtb.AppendText(journal);
                    return;

                case "������������":
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
                case "��� url-������":
                    rtb.AppendText($"https://doi.org/{DOI}");
                    return;

                case "�����������":
                    rtb.AppendText(DOI);
                    return;

                //case "��� ��������":
                //    return "";

                default:
                    return;
            }
        }

        async void FormYear(Response1 response, RichTextBox rtb)
        {
            var year = response.message.license[0].start.date.Substring(0, 4);

            if (YearBold.Checked && YearItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold | FontStyle.Italic);
                rtb.AppendText(year);
            }
            else if (YearBold.Checked && !YearItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold);
                rtb.AppendText(year);
            }
            else if (!YearBold.Checked && YearItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Italic);
                rtb.AppendText(year);
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

            if (NumberThomePart.Checked)
            {
                thome = $"{thome}({response.message.issue})";
            }

            if (ThomeBold.Checked && ThomeItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold | FontStyle.Italic);
                rtb.AppendText(thome);
            }
            else if (ThomeBold.Checked && !ThomeItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold);
                rtb.AppendText(thome);
            }
            else if (!ThomeBold.Checked && ThomeItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Italic);
                rtb.AppendText(thome);
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

            if (NumberBold.Checked && NumberItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold | FontStyle.Italic);
                rtb.AppendText(number);
            }
            else if (NumberBold.Checked && !NumberItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold);
                rtb.AppendText(number);
            }
            else if (!NumberBold.Checked && NumberItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Italic);
                rtb.AppendText(number);
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

            if (PageBold.Checked && PageItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold | FontStyle.Italic);
                rtb.AppendText(page);
            }
            else if (PageBold.Checked && !PageItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Bold);
                rtb.AppendText(page);
            }
            else if (!PageBold.Checked && PageItalic.Checked)
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Italic);
                rtb.AppendText(page);
            }
            else
            {
                rtb.SelectionFont = new System.Drawing.Font(rtb.Font, FontStyle.Regular);
                rtb.AppendText(page);
            }
        }

        private void NumberThomePart_CheckedChanged(object sender, EventArgs e)
        {
            if (NumberThomePart.Checked)
            {
                if (NumberCheck.Checked)
                    blocksCount -= 1;

                NumberCheck.Enabled = false;
                NumberCheck.Checked = false;
                NumberBold.Enabled = false;
                NumberBold.Checked = false;
                NumberItalic.Enabled = false;
                NumberItalic.Checked = false;
                CheckBlocksNumber();
            }
            else if (!NumberThomePart.Checked)
            {
                NumberCheck.Enabled = true;
                NumberCheck.Checked = true;
                NumberBold.Enabled = true;
                NumberItalic.Enabled = true;
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

        private void NumberCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (NumberCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("�����");
            }
            else if (!NumberCheck.Checked)
            {
                if (!NumberThomePart.Checked)
                    blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("�����");
            }

            FormBlockList();
        }

        private void PageCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PageCheck.Checked)
            {
                blocksCount += 1;
                CheckBlocksNumber();
                blocks.Add("��������");
            }
            else
            {
                blocksCount -= 1;
                CheckBlocksNumber();
                blocks.Remove("��������");
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
                    FormDOI(richTextBox1);
                    break;

                case "���":
                    FormYear(res, richTextBox1);
                    break;

                case "���":
                    FormThome(res, richTextBox1);
                    break;

                case "�����":
                    FormNumber(res, richTextBox1);
                    break;

                case "��������":
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
    }
}