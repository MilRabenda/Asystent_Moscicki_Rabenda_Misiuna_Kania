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
using System.Windows.Shapes;

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnProjekcja_Click(object sender, RoutedEventArgs e)
        {
            AdminContent.Content = new StronyAdmin.Projekcja();
            lbl_Witaj.Content = "Projekcja Strony Głównej";
            
        }

        private void btnDodajBadanie_Click(object sender, RoutedEventArgs e)
        {
            AdminContent.Content = new StronyAdmin.BadaniaDodaj();
            lbl_Witaj.Content = "Dodaj Nowe Badanie";
        }

        private void btnEdytujBadanie_Click(object sender, RoutedEventArgs e)
        {
            AdminContent.Content = new StronyAdmin.BadaniaEdycja();
            lbl_Witaj.Content = "Edytuj Badanie";
        }

        private void btnDodajOsobe_Click(object sender, RoutedEventArgs e)
        {
            AdminContent.Content = new StronyAdmin.OsobaDodaj();
            lbl_Witaj.Content = "Dodaj Nową Osobę";
        }

        private void btnEdytujOsobe_Click(object sender, RoutedEventArgs e)
        {
            
            var window = new StronyRecepcja.EditKontoWindow();
            window.ShowDialog();
            //updateOsobas();
        }

        private void btnKonto_Click(object sender, RoutedEventArgs e)
        {
            AdminContent.Content = new StronyAdmin.ZmienSwojeDane();
            lbl_Witaj.Content = "Edycja Konta";
        }
    }
}
