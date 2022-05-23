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

        public static List<string> getWizytyPacjent(int idPacjenta)
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
        public static List<string> getWizytyPielęgniarka(int idPielęgniarki)
        {
            using (MySqlConnection połączenie = new MySqlConnection(@"server=localhost;user id=root; password=2137;database=laboratorium"))
            {

                MySqlCommand log = new MySqlCommand($@"select datawizyty,idwizyty from wizyta where idpielegniarki={idPielęgniarki}", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();

                List<string> lista = new List<string>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var f = reader.GetString(0);
                        var s = reader.GetString(1);
                        lista.Add(f+" "+s);
                    }
                }
                reader.Close();
                połączenie.Close();
                return lista;
            }
        }
        public static List<string> getWizytyPielęgniarkaDzisiaj(int idPielęgniarki)
        {
            using (MySqlConnection połączenie = new MySqlConnection(@"server=localhost;user id=root; password=2137;database=laboratorium"))
            {

                MySqlCommand log = new MySqlCommand($@"select datawizyty,idwizyty from wizyta where idpielegniarki={idPielęgniarki}", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();

                List<string> lista = new List<string>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var q = reader.GetString(0);
                        var f = Convert.ToDateTime(q);
                        

                        var s = reader.GetString(1);
                        if (f.DayOfYear == DateTime.Today.AddDays(-5).DayOfYear) lista.Add(f + " " + s);
                        
                    }
                }
                reader.Close();
                połączenie.Close();
                return lista;
            }
        }
        public static bool ZmieńHasło(int idOsoby, string newpassword)
        {
            
            using (MySqlConnection połączenie = new MySqlConnection(@"server=localhost;user id=root; password=2137;database=laboratorium"))
            {
                MySqlCommand command = new MySqlCommand($@"UPDATE osoba SET haslo = '{newpassword}' WHERE idosoby = {idOsoby}", połączenie);
                połączenie.Open();

                var git = command.ExecuteNonQuery() == 1;
                połączenie.Close();
                return git;
            }
        }
    }
    
}
