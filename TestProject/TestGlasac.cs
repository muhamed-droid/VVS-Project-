using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VVSZadaca1;

namespace TestProject
{
    [TestClass]
    internal class TestGlasac
    {
        static 
            Glasac glasac;

        [TestInitialize()]
        public void Initialize()
        {
            glasac = new Glasac("Cristiano", "Ronaldo", new Adresa("Brcko", "Mujkici III", 76100, "35"), new DateTime(1985, 2, 5), "156T25", 0502985186500);
        }

        //Funkcionalnost br.5 Esma Zejnilović
        [TestMethod]
        public void TestPonovnoGlasanje1()
        {
            string poruka;
            poruka = glasac.ponovnoGlasanje("VVS");
            Assert.AreEqual(poruka, "Pogrešna šifra! Pokušajte ponovo:");
            poruka = glasac.ponovnoGlasanje("VVS20222023");
            Assert.AreEqual(poruka, "Unijeli ste tačnu šifru!");
        }

        [TestMethod]
        public void TestPonovnoGlasanje2()
        {
            string poruka;
            poruka = glasac.ponovnoGlasanje("VVS");
            Assert.AreEqual(poruka, "Pogrešna šifra! Pokušajte ponovo:");
            poruka = glasac.ponovnoGlasanje("VVS2022");
            Assert.AreEqual(poruka, "Pogrešna šifra! Pokušajte ponovo:");
            poruka = glasac.ponovnoGlasanje("VVS2023");
            Assert.AreEqual(poruka, "Pogrešna šifra! Nemate više pokušaja!");
        }

        [TestMethod]
        public void TestIdentifikacioniBroj1()
        {
            string poruka = glasac.provjeraIdentifikacionogBroja("CR7");
            Assert.AreEqual(poruka, "Unijeli ste pogrešan identifikacioni broj!");
        }

        [TestMethod]
        public void TestIdentifikacioniBroj2()
        {
            string poruka = glasac.provjeraIdentifikacionogBroja("CR7");
            Assert.AreEqual(poruka, "Ispravan identifikacioni broj!");
        }
        //Funkcionalnost br.5 Esma Zejnilović
    }
}
