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
using System.IO;

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
        int index_listy = 0;
        public Raporty()
        {
            
            InitializeComponent();
            List<string> typy = new List<string>() { "Najpopularniejsze badania", "Wizyty" };
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


            FileStream fs = new FileStream("plik.txt", FileMode.Create, FileAccess.ReadWrite);
           StreamWriter sw = new StreamWriter(fs);
            switch (index_listy)
            {
                case 0:
                    foreach (Badania b in bad)
                    {
                        sw.WriteLine(b.ToString());
                       
                    }

                    sw.Close();
                    break;
                case 1:
                    foreach (Wizyta w in wizyty)
                    {
                        sw.WriteLine(w.ToString());
                    }
                    sw.Close();
                    break;
            }
          

        }

        private void cbxCzas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = cbxCzas.SelectedIndex;
            TimeSpan ts;
            switch (index)
            {
                case 0:
                    ts = new TimeSpan(7,0, 0, 0);
                    xtime = DateTime.Now;
                    xtime = xtime - ts;
                    MessageBox.Show(xtime.ToString());
                    break;
                case 1:
                    ts = new TimeSpan(30,0, 0, 0);
                    xtime = DateTime.Now;
                    xtime = xtime - ts;
                    MessageBox.Show(xtime.ToString());
                    break;
                case 2:
                    ts = new TimeSpan(180,0,0,0);
                    xtime = DateTime.Now;
                    xtime = xtime - ts;
                    MessageBox.Show(xtime.ToString());
                    break;                    
            }
        }

        private void cbxTyp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index_listy = cbxTyp.SelectedIndex;
            
            
                
                switch (index_listy)
                {
                    case 0:
                    
                    using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                    {
                        MySqlCommand polecenie = new MySqlCommand($@"SELECT idbadania, count(*) as b from wizyta where datawizyty>'{xtime.ToString("yyyy-MM-dd HH:mm:ss")}' group by idbadania order by b DESC", połączenie);
                        połączenie.Open();
                        MySqlDataReader reader = polecenie.ExecuteReader();
                        if (reader.HasRows)
                        {
                            bad.Clear();
                            while (reader.Read())
                            {
                                var a = reader.GetInt32(0);
                                var b = reader.GetInt32(1);
                                Badania ba = new Badania(a, b);
                                bad.Add(ba);
                            }
                        }
                        reader.Close();
                    }
                        break;
                    case 1:
                    
                    using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                    {
                        MySqlCommand polecenie1 = new MySqlCommand($@"SELECT * FROM wizyta where datawizyty> '{xtime.ToString("yyyy-MM-dd HH:mm:ss")}'", połączenie);
                        połączenie.Open();
                        MySqlDataReader reader2 = polecenie1.ExecuteReader();
                        if (reader2.HasRows)
                        {
                            wizyty.Clear();
                            while (reader2.Read())
                            {
                                var f = reader2.GetInt32(0);
                                var g = reader2.GetInt32(1);
                                var h = reader2.GetInt32(2);
                                var i = reader2.GetDateTime(3);
                                var j = reader2.GetInt32(4);
                                var k = reader2.GetDecimal(5);

                                Wizyta wiz = new Wizyta(f, g, h, i, j);
                                wizyty.Add(wiz);

                            }
                        }

                        reader2.Close();
                    }
                        break;
                }
               

            }
        }
    }

