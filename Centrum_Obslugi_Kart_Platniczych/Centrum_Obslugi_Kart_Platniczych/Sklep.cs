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
    class Sklep : Firma
    {
        public Sklep(ICentrum centrum, string nazwa, string KRS) : base(centrum,nazwa,KRS)
        {

        }
    }
}
