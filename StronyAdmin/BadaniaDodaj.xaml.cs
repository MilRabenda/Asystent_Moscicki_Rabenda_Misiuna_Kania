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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Panel_Gościa.StronyAdmin
{
    /// <summary>
    /// Logika interakcji dla klasy BadaniaDodaj.xaml
    /// </summary>
    public partial class BadaniaDodaj : Page
    {
        public delegate void Refresh();
        public static Refresh odswiez;
        static string newSource;
        static string oldSource;
        public BadaniaDodaj()
        {
            InitializeComponent();
            PrepareComponents();
        }
        public void PrepareComponents()
        {
           // List<string> list;
           // using (
           //MySqlConnection connect = new MySqlConnection(Getters.connectionString))
           // {
           //     connect.Open();
           //     MySqlDataReader rdr;
           //     list = new List<string>();
           //     MySqlCommand names = new MySqlCommand($@"SELECT nazwabadania FROM badanie", connect);
           //     rdr = names.ExecuteReader();
           //     while (rdr.Read())
           //     {
           //         cbBadania.Items.Add(rdr.GetString(0));
           //     }
           //     connect.Close();
           // }

        }

        private void btnWgrajZdjecie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdytuj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbBadania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
