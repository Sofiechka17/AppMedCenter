using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WpfAppHashing
{
    public class UserAuthentication
    {
        private static string connectionString = "Host=localhost;Port=5432;Database=hashing;Username=postgres;Password=postgres";

        // Метод для генерации хэша с солью
        public static string GenerateSaltedHash(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
                byte[] passwordWithSaltBytes = new byte[passwordBytes.Length + saltBytes.Length];

                Buffer.BlockCopy(saltBytes, 0, passwordWithSaltBytes, 0, saltBytes.Length);
                Buffer.BlockCopy(passwordBytes, 0, passwordWithSaltBytes, saltBytes.Length, passwordBytes.Length);

                byte[] hashBytes = sha256.ComputeHash(passwordWithSaltBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        // Метод для проверки пользователя
        public static bool AuthenticateUser(string login, string password)
        {
            string salt = "AeDkFoDa";
            string hashedPassword = GenerateSaltedHash(password, salt);

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT hash FROM hashing_schema.users WHERE login = @login";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@login", login);

                    var dbHash = command.ExecuteScalar() as string;
                    return dbHash == hashedPassword;
                }
            }
        }
    }
}