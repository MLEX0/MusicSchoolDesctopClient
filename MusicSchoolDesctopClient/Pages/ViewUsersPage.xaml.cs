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

namespace MusicSchoolDesctopClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewUsersPage.xaml
    /// </summary>
    public partial class ViewUsersPage : Page
    {
        List<MusicUser> users = new List<MusicUser>();
        public ViewUsersPage()
        {
            InitializeComponent();
            users.Add(new MusicUser() { FirstName = "Оксана", LastName = "Иванова", Surname = "awdaw", Role="Учитель", image = "Image\\images.png" });
            users.Add(new MusicUser() { FirstName = "Александор", LastName = "Орлов", Surname = "Сергеевич", Role = "Студент" , image = "Image\\images.png" });
            users.Add(new MusicUser() { FirstName = "Илья", LastName = "Калашников", Surname = "", Role = "Учитель", image = "Image\\images.png" });
            lvGroupLessons.ItemsSource = users;
        }
        public class MusicUser
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Surname { get; set; }
            public string Role { get; set; }

            public string image {get; set; }
        }

        private void lvGroupLessons_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PageController.MainFrame.Content = new Pages.AddEditUserPage();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageController.MainFrame.Content = new Pages.AdminPage();
        }
    }
}
