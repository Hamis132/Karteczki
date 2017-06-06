using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Program
    {
        static void test()
        {
            ICentrum centrum = new Centrum();
            var test = new Test(centrum);
            Console.WriteLine("TESTY:");
            Console.WriteLine(test.Test1());
            Console.WriteLine(test.Test2());
            Console.WriteLine(test.Test3());
            Console.WriteLine(test.Test4());
            Console.WriteLine(test.Test5());
            Console.WriteLine(test.Test6());
            Console.WriteLine(test.Test7());
            Console.WriteLine(test.Test8());
            Console.WriteLine(test.Test9());
            Console.WriteLine(test.testZapis());
            Console.WriteLine(test.TestOdczytu());
            //test.wypiszWszystko();

            Console.WriteLine();
            Console.ReadKey();
        }
        

        static void Main(string[] args)
        {
            ICentrum centrum = new Centrum();
            int exit = 0;
            Serializacja dane = new Serializacja();
            dane.OdczytajDane(centrum);
            while (exit == 0)
            {
                Console.WriteLine("0 - wyjdz" + Environment.NewLine + "1 - Klienci centrum" + Environment.NewLine + "2 - Centrum" + Environment.NewLine + "3 - Archiwum");
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 0:
                        {
                            exit = 1;
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("0 - wyjdz" + Environment.NewLine + "1 - Opcje Firmy" + Environment.NewLine + "2 - Opcje banku");
                            int j = int.Parse(Console.ReadLine());
                            switch (j)
                            {
                                case 0:
                                    {
                                        break;
                                    }
                                case 1:
                                    {
                                        Console.WriteLine("0 - wyjdz" + Environment.NewLine + "1 - Dodaj firme" + Environment.NewLine + "2 - Usun firme" + Environment.NewLine + "3 - Przeglad frim");
                                        int l = int.Parse(Console.ReadLine());
                                        switch (l)
                                        {
                                            case 1:
                                                {
                                                    int exit2 = 0;
                                                    while (exit2 == 0)
                                                    {
                                                        Console.WriteLine("0 - wyjdz" + Environment.NewLine + "1 - dodaj Sklep" + Environment.NewLine + "2 - dodaj Transport" + Environment.NewLine
                                                            + "3 - Uslugi" + Environment.NewLine);
                                                        int k = int.Parse(Console.ReadLine());
                                                        Console.WriteLine("\nLista Bankow:");
                                                        centrum.wyswietlBanki();
                                                        switch (k)
                                                        {
                                                            case 0:
                                                                {
                                                                    exit2 = 1;
                                                                    break;
                                                                }
                                                            case 1:
                                                                {
                                                                    Console.WriteLine("Podaj nazwe, KRS firmy i nazwe banku");
                                                                    string nazwa = Console.ReadLine();
                                                                    string KRS = Console.ReadLine();
                                                                    string nazwa_banku = Console.ReadLine();
                                                                    Firma Nowa_firma = new Sklep(centrum, nazwa, KRS);
                                                                    centrum.znajdzBank(nazwa_banku).dodajKlienta(Nowa_firma);
                                                                    break;
                                                                }
                                                            case 2:
                                                                {
                                                                    Console.WriteLine("Podaj nazwe, KRS firmy i nazwe banku");
                                                                    string nazwa = Console.ReadLine();
                                                                    string KRS = Console.ReadLine();
                                                                    string nazwa_banku = Console.ReadLine();
                                                                    Firma Nowa_firma = new Transport(centrum, nazwa, KRS);
                                                                    centrum.znajdzBank(nazwa_banku).dodajKlienta(Nowa_firma);
                                                                    break;
                                                                }
                                                            case 3:
                                                                {
                                                                    Console.WriteLine("Podaj nazwe, KRS firmy i nazwe banku");
                                                                    string nazwa = Console.ReadLine();
                                                                    string KRS = Console.ReadLine();
                                                                    string nazwa_banku = Console.ReadLine();
                                                                    Firma Nowa_firma = new Uslugi(centrum, nazwa, KRS);
                                                                    centrum.znajdzBank(nazwa_banku).dodajKlienta(Nowa_firma);
                                                                    break;
                                                                }
                                                        }
                                                    }
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.WriteLine("Podaj KRS firmy ktora chcesz usunac");
                                                    string KRS = Console.ReadLine();
                                                    centrum.usunFirme(KRS);
                                                    //tutaj wstawic usuwanie zobacz jak, bo nie wiem, to jest usuwanie Firm. 
                                                    //tak samo zobacz czy jak usuwasz bank to sie cały usuwa czy tylko z listy i czy tak ma być
                                                    //I też console.clear trzeba wsadzić jeszcze przy menu każdym
                                                        break;
                                                }
                                            case 3:
                                                {
                                                    foreach (Firma firma in centrum.getFirmy()) 
                                                    {
                                                        Console.WriteLine(firma.nazwa + "," + firma.KRS);
                                                    }
                                                    break;
                                                }
                                        }
                                        
                                        break;
                                    }
                                case 2:
                                    {
                                        int exit1 = 0;
                                        while (exit1 == 0)
                                        {
                                            Console.WriteLine("0 - wyjdz" + Environment.NewLine + "1 - dodaj bank" + Environment.NewLine + "2 - Stworz klienta fizycznego" + Environment.NewLine + "3 - stworz konto" + Environment.NewLine
                                                + "4 - stworz karte" + Environment.NewLine + "5 - usun bank" + Environment.NewLine + "6 - przeglad bankow" + Environment.NewLine);
                                            int k = int.Parse(Console.ReadLine());
                                            switch (k)
                                            {
                                                case 0:
                                                    {
                                                        exit1 = 1;
                                                        break;
                                                    }
                                                case 1:
                                                    {
                                                        Console.WriteLine("Podaj nazwe banku");
                                                        string nazwa_banku = Console.ReadLine();
                                                        Bank bank = new Bank(nazwa_banku);
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        Console.WriteLine("podaj imie, nazwisko, pesel i nazwe banku");
                                                        string imie = Console.ReadLine();
                                                        string nazwisko = Console.ReadLine();
                                                        string pesel = Console.ReadLine();
                                                        string nazwa_banku = Console.ReadLine();
                                                        Osoba osoba = new Osoba(imie, nazwisko, pesel);
                                                        centrum.znajdzBank(nazwa_banku).dodajKlienta(osoba);
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        Console.WriteLine("1-Konto dla Firm" + Environment.NewLine + " 2 - Konto dla Osob");
                                                        int wybor = int.Parse(Console.ReadLine());
                                                        if (wybor == 1)
                                                        {
                                                            Console.WriteLine("podaj nazwe banku i KRS");
                                                            string nazwa_banku = Console.ReadLine();
                                                            string KRS = Console.ReadLine();
                                                            centrum.znajdzBank(nazwa_banku).stworzKontoFirmy(KRS);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("podaj nazwe banku i pesel");
                                                            string nazwa_banku = Console.ReadLine();
                                                            string pesel = Console.ReadLine();
                                                            centrum.znajdzBank(nazwa_banku).stworzKonto(pesel);
                                                        }
                                                        break;
                                                    }
                                                case 4:
                                                    {
                                                        Console.WriteLine("1-Karta Bankomatowa" + Environment.NewLine + " 2 - Karta Debetowa" + Environment.NewLine + " 3 - Karta Kredytowa");
                                                        int wybor = int.Parse(Console.ReadLine());
                                                        if (wybor == 1)
                                                        {
                                                            string nazwa_banku = Console.ReadLine();
                                                            // string nrKonta = centrum.znajdzBank(nazwa_banku) // tutaj
                                                            // centrum.znajdzBank(nazwa_banku).stworzKarte();
                                                        }
                                                        break;
                                                    }
                                                case 5:
                                                    {
                                                        string nazwa_banku = Console.ReadLine();
                                                        centrum.usunBank(nazwa_banku);
                                                        break;
                                                    }
                                                case 6:
                                                    {
                                                        foreach (Bank bank in centrum.getBanki())
                                                        {
                                                            Console.WriteLine(bank.nazwa);
                                                        }
                                                        break;
                                                    }



                                            }
                                        }
                                        break;
                                    }
                                
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("podaj nrKonta i kwote");
                            string nrKonta = Console.ReadLine();
                            decimal kwota = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("podaj NrKarty i PIN");
                            string NrKarty = Console.ReadLine();
                            int PIN = int.Parse(Console.ReadLine());
                            centrum.autoryzacja(NrKarty, PIN, kwota, nrKonta);
                            break;
                        }
                    case 3:
                        {
                            centrum.historia.Menu();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("zly wybor");
                            break;
                        }
                }
            }
        
        }
    }
}
