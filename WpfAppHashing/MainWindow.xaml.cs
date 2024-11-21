using Npgsql;
using System;
using System.Security.Cryptography;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WpfAppHashing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres";
        string salt = "BibaQirZpjBoba";
        string TextPass;
        public MainWindow()
        {
            var connection = new NpgsqlConnection(ConnectionString);
            InitializeComponent();
        }

        // Метод для генерации хеша с солью
        static byte[] GenerateSaltedHash(string TextPass, string salt)
        {
            using (var algorithm = new SHA256Managed())
            {
                // Преобразуем текст пароля в байты
                byte[] plainTextBytes = Encoding.Unicode.GetBytes(TextPass);
                // Преобразуем соль из base64 в байты
                byte[] saltBytes = Convert.FromBase64String(salt);

                // Создаем массив байтов для хранения текста пароля и соли
                byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];
                // Копируем соль в начало
                Buffer.BlockCopy(saltBytes, 0, plainTextWithSaltBytes, 0, saltBytes.Length);
                // Копируем текст пароля после соли
                Buffer.BlockCopy(plainTextBytes, 0, plainTextWithSaltBytes, saltBytes.Length, plainTextBytes.Length);

                // Вычисляем хэш и возвращаем результат
                return algorithm.ComputeHash(plainTextWithSaltBytes);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.TextPass = Password.Password.Trim();
            string login = LoginWW.Text.Trim();

            if (AuthenticateUser(login, TextPass))
            {
                MessageBox.Show("Вы успешно вошли в систему");
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
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

        // Метод для генерации соли
        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Метод для конвертации хеша в строку
        private static string ConvertHashToString(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}