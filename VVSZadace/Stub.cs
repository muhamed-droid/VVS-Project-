using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadace
{
    public class Stub : IProvjera
    {
        public Registar Registar { get; set; }
        bool IProvjera.DaLiJeVecGlasao(string IDBroj)
        {
            Glasac glasac = Registar.getGlasaci().Find(g => g.getJedinstveniIdentifikacioniKod() == IDBroj);
            return glasac.getDatGlas();
        }
    }
}
