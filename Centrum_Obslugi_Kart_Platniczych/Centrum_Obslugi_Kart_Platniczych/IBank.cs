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

        bool dodajKlienta(IKlient klient);

        List<IKlient> getKlienci();

        bool decyzjaTransakcji();

        bool autoryzacja(string NrKarty, int PIN, decimal kwota);
    }
}
