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
using MySql.Data.MySqlClient;
using DatabaseCommunication;

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy WizytyPac.xaml
    /// </summary>
    public partial class WizytyPac : Page
    {
        public int id;
        public int ID
        {
            set { this.id = value; }
            get { return id; }
        }
        public WizytyPac(int idpac)
        {
            ID = idpac;
            InitializeComponent();
            
        }

        public void WysWizyty()
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                //pomysł był taki żeby zrobić w tym miejscu wyciąganie wizyt do listy. Wizyta będzie klasą. Tbc:)
            }
        }
    }
}
