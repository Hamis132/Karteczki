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

        public List<IBank> getBanki()
        {
            return banki;
        }

        public bool autoryzacja(string NrKarty, int PIN, decimal kwota)
        {
            int index = getIndexBanku(NrKarty);
            IBank bank = banki[index];
            bool czyUdana= bank.autoryzacja(NrKarty, PIN, kwota);
            ITransakcja transakcja = new Transakcja(kwota, czyUdana, NrKarty);
            historia.addTransakcja(transakcja);
            return czyUdana;
        }

        private int getIndexBanku(string NrKarty)
        {
            int index = Int32.Parse(NrKarty.Substring(0, 4));
            return index;
        }
    }
}
