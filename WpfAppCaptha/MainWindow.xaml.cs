using Npgsql;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;
using WpfAppCaptha;

namespace WpfAppHashing        
{                 /// <summary>
/// ЗДЕСЬ ДОЛЖЕН БЫТЬ код из практикии хеширование(авторизация)
/// </summary>
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";
        private int failedLoginAttempts = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordBox.Password.Trim();
            string login = LoginTextBox.Text.Trim();

            if (AuthenticateUser(login, password))
            {
                MessageBox.Show("Вы успешно вошли в систему");
                failedLoginAttempts = 0;
            }
            else
            {
                failedLoginAttempts++;
                MessageBox.Show("Неверный логин или пароль");

                if (failedLoginAttempts >= 3)
                {
                    // Отображаем окно с капчей после 3 неудачных попыток
                    CaptchaWindow captchaWindow = new CaptchaWindow();
                    bool? captchaResult = captchaWindow.ShowDialog();

                    if (captchaResult == true)
                    {
                        // Капча введена верно, сбрасываем счетчик попыток
                        failedLoginAttempts = 0;
                    }
                    else
                    {
                        // Если капча введена неверно, продолжаем требовать капчу
                        MessageBox.Show("Капча не пройдена. Попробуйте еще раз.");
                    }
                }
            }
        }

        // Метод для аутентификации пользователя
        private bool AuthenticateUser(string login, string password)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                string sql = "SELECT hash, salt FROM hashing_schema.users WHERE login = @login";

                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("login", login);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader.GetString(0);
                            string storedSalt = reader.GetString(1);

                            byte[] enteredHash = GenerateSaltedHash(password, storedSalt);
                            string enteredHashString = ConvertHashToString(enteredHash);

                            return enteredHashString == storedHash;
                        }
                    }
                }
                connection.Close();
            }
            return false;
        }

        // Остальные методы (хеширование, конвертация и т.д.)
        // ...
    }

}
