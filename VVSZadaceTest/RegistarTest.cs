using Microsoft.VisualStudio.TestTools.UnitTesting;
using VVSZadace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VVSZadaceTests
{
    [TestClass()]
    public class RegistarTest
    {
        static Registar r;
        static Glasac g1, g2;
        static Kandidat k1, k2;
        static Stranka s1, s2;

        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            r = new Registar();
            r.dodajGlasaca(new Glasac("Muhamed", "Masnopita", new Adresa("Iljas", "Ljesevo", 71380, "252"), new DateTime(1992, 11, 15), "165T24", 3009000170036));
            r.dodajGlasaca(new Glasac("Sven", "Milinkovic-Savic", new Adresa("Rim", "ulica1", 71000, "123"), new DateTime(2000, 5, 21), "131T12", 2105000175127));
            r.dodajGlasaca(new Glasac("Edin", "Dzeko", new Adresa("Sarajevo", "ulica2", 71020, "231"), new DateTime(2000, 12, 31), "131T23", 3112000175127));
            r.dodajGlasaca(new Glasac("Robert", "Prosinecki", new Adresa("Zagreb", "ulica3", 71120, "132"), new DateTime(2000, 10, 10), "131T22", 1010000175127));
            r.dodajGlasaca(new Glasac("Branislav", "Ivanovic", new Adresa("Novi Sad", "ulica4", 71000, "5"), new DateTime(1999, 2, 15), "131T45", 1502999175327));
            s1 = new Stranka("SDP", "Socijaldemokratska partija");
            s2 = new Stranka("SPK", "Samo pošteno komunistički");
        }

        [TestInitialize()]
        public void InicijalizacijaPrijeSvakogTesta()
        {
            g1 = new Glasac("Marcelo", "Brozovic", new Adresa("Zadar", "Olivera Dragojevica", 79182, "333"), new DateTime(1992, 1, 15), "113T24", 1501992170029);
            g2 = new Glasac("Dominik", "Livakovic", new Adresa("Gol", "Stativa", 71234, "1"), new DateTime(1995, 12, 11), "12T617", 1113995170005);
            k1 = new Kandidat("Marija", "Kiri", new Adresa("Poljska", "Warsava", 71224, "321"), new DateTime(1989, 10, 10), "12T657", 1010989232312);
            k1.pridruziStranci(s1);
            k2 = new Kandidat("Marko", "Livaja", new Adresa("Split", "Poljud", 74928, "10"), new DateTime(1992, 10, 10), "13T157", 1010992232312);
        }

        [TestMethod]
        public void TestMetodeGetBrojGlasaca()
        {
            Assert.AreEqual(0, r.getBrojGlasaca());
            r.dodajGlas();
            Assert.AreEqual(1, r.getBrojGlasaca());
            r.dodajGlas();
            Assert.AreEqual(2, r.getBrojGlasaca());
        }

        [TestMethod]
        public void TestMetodeGetGlasaci()
        {
            r.dodajGlasaca(g1);
            Assert.IsTrue(r.getGlasaci().Contains(g1));
            Assert.IsFalse(r.getGlasaci().Contains(g2));
        }

        [TestMethod]
        public void TestMetodeGetNezavisneKandidate()
        {
            Assert.AreEqual(0, r.getNezavisnikandidati().Count);
            r.dodajKandidata(k1);
            Assert.AreEqual(0, r.getNezavisnikandidati().Count);
            r.dodajKandidata(k2);
            Assert.AreEqual(1, r.getNezavisnikandidati().Count);
        }


        [TestMethod]
        public void TestMetodeGetStranke()
        {
            Assert.AreEqual(0, r.getStranke().Count);
            r.dodajStranku(s1);
            Assert.AreEqual(1, r.getStranke().Count);
            Assert.IsFalse(r.getStranke().Contains(s2));
            Assert.IsTrue(r.getStranke().Contains(s1));
            r.dodajStranku(s2);
            Assert.IsTrue(r.getStranke().Contains(s2));
        }

        [TestMethod]
        public void TestMetodeIspisRezultata1()
        {
            Registar r2 = new Registar();
            Assert.AreEqual("Izbori još nisu počeli", r2.ispisRezultata());
        }

        [TestMethod]
        public void TestMetodeIspisRezultata2()
        {
            r.dodajStranku(s1);
            k2.pridruziStranci(s1);
            s1.dodajGlas(g1);
            s1.dodajGlas(g2);
            k2.dodajGlas(g1);
            k2.dodajGlas(g2);
            r.dodajGlas();
            r.dodajGlas();
            Assert.AreEqual("Socijaldemokratska partija:\nMarko Livaja broj glasova: 2 procenat osvojenih glasova: 100%\n\n", r.ispisRezultata());
        }

        [TestMethod]
        public void TestMetodeDajIzlaznost()
        {
            Assert.AreEqual(0, r.dajIzlaznost());
            r.dodajGlas();
            Assert.AreEqual(0.2, r.dajIzlaznost());
            r.dodajGlas();
            Assert.AreEqual(0.4, r.dajIzlaznost());
        }

        [TestMethod]
        public void TestMetodeDajStrankeKojeSuPresleCenzus()
        {
            r.dodajStranku(s1);
            r.dodajStranku(s2);
            Assert.IsFalse(r.dajStrankeKojeSuPresleCenzus().Contains(s1));
            g1.glasaj(s1);
            Assert.IsTrue(r.dajStrankeKojeSuPresleCenzus().Contains(s1));
            Assert.IsFalse(r.dajStrankeKojeSuPresleCenzus().Contains(s2));
            g2.glasaj(s2);
            Assert.IsTrue(r.dajStrankeKojeSuPresleCenzus().Contains(s2));
        }

        [TestMethod]
        public void TestMetodeDajKandidateKojiSuOsvojiliMandat()
        {
            r.dodajKandidata(k2);
            r.dodajKandidata(k1);
            List<Kandidat> l1 = new List<Kandidat>();
            l1.Add(k1);
            g1.glasaj(l1);
            Assert.IsTrue(r.dajKandidateKojiSuOsvojiliMandat().Contains(k1));
            Assert.IsFalse(r.dajKandidateKojiSuOsvojiliMandat().Contains(k2));
            List<Kandidat> l2 = new List<Kandidat>();
            l2.Add(k2);
            g2.glasaj(l2);
            Assert.IsTrue(r.dajKandidateKojiSuOsvojiliMandat().Contains(k1));
            Assert.IsTrue(r.dajKandidateKojiSuOsvojiliMandat().Contains(k2));
        }

        static IEnumerable<object[]> Registar1
        {
            get
            {
                return new[]
                {
                new object[] { "", "Prezime", new Adresa("Minken", "Bavaria", 71300,"5") ,DateTime.Parse("01/01/1996"), "0101996170001", "M", "ZD-01" },
                new object[] { "Ime", "", DateTime.Parse("01/01/1996"), "0101996170001", "M", "ZD-01" },
                new object[] { "Ime", "Prezime", DateTime.Now.AddDays(1), "0101996170001", "M", "ZD-01" },
                new object[] { "Ime", "Prezime", DateTime.Parse("01/01/1996"), "5001996170001", "M", "ZD-01" },
                new object[] { "Ime", "Prezime", DateTime.Parse("01/01/1996"), "0101996170001", "Muško", "ZD-01" },
                new object[] { "Ime", "Prezime", DateTime.Parse("01/01/1996"), "0101996170001", "M", "01" }
                };
            }
        }

        [TestMethod]
        [DynamicData ("Registar1")]
        public void TestKonstruktoraPacijenta(string ime, string prezime, DateTime rođenje, string matični, string spol, string knjižica)
        {
            
        }
    }
}
