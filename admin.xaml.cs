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
        public delegate void Refresh();
        public static Refresh odswiez;
        int idosoby;
        public admin()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public admin(int idosoby): this()
        {
            this.idosoby = idosoby;
        }
        ~admin()
        {
            odswiez();
        }
        private void btnProjekcja_Click(object sender, RoutedEventArgs e)
        {
            var page= new StronyAdmin.Projekcja();
            AdminContent.Content = page;
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

            AdminContent.Content = new StronyAdmin.OsobaEdycja();
            lbl_Witaj.Content = "Edycja Konta";
        }

        private void btnKonto_Click(object sender, RoutedEventArgs e)
        {
            AdminContent.Content = new StronyAdmin.ZmienSwojeDane();
            lbl_Witaj.Content = "Ustawienia Konta";
        }

        private void btnWyloguj_Click(object sender, RoutedEventArgs e)
        {
                var result = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Wylogowanie", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
        }
    }
}
