using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DatabaseCommunication
{
    public static class Getters
    {

        public static List<string> getWizyty(int idPacjenta)
        {
            using (MySqlConnection połączenie = new MySqlConnection(@"server=localhost;user id=root; password=2137;database=laboratorium"))
            {

                MySqlCommand log = new MySqlCommand($@"select datawizyty from wizyta where idpacjenta={idPacjenta}", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();

                List<string> lista = new List<string>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var f = reader.GetString(0);
                        lista.Add(f);
                    }
                }
                reader.Close();
                połączenie.Close();
                return lista;

            }
        }
    }
}
