using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    interface IKarta
    {
        string NrKarty{ get; }
        int PIN { get; }
        DateTime DataWaznosci { get; }
        string Imie { get; }
        string Nazwisko { get; }
    }
}
