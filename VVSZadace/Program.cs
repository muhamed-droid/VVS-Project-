using System;
using System.Collections.Generic;

namespace VVSZadace
{
    public class Program
    {
        static void setUp(Registar r)
        {
            Glasac glasac1 = new Glasac("Muhamed", "Masnopita", new Adresa("Iljas", "Ljesevo", 71380, "252"), new DateTime(1992, 11, 15), "165T24", 12345);
            Glasac glasac2 = new Glasac("Adna", "Mehanovic", new Adresa("Vogosca", "ulica1", 71000, "bb"), new DateTime(2000, 5, 21), "131T29", 12346);
            Glasac glasac3 = new Glasac("Esma", "Zejnilovic", new Adresa("Brcko", "ulica2", 71365, "bb"), new DateTime(2007, 11, 15), "6ZT182", 12347);
            Glasac glasac4 = new Glasac("Selma", "Kurtovic", new Adresa("Sarajevo", "ulica3", 71000, "bb"), new DateTime(2002, 12, 4), "310T25", 12348);
            Glasac glasac5 = new Glasac("Zejneb", "Kost", new Adresa("Sarajevo", "ulica4", 71000, "bb"), new DateTime(2000, 1, 31), "200T12", 12349);
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
            sda.dodajClanaRukovodstva(bakir);
            sda.dodajClanaRukovodstva(dodik);
            nip.dodajClanaRukovodstva(dino);
            sdp.dodajClanaRukovodstva(denis);
            //stavit cu borjanu i irfana kao nezavisnog
            r.dodajKandidata(irfan);
            r.dodajKandidata(borjana);
        }
        static void unosGlasaca(Registar r)
        {
            Console.WriteLine("Unesite ime:");
            string ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime:");
            string prezime = Console.ReadLine();
            Console.WriteLine("Unesite jmbg:");
            int jmbg = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesite grad:");
            string grad = Console.ReadLine();
            Console.WriteLine("Unesite postanski broj:");
            int postanskiBroj = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesite naziv ulice:");
            string ulica = Console.ReadLine();
            Console.WriteLine("Unesite broj:");
            string broj = Console.ReadLine();
            Console.WriteLine("Unesite broj licne karte:");
            string licna = Console.ReadLine();
            Console.WriteLine("Unesite godinu rodjenja:");
            int godina = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesite mjesec rodjenja:");
            int mjesec = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Unesite dan rodjenja:");
            int dan = Convert.ToInt32(Console.ReadLine());
            r.dodajGlasaca(new Glasac(ime, prezime, new Adresa(grad, ulica, postanskiBroj, broj), new DateTime(godina, mjesec, dan), licna, jmbg));

        }

        /*static int brojac = 3;
        static string ponovnoGlasanje(string sifra)
        {
            brojac--;
            if (sifra.ToUpper() != "VVS20222023")
            {
                if (brojac == 0)
                {
                    return "Pogrešna šifra! Nemate više pokušaja!";
                }
                else
                    return "Pogrešna šifra! Pokušajte ponovo:";
            }
            return "Unijeli ste tačnu šifru!";
        }

        static string provjeraIdentifikacionogBroja(Glasac o, string jibr)
        {
            if (jibr != o.getJedinstveniIdentifikacioniKod())
            {
                return "Unijeli ste pogrešan identifikacioni broj!";
            }
            return "Ispravan identifikacioni broj!";
        }*/

        static void Main(string[] args)
        {
            Registar r = new Registar();
            setUp(r);

            for (; ; )
            {
                Console.WriteLine("Da li zelite glasati(1), uvid u podatke(2), resetovanje glasanja(3), izlaz iz apikacije(0)?");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("Dobro došli na izbore! Unesite vaše podatke!");
                    Console.WriteLine("Unesite ime: ");
                    string ime = Console.ReadLine();

                    Console.WriteLine("Unesite prezime: ");
                    string prezime = Console.ReadLine();
                    Console.WriteLine("Unesite jmbg: ");
                    long jmbg = long.Parse(Console.ReadLine());

                    try
                    {
                        Glasac o = r.identifikacijaGlasaca(ime, prezime, jmbg);

                        if (o.getDatGlas())
                        {
                            Console.WriteLine("Već ste glasali!");
                        }
                        else
                        {
                            Console.WriteLine("Vas identifikacijski broj glasi: " + o);
                            Console.WriteLine("Da li zelite glasati za stranku(1) ili za nezavisnog kandidata(2)?");
                            int inputGlasaca = Convert.ToInt32(Console.ReadLine());
                            if (inputGlasaca == 1)
                            {
                                int i = 0;
                                foreach (Stranka str in r.getStranke())
                                {
                                    i++;
                                    Console.WriteLine(i + ". " + str.getIdentifikacionaSkracenica() + " - " + str.getPuniNaziv());
                                }
                                Console.WriteLine("Unesite identifikacionu skracenicu stranke za koju zelite glasati");
                                string inputStranke = Console.ReadLine().ToUpper();
                                Stranka stranka = r.getStranke().Find(s => s.getIdentifikacionaSkracenica().Equals(inputStranke));
                                if (stranka == null)
                                {
                                    Console.WriteLine("Ta stranka ne postoji!");
                                }
                                else
                                {
                                    r.dodajGlas();
                                    o.glasaj(stranka);
                                    o.setDatGlas(true);

                                    int j = 0;
                                    foreach (Kandidat kandidat in stranka.getKandidati())
                                    {
                                        j++;
                                        Console.WriteLine(j + ". " + kandidat.getIme() + " " + kandidat.getPrezime());
                                    }
                                    List<Kandidat> kandidati = new List<Kandidat>();
                                    for (; ; )
                                    {
                                        Console.WriteLine("Unesite imena i prezimena kandidata stranke za koje zelite glasati (svaki kandidat u novi red) ili 0 ukoliko ne zelite glasati ili ste zavrsili sa odabirom kandidata");
                                        string inputKandidata = Console.ReadLine().ToUpper();
                                        if (inputKandidata == "0")
                                            break;
                                        Kandidat kandidat = stranka.getKandidati().Find(k => (k.getIme() + " " + k.getPrezime()).ToUpper().Equals(inputKandidata));
                                        if (kandidat == null)
                                            Console.WriteLine("Kandidat ne postoji!");
                                        else
                                        {
                                            kandidati.Add(kandidat);
                                            break;
                                        }
                                    }
                                    o.glasaj(kandidati);
                                    Console.WriteLine("Uspješno ste glasali. Hvala!");

                                }
                            }
                            else if (inputGlasaca == 2)
                            {
                                int i = 0;
                                foreach (Kandidat kandidat in r.getNezavisnikandidati())
                                {
                                    i++;
                                    Console.WriteLine(i + ". " + kandidat.getIme() + " " + kandidat.getPrezime());
                                }
                                Console.WriteLine("Unesite ime i prezime nezavisnog kandidata za kojeg zelite glasati");
                                string inputNezavisnogKandidata = Console.ReadLine().ToUpper();
                                Kandidat nezavisniKandidat = r.getNezavisnikandidati().Find(k => (k.getIme() + " " + k.getPrezime()).ToUpper().Equals(inputNezavisnogKandidata));
                                if (nezavisniKandidat == null)
                                {
                                    Console.WriteLine("Taj nezavisni kandidat ne postoji!");
                                }
                                else
                                {
                                    o.glasaj(new List<Kandidat>() { nezavisniKandidat });
                                    r.dodajGlas();
                                    o.setDatGlas(true);
                                    Console.WriteLine("Uspješno ste glasali. Hvala!");
                                }
                            }
                            else
                                Console.WriteLine("Ulaz nije validan! Ne postoji ta opcija");
                        }
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
                            Console.WriteLine("4. Pregled rezultata rukovodstva stranke");
                            Console.WriteLine("5. Pregled rezultata rukovodstva svih stranaka");
                            Console.WriteLine("5. Pregled rezultata rukovodstva svih stranaka");
                            int inputAdmina = Convert.ToInt32(Console.ReadLine());

                            switch (inputAdmina)
                            {
                                case 1:
                                    unosGlasaca(r);
                                    break;
                                case 2:
                                    r.getGlasaci().ForEach(g => Console.WriteLine(g));
                                    break;
                                case 3:
                                    Console.WriteLine("Odaberite jednu od ponuđenih opcija: ");
                                    Console.WriteLine("1. ukupna izlaznost. ");
                                    Console.WriteLine("2. stranke koje su prešle cenzus. ");
                                    Console.WriteLine("3. kandidati koji su prešli cenzus. ");
                                    int broj = Convert.ToInt32(Console.ReadLine());
                                    if (broj == 1)
                                    {

                                        Console.WriteLine("Trenutna izlaznost je: " + r.getBrojGlasaca() + " osoba, odnosno to je: " + r.dajIzlaznost() * 100 + "%");
                                    }
                                    else if (broj == 2)
                                    {

                                        Console.WriteLine("Stranke koje su prešle cenzus su: ");
                                        foreach (Stranka s in r.dajStrankeKojeSuPresleCenzus())
                                        {
                                            Console.Write(s.getPuniNaziv() + "\n");
                                        }
                                    }
                                    else if (broj == 3)
                                    {
                                        //funkcionalnost 3, omogućiti pregled informacija za sve političke stranke i kandidate
                                        //Radio: Muhamed Masnopita

                                        Console.WriteLine("Kandidati koji su prešli cenzus su:");
                                        foreach (Kandidat k in r.dajKandidateKojiSuOsvojiliMandat())
                                        {
                                            Console.Write(k + "\n");
                                        }

                                        Console.WriteLine("Odaberite jednu od ponuđenih opcija: ");
                                        Console.WriteLine("1. spisak kandidata koji su osvojili mandat po strankama. ");
                                        Console.WriteLine("0. bez spiska.");

                                        int temp = Convert.ToInt32(Console.ReadLine());
                                        if (temp == 0) break;
                                        else if (temp == 1)
                                        {
                                            //spisak ispisujemo
                                            Console.WriteLine(r.ispisRezultata());

                                        }
                                        else
                                        {
                                            Console.WriteLine("Odabrali ste nepostojeću opciju!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Odabrali ste nepostojeću opciju!");
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("Unesite identifikacionu skracenicu stranke");
                                    string inputStranke = Console.ReadLine().ToUpper();
                                    Stranka stranka = r.getStranke().Find(s => s.getIdentifikacionaSkracenica().Equals(inputStranke));
                                    if (stranka == null)
                                        Console.WriteLine("Ta stranka ne postoji!");
                                    else
                                    {
                                        Console.WriteLine("Ukupan broj glasova rukovodstva stranke" + stranka.getUkupanBrojGlasovaRukovodstva());

                                        foreach (var clan in stranka.getClanoviRukovodstvaKandidovani())
                                            Console.WriteLine(clan.getIme());

                                    }


                                    break;
                                //Funkcionalnost 4-Selma Kurtovic
                                case 5:
                                    var ukupno = r.getUkupanBrojGlasovaRukvodstvaStranaka();

                                    Console.WriteLine("Ukupan broj glasova: " + ukupno);
                                    Console.Write("Kandidati: ");
                                    var kandidati = r.getKandidovanoRukovodstvoSvihStranaka();
                                    for (var i = 0; i < kandidati.Count; i++)


                                        Console.Write("Identifikacioni broj: " + kandidati[i].getJedinstveniIdentifikacioniKod() + ", ");

                                    Console.Write("\n");


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
                //Funkcionalnost br.5 Esma Zejnilović
                else if (input == 3)
                {
                    Administrator a = new Administrator(r);
                    Console.WriteLine("Unesite jedinstveni identifikacioni broj:");
                    string jibr = Console.ReadLine();
                    string poruka = a.provjeraIdentifikacionogBroja(jibr);
                    Console.WriteLine(poruka);
                    if (poruka.Equals("Unijeli ste neispravan identifikacioni broj!"))
                        return;
                    Glasac glasac = a.dajGlasacaZaJIBroj(jibr);
                    if(!glasac.getDatGlas())
                    {
                        Console.WriteLine("Glasač " + jibr + " nije glasao!");
                        return;
                    }
                    Console.WriteLine("Unesite tajnu šifru:");
                    for (; ; )
                    {
                        string sifra = Console.ReadLine();
                        poruka = a.provjeraTajneSifre(sifra);
                        Console.WriteLine(poruka);
                        if (poruka.Contains("Nemate više pokušaja"))
                            return;
                        if (poruka.Equals("Unijeli ste tačnu šifru!"))
                            break;
                    }
                    r.resetGlasanja(glasac);
                    Console.WriteLine("Glasač " + jibr + " može ponovo glasati!");
                }
                //Funkcionalnost br.5 Esma Zejnilović
                else if (input == 0)
                    return;
                else
                    Console.WriteLine("Ulaz nije validan! Ne postoji ta opcija");
            }
        }
    }
}