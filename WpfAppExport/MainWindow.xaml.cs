using System.Diagnostics;
using Npgsql;
using System.IO;
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

namespace WpfAppExport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NpgsqlConnection connection;

        private string conectString = "Host=localhost; Port=5432;Database=postgres; User Id = postgres; Password = postgres";
        public MainWindow()
        {
            InitializeComponent();
            SqlConnectionReader();
        }

        public class Donor
        {
            public int donor_id { get; set; }
            public string donor_fullname { get; set; }
            public string donor_phone { get; set; }
            public DateTime donor_datereg { get; set; }
            public int donor_age { get; set; }
        }

        private void SqlConnectionReader()
        {
            List<Donor> donors = new List<Donor>();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM charity_schema.donors";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            donors.Add(new Donor
                            {
                                donor_id = reader.GetInt32(0),
                                donor_fullname = reader.GetString(1),
                                donor_phone = reader.GetString(2),
                                donor_datereg = reader.GetDateTime(3),
                                donor_age = reader.GetInt32(4)
                            });
                        }
                    }

                    connection.Close();
                }

                RegDonor.ItemsSource = donors;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
            }
        }
        private void Button_Click_up(object sender, RoutedEventArgs e)
        {
            Donor selectedDonor = (Donor)RegDonor.SelectedItem;

            if (selectedDonor != null)
            {
                try
                {
                    if (!int.TryParse(age_input.Text, out int age) || age < 20)
                    {
                        MessageBox.Show("Донор должен быть старше 20 лет для регистрации.");
                        return;
                    }

                    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                    {
                        connection.Open();

                        string sql = @"UPDATE charity_schema.donors
                                            SET ""donor_fullname"" = @donor_fullname,
                                                ""donor_phone"" = @donor_phone,
                                                ""donor_datereg"" = @donor_datereg,
                                                ""donor_age"" = @donor_age
                                                WHERE ""donor_id"" = @donor_id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@donor_id", selectedDonor.donor_id);
                            cmd.Parameters.AddWithValue("@donor_fullname", fullname_input.Text);
                            cmd.Parameters.AddWithValue("@donor_phone", number_input.Text);
                            cmd.Parameters.AddWithValue("@donor_datereg", DateTime.Parse(date_input.Text));
                            cmd.Parameters.AddWithValue("@donor_age", int.Parse(age_input.Text));

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Данные обновлены");
                                SqlConnectionReader();
                            }
                            else
                            {
                                MessageBox.Show("Нет данных для обновления");
                            }
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка обнолвения студента: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите студента для обновления");
            }
        }

        private void Registration_student_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement(RegDonor, e.OriginalSource as DependencyObject) as DataGridRow;

            if (row != null)
            {
                var selectedDonor = row.Item as Donor;

                if (selectedDonor != null)
                {
                    fullname_input.Text = selectedDonor.donor_fullname;
                    number_input.Text = selectedDonor.donor_phone;
                    date_input.Text = selectedDonor.donor_datereg.ToString("dd-MM-yyyy");
                    age_input.Text = selectedDonor.donor_age.ToString();
                }
            }
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            string donor_phone = number_input.Text;
            int validPhoneNumberSymbolCount = 11;

            // Проверяем, что длина номера телефона ровно 11 символов
            if (donor_phone.Length == validPhoneNumberSymbolCount && donor_phone.All(char.IsDigit))
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                    {
                        connection.Open();

                        var sqlrequest = "INSERT INTO charity_schema.donors(\"donor_fullname\", \"donor_phone\", \"donor_datereg\", \"donor_age\") VALUES (@donor_fullname, @donor_phone, @donor_datereg, @donor_age)";
                        using (var cmd = new NpgsqlCommand(sqlrequest, connection))
                        {
                            cmd.Parameters.AddWithValue("@donor_fullname", fullname_input.Text);
                            cmd.Parameters.AddWithValue("@donor_phone", donor_phone);
                            cmd.Parameters.AddWithValue("@donor_datereg", DateTime.Parse(date_input.Text));
                            cmd.Parameters.AddWithValue("@donor_age", int.Parse(age_input.Text));

                            cmd.Prepare();
                            cmd.ExecuteNonQuery();
                        }

                        connection.Close();
                    }

                    MessageBox.Show("Студент добавлен");

                    SqlConnectionReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка добавления студента: " + ex.Message);
                }
            }
            else
            {
                // Если длина номера неверна или присутствуют нецифровые символы
                if (donor_phone.Length != validPhoneNumberSymbolCount)
                {
                    MessageBox.Show("Количество цифр не соответствует номеру телефона");
                }
                else
                {
                    MessageBox.Show("В телефоне присутствуют символы, отличные от цифр");
                }
            }
        }


        private void Button_Click_del(object sender, RoutedEventArgs e)
        {
            if (RegDonor.SelectedItem is Donor selectedDonor)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                    {
                        connection.Open();

                        string sql = "DELETE FROM charity_schema.donors WHERE \"donor_id\" = @donor_id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@donor_id", selectedDonor.donor_id);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Студент удален");
                                SqlConnectionReader();
                            }
                            else
                            {
                                MessageBox.Show("Вы не выбрали студента для удаления");
                            }
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите студента для удаления");
            }
        }

        private void Button_Click_export(object sender, RoutedEventArgs e)
        {
                try
                {
                    // Получаем данные из DataGrid
                    List<string> lines = new List<string>();

                    // Заголовки столбцов
                    string header = string.Join(",", RegDonor.Columns.Select(column => column.Header.ToString()));
                    lines.Add(header);

                    // Данные
                    foreach (var donor in RegDonor.Items)
                    {
                        if (donor is Donor d)
                        {
                            string line = $"{d.donor_id},{d.donor_fullname},{d.donor_phone},{d.donor_datereg:dd-MM-yyyy},{d.donor_age}";
                            lines.Add(line);
                        }
                    }

                    // Сохранение данных в файл CSV
                    string path = "donors_data.csv";
                    File.WriteAllLines(path, lines);
                    MessageBox.Show($"Данные экспортированы в файл: {path}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка экспорта данных: " + ex.Message);
                }
        }

        private void Button_Click_import(object sender, RoutedEventArgs e)
        {
            WindowImport windowimport = new WindowImport();
            this.Close();
            windowimport.ShowDialog();
        }
    }
}