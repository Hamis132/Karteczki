using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    interface IKonto
    {
        string nrKonta { get; }

        decimal saldo { get; }

        List<IKarta> karty { get; }

        bool dodajKarte(IKarta karta);

        bool wplac(decimal kwota);

        bool wyplac(decimal kwota);
    }
}
