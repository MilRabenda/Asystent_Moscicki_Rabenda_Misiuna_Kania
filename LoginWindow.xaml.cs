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
        private void login()
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
                                    int idaa = Getters.getIdOsoby(txtLogin.Text);
                                    var f = new PanelAnalityka(idaa);
                                    f.ShowDialog();
                                    break;
                                case "personel recepcji":
                                    this.Close();
                                    int ido = Getters.getIdOsoby(txtLogin.Text);
                                    var r = new Recepcja(ido);
                                    r.ShowDialog();
                                    break;
                                case "pielegniarka":
                                    this.Close();
                                    int id = Getters.getIdOsoby(txtLogin.Text);
                                    var g = new pielegniarka(id);
                                    g.ShowDialog();
                                    break;
                                case "admin":
                                    this.Close();
                                    int ida = Getters.getIdOsoby(txtLogin.Text);
                                    var a = new admin(ida);
                                    a.ShowDialog();
                                    break;

                            }

                        }
                        break;
                    case false:
                        this.Close();
                        int id5 = Getters.getIdOsoby(txtLogin.Text);
                        var v = new PanelPacjenta(id5);
                        v.ShowDialog();
                        //MessageBox.Show("False");
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("wtf");
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            login();
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) login();
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) login();
        }
    }
}
