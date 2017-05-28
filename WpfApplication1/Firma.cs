namespace WpfApplication1
{
    public class Firma
    {
        public string nazwa;
        public string rodzaj;
        public CentrumObslugiTransakcji centrum;

        public Firma(string nazwa, string rodzaj)
        {
            this.nazwa = nazwa;
            this.rodzaj = rodzaj;
        }

        public bool wyslijZadaniePotwierdzeniaTransakcji(Karta karta, double kwota)
        {
            return centrum.zrealizujPotwierdzenie(karta, kwota, this); //this odpowiada tutaj całemu obiektowi firmy
        }

    }
}