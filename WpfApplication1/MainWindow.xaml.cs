using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Bank
    {
        public string nazwa;
        public string id; //ciag 6 liczb zapisany w kodzie karty, reprezentujacy bank
        private List<Karta> karty;
        private List<Klient> klienci;

        public List<Klient> Klienci
        {
            get
            {
                return klienci;
            }

            set
            {
                klienci = value;
            }
        }

        public Bank(string nazwa, string id)
        {
            this.nazwa = nazwa;
            this.id = id;
            this.karty = new List<Karta>();
            this.klienci = new List<Klient>();
        }

        

        public void dodajKlienta(Klient klient)
        {
            this.klienci.Add(klient);
        }
        public void dodajKarte(Karta karta)
        {
            this.karty.Add(karta);
        }
        public void usunKlienta(Klient klient)
        {
            this.klienci.Remove(klient);
        }
        public void usunKarte(Karta karta)
        {
            this.karty.Remove(karta);
        }
        public void przedluzWaznosc(Karta karta, int okres)
        {
            //TODO: obsłużyć wyjątki (exceptions)
            karty.Find(szukanaKarta => szukanaKarta == karta).Termin_wygasniecia.AddMonths(okres);
        }
        public bool autoryzacjaTransakcji(Transakcja transakcja)
        {
            Random rnd = new Random();
            return (rnd.Next(0, 150) > 50 ? true : false);
        }

        private string generujUnikalnyNumerKarty()
        {
            Random random = new Random();
            const string chars = "0123456789";

            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)])
              .ToArray());
        }

        public Karta wydajKarte(Klient klient) //bank wydaje karte klientowi; czyli tworzy karte u siebie i przypisuje ją do klienta
        {
            Karta nowaKarta = new Karta(this.id + this.generujUnikalnyNumerKarty(), this);

            karty.Add(nowaKarta); //TODO: stworzyć słownik łączący kartę z jej właścicielem

            if (!klienci.Exists(szukanyKlient => szukanyKlient == klient))
            {
                klienci.Add(klient); //jeśli bank nie ma jeszcze klienta to dodaj
            }
            return nowaKarta;
        }
    }


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Console.Write("oh shit");

            Firma firma1 = new Firma("orange", "telekom");
            Klient klient1 = new Klient("Jan", "Nowak");

            Bank bank1 = new Bank("mbank", "512345");
            Karta karta1 = new Karta("5123450099883344", bank1);

            CentrumObslugiTransakcji cot1 = new CentrumObslugiTransakcji("COT1");

            klient1.dodajKarte(bank1.wydajKarte(klient1)); //jakoś zamienić, żeby zmienna klient1 się nie powtarzała

            cot1.dodajBank(bank1);
            cot1.dodajFirme(firma1);
            
            InitializeComponent();

            lvUsers.ItemsSource = bank1.Klienci;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
