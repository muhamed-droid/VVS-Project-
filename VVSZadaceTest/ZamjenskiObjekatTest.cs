using Microsoft.VisualStudio.TestTools.UnitTesting;
using VVSZadace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VVSZadaceTests
{
    [TestClass]
    public class ZamjenskiObjekatTest
    {
        static Registar r;
        static Glasac g;
        static Stranka s;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            r = new Registar();
            g = new Glasac("Cristiano", "Ronaldo", new Adresa("Brcko", "Mujkici III", 76100, "35"), new DateTime(1985, 2, 5), "156T251", "0502985186500");
            r.dodajGlasaca(g);
            s = new Stranka("NIP", "Narod i pravda");
            r.dodajStranku(s);
        }

        [TestMethod]
        public void TestZamjenskiObjekat()
        {
            Stub stub = new Stub
            {
                Registar = r
            };

            bool flag;

            try
            {
                flag = g.VjerodostojnostGlasaca(stub);
            }
            catch(Exception e)
            {
                flag = false;
            }
            Assert.IsTrue(flag);

            g.glasaj(s);
            //g.setDatGlas(true);
            try
            {
                flag = g.VjerodostojnostGlasaca(stub);
            }
            catch (Exception e)
            {
                flag = false;
            }
            Assert.IsFalse(flag);
        }

    }
}
