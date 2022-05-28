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
    /// Logika interakcji dla klasy pielegniarka.xaml
    /// </summary>
    public partial class pielegniarka : Window
    {
        public pielegniarka()
        {
            InitializeComponent();
        }

        private void btn_PokażWizyty_Click(object sender, RoutedEventArgs e)
        {
            lstBox.Items.Clear();

            var x = Getters.getWizytyPielęgniarka(1);
            x.Sort();
            foreach (var item in x)
            {
                lstBox.Items.Add(item);
            }
        }

        private void btn_DzisiejszeWizyty_Click(object sender, RoutedEventArgs e)
        {
            lstBox.Items.Clear();
            var x = Getters.getWizytyPielęgniarkaDzisiaj(1);
            x.Sort();
            foreach (var item in x)
            {
                lstBox.Items.Add(item);
            }
        }

        private void btn_Wyloguj_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Wylogowanie", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }
    }
}
