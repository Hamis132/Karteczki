using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Centrum : ICentrum
    {
        public List<IBank> banki { get; }

        public bool autoryzacja(string NrKarty, int PIN, decimal kwota)
        {
            string bank = NrKarty;

            throw new NotImplementedException();
        }
    }
}
