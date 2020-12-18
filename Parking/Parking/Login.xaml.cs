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
using MahApps.Metro.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Parking
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
   
    public partial class Login : MetroWindow
    {
       
        public Login()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<Korisnik> provera = DataProvider.GetKorisnike();
            bool ulaz = false;
            DataProvider.setAdmin(false);
            DataProvider.setRadnik(false);

            foreach (Korisnik n in provera)
            { if (n.Korisnicko_Ime == textBox.Text && n.Sifra == passwordBox.Password && n.Pozicija == "Administrator")
                {
                    DataProvider.setAdmin(true);
                    ulaz = true;
                    break;
                }
                else if (n.Korisnicko_Ime == textBox.Text && n.Sifra == passwordBox.Password && n.Pozicija == "Radnik")
                {
                    DataProvider.setRadnik(true);
                    ulaz = true;
                    break;
                }
                else ulaz = false;
            }
            if (ulaz == true && DataProvider.getAdmin() == true)
            {
                MainWindow mv = new MainWindow();
                mv.Owner = this;
                mv.ShowDialog();
            }
            else if (ulaz == true && DataProvider.getRadnik() == true)
            {
                MainWindow mv = new MainWindow();
                mv.Owner = this;
                mv.ShowDialog();
            }
            else MessageBox.Show("Pogresili ste. Pokušajte ponovo");
        }
    }
}
