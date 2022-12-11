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
    public class SpySigurnosnaProvjeraTest
    {
        static Glasac glasac;
        static SpySigurnosnaProvjera spy;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            spy = new SpySigurnosnaProvjera();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            glasac = new Glasac("Cristiano", "Ronaldo", new Adresa("Brcko", "Mujkici III", 76100, "35"), new DateTime(1985, 2, 5), "156T251", "0502985186500");
        }

        [TestMethod]
        public void TestZamjenskiObjekat()
        {
            SpySigurnosnaProvjera spy = new SpySigurnosnaProvjera();

            spy.Opcija = 1;
            try
            {
                glasac.VjerodostojnostGlasaca(spy);
            }
            catch(Exception e)
            {
                StringAssert.Equals(e.Message, "Glasač je već izvršio glasanje!");
            }

            spy.Opcija = 0;
            Assert.IsTrue(glasac.VjerodostojnostGlasaca(spy));
        }

    }
}
