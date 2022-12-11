﻿using System;
using System.Collections.Generic;

namespace VVSZadace
{
    public class Kandidat : Glasac
    {
        private Stranka stranka;
        private List<Glasac> glasaci;
        private int brojGlasova;
        Boolean mandat = false;

        //po defaultu se kreira nezavisni kandidat u kojem je stranka null
        public Kandidat(string ime, string prezime, Adresa adresa, DateTime datumRodjenja, string brojLicneKarte, long jmbg) : base(ime, prezime, adresa, datumRodjenja, brojLicneKarte, jmbg)
        {
            this.glasaci = new List<Glasac>();
            brojGlasova = 0;
        }

        //osoba postaje kandidat kada se kreira instanca kandidat, budi član neke stranke koristeći ovu metodu.
        public void pridruziStranci(Stranka stranka)
        {
            this.stranka = stranka;
        }

        public void dodajGlas(Glasac glasac)
        {
            glasaci.Add(glasac);
            brojGlasova++;
        }
        public void ukloniGlas(Glasac glasac)
        {
            glasaci.Remove(glasac);
            brojGlasova--;
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
            if (this.getBrojGlasova() >= 0.2 * this.getStranka().getBrojGlasova())
            {
                mandat = true;
            }
            return mandat;
        }
        public override string ToString()
        {
            return getIme() + " " + getPrezime();
        }

        public List<Glasac> getGlasaci()
        {
            return glasaci;
        }
    }
}