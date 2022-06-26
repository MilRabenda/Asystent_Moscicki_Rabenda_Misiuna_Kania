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
        public static int i = 0;
        List<string> sourceList;
        List<string> namesList; 
        List<string> prizeList;
        DispatcherTimer dispatcherTimer = new DispatcherTimer(); //next image per 3s
        public void WypProjekcje()
        {

            using (MySqlConnection connect = new MySqlConnection(Getters.connectionString)) {
                connect.Open();              

                    MySqlCommand source = new MySqlCommand($@"SELECT zdjecie FROM badanie WHERE wyóżnione = 1", connect);
                    MySqlCommand commandName = new MySqlCommand($@"SELECT nazwabadania FROM badanie WHERE wyóżnione = 1", connect);
                    MySqlCommand commandPrize = new MySqlCommand($@"SELECT cennik FROM badanie WHERE wyóżnione = 1", connect);
                    sourceList = new List<string>();
                    namesList = new List<string>();//names
                    prizeList = new List<string>();//prizes
                foreach (var item in sourceList)
                {
                    string imageSource = "/images/content/" + Convert.ToString(source.ExecuteScalar());
                    sourceList.Add(imageSource);
                    string name = Convert.ToString(commandName.ExecuteScalar());
                    string prize = Convert.ToString(commandPrize.ExecuteScalar() + " zł");
                    namesList.Add(name);
                    prizeList.Add(prize);
                    lblName.Content = namesList[i];
                    lblPrize.Content = prizeList[i];
                    ImageFrame.Source = new BitmapImage(new Uri(sourceList[i], UriKind.Relative));
                    connect.Close();
                    dispatcherTimer.Tick += dispatcherTimer_Tick;
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
                    dispatcherTimer.Start();
                }
            }
        }
        public Guest1()
        {
            InitializeComponent();
            WypProjekcje();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
           i++; if (i > 6) i = 0;
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
            if (i < 0) i = 6;
            ImageFrame.Source = new BitmapImage(new Uri(sourceList[i], UriKind.Relative));
            lblName.Content = namesList[i];
            lblPrize.Content = prizeList[i];
            dispatcherTimer.Stop();
            dispatcherTimer.Start();
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i > 6) i = 0; 
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
