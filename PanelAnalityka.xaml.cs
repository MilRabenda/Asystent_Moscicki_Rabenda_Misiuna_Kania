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

namespace Panel_Gościa
{
    
    /// <summary>
    /// Logika interakcji dla klasy PanelAnalityka.xaml
    /// </summary>
    public partial class PanelAnalityka : Window
    {
        public int idAnalityka;
        public string imie;
        public PanelAnalityka(int id)
        {
            InitializeComponent();
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand idpac = new MySqlCommand($@"SELECT idanalityka FROM analityk where idosoby={id}", połączenie);
                połączenie.Open();
                MySqlDataReader IdReader = idpac.ExecuteReader();
                IdReader.Read();
                idAnalityka = Convert.ToInt32(IdReader.GetValue(0));
                IdReader.Close();
                MySqlCommand name = new MySqlCommand($@"SELECT imie FROM osoba where idosoby={id}", połączenie);
                MySqlDataReader ImieReader = name.ExecuteReader();
                ImieReader.Read();
                imie = Convert.ToString(ImieReader.GetValue(0));
                ImieReader.Close();

            }
            lbl_Witaj.Content = $@"Witaj {imie}";
        }

        private void btn_ZapiszWizytę_Click(object sender, RoutedEventArgs e)
        {
            anFrame.Content = new StronyAnalityk.StronaRaporty(idAnalityka);
        }
    }
}
