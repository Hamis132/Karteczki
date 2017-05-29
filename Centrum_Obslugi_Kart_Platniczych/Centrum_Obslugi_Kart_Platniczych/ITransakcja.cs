using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    interface ITransakcja
    {
        DateTime data { get; }

        decimal kwota { get; }

        bool udana { get; }

        string nrKonta { get; }

    }
}
