using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VVSZadaca1;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;

namespace TestProject
{
    [TestClass]
    public class TestRegistar
    {
        //Muhamed Masnopita
        Registar r = new Registar();

        [TestInitialize()]
        public void Initialize()
        {
            r.dodajGlasaca(new Glasac("Muhamed", "Masnopita", new Adresa("Iljas", "Ljesevo", 71380, "252"), new DateTime(1992, 11, 15), "165T24", 3009000170036));
            r.dodajGlasaca(new Glasac("Sven", "Milinkovic-Savic", new Adresa("Rim", "ulica1", 71000, "123"), new DateTime(2000, 5, 21), "131T12", 2105000175127));
            r.dodajGlasaca(new Glasac("Edin", "Dzeko", new Adresa("Sarajevo", "ulica2", 71020, "231"), new DateTime(2000, 12, 31), "131T23", 3112000175127));
            r.dodajGlasaca(new Glasac("Robert", "Prosinecki", new Adresa("Zagreb", "ulica3", 71120, "132"), new DateTime(2000, 10, 10), "131T22", 1010000175127));
            r.dodajGlasaca(new Glasac("Branislav", "Ivanovic", new Adresa("Novi Sad", "ulica4", 71000, "5"), new DateTime(1999, 2, 15), "131T45", 1502999175327));
        }



        [TestMethod]
            //[DynamicData("Pacijenti2")]
            void TestMetodeDodajGlasaca()
            {
                Glasac g1 = new Glasac("Marcelo", "Brozovic", new Adresa("Zadar", "Olivera Dragojevica", 79182, "333"), new DateTime(1992, 1, 15), "113T24", 1501992170029);
                Glasac g2 = new Glasac("Dominik", "Livakovic", new Adresa("Gol", "Stativa", 71234, "1"), new DateTime(1995, 13, 11), "12T617", 1113995170005); 
                Assert.AreEqual(5, r.getGlasaci().Count);
                r.dodajGlasaca(g1);
                Assert.AreEqual(6, r.getGlasaci().Count);
                r.dodajGlasaca(g2);
                Assert.AreEqual(7, r.getGlasaci().Count);
            }

            [TestMethod]
            void TestMetodeGetGlasaci()
            {
            Glasac g1 = new Glasac("Marcelo", "Brozovic", new Adresa("Zadar", "Olivera Dragojevica", 79182, "333"), new DateTime(1992, 1, 15), "113T24", 1501992170029);
            Glasac g2 = new Glasac("Dominik", "Livakovic", new Adresa("Gol", "Stativa", 71234, "1"), new DateTime(1995, 13, 11), "12T617", 1113995170005);
            r.dodajGlasaca(g1);
            Assert.IsTrue(r.getGlasaci().Contains(g1));
            Assert.IsFalse(r.getGlasaci().Contains(g2));
        }


    }
}
