using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Historia
    {
        public List<ITransakcja> transakcje { get; protected set; }

        public Historia(ITransakcja transakcja)
        {
            transakcje = new List<ITransakcja>();
            transakcje.Add(transakcja);
        }

        public Historia()
        {
            transakcje = new List<ITransakcja>();
        }

        public bool addTransakcja(ITransakcja transakcja)
        {
            if(transakcja != null)
            {
                transakcje.Add(transakcja);
                return true;
            }
            return false;
        }
    }
}
