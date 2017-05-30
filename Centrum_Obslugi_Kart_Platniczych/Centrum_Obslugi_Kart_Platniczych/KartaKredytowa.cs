using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class KartaKredytowa : Karta
    {
        decimal Saldo = 2000.00M;
        public KartaKredytowa(string imie, string nazwisko, int PIN, string nrKarty) : base (imie,nazwisko,PIN, nrKarty)
        { }

    }
}
