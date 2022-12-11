using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadace
{
    public class SpySigurnosnaProvjera : IProvjera
    {
        public int Opcija { get; set; }
        public bool DaLiJeVecGlasao(string IDBroj)
        {
            if (Opcija == 1)
                return true;
            else
                return false;
        }
    }
}
