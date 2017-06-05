using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class KartaException : KontoException
    {
        public KartaException(string msg) : base(msg)
        {

        }
    }
}
