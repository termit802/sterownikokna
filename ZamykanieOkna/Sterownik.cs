using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZamykanieOkna
{
    class Sterownik
    {
        Form1 okno;
        public int obecny_priorytet;
        Stan stan = Stan.Otwarte;
        enum Stan { Otwarte, Zamkniete, Zamykanie, Otwieranie, Awaria };
        List<Czujnik> czujniki = new List<Czujnik>();
        public void dodaj_czujnik(Czujnik cz) { czujniki.Add(cz); }
        public Sterownik(Form1 okno)
        {
            obecny_priorytet = 100;
            this.okno = okno;
            pozycja = 100;
            dodaj_czujnik(new Czujnik("czad-1", 50, 0,this));
            dodaj_czujnik(new Czujnik("przeszkoda", 1, 1, this));
            dodaj_czujnik(new Czujnik("temperatura", 25, 2, this));
            dodaj_czujnik(new Czujnik("wilgotność", 50, 3, this));
            dodaj_czujnik(new Czujnik("deszcz", 1, 4, this));
            dodaj_czujnik(new Czujnik("śnieg/lód", 1, 5, this));
        }

        public void zmien_stan_czujnika(string nazwa, int wartosc)
        {
            foreach (Czujnik cz in czujniki)
                if(cz.nazwa == nazwa)
                    cz.wartosc_biezaca = wartosc;
      
        }

        public void tick()
        {
            if (stan == Stan.Otwarte || stan == Stan.Zamykanie)
            {
                if (pozycja > 0)
                {
                    pozycja--;
                    if (pozycja == 0) 
                        okno.poinformuj("zamknieto pomyslnie.", pozycja, 100);
                    else
                        okno.poinformuj("trwa zamykanie.", pozycja, 100);
                }
            }

            if (stan == Stan.Zamkniete|| stan == Stan.Otwieranie)
            {
                if (pozycja < 100)
                {
                    pozycja++;
                    if (pozycja == 100)
                        okno.poinformuj("otwarto pomyslnie.", pozycja, 100);
                    else
                        okno.poinformuj("trwa otwieranie.", pozycja, 100);
                }
            }


            foreach (Czujnik cz in czujniki)
                cz.tick();
        }

        public void poinformuj(Czujnik cz)
        {
            okno.poinformuj("informacja od czujnika " + cz.nazwa, pozycja, cz.id);
        }

        protected int pozycja;

        public void zamknij()
        {
            stan = Stan.Zamykanie;
        }

        public void otworz()
        {
            stan = Stan.Otwieranie;
        }

        public void awaria()
        {
            stan = Stan.Awaria;
        }
    }
}
