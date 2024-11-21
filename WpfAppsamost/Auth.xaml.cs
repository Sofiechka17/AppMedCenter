using Npgsql;
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

namespace WpfAppsamost
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        private string conectString = "Host=localhost;Port=5432;Database=postgres; User Id = postgres; Password = postgres;";
        public Auth()
        {
            InitializeComponent();
        }

        private void btn_ok(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string password = Password.Text.Trim();

                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                    {
                        connection.Open();

                        string sql = "";

                            sql = "SELECT donor_id, donor_fullname, donor_phone FROM charity_schema.donors WHERE donor_fullname = @login AND donor_phone = @password";
                        
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@login", login);
                            cmd.Parameters.AddWithValue("@password", password);

                            using (NpgsqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    Window nextWindow = null;

                                    nextWindow = new MainWindow();
                                    this.Close();
                                    nextWindow.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный логин или пароль");
                                }
                            }
                        }


                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                }
        }
    }
}
