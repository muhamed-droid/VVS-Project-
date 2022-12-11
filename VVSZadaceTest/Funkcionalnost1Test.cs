using Microsoft.VisualStudio.TestTools.UnitTesting;
using VVSZadace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [TestMethod()]
        public void TestGetIme()
        {
            Assert.AreEqual(glasac.getIme(), "Adna");
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
                glasac.setIme("MM");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Prezime treba da se sastoji od minimalno 3, a maksimalno 50 slova!");
            }

            try
            {
                glasac.setIme("1Mehanovic-");
            }
            catch (LicneInformacijeOGlasacuException ex)
            {
                StringAssert.Equals(ex.Message, "Prezime treba sadržavati samo slova i crticu!");
            }
        }

        [TestMethod()]
        public void TestGetBrojLicneKarte()
        {
            Assert.AreEqual(glasac.getBrojLicneKarte(), "111T111");
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

        [TestMethod()]
        public void TestGetJmbg()
        {
            Assert.AreEqual(glasac.getJmbg(), "1011000111111");
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

    }
}
