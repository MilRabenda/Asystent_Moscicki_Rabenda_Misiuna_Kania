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
    public partial class Raporty : Page
    {
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
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                //MySqlCommand polecenie1 = new MySqlCommand($@"SELECT  FROM pielegniarki where idpielegniarki={idPielegniarki}", połączenie);
                //połączenie.Open();
                //switch (cbxTyp)
                //{
                //    case 0:
                //        {
                //            switch (cbxCzas)
                //            {
                //                case 0:

                //            }
                //            break;
                //        }
                //}
            }
        }
    }
}
