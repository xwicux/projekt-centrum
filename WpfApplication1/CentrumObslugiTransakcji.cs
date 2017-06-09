using System;
using System.Collections.Generic;

namespace WpfApplication1
{
    public class CentrumObslugiTransakcji
    {
        public string nazwa;
        private List<Firma> firmy; //klienci centrum = firmy
        private List<Bank> banki;

        private Dictionary<string, Bank> idBank = new Dictionary<string, Bank>();
        
        public CentrumObslugiTransakcji(string nazwa)
        {
            this.nazwa = nazwa;
            this.firmy = new List<Firma>();
            this.banki = new List<Bank>();
        }

        public bool zrealizujPotwierdzenie(Karta karta, double kwota, Firma firma)
        {
            //dokonaj walidacji karty
            Bank bank = this.wyszukajBankPoId(karta);
            Transakcja transakcja = new Transakcja(kwota, firma, karta, DateTime.Now);
            

            bool wynikAutoryzacji = bank.autoryzacjaTransakcji(transakcja);
            this.zapiszDoArchiwum(transakcja, wynikAutoryzacji);

            return wynikAutoryzacji;
        }

        private void zapiszDoArchiwum(Transakcja transakcja, bool wynikAutoryzacji)
        {
            Console.WriteLine(transakcja.ToString(), wynikAutoryzacji.ToString());
        }

        private Bank wyszukajBankPoId(Karta karta)
        {
            /*
             * Numer karty kredytowej to 16 cyfr zapisanych w 4 blokach po 4 cyfry. Co się ukrywa pod tymi cyframi?

                Pierwsza cyfra oznacza organizację, która wydała tę kartę. Może ona wskazywać na linie lotnicze, korporacje paliwowe, telekomunikacyjne, 
                handel oraz banki. Jeśli pierwszą cyfrą będzie 4 lub 5 wtedy oznacza to, że wystawcą karty jest bank.
                6 pierwszych cyfr oznacza organizację, która te kartę wydała lub ją autoryzuje.
                11 kolejnych cyfr oznacza indywidualny numer klienta.
                Ostatnia 16 cyfra oznacza cyfrę kontrolną.
            */
            string id = karta.numer_karty.Substring(0, 6);
            Bank bank;
            idBank.TryGetValue(id, out bank);
            //powinno działać hehe
            return bank;
        }

        public void dodajBank(Bank bank)
        {
            banki.Add(bank);
            idBank.Add(bank.id, bank);
        }
        public void dodajFirme(Firma firma)
        {
            this.firmy.Add(firma);
        }
        public void usunBank(Bank bank)
        {
            this.banki.Remove(bank);
        }
        public void usunFirme(Firma firma)
        {
            this.firmy.Remove(firma);
        }
    }
}