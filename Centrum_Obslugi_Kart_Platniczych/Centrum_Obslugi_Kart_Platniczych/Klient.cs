using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    abstract class Klient : IKlient
    {
        public List<IKonto> konta{ get; protected set; } = new List<IKonto>();

        public bool dodajKonto(IKonto konto)
        {
            if(konto != null)
            {
                konta.Add(konto);
                return true;
            }
            return false;
        }

        public List<IKonto> getKonta()
        {
            return konta;
        }
    }
}
