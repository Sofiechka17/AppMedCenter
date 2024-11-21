using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateFileButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = fileNameTextBox.Text;
            string fileContent = fileContentTextBox.Text;

            // Путь к файлу в текущей директории
            string filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName);

            // Запись текста в файл
            File.WriteAllText(filePath, fileContent);

            MessageBox.Show("File created successfully.");
        }
    }
}


