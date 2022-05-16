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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

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

            this.Close();
            if (this.txtLogin.Text != string.Empty || this.txtPassword.Password != string.Empty)
            {
                using (MySqlConnection połączenie = new MySqlConnection(@"server=localhost;user id=root; password=root;database=laboratorium"))
                {
                 
                    MySqlCommand log = new MySqlCommand($@"SELECT pesel FROM osoba where pesel='{txtLogin.Text}'", połączenie);
                    MySqlCommand has = new MySqlCommand($@"SELECT haslo FROM osoba where haslo ='{ txtPassword.Password }'", połączenie);
                    połączenie.Open();
                    MySqlDataReader poprawne_log = log.ExecuteReader();
                    bool ok1;
                    bool ok2;
                    if (poprawne_log.HasRows==true)
                    {
                        ok1 = true;
                        
                    }
                    else
                    {
                        ok1 = false;
                    }

                    poprawne_log.Close();
                    MySqlDataReader poprawne_has = has.ExecuteReader();

                    if (poprawne_has.HasRows == true)
                    {
                        ok2 = true;

                    }
                    else
                    {
                        ok2 = false;
                    }

                    poprawne_has.Close();
                    if(ok1 && ok2==true)
                    {
                        var window = new PanelPacjenta();
                        window.ShowDialog();
                    }

                    połączenie.Close();


                    //połączenie.Open();
                    //MySqlDataReader czytnik = polecenie.ExecuteReader();
                    //czytnik.Close();
                    //połączenie.Close();
                }


            }
            //sprawdź z bazą danych czy login i hasło się zgadzają
            //jeśli tak to 
            //    if(this.txtLogin.Text == DobryLogin && this.txtPassword.Password == DobreHasło)
            //    {
            //        setUser(this.txtLogin.Text, this.txtPassword.Password);

            //        this.Close();

            //    }
            //    else MessageBox.Show("Błędny login lub hasło - spróbuj ponownie", "Błąd");
            //}
            //else
            //{
            //    MessageBox.Show("Błąd");
            //}


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

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtLogin.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("images/login.jpg", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                txtLogin.Background = textImageBrush;
            }
            else
            {

                txtLogin.Background = null;
            }
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("images/haslo.jpg", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                txtPassword.Background = textImageBrush;
            }
            else
            {

                txtPassword.Background = null;
            }
        }
    }
}
