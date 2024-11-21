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

namespace AptekaApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length < 3)
            {
                textBoxLogin.ToolTip = "Это поле введено не корректно!";
                textBoxLogin.Background = Brushes.IndianRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Длина пароля должна быть 5 символов или более";
                passBox.Background = Brushes.IndianRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;


                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }
                if (authUser != null)
                {
                   MessageBox.Show("Регистрация завершена");
                   UserPageWindow userPageWindow = new UserPageWindow();
                   userPageWindow.Show();
                   Hide();
                }
                else
                MessageBox.Show("Что-то пошло не так");

            }

        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
