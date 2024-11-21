using CsvHelper;
using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace WpfAppExport
{
    /// <summary>
    /// Логика взаимодействия для WindowImport.xaml
    /// </summary>
    public partial class WindowImport : Window
    {
        public WindowImport()
        {
            InitializeComponent();
        }
        private void ImportCsvButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Select a CSV file"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var filePath = openFileDialog.FileName;
                List<Donor> donors;

                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    donors = csv.GetRecords<Donor>().ToList();
                }

                // Здесь добавьте код для отображения данных в вашем DataGrid или другой контроле
                MessageBox.Show($"{donors.Count} records imported from CSV.");
            }
        }

        private void Button_Click_export(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            this.Close();
            mainwindow.ShowDialog();
        }
    }

    public class Donor
    {
        public int donor_id { get; set; }
        public string donor_fullname { get; set; }
        public string donor_phone { get; set; }
        public DateTime donor_datereg { get; set; }
        public int donor_age { get; set; }
    }

}