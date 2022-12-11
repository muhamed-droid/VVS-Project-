using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadace
{
    public class Stub : IProvjera
    {
        //public string IdentifikacijskiBroj { get; set; }
        bool IProvjera.DaLiJeVecGlasao(string IDBroj)
        {
            //IdentifikacijskiBroj = IDBroj;

            throw new NotImplementedException();
        }
    }
}
