using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class BankException : Exception
    {
        public BankException(string msg) : base(msg)
        {

        }
        
        public BankException() { }
    }
}
