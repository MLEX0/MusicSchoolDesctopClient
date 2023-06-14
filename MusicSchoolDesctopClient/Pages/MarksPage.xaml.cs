using MusicSchoolDesctopClient.Class;
using MusicSchoolDesctopClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для MarksPage.xaml
    /// </summary>
    public partial class MarksPage : Page
    {

        public MarksPage()
        {
            InitializeComponent();

            GetScheduleForTeacher();
        }

        private async void GetScheduleForTeacher()
        {
            List<TeacherSchedule> listShedule = new List<TeacherSchedule>();
            listShedule = await AppData.Context.GetTeacherScheduleByID(TempData.TeacherUser.ID);


            lvGroupLessons.ItemsSource = listShedule;
        }

        private void lvGroupLessons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //if(sender is Grid)
            //PageController.MainFrame.Content = new Pages.MarksViewPage();
        }

        private void lvGroupLessons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid) 
            {
                if (grid.DataContext is TeacherSchedule teacherSchedule) 
                {
                    PageController.MainFrame.Content = new Pages.MarksViewPage(teacherSchedule);
                }
            }
        }
    }


}
