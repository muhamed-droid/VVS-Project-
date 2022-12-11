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
    //Esma Zejnilovic
    [TestClass]
    public class Funkcionalnost5Test  //funkcionalnost br.5 = dvije metode u Glasac.cs i jedna metoda u Registar.cs + dio Main-a (koji ne treba testirati)
    {
        static Glasac glasac;
        static Registar r;
        static Kandidat k1;
        static Stranka s1;

        /// <summary>
        /// Inicijalizacija podataka koja se vrši samo jednom
        /// </summary>
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            r = new Registar();
            r.dodajGlasaca(new Glasac("Muhamed", "Masnopita", new Adresa("Iljas", "Ljesevo", 71380, "252"), new DateTime(1992, 11, 15), "165T24", 3009000170036));
            r.dodajGlasaca(new Glasac("Sven", "Milinkovic-Savic", new Adresa("Rim", "ulica1", 71000, "123"), new DateTime(2000, 5, 21), "131T12", 2105000175127));
            r.dodajGlasaca(new Glasac("Edin", "Dzeko", new Adresa("Sarajevo", "ulica2", 71020, "231"), new DateTime(2000, 12, 31), "131T23", 3112000175127));
            r.dodajGlasaca(new Glasac("Robert", "Prosinecki", new Adresa("Zagreb", "ulica3", 71120, "132"), new DateTime(2000, 10, 10), "131T22", 1010000175127));
            r.dodajGlasaca(new Glasac("Branislav", "Ivanovic", new Adresa("Novi Sad", "ulica4", 71000, "5"), new DateTime(1999, 2, 15), "131T45", 1502999175327));
            s1 = new Stranka("SDP", "Socijaldemokratska partija");
            r.dodajStranku(s1);
            k1 = new Kandidat("Marija", "Kiri", new Adresa("Poljska", "Warsava", 71224, "321"), new DateTime(1989, 10, 10), "12T657", 1010989232312);
            r.dodajKandidata(k1);
            k1.pridruziStranci(s1);
        }

        /// <summary>
        /// Inicijalizacija podataka koja se vrši prije svakog testa
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            glasac = new Glasac("Cristiano", "Ronaldo", new Adresa("Brcko", "Mujkici III", 76100, "35"), new DateTime(1985, 2, 5), "156T25", 0502985186500);
        }

        /// <summary>
        /// Test ponovno glasanje sa unesenom ispravnom tajnom šifrom
        /// </summary>
        [TestMethod]
        public void TestPonovnoGlasanje1()
        {
            string poruka;
            poruka = glasac.ponovnoGlasanje("VVS");
            StringAssert.Equals(poruka, "Pogrešna šifra! Pokušajte ponovo:");
            poruka = glasac.ponovnoGlasanje("VVS20222023");
            StringAssert.Equals(poruka, "Unijeli ste tačnu šifru!");
        }

        /// <summary>
        /// Test ponovno glasanje sa unesenom neispravnom tajnom šifrom 3 puta
        /// </summary>
        [TestMethod]
        public void TestPonovnoGlasanje2()
        {
            string poruka;
            poruka = glasac.ponovnoGlasanje("VVS");
            StringAssert.Equals(poruka, "Pogrešna šifra! Pokušajte ponovo:");
            poruka = glasac.ponovnoGlasanje("VVS2022");
            StringAssert.Equals(poruka, "Pogrešna šifra! Pokušajte ponovo:");
            poruka = glasac.ponovnoGlasanje("VVS2023");
            StringAssert.Equals(poruka, "Pogrešna šifra! Nemate više pokušaja!");
        }

        /// <summary>
        /// Test ponovno glasanje sa unesenim neispravnim identifikacionim brojem
        /// </summary>
        [TestMethod]
        public void TestIdentifikacioniBroj1()
        {
            string poruka = glasac.provjeraIdentifikacionogBroja("CR7");
            StringAssert.Contains(poruka, "pogrešan");
        }

        /// <summary>
        /// Test ponovno glasanje sa unesenim ispravnim identifikacionim brojem
        /// </summary>
        [TestMethod]
        public void TestIdentifikacioniBroj2()
        {
            string poruka = glasac.provjeraIdentifikacionogBroja("CrRo76851550");
            StringAssert.Contains(poruka, "Ispravan");
        }

        /// <summary>
        /// Test resetovanja glasanja, provjera da li su maknuti glasovi glasaca za određen stranku i/ili nezavisnog kandidata
        /// </summary>
        [TestMethod]
        public void TestResetujGlasanje()
        {
            int brojGlasaca = r.getBrojGlasaca();
            glasac.glasaj(s1);
            glasac.glasaj(new List<Kandidat>() { k1 });
            Assert.IsTrue(s1.getGlasaci().Contains(glasac));
            Assert.IsTrue(k1.getGlasaci().Contains(glasac));
            r.resetujGlasanje(glasac);
            Assert.IsFalse(glasac.getDatGlas());
            Assert.AreEqual(r.getBrojGlasaca(), brojGlasaca - 1);
            Assert.IsFalse(s1.getGlasaci().Contains(glasac));
            Assert.IsFalse(k1.getGlasaci().Contains(glasac));
        }

        static IEnumerable<object[]> TajneSifre
        {
            get
            {
                return new[]
                {
                    new object[] { "VVS" },
                    new object[] { "VVS2022" },
                    new object[] { "VVS2023" }
                };
            }
        }
        [TestMethod]
        [DynamicData("TajneSifre")]
        public void TestPonovnoGlasanje3(string sifra)
        {
            string poruka = glasac.ponovnoGlasanje(sifra);
            if(glasac.getBrojac() != 0)
                StringAssert.Equals(poruka, "Pogrešna šifra! Pokušajte ponovo:");
            else
                StringAssert.Equals(poruka, "Pogrešna šifra! Nemate više pokušaja!");
        }


        public static IEnumerable<object[]> UcitajTajneSifreXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("TajneSifre.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                yield return new object[] { node.InnerText };
            }
        }
        static IEnumerable<object[]> TajneSifreXML
        {
            get
            {
                return UcitajTajneSifreXML();
            }
        }
        [TestMethod]
        [DynamicData("TajneSifreXML")]
        public void TestPonovnoGlasanjeXML(string sifra)
        {
            string poruka = glasac.ponovnoGlasanje(sifra);
            if (glasac.getBrojac() != 0)
                StringAssert.Equals(poruka, "Pogrešna šifra! Pokušajte ponovo:");
            else
                StringAssert.Equals(poruka, "Pogrešna šifra! Nemate više pokušaja!");
        }
    }
}
