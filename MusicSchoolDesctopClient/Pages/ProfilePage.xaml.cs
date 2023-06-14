using MusicSchoolDesctopClient.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            if (TempData.TeacherUser != null) 
            {
                tbFIO.Text = $"{TempData.TeacherUser.FirstName} {TempData.TeacherUser.LastName} {TempData.TeacherUser.Patronymic}";
                tbRole.Text = "Преподаватель";

                if (!string.IsNullOrEmpty(TempData.UserImage))
                {
                    byte[] image = AppData.Context.GetImage(TempData.UserImage);
                    //загрузка изображения в приложение
                    BitmapImage biImg = new BitmapImage();
                    MemoryStream ms = new MemoryStream(image);
                    biImg.BeginInit();
                    biImg.StreamSource = ms;
                    biImg.EndInit();

                    ImageSource imgSrc = biImg as ImageSource;

                    ProfileUserImage.ImageSource = imgSrc;
                }
            }
            
        }
    }
}
