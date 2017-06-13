using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    [Serializable]
    class Centrum : ICentrum
    {
        public static List<IBank> banki { get; protected set; } = new List<IBank>();

        public Historia historia { get; protected set; } = new Historia();

        public List<IFirma> firmy { get;protected set; } = new List<IFirma>();

        public Centrum()
        {
        }

        public List<IFirma> getFirmy()
        {
            return firmy;
        }

        public bool dodajFirmy(List<IFirma> firmy)
        {
            this.firmy=firmy;
            return true;
        }

        public void wyswietlFirmy()
        {
            int i = 0;
            foreach(IFirma firma in firmy)
            {
                Console.WriteLine("{0} :{1}",i++,firma.Wypisz());
            }
        }

        public void wyswietlBanki()
        {
            int i = 0;
            foreach(IBank bank in banki)
            {
                Console.WriteLine("{0} :{1}",i++,bank.nazwa);
            }
        }
        
        public bool dodajHistorie(Historia historia)
        {
            this.historia = historia;
            return true;
        }

        public bool usunBank(IBank bank)
        {
            return banki.Remove(bank);
        }

        public bool usunFirme(IFirma firma)
        {
            return firmy.Remove(firma);
        }

        public List<IBank> getBanki()
        {
            return banki;
        }

        public bool dodajBanki(List<IBank> bank)
        {
            int nr = 0;
            foreach(IBank _bank in bank)
            {
                if(!czyIstnieje(_bank))
                {
                    _bank.setNr(nr);
                    banki.Add(_bank);
                    nr++;
                }
            }
            return true;
        }

        public IFirma znajdzFirme(string KRS)
        {
            foreach(IFirma firma in firmy)
            {
                if(firma.KRS == KRS)
                {
                    return firma;
                }
            }
            throw new Exception("Nie ma takiej Firmy");
        }

        public bool usunFirme(string KRS)
        {
            try
            {
                return firmy.Remove(znajdzFirme(KRS));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IBank znajdzBank(string nazwa)
        {
            foreach(IBank bank in banki)
            {
                if(bank.nazwa == nazwa)
                {
                    return bank;
                }
            }

            throw new BankException("Nie ma takiego banku!");
        }

        private bool czyIstnieje(IBank bank)
        {
            foreach(IBank _bank in banki)
            {
                if(bank == _bank)
                {
                    return true;
                }
            }
            return false;
        }

        public bool autoryzacja(string NrKarty, int PIN, decimal kwota, string nrKonta)
        {
            
                int index = getIndexBanku(NrKarty);
                IBank bankKlienta = banki[index];
                IBank bankFirmy = banki[getIndexBankuFirmy(nrKonta)];
                bool czyUdana = bankKlienta.autoryzacja(NrKarty, PIN, kwota, nrKonta, bankFirmy);
                updateSaldo(bankFirmy, nrKonta);
                ITransakcja transakcja = new Transakcja(kwota, czyUdana, NrKarty, nrKonta);
                historia.addTransakcja(transakcja);                //UWAGA!!!
                return czyUdana;
        }

        private void updateSaldo(IBank bank, string nrKonta)
        {
            foreach(IKlient klient in bank.klienci)
            {
                if(klient is IFirma)
                {
                    foreach(IKonto konto in klient.konta)
                    {
                        if(nrKonta == konto.nrKonta)
                        {
                            foreach(IFirma firma in firmy)
                            {
                                if(((IFirma)klient).KRS == firma.KRS)
                                {
                                    Konto _konto = (Konto)firma.znajdzKonto(nrKonta);
                                    _konto.updateSaldo(konto.saldo);
                                }
                            }
                        }
                    }
                }
            }
        }

        private int getIndexBanku(string NrKarty)
        {
            int index = Int32.Parse(NrKarty.Substring(0, 4));
            return index;
        }

        private int getIndexBankuFirmy(string nrKonta)
        {
            int index = Int32.Parse(nrKonta.Substring(0, 3));
            return index;
        }

        public bool dodajBank(IBank bank)
        {
            if(czyIstnieje(bank))
            {
                banki.Add(bank);
                return true;
            }
            return false;           //Powinien byc wyjatek
        }

        public bool usunBank(string nazwa)
        {
            return banki.Remove(znajdzBank(nazwa)) ;
        }
    }
}
