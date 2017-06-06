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
            if (transakcja != null)
            {
                transakcje.Add(transakcja);
                return true;
            }
            return false;
        }

        public List<ITransakcja> znajdzTransakcje(string NrKarty)
        {
            List<ITransakcja> trans = new List<ITransakcja>();
            foreach (ITransakcja transakcja in transakcje)
            {
                if (NrKarty == transakcja.nrKarty)
                {
                    trans.Add(transakcja);
                }
            }
            trans.Sort();
            return trans;
        }

        public List<ITransakcja> znajdzTransakcje(string NrKarty, DateTime rok)
        {
            List<ITransakcja> trans = new List<ITransakcja>();
            foreach (ITransakcja transakcja in transakcje)
            {
                if (NrKarty == transakcja.nrKarty && transakcja.data.Year == rok.Year)
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

        public void wyswietlTransakcje(List<ITransakcja> trans)
        {
            foreach (ITransakcja transakcja in trans)
            {
                Console.WriteLine(transakcja);
            }
        }

        public void Menu()
        {
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine("0 - wyjdz" + Environment.NewLine + "1 - Wyswietl wszystkie Transakcje" + Environment.NewLine + "2 - Znajdz transakcje");
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 0:
                        {
                            exit = 1;
                            break;
                        }
                    case 1:
                        {
                            wyswietlTransakcje(transakcje);
                            break;
                        }
                    case 2:
                        {
                            int exit2 = 0;
                            while(exit2 == 0)
                            {
                               
                                Console.WriteLine("0 - wyjdz" + Environment.NewLine + "1 - Znajdz transakcje po nr karty" + Environment.NewLine + "2 - Znajdz transakcje po nr karty i roku"+Environment.NewLine +"3-Znajdz transakcje po ty czy byla udana");
                                int j = int.Parse(Console.ReadLine());
                                switch(j)
                                {
                                    case 0:
                                        {
                                            exit2 = 1;
                                            break;
                                        }
                                    case 1:
                                        {
                                            string nrKarty = Console.ReadLine();
                                            wyswietlTransakcje(znajdzTransakcje(nrKarty));
                                            break;
                                        }
                                    case 2:
                                        {
                                            string nrKarty = Console.ReadLine();
                                            int rok = Int32.Parse(Console.ReadLine());
                                            DateTime data = new DateTime(rok);
                                            wyswietlTransakcje(znajdzTransakcje(nrKarty, data));
                                            break;
                                        }
                                    case 3:
                                        {
                                            bool czyUdana = bool.Parse(Console.ReadLine());
                                            wyswietlTransakcje(znajdzTransakcje(czyUdana));
                                            break;
                                        }
                                    default:
                                        {
                                            exit2 = 1;
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                }
            }

        }
    }
}
