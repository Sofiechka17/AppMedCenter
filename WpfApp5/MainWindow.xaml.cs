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
using WpfApp5.Data;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TeacherDbContext dbContext;
        Teacher newTeacher = new Teacher();
        public MainWindow(TeacherDbContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetTeachers();

            DGAdd.DataContext = newTeacher;
        }

        private void GetTeachers()
        {
            DGTeacher.ItemsSource = dbContext.Teachers.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            dbContext.Teachers.Add(newTeacher);
            dbContext.SaveChanges();
            GetTeachers();
            newTeacher = new Teacher();
            DGAdd.DataContext = newTeacher;
        }

        Teacher selectedTeacher = new Teacher();
        private void UpdateClick(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedTeacher);
            dbContext.SaveChanges();
            GetTeachers();
        }

        private void UpdateClickForEdit(object s, RoutedEventArgs e)
        {
            selectedTeacher = (s as FrameworkElement).DataContext as Teacher;
            DGUpdate.DataContext = selectedTeacher;
        }

        private void DeleteClick(object s, RoutedEventArgs e)
        {
            var teacherForDelete = (s as FrameworkElement).DataContext as Teacher;
            dbContext.Teachers.Remove(teacherForDelete);
            dbContext.SaveChanges();
            GetTeachers();
        }
    }
}