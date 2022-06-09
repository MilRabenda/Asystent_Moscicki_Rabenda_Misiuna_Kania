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
    /// Logika interakcji dla klasy ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public int idOsoby { get; set; }
        public ChangePasswordWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public ChangePasswordWindow(int idOs) : this()
        {
            this.idOsoby = idOs;
        }
        private void btnZmien_Click(object sender, RoutedEventArgs e)
        {
            
            if (pwdNewPwd1.Password == string.Empty || pwdNewPwd2.Password == string.Empty)
            {
                MessageBox.Show("Wpisz ponownie nowe hasło");
                return;
            }
            if (pwdNewPwd1.Password != pwdNewPwd2.Password)
            {
                MessageBox.Show("Podane hasła się nie zgadzają");
                return;
            }
            Getters.ZmieńHasło(idOsoby,pwdNewPwd1.Password);
            MessageBox.Show("Zmieniono hasło");
            this.Close();

        }
    }
}
