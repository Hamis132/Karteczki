using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Centrum_Obslugi_Kart_Platniczych
{
    [Serializable]
    class Konto : IKonto
    {
       
        public string nrKonta { get; }

        public int licznikKart { get; protected set; } = 0;

        public List<IKarta> karty { get; protected set; } = new List<IKarta>();

        public bool dodajKarte(IKarta karta)
        {
            karty.Add(karta);
            licznikKart++;
            return true;
        }

        public decimal saldo { get; set; } = 0.00M;

        public Konto() { }

        public Konto(string nrKonta)
        {
            this.nrKonta = nrKonta;
        }

        public bool wplac(decimal kwota)
        {
            saldo += kwota;
            return true;
        }

        public bool wyplac(decimal kwota)
        {
            if(saldo - kwota >=0.00M)
            {
                saldo -= kwota;
                return true;
            }
            return false;
        }
    }
}
