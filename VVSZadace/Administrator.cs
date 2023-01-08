using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadace
{
    public class Administrator
    {
        //Funkcionalnost br.5 Esma Zejnilović
        private Registar registar;
        public Administrator(Registar registar)
        {
            this.registar = registar;
        }

        int brojac = 3;
        public int getBrojac()
        {
            return brojac;
        }
        public string provjeraTajneSifre(string sifra)
        {
            brojac--;
            String tajnaSifra = "VVS20222023";
            if (!sifra.ToUpper().Equals(tajnaSifra))
            {
                if (brojac == 0)
                {
                    return "Pogrešna šifra! Nemate više pokušaja!";
                }
                else
                    return "Pogrešna šifra! Pokušajte ponovo:";
            }
            return "Unijeli ste tačnu šifru!";
        }

        public string provjeraIdentifikacionogBroja(string jibr)
        {
            Glasac o = dajGlasacaZaJIBroj(jibr);
            if (o == null)
            {
                return "Unijeli ste neispravan identifikacioni broj!";
            }
            //brojac = 3;
            return "Ispravan identifikacioni broj!";
        }

        public Glasac dajGlasacaZaJIBroj(string jibr)
        {
            return registar.getGlasaci().Find(g => g.getJedinstveniIdentifikacioniKod() == jibr);
        }
        //Funkcionalnost br.5 Esma Zejnilović
    }
}
