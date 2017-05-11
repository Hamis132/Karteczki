using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    public class Bank : IBank
    {
        public List<Klient> klienci { get; protected set; } = new List<Klient>();

        public void dodajKlienta(IKlient klient)
        {
            throw new NotImplementedException();
        }

        public List<Klient> getKlienci()
        {
            throw new NotImplementedException();
        }
    }
}
