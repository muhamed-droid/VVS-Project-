using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadaca1
{
    //Osoba je po defaultu glasač
    internal class Glasac
    {
        private String ime, prezime;
        private Adresa adresa;
        private DateTime datumRodjenja;
        private String brojLicneKarte;
        private long jmbg;
        private String jedinstveniIdentifikacioniKod;
        private bool datGlas = false; 

        //konstruktor za Glasaca
        public Glasac(string ime, string prezime, Adresa adresa, DateTime datumRodjenja, string brojLicneKarte, long jmbg)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.datumRodjenja = datumRodjenja;
            this.brojLicneKarte = brojLicneKarte;
            this.jmbg = jmbg;
            //pitanje je da li ćemo ga ovako generisat jer je glupo što ako je mjesec osmi pokupit će 8/
            //Možda da od godine kupimo
            this.jedinstveniIdentifikacioniKod = ime.Substring(0, 2) + prezime.Substring(0, 2) + 
                adresa.ToString().Substring(0,2) + datumRodjenja.Year.ToString().Substring(2, 2) + 
                brojLicneKarte.Substring(0,2) + jmbg.ToString().Substring(0,2);
           
        }

        public string getIme()
        {
            return ime;
        }
        public string getPrezime()
        {
            return prezime;
        }
        public long getJmbg()
        {
            return jmbg;
        }
        public bool getDatGlas()
        {
            return datGlas;
        }
        public void setDatGlas(bool flag)
        {
            this.datGlas = flag;
        }

        public override string ToString()
        {
            return jedinstveniIdentifikacioniKod;
        }

        public String getJedinstveniIdentifikacioniKod()
        {
            return this.jedinstveniIdentifikacioniKod;
        }
    
        //dodaje glas stranci
        public void glasaj(Stranka stranka)
        {
            stranka.dodajGlas(this);
        }

        bool daLiJeListicValidan(List<Kandidat> kandidati)
        {
            //prazan listic također nije validan listić
            if (kandidati == null) return false;

            //glasanje za nezavisnog kandidata se vrsi iskljucivo glasom za jednog tog kandidata
            //sve ostalo je nevazece
            if (kandidati.ElementAt(0).getStranka() == null && kandidati.Count() > 1) return false; 

            //prolazak kroz kandidate
            foreach (var kandidat in kandidati)
            {
                //prolazak jos jednom kroz kandidate radi poređenja
                foreach (var poredjenje in kandidati)
                {
                    //ako kandidat i onaj sa kojim se poredi dolaze iz razlicite stranke, listić je nevažeći
                    if (kandidat.getStranka() != poredjenje.getStranka())
                    {
                        return false;
                    }
                }
            }
            //u suprotnom je važeći
            return true;
        }

        //dodaje glas svim kandidatima koji su u listi, naravno ako pripadaju istoj stranci.
        public void glasaj(List<Kandidat> kandidati) 
        {
            if (kandidati.Count == 0 || !daLiJeListicValidan(kandidati)) return;
            foreach(Kandidat k in kandidati){
                k.dodajGlas(this);
            }
        }
    }
}
