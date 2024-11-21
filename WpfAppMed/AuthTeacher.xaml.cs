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
    /// Логика взаимодействия для AuthTeacher.xaml
    /// </summary>
    public partial class AuthTeacher : Window
    {
        public AuthTeacher()
        {
            InitializeComponent();
        }

        private void btn_ok(object sender, RoutedEventArgs e)
        {
            TeacherWindow teacherWindow = new TeacherWindow();//Создание нового окна
            this.Close();// закрытие этого окна
            teacherWindow.ShowDialog();//отображение
        }

        private void btn_cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
