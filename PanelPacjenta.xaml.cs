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
    /// Logika interakcji dla klasy PanelPacjenta.xaml
    /// </summary>
    public partial class PanelPacjenta : Window

    {
        public int idosoby;
        public int idpacjenta;
        public string imie;

        public int IdOsoby
        {
            get { return idosoby; }
            set { this.idosoby = value; }
        }

        public int IdPacjenta
        {
            get { return idpacjenta; }
            set { this.idpacjenta = value; }
        }

        public string Imie
        {
            get { return imie; }
            set { this.imie = value;}
        }

        public PanelPacjenta(int id)
        { 
            InitializeComponent();
            IdOsoby = id;
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand idpac = new MySqlCommand($@"SELECT idpacjenta FROM pacjenci where idosoby={IdOsoby}", połączenie);
                połączenie.Open();
                MySqlDataReader IdReader = idpac.ExecuteReader();
                IdReader.Read();
                IdPacjenta = Convert.ToInt32(IdReader.GetValue(0));
                IdReader.Close();
                MySqlCommand name = new MySqlCommand($@"SELECT imie FROM osoba where idosoby={IdOsoby}", połączenie);
                MySqlDataReader ImieReader = name.ExecuteReader();
                ImieReader.Read();
                Imie = Convert.ToString(ImieReader.GetValue(0));
                ImieReader.Close();

            }
            lbl_Witaj.Content = $@"Witaj {Imie}";

        }

        private void btn_idk_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Wylogowanie", MessageBoxButton.OKCancel);
            if(result== MessageBoxResult.OK)
            {
                this.Close();
            }
          
        }

        private void btn_Wizyty_Click(object sender, RoutedEventArgs e)
        {

            wizFrame.Content = new WizytyPac(IdPacjenta);
        }

        private void btn_ZapiszWizytę_Click(object sender, RoutedEventArgs e)
        {

            wizFrame.Content = new ZapisPac(IdPacjenta);
        }

        private void btn_Konto_Click(object sender, RoutedEventArgs e)
        {
            wizFrame.Content = new StronyPielegniarka.StronaUstawienia(IdOsoby);

        }
        private void btn_UstawieniaKonta_Click(object sender, RoutedEventArgs e)
        {
            wizFrame.Content = new UstawieniaKontaPac(IdOsoby);

        }
       

    }
}
