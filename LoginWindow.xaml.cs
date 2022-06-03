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
using DatabaseCommunication;

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
            try
            {
                InitializeComponent();
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }
        void setUser(string l, string h)
        {
            Loginstr = l;
            Hasłostr = h;
            Git = true;
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var x = Getters.tryToLogIn(txtLogin.Text, txtPassword.Password);
                switch (x)
                {
                    case null:
                        MessageBox.Show("Logowanie nieudane");
                        break;
                    case true:
                        {
                            string type = Methods.getUserType(Getters.getIdOsoby(txtLogin.Text));
                            switch (type)
                            {
                                case "analityk":
                                    this.Close();
                                    var f = new admin();
                                    f.ShowDialog();
                                    break;
                                case "personel recepcji":
                                    MessageBox.Show("Recepcja TBD");
                                    break;
                                case "pielegniarka":
                                    this.Close();
                                    int id = Getters.getIdOsoby(txtLogin.Text);
                                    var g = new pielegniarka(id);
                                    g.ShowDialog();
                                    break;
                            }

                        }
                        break;
                    case false:
                        this.Close();
                        var v = new PanelPacjenta();
                        v.ShowDialog();
                        //MessageBox.Show("False");
                        break;

                }
            } catch (Exception ex)
            {
                MessageBox.Show("wtf");
            }
            //this.Close();
            //bool ok = false;
            //do
            //{
            //    if (this.txtLogin.Text != string.Empty || this.txtPassword.Password != string.Empty)
            //    {
            //        using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            //        {


            //            MySqlCommand log = new MySqlCommand($@"SELECT pesel FROM osoba where pesel='{txtLogin.Text}'", połączenie);
            //            MySqlCommand has = new MySqlCommand($@"SELECT haslo FROM osoba where pesel='{txtLogin.Text}'", połączenie);
            //            połączenie.Open();
            //            MySqlDataReader poprawne_log = log.ExecuteReader();
            //            bool ok1;
            //            bool ok2;
            //            ok1 = poprawne_log.HasRows;
            //            poprawne_log.Close();
            //            MySqlDataReader poprawne_has = has.ExecuteReader();
            //            ok2 = poprawne_has.HasRows;
            //            poprawne_has.Close();
            //            if (ok1 && ok2)
            //            {
            //                var window = new PanelPacjenta();
            //                MySqlCommand idos = new MySqlCommand($@"SELECT idosoby FROM osoba where pesel='{txtLogin.Text}'", połączenie);
            //                MySqlDataReader IdReader = idos.ExecuteReader();
            //                IdReader.Read();
            //                window.setter(Convert.ToInt32(IdReader.GetValue(0)));
            //                IdReader.Close();
            //                ok = true;
            //                window.ShowDialog();

            //            }
            //            else
            //            {
            //                MessageBox.Show("błędny login lub hasło");
            //            }

            //            połączenie.Close();

            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Wpisz login i hasło!");
            //    }
            //} while (ok == false);
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
           /* if (txtLogin.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("../images/login.jpg", UriKind.Relative)
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
           */
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
           /* if (txtPassword.Password == "")
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
           */
        }
           
           
    }
}
