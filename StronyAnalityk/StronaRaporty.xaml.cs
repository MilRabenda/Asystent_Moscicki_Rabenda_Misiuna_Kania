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
using MySql.Data.MySqlClient;
using DatabaseCommunication;

namespace Panel_Gościa.StronyAnalityk
{
    /// <summary>
    /// Logika interakcji dla klasy StronaRaporty.xaml
    /// </summary>
    /// 
    public class Pac
    {
        public string imie, nazwisko;
        public int id;
        public Pac(string i, string n, int id)
        {
            this.imie = i;
            this.nazwisko = n;
            this.id = id;
        }

        public override string ToString()
        {
            return imie+" "+nazwisko;
        }
    }
    public partial class StronaRaporty : Page
    {
        List<int> idosoby = new List<int>();
        List<Pac> Pacjenci = new List<Pac>();
        List<Wizyta> wizyty = new List<Wizyta>();
        public string nazwa;
        public int idAnalityka;
       
        public StronaRaporty(int id)
        {
            idAnalityka = id;
            InitializeComponent();
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                    MySqlCommand naz = new MySqlCommand($@"SELECT idpacjenta, imie, nazwisko FROM osoba JOIN pacjenci on osoba.idosoby=pacjenci.idosoby", połączenie);
                    połączenie.Open();
                     MySqlDataReader NazReader = naz.ExecuteReader();
                    while(NazReader.Read())
                    {
                        Pac p = new Pac(Convert.ToString(NazReader.GetValue(1)), Convert.ToString(NazReader.GetValue(2)), Convert.ToInt32(NazReader.GetValue(0)));
                        Pacjenci.Add(p);
                        cbxOsoby.Items.Add(p);
                    }
                    
            }
                
        }

        private void cbxOsoby_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wizyty.Clear();
            lbxWysw.Items.Clear();
            nazwa = cbxOsoby.SelectedItem.ToString();
            string[] sub = nazwa.Split(' ');
            int idd=0;
            foreach(Pac x in Pacjenci)
            {
                if(x.nazwisko==sub[1]&& x.imie==sub[0])
                {
                    idd = x.id;
                }
            }

            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand polecenie = new MySqlCommand($@"SELECT * FROM wizyta where idpacjenta={idd}", połączenie);
                połączenie.Open();
                MySqlDataReader PolReader = polecenie.ExecuteReader();
                while (PolReader.Read())
                {
                    Wizyta w = new Wizyta(Convert.ToInt32(PolReader.GetValue(0)), Convert.ToInt32(PolReader.GetValue(1)), Convert.ToInt32(PolReader.GetValue(2)), Convert.ToDateTime(PolReader.GetValue(3)), Convert.ToInt32(PolReader.GetValue(4)), PolReader.GetDecimal(5));
                    wizyty.Add(w);
                    lbxWysw.Items.Add(w);
                }
            }

        }

        private void lbxWysw_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int i=lbxWysw.SelectedIndex;
            Wizyta w;
            w = wizyty.ElementAt(i);
            var v = new Wynik(idAnalityka, w.idBadania, w.idWizyty, w.data, 20);
            v.ShowDialog();
        }
    }
}
