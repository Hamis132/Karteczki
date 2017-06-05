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
    class Transakcja : ITransakcja
    {
        public DateTime data { get; protected set; }

        public decimal kwota { get; protected set; }

        public bool udana { get; protected set; }

        public string nrKarty { get; protected set; }

        public Transakcja(decimal kwota, bool udana, string nrKarty)
        {
            this.kwota = kwota;
            this.udana = udana;
            this.nrKarty = nrKarty;
            data = DateTime.Now;
        }

        public override string ToString()
        {
            return "Nr karty: " + nrKarty + " kwota: " + kwota + " udana: " + udana + " Data: " + data;
        }
    }
}
