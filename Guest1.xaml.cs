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

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy Guest1.xaml
    /// </summary>
    public partial class Guest1 : Page
    {

        public static int i = 0;

        //BitmapImage list
        List<BitmapImage> bitMapList = new List<BitmapImage>();
        //Tab string
        string[] baners= {"Badanie na Anemię 30zł","Badanie serca 55zł","Badanie ogólne 40zł"};

        public Guest1()
        {
            InitializeComponent();
            btn_test.Visibility = Visibility.Visible;

            //photos:

            Image i1 = new Image();
            BitmapImage bitmapImage1 = new BitmapImage(); bitmapImage1.BeginInit();
            bitmapImage1.UriSource = new Uri("images/anemia.jpg", UriKind.Relative);
            bitmapImage1.DecodePixelWidth = 200;
            bitmapImage1.EndInit();


            Image i2 = new Image();
            BitmapImage bitmapImage2 = new BitmapImage(); bitmapImage2.BeginInit();
            bitmapImage2.UriSource = new Uri(@"C:\Users\milen\Documents\GitHub\5555\Asystent_Moscicki_Rabenda_Misiuna_Kania\images\serce.jpg");
            bitmapImage2.DecodePixelWidth = 200;
            bitmapImage2.EndInit();

            Image i3 = new Image();
            BitmapImage bitmapImage3 = new BitmapImage(); bitmapImage3.BeginInit();
            bitmapImage3.UriSource = new Uri(@"C:\Users\milen\Documents\GitHub\5555\Asystent_Moscicki_Rabenda_Misiuna_Kania\images\podstawa.jpg");
            bitmapImage3.DecodePixelWidth = 200;
            bitmapImage3.EndInit();
            bitMapList.Add(bitmapImage1);
            bitMapList.Add(bitmapImage2);
            bitMapList.Add(bitmapImage3);
            //image in widget
            ImageBaner.Source= bitMapList[i];
            lblBaner.Content = baners[i];
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
            ImageBaner.Source = bitMapList[i];
            lblBaner.Content=baners[i];
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i > 2) i =0;
            ImageBaner.Source = bitMapList[i];
            lblBaner.Content = baners[i];
        }
    }

}
