using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class ZleKontoException : BankException
    {
        private string nrKonta;

        public ZleKontoException(string msg, string nrKonta) : base(msg) { this.nrKonta = nrKonta; }
    }
}
