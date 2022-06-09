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
using MySql.Data.MySqlClient;
using DatabaseCommunication;

namespace Panel_Gościa.StronyRecepcja
{
    /// <summary>
    /// Logika interakcji dla klasy StronaEditWizyty.xaml
    /// </summary>
    public partial class StronaEditWizyty : Page
    {
        public delegate void lbxDoubleClick(int ix);
        public lbxDoubleClick DoubleClick;
        public StronaEditWizyty()
        {
            InitializeComponent();
            //updateContent();
        }
        
        public void updateContent(List<Wizyta> lista)
        {
            lstBox.Items.Clear();
            foreach (var wiz in lista)
            {
                lstBox.Items.Add(wiz);
            }
        }

        private void lstBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DoubleClick(lstBox.SelectedIndex);
        }
    }
}
