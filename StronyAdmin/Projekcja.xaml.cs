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
namespace Panel_Gościa.StronyAdmin
{
    /// <summary>
    /// Logika interakcji dla klasy Projekcja.xaml
    /// </summary>
    public partial class Projekcja : Page
    {

        public Projekcja()
        {
           
            InitializeComponent();
            using (
            MySqlConnection connect = new MySqlConnection(Getters.connectionString))
            {

                connect.Open();
                for (int i = 1; i <= 6; i++)
                {
                    MySqlCommand commandName = new MySqlCommand($@"SELECT nazwabadania FROM badanie WHERE idbadania={i}", connect);
                    string s = Convert.ToString(commandName.ExecuteScalar());
                    CheckBox checkBox;
                    lbBadania.Items.Add(checkBox = new CheckBox());
                    checkBox.Content = s;
                }
            }
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            //pobierz id z checkedboxów i prześlij do guest1
        }
    }
}
