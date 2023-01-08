using System;
using System.Collections.Generic;
using System.Linq;

namespace VVSZadace
{
    public class Registar
    {
        private List<Kandidat> nezavisniKandidati = new List<Kandidat>();
        private List<Glasac> glasaci = new List<Glasac>();
        private List<Stranka> stranke = new List<Stranka>();
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
        public void dodajGlasaca(Glasac o)
        {
            glasaci.Add(o);
        }
        public void dodajKandidata(Kandidat k)
        {
            if(k.getStranka()==null)
            nezavisniKandidati.Add(k);
        }
        public void dodajStranku(Stranka s)
        {
            stranke.Add(s);
        }
        public Glasac identifikacijaGlasaca(string ime, string prezime, string jmbg)
        {
            return glasaci.First(item => item.getIme().ToLower().Equals(ime.ToLower()) && 
            item.getPrezime().ToLower().Equals(prezime.ToLower(), StringComparison.Ordinal) && 
            item.getJmbg().Equals(jmbg));

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
        //Muhamed Masnopita
        public String ispisRezultata()
        {
            String ispis = "";
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
                    ispis = s.getPuniNaziv() + ":\n";
                    foreach (Kandidat k in s.getKandidati())
                    {
                        if (k.getBrojGlasova() >= 0.2 * s.getBrojGlasova() && this.getBrojGlasaca() > 0 && k.getBrojGlasova() > 0)
                        {
                            double procenat = (double)k.getBrojGlasova() / (double)s.getBrojGlasova();
                            ispis = ispis + k + " broj glasova: " + k.getBrojGlasova() + " procenat osvojenih glasova: " + procenat * 100 + "%\n";
                        }
                    }
                    ispis = ispis + "\n";
                }
            return ispis;
        }

        public double dajIzlaznost()
        {
            return (double)this.getBrojGlasaca() / (double)this.getGlasaci().Count;
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
            bool postojiOsobaKojaJeGlasala = this.getBrojGlasaca() >= 0;

            if (postojiOsobaKojaJeGlasala)
            {
                foreach (Kandidat k in this.getNezavisnikandidati())
                {
                    bool cenzusKaoNezavisniKandidat = k.getBrojGlasova() >= 0.02 * this.getBrojGlasaca();
                    if (cenzusKaoNezavisniKandidat)
                    {
                        kandidatiKojiSuOsvojiliMandat.Add(k);
                    }
                }

                List<Stranka> listaStranki = this.getStranke();
                foreach (Stranka s in listaStranki)
                {
                    foreach (Kandidat k in s.getKandidati())
                    {
                        bool cenzusUStranci = k.getBrojGlasova() >= 0.2 * s.getBrojGlasova();
                        bool imaGlasova = k.getBrojGlasova() > 0;
                        bool uslovZaOsvojenMandatKandidataStranke = cenzusUStranci && imaGlasova;
                        if (uslovZaOsvojenMandatKandidataStranke)
                        {
                            kandidatiKojiSuOsvojiliMandat.Add(k);
                        }
                    }
                }
            }
            return kandidatiKojiSuOsvojiliMandat;
        }

        public int getUkupanBrojGlasovaRukvodstvaStranaka()
        {
            var ukupno = 0;
            for (var i = 0; i < stranke.Count; i++)
                foreach (var clan in stranke[i].getClanoviRukovodstvaKandidovani())
                    ukupno += clan.getBrojGlasova();
            return ukupno;
        }

        public List<Kandidat> getKandidovanoRukovodstvoSvihStranaka()
        {
            List<Kandidat> list = new List<Kandidat>();
            for (var i = 0; i < stranke.Count; i++)
            {

                int brojKandidata = stranke[i].getClanoviRukovodstvaKandidovani().Count;
                for (var j = 0; j < brojKandidata; j++)
                    list.Add(stranke[i].getClanoviRukovodstvaKandidovani()[j]);
            }
            return list;

        }

        //Funkcionalnost br.5 Esma Zejnilović
        public void resetGlasanja(Glasac o)
        {
            o.setDatGlas(false);
            ukloniGlas();
            Stranka stranka = getStranke().Find(s => s.getGlasaci().Contains(o));
            if (stranka != null)
            {
                stranka.ukloniGlas(o);
            }
            List<Kandidat> kandidati = getNezavisnikandidati().FindAll(k => k.getGlasaci().Contains(o));
            if (kandidati != null)
            {
                foreach (Kandidat kandidat in kandidati)
                {
                    kandidat.ukloniGlas(o);
                }
            }
        }
        //Funkcionalnost br.5 Esma Zejnilović
    }
}
