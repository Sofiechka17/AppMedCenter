using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Coder
{
    /// <summary>
    /// Логика взаимодействия для Decrypts.xaml
    /// </summary>
    public partial class Decrypts : Window
    {
        public Decrypts()
        {
            InitializeComponent();
        }

        private void Encrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            string convertation = WordNameTextBox_3.Text.Trim();
            string words = WordNameTextBox_4.Text.Trim();

        }
        private void Encrypt_Button_Click(object sender, RoutedEventArgs e)
        {
            EncryptWindow encryptWindow = new EncryptWindow();
            ncryptWindow.Show();
            Hide();
        }
    }
}