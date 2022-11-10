using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadaca1
{
    internal class Adresa
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

        public override string ToString()
        {
            return postanskiBroj.ToString() + " " + nazivGrada+ " " + nazivUlice + " " + broj;
        }

    }
}
