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

namespace Panel_Gościa.StronyRecepcja
{
    /// <summary>
    /// Logika interakcji dla klasy EditKontoWindow.xaml
    /// </summary>
    public partial class EditKontoWindow : Window
    {
        private Osoba osoba { get; set; }
        private int idOsoby { get; set; }
        public EditKontoWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public EditKontoWindow(Osoba os) : this()
        {
            updateDane(os);
        }
        public void updateDane(Osoba os)
        {
            this.osoba = os;
            txtNazwisko.Text = osoba.nazwisko;
            txtImie.Text = osoba.imie;
            txtAddr.Text = osoba.adres;
            txtPesel.Text = osoba.pesel;
            txtMail.Text = osoba.mail;
            txtTelefon.Text = osoba.telefon;
            if (!os.aktywne) btnDeactivate.Content = "Dezaktywuj konto";
            else btnDeactivate.Content = "Aktywuj konto";
        }

        private void btnChangeNames_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Czy na pewno chcesz zmienić imię i nazwisko?", "Zmiana", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool good = false;
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"update osoba set imie = '{txtImie.Text}', nazwisko = '{txtNazwisko.Text}' where idosoby={osoba.idOsoby}", połączenie);
                    połączenie.Open();
                    good = log.ExecuteNonQuery() == 1;

                    połączenie.Close();
                }
                if (good) MessageBox.Show("Zmiana się powiodła", "Sukces");
                else MessageBox.Show("Zmiana się nie powiodła", "Błąd");
            }
            osoba.update();
            updateDane(this.osoba);

        }

        private void btnChangeAddr_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zmienić adres?", "Zmiana", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool good = false;
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"update osoba set adres = '{txtAddr.Text}' where idosoby={osoba.idOsoby}", połączenie);
                    połączenie.Open();
                    good = log.ExecuteNonQuery() == 1;

                    połączenie.Close();
                }
                if (good) MessageBox.Show("Zmiana się powiodła", "Sukces");
                else MessageBox.Show("Zmiana się nie powiodła", "Błąd");
            }
            osoba.update();
            updateDane(this.osoba);
        }

        private void btnPesel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zmienić pesel?", "Zmiana", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool good = false;
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"update osoba set pesel = '{txtPesel.Text}' where idosoby={osoba.idOsoby}", połączenie);
                    połączenie.Open();
                    good = log.ExecuteNonQuery() == 1;

                    połączenie.Close();
                }
                if (good) MessageBox.Show("Zmiana się powiodła", "Sukces");
                else MessageBox.Show("Zmiana się nie powiodła", "Błąd");
            }
            osoba.update();
            updateDane(this.osoba);
        }

        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zmienić e-mail?", "Zmiana", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool good = false;
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"update osoba set mail = '{txtMail.Text}' where idosoby={osoba.idOsoby}", połączenie);
                    połączenie.Open();
                    good = log.ExecuteNonQuery() == 1;

                    połączenie.Close();
                }
                if (good) MessageBox.Show("Zmiana się powiodła", "Sukces");
                else MessageBox.Show("Zmiana się nie powiodła", "Błąd");
            }
            osoba.update();
            updateDane(this.osoba);
        }

        private void btnTele_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zmienić numer telefonu?", "Zmiana", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool good = false;
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"update osoba set telefon = '{txtTelefon.Text}' where idosoby={osoba.idOsoby}", połączenie);
                    połączenie.Open();
                    good = log.ExecuteNonQuery() == 1;

                    połączenie.Close();
                }
                if (good) MessageBox.Show("Zmiana się powiodła", "Sukces");
                else MessageBox.Show("Zmiana się nie powiodła", "Błąd");
            }
            osoba.update();
            updateDane(this.osoba);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        {
            var active = 0;
            if (osoba.aktywne) active = 0;
            else active = 1;
            string str = "";
            if (osoba.aktywne) str = "aktywować";
            else str = "dezaktywować";
            if (MessageBox.Show($"Czy na pewno chcesz {str} konto?", "Zmiana", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                bool good = false;
                
                using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
                {
                    MySqlCommand log = new MySqlCommand($@"update osoba set aktywne = {active} where idosoby={osoba.idOsoby}", połączenie);
                    połączenie.Open();
                    good = log.ExecuteNonQuery() == 1;

                    połączenie.Close();
                }
                if (good) MessageBox.Show("Zmiana się powiodła", "Sukces");
                else MessageBox.Show("Zmiana się nie powiodła", "Błąd");
            }
            osoba.update();
            updateDane(this.osoba);
        }

        private void btnHaslo_Click(object sender, RoutedEventArgs e)
        {
            var window = new ChangePasswordWindow(osoba.idOsoby);
            window.ShowDialog();
        }
    }
}
