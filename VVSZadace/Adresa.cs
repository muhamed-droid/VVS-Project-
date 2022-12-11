using System;

namespace VVSZadace
{
    public class Adresa
    {
        String nazivGrada, nazivUlice;
        int postanskiBroj;
        String broj;

        public Adresa(string nazivGrada, string nazivUlice, int postanskiBroj, string broj)
        {
            this.nazivGrada = nazivGrada;
            this.nazivUlice = nazivUlice;
            this.postanskiBroj = postanskiBroj;
            this.broj = broj;
        }
        public Adresa()
        {

        }

        public override string ToString()
        {
            return nazivGrada + " " + postanskiBroj.ToString() + " " + nazivUlice + " " + broj;
        }

    }
}
