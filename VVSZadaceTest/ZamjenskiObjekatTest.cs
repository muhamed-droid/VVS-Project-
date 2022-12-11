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
        /*[TestMethod]
        public void TestStub()
        {
            Glasac glasac = new Glasac("Cristiano", "Ronaldo", new Adresa("Brcko", "Mujkici III", 76100, "35"), new DateTime(1985, 2, 5), "156T25", 0502985186500);
            StubNiskaTemperatura stub1 = new StubNiskaTemperatura();
            k.AutomatskaKontrola(stub1, true);
            Assert.AreEqual(k.JačinaGrijanja, 1);
            StubSrednjaTemperatura stub2 = new StubSrednjaTemperatura();
            k.AutomatskaKontrola(stub2, true);
            Assert.AreEqual(k.JačinaGrijanja, 0.5);
            StubVisokaTemperatura stub3 = new StubVisokaTemperatura();
            k.AutomatskaKontrola(stub3, true);
            Assert.AreEqual(k.JačinaGrijanja, 0);
        }*/

        [TestMethod]
        public void TestZamjenskiObjekat()
        {
            Glasac glasac = new Glasac("Cristiano", "Ronaldo", new Adresa("Brcko", "Mujkici III", 76100, "35"), new DateTime(1985, 2, 5), "156T25", 0502985186500);
            Stub stub = new Stub();
            
            //spy.IdentifikacijskiBroj = "cr7";
            bool flag = glasac.VjerodostojnostGlasaca(stub);
            Assert.IsTrue(flag);

            glasac.setDatGlas(true);
            //spy.IdentifikacijskiBroj = "cr7";
            flag = glasac.VjerodostojnostGlasaca(stub);
            Assert.IsFalse(flag);
        }

    }
}
