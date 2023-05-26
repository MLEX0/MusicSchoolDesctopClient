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
    /// Логика взаимодействия для AddEditLesson.xaml
    /// </summary>
    public partial class AddEditLesson : Page
    {
        public AddEditLesson()
        {
            InitializeComponent();
        }

        public AddEditLesson(String da)
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageController.MainFrame.Content = new Pages.ProfileChangeLessonPage();
        }
    }
}
