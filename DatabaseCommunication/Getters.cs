using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DatabaseCommunication
{
    public static class Getters
    {
        public static Dictionary<int, string> mapaBadania = new Dictionary<int, string>() { 
            { 1, "Badanie Podstawowe" },
            { 2, "Badanie na Anemię" },
            { 3, "Badanie Serca" },
            { 4, "Badanie na Alergię" },
            { 5, "Badanie na Cukrzycę" },
            { 6, "Badanie nerek" },
            { 7, "Badanie na Reumatyzm" },
            { 8, "Badanie Tarczycy" },
            { 9, "Badanie Wątroby" }
        };
        public static string connectionString = "server=localhost;user id=root; password=2137;database=laboratorium";
        public static string getConnectionString()
        {
            FileStream fileStream = new FileStream(connectionString, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fileStream);
            string constr = sw.ReadToEnd();
            sw.Close();
            fileStream.Close();
            return constr;
        }
        /// <summary>
        /// Returns NULL if logging in fails.
        /// Returns false if logged person was patient.
        /// Returns true if logged person was worker.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool? tryToLogIn(string login, string password)
        {
            //jeśli zwrócimy null, to nie udało się zalogować
            //jeśli false to pacjent
            //jeśli true to pracownik
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                if (Methods.isPesel(login))
                {
                    MySqlCommand log = new MySqlCommand($@"SELECT pesel FROM osoba where pesel='{login}'", połączenie);
                    MySqlCommand has = new MySqlCommand($@"SELECT haslo FROM osoba where pesel='{password}'", połączenie);
                    połączenie.Open();
                    MySqlDataReader poprawne_log = log.ExecuteReader();
                    bool ok1;
                    bool ok2;
                    ok1 = poprawne_log.HasRows;
                    poprawne_log.Close();
                    MySqlDataReader poprawne_has = has.ExecuteReader();
                    ok2 = poprawne_has.HasRows;
                    poprawne_has.Close();
                    if (ok1 && ok2)
                    {
                        połączenie.Close();
                        return false;
                    }
                }
                else
                {
                    MySqlCommand mail = new MySqlCommand($@"SELECT mail FROM osoba where mail='{login}'", połączenie);
                    MySqlCommand has = new MySqlCommand($@"SELECT haslo FROM osoba where mail='{password}'", połączenie);
                    połączenie.Open();
                    MySqlDataReader poprawne_log = mail.ExecuteReader();
                    bool ok1;
                    bool ok2;
                    ok1 = poprawne_log.HasRows;
                    poprawne_log.Close();
                    MySqlDataReader poprawne_has = has.ExecuteReader();
                    ok2 = poprawne_has.HasRows;
                    poprawne_has.Close();
                    if (ok1 && ok2)
                    {
                        połączenie.Close();
                        return true;
                    }
                }
                połączenie.Close();
                return null;
            }
        }
        

        public static List<string> getWizytyPacjent(int idPacjenta)
        {
            using (MySqlConnection połączenie = new MySqlConnection(connectionString))
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
            using (MySqlConnection połączenie = new MySqlConnection(connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"select datawizyty,idbadania from wizyta where idpielegniarki={idPielęgniarki}", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                List<string> lista = new List<string>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var data = reader.GetDateTime(0);
                        var idbadania = reader.GetInt32(1);
                        mapaBadania.TryGetValue(idbadania, out string nazwa);
                        lista.Add(nazwa + " " + data.ToString("dd.MM.yyyy"));
                    }
                }
                reader.Close();
                połączenie.Close();
                return lista;
            }
        }
        public static List<string> getWizytyPielęgniarkaDzisiaj(int idPielęgniarki)
        {
            using (MySqlConnection połączenie = new MySqlConnection(connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"select datawizyty,idbadania from wizyta where idpielegniarki={idPielęgniarki}", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                List<string> lista = new List<string>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var date = reader.GetDateTime(0);
                        var s = reader.GetString(1);
                        if (date.DayOfYear == DateTime.Today.DayOfYear) lista.Add(date + " " + s);
                    }
                }
                reader.Close();
                połączenie.Close();
                return lista;
            }
        }
        public static bool ZmieńHasło(int idOsoby, string newPassword)
        {
            using (MySqlConnection połączenie = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand($@"UPDATE osoba SET haslo = '{newPassword}' WHERE idosoby = {idOsoby}", połączenie);
                połączenie.Open();
                var git = command.ExecuteNonQuery() == 1;
                połączenie.Close();
                return git;
            }
        }
    }
    
}
