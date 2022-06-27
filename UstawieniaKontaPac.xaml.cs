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
    /// Logika interakcji dla klasy UstawieniaKontaPac.xaml
    /// </summary>
    public partial class UstawieniaKontaPac : Page
    {
        public int idOsoby;
        public UstawieniaKontaPac(int id)
        {
            idOsoby = id;
            InitializeComponent();
        }

        private void btnZmien_Click(object sender, RoutedEventArgs e)
        {

            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"UPDATE osoba SET haslo='{txthaslo.Text}' WHERE idosoby={idOsoby}", połączenie);
                połączenie.Open();
                log.ExecuteNonQuery();

                połączenie.Close();

            }
        }

        private void btnDez_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz dezaktywować konto?", "Dezaktywacja", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"UPDATE osoba SET aktywne=1 WHERE idosoby={idOsoby}", połączenie);
                    połączenie.Open();
                    log.ExecuteNonQuery();

                    połączenie.Close();

                }
            }

           
        }
    }
}
