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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace AptekaApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();

            DoubleAnimation btnAnimation = new DoubleAnimation();
            btnAnimation.From = 0; 
            btnAnimation.To = 450;
            btnAnimation.Duration = TimeSpan.FromSeconds(3);
            regButton.BeginAnimation(Button.WidthProperty, btnAnimation);
        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if(login.Length < 3)
            {
                textBoxLogin.ToolTip = "Это поле введено не корректно!";
                textBoxLogin.Background = Brushes.IndianRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Длина пароля должна быть 5 символов или более";
                passBox.Background = Brushes.IndianRed;
            }
            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Пароль не совпадает";
                passBox_2.Background = Brushes.IndianRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Это поле введено не корректно!";
                textBoxEmail.Background = Brushes.IndianRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Регистрация завершена");

                User user = new User(login, email, pass);

                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
        }
        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
