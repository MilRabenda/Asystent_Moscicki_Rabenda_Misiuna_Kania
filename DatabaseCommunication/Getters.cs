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
                    MySqlCommand log = new MySqlCommand($@"SELECT haslo FROM osoba where pesel='{login}'", połączenie);
                    połączenie.Open();
                    MySqlDataReader reader = log.ExecuteReader();
                    string correctPassword = "";
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            correctPassword = reader.GetString(0);
                        }
                    }
                    reader.Close();
                    połączenie.Close();

                    if (correctPassword == password) return false;
                    
                }
                else
                {
                    MySqlCommand log = new MySqlCommand($@"SELECT haslo FROM osoba where mail='{login}'", połączenie);
                    połączenie.Open();
                    MySqlDataReader reader = log.ExecuteReader();
                    string correctPassword = "";
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            correctPassword = reader.GetString(0);
                        }
                    }
                    reader.Close();
                    połączenie.Close();

                    if (correctPassword == password) return true;
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
                        lista.Add(getNazwaBadania(idbadania) + " " + data.ToString("dd.MM.yyyy"));
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
        public static int getIdOsoby(string login)
        {
            int idOsoby = -1;
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                if (Methods.isPesel(login))
                {
                    MySqlCommand log = new MySqlCommand($@"SELECT idosoby FROM osoba where pesel='{login}'", połączenie);
                    połączenie.Open();
                    MySqlDataReader reader = log.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            idOsoby = reader.GetInt32(0);
                        }
                    }
                    reader.Close();
                    połączenie.Close();
                }
                else
                {
                    MySqlCommand log = new MySqlCommand($@"SELECT idosoby FROM osoba where mail='{login}'", połączenie);
                    połączenie.Open();
                    MySqlDataReader reader = log.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            idOsoby = reader.GetInt32(0);
                        }
                    }
                    reader.Close();
                    połączenie.Close();
                }
                połączenie.Close();
            }
            return idOsoby;
        }
        public static string getImie(int idOsoby)
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"SELECT imie FROM osoba where idosoby='{idOsoby}'", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                string str = "błąd";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        str = reader.GetString(0);
                    }
                }
                reader.Close();
                połączenie.Close();
                return str;
            }

        }
        public static int getIdPielegniarki(int idOsoby)
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"SELECT idpielegniarki FROM pielegniarki where idosoby='{idOsoby}'", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                int licz = -1;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        licz = reader.GetInt32(0);
                    }
                }
                reader.Close();
                połączenie.Close();
                return licz;
            }
        }
        public static string getCurrentPassword(int idOsoby)
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"SELECT haslo FROM osoba where idosoby='{idOsoby}'", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                string pwd = "";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pwd = reader.GetString(0);
                    }
                }
                
                reader.Close();
                połączenie.Close();
                if (pwd == string.Empty) throw new Exception($"FATAL ERROR, id {idOsoby}");
                return pwd;
            }
        }
        public static bool checkPassword(int idOsoby, string password)
        {
            var pwd = getCurrentPassword(idOsoby);
            return pwd == password;
        }
        public static string getNazwaBadania(int idBadania)
        {
            using (MySqlConnection połączenie = new MySqlConnection(connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"SELECT nazwabadania FROM badanie where idbadania='{idBadania}'", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                string nazwa = "";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        nazwa = reader.GetString(0);
                    }
                }

                reader.Close();
                połączenie.Close();
                if (nazwa == string.Empty) throw new Exception($"Nie można wyciągnąć nazwy");
                return nazwa;
            }
        }
    }
    
}
