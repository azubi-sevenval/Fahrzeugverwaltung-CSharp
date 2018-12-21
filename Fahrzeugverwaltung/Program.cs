using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung.Klassen
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Fahrzeugliste fl = new Fahrzeugliste();
            Parkhaus parkhaus1 = new Parkhaus("Köln", "51105", "Westerwaldstr. 99");

            PKW pkw1 = new PKW("VW", "Käfer", "K-GS-01", 1965, 9999, 1000, 30, 1);
            PKW pkw2 = new PKW("Opel", "Kadett", "K-GS-02", 1964, 12000, 1600, 60, 2);
            Motorrad mr1 = new Motorrad("BMW", "R1200r", "K-GS-03", 1999, 6000, 1170);
            LKW lkw1 = new LKW("Mercedes", "LG 315", "K-GS-04", 1960, 23000, 2, 5.5);

            fl.AddPKW(pkw1);
            fl.AddPKW(pkw2);
            fl.AddMotorrad(mr1);
            fl.AddLKW(lkw1);

            Parkplatz p1 = new Parkplatz(100, pkw1, "PKW");
            Parkplatz p2 = new Parkplatz(101, pkw2, "PKW");
            Parkplatz p3 = new Parkplatz(200, mr1, "Motorrad");
            Parkplatz p4 = new Parkplatz(300, lkw1, "LKW");

            parkhaus1.AddParkplatz(p1);
            parkhaus1.AddParkplatz(p2);
            parkhaus1.AddParkplatz(p3);
            parkhaus1.AddParkplatz(p4);

            // Ab hier soll die Menüführung beginnen...
             parkhaus1.GetParkplatzInfo("K-GS-04");
             Steuerberechnung.CalcSteuerschuld(fl, "K-GS-04");
        }
    }
}
