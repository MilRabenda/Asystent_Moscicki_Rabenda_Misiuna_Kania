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
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            lblZar.Content = "Załóż konto M-Pacjenta";
            
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtName.Clear();
        }

        private void txtSurname_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtSurname.Clear();
        }

        private void txtAdres_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtAdres.Clear();
        }

        private void txtPesel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtPesel.Clear();
        }

        private void txtMail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtMail.Clear();
        }

        private void txtTelefon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtTelefon.Clear();
        }
    }

}

