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
using MySql.Data.MySqlClient;
using DatabaseCommunication;

namespace Panel_Gościa.StronyAnalityk
{
    /// <summary>
    /// Logika interakcji dla klasy Wynik.xaml
    /// </summary>
    public partial class Wynik : Window
    {

        public int idAnalityka, idBadania, idWizyty;
        public double cena;

        public Wynik(int id, int idb, int idwiz, DateTime d, double c)
        {
            
            InitializeComponent();
            lblIdPac_Copy3.Content = "Napisz wynik badania: ";
            idAnalityka = id;
            idBadania = idb;
            idWizyty = idwiz;
            cena = c;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand polecenie = new MySqlCommand($@"INSERT INTO wykonaniabadania VALUES ({idWizyty}, {idAnalityka}, {idBadania}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{txtWynik.Text}')", połączenie);
                połączenie.Open();
                polecenie.ExecuteNonQuery();
                połączenie.Close();
            }
        }
    }
}
