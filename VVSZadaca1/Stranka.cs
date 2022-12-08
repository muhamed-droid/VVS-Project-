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
        private List<Kandidat> kandidati;
        private List<Glasac> glasaci;
        private List<Glasac> clanoviRukovodstva;

        public Stranka(string identifikacionaSkracenica, string puniNaziv)
        {
            this.identifikacionaSkracenica = identifikacionaSkracenica;
            this.puniNaziv = puniNaziv;
            this.kandidati = new List<Kandidat>();
            this.glasaci = new List<Glasac>();
            this.clanoviRukovodstva = new List<Glasac>();
            this.brojGlasova = 0;
        }

        public String getIdentifikacionaSkracenica()
        {
            return identifikacionaSkracenica;
        }
        public String getPuniNaziv()
        {
            return puniNaziv;
        }
        public int getBrojGlasova()
        {
            return brojGlasova;
        }
        public List<Kandidat> getKandidati()
        {
            return kandidati;
        }
        public List<Glasac> getClanoviRukovodstva()
        {
            return clanoviRukovodstva;
        }
        public List<Glasac> getClanoviRukovodstvaKandidovani()
        {
            var listaKandidataRukovodstva = new List<Glasac>();
            for (int i = 0; i < clanoviRukovodstva.size(); i++)

                for (int j = 0; j < kandidati.size(); j++)
                    if (kandidati[j].getJmbg().equals(clanoviRukovodstva[i].getJmbg()))
                        listaKandidataRukovodstva.add(kandidati[j]);

            return listaKandidataRukovodstva;

            
        }
        public int getUkupanBrojGlasovaRukovodstva()
        {
            var lista = getClanoviRukovodstvaKandidovani();
            int zbir = 0;
            foreach (var clan in lista)
                zbir += clan.getBrojGlasova();
            return zbir;
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

        //stranka ima svoju listu kandidata, ovako stranka dodaje kandidata na listu
        public void dodajKandidata(Kandidat kandidat)
        {
            kandidati.Add(kandidat);   
        }

        public void izbaciKandidata(Kandidat kandidat)
        {
            kandidati.Remove(kandidat);
        }

        public List<Glasac> getGlasaci()
        {
            return glasaci;
        }
    }
}
