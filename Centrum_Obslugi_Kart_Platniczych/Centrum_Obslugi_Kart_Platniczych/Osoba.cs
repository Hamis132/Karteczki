using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Osoba : Klient
    {
        public string imie { get; protected set; }

        public string nazwisko { get; protected set; }

        public string PESEL { get; protected set; }

        public Osoba(string imie, string nazwisko, string PESEL)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.PESEL = PESEL;
        }
    }
}
