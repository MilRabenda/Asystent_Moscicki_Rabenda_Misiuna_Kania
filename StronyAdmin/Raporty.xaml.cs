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

namespace Panel_Gościa.StronyAdmin
{
    /// <summary>
    /// Logika interakcji dla klasy Raporty.xaml
    /// </summary>
    /// 

    public class Badania
    {
        public int idBadania;
        public string nazwaBadania;
        public int liczbaWykon;

        public Badania(int id, int lw)
        {
            idBadania = id;
            liczbaWykon = lw;
            nazwaBadania = Getters.getNazwaBadania(idBadania);
        }

        public override string ToString()
        {
            return nazwaBadania + " | " + liczbaWykon;
        }

    }
    public partial class Raporty : Page
    {
        DateTime xtime = DateTime.Now;
        List<Wizyta> wizyty = new List<Wizyta>();
        List<Badania> bad = new List<Badania>();
        public Raporty()
        {
            
            InitializeComponent();
            List<string> typy = new List<string>() { "Wykonane badania" };
            List<string> czas = new List<string>() { "ostatni tydzień", "ostatni miesiąc", "ostatnie pół roku" };
            foreach(string x in czas)
            {
                cbxCzas.Items.Add(x);
            }
            foreach (string x in typy)
            {
                cbxTyp.Items.Add(x);
            }
        }

        private void btnGeneruj_Click(object sender, RoutedEventArgs e)
        {
          

        }

        private void cbxCzas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = cbxCzas.SelectedIndex;
            TimeSpan ts;
            switch (index)
            {
                case 1:
                    ts = new TimeSpan(7, 0, 0);
                    xtime = xtime - ts;
                    break;
                case 2:
                    ts = new TimeSpan(30, 0, 0);
                    xtime = xtime - ts;
                    break;
                case 3:
                    ts = new TimeSpan(180,0,0);
                    xtime = xtime - ts;
                    break;                    
            }
        }

        private void cbxTyp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = cbxTyp.SelectedIndex;
            wizyty.Clear();
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand polecenie;
                switch (index)
                {
                    case 1:
                        bad.Clear();
                        polecenie = new MySqlCommand($@"SELECT idbadania, count(*) as b from wizyta where datawizyty>'{xtime.ToString("yyyy-MM-dd HH:mm:ss")}' group by idbadania order by b DESC", połączenie);
                        połączenie.Open();
                        MySqlDataReader reader = polecenie.ExecuteReader();
                        if(reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                var a = reader.GetInt32(0);
                                var b = reader.GetInt32(1);
                                Badania ba = new Badania(a, b);
                                bad.Add(ba);
                            }
                        }
                        break;
                }
               

            }
        }
    }
}
