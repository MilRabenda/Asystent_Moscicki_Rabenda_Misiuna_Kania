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
using System.Windows.Shapes;
using DatabaseCommunication;

namespace Panel_Gościa.StronyRecepcja
{
    /// <summary>
    /// Logika interakcji dla klasy EditWizytaWindow.xaml
    /// </summary>
    public partial class EditWizytaWindow : Window
    {
        private Wizyta wizyta { get; set; }
        public EditWizytaWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public EditWizytaWindow(Wizyta wizyta) : this()
        {
            this.wizyta = wizyta;
            updateDane();
        }
        public void updateDane()
        {
            txtIdPacjenta.Text = wizyta.idPacjenta.ToString();
            txtIdPielegniarki.Text = wizyta.idPielegniarki.ToString();
            txtIdBadania.Text = wizyta.idBadania.ToString();
            txtDataWizyty.Text = wizyta.data.ToString();
        }

        private void btnZmienIdPacjenta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnZmienIdPielegniarki_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnZmienDateWizyty_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnZmienIdBadania_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUsunWizyte_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnKoniec_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public class Wizyta
        {
            public int idPacjenta { get; set; }
            public int idPielegniarki { get; set; }
            public int idWizyty { get; set; }
            public DateTime data { get; set; }

            public int idBadania { get; set; }
            public Wizyta(int iPa, int iPi, int idW, DateTime time, int idB)
            {
                idPacjenta = iPa;
                idPielegniarki = iPi;
                idWizyty = idW;
                data = time;
                idBadania = idB;
            }
            public override string ToString()
            {
                return $"{Getters.getNazwaBadania(idBadania)}, {data}";
            }


        }
    }
}
