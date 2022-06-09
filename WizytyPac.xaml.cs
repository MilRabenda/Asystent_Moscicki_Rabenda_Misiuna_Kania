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

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy WizytyPac.xaml
    /// </summary>
    /// 
    //public class Wizyta
    //{
    //    public DateTime data;
    //    public int idpielęgniarki;
    //    public int idbadania;

    //    public DateTime Data
    //    {
    //        set { this.data = value; }
    //        get { return data; }
    //    }

    //    public int IdPielęgniarki
    //    {
    //        set { this.idpielęgniarki = value; }
    //        get { return idpielęgniarki; }
    //    }

    //    public int IdBadania
    //    {
    //        set { this.idbadania = value; }
    //        get { return idbadania; }
    //    }

    //    public override string ToString()
    //    {
    //        using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
    //        {
    //            MySqlCommand polecenie1  = new MySqlCommand($@"SELECT idosoby FROM pielegniarki where idpielegniarki={IdPielęgniarki}", połączenie);
    //            połączenie.Open();
    //            MySqlDataReader Czytaj = polecenie1.ExecuteReader();
    //            Czytaj.Read();
    //            int idp = Convert.ToInt32(Czytaj.GetValue(0));
    //            Czytaj.Close();
    //            MySqlCommand polecenie2 = new MySqlCommand($@"SELECT imie, nazwisko FROM osoba where idosoby={idp};", połączenie);
    //            MySqlDataReader Czytaj2 = polecenie2.ExecuteReader();
    //            Czytaj2.Read();
    //            string imiepielegniarki=Convert.ToString(Czytaj2.GetValue(0)) + " " + Convert.ToString(Czytaj2.GetValue(1));
    //            Czytaj2.Close();
    //            MySqlCommand polecenie3 = new MySqlCommand($@"SELECT nazwabadania FROM badanie where idbadania={IdBadania};", połączenie);
    //            MySqlDataReader Czytaj3 = polecenie3.ExecuteReader();
    //            Czytaj3.Read();
    //            string nazwabadania = Convert.ToString(Czytaj3.GetValue(0));
    //            Czytaj3.Close();
    //            return $@"{nazwabadania} | {Data} | {imiepielegniarki}";
    //        }
    //    }
    //}
    public partial class WizytyPac : Page
    {
        public int id;
        public int ID
        {
            set { this.id = value; }
            get { return id; }
        }
        List<Wizyta> listawizyt = new List<Wizyta>();
        public WizytyPac(int idpac)
        {
            ID = idpac;
            InitializeComponent();
            WysWizyty();
            
        }

        public void WysWizyty()
        {
            
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"select * from wizyta where idpacjenta={ID}", połączenie);
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
                        lbxWizyty.Items.Add(wiz);
                    }
                }
                listawizyt = lista;
                reader.Close();
                połączenie.Close();
            }
        }
    }
}
