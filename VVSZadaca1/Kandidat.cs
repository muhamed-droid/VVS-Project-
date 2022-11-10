using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadaca1
{
    internal class Kandidat : Osoba
    {
        private String ime, prezime;
        private Adresa adresa;
        private DateTime datumRodjenja;
        private String brojLicneKarte;
        private int jmbg;
        private String jedinstveniIdentifikacioniKod;
        private Stranka stranka;
        int brojGlasova;

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
    }
}
