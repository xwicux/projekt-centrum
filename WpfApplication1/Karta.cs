using System;

namespace WpfApplication1
{
    public class Karta
    {
        public string numer_karty;
        public Bank wydana_przez;
        private DateTime termin_wygasniecia;

        public Karta(string numer_karty, Bank wydana_przez)
        {
            DateTime today = DateTime.Now;

            this.numer_karty = numer_karty;
            this.wydana_przez = wydana_przez;
            this.termin_wygasniecia = today.AddMonths(6);
        }

        public DateTime Termin_wygasniecia
        {
            get
            {
                return termin_wygasniecia;
            }

            set
            {
                termin_wygasniecia = value;
            }
        }

        private int getWaznosc()
        {
            DateTime today = DateTime.Now;
            TimeSpan pozostaleDni = termin_wygasniecia - today;

            return (int)pozostaleDni.TotalDays;
        }
    }
    public class KartaKredytowa : Karta
    {
        public int limitKredytowy;
        //TODO: dokończyć to cholerstwo; dodać limit kredytowy?
        public KartaKredytowa(string numer_karty, Bank wydana_przez) : base(numer_karty, wydana_przez)
        {
        }
    }
    public class KartaDebetowa : Karta
    {
        //TODO: dokończyć to cholerstwo; dodać limit debetu, stan debetu?
        public KartaDebetowa(string numer_karty, Bank wydana_przez) : base(numer_karty, wydana_przez)
        {
        }
    }
    public class KartaBankomatowa : Karta
    {
        //TODO: que?
        public KartaBankomatowa(string numer_karty, Bank wydana_przez) : base(numer_karty, wydana_przez)
        {
        }
    }
}