using System.Text.RegularExpressions;

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
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                label1.Text = "Error, empty field";
            else
            {
                Response1 res = await handler.GetMetadata(textBox1.Text);

                if (res.status == "error")
                    label1.Text = "Error, wrong DOI";
                else
                {
                    string doiText;
                    var authors = res.message.author;
                    string[] authorsStr = new string[authors.Length];
                    string[] initials;
                    string initialsSeparator = " ";
                    string nameSeparator = " ";
                    string authorSeparator = ", ";

                    for (int i = 0; i < authors.Length; i++) 
                    {
                        matches = regex.Matches(authors[i].given);
                        initials = new string[matches.Count];
                        for (int j = 0; j < matches.Count(); j++)
                            initials[j] = $"{matches[j].Value}.";

                        authorsStr[i] = 
                            $"{String.Join(initialsSeparator, initials)}{nameSeparator}{authors[i].family}";

                        foreach (Match match in matches)
                            Console.WriteLine(match.Value);
                    }

                    doiText = String.Join(authorSeparator, authorsStr);

                    label1.Text = doiText;
                }
            }

        }
    }
}