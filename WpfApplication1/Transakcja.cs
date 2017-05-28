using System;

namespace WpfApplication1
{
    public class Transakcja
    {
        private double kwota;
        private Firma odbiorca;
        private Karta karta;
        private DateTime data;

        public Transakcja(double kwota, Firma odbiorca, Karta karta, DateTime data)
        {
            this.kwota = kwota;
            this.odbiorca = odbiorca;
            this.karta = karta;
            this.data = data;
        }
    }
}