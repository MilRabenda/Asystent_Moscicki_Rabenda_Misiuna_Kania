using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCommunication;
using MySql.Data.MySqlClient;

namespace Panel_Gościa
{
    public class Osoba
    {
        public int idOsoby { get; set; }
        public string nazwisko { get; set; }
        public string imie { get; set; }
        public string adres { get; set; }
        public string pesel { get; set; }
        public string mail { get; set; }
        public string telefon { get; set; }
        public string hasło { get; set; }
        public bool aktywne { get; set; }
        public Osoba(int idOsoby, string nazwisko, string imie, string adres, string pesel, string mail, string telefon, string haslo, bool aktywne)
        {
            this.idOsoby = idOsoby;
            this.nazwisko = nazwisko;
            this.imie = imie;
            this.adres = adres;
            this.pesel = pesel;
            this.mail = mail;
            this.telefon = telefon;
            this.hasło = haslo;
            this.aktywne = aktywne;
        }
        public Osoba(int idOsoby)
        {
            this.idOsoby = idOsoby;
            update();
            
        }
        public override string ToString()
        {
            return $"{imie} {nazwisko}, {pesel}, {mail}";
        }
        public void changeTel(string newTel)
        {
            this.telefon = newTel;
        }
        public void update()
        {
            using (MySqlConnection połączenie = new MySqlConnection(Getters.connectionString))
            {
                MySqlCommand log = new MySqlCommand($@"select * from osoba where idosoby={idOsoby}", połączenie);
                połączenie.Open();
                MySqlDataReader reader = log.ExecuteReader();
                var oldId = idOsoby;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.idOsoby = reader.GetInt32(0);
                        if (oldId != this.idOsoby) throw new Exception("Błędne nowe id?<osoba>");
                        this.nazwisko = reader.GetString(1);
                        this.imie = reader.GetString(2);
                        this.adres = reader.GetString(3);
                        this.pesel = reader.GetString(4);
                        this.mail = reader.GetString(5);
                        this.telefon = reader.GetString(6);
                        this.hasło = reader.GetString(7);
                        this.aktywne = reader.GetBoolean(8);
                    }
                }
                reader.Close();
                połączenie.Close();
            }
        }
    }
}
