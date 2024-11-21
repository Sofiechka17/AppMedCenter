using Npgsql;
using System.Linq;
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
using static WpfAppsamost.MainWindow;
using static WpfAppsamost.projectOrg;

namespace WpfAppsamost
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
            LoadDonors();
            LoadProjects();
            LoadDonations();
        }

        public class Donor
        {
            public int donor_id { get; set; }
            public string donor_fullname { get; set; }
            public string donor_phone { get; set; }
            public DateTime donor_datereg { get; set; }
            public int donor_age { get; set; } 
        }

        public class Project
        {
            public int project_id { get; set; }
            public int organization_id { get; set; }
            public string project_name { get; set; }
            public string project_description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public class Donation
        {
            public int donation_id { get; set; }
            public int donor_id { get; set; }
            public int project_id { get; set; }
            public decimal Amount { get; set; }
            public DateTime DonationDate { get; set; }
        }

        public class Organization
        {
            public int organization_id { get; set; }
            public string organization_name { get; set; }
            public override string ToString() => organization_name;
        }

        private void LoadDonors()
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

        private List<Project> projects = new List<Project>();

        private void LoadProjects()
        {
            projects.Clear();
            List<Organization> organizations = new List<Organization>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                {
                    connection.Open();

                    // Запрос на получение данных организаций
                    string sqlOrganizations = "SELECT organization_id, organization_name FROM charity_schema.organizations";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlOrganizations, connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            organizations.Add(new Organization
                            {
                                organization_id = reader.GetInt32(0),
                                organization_name = reader.GetString(1)
                            });
                        }
                    }

                    // Запрос на получение проектов
                    string sqlProjects = "SELECT * FROM charity_schema.projects";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlProjects, connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projects.Add(new Project
                            {
                                project_id = reader.GetInt32(0),
                                organization_id = reader.GetInt32(1),
                                project_name = reader.GetString(2),
                                project_description = reader.GetString(3),
                                StartDate = reader.GetDateTime(4),
                                EndDate = reader.GetDateTime(5)
                            });
                        }
                    }

                    // LINQ-запрос для объединения projects с organization для замены organization_id на organization_name
                    var projectWithOrgNames = from p in projects
                                              join o in organizations on p.organization_id equals o.organization_id
                                              select new
                                              {
                                                  p.project_id,
                                                  organization_id = o.organization_name,
                                                  p.project_name,
                                                  p.project_description,
                                                  p.StartDate,
                                                  p.EndDate
                                              };

                    // Заполнение DataGrid результатами
                    RegProject.ItemsSource = projectWithOrgNames.ToList();

                    // Заполнение ComboBox списком организаций
                    organization_choise.ItemsSource = organizations;
                    organization_choise.DisplayMemberPath = "organization_name";
                    organization_choise.SelectedValuePath = "organization_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке проектов: " + ex.Message);
            }
        }


        private void LoadDonations()
        {
            List<Donation> donations = new List<Donation>();
            List<Donor> donors = new List<Donor>();
            List<Project> projects = new List<Project>();

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                {
                    connection.Open();

                    // Загрузка списка доноров
                    string sqlDonors = "SELECT donor_id, donor_fullname FROM charity_schema.donors";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlDonors, connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            donors.Add(new Donor
                            {
                                donor_id = reader.GetInt32(0),
                                donor_fullname = reader.GetString(1)
                            });
                        }
                    }

                    // Загрузка списка проектов
                    string sqlProjects = "SELECT project_id, project_name FROM charity_schema.projects";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlProjects, connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projects.Add(new Project
                            {
                                project_id = reader.GetInt32(0),
                                project_name = reader.GetString(1)
                            });
                        }
                    }

                    // Загрузка пожертвований
                    string sqlDonations = "SELECT * FROM charity_schema.donations";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlDonations, connection))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            donations.Add(new Donation
                            {
                                donation_id = reader.GetInt32(0),
                                donor_id = reader.GetInt32(1),
                                project_id = reader.GetInt32(2),
                                Amount = reader.GetDecimal(3),
                                DonationDate = reader.GetDateTime(4)
                            });
                        }
                    }

                    // LINQ-запрос для объединения donations с donors и projects для отображения имен вместо ID
                    var donationsWithNames = from d in donations
                                             join dn in donors on d.donor_id equals dn.donor_id
                                             join p in projects on d.project_id equals p.project_id
                                             select new
                                             {
                                                 d.donation_id,
                                                 donor_id = dn.donor_fullname,
                                                 project_id = p.project_name,
                                                 d.Amount,
                                                 d.DonationDate
                                             };

                    // Заполнение DataGrid результатами
                    RegDonation.ItemsSource = donationsWithNames.ToList();

                    // Заполнение ComboBox для доноров
                    donor_choise.ItemsSource = donors;
                    donor_choise.DisplayMemberPath = "donor_fullname";
                    donor_choise.SelectedValuePath = "donor_id";

                    // Заполнение ComboBox для проектов
                    project_choise.ItemsSource = projects;
                    project_choise.DisplayMemberPath = "project_name";
                    project_choise.SelectedValuePath = "project_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных о пожертвованиях: " + ex.Message);
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
                                LoadDonors();
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

                    LoadDonors();
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
                                LoadDonors();
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

        private void Button_Click_projectOrganization(object sender, RoutedEventArgs e)
        {
            projectOrg projOrg = new projectOrg();
            this.Close();
            projOrg.ShowDialog();
        }

        private void Registration_project_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Получаем выбранную строку в DataGrid
                var row = ItemsControl.ContainerFromElement(RegProject, e.OriginalSource as DependencyObject) as DataGridRow;

                if (row != null && row.Item != null)
                {
                    // Приводим строку к анонимному типу (или заменяем dynamic на типизированное представление, если возможно)
                    var selectedRow = row.Item;

                    // Проверяем, что объект содержит поле project_id
                    var projectIdProperty = selectedRow.GetType().GetProperty("project_id");
                    if (projectIdProperty != null)
                    {
                        int selectedProjectId = (int)projectIdProperty.GetValue(selectedRow);

                        // Ищем оригинальный объект Project в списке projects
                        var selectedProject = projects?.FirstOrDefault(p => p.project_id == selectedProjectId);

                        if (selectedProject != null)
                        {
                            // Устанавливаем значения в полях из выбранного проекта
                            organization_choise.SelectedValue = selectedProject.organization_id;
                            name_input.Text = selectedProject.project_name;
                            description_input.Text = selectedProject.project_description;
                            StartDate_input.Text = selectedProject.StartDate.ToString("dd-MM-yyyy");
                            EndDate_input.Text = selectedProject.EndDate.ToString("dd-MM-yyyy");
                        }
                        else
                        {
                            MessageBox.Show("Проект не найден в коллекции.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Строка не содержит project_id.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Button_Click_add_prjct(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                {
                    connection.Open();

                    // Подготовка запроса на добавление
                    string sqlInsert = "INSERT INTO charity_schema.projects (organization_id, project_name, project_description, StartDate, EndDate) " +
                                       "VALUES (@organization_id, @project_name, @project_description, @StartDate, @EndDate) RETURNING project_id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlInsert, connection))
                    {
                        cmd.Parameters.AddWithValue("@organization_id", (int)organization_choise.SelectedValue);
                        cmd.Parameters.AddWithValue("@project_name", name_input.Text);
                        cmd.Parameters.AddWithValue("@project_description", description_input.Text);
                        cmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(StartDate_input.Text));
                        cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(EndDate_input.Text));

                        int newProjectId = (int)cmd.ExecuteScalar(); // Получение ID нового проекта

                        // Добавляем новый проект в локальный список
                        projects.Add(new Project
                        {
                            project_id = newProjectId,
                            organization_id = (int)organization_choise.SelectedValue,
                            project_name = name_input.Text,
                            project_description = description_input.Text,
                            StartDate = DateTime.Parse(StartDate_input.Text),
                            EndDate = DateTime.Parse(EndDate_input.Text)
                        });
                    }
                }

                LoadProjects(); // Обновляем DataGrid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении проекта: " + ex.Message);
            }
        }


        private void Button_Click_del_prjct(object sender, RoutedEventArgs e)
        {
            if (RegProject.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите проект для удаления.");
                return;
            }

            try
            {
                // Получаем выбранный проект
                var selectedRow = RegProject.SelectedItem;
                var projectIdProperty = selectedRow.GetType().GetProperty("project_id");
                if (projectIdProperty == null) return;

                int selectedProjectId = (int)projectIdProperty.GetValue(selectedRow);

                using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                {
                    connection.Open();

                    // Подготовка запроса на удаление
                    string sqlDelete = "DELETE FROM charity_schema.projects WHERE project_id = @project_id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlDelete, connection))
                    {
                        cmd.Parameters.AddWithValue("@project_id", selectedProjectId);
                        cmd.ExecuteNonQuery();
                    }

                    // Удаление проекта из локального списка
                    projects.RemoveAll(p => p.project_id == selectedProjectId);
                }

                LoadProjects(); // Обновляем DataGrid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении проекта: " + ex.Message);
            }
        }


        private void Button_Click_up_prjct(object sender, RoutedEventArgs e)
        {
            if (RegProject.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите проект для обновления.");
                return;
            }

            try
            {
                // Получаем выбранный проект
                var selectedRow = RegProject.SelectedItem;
                var projectIdProperty = selectedRow.GetType().GetProperty("project_id");
                if (projectIdProperty == null) return;

                int selectedProjectId = (int)projectIdProperty.GetValue(selectedRow);

                using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
                {
                    connection.Open();

                    // Подготовка запроса на обновление
                    string sqlUpdate = "UPDATE charity_schema.projects SET organization_id = @organization_id, project_name = @project_name, " +
                                       "project_description = @project_description, StartDate = @StartDate, EndDate = @EndDate WHERE project_id = @project_id";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlUpdate, connection))
                    {
                        cmd.Parameters.AddWithValue("@organization_id", (int)organization_choise.SelectedValue);
                        cmd.Parameters.AddWithValue("@project_name", name_input.Text);
                        cmd.Parameters.AddWithValue("@project_description", description_input.Text);
                        cmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(StartDate_input.Text));
                        cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(EndDate_input.Text));
                        cmd.Parameters.AddWithValue("@project_id", selectedProjectId);

                        cmd.ExecuteNonQuery();
                    }

                    // Обновляем локальный список проектов
                    var project = projects.FirstOrDefault(p => p.project_id == selectedProjectId);
                    if (project != null)
                    {
                        project.organization_id = (int)organization_choise.SelectedValue;
                        project.project_name = name_input.Text;
                        project.project_description = description_input.Text;
                        project.StartDate = DateTime.Parse(StartDate_input.Text);
                        project.EndDate = DateTime.Parse(EndDate_input.Text);
                    }
                }

                LoadProjects(); // Обновляем DataGrid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении проекта: " + ex.Message);
            }
        }

        private void Registration_donation_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)//НАЧАЛА добавлять код ниже сразу ошибка инициализации появляется и проект не робит
        {
            //try
            //{
            //    var row = ItemsControl.ContainerFromElement(RegDonation, e.OriginalSource as DependencyObject) as DataGridRow;

            //    if (row != null && row.Item != null)
            //    {
            //        var selectedRow = row.Item;
            //        var donationIdProperty = selectedRow.GetType().GetProperty("donation_id");
            //        if (donationIdProperty != null)
            //        {
            //            int selectedDonationId = (int)donationIdProperty.GetValue(selectedRow);

            //            var selectedDonation = donations?.FirstOrDefault(d => d.donation_id == selectedDonationId);

            //            if (selectedDonation != null)
            //            {
            //                donor_choise.SelectedValue = selectedDonation.donor_id;
            //                project_choise.SelectedValue = selectedDonation.project_id;
            //                Amount_input.Text = selectedDonation.Amount.ToString("F2");
            //                DonationDate_input.Text = selectedDonation.DonationDate.ToString("dd-MM-yyyy");
            //            }
            //            else
            //            {
            //                MessageBox.Show("Пожертвование не найдено в коллекции.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Строка не содержит donation_id.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }



        private void Button_Click_add_dntn(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
            //    {
            //        connection.Open();

            //        string sqlInsert = "INSERT INTO charity_schema.donations (donor_id, project_id, Amount, DonationDate) " +
            //                           "VALUES (@donor_id, @project_id, @Amount, @DonationDate) RETURNING donation_id";
            //        using (NpgsqlCommand cmd = new NpgsqlCommand(sqlInsert, connection))
            //        {
            //            cmd.Parameters.AddWithValue("@donor_id", (int)donor_choise.SelectedValue);
            //            cmd.Parameters.AddWithValue("@project_id", (int)project_choise.SelectedValue);
            //            cmd.Parameters.AddWithValue("@Amount", decimal.Parse(Amount_input.Text));
            //            cmd.Parameters.AddWithValue("@DonationDate", DateTime.Parse(DonationDate_input.Text));

            //            int newDonationId = (int)cmd.ExecuteScalar();

            //            donations.Add(new Donation
            //            {
            //                donation_id = newDonationId,
            //                donor_id = (int)donor_choise.SelectedValue,
            //                project_id = (int)project_choise.SelectedValue,
            //                Amount = decimal.Parse(Amount_input.Text),
            //                DonationDate = DateTime.Parse(DonationDate_input.Text)
            //            });
            //        }
            //    }

            //    LoadDonations();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка при добавлении пожертвования: " + ex.Message);
            //}
        }

        private void Button_Click_del_dntn(object sender, RoutedEventArgs e)
        {
            //if (RegDonation.SelectedItem == null)
            //{
            //    MessageBox.Show("Пожалуйста, выберите пожертвование для удаления.");
            //    return;
            //}

            //try
            //{
            //    var selectedRow = RegDonation.SelectedItem;
            //    var donationIdProperty = selectedRow.GetType().GetProperty("donation_id");
            //    if (donationIdProperty == null) return;

            //    int selectedDonationId = (int)donationIdProperty.GetValue(selectedRow);

            //    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
            //    {
            //        connection.Open();

            //        string sqlDelete = "DELETE FROM charity_schema.donations WHERE donation_id = @donation_id";
            //        using (NpgsqlCommand cmd = new NpgsqlCommand(sqlDelete, connection))
            //        {
            //            cmd.Parameters.AddWithValue("@donation_id", selectedDonationId);
            //            cmd.ExecuteNonQuery();
            //        }

            //        donations.RemoveAll(d => d.donation_id == selectedDonationId);
            //    }

            //    LoadDonations();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка при удалении пожертвования: " + ex.Message);
            //}
        }

        private void Button_Click_up_dntn(object sender, RoutedEventArgs e)
        {
            //if (RegDonation.SelectedItem == null)
            //{
            //    MessageBox.Show("Пожалуйста, выберите пожертвование для обновления.");
            //    return;
            //}

            //try
            //{
            //    var selectedRow = RegDonation.SelectedItem;
            //    var donationIdProperty = selectedRow.GetType().GetProperty("donation_id");
            //    if (donationIdProperty == null) return;

            //    int selectedDonationId = (int)donationIdProperty.GetValue(selectedRow);

            //    using (NpgsqlConnection connection = new NpgsqlConnection(conectString))
            //    {
            //        connection.Open();

            //        string sqlUpdate = "UPDATE charity_schema.donations SET donor_id = @donor_id, project_id = @project_id, " +
            //                           "Amount = @Amount, DonationDate = @DonationDate WHERE donation_id = @donation_id";
            //        using (NpgsqlCommand cmd = new NpgsqlCommand(sqlUpdate, connection))
            //        {
            //            cmd.Parameters.AddWithValue("@donor_id", (int)donor_choise.SelectedValue);
            //            cmd.Parameters.AddWithValue("@project_id", (int)project_choise.SelectedValue);
            //            cmd.Parameters.AddWithValue("@Amount", decimal.Parse(Amount_input.Text));
            //            cmd.Parameters.AddWithValue("@DonationDate", DateTime.Parse(DonationDate_input.Text));
            //            cmd.Parameters.AddWithValue("@donation_id", selectedDonationId);

            //            cmd.ExecuteNonQuery();
            //        }

            //        var donation = donations.FirstOrDefault(d => d.donation_id == selectedDonationId);
            //        if (donation != null)
            //        {
            //            donation.donor_id = (int)donor_choise.SelectedValue;
            //            donation.project_id = (int)project_choise.SelectedValue;
            //            donation.Amount = decimal.Parse(Amount_input.Text);
            //            donation.DonationDate = DateTime.Parse(DonationDate_input.Text);
            //        }
            //    }

            //    LoadDonations();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Ошибка при обновлении пожертвования: " + ex.Message);
            //}
        }

    }
}