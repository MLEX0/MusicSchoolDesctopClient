using MusicSchoolDesctopClient.Class;
using MusicSchoolDesctopClient.Model;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            try
            {
                AppData.updateContext();
                AppData.Context.RunAsync().GetAwaiter().GetResult();
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с сервером!" +
                    "\nПожалуйста, запустите сервер заново запустите приложение!",
                    "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Application.Current.Shutdown();
            }

            //PageController.MainFrame = MainFrame;

            //PageController.MainFrame.Content = new Pages.MarksPage();
        }

        private async void Auth() 
        {
            if (String.IsNullOrWhiteSpace(txtEmail.Text)) 
            {
                MessageBox.Show("Поле \"Email\" не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(PasswordBoxAuth.Password))
            {
                MessageBox.Show("Поле \"Пароль\" не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User user = new User();
            user.Email = txtEmail.Text;
            user.Password = PasswordBoxAuth.Password;

            AuthUser authUser = new AuthUser();
            authUser = await AppData.Context.Authorization(user);
            if (authUser.message == null)
            {
                if (authUser.IDRole != null) 
                {
                    switch (authUser.IDRole)
                    {
                        case "1":
                            MessageBox.Show("В данной версии приложения отсутствует функционал администратора." +
                                "\nВоспользуйтесь интерфесом СУБД.", 
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        case "2":
                            TempData.UserID = authUser.IdUser;
                            TempData.UserRoleID = authUser.IDRole;
                            TempData.UserImage = authUser.UserImage;
                            TempData.UserToken = authUser.token;
                            TempData.TeacherUser = await AppData.Context.GetTeacherByID(TempData.UserID);

                            NavigationService.Navigate(new Pages.MainFramePage());
                            break;
                        case "3":
                            MessageBox.Show("У вас нет прав для использования этого приложения." +
                                            "\nВоспользуйтесь мобильным приложением.",
                                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        default:
                            break;
                    }
                }
            }
            else 
            {
                MessageBox.Show(authUser.message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAuth_Click(object sender, RoutedEventArgs e)
        {
            Auth();
        }

    }
}
