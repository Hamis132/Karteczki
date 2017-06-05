using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class KlientException : Exception
    {
        public KlientException(string msg) : base (msg)
        {

        }
        public override string ToString()
        {
            return Message;
        }
    }
}
