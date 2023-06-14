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
using static MusicSchoolDesctopClient.Pages.ViewUsersPage;

namespace MusicSchoolDesctopClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для MarksViewPage.xaml
    /// </summary>
    public partial class MarksViewPage : Page
    {
        List<StudentGrade> marks = new List<StudentGrade>();
        private TeacherSchedule _thisLesson;
        public MarksViewPage(TeacherSchedule lesson)
        {
            InitializeComponent();

            _thisLesson = lesson;

            GetLessonMarks(lesson.IDLesson);
        }

        private async void GetLessonMarks(int lessonID)
        {
            marks = await AppData.Context.GetLessonMarksByID(lessonID);

            lvMarksLessons.ItemsSource = marks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            PageController.MainFrame.Content = new Pages.AddEditMark(_thisLesson, marks);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageController.MainFrame.Content = new Pages.MarksPage();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                if (grid.DataContext is StudentGrade editGrade)
                {
                    PageController.MainFrame.Content = new Pages.AddEditMark(_thisLesson, editGrade);
                }
            }
        }
    }
}
