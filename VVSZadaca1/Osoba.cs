using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadaca1
{
    //Osoba je po defaultu glasač, ali će se prilikom glasanja osobi provjeravati starost
    //Za sve ispod 18 neće imati pravo glasa
    internal class Osoba
    {
        private String ime, prezime;
        private Adresa adresa;
        private DateTime datumRodjenja;
        private String brojLicneKarte;
        private int jmbg;
        private String jedinstveniIdentifikacioniKod;

        //konstruktor za Osobu, jedinstveniIdentifikacioniKod se automatski generise
        public Osoba(string ime, string prezime, Adresa adresa, DateTime datumRodjenja, string brojLicneKarte, int jmbg)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.datumRodjenja = datumRodjenja;
            this.brojLicneKarte = brojLicneKarte;
            this.jmbg = jmbg;
            //pitanje je da li ćemo ga ovako generisat jer je glupo što ako je mjesec osmi pokupit će 8/
            //Možda da od godine kupimo
            this.jedinstveniIdentifikacioniKod = ime.Substring(0, 2) + prezime.Substring(0, 2) + adresa.ToString().Substring(0,2) + datumRodjenja.Year.ToString().Substring(2, 2) + brojLicneKarte.Substring(0,2) + jmbg.ToString().Substring(0,2);
           
        }

        public string getIme()
        {
            return ime;
        }
        public string getPrezime()
        {
            return prezime;
        }
        public int getJmbg()
        {
            return jmbg;
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
            stranka.dodajGlas();
        }

        bool daLiJeListicPrazan(List<Kandidat> kandidati)
        {
            if (kandidati == null) return true;
            return false;
        }


        bool daLiJeListicValidan(List<Kandidat> kandidati)
        {
            //prazan listic također nije validan listić
            if (daLiJeListicPrazan(kandidati)) throw new ArgumentNullException("Prazan lisitć");

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
            if (!daLiJeListicValidan(kandidati)) return;
            //dodaje se glas stranci iz koje je kandidat zaokruzen
            kandidati.ElementAt(0).getStranka().dodajGlas();
            foreach(Kandidat k in kandidati){
                k.dodajGlas();
            }
          
        }


        public void glasaj(Stranka stranka, List<Kandidat> kandidati)
        {
            glasaj(stranka);
            glasaj(kandidati);
        }


    }
}
