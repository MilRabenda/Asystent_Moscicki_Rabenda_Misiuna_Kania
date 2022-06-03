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
using DatabaseCommunication;

namespace Panel_Gościa.StronyPielegniarka
{
    /// <summary>
    /// Logika interakcji dla klasy StronaWizyty.xaml
    /// </summary>
    public partial class StronaWizyty : Page
    {
        public StronaWizyty()
        {
            InitializeComponent();
        }
        public StronaWizyty(int idOsoby) : this()
        {
            int idPiel = Getters.getIdPielegniarki(idOsoby);
            List<string> lista = Getters.getWizytyPielęgniarka(idPiel);
            foreach(var v in lista){
                lstBox.Items.Add(v);
            }
            if (lista.Count == 0) lstBox.Items.Add($"Brak wizyt");

            lstBox.Background = Brushes.AliceBlue;
            
        }
    }
}
