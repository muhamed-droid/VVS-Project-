using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadaca1
{
    internal class Stranka
    {
        private String identifikacionaSkracenica, puniNaziv;
        private int brojGlasova;
        private List<Osoba> kandidati;

        public Stranka(string identifikacionaSkracenica, string puniNaziv)
        {
            this.identifikacionaSkracenica = identifikacionaSkracenica;
            this.puniNaziv = puniNaziv;
            this.kandidati = new List<Osoba>();
            this.brojGlasova = 0;
        }

        public int getBrojGlasova()
        {
            return brojGlasova;
        }
        public List<Osoba> getKandidati()
        {
            return kandidati;
        }
        public void dodajGlas()
        {
            brojGlasova++;
        }

        //stranka ima svoju liistu kandidata, ovako stranka dodaje kandidata na listu
        public void dodajKandidata(Osoba osoba)
        {
            kandidati.Add(osoba);   
        }

        public void izbaciKandidata(Osoba osoba)
        {
            kandidati.Remove(osoba);
        }

    }
}
