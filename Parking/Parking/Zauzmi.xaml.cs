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
using MahApps.Metro.Controls;

namespace Parking
{
    /// <summary>
    /// Interaction logic for Zauzmi.xaml
    /// </summary>
    public partial class Zauzmi : MetroWindow
    {
        public Zauzmi()
        {
            InitializeComponent();
            textBox2.Text = DateTime.Now.ToString();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Ulaz novi = new Ulaz();
            novi.RegistracioniBroj = textBox1.Text;
            TimeSpan tmp = DateTime.Now.TimeOfDay;
            novi.Vreme_Ulaska = tmp;
            DataProvider.DodajUlaz(novi);
            MessageBox.Show("Uspešno evidentiran ulaz na parking.");
            this.Close();
        }
    }
}
