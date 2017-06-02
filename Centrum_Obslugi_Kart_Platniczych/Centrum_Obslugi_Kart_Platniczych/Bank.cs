﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Centrum_Obslugi_Kart_Platniczych
{
    class Bank : IBank
    {
        public List<IKlient> klienci { get; protected set; } = new List<IKlient>();

        public bool autoryzacja(IKarta karta, int PIN, decimal kwota)
        {
            foreach(IKlient klient in klienci)
            {
                foreach(IKonto konto in klient.konta)
                {
                    foreach(IKarta karteczka in konto.karty )
                    {
                        if( (Karta)karteczka == (Karta)karteczka && PIN == ((Karta)karteczka).PIN)
                        {
                            if (konto.saldo - kwota < 0)
                            {
                                return false;   //Tu bedzie wyjatek zła kwota
                            }
                            else
                            {
                                if(this.decyzjaTransakcji())
                                {
                                    konto.wyplac(kwota);
                                    return true;
                                }
                                return false;
                            }
                        }
                    }
                }
            }
            return false;       //Tu bedzie wyjatek brak konta
        }

        private bool decyzjaTransakcji()
        {
            var rnd = new Random();
            System.Threading.Thread.Sleep(1000);
            if(rnd.Next(0,100) < 90)
            {
                return true;
            }
            return false;
        }

        public bool dodajKlienta(IKlient klient)
        {
            if(klient != null)
            {
                klienci.Add(klient);
                return true;
            }
            return false;       
        }

        public List<IKlient> getKlienci()
        {
            return klienci;
        }

    }
}
