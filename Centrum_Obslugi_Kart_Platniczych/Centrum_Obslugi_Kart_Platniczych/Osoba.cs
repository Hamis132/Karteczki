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
