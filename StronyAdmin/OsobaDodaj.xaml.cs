using DatabaseCommunication;
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
    /// Logika interakcji dla klasy OsobaDodaj.xaml
    /// </summary>
    public partial class OsobaDodaj : Page
    {
        public OsobaDodaj()
        {
            InitializeComponent();
            PrepareComponents();
        }
        List<string> list;
        public void PrepareComponents()
        {
             list= new List<string>();
             list.Add("Pacjent"); list.Add("Pielęgniarka"); list.Add("Analityk"); list.Add("Recepcja"); list.Add("Administracja");
             foreach (var item in list)
             {
                cbRole.Items.Add(item);
             }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string imie = txtImie.Text;
            string nazwisko = txtNazwisko.Text;
            string adres = txtAdres.Text;
            string pesel = txtPesel.Text;
            string telefon = txtTelefon.Text;
            string mail = txtEmail.Text;
            string hasło= txtHasło.Text;

            string error="";
            if (imie.All(char.IsLetter) && imie.Length < 15 && imie.Length > 2)
            {
                imie = txtImie.Text;
                error += "OK \n";
            }
            else error += "Błędne Imię  \n";
            if (nazwisko.All(char.IsLetter) && nazwisko.Length < 20 && nazwisko.Length > 2)
            {
                nazwisko = txtNazwisko.Text;
                error += "OK \n";
            }
            else error += "Błędne Nazwisko  \n";
            if (pesel.All(char.IsDigit) && pesel.Length ==11)
            {
                pesel = txtNazwisko.Text;
                error += "OK \n";
            }
            else error += "Błędny Pesel '\n'";
            if (IsValidEmail(mail))
            {
                mail = txtEmail.Text;
                error += "OK \n";
            }
            else error += "Błędny Email \n";
            if (telefon.All(char.IsDigit) && telefon.Length==9)
            {

                error += "OK \n";
            }
            else if(telefon.StartsWith("+") && !telefon.Any(char.IsLetter)) error += "OK \n";
            else error += "Błędny Numer Telfeonu \n";
            if (adres.Length>4 && adres.Length<25)
            {
                error += "OK \n";
            }
            else error += "Błędny Adres \n";
            if (hasło.Length > 3)
            {
                error += "OK \n";
            }
            else error += "Za krótkie hasło \n";
            MessageBox.Show(error);

            using (MySqlConnection connect = new MySqlConnection(Getters.connectionString))
            {
                connect.Open();
                if (cbRole.SelectedItem == null)
                {
                    cbRole.SelectedItem = list[0];
                }
                MySqlCommand commandAdd = new MySqlCommand($@"INSERT INTO osoba (imie, nazwisko, adres, pesel, mail, telefon, haslo, aktywne) VALUES ('{imie}','{nazwisko}','{adres}','{pesel}','{mail}','{telefon}','{hasło}',1)", connect);
                commandAdd.ExecuteScalar();
                MySqlCommand commandFindID = new MySqlCommand($@"SELECT idosoby FROM osoba WHERE imie='{imie}' AND nazwisko='{nazwisko}' AND pesel='{pesel}' AND haslo='{hasło}'", connect);
                int id = Convert.ToInt32(commandFindID.ExecuteScalar());
                switch (cbRole.SelectedItem.ToString())
                {
                    case "Pacjent":
                        MySqlCommand commandJoin = new MySqlCommand($@"INSERT INTO pacjenci (idosoby) VALUES ({id})", connect);
                        commandJoin.ExecuteScalar();
                        break;
                    case "Pielęgniarka":
                        MySqlCommand commandJoinP = new MySqlCommand($@"INSERT INTO pielegniarki (idosoby) VALUES ({id})", connect);
                        commandJoinP.ExecuteScalar();
                        break;
                    case "Analityk":
                        MySqlCommand commandJoinA = new MySqlCommand($@"INSERT INTO analityk (idosoby) VALUES ({id})", connect);
                        commandJoinA.ExecuteScalar();
                        break;
                    case "Recepcja":
                        MySqlCommand commandJoinR = new MySqlCommand($@"INSERT INTO personelrecepcji (idosoby) VALUES ({id})", connect);
                        commandJoinR.ExecuteScalar();
                        break;
                    case "Administracja":
                        MySqlCommand commandJoinADMIN = new MySqlCommand($@"INSERT INTO administracja (idosoby) VALUES ({id})", connect);
                        commandJoinADMIN.ExecuteScalar();
                        break;
                        
                }

                connect.Close();
            }
        }
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        public void cbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
