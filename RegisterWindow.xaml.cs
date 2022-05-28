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


namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            lblZar.Content = "Załóż konto M-Pacjenta";
            
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

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* if (txtName.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri(".../images/imie.jpg", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                txtName.Background = textImageBrush;
            }
            else
            {

                txtName.Background = null;
            }
           */
        }

        private void txtSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* if (txtSurname.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("images/nazwisko.jpg", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                txtSurname.Background = textImageBrush;
            }
            else
            {

                txtSurname.Background = null;
            }
           */
        }

        private void txtAdres_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* if (txtAdres.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("images/adres.jpg", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                txtAdres.Background = textImageBrush;
            }
            else
            {

                txtAdres.Background = null;
            }
           */

        }

        private void txtPesel_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*if (txtPesel.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("images/pesel.jpg", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                txtPesel.Background = textImageBrush;
            }
            else
            {

                txtPesel.Background = null;
            }
            */

        }

        private void txtMail_TextChanged(object sender, TextChangedEventArgs e)
        {
           /* if (txtMail.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("images/mail.jpg", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                txtMail.Background = textImageBrush;
            }
            else
            {

                txtMail.Background = null;
            }
           */

        }

        private void txtTelefon_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*if (txtTelefon.Text == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("images/telefon.jpg", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                txtTelefon.Background = textImageBrush;
            }
            else
            {

                txtTelefon.Background = null;
            }
            */
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            /*
            if (PasswordBox.Password == "")
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
                PasswordBox.Background = textImageBrush;
            }
            else
            {

                PasswordBox.Background = null;
            }
            */

        }

        private void PasswordCopyBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            /*
            if (PasswordCopyBox.Password == "")
            {
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri("images/powtorzhaslo.jpg", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                PasswordCopyBox.Background = textImageBrush;
            }
            else
            {

                PasswordCopyBox.Background = null;
            }
            */

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string imie = txtName.Text;
            string nazwisko = txtSurname.Text;
            string adres = txtAdres.Text;
            string pesel = txtPesel.Text;
            string mail = txtMail.Text;
            string telefon = txtTelefon.Text;
            string haslo1 = pbxHaslo1.Password;
            string haslo2 = pbxHaslo2.Password;
            if(imie == string.Empty)
            {
                MessageBox.Show("Podaj imię", "Błąd");
                return;
            }
            if (nazwisko == string.Empty)
            {
                MessageBox.Show("Podaj nazwisko", "Błąd");
                return;
            }
            if (adres == string.Empty)
            {
                MessageBox.Show("Podaj adres", "Błąd");
                return;
            }
            if (pesel == string.Empty)
            {
                MessageBox.Show("Podaj pesel", "Błąd");
                return;
            }
            else
            {
                if(!Methods.isPesel(pesel))
                {
                    MessageBox.Show("Niepoprawny pesel!", "Błąd");
                    return;
                }
            }
            if (mail == string.Empty)
            {
                MessageBox.Show("Podaj e-mail", "Błąd");
                return;
            }
            else
            {
                if (!Methods.isEmail(mail))
                {
                    MessageBox.Show("Niepoprawny e-mail!", "Błąd");
                    return;
                }
            }
            if (telefon == string.Empty)
            {
                MessageBox.Show("Podaj telefon", "Błąd");
                return;
            }
            if (haslo1 == string.Empty)
            {
                MessageBox.Show("Podaj hasło", "Błąd");
                return;
            }
            if (haslo2 == string.Empty)
            {
                MessageBox.Show("Powtórz hasło", "Błąd");
                return;
            }
            if(haslo1 != haslo2)
            {
                MessageBox.Show("Hasła się nie zgadzają");
            }

            MessageBox.Show("Utworzono nowe konto, teraz możesz się zalogować", "Żarcik");
            //TO BE DONE
            this.Close();

        }
    }

}

