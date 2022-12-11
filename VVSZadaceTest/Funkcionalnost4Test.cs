﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VVSZadace;
using System;
using System.Collections.Generic;
using System.Xml;

//Selma Kurtovic-funkcionalnost 4-metode u klasi Stranka+main(nije testiran)

namespace VVSZadaceTests
{
    [TestClass()]
   public class Funkcionalnost4Test
    {
        static Registar r;
        static Glasac glasac1, glasac2;
        static Kandidat bakir, sebija, dino;
        static Stranka sda, nip;

        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            r = new Registar();
           glasac1 = new Glasac("Muhamed", "Masnopita", new Adresa("Iljas", "Ljesevo", 71380, "252"), new DateTime(1992, 11, 15), "165T214", "1511992111111");


            glasac2 = new Glasac("Adna", "Mehanovic", new Adresa("Vogosca", "ulica1", 71000, "bb"), new DateTime(2000, 5, 21), "131T219", "2105000222222");
            r.dodajGlasaca(glasac1);
            r.dodajGlasaca(glasac2);

            sda = new Stranka("SDA", "Stranka demokratske akcije");
            nip = new Stranka("NIP", "Narod i pravda");
            r.dodajStranku(nip);
            r.dodajStranku(sda);

            bakir = new Kandidat("Bakir", "Izetbegovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T121", "1511967111111");
             sebija = new Kandidat("Sebija", "Izetbegovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T422", "1511967111111");
            dino = new Kandidat("Elmedin", "Konakovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T238", "1511967111111");

            r.dodajGlasaca(bakir);
            r.dodajGlasaca(sebija);
            r.dodajGlasaca(dino);

            sda.dodajKandidata(bakir);
            sda.dodajKandidata(sebija);
            nip.dodajKandidata(dino);
            sda.dodajClanaRukovodstva(bakir);
            sda.dodajClanaRukovodstva(sebija);
            nip.dodajClanaRukovodstva(dino);
        }

            [TestMethod]
            public void TestMetodeDodajClanaRukovodstva()
            {
                Stranka sdp = new Stranka("SDP", "Socijaldemokratska partija");
                Kandidat forto = new Kandidat("Edin", "Forto", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T248", "1511967111111");
                r.dodajGlasaca(forto);
                sdp.dodajClanaRukovodstva(forto);
                Assert.AreEqual(1,sdp.getClanoviRukovodstva().Count);
            }
        [TestMethod]
        public void TestMetodeGetClanoviRukovodstva()
            {
            Assert.AreEqual(2, sda.getClanoviRukovodstva().Count);
            Assert.IsTrue(sda.getClanoviRukovodstva().Contains(bakir));
            Assert.IsTrue(sda.getClanoviRukovodstva().Contains(sebija));
            Assert.IsFalse(sda.getClanoviRukovodstva().Contains(dino));

              }
        [TestMethod]
        public void TestMetodeGetClanoviRukovodstvaKandidovani()
        {
            Assert.AreEqual(2, sda.getClanoviRukovodstvaKandidovani().Count);
            Assert.AreEqual(1, nip.getClanoviRukovodstvaKandidovani().Count);

        }

        [TestMethod]
        public void TestMetodeGetUkupanBrojGlasovaRukovodstva()
        {
            Assert.AreEqual(0, nip.getUkupanBrojGlasovaRukovodstva());
            nip.dodajGlas(glasac1);
            dino.dodajGlas(glasac1);
            Assert.AreEqual(1, dino.getBrojGlasova());

             Assert.AreEqual(1, nip.getUkupanBrojGlasovaRukovodstva());
            sda.dodajGlas(glasac1);
             bakir.dodajGlas(glasac1);
             sebija.dodajGlas(glasac1);
             Assert.AreEqual(2, sda.getUkupanBrojGlasovaRukovodstva());
            

        }

        static IEnumerable<object[]> Kandidati
        {
            get
            {
                return new[]
                {
                    new object[] { "Borjana", "Kristo", DateTime.Parse("11/15/1967"), "123T829", "1511967111111","HDZ","hdz" ,"ka","la",21,"bb"},
                     new object[] { "Bakir", "Izetbegovic", DateTime.Parse("11/15/1967"), "123T829", "1511967111111","Sda","sda", "se", "er", 48, "bb" }




                };
            }
        }
        [TestMethod]
        [DynamicData("Kandidati")]
        public void TestRukovodstvo(string ime, string prezime, DateTime datum, string licna, string id, string stranka_naziv, string stranka,
            string ulica, string grad, int broj, string drzava)
        {
            
            Kandidat k = new Kandidat(ime, prezime, new Adresa(ulica, grad, broj, drzava), datum, licna, id);
            Stranka s = new Stranka(stranka, stranka_naziv);
            k.pridruziStranci(s);
            //s.dodajKandidata(k);
            s.dodajClanaRukovodstva(k);
            Assert.AreEqual(s.getClanoviRukovodstva().Count, 1);
        }









    }





}
