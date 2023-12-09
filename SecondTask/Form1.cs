using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];
            comboBox3.SelectedItem = comboBox3.Items[0];
            comboBox4.SelectedItem = comboBox4.Items[0];
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            labelOutput.Text = "";
            if (textBox1.Text == "")
            {
                labelOutput.Text = "Error, empty field.";
                return;
            }

            Response1 res = await handler.GetMetadata(textBox1.Text);

            if (res.status == "error")
            {
                labelOutput.Text = "Error, wrong input.";
                return;
            }

            labelOutput.Text = $"{await FormAuthorsList(res)} / {await FormTitle(res)}";
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                label4.Enabled = true;
                numericUpDown1.Enabled = true;
                checkBox3.Enabled = false;
                checkBox3.Checked = false;
            }
            else
            {
                label4.Enabled = false;
                numericUpDown1.Enabled = false;
                checkBox3.Enabled = true;
            }
        }

        async Task<string> FormAuthorsList(Response1 response)
        {
            string firstW, secondW, initialEnd, initialsSeparator;
            string nameSeparator = comboBox2.Text.Trim('"');
            string authorsSeparator = $"{comboBox3.Text} ";

            if (checkBox1.Checked)
                initialEnd = ".";
            else
                initialEnd = "";

            if (checkBox2.Checked)
                initialsSeparator = " ";
            else
                initialsSeparator = "";


            var authors = response.message.author;
            int authorsLength = authors.Length;
            if (checkBox4.Checked)
            {
                authorsLength = (int)numericUpDown1.Value;
            }
            string[] authorsStr = new string[authorsLength];

            if (comboBox1.Text == "Инициалы/Фамилия")
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

            if (checkBox3.Checked && authorsLength >= 2)
            {
                string lastAuthor = authorsStr.Last();
                List<string> tempAuthorsStr = new List<string>(authorsStr);
                tempAuthorsStr.RemoveAt(authorsLength - 1);
                authorsStr = tempAuthorsStr.ToArray();

                return $"{String.Join(authorsSeparator, authorsStr)} and {lastAuthor}";
            }

            if (checkBox4.Checked)
            {
                return $"{String.Join(authorsSeparator, authorsStr)} et al.";
            }

            return String.Join(authorsSeparator, authorsStr);
        }

        async Task<string> FormTitle(Response1 response)
        {
            switch (comboBox4.SelectedItem)
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