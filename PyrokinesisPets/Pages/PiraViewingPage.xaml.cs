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
    /// Логика взаимодействия для PiraViewingPage.xaml
    /// </summary>
    public partial class PiraViewingPage : Page
    {
        public static List<Albom> alboms { get; set; }
        public static List<TypePets> typePets { get; set; }
        public PiraViewingPage()
        {
            InitializeComponent();

            alboms = new List<Albom>(DBConnection.sr.Albom.ToList());
            typePets = new List<TypePets>(DBConnection.sr.TypePets.ToList());
            this.DataContext = this;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
