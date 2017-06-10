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
    class KartaBankomatowa : Karta
    {
        public KartaBankomatowa(string imie, string nazwisko, int PIN, string nrKarty) : base (imie,nazwisko,PIN, nrKarty)
        { }
    }
}
