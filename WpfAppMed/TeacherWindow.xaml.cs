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
    /// Логика взаимодействия для TeacherWindow.xaml
    /// </summary>
    public partial class TeacherWindow : Window
    {
        private NpgsqlConnection connection;

        private string conectString = "Host=localhost;Port=5432;Database=postgres; User Id = postgres; Password = postgres;";
        public TeacherWindow()
        {
            InitializeComponent();
            ConnectReader();
        }
        public class Student
        {
            public int student_id { get; set; }
            public string student_fullname { get; set; }
            public string student_phonenumber { get; set; }
            public DateTime student_datereg { get; set; }

        }

        //Метод для загрузк данных из бд в DataGrid
        private void ConnectReader()
        {
            List<Student> students = new List<Student>();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                {
                    connection.Open();

                    // Измените SQL-запрос, чтобы выбирать только необходимые поля
                    string sql = "SELECT student_id, student_fullname FROM medcenter_schema.students";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Читайте данные только для необходимых полей
                            students.Add(new Student
                            {
                                student_id = reader.GetInt32(0),
                                student_fullname = reader.GetString(1)
                            });
                        }
                    }
                    //connection.Close();
                }
                //Привязываем данные к DataGrid
                Teacher.ItemsSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
            }
        }
    }
}
