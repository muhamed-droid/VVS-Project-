using System;

namespace VVSZadaca1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Osoba glasac1 = new Osoba("Muhamed", "Masnopita", new Adresa("Iljas", "Ljesevo", 71380, "252"), new DateTime(2001, 11, 15), "165T24", 12345);
            Osoba glasac2 = new Osoba("Adna", "Mehanovic", new Adresa("Vogosca", "ulica1", 71000, "bb"), new DateTime(2000, 5, 21), "131T29", 12346);
            Osoba glasac3 = new Osoba("Esma", "Zejnilovic", new Adresa("Brcko", "ulica2", 71365, "bb"), new DateTime(2007, 11, 15), "6ZT182", 12347);
            Osoba glasac4 = new Osoba("Selma", "Kurtovic", new Adresa("Sarajevo", "ulica3", 71000, "bb"), new DateTime(2002, 12, 4), "310T25", 12348);
            Osoba glasac5 = new Osoba("Zejneb", "Kost", new Adresa("Sarajevo", "ulica4", 71000, "bb"), new DateTime(2000, 1, 31), "200T12", 12349);

            Stranka sda = new Stranka("SDA", "Stranka demokratske akcije");
            Stranka sdp = new Stranka("SDP", "Socijaldemokratska partija");
            Stranka df = new Stranka("DF", "Demokratska fronta");
            Stranka nip = new Stranka("NIP", "Narod i pravda");
            Stranka ns = new Stranka("NS", "Nasa stranka");
            Stranka hdz = new Stranka("HDZ", "Hrvatska demokratska zajednica");
            Stranka snsd = new Stranka("SNSD", "Savez nezavisnih socijaldemokrata"); 

            Osoba bakir = new Kandidat("Bakir", "Izetbegovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T21", 99900);
            Osoba sebija = new Kandidat("Sebija", "Izetbegovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T22", 99901);
            Osoba dino = new Kandidat("Elmedin", "Konakovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T23", 99902);
            Osoba forto = new Kandidat("Edin", "Forto", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T24", 99903);
            Osoba dodik = new Kandidat("Milorad", "Dodik", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T25", 99904);
            Osoba denis = new Kandidat("Denis", "Becirovic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T26", 99905);
            Osoba komso = new Kandidat("Zeljko", "Komsic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T27", 99906);
            Osoba sabina = new Kandidat("Sabina", "Cudic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T28", 99907);
            Osoba borjana = new Kandidat("Borjana", "Kristo", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T29", 99908);
            Osoba zlatko = new Kandidat("Zlatko", "Lagumdzija", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T30", 99909);
            Osoba irfan = new Kandidat("Irfan", "Cengic", new Adresa("ka", "la", 21, "bb"), new DateTime(1967, 11, 15), "123T31", 99910);


            Console.WriteLine("unesi ime:");
            string userName = Console.ReadLine();
            Osoba nova= new Osoba(userName, "selma",new Adresa("a","b",1,"c"), new DateTime(1, 2, 3), "", 1);
            sda.dodajKandidata(nova);
            Console.WriteLine(sda.getKandidati());  
        }
    }
}
