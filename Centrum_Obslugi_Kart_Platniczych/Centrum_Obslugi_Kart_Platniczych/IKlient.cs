using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
     interface IKlient
    {
        List<IKonto> konta { get; }

        bool dodajKonto(IKonto konto);

        List<IKonto> getKonta();

    }

}
