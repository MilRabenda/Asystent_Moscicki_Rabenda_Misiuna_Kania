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
    public partial class WizytyPac : Page
    {
        public int id;
        public int ID
        {
            set { this.id = value; }
            get { return id; }
        }
        List<Wizyta> listawizyt = new List<Wizyta>();
        public WizytyPac(int idpac)
        {
            ID = idpac;
            InitializeComponent();
            WysWizyty();
            
        }

        public void WysWizyty()
        {
            
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"select * from wizyta where idpacjenta={ID}", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                List<Wizyta> lista = new List<Wizyta>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var f = reader.GetInt32(0);
                        var g = reader.GetInt32(1);
                        var h = reader.GetInt32(2);
                        var i = reader.GetDateTime(3);
                        var j = reader.GetInt32(4);
                        var k = reader.GetDecimal(5);

                        Wizyta wiz = new Wizyta(f, g, h, i, j);
                        lista.Add(wiz);
                        lbxWizyty.Items.Add(wiz);
                    }
                }
                listawizyt = lista;
                reader.Close();
                połączenie.Close();
            }
        }
    }
}
