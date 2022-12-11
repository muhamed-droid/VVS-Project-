using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace VVSZadace
{
    public class Glasac
    {
        private String ime, prezime;
        private Adresa adresa;
        private DateTime datumRodjenja;
        private String brojLicneKarte;
        private string jmbg;
        private String jedinstveniIdentifikacioniKod;
        private bool datGlas = false;

        public Glasac(string ime, string prezime, Adresa adresa, DateTime datumRodjenja, string brojLicneKarte, string jmbg)
        {
            this.setIme(ime);
            this.setPrezime(prezime);
            this.setAdresa(adresa);
            this.setDatumRodjenja(datumRodjenja);
            this.setBrojLicneKarte(brojLicneKarte);
            this.setJmbg(jmbg);

            this.jedinstveniIdentifikacioniKod = ime.Substring(0, 2) + prezime.Substring(0, 2) + adresa.ToString().Substring(0, 2) +
                datumRodjenja.ToString("dd") + datumRodjenja.ToString("MM") + datumRodjenja.ToString("yy") +
                brojLicneKarte.Substring(0, 2);
        }

        public Glasac() { }

        public bool daLiSadrziSlovaICrticu(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z\-\s]+$") &&
                (input.Count(c => c == '-') == 1 || input.Count(c => c == '-') == 0);
        }

        public bool daLiJePrazan(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }


        public string getIme()
        {
            return ime;
        }

        public void setIme(string ime)
        {
            if (daLiJePrazan(ime))
                throw new ArgumentException("Ime je prazno!");

            if (ime.Length < 2 || ime.Length > 40)
                throw new ArgumentException("Ime nije ispravne dužine!");

            if (!daLiSadrziSlovaICrticu(ime))
                throw new ArgumentException("Ime smije sadržavati samo slova i crticu!");

            this.ime = ime;

        }

        public string getPrezime()
        {
            return prezime;
        }

        public void setPrezime(string prezime)
        {
            if (daLiJePrazan(prezime))
                throw new ArgumentException("Prezime je prazno!");

            if (prezime.Length < 3 || ime.Length > 50)
                throw new ArgumentException("Prezime ispravne dužine!");

            if (!daLiSadrziSlovaICrticu(prezime))
                throw new ArgumentException("Prezime smije sadržavati samo slova i crticu!");

            this.prezime = prezime;

        }

        public Adresa getAdresa()
        {
            return adresa;
        }

        public void setAdresa(Adresa adresa)
        {
            this.adresa = adresa;
        }

        public string getBrojLicneKarte()
        {
            return brojLicneKarte;
        }

        public void setBrojLicneKarte(string brojLicneKarte)
        {
            if (brojLicneKarte.Length == 7 && Regex.IsMatch(brojLicneKarte, @"^\d{3}[EJKMT]\d{3}$"))
            {
                this.brojLicneKarte = brojLicneKarte;
            }
        }

        public DateTime getDatumRodjenja()
        {
            return datumRodjenja;
        }

        public void setDatumRodjenja(DateTime datumRodjenja)
        {
            int godine = DateTime.Now.Year - datumRodjenja.Year;
            if (DateTime.Now.DayOfYear < datumRodjenja.DayOfYear)
                godine--;

            if (godine >= 18 && DateTime.Compare(datumRodjenja, DateTime.Now) <= 0)
            {
                this.datumRodjenja = datumRodjenja;
            }
        }

        public string getJmbg()
        {
            return jmbg;
        }

        public void setJmbg(string jmbg)
        {
            string godina = getDatumRodjenja().Year.ToString();
            if (jmbg.Length == 13 && Regex.IsMatch(jmbg.ToString(), @"^[\d\s]+$") &&
                 jmbg.Substring(0, 2) == getDatumRodjenja().ToString("dd") &&
                 jmbg.Substring(2, 2) == getDatumRodjenja().ToString("MM") &&
                 jmbg.Substring(4, 3) == godina.Substring(godina.Length > 3 ? godina.Length - 3 : 0))
            {
                this.jmbg = jmbg;
            }
        }

        public string getJedinstveniIdentifikacioniKod()
        {
            return this.jedinstveniIdentifikacioniKod;
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

        public void glasaj(Stranka stranka)
        {
            stranka.dodajGlas(this);
        }

        public bool daLiJeListicValidan(List<Kandidat> kandidati)
        {
            if (kandidati == null) return false;

            if (kandidati.ElementAt(0).getStranka() == null && kandidati.Count() > 1) return false;

            foreach (var kandidat in kandidati)
            {
                foreach (var poredjenje in kandidati)
                {
                    //ako kandidat i onaj sa kojim se poredi dolaze iz razlicite stranke, listić je nevažeći
                    if (kandidat.getStranka() != poredjenje.getStranka())
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void glasaj(List<Kandidat> kandidati)
        {
            if (kandidati.Count == 0 || !daLiJeListicValidan(kandidati)) return;
            foreach (Kandidat k in kandidati)
            {
                k.dodajGlas(this);
            }
        }

        public bool VjerodostojnostGlasaca(IProvjera sigurnosnaProvjera)
        {
            if (sigurnosnaProvjera.DaLiJeVecGlasao(jedinstveniIdentifikacioniKod))
                throw new Exception("Glasač je već izvršio glasanje!");
            return true;
        }

    }
}
