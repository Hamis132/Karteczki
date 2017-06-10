using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class UI
    {
        public ICentrum centrum { get; protected set; }

        public UI(ICentrum centrum)
        {
            this.centrum = centrum;
        }

        public void MenuGlowne()
        {
            int exit = 0;
            while(exit == 0)
            {
                Console.Clear();
                Console.WriteLine("1-Menu Centrum\n2-Menu Banku\n3-MenuFirm\n4-Menu Archiwum\n0-Wyjdz z programu");
                int i = Int32.Parse(Console.ReadLine());
                switch(i)
                {
                    case 1:
                        Console.Clear();
                        MenuCentrum();
                        break;
                    case 2:
                        Console.Clear();
                        centrum.wyswietlBanki();
                        Console.WriteLine();
                        Console.WriteLine("Podaj index Banku...\n");
                        int index = Int32.Parse(Console.ReadLine());
                        MenuBanku(Centrum.banki[index]);
                        break;
                    case 3:
                        Console.Clear();
                        MenuFirm();
                        break;
                    case 4:
                        Console.Clear();
                        MenuHistorii();
                        break;
                    case 0:
                        exit = 1;
                        break;

                }
            }
        }

        private void MenuHistorii()
        {
            int exit = 0;
            try
            {
                while (exit == 0)
                {
                    Console.Clear();
                    Console.WriteLine("1-Wyswietl wszystkie transakcje\n2-Znajdz transakcje po nr karty\n3-Znajdz transakcje po nr karty i roku \n4-Pokaz transakcje udane lub nieudane\n0-Wyjdz z menu\n");
                    int i = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (i)
                    {
                        case 1:
                            centrum.historia.wyswietlTransakcje(centrum.historia.transakcje);
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("Podaj nr karty...\n");
                            string nrKarty = Console.ReadLine();
                            centrum.historia.wyswietlTransakcje(centrum.historia.znajdzTransakcje(nrKarty));
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("Podaj nr karty oraz rok...\n");
                            nrKarty = Console.ReadLine();
                            DateTime rok = DateTime.Parse(Console.ReadLine());
                            centrum.historia.wyswietlTransakcje(centrum.historia.znajdzTransakcje(nrKarty, rok));
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("1-Pokaz udane\n2-Pokaz nieudane\n");
                            int opcja = Int32.Parse(Console.ReadLine());
                            switch (opcja)
                            {
                                case 1:
                                    centrum.historia.wyswietlTransakcje(centrum.historia.znajdzTransakcje(true));
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    centrum.historia.wyswietlTransakcje(centrum.historia.znajdzTransakcje(false));
                                    Console.ReadKey();
                                    break;
                            }
                            break;
                        case 0:
                            exit = 1;
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Zła opcja ");
            }
        }

        private void _MenuFirm()
        {
            int exit = 0;
            while(exit==0)
            {
                Console.Clear();
                Console.WriteLine("1-Stworz sklep\n2-Stworz firme transportowa\n3-Stworz zaklad uslugowy\n0-Wyjdz z menu\n");
                int i = Int32.Parse(Console.ReadLine());
                switch(i)
                {
                    case 1:
                        {
                            Console.WriteLine("Podaj nazwe i KRS");
                            Console.WriteLine();
                            string nazwa = Console.ReadLine();
                            string KRS = Console.ReadLine();
                            IFirma firma = new Sklep(centrum, nazwa, KRS);

                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Podaj nazwe i KRS");
                            Console.WriteLine();
                            string nazwa = Console.ReadLine();
                            string KRS = Console.ReadLine();
                            IFirma firma = new Transport(centrum, nazwa, KRS);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Podaj nazwe i KRS");
                            Console.WriteLine();
                            string nazwa = Console.ReadLine();
                            string KRS = Console.ReadLine();
                            IFirma firma = new Uslugi(centrum, nazwa, KRS);
                            break;
                        }
                    case 0:
                        exit = 1;
                        break;

                }
            }
        }

        private void MenuCentrum()
        {
            int exit = 0;
            IBank bank;
            while (exit == 0)
            {
                Console.Clear();
                Console.WriteLine("1-Wyswietl wszystkie banki\n2-Dodaj bank\n3-Usun Bank\n4-Wyswietl firmy\n5-Dodaj firme\n6-Usun firme\n0-Wyjdz z Menu\n");
                int i = Int32.Parse(Console.ReadLine());
                int index;
                Console.Clear();
                switch (i)
                {
                    case 1:
                        centrum.wyswietlBanki();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Podaj nazwe Banku, ktory chcesz dodac...");
                        string nazwaBanku = Console.ReadLine();
                        bank = new Bank(nazwaBanku);
                        Console.ReadKey();
                        break;
                    case 3:
                        centrum.wyswietlBanki();
                        Console.WriteLine();
                        Console.WriteLine("Podaj index banku ktory chcesz usunac...");
                        index = Int32.Parse(Console.ReadLine());
                        bank = Centrum.banki[index];
                        centrum.usunBank(bank);
                        break;
                    case 4:
                        centrum.wyswietlFirmy();
                        Console.ReadKey();
                        break;
                    case 5:
                        _MenuFirm();
                        
                        break;
                    case 6:
                        centrum.wyswietlFirmy();
                        Console.WriteLine();
                        Console.WriteLine("Podaj index firmy ktora chcesz usunac...");
                        index = Int32.Parse(Console.ReadLine());
                        IFirma firma = centrum.firmy[index];
                        centrum.usunFirme(firma);
                        break;
                    case 0:
                        exit = 1;
                        break;

                }
            }
        }

        private void MenuBanku(IBank _bank)
        {
            int exit = 0;
            IBank bank = _bank;

            while (exit == 0)
            {
                Console.Clear();
               
                Console.WriteLine("1-Dodaj klienta\n2-Utworz konto dla wybranego klienta\n3-Menu klienta\n4-Usun wybranego klienta\n0-Wyjdz z Menu\n");
                int i = Int32.Parse(Console.ReadLine());
                Console.Clear();
                switch (i)
                {

                    case 1:
                        Console.Clear();
                        Console.WriteLine("1-Dodaj osobe fizyczna\n2-Dodaj firme\n");
                        int opcja = Int32.Parse(Console.ReadLine());
                        Console.Clear();
                        switch(opcja)
                        {
                            case 1:
                                Console.WriteLine("Podaj imie, nazwisko i numer PESEL...");
                                string imie = Console.ReadLine();
                                string nazwisko = Console.ReadLine();
                                string PESEL = Console.ReadLine();
                                IKlient klient = new Osoba(imie, nazwisko, PESEL);
                                bank.dodajKlienta(klient);
                                break;
                            case 2:
                                try
                                {
                                    centrum.wyswietlFirmy();
                                    Console.WriteLine("Podaj indeks firmy, ktora chcialbys dodac do banku...\n");
                                    int _index = Int32.Parse(Console.ReadLine());
                                    bank.dodajKlienta(centrum.firmy[_index]);
                                    break;
                                }
                                catch (Exception ex) { Console.WriteLine("Podano index spoza zakresu!"); }
                                break;
                        }
                        break;

                    case 2:

                        bank.wypiszKlientow();
                        Console.WriteLine();
                        Console.WriteLine("Podaj index klienta dla ktorego chcesz utworzyc konto");
                        int index = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Twoj numer konta to: " + bank.stworzKonto(index));
                        Console.ReadKey();
                        break;

                    case 3:

                        bank.wypiszKlientow();
                        Console.WriteLine();
                        Console.WriteLine("Wybierz klienta...");
                        index = Int32.Parse(Console.ReadLine());
                        MenuKlienta(bank, bank.klienci[index]);
                        break;

                    case 4:
                        
                        bank.wypiszKlientow();
                        Console.WriteLine();
                        Console.WriteLine("Wybierz klienta ktorego chcesz usunac...");
                        index = Int32.Parse(Console.ReadLine());
                        bank.usunKlienta(index);
                        break;
                    case 0:
                        exit = 1;
                        break;
                }
            }
        }

        private void update(IKlient klient)
        {
            foreach(IFirma firma in centrum.firmy)
            {
               if(klient is IFirma)
                {
                    if(((IFirma)klient).KRS == firma.KRS)
                    {
                        centrum.firmy.Remove(firma);
                        centrum.firmy.Add((IFirma)klient);
                        return;
                    }
                }
            }
        }

        private void MenuKlienta(IBank _bank,IKlient _klient)
        {
            int exit = 0;
            IKlient klient = _klient;
            IBank bank = _bank;
            while(exit ==0)
            {
                Console.Clear();
                Console.WriteLine("KONTA:\n");
                klient.wypiszKonta();
                Console.WriteLine("1-Stworz karte dla wybranego konta\n2-Usun konto\n3-Wyplac pieniadze\n-Wyjdz z menu\n");
                int i = Int32.Parse(Console.ReadLine());
                int index;
                IKonto konto;
                Console.Clear();
                switch(i)
                {
                    
                    case 1:
                        klient.wypiszKonta();
                        Console.WriteLine();
                        Console.WriteLine("Podaj index konta dla ktorego chcesz stworzyc karte...");
                        index = Int32.Parse(Console.ReadLine());
                        konto = klient.konta[index];
                        MenuKart(bank, konto);                     //MenuKart
                        break;
                    case 2:
                        klient.wypiszKonta();
                        Console.WriteLine();
                        Console.WriteLine("Podaj index konta ktore chcialbys usunac...");
                        index = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Wszystkie srodki na koncie zostaną utracone...");
                        Console.ReadKey();
                        bank.usunKonto(klient.konta[index].nrKonta);
                        break;
                    case 3:
                        klient.wypiszKonta();
                        Console.WriteLine();
                        try
                        {
                            Console.WriteLine("Podaj index konta, na ktore chcialbys wplacic pieniadze...");
                            index = Int32.Parse(Console.ReadLine());
                            konto = klient.konta[index];
                            Console.WriteLine("Podaj kwote...");
                            try
                            {
                                decimal kwota = decimal.Parse(Console.ReadLine());
                                konto.wplac(kwota);
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Podales niepoprawna kwote!");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Podano zly indeks konta lub nie poprawna kwote");
                        }
                        Console.ReadKey();
                        break;
                    case 0:
                        exit = 1;
                        break;
                        
                }
                update(klient);
            }
        }

        private void MenuKart(IBank _bank, IKonto _konto)
        {
            int exit = 0;
            IBank bank = _bank;
            IKonto konto = _konto;
            while(exit == 0)
            {
                Console.Clear();
                Console.WriteLine("1-Stworz karte bankomatowa\n2-Stworz karte debetowa\n3-Stworz karte kredytowa\n");
                int i = Int32.Parse(Console.ReadLine());
                int PIN;
                switch (i)
                {
                    
                    case 1:
                        Console.WriteLine("Podaj PIN...");
                        PIN = Int32.Parse(Console.ReadLine());
                        bank.stworzKarteBankomatowa(konto.nrKonta, PIN);
                        break;
                    case 2:
                        Console.WriteLine("Podaj PIN...");
                        PIN = Int32.Parse(Console.ReadLine());
                        bank.stworzKarteDebetowa(konto.nrKonta, PIN);
                        break;
                    case 3:
                        Console.WriteLine("Podaj PIN..");
                        PIN = Int32.Parse(Console.ReadLine());
                        bank.stworzKarteKredytowa(konto.nrKonta, PIN);
                        break;
                    case 0:
                        exit = 1;
                        break; 
                }
            }
        }

        private void MenuFirm()
        {
            int exit = 0;
            IBank bank;
            while(exit == 0)
            {
                Console.Clear();
                Console.WriteLine("1-Transakcja\n2-Wyswietl wszystkie firmy\n");
                int index;
                int i = Int32.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        centrum.wyswietlFirmy();
                        Console.WriteLine();
                        Console.WriteLine("Podaj index firmy dla ktorej chcesz zrealizowac transakcje");
                        index = Int32.Parse(Console.ReadLine());
                        IFirma firma = centrum.firmy[index];
                        Console.Clear();
                        firma.wypiszKonta();
                        Console.WriteLine();
                        Console.WriteLine("Podaj index konta na ktore chcesz dostac pieniadze");
                        int indexKonta = Int32.Parse(Console.ReadLine());
                        Console.Clear();
                        centrum.wyswietlBanki();
                        Console.WriteLine("Podaj index Banku z ktorego chcesz zrealizowac transakcje");
                        index = Int32.Parse(Console.ReadLine());
                        bank = centrum.getBanki()[index];
                        Console.Clear();
                        bank.wyswietlKarty();
                        Console.WriteLine("Podaj nr karty oraz kwote");
                        string nrKarty = Console.ReadLine();
                        decimal kwota = decimal.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Podaj PIN");
                        int PIN = Int32.Parse(Console.ReadLine());
                        try
                        {
                            if (firma.centrum.autoryzacja(nrKarty, PIN, kwota, firma.konta[indexKonta].nrKonta))
                            {
                                Console.WriteLine("Transakcja sie powiodła");
                            }
                            else
                            {
                                Console.WriteLine("Odrzucono");
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Złe dane");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        centrum.wyswietlFirmy();
                        Console.ReadKey();
                        break;
                    case 0:
                        exit = 1;
                        break;
                }
            }
        }
    }
}
