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
    /// Логика взаимодействия для SharedAlbomPage.xaml
    /// </summary>
    public partial class SharedAlbomPage : Page
    {
        public static List<Albom> alboms { get; set; }
        public static List<TypePets> typePets { get; set; }
        public SharedAlbomPage()
        {
            InitializeComponent();
            alboms = new List<Albom>(DBConnection.sr.Albom.ToList());
            typePets = new List<TypePets>(DBConnection.sr.TypePets.ToList());
            this.DataContext = this;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            sharedalbSlv.ItemsSource = new List<Albom>(DBConnection.sr.Albom.Where(i => i.Id_Pet == 1 && i.Description.StartsWith(SearchTb.Text)).ToList());
        }

        private void SearchCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
