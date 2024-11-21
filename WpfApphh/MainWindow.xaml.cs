using System;
using Microsoft.EntityFrameworkCore;
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
using WpfApphh.DataModel;
using System.Linq;
using WpfApphh.DataModel.WpfApphh.DataModel;

namespace WpfApphh
{
    public partial class MainWindow : Window
    {
        private YourDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new YourDbContext();

            DbInitializer.Initialize(_context);

            LoadTeachers();
            LoadComboBoxValues();
        }

        private void LoadTeachers()
        {
#pragma warning disable IDE0037 // Использовать имя выводимого элемента
            var teacherWithTeachersCourse = _context.Teachers
                                       .Include(t => t.TeachersCourse)
                                       .Select(t => new
                                       {
                                           TeacherFullName = t.FullName,
                                           Seniority = t.Seniority,
                                           PhoneNumber = t.PhoneNumber,
                                           TeachersCourseCourse = t.TeachersCourse.Course
                                       })
                                       .ToList();
#pragma warning restore IDE0037 // Использовать имя выводимого элемента

            TeachersDataGrid.ItemsSource = teacherWithTeachersCourse;
        }

        private void LoadComboBoxValues()
        {
            var quantities = _context.Teachers.Select(t => t.Seniority).Distinct().ToList();
            SeniorityFilterComboBox.ItemsSource = quantities;
        }

        private void SeniorityFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SeniorityFilterComboBox.SelectedItem != null)
            {
                int selectedQuantity = (int)SeniorityFilterComboBox.SelectedItem;
                var filteredTeachers = _context.Teachers.Where(t => t.Seniority == selectedQuantity).ToList();
                TeachersDataGrid.ItemsSource = filteredTeachers;
            }
        }
    }
 }
