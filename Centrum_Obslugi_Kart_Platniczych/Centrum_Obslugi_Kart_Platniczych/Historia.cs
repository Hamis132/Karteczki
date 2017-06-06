using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace Centrum_Obslugi_Kart_Platniczych
{
    [Serializable]
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

        public List<ITransakcja> znajdzTransakcje(string NrKarty)
        {
            List<ITransakcja> trans = new List<ITransakcja>();
            foreach(ITransakcja transakcja in transakcje)
            {
                if(NrKarty == transakcja.nrKarty)
                {
                    trans.Add(transakcja);
                }
            }
            trans.Sort();
            return trans;
        }

        public List<ITransakcja> znajdzTransakcje(string NrKarty,DateTime rok)
        {
            List<ITransakcja> trans = new List<ITransakcja>();
            foreach (ITransakcja transakcja in transakcje)
            {
                if(NrKarty == transakcja.nrKarty && transakcja.data.Year == rok.Year)
                {
                    trans.Add(transakcja);
                }
            }
            trans.Sort();
            return trans;
        }

        public List<ITransakcja> znajdzTransakcje(bool czyUdana)
        {
            List<ITransakcja> trans = new List<ITransakcja>();
            foreach (ITransakcja transakcja in transakcje)
            {
                if (czyUdana == transakcja.udana)
                {
                    trans.Add(transakcja);
                }
            }
            trans.Sort();
            return trans;
        }
    }
}
