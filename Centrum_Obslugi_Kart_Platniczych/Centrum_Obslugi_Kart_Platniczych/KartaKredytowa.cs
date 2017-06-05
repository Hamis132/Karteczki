using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class KartaKredytowa : Karta
    {
        public decimal saldo { get; protected set; } = 2000.00M;

        public bool wyplac(decimal kwota)
        {
            if(kwota - saldo <=0)
            {
                saldo -= kwota;
                return true;
            }
            else
            {
                return false;           //wyjatek
            }
        }

        public KartaKredytowa(string imie, string nazwisko, int PIN, string nrKarty) : base (imie,nazwisko,PIN, nrKarty)
        {

        }

    }
}
