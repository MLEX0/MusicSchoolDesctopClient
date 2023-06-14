using MusicSchoolDesctopClient.Class;
using MusicSchoolDesctopClient.Model;
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

namespace MusicSchoolDesctopClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditMark.xaml
    /// </summary>
    public partial class AddEditMark : Page
    {
        private TeacherSchedule _thisLesson;
        private List<Student> students;
        List<int> marks = new List<int>();
        private bool _isEdit;
        private StudentGrade EditGrade = null;
        public AddEditMark(TeacherSchedule lesson, List<StudentGrade> existsMarks)
        {
            InitializeComponent();
            _isEdit = false;
            _thisLesson = lesson;
            students = new List<Student>();

            txtLesson.Text = lesson.SubjectName;

            marks.Add(2);
            marks.Add(3);
            marks.Add(4);
            marks.Add(5);

            cmbMark.ItemsSource = marks;
            cmbMark.SelectedItem = 5;

            GetStudentsAdd(existsMarks);
        }

        public AddEditMark(TeacherSchedule lesson, StudentGrade editGrade)
        {
            InitializeComponent();
            _isEdit = true;
            EditGrade = editGrade;
            _thisLesson = lesson;
            students = new List<Student>();

            txtLesson.Text = lesson.SubjectName;
            btnAddEditMark.Content = "Изменить";

            marks.Add(2);
            marks.Add(3);
            marks.Add(4);
            marks.Add(5);

            cmbMark.ItemsSource = marks;
            cmbMark.SelectedItem = editGrade.IDGrade;

            GetStudentsEdit(EditGrade);
        }

        private async void GetStudentsAdd(List<StudentGrade> existsMarks) 
        {
            students = await AppData.Context.GetStudentsByLessonID(_thisLesson.IDLesson);

            foreach (StudentGrade existStudent in existsMarks) 
            {
                Student student = students.Where(i => i.ID == existStudent.IDStudent).ToList().FirstOrDefault();
                if (student != null) 
                { 
                    students.Remove(student);
                }
            }

            students = students.OrderBy(x => x.Patronymic).OrderBy(x=>x.FirstName).OrderBy(x=>x.LastName).ToList();
            cmbStudents.ItemsSource = students;
            cmbStudents.DisplayMemberPath = "FIO";
            cmbStudents.SelectedIndex = 0;
        }


        private async void GetStudentsEdit(StudentGrade editGrade)
        {
            students = await AppData.Context.GetStudentsByLessonID(_thisLesson.IDLesson);

            Student student = students.Where(x=>x.ID == editGrade.IDStudent).FirstOrDefault();

            students.Clear();
            students.Add(student);

            cmbStudents.ItemsSource = students;
            cmbStudents.DisplayMemberPath = "FIO";
            cmbStudents.SelectedIndex = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageController.MainFrame.Content = new Pages.MarksViewPage(_thisLesson);
        }

        private async void AddMark() 
        {
            Grade grade = new Grade();
            grade.ID = -1;
            grade.IDGrade = Convert.ToInt32(cmbMark.SelectedItem);
            grade.IDStudent = Convert.ToInt32((cmbStudents.SelectedItem as Student).ID);
            grade.IDLesson = _thisLesson.IDLesson;

            Grade newGrade = new Grade();
            newGrade = await AppData.Context.AddMark(grade);

            if (newGrade.ID > 0)
            {
                MessageBox.Show("Оценка успешно добавлена!",
                                "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                PageController.MainFrame.Content = new Pages.MarksViewPage(_thisLesson);
            }
            else 
            {
                MessageBox.Show("Оценка не была добавлена!" +
                                "\nПроверьте соединение с сервером",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void EditMark()
        {
            Grade grade = new Grade();
            grade.ID = EditGrade.IDStudentGrade;
            grade.IDGrade = Convert.ToInt32(cmbMark.SelectedItem);
            grade.IDStudent = Convert.ToInt32((cmbStudents.SelectedItem as Student).ID);
            grade.IDLesson = _thisLesson.IDLesson;

            Grade editGrade = new Grade();
            editGrade = await AppData.Context.EditMark(grade);

            if (editGrade.ID > 0)
            {
                MessageBox.Show("Оценка успешно изменена!",
                                "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                PageController.MainFrame.Content = new Pages.MarksViewPage(_thisLesson);
            }
            else
            {
                MessageBox.Show("Оценка не была изменена!" +
                                "\nПроверьте соединение с сервером",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAddEditMark_Click(object sender, RoutedEventArgs e)
        {
            if (_isEdit) 
            {
                EditMark();
            }
            else 
            {
                AddMark();
            }
        }
    }
}
