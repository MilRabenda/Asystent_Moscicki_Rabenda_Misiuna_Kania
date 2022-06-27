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
using System.Windows.Threading;
using DatabaseCommunication;

namespace Panel_Gościa
{



    /// <summary>
    /// Logika interakcji dla klasy Guest1.xaml
    /// </summary>
    public partial class Guest1 : Page
    {
        public static int i=0;
        public static int size;
        List<string> namesList;
        List<string> prizeList;
        List<string> sourceList;

        DispatcherTimer dispatcherTimer = new DispatcherTimer(); //next image per 3s
        public void WypProjekcje()
        {

            using (MySqlConnection connect = new MySqlConnection(Getters.connectionString)) {
                connect.Open();
                MySqlDataReader rdr;
                MySqlCommand sizecommand = new MySqlCommand($@"SELECT count(*) FROM badanie WHERE wyróżnione = 1", connect);
                size = Convert.ToInt32(sizecommand.ExecuteScalar());
                    sourceList = new List<string>();
                    namesList = new List<string>();//names
                    prizeList = new List<string>();//prizes
                MySqlCommand source = new MySqlCommand($@"SELECT nazwabadania, cennik, zdjecie FROM badanie WHERE wyróżnione = 1", connect);
                rdr = source.ExecuteReader();
                while (rdr.Read())
                {
                    namesList.Add(rdr.GetString(0));
                    prizeList.Add(rdr.GetString(1) + " zł");
                    sourceList.Add("/images/content/"+rdr.GetString(2));
                }

                for (int j = 0; j < size; j++)
                {                 
                    lblName.Content = namesList[j];
                    lblPrize.Content = prizeList[j];
                    ImageFrame.Source = new BitmapImage(new Uri(sourceList[j], UriKind.Relative));
                }
                connect.Close();
                dispatcherTimer.Tick += dispatcherTimer_Tick;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
                dispatcherTimer.Start();

            }
        }

        public Guest1()
        {
            InitializeComponent();
            WypProjekcje();
            StronyAdmin.Projekcja.odswiez = WypProjekcje;
            StronyAdmin.BadaniaEdycja.odswiez = WypProjekcje;
        }


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           i++; if (i > size - 1) i = 0;
           lblName.Content = namesList[i];
           lblPrize.Content = prizeList[i];
           ImageFrame.Source = new BitmapImage(new Uri(sourceList[i], UriKind.Relative));
        }

        private void btn_test_Click(object sender, RoutedEventArgs e)
        {
            var window = new PanelPacjenta(2);
            window.ShowDialog();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            i--;
            if (i < 0) i = size-1;
            ImageFrame.Source = new BitmapImage(new Uri(sourceList[i], UriKind.Relative));
            lblName.Content = namesList[i];
            lblPrize.Content = prizeList[i];
            dispatcherTimer.Stop();
            dispatcherTimer.Start();
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i > size - 1) i = 0; 
            ImageFrame.Source = new BitmapImage(new Uri(sourceList[i], UriKind.Relative));
            lblName.Content = namesList[i];
            lblPrize.Content = prizeList[i];
            dispatcherTimer.Stop();
            dispatcherTimer.Start();
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

        private void ImageFrame_Click(object sender, RoutedEventArgs e)
        {
            var window = new Login();
            window.ShowDialog();
        }

    }

}
