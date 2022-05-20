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
using System.Drawing;
using MySql.Data.MySqlClient;

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy Guest1.xaml
    /// </summary>
    public partial class Guest1 : Page
    {
        public static int i = 0;

        //BitmapImage list
        
        //Tab string
        string[] baners= {"xBadanie na Anemię 30zł","xBadanie serca 55zł","xBadanie ogólne 40zł"};
        List<string> sourceList;
        public Guest1()
        {
            sourceList = new List<string>();
            InitializeComponent();
            btn_test.Visibility = Visibility.Visible;

            //MySqlCommand ZdjAutka = new MySqlCommand($"SELECT zdjecie from pojazdy WHERE IdPojazdy = {i};", con);
            //String zdj = Convert.ToString(ZdjAutka.ExecuteScalar());
            //myImage.Source = new BitmapImage(new Uri(zdj, UriKind.Relative));

            using (
                MySqlConnection połączenie = new MySqlConnection(@"server=localhost;user id=root; password=root;database=laboratorium")) {
                MySqlCommand command = new MySqlCommand($@"SELECT count(zdjecie) FROM badanie", połączenie);
                połączenie.Open();
                int size = Convert.ToInt32(command.ExecuteScalar());
                for (i = 1; i <= size; i++)
                {
                    MySqlCommand source = new MySqlCommand($@"SELECT zdjecie FROM badanie WHERE idbadania={i}", połączenie);
                    string imageSource = "/images/content/" + Convert.ToString(source.ExecuteScalar());
                    sourceList.Add(imageSource);
                }
                połączenie.Close(); 
                ImageFrame.Source = new BitmapImage(new Uri(sourceList[0], UriKind.Relative));
            }
        }
        private void btn_test_Click(object sender, RoutedEventArgs e)
        {
            var window = new PanelPacjenta();
            window.ShowDialog();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            i--;
            if (i < 0) i = 2;
            ImageFrame.Source = new BitmapImage(new Uri(sourceList[i], UriKind.Relative));
            lblBaner.Content=baners[i];
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i > 2) { i = 0; }
            ImageFrame.Source = new BitmapImage(new Uri(sourceList[i], UriKind.Relative));
            lblBaner.Content = baners[i];
        }
        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            admin a = new admin();
            a.Show();
        }

        private void btnPielegniarka_Click(object sender, RoutedEventArgs e)
        {
            pielegniarka p = new pielegniarka();
            p.Show();
        }



    }

}
