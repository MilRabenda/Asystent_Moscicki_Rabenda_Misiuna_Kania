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
using Panel_Gościa.StronyPielegniarka;

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy pielegniarka.xaml
    /// </summary>
    public partial class pielegniarka : Window
    {
        private int idOsoby;
        private int idPielegniarki;
        private bool ustawienia = false;
        public pielegniarka()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }
        public pielegniarka(int idOsoby) : this()
        {
            this.idOsoby = idOsoby;
            this.idPielegniarki = Getters.getIdPielegniarki(idOsoby);
            lbl_Witaj.Content = "Witaj, " + Getters.getImie(idOsoby);
        }

        private void btn_PokażWizyty_Click(object sender, RoutedEventArgs e)
        {
            ustawienia = false;
            stronaWyswietlana.Content = new StronaWizyty(idOsoby);
            //lstBox.Items.Clear();

            //var x = Getters.getWizytyPielęgniarka(idPielegniarki);
            //x.Sort();
            //foreach (var item in x)
            //{
            //    lstBox.Items.Add(item);
            //}
        }

        private void btn_DzisiejszeWizyty_Click(object sender, RoutedEventArgs e)
        {
            ustawienia = false;
            stronaWyswietlana.Content = new StronaDzisiejszeWizyty(idOsoby);

            //lstBox.Focusable = false;
            //lstBox.Items.Clear();
            //var x = Getters.getWizytyPielęgniarkaDzisiaj(idPielegniarki);
            //x.Sort();
            //foreach (var item in x)
            //{
            //    lstBox.Items.Add(item);
            //}
            //if (x.Count == 0) lstBox.Items.Add("Brak wizyt");
        }

        private void btn_Wyloguj_Click(object sender, RoutedEventArgs e)
        {
            ustawienia = false;
            var result = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Wylogowanie", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void btn_UstawieniaKonta_Click(object sender, RoutedEventArgs e)
        {
            ustawienia = true;
            var str = new StronaUstawienia(idOsoby);
            str.ClickPassword = this.zmienHaslo;
            str.DeactivateMe = this.dezaktywujKonto;            
            stronaWyswietlana.Content = str;

        }
        private void zmienHaslo()
        {
            //MessageBox.Show(Getters.getCurrentPassword(idOsoby));
            var str = new StronaZmienHaslo(idOsoby);
            str.ChangePassword = ChangePwd;
            str.CheckPassword = Getters.checkPassword;
            stronaWyswietlana.Content = str;

        }
        private void ChangePwd(string x)
        {
            Getters.ZmieńHasło(idOsoby, x);
        }
        private void dezaktywujKonto()
        {
            MessageBox.Show("Dezaktywowano","Żarcik");
        }
    }
}
