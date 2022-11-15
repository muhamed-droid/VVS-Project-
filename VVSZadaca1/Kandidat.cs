using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadaca1
{
    internal class Kandidat : Glasac
    {
        private Stranka stranka;
        int brojGlasova;
        Boolean mandat=false;

        //po defaultu se kreira nezavisni kandidat u kojem je stranka null
        public Kandidat(string ime, string prezime, Adresa adresa, DateTime datumRodjenja, string brojLicneKarte, int jmbg) : base(ime, prezime, adresa, datumRodjenja, brojLicneKarte, jmbg)
        {
            brojGlasova = 0;
        }

        //osoba postaje kandidat kada se kreira instanca kandidat, budi član neke stranke koristeći ovu metodu.
        public void pridruziStranci(Stranka stranka)
        {
            this.stranka = stranka;
        }

        //kandidat dobija glas
        public void dodajGlas()
        {
            brojGlasova++;
        }

        public int getBrojGlasova()
        {
            return brojGlasova;
        }

        public Stranka getStranka()
        {
            return stranka;
        }

        public Boolean getMandat()
        {
            return mandat;
        }

        public Boolean provjeraMandata()
        {
            if(this.getBrojGlasova()>=0.2*this.getStranka().getBrojGlasova())
            {
                mandat = true;
            }
            return mandat;
        }

    }
}
