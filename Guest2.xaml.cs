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
using DatabaseCommunication;

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy Guest2.xaml
    /// </summary>
    public partial class Guest2 : Page
    {
        List<string> infoList;
        List<string> sourceList;
        public Guest2()
        {
            sourceList = new List<string>();
            int[] tab = new int[4] {1,2,3,4};
            
            InitializeComponent();
            
            using (
            MySqlConnection connect = new MySqlConnection(Getters.connectionString))
            {
                
                int i = 0;
                MySqlCommand commandImages = new MySqlCommand($@"SELECT count(zdjecie) FROM badanie", connect);

                connect.Open();
                int size = Convert.ToInt32(commandImages.ExecuteScalar());
                for (int j = 0; j < size; j++) //images
                {
                    Label label = new Label();
                    label.HorizontalAlignment = HorizontalAlignment.Center;
                    //label.FontWeight = FontWeights.Black;
                    MySqlCommand source = new MySqlCommand($@"SELECT zdjecie FROM badanie WHERE idbadania={j+1}", connect);
                    MySqlCommand commandName = new MySqlCommand($@"SELECT nazwabadania FROM badanie WHERE idbadania={j + 1}", connect);
                    MySqlCommand commandPrize = new MySqlCommand($@"SELECT cennik FROM badanie WHERE idbadania={j + 1}", connect);
                    string imageSource = "/images/content/" + Convert.ToString(source.ExecuteScalar());
                    sourceList.Add(imageSource);
                    Image img = new Image();
                    img.Width = 100; img.Height = 75; img.Stretch = Stretch.Fill;
                    img.Source = new BitmapImage(new Uri(sourceList[j], UriKind.Relative));
                    string info = Convert.ToString(commandName.ExecuteScalar())+" "+ Convert.ToString(commandPrize.ExecuteScalar() + " zł"); 
                    if (i<=3)
                    {
                        if (tab[i] == 1) { stack1.Children.Add(img); stack1.Children.Add(label); }
                        else if (tab[i] == 2) { stack2.Children.Add(img); stack2.Children.Add(label); }
                        else if (tab[i] == 3) { stack3.Children.Add(img); stack3.Children.Add(label); }
                        else if (tab[i] == 4) { stack4.Children.Add(img); stack4.Children.Add(label); }
                    }
                    else { i = 0; stack1.Children.Add(img); stack1.Children.Add(label); }
                    label.Content=info;
                i++;

                }
            }    
        }
    }
}
