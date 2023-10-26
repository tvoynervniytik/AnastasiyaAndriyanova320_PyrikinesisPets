using Microsoft.Win32;
using PyrokinesisPets.DB;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    /// 
    public partial class AddPage : Page
    {
        public static List<Albom> alboms { get; set; }
        public static Albom albom = new Albom();
        public static List<TypePets> typePets { get; set; }
        public AddPage()
        {
            InitializeComponent();

            alboms = new List<Albom>(DBConnection.sr.Albom.ToList());
            typePets = new List<TypePets>(DBConnection.sr.TypePets.ToList());
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pet = petsCb.SelectedItem as TypePets;
            albom.Id_Pet = pet.Id;
            albom.Description = descTb.Text.Trim();

            DBConnection.sr.Albom.Add(albom);
            DBConnection.sr.SaveChanges();
            MessageBox.Show("Данные внесены");
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                albom.Photo = File.ReadAllBytes(openFileDialog.FileName);
                PhotoAdd.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
