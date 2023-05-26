using MusicSchoolDesctopClient.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ProfileChangeLessonPage.xaml
    /// </summary>
    public partial class ProfileChangeLessonPage : Page
    {
        List<MusicLesson> musicLessons = new List<MusicLesson>();
        public ProfileChangeLessonPage()
        {
            InitializeComponent();
           
        musicLessons.Add(new MusicLesson() { Group= "МУЗ-1",
            Specification= "Музыкальное искусство",
            Class="1",
            Teaher="Роман Романов",
            DateLesson = "20.07.2023",
            TimeLesson= "16:45:00"
        });
            musicLessons.Add(new MusicLesson()
            {
                Group = "ФОЛК-3",
                Specification = "Изобразительное искусство",
                Class = "1",
                Teaher = "Иван Иванов",
                DateLesson = "21.07.2023",
                TimeLesson = "16:45:00"
            });
            musicLessons.Add(new MusicLesson()
            {
                Group = "ФОЛК-3",
                Specification = "Народное искусство",
                Class = "1",
                Teaher = "Иван Иванов",
                DateLesson = "22.07.2023",
                TimeLesson = "20:30:00"
            });

            lvGroupLessons.ItemsSource = musicLessons;
                }

        public class MusicLesson
        {
            public string Group { get; set; }

            public string Specification { get; set; }

            public string Class {get; set; }
   
            public string Teaher { get; set; }

            public string TimeLesson { get; set; }

            public string DateLesson { get; set; }
        }

    private void lvGroupLessons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lvGroupLessons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PageController.MainFrame.Content = new Pages.AddEditLesson();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageController.MainFrame.Content=new Pages.AdminPage();
        }
    }
}
