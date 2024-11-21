using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Npgsql;
using static WpfAppsamost.projectOrg;

namespace WpfAppsamost
{
    public partial class projectOrg : Window
    {
       
        private string connectionString = "Host=localhost; Port=5432; Database=postgres; User Id=postgres; Password=postgres;";

        public projectOrg()
        {
            InitializeComponent();
            LoadOrganizations();
        }

       
        public class Organization
        {
            public int OrganizationId { get; set; }
            public string OrganizationName { get; set; }
            public override string ToString() => OrganizationName; 
        }

        
        public class Project
        {
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
        }

        
        private void LoadOrganizations()
        {
            List<Organization> organizations = new List<Organization>();

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT organization_id, organization_name FROM charity_schema.organizations";
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            organizations.Add(new Organization
                            {
                                OrganizationId = reader.GetInt32(0),
                                OrganizationName = reader.GetString(1)
                            });
                        }
                    }
                }

                Organizations.ItemsSource = organizations;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке организаций: " + ex.Message);
            }
        }

        
        private void Organizations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Organizations.SelectedItem is Organization selectedOrganization)
            {
                LoadProjectsForOrganization(selectedOrganization.OrganizationId);
            }
        }

        // Метод для загрузки проектов конкретной организации
        private void LoadProjectsForOrganization(int organizationId)
        {
            List<Project> projects = new List<Project>();

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT project_id, project_name FROM charity_schema.projects WHERE organization_id = @organization_id";
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@organization_id", organizationId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                projects.Add(new Project
                                {
                                    ProjectId = reader.GetInt32(0),
                                    ProjectName = reader.GetString(1)
                                });
                            }
                        }
                    }
                }

                Projects.ItemsSource = projects;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке проектов: " + ex.Message);
            }
        }

        private void Projects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
