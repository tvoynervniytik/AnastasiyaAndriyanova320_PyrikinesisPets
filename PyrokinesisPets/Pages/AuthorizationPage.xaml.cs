using PyrokinesisPets.DB;
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

namespace PyrokinesisPets.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Administrator> administrators {  get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();

            administrators = new List<Administrator>(DBConnection.sr.Administrator.ToList());
            Administrator currentUser = administrators.FirstOrDefault(i => i.Login == login && i.Password == password);
            if (currentUser != null)
            {
                if (currentUser.Name == "Андрей")
                {
                    MessageBox.Show("Привет, Андрей!! (тутутуту)");
                    NavigationService.Navigate(new PiraViewingPage());
                }
                else if (currentUser.Name == "Деля")
                {
                    MessageBox.Show("Это Деля)");
                    NavigationService.Navigate(new DelyaViewingPage());
                }

                
            }
            else
                MessageBox.Show("All's wrong");
        }
    }
}
