using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    public interface IKlient
    {
        List<Konto> konta { get; }

        void dodajKonto(Konto konto);

        List<Konto> getKonta();

    }

}
