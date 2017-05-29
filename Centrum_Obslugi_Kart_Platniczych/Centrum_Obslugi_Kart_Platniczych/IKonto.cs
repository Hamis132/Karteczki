using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
   public  interface IKonto
    {
        string nrKonta { get; }

        decimal saldo { get; }

        bool wplac(decimal kwota);

        bool wyplac(decimal kwota);
    }
}
