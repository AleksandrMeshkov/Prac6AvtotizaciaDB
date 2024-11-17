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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnRegistr_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLog.Text.Trim();
            string password = tbPass.Text.Trim();
            string familia = tbFam.Text.Trim();
            string otchestvo = tbotch.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

                var db = Helper.GetContext();
                {
                    if (db.Client.Any(x => x.Name == login))
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует.");
                        return;
                    }

                    var newUser = new Client
                    {
                        Name = login,
                        Password = password,
                        Surname = familia,
                        Patronymic = otchestvo,
                        Id_Role = 2 
                    };

                    db.Client.Add(newUser);

                    db.SaveChanges();

                    MessageBox.Show("Пользователь успешно добавлен!");

                    NavigationService.Navigate(new Autho());
                }
            
        }

        private void tbPass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbLog_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbotch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbFam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
