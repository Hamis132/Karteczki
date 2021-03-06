﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    interface IFirma : IKlient
    {
        ICentrum centrum { get; }

        string nazwa { get; }

        string KRS { get; }

        bool autorisationRequest(string NrKarty, int PIN, decimal kwota, string nrKonta);

        void updateCentrum(ICentrum centrum);

    }
}
