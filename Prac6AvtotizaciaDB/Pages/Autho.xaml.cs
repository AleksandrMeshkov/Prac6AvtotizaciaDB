using Prac6AvtotizaciaDB.Models;
using Prac6AvtotizaciaDB.Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Prac6AvtotizaciaDB.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        int click;

        public Autho()
        {
            InitializeComponent();
            click = 0;
        }

        private void btnEnterGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage(null, null));
        }

        private void GenerateCapctcha()
        {
            tbCaptcha.Visibility = Visibility.Visible;
            tblCaptcha.Visibility = Visibility.Visible;

            string capctchaText = CaptchaGenerator.GenerateCaptchaText(6);
            tblCaptcha.Text = capctchaText;
            tblCaptcha.TextDecorations = TextDecorations.Strikethrough;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            click += 1;
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Text.Trim();

            var db = Helper.GetContext();
            var user = db.Client.Where(x => x.Name == login && x.Password == password).FirstOrDefault();

                if (click == 1)
                {
                    if (user != null && user.Role != null && user.Role.Role_Name != null)
                    {
                        MessageBox.Show("Вы вошли под: " + user.Role.Role_Name.ToString());
                        LoadPage(user.Role.Role_Name.ToString(), user);
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели логин или пароль неверно!");
                        GenerateCapctcha();
                    }
                }
                else if (click > 1)
                {
                    if (user != null && user.Role != null && user.Role.Role_Name != null && tbCaptcha.Text == tblCaptcha.Text)
                    {
                        MessageBox.Show("Вы вошли под: " + user.Role.Role_Name.ToString());
                        LoadPage(user.Role.Role_Name.ToString(), user);
                    }
                    else
                    {
                        MessageBox.Show("Введите данные заново!");
                    }
                }
            
        }
        private void LoadPage(string _role, Client user)
        {
            click = 0;
            switch (_role)
            {
                case "Клиент":
                    NavigationService.Navigate(new ClientPage(user, _role));
                    break;
            }
        }

        private void tbCaptcha_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            NavigationService.Navigate(new Uri("RegisterPage.xaml", UriKind.Relative));
        }

    }
}
