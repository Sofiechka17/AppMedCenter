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
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;


namespace Wpfsamworkai
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NpgsqlConnection connection;

        private string conectString = "Host=localhost;Port=5432;Database=postgres; User Id = postgres; Password = postgres";
        public MainWindow()
        {
            InitializeComponent();

            SqlConnectionReader();
        }

        public class Student
        {
            public int student_id { get; set; }
            public string student_fullname { get; set; }
            public string student_phonenumber { get; set; }
            public DateTime student_datereg { get; set; }

        }

        //Метод для загрузк данных из бд в DataGrid
        private void SqlConnectionReader()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM medcenter_schema.students";


                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                student_id = reader.GetInt32(0),
                                student_fullname = reader.GetString(1),
                                student_phonenumber = reader.GetString(2),
                                student_datereg = reader.GetDateTime(3)
                            });
                        }
                    }

                    connection.Close();
                }
                //Привязываем данные к DataGrid
                Registration_student.ItemsSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
            }
        }

        // Обработчик события кнопки "Добавить"
        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            string phoneNumber = number_input.Text;
            List<char> digits = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int validPhoneNumberSymbolCount = 11;

            if (phoneNumber.Length != validPhoneNumberSymbolCount)
            {
                bool isPhoneNumberValid = true;
                int symbolIndex = 0;

                while (isPhoneNumberValid && symbolIndex < phoneNumber.Length)
                {
                    char symbol = digits[symbolIndex];

                    if (digits.Contains(symbol) == false)
                    {
                        isPhoneNumberValid = false;
                    }
                    else
                    {
                        symbolIndex++;
                    }
                }

                if (isPhoneNumberValid)
                {
                    try
                    {
                        using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                        {
                            connection.Open();

                            //sql запрос для добавление нового студента
                            var sqlrequest = "INSERT INTO medcenter_schema.students(\"student_fullname\", \"student_phonenumber\", \"student_datereg\") VALUES (@student_fullname, @student_phonenumber, @student_datereg)";
                            using (var cmd = new NpgsqlCommand(sqlrequest, connection))
                            {
                                //Передаем параметры из полей ввода в запрос
                                cmd.Parameters.AddWithValue("student_fullname", fullname_input.Text);
                                cmd.Parameters.AddWithValue("student_phonenumber", number_input.Text);
                                cmd.Parameters.AddWithValue("@student_datereg", DateTime.Parse(date_input.Text));

                                cmd.Prepare();
                                cmd.ExecuteNonQuery();// выполняем запрос
                            }

                            connection.Close();
                        }

                        //Сообщаем пользователю об успешном добавлении
                        MessageBox.Show("Student added successfully");

                        //Обновляем DataGrid, чтобы отобразить новые данные
                        SqlConnectionReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding student: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("В телефоне присутсвуют символы не цифры");
                }
            }
            else
            {
                MessageBox.Show("Количество цифр не соответствует номеру телефона");
            }

        }

        private void Button_Click_del(object sender, RoutedEventArgs e)
        {
            if (Registration_student.SelectedItem is Student selectedStudent)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                    {
                        connection.Open();

                        string sql = "DELETE FROM medcenter_schema.students WHERE \"student_id\" = @student_id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@student_id", selectedStudent.student_id);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Student deleted successfully");
                                SqlConnectionReader();
                            }
                            else
                            {
                                MessageBox.Show("No student was deleted");
                            }
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting student: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete");
            }
        }

        private void Button_Click_up(object sender, RoutedEventArgs e)
        {
            Student selectedStudent = (Student)Registration_student.SelectedItem;

            if (selectedStudent != null)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                    {
                        connection.Open();

                        string sql = @"UPDATE medcenter_schema.students
                                            SET ""student_fullname"" = @student_fullname,
                                                ""student_phonenumber"" = @student_phonenumber,
                                                ""student_datereg"" = @student_datereg
                                                WHERE ""student_id"" = @student_id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@student_id", selectedStudent.student_id);
                            cmd.Parameters.AddWithValue("@student_fullname", fullname_input.Text);
                            cmd.Parameters.AddWithValue("@student_phonenumber", number_input.Text);
                            cmd.Parameters.AddWithValue("@student_datereg", DateTime.Parse(date_input.Text));


                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Student updated successfully");
                                SqlConnectionReader();
                            }
                            else
                            {
                                MessageBox.Show("No student was updated");
                            }
                        }

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating student: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a student to update");
            }
        }

        private void Registration_student_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement(Registration_student, e.OriginalSource as DependencyObject) as DataGridRow;

            if (row != null)
            {
                var selectedStudent = row.Item as Student;

                if (selectedStudent != null)
                {
                    fullname_input.Text = selectedStudent.student_fullname;
                    number_input.Text = selectedStudent.student_phonenumber;
                    date_input.Text = selectedStudent.student_datereg.ToString("dd-MM-yyyy");
                }
            }
        }
    }
}