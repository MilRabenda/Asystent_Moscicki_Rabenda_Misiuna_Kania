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

namespace Panel_Gościa.StronyRecepcja
{
    /// <summary>
    /// Logika interakcji dla klasy StronaEditKonta.xaml
    /// </summary>
    public partial class StronaEditKonta : Page
    {
        public delegate void lbxDoubleClick(int ix);
        public lbxDoubleClick DoubleClick;

        public StronaEditKonta()
        {
            InitializeComponent();
        }
        public void updateContent(List<Osoba> lista)
        {
            lstBox.Items.Clear();
            foreach(var os in lista)
            {
                lstBox.Items.Add(os);
            }
        }

        private void lstBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DoubleClick(lstBox.SelectedIndex);
        }
    }
}
