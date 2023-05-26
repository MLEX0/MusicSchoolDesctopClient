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
    /// Логика взаимодействия для MainFramePage.xaml
    /// </summary>
    public partial class MainFramePage : Page
    {
        public MainFramePage()
        {
            InitializeComponent();

            NavigationFrame.Content = new Pages.ProfilePage();
            BtnBorderProfile.Visibility = Visibility.Visible;
            PageController.MainFrame = NavigationFrame;
        }

        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            BtnBorderProfile.Visibility = Visibility.Visible;
            BtnBorderSchedule.Visibility = Visibility.Hidden;
            BtnBorderMarks.Visibility = Visibility.Hidden;
            BtnBorderAdmin.Visibility = Visibility.Hidden;
            PageController.MainFrame.Content = new Pages.ProfilePage();
        }

        private void ButtonSchedule_Click(object sender, RoutedEventArgs e)
        {
            BtnBorderProfile.Visibility = Visibility.Hidden;
            BtnBorderSchedule.Visibility = Visibility.Visible;
            BtnBorderMarks.Visibility = Visibility.Hidden;
            BtnBorderAdmin.Visibility = Visibility.Hidden;
            PageController.MainFrame.Content = new Pages.SchedulePage();
        }

        private void ButtonMarks_Click(object sender, RoutedEventArgs e)
        {
            BtnBorderProfile.Visibility = Visibility.Hidden;
            BtnBorderSchedule.Visibility = Visibility.Hidden;
            BtnBorderMarks.Visibility = Visibility.Visible;
            BtnBorderAdmin.Visibility = Visibility.Hidden;
            PageController.MainFrame.Content = new Pages.MarksPage();
        }



        private void ButtonAdmin_Click(object sender, RoutedEventArgs e)
        {
            BtnBorderProfile.Visibility = Visibility.Hidden;
            BtnBorderSchedule.Visibility = Visibility.Hidden;
            BtnBorderMarks.Visibility = Visibility.Hidden;
            BtnBorderAdmin.Visibility = Visibility.Visible;
            PageController.MainFrame.Content = new Pages.AdminPage();
        }


        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
