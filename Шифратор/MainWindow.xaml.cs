using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Шифратор
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Button_Click(object sender, EventArgs e)
        {
            string originalWord = WordNameTextBox.Text;
            string encryptedWord = EncryptWord(originalWord);
            WordNameTextBox_2.Text = encryptedWord;
        }

        private string EncryptWord(string word)
        {
            Random random = new Random();
            int shift = random.Next(4, 16);

            StringBuilder sb = new StringBuilder();

            foreach (char c in word)
            {
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c)) // for uppercase letters
                    {
                        sb.Append((char)((c - 'А' + shift) % 33 + 'А'));
                    }
                    else if (char.IsLower(c)) // for lowercase letters
                    {
                        sb.Append((char)((c - 'а' + shift) % 33 + 'а'));
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        private void wordname_TextChanged(object sender, EventArgs e)
        {
            string word = WordNameTextBox.Text;

            foreach (char c in word)
            {
                if (char.IsLetter(c) && !char.IsRussian(c))
                {
                    MessageBox.Show("Please switch to using Russian characters.");
                    break;
                }
            }
        }
    }

    public static class CharExtensions
    {
        public static bool IsRussian(this char c)
        {
            return (c >= 'А' && c <= 'я');
        }
    }
}


