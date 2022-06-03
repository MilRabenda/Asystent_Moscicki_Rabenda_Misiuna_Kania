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
    /// Logika interakcji dla klasy StronaZmienHaslo.xaml
    /// </summary>
    public partial class StronaZmienHaslo : Page
    {
        public delegate void changePwd(string x);
        public changePwd ChangePassword;
        public delegate bool checkPwd(int idOsoby, string x);
        public checkPwd CheckPassword;
        private int idOsoba;
        public StronaZmienHaslo()
        {
            InitializeComponent();
        }
        public StronaZmienHaslo(int idOsoba) : this()
        {
            this.idOsoba = idOsoba;
        }

        private void btnZmien_Click(object sender, RoutedEventArgs e)
        {
            if (pwdCurrentPwd.Password == string.Empty)
            {
                MessageBox.Show("Wpisz ponownie aktualne hasło");
                return;
            }
            if (!CheckPassword(idOsoba, pwdCurrentPwd.Password))
            {
                MessageBox.Show("Podane hasło się nie zgadza");
                return;
            }
            if(pwdNewPwd1.Password == string.Empty || pwdNewPwd2.Password == string.Empty)
            {
                MessageBox.Show("Wpisz ponownie nowe hasło");
                return;
            }
            if(pwdNewPwd1.Password != pwdNewPwd2.Password)
            {
                MessageBox.Show("Podane hasła się nie zgadzają");
                return;
            }
            this.ChangePassword(pwdNewPwd1.Password);
            MessageBox.Show("Zmieniono hasło");

        }
    }
}
