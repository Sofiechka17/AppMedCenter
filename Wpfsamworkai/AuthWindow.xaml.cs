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
using Npgsql;
using System;

namespace Wpfsamworkai
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private string conectString = "Host=localhost;Port=5432;Database=postgres; User Id = postgres; Password = postgres;";

        public AuthWindow()
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

                    sql = "SELECT student_id, student_fullname, student_phonenumber FROM medcenter_schema.students WHERE student_fullname = @login AND student_phonenumber = @password";


                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //Window nextWindow = null;


                                //int studentId = reader.GetInt32(0);
                                //nextWindow = new MainWindow(studentId);

                                //this.Close();
                                //nextWindow.Show();

                                MainWindow mainWindow = new MainWindow();
                                mainWindow.ShowDialog();//отображение
                                this.Close();// закрытие этого окна
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
