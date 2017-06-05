﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace Centrum_Obslugi_Kart_Platniczych
{
    [Serializable]
    class Bank : IBank
    {
        public List<IKlient> klienci { get; protected set; } = new List<IKlient>();

        public string nazwa { get; protected set; }

        public int nr { get; protected set; } = 0;

        public static int licznikBankow { get; protected set; } = 0;      //licznik bankow

        public int licznikKont { get; protected set; } = 0;

        public Bank(string nazwa)
        {
            if(nazwa != null)
            {
                this.nazwa = nazwa;
                nr = licznikBankow;
                licznikBankow++;
                licznikKont = 0;
                Centrum.banki.Add(this);
            }
        }
            
        public bool autoryzacja(string nrKarty, int PIN, decimal kwota, string nrKonta, IBank bankFirmy)
        {
            IKarta karta = znajdzKarte(nrKarty);
            IKonto konto = znajdzKontoByNrKarty(nrKarty);
            if(PIN == ((Karta)karta).PIN)
            {
                if(karta is KartaKredytowa)
                {
                    if(decyzjaTransakcji() && ((KartaKredytowa)karta).saldo - kwota >=0)
                    {
                        ((KartaKredytowa)karta).wyplac(kwota);
                        bankFirmy.znajdzKonto(nrKonta).wplac(kwota);
                        return true;
                    }
                }
                if(decyzjaTransakcji() && konto.saldo - kwota >= 0)
                {
                    konto.wyplac(kwota);
                    bankFirmy.znajdzKonto(nrKonta).wplac(kwota);
                    return true;
                }
                return false;               
            }
            return false;   //wyjatek nie poprawny pin
            
        }

        private bool decyzjaTransakcji()
        {
            var rnd = new Random();
            System.Threading.Thread.Sleep(1000);
            if(rnd.Next(0,100) < 90)
            {
                return true;
            }
            return false;
        }               //Prawdopodobienstwo odrzucenia 1/10

        public bool dodajKlienta(IKlient klient)
        {
            if(klient != null)
            {
                klienci.Add(klient);
                return true;
            }
            return false;       
        }

        public string stworzKonto(string PESEL)
        {
            var klient = znajdzKlienta(PESEL);
            string nrKonta = this.stworzNrKonta() ;
            IKonto konto = new Konto(nrKonta);
            klient.dodajKonto(konto);
            licznikKont++;
            return nrKonta;
        }  //Metoda tworzy konto w tym banku i przydziela nr Konta

        public string stworzKontoFirmy(string KRS)
        {
            var firma = znajdzFirme(KRS);
            string nrKonta = this.stworzNrKonta();
            IKonto konto = new Konto(nrKonta);
            firma.dodajKonto(konto);
            licznikKont++;
            return nrKonta;
        }

        public IFirma znajdzFirme(string KRS)
        {
            foreach(IKlient firma in klienci)
            {
                if(((IFirma)firma).KRS == KRS)
                {
                    return (IFirma)firma;
                }
            }
            throw new Exception("Nie ma takiej firmy");
        }

        public IKarta znajdzKarte(string nrKarty)
        {
            foreach (IKlient klient in klienci)
            {
                if (klient is Osoba)
                {
                    foreach (IKonto konto in klient.konta)
                    {
                        foreach (IKarta karteczka in konto.karty)
                        {
                            if (karteczka.NrKarty == nrKarty)
                            {
                                return karteczka;
                            }

                        }
                    }
                }
            }
            return null;                //Wyjątek brak takiej karty w bazie
        }

        public IKonto znajdzKontoByNrKarty(string nrKarty)
        {
            foreach (IKlient klient in klienci)
            {
                foreach (IKonto konto in klient.konta)
                {
                    foreach (IKarta karteczka in konto.karty)
                    {
                        if (karteczka.NrKarty == nrKarty)
                        {
                            return konto;
                        }

                    }
                }
            }
            return null;                //Wyjatek ten nr karty nie pasuje do zadnego konta w tym Banku
        }

        private string stworzNrKonta()          //zakładamy ze nrKonta bedzie zawsze 12 cyfrowy
        {
                
                string nrKonta = "";
                while((nrKonta + nr).Length !=3)
                {
                    nrKonta += "0";
                }
                nrKonta += nr;
                while((nrKonta + licznikKont).Length !=12)
                {
                    nrKonta += "0";
                }
                nrKonta += licznikKont;
                return nrKonta;
        }

        public List<IKlient> getKlienci()
        {
            return klienci;
        }

        public IKlient znajdzKlienta(string identyfikator)   //Szuka klienta po identyfikatorze
        {
            
            foreach(IKlient customer in klienci)
            {
                if(customer is IFirma)
                {
                    if(identyfikator == ((IFirma)customer).KRS)
                    {
                        return customer;
                    }
                }
                else
                {
                    if(identyfikator == ((Osoba)customer).PESEL)
                    {
                        return customer;
                    }
                }
            }

            throw new Exception("Nie ma takiego klienta w banku");  //do zmiany oczywiscie
        }

        public IKonto znajdzKonto(string nrKonta)
        {
            foreach(IKlient klient in klienci)
            {
                foreach(IKonto konto in klient.konta)
                {
                    if(nrKonta == konto.nrKonta) { return konto; }
                }
            }
            throw new Exception("Nie ma takiego konta");
        }

        public IKlient znajdzKlientaByNrKonta(string nrKonta)
        {
            foreach(IKlient klient in klienci)
            {
                foreach(IKonto konto in klient.getKonta())
                {
                    if(nrKonta == konto.nrKonta)
                    {
                        return klient;
                    }
                }
            }
            throw new Exception("Nie ma takiego klienta w tym banku");
        }

        public string stworzKarte(string nrKonta, int PIN)
        {
            IKlient klient = znajdzKlientaByNrKonta(nrKonta);
            IKarta karta = new Karta(((Osoba)klient).imie, ((Osoba)klient).nazwisko, PIN, this.stworzNrKarty(nrKonta));
            this.znajdzKonto(nrKonta).dodajKarte(karta);
            return karta.NrKarty;
        }       

                                                           //    NP.    0001 0000 0002 0005
        private string stworzNrKarty(string nrKonta)      // Postac nrKarty:    NrBanku-4 cyfry NrKonta-8 cyfr, LicznikKart - 4cyfry
        {
            string nrKarty = "";
            
            while ((nrKarty + nr).Length != 4)
            {
                nrKarty += "0";
            }
            nrKarty += nr;
            int konto = Int32.Parse(nrKonta.Substring(nrKonta.Length-4, 4));
            while ((nrKarty + konto).Length != 12)
            {
                nrKarty += "0";
            }
            nrKarty += konto;
            int licznikKarty = znajdzKonto(nrKonta).licznikKart;
            while ((nrKarty + licznikKarty).Length !=16)
            {
                nrKarty += "0";
            }
            nrKarty += licznikKarty;

            return nrKarty;
        }

        public bool usunKonto(string nrKonta)
        {
            return znajdzKlientaByNrKonta(nrKonta).konta.Remove(znajdzKonto(nrKonta));
        }
    }
}
