using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Test
    {
        public bool Test1()
        {
            Bank PKO = new Bank();
            var ziomek = new Osoba("Kurde", "Ziom", "891264003210");
            IKonto k1 = new Konto("123");
            IKarta karteczka = new Karta(ziomek.imie, ziomek.nazwisko, 123, "321");
            ziomek.dodajKonto(k1);
            k1.dodajKarte(karteczka);
            k1.wplac(500.20M);
            PKO.dodajKlienta(ziomek);
            return PKO.autoryzacja(karteczka, 123, 12.20M);
            
        }
    }
}
