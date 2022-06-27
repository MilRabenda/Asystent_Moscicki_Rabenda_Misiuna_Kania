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
using System.IO;
namespace Panel_Gościa.StronyAdmin
{
    /// <summary>
    /// Logika interakcji dla klasy BadaniaEdycja.xaml
    /// </summary>
    public partial class BadaniaEdycja : Page
    {
        public delegate void Refresh();
        public static Refresh odswiez;
        static string oldSource;
        static string newSource = oldSource;
        static int i=0;
        public BadaniaEdycja()
        {
            InitializeComponent();
            PrepareComponents();

        }
        List<string> list;
        public void PrepareComponents()
        {

            //cbBadania.Items.Clear();
          
            using (
           MySqlConnection connect = new MySqlConnection(Getters.connectionString))
            {
                connect.Open();
                MySqlDataReader rdr;
                list = new List<string>();
                MySqlCommand names = new MySqlCommand($@"SELECT nazwabadania FROM badanie", connect);
                rdr = names.ExecuteReader();
                while (rdr.Read())
                {
                    cbBadania.Items.Add(rdr.GetString(0));
                    list.Add(rdr.GetString(0));
                }
                connect.Close();
            }
            
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

        private void cbBadania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            using (MySqlConnection connect = new MySqlConnection(Getters.connectionString))
            {
                connect.Open();
                MySqlDataReader rdr;
                if (cbBadania.SelectedItem==null)
                {
                    cbBadania.SelectedItem=list[0];
                }
                string s=cbBadania.SelectedItem.ToString();
                MySqlCommand names = new MySqlCommand($@"SELECT nazwabadania, cennik, zdjecie FROM badanie WHERE nazwabadania='{s}'", connect);
                rdr = names.ExecuteReader();
                while (rdr.Read())
                {
                    txtNazwa.Text=rdr.GetString(0);
                    txtCena.Text = rdr.GetString(1);
                    oldSource = rdr.GetString(2);
                }
                connect.Close();
            }
        }
        private void checkbox_Checked(object sender, RoutedEventArgs e)
        {
            i = 1;
        }
        private void btnEdytuj_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection connect = new MySqlConnection(Getters.connectionString))
            {
                connect.Open();
                string s = cbBadania.SelectedItem.ToString();
                string nazwa = txtNazwa.Text;
                decimal cena = Convert.ToDecimal(txtCena.Text);
                if (newSource == null) newSource = oldSource;
                MySqlCommand commnad = new MySqlCommand($@"UPDATE badanie SET nazwabadania='{nazwa}', cennik={cena}, zdjecie='{newSource}', wyróżnione={i} WHERE nazwabadania='{s}'", connect);
                commnad.ExecuteScalar();
                Image.Source = null;
                checkbox.IsChecked = false;
                oldSource = newSource;
                newSource = null;
                MySqlDataReader rdr;
                MySqlCommand names = new MySqlCommand($@"SELECT nazwabadania, cennik, zdjecie FROM badanie WHERE nazwabadania='{s}'", connect);
                rdr = names.ExecuteReader();
                while (rdr.Read())
                {
                    oldSource = rdr.GetString(2);
                }
                connect.Close();
            }
            odswiez();
        }

        private void btnUsuń_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection connect = new MySqlConnection(Getters.connectionString))
            {
                connect.Open();
                string s = cbBadania.SelectedItem.ToString();
                MySqlCommand commnad = new MySqlCommand($@"DELETE FROM badanie WHERE nazwabadania='{s}'", connect);
                commnad.ExecuteScalar();
                connect.Close();
                txtCena.Text = "";
                txtNazwa.Text = "";
                checkbox.IsChecked = false;
                Image.Source = null;
                cbBadania.Items.Remove(s);
            }
            odswiez();
        }
    }
}
