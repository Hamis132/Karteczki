using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    interface ICentrum
    { 
        Historia historia { get; }
        bool autoryzacja(string NrKarty, int PIN, decimal kwota);
        List<IBank> getBanki();

    }
}
