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

namespace Course_selection_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        Student selectedStudent = null;
        public MainWindow()
        {
            InitializeComponent();

            InitializeStudent();
        }

        private void InitializeStudent()
        {
            students.Add(new Student { StudentId = "A1234567", StudentName = "陳一" });
            students.Add(new Student { StudentId = "A1234566", StudentName = "王二" });
            students.Add(new Student { StudentId = "A1234555", StudentName = "林三" });

            cmbStudent.ItemsSource = students;
        }

        private void cmbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            labelStatus.Content = $"選取學生:{selectedStudent.ToString()}";
        }
    }
}
