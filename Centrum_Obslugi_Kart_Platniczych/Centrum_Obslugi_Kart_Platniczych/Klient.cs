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
    abstract class Klient : IKlient
    {
        public List<IKonto> konta{ get; protected set; } = new List<IKonto>();
    
        public bool dodajKonto(IKonto konto)
        {
            if(konto != null)
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

        public void wypiszKonta()
        {
            foreach(IKonto konto in konta)
            {
                Console.WriteLine(konto.nrKonta);
            }
        }

        public IKonto znajdzKonto(string nrKonta)
        {
            foreach(IKonto konto in konta)
            {
                if(konto.nrKonta == nrKonta)
                {
                    return konto;
                }
            }
            throw new Exception("Nie ma takiego konta");
        }
    }
}
