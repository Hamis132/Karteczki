using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    interface ICentrum
    {

        Historia historia { get; }

        List<IFirma> firmy { get; }

        bool autoryzacja(string NrKarty, int PIN, decimal kwota, string nrKonta);

        IBank znajdzBank(string nazwa);

        bool dodajBanki(List<IBank> bank);

        bool dodajBank(IBank bank);

        bool dodajHistorie(Historia historia);

        bool usunBank(string nazwa);

        List<IBank> getBanki();

    }
}
