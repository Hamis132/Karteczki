using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Serializacja
    {
        /*
         using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
 
 
    [Serializable]
    public class Wydawnictwo
    {
        List<Autor> autorzy = new List<Autor>();
        List<Drukarnia> drukarnie = new List<Drukarnia>();
        List<Dokument> dokumenty = new List<Dokument>();
        List<Zlecenie> zleceniaOczekujace = new List<Zlecenie>();
 
 public void zapis()
        {
            BinaryFormatter formatter = new BinaryFormatter();
 
            FileStream fsAutorzy = new FileStream("Autorzy.dat", FileMode.Create);
            formatter.Serialize(fsAutorzy, autorzy);
            fsAutorzy.Close();
 
            FileStream fsDokumenty = new FileStream("Dokumenty.dat", FileMode.Create);
            formatter.Serialize(fsDokumenty, dokumenty);
            fsDokumenty.Close();
 
            FileStream fsZlecenia = new FileStream("ZleceniaOczekujace.dat", FileMode.Create);
            formatter.Serialize(fsZlecenia, zleceniaOczekujace);
            fsZlecenia.Close();
 
            FileStream fsDrukarnie = new FileStream("Drukarnie.dat", FileMode.Create);
            formatter.Serialize(fsDrukarnie, drukarnie);
            fsDrukarnie.Close();
 
 
        }
 
        public void odczyt()
        {
            BinaryFormatter formatter = new BinaryFormatter();
 
            FileStream fsAutorzy = new FileStream("Autorzy.dat", FileMode.Open);
            autorzy= (List<Autor>)formatter.Deserialize(fsAutorzy);
            fsAutorzy.Close();
 
            FileStream fsDokumenty = new FileStream("Dokumenty.dat", FileMode.Open);
            dokumenty = (List<Dokument>)formatter.Deserialize(fsDokumenty);
            fsDokumenty.Close();
 
            FileStream fsZlecenia = new FileStream("ZleceniaOczekujace.dat", FileMode.Open);
            zleceniaOczekujace = (List<Zlecenie>)formatter.Deserialize(fsZlecenia);
            fsZlecenia.Close();
 
            FileStream fsDrukarnie = new FileStream("Drukarnie.dat", FileMode.Open);
            drukarnie = (List<Drukarnia>)formatter.Deserialize(fsDrukarnie);
            fsDrukarnie.Close();
        }
 
 
    }
          
          */
    }
}
