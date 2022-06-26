﻿using DatabaseCommunication;
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
    /// Logika interakcji dla klasy BadaniaEdycja.xaml
    /// </summary>
    public partial class BadaniaEdycja : Page
    {
        public BadaniaEdycja()
        {
            InitializeComponent();
            PrepareComponents();
        }
        
        public void PrepareComponents()
        {
            List<string> list;
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
                }
                connect.Close();
            }
            
        }
        private void btnWgrajZdjecie_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Image.Source = new BitmapImage(new Uri(op.FileName));
                using (MySqlConnection connect = new MySqlConnection(Getters.connectionString))
                {
                    connect.Open();
                    MySqlDataReader rdr;
                    string s = cbBadania.SelectedItem.ToString();
                    MySqlCommand names = new MySqlCommand($@"SELECT zdjecie FROM badanie WHERE nazwabadania='{s}'", connect);
                    rdr = names.ExecuteReader();
                    while (rdr.Read())
                    {
                        txtNazwa.Text = rdr.GetString(0);
                    }
                    connect.Close();
                }
            }
        }

        private void cbBadania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            using (MySqlConnection connect = new MySqlConnection(Getters.connectionString))
            {
                connect.Open();
                MySqlDataReader rdr;
                string s=cbBadania.SelectedItem.ToString();
                MySqlCommand names = new MySqlCommand($@"SELECT nazwabadania, cennik, zdjecie FROM badanie WHERE nazwabadania='{s}'", connect);
                rdr = names.ExecuteReader();
                while (rdr.Read())
                {
                    txtNazwa.Text=rdr.GetString(0);
                    txtCena.Text = rdr.GetString(1);
                }
                connect.Close();
            }
        }

        private void btnEdytuj_Click(object sender, RoutedEventArgs e)
        {
            using (MySqlConnection connect = new MySqlConnection(Getters.connectionString))
            {
                connect.Open();
                string s = cbBadania.SelectedItem.ToString();
                string nazwa = txtNazwa.Text;
                decimal cena = Convert.ToDecimal(txtCena.Text);
                //string zdjecie = txtNazwa.Text;
                MySqlCommand commnad = new MySqlCommand($@"UPDATE badanie SET nazwabadania='{nazwa}', cennik={cena} WHERE nazwabadania='{s}'", connect);
                commnad.ExecuteScalar();
                connect.Close();
            }

            PrepareComponents();
        }
    }
}
