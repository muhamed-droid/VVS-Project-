using System;

namespace VVSZadaca1
{
    internal class Program
    {
      
        static void setUp(Registar r)
        {
        
            Osoba glasac1 = new Osoba("Muhamed", "Masnopita", new Adresa("Iljas", "Ljesevo", 71380, "252"), new DateTime(1992, 11, 15), "165T24", 12345);
            Osoba glasac2 = new Osoba("Adna", "Mehanovic", new Adresa("Vogosca", "ulica1", 71000, "bb"), new DateTime(2000, 5, 21), "131T29", 12346);
            Osoba glasac3 = new Osoba("Esma", "Zejnilovic", new Adresa("Brcko", "ulica2", 71365, "bb"), new DateTime(2007, 11, 15), "6ZT182", 12347);
            Osoba glasac4 = new Osoba("Selma", "Kurtovic", new Adresa("Sarajevo", "ulica3", 71000, "bb"), new DateTime(2002, 12, 4), "310T25", 12348);
            Osoba glasac5 = new Osoba("Zejneb", "Kost", new Adresa("Sarajevo", "ulica4", 71000, "bb"), new DateTime(2000, 1, 31), "200T12", 12349);
            r.dodajGlasaca(glasac1);
            r.dodajGlasaca(glasac2);
            r.dodajGlasaca(glasac3);
            r.dodajGlasaca(glasac4);
            r.dodajGlasaca(glasac5);
            Stranka sda = new Stranka("SDA", "Stranka demokratske akcije");
            Stranka sdp = new Stranka("SDP", "Socijaldemokratska partija");
            Stranka df = new Stranka("DF", "Demokratska fronta");
            Stranka nip = new Stranka("NIP", "Narod i pravda");
            Stranka ns = new Stranka("NS", "Nasa stranka");
            Stranka hdz = new Stranka("HDZ", "Hrvatska demokratska zajednica");
            Stranka snsd = new Stranka("SNSD", "Savez nezavisnih socijaldemokrata");
            r.dodajStranku(sda);
            r.dodajStranku(sdp);
            r.dodajStranku(df);
            r.dodajStranku(nip);
            r.dodajStranku(ns);
            r.dodajStranku(hdz);
            r.dodajStranku(snsd);
            Kandidat bakir = new Kandidat("Bakir", "Izetbegovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T21", 99900);
            Kandidat sebija = new Kandidat("Sebija", "Izetbegovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T22", 99901);
            Kandidat dino = new Kandidat("Elmedin", "Konakovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T23", 99902);
            Kandidat forto = new Kandidat("Edin", "Forto", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T24", 99903);
            Kandidat dodik = new Kandidat("Milorad", "Dodik", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T25", 99904);
            Kandidat denis = new Kandidat("Denis", "Becirovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T26", 99905);
            Kandidat komso = new Kandidat("Zeljko", "Komsic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T27", 99906);
            Kandidat sabina = new Kandidat("Sabina", "Cudic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T28", 99907);
            Kandidat borjana = new Kandidat("Borjana", "Kristo", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T29", 99908);
            Kandidat zlatko = new Kandidat("Zlatko", "Lagumdzija", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T30", 99909);
            Kandidat irfan = new Kandidat("Irfan", "Cengic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T31", 99910);
            r.dodajGlasaca(bakir);
            r.dodajGlasaca(sebija);
            r.dodajGlasaca(dino);
            r.dodajGlasaca(forto);
            r.dodajGlasaca(dodik);
            r.dodajGlasaca(denis);
            sda.dodajKandidata(bakir);
            sda.dodajKandidata(sebija);
            nip.dodajKandidata(dino);
            ns.dodajKandidata(forto);
            df.dodajKandidata(komso);
            //stavit cu borjanu i irfana kao nezavisnog
            r.dodajKandidata(irfan);
            r.dodajKandidata(borjana);
        }
        static void Main(string[] args)
        {
            Registar r = new Registar();
            setUp(r);


            for(; ; )

            {
                Console.WriteLine("Da li zelite glasati(1), uvid u podatke(2), izlaz iz apikacija(0)?");
                int input=Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("Dobro došli na izbore! Unesite vaše podatke!");
                    Console.WriteLine("Unesite ime:");
                    string ime = Console.ReadLine();

                    Console.WriteLine("Unesite prezime:");
                    string prezime = Console.ReadLine();
                    Console.WriteLine("Unesite jmbg:");
                    int jmbg = Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        Osoba o = r.identifikacijaGlasaca(ime, prezime, jmbg);
                        Console.WriteLine("Vas identifikacijski broj glasi: "+o);
                        r.unesiGlas();
                        Console.WriteLine("Izaberite stranku ili nezavisnog kandidata!");

                        /*esmin dio*/


                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Niste na glasackom spisku!");

                    }




                }
                else if (input == 2)
                {
                    for (; ; )
                    {
                        Console.WriteLine("Unesite password za admina ili 0 za izlaz:");
                        int password = Convert.ToInt32(Console.ReadLine());
                        if (password == 123)
                        {
                            
                                Console.WriteLine("Izaberite opciju!");
                                Console.WriteLine("0 izlaz");
                                Console.WriteLine("1. Unos glasaca");
                                Console.WriteLine("2. Pregled svih glasaca");
                                Console.WriteLine("3. Pregled statistike");
                                int inputAdmina = Convert.ToInt32(Console.ReadLine());

                                switch (inputAdmina)
                                {
                                    
                                        
                                    case 1:
                                        Console.WriteLine("Unesi ime!");
                                        Console.WriteLine("Unesi prezime");
                                        break;
                                    case 2:
                                        r.getGlasaci().ForEach(g => Console.WriteLine(g));
                                        break;
                                    case 3:
                                        /*muhamedov dio*/

                                        break;


                                }
                            break;


                        }
                        else if (password == 0)
                            break;
                        else
                            Console.WriteLine("Napravili ste gresku. Unesite ponovo ili kliknite 0 za izlaz.");

                    }
                }


                else if (input == 0)
                    return;
                else
                    Console.WriteLine("Ulaz nije validan!Ne postoji ta opcija");

                }


            //Console.WriteLine("unesi ime:");
            //  string userName = Console.ReadLine();
            /// Osoba nova = new Osoba(userName, "Kost", new Adresa("Sarajevo", "ulica4", 71000, "bb"), new DateTime(2000, 1, 31), "200T12", 12349);
            //sda.dodajKandidata(nova);
            //    sda.getKandidati().ForEach(o => Console.WriteLine(o));
            //  Console.WriteLine(sda.getKandidati().Count);
            
            
        }

        
    }
}
