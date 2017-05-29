using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Bank : IBank
    {
        public List<IKlient> klienci { get; protected set; } = new List<IKlient>();

        public bool dodajKlienta(IKlient klient)
        {
            if(klient != null)
            {
                klienci.Add(klient);
                return true;
            }
            return false;
        }

        public List<IKlient> getKlienci()
        {
            return klienci;
        }

    }
}
