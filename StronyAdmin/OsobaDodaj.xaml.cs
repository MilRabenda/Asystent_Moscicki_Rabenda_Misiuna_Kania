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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string imie = txtImie.Text;
            string nazwisko = txtNazwisko.Text;
            string adres = txtAdres.Text;
            string pesel = txtPesel.Text;
            string telefon = txtTelefon.Text;
            string mail = txtEmail.Text;

            string error;
            if (imie.All(char.IsLetter) && imie.Length<15)
            { imie = txtImie.Text;
                MessageBox.Show("OK");
            }
            else imie = "";

            if (nazwisko.All(char.IsLetter) && nazwisko.Length < 20)
            {
                nazwisko = txtNazwisko.Text;
                MessageBox.Show("OK");
            }
            else nazwisko = "";

            if (pesel.All(char.IsDigit) && pesel.Length ==11)
            {
                pesel = txtNazwisko.Text;
                MessageBox.Show("OK");
            }
            else pesel = "";
            if (mail.Contains("@") && mail.Contains(".") )
            {
                mail = txtNazwisko.Text;
                MessageBox.Show("OK");
            }
            else mail = "";

        }
    }
}
