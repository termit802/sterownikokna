using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZamykanieOkna
{
    class Czujnik
    {
        public string nazwa;
        public int wartosc_biezaca, wartosc_progowa, id ;
        public Sterownik s;
        public Czujnik(string nazwa, int wartosc_progowa, int id, Sterownik s) { 
            this.nazwa = nazwa; 
            this.s = s;
            this.wartosc_progowa = wartosc_progowa;
            this.id = id;
        }
        public int odczyt() { return wartosc_biezaca; }
        public void tick()
        {
            if (wartosc_biezaca >= wartosc_progowa) s.poinformuj(this);
        }

    }
}
