using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVSZadace;

namespace VVSZadaceTests
{
    [TestClass()]
    public class CodeTuning
    {
        [TestMethod()]
        public void TestTuning()
        {
            Registar registar = new Registar();
            //Stranka stranka = new Stranka("STRANKA", "Stranka");
            //registar.dodajStranku(stranka);
            for (int i = 0; i < 10000000; i++)
            {
                //stranka.dodajKandidata(new Kandidat("Zeljko", "Komsic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T278", "1511967111111"));
                registar.dodajKandidata(new Kandidat("Zeljko", "Komsic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T278", "1511967111111"));
            }

            int x = 0;

            for (int i = 0; i < 50; i++)
            {
                registar.dajKandidateKojiSuOsvojiliMandat();
            }

            int y = 0;

            Assert.IsTrue(true);
        }
    }
}
