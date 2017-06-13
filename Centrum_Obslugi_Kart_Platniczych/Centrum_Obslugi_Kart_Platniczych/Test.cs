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
    class Test
    {
        ICentrum centrum;
        IFirma PSS;
        IBank bank1 = new Bank("PKO");
        IBank bank2 = new Bank("Millenium");
        
        Osoba osoba1 = new Osoba("Paweł", "Cos", "124");
        Osoba osoba2 = new Osoba("Paweł", "Cos", "125");
        Osoba osoba3 = new Osoba("Paweł", "Cos", "126");
        Osoba osoba4 = new Osoba("Paweł", "Cos", "127");
        public string nrSklep; 

        public Test(ICentrum centrum)
        {
            this.centrum = centrum;
            PSS = new Sklep(centrum, "PSS", "XD");
            bank1.dodajKlienta((IKlient)PSS);
            nrSklep = bank1.stworzKontoFirmy("XD");
        }

        public bool Test1()
        {
            try
            {
                bank1.dodajKlienta(osoba1);
                bank2.dodajKlienta(osoba2);
                bank1.dodajKlienta(osoba3);
                bank2.dodajKlienta(osoba4);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Test2()
        {
            try
            {
                bank1.stworzKonto(osoba1.PESEL);
                bank2.stworzKonto(osoba2.PESEL);
                bank1.stworzKonto(osoba3.PESEL);
                Console.WriteLine(bank2.stworzKonto(osoba4.PESEL));
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            }

        public bool Test3()
        {
            try
            {
                bank1.znajdzKlienta("124");
                return true;
            }
            catch(KlientException ex)
            {
                return false;
            }
            catch(Exception ex )
            {
                return false;
            }
        }

        public bool Test4()
        {
            try
            {
                bank2.stworzKarteDebetowa("001000000001", 1234);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Test5()
        {
            if(!centrum.autoryzacja("0001000000010000", 1234, 12.2M, nrSklep))
            {
                return true;
            }
            return false;
        }

        public bool Test6()
        {
            if(bank2.znajdzKonto("001000000000").wplac(80.20M))
            {
                bank2.stworzKarteDebetowa("001000000000", 6452);
                return true;
            }
            return false;
        }

        public bool Test7()
        {
            if(centrum.autoryzacja("0001000000000000", 6452, 5.50M, nrSklep))
            {
                return true;
            }
            return false;
        }

        public bool Test8()
        {
            if (bank2.znajdzKonto("001000000000").saldo == 74.70M) { return true; }             //74,70
            return false;
        }

        public string Test9()
        {
            ITransakcja transakcja = centrum.historia.transakcje[1];
            return ((Transakcja)transakcja).ToString();

        }

        public bool testZapis()
        {
            
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fsHistoria = new FileStream("HistoriaT.dat", FileMode.Create);
            formatter.Serialize(fsHistoria, centrum.historia);
            fsHistoria.Close();

            FileStream fsBanki = new FileStream("BankiT.dat", FileMode.Create);
            formatter.Serialize(fsBanki, centrum.getBanki());
            fsBanki.Close();
            return true;
        }

        public bool TestOdczytu()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream fsBanki = new FileStream("BankiT.dat", FileMode.Open);
            List<IBank> banki = (List<IBank>)formatter.Deserialize(fsBanki);
            fsBanki.Close();
            return true;
        }
        public void wypiszWszystko()
        {
            foreach(IKlient klient in bank1.getKlienci())
            {
                Console.WriteLine("Imie:"+((Osoba)klient).imie+" Nazwisko:" + ((Osoba)klient).nazwisko+" PESEL:" + ((Osoba)klient).PESEL);
                foreach(IKonto konto in klient.getKonta())
                {
                    Console.WriteLine("NrKonta: " + konto.nrKonta);
                }
            }
            foreach (IKlient klient in bank2.getKlienci())
            {
                Console.WriteLine("Imie:" + ((Osoba)klient).imie + " Nazwisko:" + ((Osoba)klient).nazwisko + " PESEL:" + ((Osoba)klient).PESEL);
                Console.WriteLine("KONTA:");
                foreach (IKonto konto in klient.getKonta())
                {
                    Console.WriteLine("NrKonta: " + konto.nrKonta);
                    foreach(IKarta karta in konto.karty)
                    {
                        Console.WriteLine("nrKarty: "+karta.NrKarty+"   Data Waznosci: "+karta.DataWaznosci);
                    }
                }
            }
        }
    }
}
