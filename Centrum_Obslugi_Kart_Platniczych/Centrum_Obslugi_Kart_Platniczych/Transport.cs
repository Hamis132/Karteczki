﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Transport : IFirma
    { 
   public ICentrum centrum { get; protected set; }

    public List<IKonto> konta { get; protected set; }

    public Transport(ICentrum centrum, IKonto konto)
    {
        this.centrum = centrum;
        konta.Add(konto);
    }

    public bool dodajKonto(IKonto konto)
    {
        if (konto != null)
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

        public bool autorisationRequest(string NrKarty, int PIN, decimal kwota)
        {
            throw new NotImplementedException();
        }
    }
}
