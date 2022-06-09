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
using DatabaseCommunication;
using MySql.Data.MySqlClient;

namespace Panel_Gościa.StronyRecepcja
{
    /// <summary>
    /// Logika interakcji dla klasy EditWizytaWindow.xaml
    /// </summary>
    public partial class EditWizytaWindow : Window
    {
        private Wizyta wizyta { get; set; }
        public EditWizytaWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public EditWizytaWindow(Wizyta wizyta) : this()
        {
            this.wizyta = wizyta;
            updateDane();
        }
        public void updateDane()
        {
            txtIdPacjenta.Text = wizyta.idPacjenta.ToString();
            txtIdPielegniarki.Text = wizyta.idPielegniarki.ToString();
            txtIdBadania.Text = wizyta.idBadania.ToString();
            txtDataWizyty.Text = wizyta.data.ToString();
        }

        private void btnZmienIdPacjenta_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zmienić id pacjenta?", "Zmiana", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool good = false;
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"update wizyta set idpacjenta = '{txtIdPacjenta.Text}' where idwizyty={this.wizyta.idWizyty}", połączenie);
                    połączenie.Open();
                    good = log.ExecuteNonQuery() == 1;

                    połączenie.Close();
                }
                if (good) MessageBox.Show("Zmiana się powiodła", "Sukces");
                else MessageBox.Show("Zmiana się nie powiodła", "Błąd");
            }
            wizyta.update();
            updateDane();
        }

        private void btnZmienIdPielegniarki_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zmienić id pielegniarki?", "Zmiana", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool good = false;
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"update wizyta set idpielegniarki = '{txtIdPielegniarki.Text}' where idwizyty={this.wizyta.idWizyty}", połączenie);
                    połączenie.Open();
                    good = log.ExecuteNonQuery() == 1;

                    połączenie.Close();
                }
                if (good) MessageBox.Show("Zmiana się powiodła", "Sukces");
                else MessageBox.Show("Zmiana się nie powiodła", "Błąd");
            }
            wizyta.update();
            updateDane();
        }

        private void btnZmienDateWizyty_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zmienić datę wizyty?", "Zmiana", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool good = false;
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"update wizyta set datawizyty = '{txtDataWizyty.Text}' where idwizyty={this.wizyta.idWizyty}", połączenie);
                    połączenie.Open();
                    good = log.ExecuteNonQuery() == 1;

                    połączenie.Close();
                }
                if (good) MessageBox.Show("Zmiana się powiodła", "Sukces");
                else MessageBox.Show("Zmiana się nie powiodła", "Błąd");
            }
            wizyta.update();
            updateDane();
        }

        private void btnZmienIdBadania_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zmienić id badania?", "Zmiana", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool good = false;
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"update wizyta set idbadania = '{txtIdBadania.Text}' where idwizyty={this.wizyta.idWizyty}", połączenie);
                    połączenie.Open();
                    good = log.ExecuteNonQuery() == 1;

                    połączenie.Close();
                }
                if (good) MessageBox.Show("Zmiana się powiodła", "Sukces");
                else MessageBox.Show("Zmiana się nie powiodła", "Błąd");
            }
            wizyta.update();
            updateDane();
        }

        private void btnUsunWizyte_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NOT AVAILABLE YET");
        }

        private void btnKoniec_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}
