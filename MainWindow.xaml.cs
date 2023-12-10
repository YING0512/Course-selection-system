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

        List<Course> courses = new List<Course>();
        Course selectedCourse = null;

        List<Teacher> teachers = new List<Teacher>();
        Teacher selectedTeacher = null;
        public MainWindow()
        {
            InitializeComponent();

            InitializeStudent();

            InitializeCourse();
        }

        private void InitializeCourse()
        {
            Teacher teacher1 = new Teacher() { TeacherName = "陳定宏" };
            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "視窗程式設計",
                OpeniingClass = "五專三甲",
                Type = "必修",
                Point = 3
            });
            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "視窗程式設計",
                OpeniingClass = "四技二甲",
                Type = "選修",
                Point = 3
            });
            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "視窗程式設計",
                OpeniingClass = "四技二乙",
                Type = "選修",
                Point = 3
            });
            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "視窗程式設計",
                OpeniingClass = "四技二丙",
                Type = "選修",
                Point = 3
            });

            Teacher teacher2 = new Teacher() { TeacherName = "陳福坤" };
            teacher2.TeachingCourses.Add(new Course(teacher2)
            {
                CourseName = "計算機概論",
                OpeniingClass = "四技一丙",
                Type = "必修",
                Point = 2
            });
            teacher2.TeachingCourses.Add(new Course(teacher2)
            {
                CourseName = "計算機概論",
                OpeniingClass = "四技一甲",
                Type = "必修",
                Point = 2
            });
            teacher2.TeachingCourses.Add(new Course(teacher2)
            {
                CourseName = "數位系統導論",
                OpeniingClass = "四技一乙",
                Type = "必修",
                Point = 2
            });

            Teacher teacher3 = new Teacher() { TeacherName = "許子衡" };
            teacher3.TeachingCourses.Add(new Course(teacher3)
            {
                CourseName = "Android程式設計",
                OpeniingClass = "四技資工三甲",
                Type = "選修",
                Point = 3
            });
            teacher3.TeachingCourses.Add(new Course(teacher3)
            {
                CourseName = "人工智慧與雲端運算",
                OpeniingClass = "四技資工四甲",
                Type = "選修",
                Point = 3
            });
            teacher3.TeachingCourses.Add(new Course(teacher3)
            {
                CourseName = "動態程式語言",
                OpeniingClass = "五專資工三甲",
                Type = "選修",
                Point = 3
            });

            teachers.Add(teacher1);
            teachers.Add(teacher2);
            teachers.Add(teacher3);

            tvTeacher.ItemsSource = teachers;

            foreach (Teacher teacher in teachers)
            {
                foreach(Course course in teacher.TeachingCourses)
                {
                    courses.Add(course);
                }
                lbCourse.ItemsSource = courses;
            }
        }

        private void InitializeStudent()
        {
            students.Add(new Student { StudentId = "A1234567", StudentName = "陳一" });
            students.Add(new Student { StudentId = "A1234566", StudentName = "王二" });
            students.Add(new Student { StudentId = "A1234555", StudentName = "林三" });

            cmbStudent.ItemsSource = students;
            cmbStudent.SelectedIndex = 0;
        }

        private void cmbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            labelStatus.Content = $"選取學生:{selectedStudent.ToString()}";
        }

        private void tvTeacher_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(tvTeacher.SelectedItem is Teacher)
            {
                selectedTeacher = (Teacher)tvTeacher.SelectedItem;
                labelStatus.Content = $"選取教師:{selectedTeacher.ToString()}";
            }
            else if(tvTeacher.SelectedItem is Course)
            {
                selectedCourse = (Course)tvTeacher.SelectedItem;
                labelStatus.Content = $"選取課程:{selectedCourse.ToString()}";
            }
        }
    }
}
