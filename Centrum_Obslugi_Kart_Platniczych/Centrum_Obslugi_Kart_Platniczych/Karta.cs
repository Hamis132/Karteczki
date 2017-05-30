using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Karta : IKarta
    {
        public string NrKarty { get; }
        protected int PIN { get; set; }
        public DateTime DataWaznosci { get; } 
        public string Imie { get; }
        public string Nazwisko { get; }
        public Karta(string Imie, string Nazwisko, int PIN, string NrKarty)
        {
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            DataWaznosci.AddYears(3);
            this.PIN = PIN;
            this.NrKarty = NrKarty;
        }
    }
}
