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

            this.Close();
            //if(this.txtLogin.Text != string.Empty || this.txtPassword.Password != string.Empty)
            //{
            //    //sprawdź z bazą danych czy login i hasło się zgadzają
            //    //jeśli tak to 
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
                        new Uri(@"C:\Users\milen\Documents\GitHub\5555\Asystent_Moscicki_Rabenda_Misiuna_Kania\images\login.jpg", UriKind.Relative)
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
                        new Uri(@"C:\Users\milen\Documents\GitHub\5555\Asystent_Moscicki_Rabenda_Misiuna_Kania\images\haslo.jpg", UriKind.Relative)
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
