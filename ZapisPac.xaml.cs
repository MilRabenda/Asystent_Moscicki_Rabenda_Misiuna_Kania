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
using System.Globalization;

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy ZapisPac.xaml
    /// </summary>
    /// 
  
    public partial class ZapisPac : Page
    {

        public int idbadania;
        public int idpielegniarki;
        public int id;
        public string data;
        public string czas;
        public int potrzebne;
        


        List<int> lista = new List<int>();


        public ZapisPac(int a)
        {
            id = a;
            InitializeComponent();

            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand pol_badanie = new MySqlCommand($@"SELECT nazwabadania FROM badanie", połączenie);
                połączenie.Open();
                MySqlDataReader BReader = pol_badanie.ExecuteReader();

                while(BReader.Read())
                {
                    cbxBadanie.Items.Add(BReader.GetValue(0));
                }
                BReader.Close();
                MySqlCommand pol_piel = new MySqlCommand($@"SELECT idpielegniarki FROM pielegniarki", połączenie);
                MySqlDataReader PReader = pol_piel.ExecuteReader();
                
                while(PReader.Read())
                {
                    lista.Add(Convert.ToInt32(PReader.GetValue(0)));
                }
                PReader.Close();

               
                    MySqlCommand pol_piel_imie = new MySqlCommand($@"SELECT imie, nazwisko FROM osoba JOIN pielegniarki on osoba.idosoby=pielegniarki.idosoby ", połączenie);
                    MySqlDataReader PNReader = pol_piel_imie.ExecuteReader();
                    while (PNReader.Read())
                    {
                        string nazwa = Convert.ToString(PNReader.GetValue(0)) + " " + Convert.ToString(PNReader.GetValue(1));
                        cbxPielegniarka.Items.Add(nazwa);
                    }
                    PNReader.Close();

                for(int i=8; i<=20; i++)
                {
                    cbxGodzina.Items.Add($@"{i}:00");
                    cbxGodzina.Items.Add($@"{i}:30");
                }

               
                MySqlCommand idwiz = new MySqlCommand($@"SELECT COUNT(idwizyty) FROM wizyta", połączenie);
                MySqlDataReader rid = idwiz.ExecuteReader();
                while (rid.Read())
                {
                    potrzebne = Convert.ToInt32(rid.GetValue(0));
                }
                rid.Close();

            }
            
        }

        

        private void cbxBadanie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idbadania = cbxBadanie.SelectedIndex + 1;
            
        }

        private void cbxPielegniarka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            idpielegniarki = lista.ElementAt(cbxPielegniarka.SelectedIndex);
           
        }

        

        private void DataBadania_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            data = DataBadania.SelectedDate.Value.ToString("yyyy-MM-dd");
            MessageBox.Show(data + " " + czas);
          
        }

        private void cbxGodzina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            czas = cbxGodzina.SelectedItem.ToString();
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                
                string jajebe = data + " " + czas;
                DateTime ok = DateTime.Parse(jajebe);
                MySqlCommand idpac = new MySqlCommand($@"INSERT INTO wizyta VALUES({id}, {idpielegniarki},{potrzebne+1}, '{ok.ToString("yyyy-MM-dd HH:mm:ss")}', {idbadania})", połączenie);
                połączenie.Open();
                idpac.ExecuteNonQuery();
                MySqlCommand sprawdz = new MySqlCommand($@"SELECT * FROM wizyta where datawizyty='{ok.ToString("yyyy-MM-dd HH:mm:ss")}'", połączenie);
                MySqlDataReader reader = sprawdz.ExecuteReader();
                if(reader.HasRows)
                {
                    MessageBox.Show("Wizyta dodana pomyślnie");
                }


            }
            

            
        }
    }
}
