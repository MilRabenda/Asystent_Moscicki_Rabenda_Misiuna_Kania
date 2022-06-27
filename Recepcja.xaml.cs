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
using DatabaseCommunication;
using MySql.Data.MySqlClient;

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy Recepcja.xaml
    /// </summary>
    public partial class Recepcja : Window
    {
        public delegate void updateStrona(List<Osoba> osobas);
        public updateStrona updateStr;
        public delegate void updateStronaWiz(List<Wizyta> wizytas);
        public updateStronaWiz updateStrWiz;
        private int idOsoby { get; set; }
        private int idRecepcjonistki { get; set; }

        public Recepcja()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public Recepcja(int idOsoby) : this()
        {
            if (idOsoby < 0) throw new Exception("Recepcja idOsoby<0");
            this.idOsoby = idOsoby;
            this.idRecepcjonistki = getIdRecepcjonistki(idOsoby);
            lbl_Witaj.Content = "Witaj, " + Getters.getImie(idOsoby);
            osobas = getLudzie();
            wizyty = getWizyty();
            //MessageBox.Show(osobas.ElementAt(idOsoby - 1).ToString());
        }
        public static int getIdRecepcjonistki(int idOsoby)
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"SELECT idrecepcjonistki FROM personelrecepcji where idosoby='{idOsoby}'", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                int licz = -1;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        licz = reader.GetInt32(0);
                    }
                }
                reader.Close();
                połączenie.Close();
                return licz;
            }
        }
        
        private void btn_EditKonta_Click(object sender, RoutedEventArgs e)
        {
            var strona = new StronyRecepcja.StronaEditKonta();
            strona.DoubleClick = editKonto;
            this.updateStr = strona.updateContent;
            MessageBox.Show("I am here");
            updateStr(osobas);
            stronaWyswietlana.Content = strona;

        }
        public void editKonto(int idOs)
        {
            var s = new Osoba(idOs+1);
            var window = new StronyRecepcja.EditKontoWindow(s);
            window.ShowDialog();
            updateOsobas();
        }

        private void btn_Wyloguj_Click(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Wylogowanie", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }
        private void btn_EditWizyty_Click(object sender, RoutedEventArgs e)
        {
            var window = new StronyRecepcja.StronaEditWizyty();
            window.DoubleClick = editWizyta;
            this.updateStrWiz = window.updateContent;
            updateStrWiz(wizyty);

            stronaWyswietlana.Content = window;

        }
        public void editWizyta(int ixWizyty)
        {
            var wiz = wizyty[ixWizyty];
            var window = new StronyRecepcja.EditWizytaWindow(wiz);
            window.ShowDialog();
            updateWiz();
        }
        public void updateWiz()
        {
            wizyty = getWizyty();
            updateStrWiz(wizyty);
        }
        private void lstBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstBox.SelectedIndex == 0) MessageBox.Show(osobas.ElementAt(0).ToString());
        }
        public static List<Osoba> osobas;
        public List<Osoba> getLudzie()
        {
            using(MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
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
        public List<Wizyta> getWizyty()
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"select * from wizyta", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                List<Wizyta> lista = new List<Wizyta>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var f = reader.GetInt32(0);
                        var g = reader.GetInt32(1);
                        var h = reader.GetInt32(2);
                        var i = reader.GetDateTime(3);
                        var j = reader.GetInt32(4);

                        Wizyta wiz = new Wizyta(f, g, h, i, j);
                        lista.Add(wiz);
                    }
                }
                reader.Close();
                połączenie.Close();
                return lista;
            }
        }
        public void updateOsobas()
        {
            osobas = getLudzie();
            updateStr(osobas);
        }
        public List<Wizyta> wizyty;
        public void updateWizyty()
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"select * from wizyta", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                List<Wizyta> lista = new List<Wizyta>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var f = reader.GetInt32(0);
                        var g = reader.GetInt32(1);
                        var h = reader.GetInt32(2);
                        var i = reader.GetDateTime(3);
                        var j = reader.GetInt32(4);

                        Wizyta wiz = new Wizyta(f, g, h, i, j);
                        lista.Add(wiz);
                    }
                }
                wizyty = lista;
                reader.Close();
                połączenie.Close();
            }

        }



    }
}
