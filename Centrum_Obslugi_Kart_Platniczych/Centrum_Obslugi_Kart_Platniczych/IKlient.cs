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

        List<IKonto> getKonta();

        bool dodajKonto(IKonto konto);

        IKonto znajdzKonto(string nrKonta);

    }

}
