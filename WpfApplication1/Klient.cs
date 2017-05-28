using System;
using System.Collections.Generic;

namespace WpfApplication1
{
    public class Klient
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        private List<Karta> karty;

        public Klient(string imie, string nazwisko)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.karty = new List<Karta>();
        }

        public void dodajKarte(Karta karta)
        {
            this.karty.Add(karta);
        }
    }
}