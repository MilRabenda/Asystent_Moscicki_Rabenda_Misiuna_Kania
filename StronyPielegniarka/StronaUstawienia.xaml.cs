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

namespace Panel_Gościa.StronyPielegniarka
{
    /// <summary>
    /// Logika interakcji dla klasy StronaUstawienia.xaml
    /// </summary>
    public partial class StronaUstawienia : Page
    {
        public Action ClickPassword;
        public Action DeactivateMe;
        private int idOsoby;
        public StronaUstawienia()
        {
            InitializeComponent();
        }
        public StronaUstawienia(int idOsoby) : this()
        {
            this.idOsoby = idOsoby;

        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            this.ClickPassword();
        }

        private void btnDeactivate_Click(object sender, RoutedEventArgs e)
        {
            this.DeactivateMe();
        }
    }
}
