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

namespace Panel_Gościa.StronyRecepcja
{
    /// <summary>
    /// Logika interakcji dla klasy StronaEditWizyty.xaml
    /// </summary>
    public partial class StronaEditWizyty : Page
    {
        public delegate void lbxDoubleClick(int ix);
        public lbxDoubleClick DoubleClick;
        public StronaEditWizyty()
        {
            InitializeComponent();
            updateWizyty();
        }
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
            lstBox.Items.Clear();
            foreach(var w in wizyty)
            {
                lstBox.Items.Add(w);
            }

        }
        public static List<Wizyta> wizyty;
        public class Wizyta
        {
            public int idPacjenta { get; set; }
            public int idPielegniarki { get; set; }
            public int idWizyty { get; set; }
            public DateTime data { get; set; }

            public int idBadania { get; set; }
            public Wizyta(int iPa,int iPi,int idW, DateTime time, int idB)
            {
                idPacjenta = iPa;
                idPielegniarki = iPi;
                idWizyty = idW;
                data = time;
                idBadania = idB;
            }
            public override string ToString()
            {
                return $"{Getters.getNazwaBadania(idBadania)}, {data}";
            }


        }

        private void lstBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DoubleClick(lstBox.SelectedIndex);
        }
    }
}
