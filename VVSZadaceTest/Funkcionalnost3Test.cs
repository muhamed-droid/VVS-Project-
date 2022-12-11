using Microsoft.VisualStudio.TestTools.UnitTesting;
using VVSZadace;
using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.VisualBasic;

namespace VVSZadaceTests
{
    [TestClass()]
    public class Funkcionalnost3Test
    {
        static Registar registar;
        static Glasac glasac1, glasac2;
        static Kandidat kandidat1, kandidat2;
        static Stranka s1, s2;

        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            registar = new Registar();
            s1 = new Stranka("SDP", "Socijaldemokratska partija");
            s2 = new Stranka("SPK", "Samo pošteno komunistički");
            registar.dodajGlasaca(new Glasac("Muhamed", "Masnopita", new Adresa("Iljas", "Ljesevo", 71380, "252"), new DateTime(1992, 11, 15), "165T214", "1511992111111"));
            registar.dodajGlasaca(new Glasac("Sven", "Milinkovic-Savic", new Adresa("Rim", "ulica1", 71000, "123"), new DateTime(2000, 5, 21), "131T121", "2105000222222"));
            registar.dodajGlasaca(new Glasac("Edin", "Dzeko", new Adresa("Sarajevo", "ulica2", 71020, "231"), new DateTime(2000, 12, 31), "131T231", "3112000333333"));
            registar.dodajGlasaca(new Glasac("Robert", "Prosinecki", new Adresa("Zagreb", "ulica3", 71120, "132"), new DateTime(2000, 10, 10), "131T212", "1010000444444"));
            registar.dodajGlasaca(new Glasac("Branislav", "Ivanovic", new Adresa("Novi Sad", "ulica4", 71000, "5"), new DateTime(1999, 2, 15), "131T415", "1502999555555"));
            glasac1 = new Glasac("Marcelo", "Brozovic", new Adresa("Zadar", "Olivera Dragojevica", 79182, "333"), new DateTime(1992, 1, 15), "113T214", "1501992666666");
            glasac2 = new Glasac("Dominik", "Livakovic", new Adresa("Gol", "Stativa", 71234, "1"), new DateTime(1995, 12, 11), "121T617", "1112995777777");
            kandidat1 = new Kandidat("Marija", "Kiri", new Adresa("Poljska", "Warsava", 71224, "321"), new DateTime(1989, 10, 10), "112T657", "1010989888888");
            kandidat1.pridruziStranci(s1);
            kandidat2 = new Kandidat("Marko", "Livaja", new Adresa("Split", "Poljud", 74928, "10"), new DateTime(1992, 10, 10), "113T157", "1010992999999");
            registar.dodajStranku(s1);
            registar.dodajStranku(s2);
            registar.dodajGlas();
            registar.dodajGlas();
            registar.dodajKandidata(kandidat2);
            registar.dodajKandidata(kandidat1);
            List<Kandidat> l1 = new List<Kandidat>();
            l1.Add(kandidat1);
            glasac1.glasaj(l1);
            glasac1.glasaj(s1);
            kandidat1.dodajGlas(glasac1);
            kandidat1.dodajGlas(glasac2);
            kandidat1.dodajGlas(new Glasac("Mensur", "Mujdza", new Adresa("Sarajevo", "Hasima Spahica", 71000, "bb"), new DateTime(1999, 1, 23), "231T657", "2301999170035"));
            registar.dodajStranku(s1);
            kandidat2.pridruziStranci(s1);
            s1.dodajGlas(glasac1);
            s1.dodajGlas(glasac2);
            kandidat2.dodajGlas(glasac1);
            kandidat2.dodajGlas(glasac2);
            registar.dodajGlas();
            registar.dodajGlas();
            s1.dodajGlas(new Glasac("kk", "jjiajas", new Adresa("iqiqi", "jksja", 18293, "bb"), new DateTime(1999, 1, 21), "211T611", "2101999212317"));
            s1.dodajGlas(new Glasac("ki", "jjiajas", new Adresa("iqiqi", "jksja", 18293, "bb"), new DateTime(1999, 1, 21), "221T918", "2101999212190"));
            s1.dodajGlas(new Glasac("km", "jjijajas", new Adresa("iqiqi", "jksja", 18293, "bb"), new DateTime(1999, 1, 21), "281T613", "2101999212176"));
            s1.dodajGlas(new Glasac("kl", "jjlijas", new Adresa("iqiqi", "jksja", 18293, "bb"), new DateTime(1999, 1, 21), "241T811", "2101999212156"));
            s1.dodajGlas(new Glasac("ko", "jjilijas", new Adresa("iqiqi", "jksja", 18293, "bb"), new DateTime(1999, 1, 21), "281T612", "2101999211209"));
        }

        [TestMethod]
        public void TestMetodeGetBrojGlasaca()
        {
            Assert.AreEqual(4, registar.getBrojGlasaca());
        }

        [TestMethod]
        public void TestMetodeGetGlasaci()
        {
            registar.dodajGlasaca(glasac1);
            Assert.IsTrue(registar.getGlasaci().Contains(glasac1));
            Assert.IsFalse(registar.getGlasaci().Contains(glasac2));
        }

        [TestMethod]
        public void TestMetodeGetNezavisneKandidate()
        {
            Assert.AreEqual(1, registar.getNezavisnikandidati().Count);
        }


        [TestMethod]
        public void TestMetodeGetStranke()
        {
            Assert.AreEqual(3, registar.getStranke().Count);
            Assert.IsTrue(registar.getStranke().Contains(s2));
            Assert.IsTrue(registar.getStranke().Contains(s1));
            registar.dodajStranku(s2);
            Assert.IsTrue(registar.getStranke().Contains(s2));
        }

        [TestMethod]
        public void TestMetodeIspisRezultata2()
        {
            
            Assert.AreEqual("Socijaldemokratska partija:\n\n", registar.ispisRezultata());
        }

        [TestMethod]
        public void TestMetodeDajIzlaznost()
        {
            Assert.AreEqual(0.8, registar.dajIzlaznost());
        }

        [TestMethod]
        public void TestMetodeDajStrankeKojeSuPresleCenzus()
        {
            Assert.IsTrue(registar.dajStrankeKojeSuPresleCenzus().Contains(s1));
            Assert.IsFalse(registar.dajStrankeKojeSuPresleCenzus().Contains(s2));
        }

        [TestMethod]
        public void TestMetodeDajKandidateKojiSuOsvojiliMandat()
        {
            Assert.IsFalse(registar.dajKandidateKojiSuOsvojiliMandat().Contains(kandidat1));
            Assert.IsTrue(registar.dajKandidateKojiSuOsvojiliMandat().Contains(kandidat2));
        }

        static IEnumerable<object[]> Registar1
        {
            get
            {
                return new[]
                {
                new object[] { "Muhamed", "Masnopita", new Adresa("Iljas", "Ljesevo", 71380, "252"), new DateTime(1992, 11, 15), "165T214", "1511992111111", new Stranka("SDA", "Stranka demokratske akcije")},
                };
            }
        }

        [TestMethod]
        [DynamicData ("Registar1")]
        public void InlineTest(string ime, string prezime, Adresa adresa, DateTime datumRodjenja, string brojLicneKarte, string jmbg, Stranka s)
        {
            Registar r3 = new Registar();
            Glasac g = new Glasac(ime, prezime, adresa, datumRodjenja, brojLicneKarte, jmbg);
            g.glasaj(s);
            Assert.AreEqual(1, s.getBrojGlasova());
        }


        public static IEnumerable<object[]> UcitajPodatkeXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\masno\\Source\\Repos\\VVSZadaca1\\VVSZadaceTest\\Podaci.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                yield return new object[] { node.InnerText };
            }
        }
        static IEnumerable<object[]> PodaciXML
        {
            get
            {
                return UcitajPodatkeXML();
            }
        }


        [TestMethod]
        [DynamicData("PodaciXML")]
        public void TestPodaciXML(String ulaz)
        {
            Boolean postoji = false;
            foreach(Stranka s in registar.getStranke())
            {
                if(s.getIdentifikacionaSkracenica().Equals(ulaz))
                {
                    postoji = true;
                    break;
                }
            }
            Assert.IsTrue(postoji);
        }

    }
}
