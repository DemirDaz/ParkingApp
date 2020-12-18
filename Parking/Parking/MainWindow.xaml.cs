using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Parking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        ObservableCollection<Evidencija> grid = new ObservableCollection<Evidencija>();
        ObservableCollection<Ulaz> grid2 = new ObservableCollection<Ulaz>();

        public MainWindow()
        {
            InitializeComponent();
            if (DataProvider.getAdmin() == true)
            {
                NapuniGrid();
                dataGrid.ItemsSource = grid;
                button.Visibility = Visibility.Hidden;
                button1.Visibility = Visibility.Hidden;
                button2.Visibility = Visibility.Hidden;
                label.Content = "Dnevni Pazar:";
                textBox.Text = dnevniPrihod();

            }

            if (DataProvider.getRadnik() == true)
            {
                NapuniUlaze();
                dataGrid.ItemsSource = grid2;
                button.Visibility = Visibility.Visible;
                button1.Visibility = Visibility.Visible;
                button2.Visibility = Visibility.Visible;
                label.Content = "Broj slobodnih mesta:";
                textBox.Text = dnevniBroj();
            }



        }

        public string dnevniPrihod() {
          decimal ukupno = 0;
            foreach (Evidencija r in DataProvider.GetEvidencije())
               if(r.Datum == DateTime.Now.Date)
                ukupno = ukupno + r.Racun;
            return ukupno.ToString();
        }

        public string dnevniBroj()
        {
            int slobodna = 200;
            foreach (Ulaz r in DataProvider.GetUlaze())
                slobodna = slobodna - 1;
            return slobodna.ToString();
        }


        void NapuniGrid() 
        {
            foreach (Evidencija r in DataProvider.GetEvidencije()) 
            {
                grid.Add(r);
            }
        }

        void NapuniUlaze()
        {
            foreach (Ulaz r in DataProvider.GetUlaze())
            {
                grid2.Add(r);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Oslobodi s = new Oslobodi();
            s.Owner = this;
            s.ShowDialog();
            

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Zauzmi z = new Zauzmi();
            z.Owner = this;
            z.ShowDialog();
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            grid2.Clear();
            NapuniUlaze();
            dataGrid.ItemsSource = grid2;
            textBox.Text = dnevniBroj();


        }
    }
}
