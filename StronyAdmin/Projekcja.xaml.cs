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

        List<string> checkedBoxes = new List<string>();
        public delegate void PassListToAdmin(List<string> lista);
        public PassListToAdmin list;
        public Projekcja()
        {

            InitializeComponent();
            using (
            MySqlConnection connect = new MySqlConnection(Getters.connectionString))
            {
                connect.Open();
                MySqlCommand command = new MySqlCommand($@"SELECT COUNT(*) FROM badanie WHERE zdjecie IS NOT NULL", connect);
                int max = Convert.ToInt32(command.ExecuteScalar());

                for (int i = 1; i <= max; i++)
                {

                    MySqlCommand commandName = new MySqlCommand($@"SELECT nazwabadania FROM badanie WHERE idbadania={i}", connect);
                    string s = Convert.ToString(commandName.ExecuteScalar());
                    CheckBox checkBox = new CheckBox();
                    lbBadania.Items.Add(checkBox = new CheckBox());
                    checkBox.Content = s;
                    checkBox.Checked += Checked;
                    checkBox.Unchecked += UnChecked;
                }
            }
        }
        private void Checked(object sender, RoutedEventArgs e)
        {
            string content = (sender as CheckBox).Content.ToString();
            checkedBoxes.Add(content);

        }
        private void UnChecked(object sender, RoutedEventArgs e)
        {
            string content = (sender as CheckBox).Content.ToString();
            checkedBoxes.Remove(content);
        }
        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            string s="";
            foreach (var item in checkedBoxes)
            {
                s += item;
            }
            MessageBox.Show(s);
            list(checkedBoxes); 
        }
    }
}
    