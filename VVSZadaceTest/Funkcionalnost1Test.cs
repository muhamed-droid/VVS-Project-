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
    //Adna Mehanovic
    [TestClass()]
    public class Funkcionalnost1Test
    {

        static Glasac glasac;

        /// <summary>
        /// Inicijalizacija podataka koja se vrši prije svakog testa
        /// </summary>
        [TestInitialize]
        public void InicijalizacijaPrijeSvakogTesta()
        {
            glasac = new Glasac("Adna", "Mehanovic", new Adresa("Vogosca", "Josanicka", 71000, "21"), new DateTime(2000, 11, 10), "111T111", "1011000111111");
        }

        /// <summary>
        /// Test unosa neispravnog imena
        /// </summary>
        [TestMethod()]
        public void TestSetImeIzuzetak()
        {
            try
            {
                glasac.setIme("");
            }
            catch(LicneInformacijeOGlasacuException ex){
                StringAssert.Equals(ex.Message, "Ime ne smije biti prazno!");
            }

            try
            {
                glasac.setIme("A");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Ime treba da se sastoji od minimalno 2, a maksimalno 40 slova!");
            }

            try
            {
                glasac.setIme("Adna*");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Ime treba sadržavati samo slova i crticu!");
            }
        }

        [TestMethod()]
        public void TestGetPrezime()
        {
            Assert.AreEqual(glasac.getPrezime(), "Mehanovic");
        }

        /// <summary>
        /// Test unosa neispravnog prezimena
        /// </summary>
        [TestMethod()]
        public void TestSetPrezimeIzuzetak()
        {
            try
            {
                glasac.setPrezime("                ");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Prezime ne smije biti prazno!");
            }

            try
            {
                glasac.setPrezime("MM");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Prezime treba da se sastoji od minimalno 3, a maksimalno 50 slova!");
            }

            try
            {
                glasac.setPrezime("1Mehanovic-");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Prezime treba sadržavati samo slova i crticu!");
            }
        }


        /// <summary>
        /// Test unosa neispravnog prezimena
        /// </summary>
        [TestMethod()]
        public void TestSetBrojLicneKarteIzuzetak()
        {
            try
            {
                glasac.setBrojLicneKarte("123T33");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Broj lične karte uvijek se sastoji od tačno 7 karaktera!");
            }

            try
            {
                glasac.setBrojLicneKarte("777A666");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Nije ispravan format!");
            }
        }

        /// <summary>
        /// Test unosa neispravnog datuma rodjenja
        /// </summary>
        [TestMethod()]
        public void TestSetDatumRodjenjaIzuzetak()
        {
            try
            {
                glasac.setDatumRodjenja(new DateTime(2010, 10, 10));
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Glasač mora biti punoljetan!");
            }

            try
            {
                glasac.setDatumRodjenja(new DateTime(2025, 1, 2));
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Datum rođenja ne može biti u budućnosti!");
            }
        }

        /// <summary>
        /// Test unosa neispravnog maticnog broja
        /// </summary>
        [TestMethod()]
        public void TestSetJmbgIzuzetak()
        {
            try
            {
                glasac.setJmbg("101120001111");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Matični broj se mora sastojati od 13 brojeva!");
            }

            try
            {
                glasac.setJmbg("12102000111111");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Nije ispravan format!");
            }
        }

        /// <summary>
        /// Test provjere identifikacionog broja glasaca
        /// </summary>
        [TestMethod()]
        public void TestGetJedinstveniIdentifikacioniKod()
        {
            Assert.AreEqual(glasac.getJedinstveniIdentifikacioniKod(), "AdMeVo10110011");
        }

        static IEnumerable<object[]> LicneInformacije
        {
            get
            {
                return new[]
                {
                    new object[] { "Esma", "Zejnilovic", "Sarajevo", "Ulica1", 71000, "bb", new DateTime(1999, 1, 2), "111T111", "0201999111111", "EsZeSa02019911"},
                    new object[] { "Muhamed", "Masnopita", "Sarajevo", "Ulica2", 71000, "bb", new DateTime(2000, 11, 21), "222M222", "2111000222222", "MuMaSa21110022"},
                    new object[] { "Selma", "Kurtovic", "Sarajevo", "Ulica3", 71000, "bb", new DateTime(2001, 2, 18), "333M333", "1802001333333", "SeKuSa18020133"},
                    new object[] { "Zejneb", "Kost", "Sarajevo", "Ulica4", 71000, "bb", new DateTime(2000, 8, 8), "444T444", "0808000444444", "ZeKoSa08080044"},
                };
            }
        }

        [TestMethod]
        [DynamicData("LicneInformacije")]
        public void TestLicneInformacije(string ime, string prezime, string grad, string ulica, int postanskiBroj, string broj, 
            DateTime datumRodjenja, string brojLicneKarte, string jmbg, string identifikacioniKod )
        {
            Glasac g = new Glasac(ime, prezime, new Adresa(grad, ulica, postanskiBroj, broj), datumRodjenja, brojLicneKarte, jmbg);
            Assert.AreEqual(g.getJedinstveniIdentifikacioniKod(), identifikacioniKod);
        }

        public static IEnumerable<object[]> UčitajGlasaceXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Glasaci.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                List<string> elements = new List<string>();
                foreach (XmlNode innerNode in node)
                {
                    elements.Add(innerNode.InnerText);
                }
                yield return new object[] { elements[0], elements[1], elements[2], elements[3], 
                    Convert.ToInt32(elements[4]), elements[5],
                    DateTime.Parse(elements[6]), elements[7], elements[8], elements[9] };
            }
        }

        static IEnumerable<object[]> GlasaciXML
        {
            get
            {
                return UčitajGlasaceXML();
            }
        }

        [TestMethod]
        [DynamicData("GlasaciXML")]
        public void TestKonstruktoraPacijentaXML(string ime, string prezime, string grad, string ulica, int postanskiBroj, string broj,
        DateTime rodjenje, string brojLicneKarte, string jmbg, string identifikacioniKod)
        {
            Glasac g = new Glasac(ime, prezime, new Adresa(grad, ulica, postanskiBroj, broj), rodjenje, brojLicneKarte, jmbg);
            Assert.AreEqual(g.getJedinstveniIdentifikacioniKod(), identifikacioniKod);
        }
       
    }
}
