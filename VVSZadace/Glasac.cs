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

        public bool daLiSadrziSamoSlovaICrticu(string input)
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
                throw new LicneInformacijeOGlasacuException("Ime ne smije biti prazno!");

            if (ime.Length < 2 || ime.Length > 40)
                throw new LicneInformacijeOGlasacuException("Ime treba da se sastoji od minimalno 2, a maksimalno 40 slova!");

            if (!daLiSadrziSamoSlovaICrticu(ime))
                throw new LicneInformacijeOGlasacuException("Ime treba sadržavati samo slova i crticu!");

            this.ime = ime;
        }

        public string getPrezime()
        {
            return prezime;
        }

        public void setPrezime(string prezime)
        {
            if (daLiJePrazan(prezime))
                throw new LicneInformacijeOGlasacuException("Prezime ne smije biti prazno!");

            if (prezime.Length < 3 || ime.Length > 50)
                throw new LicneInformacijeOGlasacuException("Prezime treba da se sastoji od minimalno 3, a maksimalno 50 slova!");

            if (!daLiSadrziSamoSlovaICrticu(prezime))
                throw new LicneInformacijeOGlasacuException("Prezime treba sadržavati samo slova i crticu!");

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
            if (brojLicneKarte.Length != 7)
                throw new LicneInformacijeOGlasacuException("Broj lične karte uvijek se sastoji od tačno 7 karaktera!");

            if (!Regex.IsMatch(brojLicneKarte, @"^\d{3}[EJKMT]\d{3}$"))
                throw new LicneInformacijeOGlasacuException("Nije ispravan format!");
            
            this.brojLicneKarte = brojLicneKarte;
        }

        public DateTime getDatumRodjenja()
        {
            return datumRodjenja;
        }

        public void setDatumRodjenja(DateTime datumRodjenja)
        {
            if (DateTime.Compare(datumRodjenja, DateTime.Now) > 0)
                throw new LicneInformacijeOGlasacuException("Datum rođenja ne može biti u budućnosti!");

            int godine = DateTime.Now.Year - datumRodjenja.Year;
            if (DateTime.Now.DayOfYear < datumRodjenja.DayOfYear)
                godine--;

            if (godine < 18)
                throw new LicneInformacijeOGlasacuException("Glasač mora biti punoljetan!");
            
            this.datumRodjenja = datumRodjenja;
  
        }

        public string getJmbg()
        {
            return jmbg;
        }

        public void setJmbg(string jmbg)
        {
            
            if (jmbg.Length != 13)
                throw new LicneInformacijeOGlasacuException("Matični broj se mora sastojati od 13 brojeva!");

            string godina = getDatumRodjenja().Year.ToString();
            if (!Regex.IsMatch(jmbg.ToString(), @"^[\d\s]+$") ||
                 jmbg.Substring(0, 2) != getDatumRodjenja().ToString("dd") ||
                 jmbg.Substring(2, 2) != getDatumRodjenja().ToString("MM") ||
                 jmbg.Substring(4, 3) != godina.Substring(godina.Length > 3 ? godina.Length - 3 : 0))
                throw new LicneInformacijeOGlasacuException("Nije ispravan format!");
            
            this.jmbg = jmbg;
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
    }
}
