using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Transakcja : ITransakcja
    {
        public DateTime data { get; protected set; }

        public decimal kwota { get; protected set; }

        public bool udana { get; protected set; }

        public string nrKonta { get; protected set; }

        public Transakcja(decimal kwota, bool udana, string nrKonta)
        {
                            //Do uzupełnienia !
        }
    }
}
