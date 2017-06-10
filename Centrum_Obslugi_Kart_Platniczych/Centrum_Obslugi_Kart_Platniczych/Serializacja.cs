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
            
            FileStream fsFirmy = new FileStream("Firmy.dat", FileMode.Create);
            formatter.Serialize(fsFirmy, centrum.getFirmy());
            fsFirmy.Close();

            FileStream fsBanki = new FileStream("Banki.dat", FileMode.Create);
            formatter.Serialize(fsBanki, centrum.getBanki());
            fsBanki.Close();
            return true;
        }

        public bool OdczytajDane(ICentrum centrum)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fsBanki = new FileStream("Banki.dat", FileMode.Open);
            List<IBank> banki = (List<IBank>)formatter.Deserialize(fsBanki);
            fsBanki.Close();

            FileStream fsFirmy = new FileStream("Firmy.dat", FileMode.Open);
            List<IFirma> firmy = (List<IFirma>)formatter.Deserialize(fsFirmy);
            foreach(IFirma firma in firmy)
            {
                firma.updateCentrum(centrum);
            }
            fsFirmy.Close();

          FileStream fsHistoria = new FileStream("Historia.dat", FileMode.Open);
            Historia historia = (Historia)formatter.Deserialize(fsHistoria);
            fsHistoria.Close();

            centrum.dodajFirmy(firmy);
            centrum.dodajBanki(banki);
            centrum.dodajHistorie(historia);
            return true;
        }
    }
}
