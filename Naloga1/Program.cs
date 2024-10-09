using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Naloga1;
class Program
{
    static void Main(string[] args)
    {
     
        List<ZakonskaSkupnost> skupnosti = ZakonskaSkupnost.UvoziIzCSV(@"C:\Users\arnis\OneDrive - Univerza v Mariboru\2.LETNIK\ARHITEKTURE INFORMACIJSKIH SISTEMOV\Naloga1\1NALOGA.txt");

        foreach (var skupnost in skupnosti)
        {
            Console.WriteLine("To je skupnost:");
            skupnost.Ata.Izpis();
            skupnost.Mama.Izpis();
            foreach (var otrok in skupnost.Otroci)
            {
                otrok.Izpis();
            }

            double povprecnaStarost = skupnost.IzracunajPovprecnoStarostOtrok();
            Console.WriteLine($"Povprečna starost otrok: {povprecnaStarost}");

            Otrok najmlajsiOtrok = skupnost.NajmlajsiOtrok();
            if (najmlajsiOtrok != null)
            {
                Console.WriteLine("Najmlajši otrok:");
                najmlajsiOtrok.Izpis();
            }

            string iskaniPredmet = "Matematika";
            Otrok otrokZNajljubsimPredmetom = skupnost.NajdiOtrokaZNajljubsimPredmetom("Matematika");
            if (otrokZNajljubsimPredmetom != null)
            {
                Console.WriteLine($"Otrok z najljubšim predmetom {iskaniPredmet}:");
                otrokZNajljubsimPredmetom.Izpis();
            }
            else
            {
                Console.WriteLine($"Noben otrok nima najljubšega predmeta: {iskaniPredmet}");
            }
        }
        Ata Uroš = new Ata("Uroš", "Rems", DateTime.Parse("29.3.1965"), "Računalničar", "Feri", 38);
        Mama Bernarda = new Mama("Bernarda", "Rems", DateTime.Parse("18.10.1973"), "Informatika", "Fri", 30);
        Otrok Jaz = new Otrok("Arnož", "Rems", DateTime.Parse("2.7.2003"), "Feri", "Športna", 21);
        Otrok Brat = new Otrok("Rožle", "Rems", DateTime.Parse("18.1.1990"), "EPF", "Matematika", 34);
        Otrok Manja = new Otrok("Manja", "Rems", DateTime.Parse("19.9.1991"), "Turistični faks", "Anglescina", 33);
            
        List<Otrok> otroci1 = new List<Otrok> { Jaz, Manja, Brat };
        ZakonskaSkupnost zakonskaSkupnost1 = new ZakonskaSkupnost(Uroš, Bernarda);
      
            zakonskaSkupnost1.DodajOtroka(Jaz);
            zakonskaSkupnost1.DodajOtroka(Brat);
            zakonskaSkupnost1.DodajOtroka(Manja);
    
        double povprecnaStarost1 = zakonskaSkupnost1.IzracunajPovprecnoStarostOtrok();
        Console.WriteLine($"To je povprečna starost otrok za ZakonskoSkupnost1: {povprecnaStarost1}");

        Otrok najmlajsi = zakonskaSkupnost1.NajmlajsiOtrok();
        if (najmlajsi != null)
        {
            Console.WriteLine("Najmlajši otrok:");
            najmlajsi.Izpis();
        }
        string FavPredmet = "Matematika";
        Otrok najljubsiPredmet = zakonskaSkupnost1.NajdiOtrokaZNajljubsimPredmetom("Matematika");
        if (najljubsiPredmet != null)
        {
            Console.WriteLine($"Otrok z najljubšim predmetom {FavPredmet}:");
            najljubsiPredmet.Izpis();
        }
        else
        {
            Console.WriteLine($"Noben otrok nima najljubšega predmeta: {FavPredmet}");
        }

        Ata Bojan = new Ata("Bojan", "Kekec", DateTime.Parse("12.12.2000"), "Neki", "Neki", 38);
        Mama Helda = new Mama("Helda", "Kekec", DateTime.Parse("18.10.2003"), "Farmacija", "FF", 21);
        Otrok Nik = new Otrok("Nik", "Kekec", DateTime.Parse("2.7.2016"), "OsnovnaŠola", "Športna", 8);
        ZakonskaSkupnost zakonskaSkupnostZaNapako = new ZakonskaSkupnost(Bojan, Helda);
        try
        {
            zakonskaSkupnostZaNapako.DodajOtroka(Nik);
        }
        catch (Exception e) { Console.WriteLine(e.Message); }
        }
}
