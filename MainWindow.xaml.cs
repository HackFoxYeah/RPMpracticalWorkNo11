using System.Text.RegularExpressions;
using System.Windows;

namespace practWorkNo11
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            const string TASKNOONE = "aba aca aea abba adca abea",
                         TASKNOTWO = "ave a#b a2b a$b a4b a5b a-b acb",
                         PATTERNFIRST = @"abba|adca|abea",
                         PATTERNSECOND = @"\w*a\w*[^А-ЯA-Z\d]\w*b\w*";/*@"\w*a\w*[\W\D]\w*b\w*"*/

            MatchCollection matchColFirst,
                            matchColSecond;
            Regex regExp;

            regExp = new(PATTERNFIRST, RegexOptions.Multiline);

            matchColFirst = regExp.Matches(TASKNOONE);

            tbResult.Clear();

            tbResult.Text = $"Даны две строки:\n1) aba aca aea abba adca abea\n2) ave a#b a2b a$b a4b a5b a-b acb\n" +
                            $"К ним даны два шаблона:\n1) abba adca abea\n2) \"По бокам a и b, между ними не буква и не цифра\"\n\n";

            if (matchColFirst.Count > 0)
            {
                tbResult.Text += "Совпадения в первой строке: ";
                foreach (Match match in matchColFirst)
                    tbResult.Text += match.Value + " ";
                tbResult.Text += "\n";
            }
            else
            {
                tbResult.Text += "Нет совпадений в первой строке\n";
            }

            matchColSecond = Regex.Matches(TASKNOTWO, PATTERNSECOND, RegexOptions.IgnoreCase);

            if (matchColSecond.Count > 0)
            {
                tbResult.Text += "Совпадения во второй строке: ";
                foreach (Match match in matchColSecond)
                    tbResult.Text += match.Value + " ";
                tbResult.Text += "\n";
            }
            else
            {
                tbResult.Text += "Нет совпадений во второй строке";
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }        
    }
}