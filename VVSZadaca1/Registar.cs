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
        private List<Glasac> glasaci = new List<Glasac>();
        private List<Stranka> stranke=new List<Stranka>();
        private static int brojGlasaca = 0;
        public List<Glasac> getGlasaci()
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
        public void  dodajGlasaca(Glasac o)
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
        public Glasac identifikacijaGlasaca(string ime, string prezime, long jmbg)
        {
            return glasaci.First(item => item.getIme().ToLower().Equals(ime.ToLower()) && item.getPrezime().ToLower().Equals(prezime.ToLower(), StringComparison.Ordinal) && item.getJmbg().Equals(jmbg) );
            
        }
        public void dodajGlas()
        {
            brojGlasaca++;
        }

        public void ukloniGlas()
        {
            brojGlasaca--;
        }

        public int getBrojGlasaca()
        {
            return brojGlasaca;
        }

        public void ispisRezultata()
        {
            if (brojGlasaca == 0) Console.Write("Izbori još nisu počeli");
            else
            {
                List<Stranka> strankeKojeSuProlseCenzus = new List<Stranka>();
                foreach (Stranka s in this.getStranke())
                {
                    if (s.getBrojGlasova() > 0.02 * this.getBrojGlasaca())
                    {
                        strankeKojeSuProlseCenzus.Add(s);
                    }
                }

                foreach (Stranka s in strankeKojeSuProlseCenzus)
                {
                    Console.Write(s.getPuniNaziv() + ":");
                    foreach(Kandidat k in s.getKandidati())
                    {
                        if (k.getBrojGlasova() >= 0.2 * s.getBrojGlasova() && this.getBrojGlasaca() > 0 && k.getBrojGlasova() > 0)
                        {
                            double procenat = (double)k.getBrojGlasova() / (double)s.getBrojGlasova();
                            Console.Write(k + " broj glasova: " + k.getBrojGlasova() + " procenat osvojenih glasova: " + procenat*100 + "%\n");
                        }
                    }
                    Console.WriteLine();
                }
            } 
        } 

        public double dajIzlaznost()
        {
            double izlaznost = (double)this.getBrojGlasaca() / (double)this.getGlasaci().Count;
            return 1.0;
        }

        public List<Stranka> dajStrankeKojeSuPresleCenzus()
        {
            List<Stranka> strankeKojeSuPresleCenzus = new List<Stranka>();
            foreach (Stranka s in this.getStranke())
            {
                if (s.getBrojGlasova() > 0.02 * this.getBrojGlasaca())
                {
                    strankeKojeSuPresleCenzus.Add(s);
                }
            }
            return strankeKojeSuPresleCenzus;
        }

        public List<Kandidat> dajKandidateKojiSuOsvojiliMandat()
        {
            List<Kandidat> kandidatiKojiSuOsvojiliMandat = new List<Kandidat>();
            foreach (Kandidat k in this.getNezavisnikandidati())
            {
                if (k.getBrojGlasova() >= 0.02 * this.getBrojGlasaca() && this.getBrojGlasaca() > 0)
                {
                    kandidatiKojiSuOsvojiliMandat.Add(k);
                }
            }
            List<Stranka> listaStranki = this.getStranke();
            foreach (Stranka s in listaStranki)
            {
                foreach (Kandidat k in s.getKandidati())
                {
                    if (k.getBrojGlasova() >= 0.2 * s.getBrojGlasova() && this.getBrojGlasaca() > 0 && k.getBrojGlasova() > 0)
                    {
                        kandidatiKojiSuOsvojiliMandat.Add(k);
                    }
                }
            }
            return kandidatiKojiSuOsvojiliMandat;
        }

    }
}
