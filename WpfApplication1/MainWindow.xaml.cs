using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        List<Klient> klienci = new List<Klient>();
        List<Bank> banki = new List<Bank>();
        public MainWindow()
        {
            InitializeComponent();
            wczytywanieBanki();
            wczytywanieKlienci();

        }
        public void wczytywanieKlienci()
        {
            if (File.Exists("kliencilista.txt"))
            {
                string[] linijki = File.ReadAllLines("kliencilista.txt", Encoding.UTF8);
                Klient k;
                for (int i = 0; i < linijki.Length; i++)
                {
                    string[] aktualnaLinijka = linijki[i].Split(';');
                    k = new Klient(aktualnaLinijka[0], aktualnaLinijka[1]);
                    klienci.Add(k);
                }
            }

            listapokaz.ItemsSource = klienci;
        }
        public void wczytywanieBanki()
        {
            if (File.Exists("bankilista.txt"))
            {
                string[] linijki = File.ReadAllLines("bankilista.txt", Encoding.UTF8);
                Bank b;
                for (int i = 0; i < linijki.Length; i++)
                {
                    string[] aktualnaLinijka = linijki[i].Split(';');
                    b = new Bank(aktualnaLinijka[0], aktualnaLinijka[1]);
                    banki.Add(b);
                }
            }
            
            listabankipokaz.ItemsSource = banki;
        }

        private void guzik_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("zapisBanki.txt"))
            {
                for (int i = 0; i < banki.Count; i++)
                {
                    writer.Write(banki[i].nazwa + ";");
                    writer.WriteLine(banki[i].id);
                }
            }
            napis.Content = "zapisano banki";
        }

        private void zapis_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("zapisKlienci.txt"))
            {
                for (int i = 0; i < klienci.Count; i++)
                {
                    writer.Write(klienci[i].imie+";");
                    writer.WriteLine(klienci[i].nazwisko);
                }
            }
            napis.Content = "zapisano klientow";
        }
    }

        
    
    
}

