using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;


namespace Centrum_Obslugi_Kart_Platniczych
{
    [Serializable]
    class Serializacja
    {
        public bool Zapisz(ICentrum centrum)
        {

            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fsHistoria = new FileStream("Historia.dat", FileMode.Create);
            formatter.Serialize(fsHistoria, centrum.historia);
            fsHistoria.Close();

            FileStream fsBanki = new FileStream("Banki.dat", FileMode.Create);
            formatter.Serialize(fsBanki, centrum.getBanki());
            fsBanki.Close();
            return true;
        }

        public bool TestOdczytu(ICentrum centrum)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fsBanki = new FileStream("Banki.dat", FileMode.Open);
            List<IBank> banki = (List<IBank>)formatter.Deserialize(fsBanki);
            fsBanki.Close();

            FileStream fsHistoria = new FileStream("Historia.dat", FileMode.Open);
            Historia historia = (Historia)formatter.Deserialize(fsHistoria);
            fsHistoria.Close();

            centrum.dodajBanki(banki);
            centrum.dodajHistorie(historia);
            return true;
        }
    }
}
