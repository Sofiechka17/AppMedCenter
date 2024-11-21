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

namespace WpfAppMed
{
    /// <summary>
    /// Логика взаимодействия для TeacherAdminWindow.xaml
    /// </summary>
    public partial class TeacherAdminWindow : Window
    {
        private NpgsqlConnection connection;
        private string conectString = "Host=localhost;Port=5432;Database=postgres; User Id = postgres; Password = postgres;";

        public TeacherAdminWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public class Teacher
        {
            public int teacher_id { get; set; }
            public string teacher_fullname { get; set; }
            public int teacher_seniority { get; set; }
            public string phone_number { get; set; }
        }

        //Метод для загрузк данных из бд в DataGrid
        private void LoadData()
        {
            List<Teacher> teachers = new List<Teacher>();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM medcenter_schema.teachers";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teachers.Add(new Teacher
                            {
                                teacher_id = reader.GetInt32(0),
                                teacher_fullname = reader.GetString(1),
                                teacher_seniority = reader.GetInt32(2),
                                phone_number = reader.GetString(3)
                            });
                        }
                    }
                    //connection.Close();
                }

                //Привязываем данные к DataGrid
                Registration_teacher.ItemsSource = teachers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
            }
        }

        // Обработчик события кнопки "Добавить"
        private void Click_add(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                {
                    connection.Open();

                    //sql запрос для добавление нового преподавателя
                    var query = "INSERT INTO medcenter_schema.teachers(\"teacher_fullname\", \"teacher_seniority\", \"phone_number\") VALUES (@teacher_fullname, @teacher_seniority, @phone_number)";
                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        //Передаем параметры из полей ввода в запрос
                        cmd.Parameters.AddWithValue("@teacher_fullname", fullname_input2.Text);
                        cmd.Parameters.AddWithValue("@teacher_seniority", int.Parse(seniority_input.Text));
                        cmd.Parameters.AddWithValue("@phone_number", number_input2.Text);

                        cmd.Prepare();
                        cmd.ExecuteNonQuery();// выполняем запрос
                    }
                }

                //Сообщаем пользователю об успешном добавлении
                MessageBox.Show("Teacher added successfully");

                //Обновляем DataGrid, чтобы отобразить новые данные
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding teacher: " + ex.Message);
            }
        }

        private void Click_del(object sender, RoutedEventArgs e)
        {
            if (Registration_teacher.SelectedItem is Teacher selectedTeacher)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                    {
                        connection.Open();

                        string sql = "DELETE FROM medcenter_schema.teachers WHERE \"teacher_id\" = @teacher_id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@teacher_id", selectedTeacher.teacher_id);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Teacher deleted successfully");
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("No teacher was deleted");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting teacher: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a teacher to delete");
            }
        }

        private void Click_up(object sender, RoutedEventArgs e)
        {
            Teacher selectedTeacher = (Teacher)Registration_teacher.SelectedItem;

            if (selectedTeacher != null)
            {
                try
                {
                    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                    {
                        connection.Open();

                        string sql = @"UPDATE medcenter_schema.teachers
                                    SET ""teacher_fullname"" = @teacher_fullname,
                                        ""teacher_seniority"" = @teacher_seniority,
                                        ""phone_number"" = @phone_number
                                        WHERE ""teacher_id"" = @teacher_id";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@teacher_id", selectedTeacher.teacher_id);
                            cmd.Parameters.AddWithValue("@teacher_fullname", fullname_input2.Text);
                            cmd.Parameters.AddWithValue("@teacher_seniority", int.Parse(seniority_input.Text));
                            cmd.Parameters.AddWithValue("@phone_number", number_input2.Text);


                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Teacher updated successfully");
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("No teacher was updated");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating teacher: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a teacher to update");
            }
        }

        private void Button_Click_student(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow();//Создание нового окна
            this.Close();// закрытие этого окна
            studentWindow.ShowDialog();//отображение
        }

        private void Button_LK_teacher(object sender, RoutedEventArgs e)
        {
            TeacherWindow teacherWindow = new TeacherWindow();//Создание нового окна
            this.Close();// закрытие этого окна
            teacherWindow.ShowDialog();//отображение
        }
        private void Registration_teacher_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement(Registration_teacher, e.OriginalSource as DependencyObject) as DataGridRow;

            if (row != null)
            {
                var selectedTeacher = row.Item as Teacher;

                if (selectedTeacher != null)
                {
                    fullname_input2.Text = selectedTeacher.teacher_fullname;
                    seniority_input.Text = selectedTeacher.teacher_seniority.ToString();
                    number_input2.Text = selectedTeacher.phone_number;
                }
            }
        }
    }
}
