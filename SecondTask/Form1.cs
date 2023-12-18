using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Aspose.Cells;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        RequestsHandler handler;
        Regex regex = new Regex(@"[A-Z]");
        MatchCollection matches;
        TextInfo textInfo = new CultureInfo("ru-RU").TextInfo;

        public Form1()
        {
            InitializeComponent();
            handler = new RequestsHandler();
            AuthPosDropList.SelectedItem = AuthPosDropList.Items[0];
            NameSepDropList.SelectedItem = NameSepDropList.Items[0];
            AuthSepDropList.SelectedItem = AuthSepDropList.Items[0];
            ArticleNameDropList.SelectedItem = ArticleNameDropList.Items[0];
            JournalNameDropList.SelectedItem = JournalNameDropList.Items[0];
            DOIDropList.SelectedItem = DOIDropList.Items[0];
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            labelOutput.Text = "";
            if (DOIinput.Text == "")
            {
                labelOutput.Text = "Error, empty field.";
                return;
            }

            Response1 res = await handler.GetMetadata(DOIinput.Text);

            if (res.status == "error")
            {
                labelOutput.Text = "Error, wrong input.";
                return;
            }

            //labelOutput.Text = $"{await FormAuthorsList(res)} / {await FormTitle(res)}";
            labelOutput.Text = await FormJournalName(res);
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

        async Task<string> FormAuthorsList(Response1 response)
        {
            string firstW, secondW, initialEnd, initialsSeparator;
            string nameSeparator = NameSepDropList.Text.Trim('"');
            string authorsSeparator = $"{AuthSepDropList.Text} ";

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
            if (AuthsLimitCheck.Checked)
            {
                authorsLength = (int)AuthorsLimiter.Value;
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

                return $"{String.Join(authorsSeparator, authorsStr)} and {lastAuthor}";
            }

            if (AuthsLimitCheck.Checked)
            {
                return $"{String.Join(authorsSeparator, authorsStr)} et al.";
            }

            return String.Join(authorsSeparator, authorsStr);
        }

        async Task<string> FormTitle(Response1 response)
        {
            switch (ArticleNameDropList.SelectedItem)
            {
                case "Без названия":
                    return "";

                case "С названием":
                    return response.message.title[0];
                //return Regex.Replace(response.message.title[0], @"\s(\w)", m => m.Value.ToLower());

                case "Название с заглавными буквами":
                    return Regex.Replace(Regex.Replace(response.message.title[0], @"\b(\w)", m => m.Value.ToUpper()),
                        @"(\s(of|in|by|and|the|a|an|at|on|under|above|between|to|into|out of|from|through|along|across|before|after|till|until|ago|during|since|for|because of|due to|thanks to|in accordance with|against|behind|below|around|towards|back to|in front of|outside|on account of|upon)|\'[st])\b",
                        m => m.Value.ToLower(), RegexOptions.IgnoreCase);

                default:
                    return "";
            }
        }

        async Task<string> FormJournalName(Response1 response)
        {
            var journal = response.message.container_title[0];
            switch (JournalNameDropList.SelectedItem)
            {
                case "Полное":
                    return journal;

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
                    return journal;

                default:
                    return "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (labelOutput != null)
            {
                Clipboard.SetText(labelOutput.Text, TextDataFormat.UnicodeText);
            }

            labelSuccess.Text = "Успешно скопировано!";

            labelSuccess.Visible = true;
        }
    }
}