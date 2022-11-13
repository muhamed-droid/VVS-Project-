using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadaca1
{
    internal class Registar
    {
        private List<Kandidat> nezavisniKandidati=new List<Kandidat>();
        private List<Osoba> glasaci = new List<Osoba>();
        private List<Stranka> stranke=new List<Stranka>();
        private static int brojGlasaca = 0;
        public List<Osoba> getGlasaci()
        {
            return glasaci;

        }
        public List<Kandidat> getNezavisnikandidati()
        {
            return nezavisniKandidati;
        }
        public List<Stranka> getStranke()
        {
            return stranke;
        }
        public void  dodajGlasaca(Osoba o)
        {
            glasaci.Add(o); 
        }
        public void dodajKandidata(Kandidat k)
        {
            nezavisniKandidati.Add(k);  
        }
         public void dodajStranku(Stranka s)
        {
            stranke.Add(s);
        }
        public Osoba identifikacijaGlasaca(string ime, string prezime, int jmbg)
        {
            return glasaci.First(item => item.getIme().ToLower().Equals(ime.ToLower()) && item.getPrezime().ToLower().Equals(prezime.ToLower(), StringComparison.Ordinal) && item.getJmbg().Equals(jmbg) );
            
        }
        public void unesiGlas()
        {
            brojGlasaca++;
        }

    }
}
