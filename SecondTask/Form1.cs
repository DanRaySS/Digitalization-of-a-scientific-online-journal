using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        RequestsHandler handler;
        Regex regex = new Regex(@"[A-Z]");
        MatchCollection matches;

        public Form1()
        {
            InitializeComponent();
            handler = new RequestsHandler();
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox2.SelectedItem = comboBox2.Items[0];
            comboBox3.SelectedItem = comboBox3.Items[0];
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label1.Text = "Error, empty field.";
                return;
            }

            Response1 res = await handler.GetMetadata(textBox1.Text);
            if (res.status == "error")
            {
                label1.Text = "Error, wrong input.";
                return;
            }

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


            var authors = res.message.author;
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

                label1.Text = $"{String.Join(authorsSeparator, authorsStr)} and {lastAuthor}";

                return;
            }

            label1.Text = String.Join(authorsSeparator, authorsStr);

            if (checkBox4.Checked)
            {
                label1.Text = $"{label1.Text} et al.";
            }
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
    }
}