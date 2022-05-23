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
        public int ok;
        public int OK
        {
            set { this.ok = value; }
            get {return ok; }
        }
        public PanelPacjenta()
        {
            InitializeComponent();
       
        }

        private void btn_TwojeWizyty_Click(object sender, RoutedEventArgs e)
        {
            wizFrame.Content = new WizytyPac();
        }

        private void btn_idk_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz się wylogować?", "Wylogowanie", MessageBoxButton.OKCancel);
            if(result== MessageBoxResult.OK)
            {
                this.Close();
            }
          
        }
    }
}
