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

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string Loginstr { get; set; }
        public string Hasłostr { get; set; }
        public string DobreHasło = "admin";
        public string DobryLogin = "admin";
        public bool Git { get; set; } = false;
        public Login()
        {
            InitializeComponent();
        }
        void setUser(string l, string h)
        {
            Loginstr = l;
            Hasłostr = h;
            Git = true;
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(this.txtLogin.Text != string.Empty || this.txtPassword.Password != string.Empty)
            {
                //sprawdź z bazą danych czy login i hasło się zgadzają
                //jeśli tak to 
                if(this.txtLogin.Text == DobryLogin && this.txtPassword.Password == DobreHasło)
                {
                    setUser(this.txtLogin.Text, this.txtPassword.Password);

                    this.Close();

                }
                else MessageBox.Show("Błędny login lub hasło - spróbuj ponownie", "Błąd");
            }
            else
            {
                MessageBox.Show("Błąd");
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
