using Microsoft.VisualStudio.TestTools.UnitTesting;
using VVSZadace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVSZadaceTests
{
    //Zejneb Kost
    [TestClass()]
    public class Funkcionalnost2Test
    {

        static Kandidat kandidat;
        Stranka sda = new Stranka("SDA", "Stranka demokratske akcije");
        Stranka sdp = new Stranka("SDP", "Socijaldemokratska partija");


        [TestInitialize]
        public void InicijalizacijaPrijeSvakogTesta()
        {
            kandidat = new Kandidat("Bakir", "Izetbegovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T121", "1511967111111");
        }

        [TestMethod()]
        public void TestNemaStranke()
        {
            Assert.AreEqual(kandidat.getHistorijaStranaka(), "");
        }

        [TestMethod()]
        public void TestJednaStranka()
        {
            kandidat.pridruziStranci(sda);
            Assert.AreEqual(kandidat.getHistorijaStranaka(), "Kandidat je bio član stranke Stranka demokratske akcije od " + DateTime.Now.ToString("d/M/yyyy"));
        }
    }
}
