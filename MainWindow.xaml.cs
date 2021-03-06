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

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static public bool clicked = false;
        public MainWindow()
        {
            InitializeComponent();
            Guest.Content=new Guest1();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnMinimalize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           

            var window = new Login();
            this.Hide();
            window.ShowDialog();
            this.Show();

            //if (window.Git)
            //{
            //    MessageBox.Show("Logowanie udane!");

            //} else 
            //{
            //    MessageBox.Show("Logowanie nieudane");
            //}
            //if (isPesel(window.txtLogin.Text)) MessageBox.Show("JEST PESEL", window.txtLogin.Text);
            //else MessageBox.Show("NIE JEST PESEL", window.txtLogin.Text);


            //jeśli window

            //zaloguj(window.Loginstr, window.Hasłostr);

            if (window.txtLogin.Text != string.Empty || window.txtPassword.Password != string.Empty)
            {
                //przeszukaj baze danych - czy jest taki użytkownik i czy dobre hasło
                //jeśli user i hasło git to idz do panelu {użytkownika}
                //jeśli user git hasło nie to powiedz że złe hasło
                //jeśli user źle to powiedz że user zły :D

            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var window = new RegisterWindow();
            window.ShowDialog();
            
            //test
        }


        private void btnWiecej_Click(object sender, RoutedEventArgs e)
        {
            
            clicked = !clicked;
            if (clicked)
            {
                Guest.Content = new Guest2(); btnWiecej.Content = "Mniej badań";
            }
            else
            {
                Guest.Content = new Guest1(); btnWiecej.Content = "Więcej badań";
            }
        }


    }
}
