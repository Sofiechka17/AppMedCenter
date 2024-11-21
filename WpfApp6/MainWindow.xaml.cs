using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp6.DataModel;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (TeacherDbContext context = new TeacherDbContext())
            {
                Teacher teacher = new Teacher();
                teacher.FullName = "Иванов Иван Петрович";
                teacher.Seniority = 5;
                teacher.Number = "89097865786";
            }
        }
    }
}