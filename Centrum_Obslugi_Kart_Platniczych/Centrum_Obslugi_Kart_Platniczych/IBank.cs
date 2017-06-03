using System;
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

        bool dodajKlienta(IKlient klient);

        IKonto znajdzKonto(string nrKonta);

        string stworzKonto(string PESEL);

        string stworzKarte(string nrKonta, int PIN);

       // string getNrKontaByNrKarty(string nrKarty);

        IKlient znajdzKlienta(string Pesel);

        List<IKlient> getKlienci();

        bool autoryzacja(string nrKarty, int PIN, decimal kwota);
    }
}
