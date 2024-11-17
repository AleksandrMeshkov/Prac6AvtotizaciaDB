using Prac6AvtotizaciaDB.Pages;
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

namespace Prac6AvtotizaciaDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frContent.Content = new Autho();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            frContent.GoBack();
        }


        private void frContent_Content_ContentRendered(object sender, EventArgs e)
        {
            if (frContent.CanGoBack)
                btnBack.Visibility = Visibility.Visible;
            else
                btnBack.Visibility = Visibility.Hidden;

        }

        private void frContent_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
