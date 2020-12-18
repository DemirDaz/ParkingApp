using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
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
using Color = System.Drawing.Color;

namespace Parking
{
    /// <summary>
    /// Interaction logic for Oslobodi.xaml
    /// </summary>
    public partial class Oslobodi : MetroWindow
    {
        private Evidencija ev = new Evidencija();
        public Oslobodi()
        {
            InitializeComponent();
            comboBox.ItemsSource = DataProvider.GetReg();
            textBox3.Text = DateTime.Now.ToString();
            button.IsEnabled = true;
        }

        private Decimal Racunn(TimeSpan a, TimeSpan b) 
        {
            double c;
            decimal cena;
            if (a.TotalMinutes < b.TotalMinutes)
                c = b.TotalMinutes - a.TotalMinutes;
            else c = (b.TotalMinutes + 720) - (a.TotalMinutes - 720);
            cena = (decimal)(c * 1.25);
            return Math.Round(cena, 3);
        }

        

       
        public void button_Click(object sender, RoutedEventArgs e)
        {
            Ulaz a = DataProvider.GetUlaz(comboBox.SelectedItem.ToString());

            Izlaz novi = new Izlaz();
            novi.Registracioni_Broj = comboBox.SelectedItem.ToString();
            TimeSpan tmp = DateTime.Now.TimeOfDay;
            novi.Vreme_Izlaska = tmp;
            DataProvider.DodajIzlaz(novi);

            Izlaz b = DataProvider.GetIzlaz(comboBox.SelectedItem.ToString());
            
            Evidencija srauf = new Evidencija();
            srauf.Registracioni_Broj = b.Registracioni_Broj;
            srauf.Vreme_Izlaska = b.Vreme_Izlaska;
            srauf.Vreme_Ulaska = a.Vreme_Ulaska;
            srauf.Racun = (decimal)Racunn(a.Vreme_Ulaska, b.Vreme_Izlaska);
            srauf.Datum = DateTime.Now.Date;

            DataProvider.DodajEvidenciju(srauf);

            ev = srauf;
            DataProvider.IzbrisiUlaz(a);

            DataProvider.IzbrisiIzlaz(b);

            MessageBox.Show("Cena je: " + Racunn(a.Vreme_Ulaska, b.Vreme_Izlaska) + " dinara.".ToString(),
                       "Uspešno oslobodjeno parking mesto!",
                       MessageBoxButton.OKCancel);


            button.IsEnabled = false;
     
        }

        public void Print()
        {
            var doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(ProvideContent);
            doc.Print();
        }


        public void ProvideContent(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);

            float fontHeight = font.GetHeight();

            int startX = 0;
            int startY = 0;
            int Offset = 20;

            Random r = new Random(100);
            

            
            graphics.DrawString("Dobrodošli na Parking IDEA", new Font("Courier New", 20),
                                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 40;

            graphics.DrawString("Tiket br:" + r.Next(),
                        new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;


            graphics.DrawString("Datum tiketa :" + DateTime.Now.ToLongDateString(),
                        new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 20;

            graphics.DrawString("Vreme uslaska :" + ev.Vreme_Ulaska,
                        new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 20;

            graphics.DrawString("Vreme izlaska :" + ev.Vreme_Izlaska,
                        new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 20;
            String underLine = "------------------------------------------";

            graphics.DrawString(underLine, new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 20;
            String Grosstotal = "Ukupna cena za plaćanje = " + ev.Racun + " Rsd.";

            
            graphics.DrawString(Grosstotal, new Font("Courier New", 14),
                       new SolidBrush(Color.Black), startX, startY + Offset);

            underLine = "------------------------------------------";
            Offset = Offset + 20;
            graphics.DrawString(underLine, new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);

            Offset = Offset + 20;
            graphics.DrawString("Hvala vam na poverenju! Pozdrav.",
                        new Font("Courier New", 14),
                        new SolidBrush(Color.Black), startX, startY + Offset);


        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {

            Print();
            this.Close();
        }
    }
}
