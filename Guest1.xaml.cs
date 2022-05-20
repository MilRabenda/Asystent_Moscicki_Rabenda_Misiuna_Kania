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
        public static int indx=1;

        //BitmapImage list
        
        //Tab string
        string[] baners= {"xBadanie na Anemię 30zł","xBadanie serca 55zł","xBadanie ogólne 40zł"};

        public Guest1()
        {
            List<Image> imageList = new List<Image>();
            InitializeComponent();
            btn_test.Visibility = Visibility.Visible;

            //MySqlCommand ZdjAutka = new MySqlCommand($"SELECT zdjecie from pojazdy WHERE IdPojazdy = {i};", con);
            //String zdj = Convert.ToString(ZdjAutka.ExecuteScalar());
            //myImage.Source = new BitmapImage(new Uri(zdj, UriKind.Relative));

            using (
            MySqlConnection połączenie = new MySqlConnection(@"server=localhost;user id=root; password=root;database=laboratorium")) {

                
                foreach (var img in imageList)
                {
                    
                    MySqlCommand image = new MySqlCommand($@"SELECT zdjecie FROM badanie WHERE idbadania={indx}", połączenie);
                    String source = Convert.ToString(image.ExecuteScalar());
                    img.Source = new BitmapImage(new Uri(source, UriKind.Relative));
                    imageList[i] =img;
                }
                lblImage.Content = imageList[0];
            }
           
            //imgFrame = imageList[0];
                //photos:

            //    Image i1 = new Image();
            //BitmapImage bitmapImage1 = new BitmapImage(); bitmapImage1.BeginInit();
            //bitmapImage1.UriSource = new Uri("images/anemia.jpg", UriKind.Relative);
            //bitmapImage1.DecodePixelWidth = 200;
            //bitmapImage1.EndInit();


            //Image i2 = new Image();
            //BitmapImage bitmapImage2 = new BitmapImage(); bitmapImage2.BeginInit();
            //bitmapImage2.UriSource = new Uri("images/serce.jpg", UriKind.Relative);
            //bitmapImage2.DecodePixelWidth = 200;
            //bitmapImage2.EndInit();

            //Image i3 = new Image();
            //BitmapImage bitmapImage3 = new BitmapImage(); bitmapImage3.BeginInit();
            //bitmapImage3.UriSource = new Uri("images/podstawa.jpg", UriKind.Relative);
            //bitmapImage3.DecodePixelWidth = 200;
            //bitmapImage3.EndInit();
            //bitMapList.Add(bitmapImage1);
            //bitMapList.Add(bitmapImage2);
            //bitMapList.Add(bitmapImage3);
            ////image in widget
            //ImageBaner.Source= bitMapList[i];
            //lblBaner.Content = baners[i];
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
           // ImageBaner.Source = bitMapList[i];
            lblBaner.Content=baners[i];
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i > 2) i =0;
            //ImageBaner.Source = bitMapList[i];
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
