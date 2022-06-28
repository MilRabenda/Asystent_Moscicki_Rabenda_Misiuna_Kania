using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DatabaseCommunication;

namespace Panel_Gościa
{
    public class Wizyta
    {
        public int idPacjenta { get; set; }
        public int idPielegniarki { get; set; }
        public int idWizyty { get; set; }
        public DateTime data { get; set; }

        public int idBadania { get; set; }
        public decimal cena;
        public Wizyta(int iPa, int iPi, int idW, DateTime time, int idB)
        {
            idPacjenta = iPa;
            idPielegniarki = iPi;
            idWizyty = idW;
            data = time;
            idBadania = idB;
        }
        public Wizyta(int iPa, int iPi, int idW, DateTime time, int idB, decimal c)
        {
            idPacjenta = iPa;
            idPielegniarki = iPi;
            idWizyty = idW;
            data = time;
            idBadania = idB;
            cena = c;
        }

        public override string ToString()
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand polecenie1 = new MySqlCommand($@"SELECT idosoby FROM pielegniarki where idpielegniarki={idPielegniarki}", połączenie);
                połączenie.Open();
                MySqlDataReader Czytaj = polecenie1.ExecuteReader();
                Czytaj.Read();
                int idp = Convert.ToInt32(Czytaj.GetValue(0));
                Czytaj.Close();
                MySqlCommand polecenie2 = new MySqlCommand($@"SELECT imie, nazwisko FROM osoba where idosoby={idp};", połączenie);
                MySqlDataReader Czytaj2 = polecenie2.ExecuteReader();
                Czytaj2.Read();
                string imiepielegniarki = Convert.ToString(Czytaj2.GetValue(0)) + " " + Convert.ToString(Czytaj2.GetValue(1));
                Czytaj2.Close();
                
                return $@"{Getters.getNazwaBadania(idBadania)} | {data} | {imiepielegniarki}";
            }

        }
        public void update()
        {

        }


    }
}
