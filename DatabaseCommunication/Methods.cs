using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabaseCommunication
{
    public static class Methods
    {
        public static void addPatient(string nazwisko, string imie, string adres, string pesel,string mail,string telefon,string haslo)
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                int idOsoby = getIdOsoby();
                int idPacjenta = getIdPacjenta();

                MySqlCommand log = new MySqlCommand($@"INSERT INTO osoba VALUES ({idOsoby},{nazwisko},{imie},{adres},{pesel},{mail},{telefon},{haslo},0)", połączenie);
                MySqlCommand log2 = new MySqlCommand($@"INSERT INTO pacjenci VALUES ({idPacjenta},{idOsoby})", połączenie);

                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();

                połączenie.Close();

            }
        }
        private static int getIdOsoby()
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"SELECT COUNT(*) FROM osoba", połączenie);
                połączenie.Open();
                MySqlDataReader readCount = log.ExecuteReader();
                int idOsoby = readCount.GetInt32(0);
                połączenie.Close();
                return idOsoby;
            }
        }
        /// <summary>
        /// Returns the patient id
        /// </summary>
        private static int getIdPacjenta()
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"SELECT COUNT(*) FROM pacjenci", połączenie);
                połączenie.Open();
                MySqlDataReader readCount = log.ExecuteReader();
                int idPacjenta = readCount.GetInt32(0);
                połączenie.Close();
                return idPacjenta;
            }
        }
        public static void deactivatePatient(int idOsoby)
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {

                MySqlCommand log = new MySqlCommand($@"UPDATE osoba SET aktywne=1 WHERE idosoby={idOsoby}", połączenie);
                połączenie.Open();
                log.ExecuteNonQuery();
                
                połączenie.Close();

            }
        }
        public static bool isEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        public static bool isPesel(string str)
        {
            var isNumeric = long.TryParse(str, out long n);
            return str.Length == 11 && isNumeric;
        }
        
        public static string getUserType(int idOsoby)
        {
            string final = "";
            if (isAnalityk(idOsoby)) final = "analityk";
            if (isPersonelRecepcji(idOsoby)) final = "personel recepcji";
            if (isPielegniarka(idOsoby)) final = "pielegniarka";

            return final;
        }
        public static bool isAnalityk(int idOsoby)
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"SELECT idanalityka FROM analityk WHERE idosoby='{idOsoby}'", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                bool ok = reader.HasRows;
                połączenie.Close();
                return ok;
            }
        }
        public static bool isPersonelRecepcji(int idOsoby)
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"SELECT idrecepcjonistki FROM personelrecepcji WHERE idosoby='{idOsoby}'", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                bool ok = reader.HasRows;
                połączenie.Close();
                return ok;
            }
        }
        public static bool isPielegniarka(int idOsoby)
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"SELECT idpielegniarki FROM pielegniarki WHERE idosoby='{idOsoby}'", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                bool ok = reader.HasRows;

                połączenie.Close();
                return ok;
            }
        }
    }
}
