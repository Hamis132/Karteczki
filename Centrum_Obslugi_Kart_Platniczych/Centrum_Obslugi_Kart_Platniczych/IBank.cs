﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    interface IBank
    {
        List<IKlient> klienci { get; }

        string nazwa { get; }

        int nr { get; }

        void setNr(int nr);

        bool dodajKlienta(IKlient klient);

        IKonto znajdzKonto(string nrKonta);

        string stworzKontoFirmy(string KRS);

        string stworzKontoFirmy(int index);

        IFirma znajdzFirme(string KRS);

        void wypiszKlientow();

        void wyswietlKarty();

        IKlient znajdzKlientaByNrKonta(string nrKonta);

        string stworzKonto(string PESEL);

        string stworzKonto(int index);

        string stworzKarteKredytowa(string nrKonta, int PIN);

        string stworzKarteBankomatowa(string nrKonta, int PIN);

        string stworzKarteDebetowa(string nrKonta, int PIN);

        IKlient znajdzKlienta(string identyfikator);

        List<IKlient> getKlienci();

        bool autoryzacja(string nrKarty, int PIN, decimal kwota, string NrKonta, IBank bankFirmy);

        bool usunKonto(string nrKonta);

        bool usunKlienta(int index);
    }
}
