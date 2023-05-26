using MusicSchoolDesctopClient.Class;
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
        List<MusicMarks> users = new List<MusicMarks>();
        public MarksViewPage()
        {
            InitializeComponent();
            users.Add(new MusicMarks() { FirstName = "Оксана", LastName = "Иванова", SurName = "awdaw", GroupNumber = "МУЗ-1 ", Grade = "5" });
            users.Add(new MusicMarks() { FirstName = "Александор", LastName = "Орлов", SurName = "Сергеевич", GroupNumber = "МУЗ-1 ", Grade = "4" });
            users.Add(new MusicMarks() { FirstName = "Илья", LastName = "Калашников", SurName = "", GroupNumber = "МУЗ-1 ", Grade = "3" });
            lvMarksLessons.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageController.MainFrame.Content = new Pages.AddEditMark();

        }
        public class MusicMarks
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SurName { get; set; }
            public string GroupNumber { get; set; }

            public string Grade { get; set; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageController.MainFrame.Content = new Pages.MarksPage();
        }
    }
}
