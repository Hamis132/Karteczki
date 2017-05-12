using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    public abstract class Klient : IKlient
    {
        public List<Konto> konta{ get; set; } = new List<Konto>();

        public void dodajKonto(Konto konto)
        {
            throw new NotImplementedException();
        }

        public List<Konto> getKonta()
        {
            throw new NotImplementedException();
        }
    }
}
