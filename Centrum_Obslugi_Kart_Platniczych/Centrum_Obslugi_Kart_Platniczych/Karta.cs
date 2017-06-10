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
    class Karta : IKarta
    {
        public string NrKarty { get; }
        public int PIN { get; protected set; }
        public DateTime DataWaznosci { get; } = DateTime.Now;
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

        public override string ToString()
        {
            return Imie + " " + Nazwisko + "\n" + NrKarty + " Data waznosci: " + DataWaznosci+"\n";
        }
    }
}
