using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadaca1
{
    internal class Osoba
    {
        private String ime, prezime;
        private Adresa adresa;
        private DateTime datumRodjenja;
        private String brojLicneKarte;
        private int jmbg;
        private String jedinstveniIdentifikacioniKod;

        public Osoba(string ime, string prezime, Adresa adresa, DateTime datumRodjenja, string brojLicneKarte, int jmbg)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.adresa = adresa;
            this.datumRodjenja = datumRodjenja;
            this.brojLicneKarte = brojLicneKarte;
            this.jmbg = jmbg;
            this.jedinstveniIdentifikacioniKod = ime.Substring(0, 2) + prezime.Substring(0, 2) + adresa.ToString().Substring(0,2) + datumRodjenja.ToString().Substring(0,2);
            Console.WriteLine(jedinstveniIdentifikacioniKod);
        }
    }
}
