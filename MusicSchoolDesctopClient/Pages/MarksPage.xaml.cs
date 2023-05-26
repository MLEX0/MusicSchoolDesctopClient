using MusicSchoolDesctopClient.Class;
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

            List<MusicSpecialty> specialties = new List<MusicSpecialty>();
            specialties.Add(new MusicSpecialty() { GroupNumber = "МУЗ-1", SubjectName = "Фортепиано", LessonDate = "25.05.2023 10:00" });
            specialties.Add(new MusicSpecialty() { GroupNumber = "МУЗ-2", SubjectName = "Скрипка", LessonDate = "25.05.2023 13:15" });
            specialties.Add(new MusicSpecialty() { GroupNumber = "МУЗ-3", SubjectName = "Гитара", LessonDate = "25.05.2023 16:10" });
            specialties.Add(new MusicSpecialty() { GroupNumber = "ХОР-1", SubjectName = "Основы музыки", LessonDate = "25.05.2023 10:40" });
            specialties.Add(new MusicSpecialty() { GroupNumber = "ХОР-2", SubjectName = "Вокал", LessonDate = "25.05.2023 10:40" });

            lvGroupLessons.ItemsSource = specialties;
        }

        private void lvGroupLessons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PageController.MainFrame.Content = new Pages.MarksViewPage();
        }

        public class MusicSpecialty
        {
            public string SubjectName { get; set; }
            public string GroupNumber { get; set; }
            public string LessonDate { get; set; }
        }

        private void lvGroupLessons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }


}
