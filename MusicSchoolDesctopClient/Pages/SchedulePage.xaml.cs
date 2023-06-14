using MusicSchoolDesctopClient.Elements;
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
using MusicSchoolDesctopClient.Class;
using MusicSchoolDesctopClient.Model;

namespace MusicSchoolDesctopClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        public  SchedulePage()
        {
            InitializeComponent();

            GetScheduleForTeacher();
        }

        private async void GetScheduleForTeacher() 
        {
            List<TeacherSchedule> listShedule = new List<TeacherSchedule>();
            listShedule = await AppData.Context.GetTeacherScheduleByID(TempData.TeacherUser.ID);


            List<string> time = new List<string>() { "9:00:00", "9:45:00", "10:30:00", "11:15:00", "12:00:00", "12:45:00", "13:30:00", "13:15:00",
                "14:00:00", "14:45:00", "15:30:00"
            , "16:15:00", "17:00:00", "17:45:00", "18:30:00", "19:15:00", "20:00:00", "20:45:00", "21:30:00", "22:15:00", "23:00:00"
            };

            foreach (TeacherSchedule s in listShedule)
            {
                int positionRow = 0;
                Elements.Schedule shedule = new Elements.Schedule();
                shedule.numGroup.Text = s.GroupNumber;
                shedule.claaRoom.Text = s.ClassroomNumber.ToString();
                shedule.Floor.Text = s.Floor.ToString();
                shedule.startTime.Text = $"{s.StartTime.Hours.ToString()}:{s.StartTime.Minutes.ToString()}";
                shedule.subject.Text = s.SubjectName;



                SheduleGrid.Children.Add(shedule);

                var temp = (time.Where(i => TimeSpan.Parse(i) >= s.StartTime && TimeSpan.Parse(i) <= s.StartTime.Add(new TimeSpan(00, 45, 0))).FirstOrDefault());
                positionRow = time.IndexOf(temp);

                Grid.SetColumn(shedule, s.WeekDayNumber);

                Grid.SetRow(shedule, positionRow);
                string str = s.SubjectName;

                int hashCode = s.GroupNumber.GetHashCode();
                Random random = new Random(hashCode);
                Color randomColor = Color.FromArgb(Convert.ToByte(random.Next(256)), Convert.ToByte(random.Next(256)), Convert.ToByte(random.Next(256)), 255);
                shedule.mainBorder.Background = new SolidColorBrush(randomColor);

            }

        } 
    }
}
