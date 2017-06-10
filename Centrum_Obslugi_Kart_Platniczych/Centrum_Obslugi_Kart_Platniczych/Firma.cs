using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Centrum_Obslugi_Kart_Platniczych
{
    [Serializable]
   abstract class Firma : Klient, IFirma
    {
        public ICentrum centrum { get; protected set; }

        public string nazwa { get; protected set; }

        public string KRS { get; protected set; }

        public Firma(ICentrum centrum, string nazwa, string KRS)
        {
            this.centrum = centrum;
            this.nazwa = nazwa;
            this.KRS = KRS;
            this.centrum.firmy.Add(this);
            
        }

        public void updateCentrum(ICentrum centrum)
        {
            this.centrum = centrum;
        }

        public bool autorisationRequest(string NrKarty, int PIN, decimal kwota, string nrKonta)
        {
            return centrum.autoryzacja(NrKarty, PIN, kwota, nrKonta);
        }

        public override string ToString()
        {
            return nazwa + " KRS: " + KRS +"\n"+"Liczba kont: "+konta.Count;
        }
    }
}
