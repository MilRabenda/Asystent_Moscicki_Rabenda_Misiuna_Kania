using DatabaseCommunication;
using MySql.Data.MySqlClient;
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
        public delegate void updateStrona(List<Osoba> osobas);
        public updateStrona updateStr;
        public delegate void Refresh();
        public static Refresh odswiez;
        public static List<Osoba> osobas;
        int idosoby;
        public admin()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public admin(int idosoby): this()
        {
            this.idosoby = idosoby;
            osobas = getLudzie();
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
            var strona = new StronyRecepcja.StronaEditKonta();
            strona.DoubleClick = editKonto;
            this.updateStr = strona.updateContent;
            lbl_Witaj.Content = "Edycja Konta";
            updateStr(osobas);
            AdminContent.Content = strona;
        }
        public void editKonto(int idOs)
        {
            var s = new Osoba(idOs + 1);
            var window = new StronyRecepcja.EditKontoWindow(s);
            window.ShowDialog();
            updateOsobas();
        }
        public void updateOsobas()
        {
            osobas = getLudzie();
            updateStr(osobas);
        }
        public List<Osoba> getLudzie()
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"select * from osoba", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                List<Osoba> lista = new List<Osoba>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var n = reader.GetString(1);
                        var i = reader.GetString(2);
                        var a = reader.GetString(3);
                        var p = reader.GetString(4);
                        var m = reader.GetString(5);
                        var t = reader.GetString(6);
                        var h = reader.GetString(7);
                        bool inAct = reader.GetBoolean(8);


                        if (inAct) lista.Add(new Osoba(id, n, i, a, p, m, t, h, inAct));
                    }
                }
                reader.Close();
                połączenie.Close();
                osobas = lista;
                return lista;
            }
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
