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

        public Historia historia { get; protected set; }

        public List<IFirma> firmy { get; protected set; } = new List<IFirma>();

        public Centrum()
        {
            historia = new Historia();
        }
        
        public bool dodajHistorie(Historia historia)
        {
            this.historia = historia;
            return true;
        }

        public List<IBank> getBanki()
        {
            return banki;
        }

        public bool dodajBanki(List<IBank> bank)
        {
            foreach(IBank _bank in bank)
            {
                if(!czyIstnieje(_bank))
                {
                    banki.Add(_bank);
                }
            }
            return true;
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
            throw new Exception("Nie ma takiego banku!");  //Do zmiany 
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
            bool czyUdana= bankKlienta.autoryzacja(NrKarty, PIN, kwota, nrKonta, bankFirmy);
            ITransakcja transakcja = new Transakcja(kwota, czyUdana, NrKarty);
            historia.addTransakcja(transakcja);
            return czyUdana;
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
