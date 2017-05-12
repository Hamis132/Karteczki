using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    public class Konto : IKonto
    {
        public string nrKonta { get; protected set; }


        public double saldo { get; protected set; }


        public void wplac(double kwota)
        {
            throw new NotImplementedException();
        }

        public void wyplac(double kwota)
        {
            throw new NotImplementedException();
        }
    }
}
