using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Bank
    {
        public string nazwa;
        public string id; //ciag 6 liczb zapisany w kodzie karty, reprezentujacy bank
        private List<Karta> karty;
        private List<Klient> klienci;

        public Bank(string nazwa, string id)
        {
            this.nazwa = nazwa;
            this.id = id;
            this.karty = new List<Karta>();
            this.klienci = new List<Klient>();
        }

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
}
