using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Centrum_Obslugi_Kart_Platniczych
{
    
    class Konto : IKonto
    {
       
        public string nrKonta { get; }

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
