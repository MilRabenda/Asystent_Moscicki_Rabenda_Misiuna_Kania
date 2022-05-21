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

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy Guest2.xaml
    /// </summary>
    public partial class Guest2 : Page
    {
        List<string> sourceList;
        public Guest2()
        {
            sourceList = new List<string>();
            int[] tab = new int[4] {1,2,3,4};
            
            InitializeComponent();
          
            using (
            MySqlConnection connect = new MySqlConnection(@"server=localhost;user id=root; password=root;database=laboratorium"))
            {
                int i = 0;
                MySqlCommand commandImages = new MySqlCommand($@"SELECT count(zdjecie) FROM badanie", connect);
                connect.Open();
                int size = Convert.ToInt32(commandImages.ExecuteScalar());
                for (int j = 0; j < size; j++) //images
                {
                    MySqlCommand source = new MySqlCommand($@"SELECT zdjecie FROM badanie WHERE idbadania={j+1}", connect);
                    string imageSource = "/images/content/" + Convert.ToString(source.ExecuteScalar());
                    sourceList.Add(imageSource);
                    Image img = new Image();
                    img.Width = 100; img.Height = 75; img.Stretch = Stretch.Fill;
                    img.Source = new BitmapImage(new Uri(sourceList[j], UriKind.Relative));
                    if (i<=3)
                    {
                        if (tab[i] == 1) stack1.Children.Add(img);
                        else if (tab[i] == 2) stack2.Children.Add(img);
                        else if (tab[i] == 3) stack3.Children.Add(img);
                        else if (tab[i] == 4) stack4.Children.Add(img);
                    }
                    else { i = 0; stack1.Children.Add(img); }
                    i++;

                }
            }    
        }
    }
}
