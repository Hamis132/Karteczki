using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    interface IBank
    {
        List<Klient> klienci { get; }

        void dodajKlienta(IKlient klient);

        List<Klient> getKlienci();


    }
}
