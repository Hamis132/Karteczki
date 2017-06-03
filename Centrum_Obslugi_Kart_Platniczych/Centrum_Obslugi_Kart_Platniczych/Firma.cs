using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
   abstract class Firma : Klient, IFirma
    {
        public ICentrum centrum { get; protected set; }

        public bool autorisationRequest(string NrKarty, int PIN, decimal kwota)
        {
            return centrum.autoryzacja(NrKarty, PIN, kwota);
        }
    }
}
