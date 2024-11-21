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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp7.DataModel;

namespace WpfApp7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (TeacherContext context = new TeacherContext())
            {
                Teacher teacher = new Teacher();
                teacher.FullName = "Иванов Иван Петрович";
                teacher.Seniority = 5;
                teacher.Number = "89097865786";

                context.Teachers.Add(teacher);
                context.SaveChanges();
            }
        }
    }
}
