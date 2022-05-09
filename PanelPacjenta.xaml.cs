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

namespace Panel_Gościa
{
    /// <summary>
    /// Logika interakcji dla klasy PanelPacjenta.xaml
    /// </summary>
    public partial class PanelPacjenta : Window
    {
        public PanelPacjenta()
        {
            InitializeComponent();
            lbl_Witaj.Content = "Witaj /imie/ !";
        }

        private void btn_TwojeWizyty_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
