﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
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

        List<Record> records = new List<Record>();
        Record selectedRecord = null;
        public MainWindow()
        {
            InitializeComponent();

            //InitializeStudent();

            InitializeCourse();
        }

        private void InitializeCourse()
        {
            Teacher teacher1 = new Teacher() { TeacherName = "陳定宏" };
            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "視窗程式設計",
                OpeningClass = "五專三甲",
                Type = "必修",
                Point = 3
            });
            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "視窗程式設計",
                OpeningClass = "四技二甲",
                Type = "選修",
                Point = 3
            });
            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "視窗程式設計",
                OpeningClass = "四技二乙",
                Type = "選修",
                Point = 3
            });
            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "視窗程式設計",
                OpeningClass = "四技二丙",
                Type = "選修",
                Point = 3
            });

            Teacher teacher2 = new Teacher() { TeacherName = "陳福坤" };
            teacher2.TeachingCourses.Add(new Course(teacher2)
            {
                CourseName = "計算機概論",
                OpeningClass = "四技一丙",
                Type = "必修",
                Point = 2
            });
            teacher2.TeachingCourses.Add(new Course(teacher2)
            {
                CourseName = "計算機概論",
                OpeningClass = "四技一甲",
                Type = "必修",
                Point = 2
            });
            teacher2.TeachingCourses.Add(new Course(teacher2)
            {
                CourseName = "數位系統導論",
                OpeningClass = "四技一乙",
                Type = "必修",
                Point = 2
            });

            Teacher teacher3 = new Teacher() { TeacherName = "許子衡" };
            teacher3.TeachingCourses.Add(new Course(teacher3)
            {
                CourseName = "Android程式設計",
                OpeningClass = "四技資工三甲",
                Type = "選修",
                Point = 3
            });
            teacher3.TeachingCourses.Add(new Course(teacher3)
            {
                CourseName = "人工智慧與雲端運算",
                OpeningClass = "四技資工四甲",
                Type = "選修",
                Point = 3
            });
            teacher3.TeachingCourses.Add(new Course(teacher3)
            {
                CourseName = "動態程式語言",
                OpeningClass = "五專資工三甲",
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
        /*
        private void InitializeStudent()
        {
            students.Add(new Student { StudentId = "A1234567", StudentName = "陳一" });
            students.Add(new Student { StudentId = "A1234566", StudentName = "王二" });
            students.Add(new Student { StudentId = "A1234555", StudentName = "林三" });

            cmbStudent.ItemsSource = students;
            cmbStudent.SelectedIndex = 0;
        }
        */
        private void cmbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            if (selectedStudent != null)
            {
                labelStatus.Content = $"選取學生: 學號-{selectedStudent.StudentId}，姓名-{selectedStudent.StudentName}";
            }
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

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (selectedStudent == null || selectedCourse == null)
            {
                MessageBox.Show("請選取學生或課程");
                return;
            }
            else
            {
                Record newRecord = new Record() { SelectedStudent = selectedStudent, SelectedCourse = selectedCourse };

                foreach(Record r in records)
                {
                    if (r.Equals(newRecord))
                    {
                        MessageBox.Show($"{selectedStudent.StudentName} 已選取 {selectedCourse.CourseName}");
                        return;
                    }
                }

                records.Add(newRecord);
                lvRecord.ItemsSource = records ;
                lvRecord.Items.Refresh();
            }
        }

        private void lbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse = (Course)tvTeacher.SelectedItem;
            labelStatus.Content = $"選取課程:{selectedCourse.ToString()}";
        }

        private void lvRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRecord = (Record)lvRecord.SelectedItem;
            if(selectedRecord != null) labelStatus.Content = selectedRecord.ToString();
        }

        private void btnWithdrawl_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecord != null)
            {
                records.Remove(selectedRecord);
                lvRecord.ItemsSource=records ;
                lvRecord.Items.Refresh();
                MessageBox.Show($"{selectedStudent.StudentName} 已退選{selectedCourse.CourseName}");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json文件 (*.json)|*.json|All Files (*.*)|*.*";
            saveFileDialog.Title = "儲存學生選課紀錄";

            if(saveFileDialog.ShowDialog() == true)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };

                String jsonString = JsonSerializer.Serialize(records, options);
                File.WriteAllText(saveFileDialog.FileName, jsonString);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Json文件 (*.json)|*.json|All Files (*.*)|*.*";
                openFileDialog.Title = "選擇學生資料檔案";

                if (openFileDialog.ShowDialog() == true)
                {
                    string jsonContent = File.ReadAllText(openFileDialog.FileName);
                    List<Student> loadedStudents = JsonSerializer.Deserialize<List<Student>>(jsonContent);

                    if (loadedStudents != null)
                    {
                        cmbStudent.ItemsSource = loadedStudents;
                        cmbStudent.DisplayMemberPath = null; // 清除 DisplayMemberPath
                        cmbStudent.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"讀取學生資料時發生錯誤: {ex.Message}");
            }
        }
    }
}
