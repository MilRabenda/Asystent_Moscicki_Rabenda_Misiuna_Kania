using DatabaseCommunication;
using Microsoft.Win32;
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
    /// Logika interakcji dla klasy BadaniaDodaj.xaml
    /// </summary>
    public partial class BadaniaDodaj : Page
    {
        static int i = 0;
        public delegate void Refresh();
        public static Refresh odswiez;
        static string newSource;
        static string oldSource;
        public BadaniaDodaj()
        {
            InitializeComponent();
        }


        private void btnWgrajZdjecie_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Wybierz zdjęcie";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                newSource = System.IO.Path.GetFileName(op.FileName);
                Image.Source = new BitmapImage(new Uri(op.FileName));
            }
            else newSource = oldSource;
        }

        private void btnWstaw_Click(object sender, RoutedEventArgs e)
        {
        using (MySqlConnection connect = new MySqlConnection(Getters.connectionString))
        {
            connect.Open();
  
            string nazwa = txtNazwa.Text;
            decimal cena = Convert.ToDecimal(txtCena.Text);
            MySqlCommand commnad = new MySqlCommand($@"INSERT INTO badanie (nazwabadania, cennik, zdjecie, wyróżnione) VALUES ('{nazwa}', {cena}, '{newSource}', {i}) ", connect);
            commnad.ExecuteScalar();
            connect.Close();
        }
    }

        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            i = 1;
        }
    }


    
}
