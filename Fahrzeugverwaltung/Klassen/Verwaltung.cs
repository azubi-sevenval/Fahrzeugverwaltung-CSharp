using System;
using System.Linq;
namespace Fahrzeugverwaltung.Klassen
{
    public static class Verwaltung
    {
        public static void Start()
        {
            // Initialisierung der Objekte
            Fahrzeugliste fl = new Fahrzeugliste();
            Parkhaus parkhaus1 = new Parkhaus("Köln", "51105", "Westerwaldstr. 99");
            PKW pkw1 = new PKW("VW", "Käfer", "K-GS-01", 1965, 9999, 1000, 30, 1);
            PKW pkw2 = new PKW("Opel", "Kadett", "K-GS-02", 1964, 12000, 1600, 60, 2);
            Motorrad mr1 = new Motorrad("BMW", "R1200r", "K-GS-03", 1999, 6000, 1170);
            LKW lkw1 = new LKW("Mercedes", "LG 315", "K-GS-04", 1960, 23000, 2, 5.5);

            Parkplatz p1 = new Parkplatz(100, pkw1, "PKW");
            Parkplatz p2 = new Parkplatz(101, pkw2, "PKW");
            Parkplatz p3 = new Parkplatz(200, mr1, "Motorrad");
            Parkplatz p4 = new Parkplatz(300, lkw1, "LKW");

            parkhaus1.AddParkplatz(p1);
            parkhaus1.AddParkplatz(p2);
            parkhaus1.AddParkplatz(p3);
            parkhaus1.AddParkplatz(p4);

            fl.AddPKW(pkw1);
            fl.AddPKW(pkw2);
            fl.AddMotorrad(mr1);
            fl.AddLKW(lkw1);

            // Das Hauptmenü wird beim Start als erstes angezeigt.
            MainMenu();

            // Die Menüführung wird in einzelne Segmente unterteilt 
            // und über lokale Methoden zugänglich gemacht.
            void MainMenu()
            {
                Console.Clear();
                bool isActive = true;
                while (isActive)
                {
                    Draw.Line("-");
                    Console.WriteLine("--> HAUPTMENÜ\n");
                    Console.WriteLine(
                        "Willkommen bei der Fahrzeugverwaltung!\n" +
                        "Bitte wählen Sie eine der unten stehenden Zahl aus.\n"
                    );
                    Console.WriteLine(
                        "1: Fahrzeugmenü\n" +
                        "2: Parkhausmenü\n" +
                        "3: Steuerschuld-Berechnung\n"
                    );
                    Draw.Line("-");

                    string userInput = Console.ReadLine();
                    string[] allowedInput = { "1", "2", "3" };
                    if (allowedInput.Contains(userInput))
                    {
                        switch (userInput)
                        {
                            case "1":
                                FahrzeugMenu();
                                break;
                            case "2":
                                ParkhausMenu();
                                break;
                            case "3":
                                SteuerschuldMenu();
                                break;
                        }
                        isActive = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ihre Eingabe war falsch!\n");
                    }
                }
            }

            void FahrzeugMenu()
            {
                Console.Clear();
                bool isActive = true;
                while (isActive)
                {
                    Draw.Line("-");
                    Console.WriteLine(
                        "--> FAHRZEUG-MENÜ\n"
                    );
                    Console.WriteLine(
                        "Bitte wählen Sie eine der unten stehenden Zahl aus:\n" +
                        "1: Ausgabe aller PKWs\n" +
                        "2: Ausgabe aller Motorräder\n" +
                        "3: Ausgabe aller LKWs\n" +
                        "4: Ausgabe aller Fahrzeuge\n" +
                        "5: Ausgabe PKW nach Kennzeichen\n" +
                        "6: Ausgabe Motorrad nach Kennzeichen\n" +
                        "7: Ausgabe LKW nach Kennzeichen\n"
                    );
                    Console.WriteLine("<-- Zurück (9)\n");
                    Draw.Line("-");

                    string userInput = Console.ReadLine();
                    string userInputKennzeichen;
                    string[] allowedInput = { "1", "2", "3", "4", "5", "6", "7", "9" };
                    if (allowedInput.Contains(userInput))
                    {
                        switch (userInput)
                        {
                            case "1":
                                Console.Clear();
                                Draw.Line("-");
                                fl.GetPKW();
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                FahrzeugMenu();
                                break;
                            case "2":
                                Console.Clear();
                                Draw.Line("-");
                                fl.GetMotorrad();
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                FahrzeugMenu();
                                break;
                            case "3":
                                Console.Clear();
                                Draw.Line("-");
                                fl.GetLKW();
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                FahrzeugMenu();
                                break;
                            case "4":
                                Console.Clear();
                                Draw.Line("-");
                                fl.GetAll();
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                FahrzeugMenu();
                                break;
                            case "5":
                                Console.WriteLine("Bitte geben Sie ein Kennzeichen ein:");
                                userInputKennzeichen = Console.ReadLine();
                                Console.Clear();
                                Draw.Line("-");
                                fl.GetPKW(userInputKennzeichen);
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                FahrzeugMenu();
                                break;
                            case "6":
                                Console.WriteLine("Bitte geben Sie ein Kennzeichen ein:");
                                userInputKennzeichen = Console.ReadLine();
                                Console.Clear();
                                Draw.Line("-");
                                fl.GetMotorrad(userInputKennzeichen);
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                FahrzeugMenu();
                                break;
                            case "7":
                                Console.WriteLine("Bitte geben Sie ein Kennzeichen ein:");
                                userInputKennzeichen = Console.ReadLine();
                                Console.Clear();
                                Draw.Line("-");
                                fl.GetLKW(userInputKennzeichen);
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                FahrzeugMenu();
                                break;
                            case "9":
                                MainMenu();
                                break;
                        }
                        isActive = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ihre Eingabe war falsch!\n");
                    }
                }
            }

            void ParkhausMenu()
            {
                Console.Clear();
                bool isActive = true;
                while (isActive)
                {
                    Draw.Line("-");
                    Console.WriteLine(
                        "--> PARKHAUS-MENÜ\n"
                    );
                    Console.WriteLine(
                        "Bitte wählen Sie eine der unten stehenden Zahl aus:\n" +
                        "1: Ausgabe der Parkhaus-Adresse\n" +
                        "2: Ausgabe aller Stellplatz-Daten\n" +
                        "3: Ausgabe der Stellplatz-Daten nach Kennzeichen\n" +
                        "4: Zuweisen eines Fahrzeugs für ein Parkhaus-Stellplatz\n"
                    );
                    Console.WriteLine("<-- Zurück (9)\n");
                    Draw.Line("-");

                    string userInput = Console.ReadLine();
                    string userInputKennzeichen;
                    string[] allowedInput = { "1", "2", "3", "4", "9" };
                    if (allowedInput.Contains(userInput))
                    {
                        switch (userInput)
                        {
                            case "1":
                                Console.Clear();
                                Draw.Line("-");
                                parkhaus1.GetParkhausInfo();
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                ParkhausMenu();
                                break;
                            case "2":
                                Console.Clear();
                                Draw.Line("-");
                                parkhaus1.GetParkplatzInfo();
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                ParkhausMenu();
                                break;
                            case "3":
                                Console.WriteLine("Bitte geben Sie ein Kennzeichen ein:");
                                userInputKennzeichen = Console.ReadLine();
                                Console.Clear();
                                Draw.Line("-");
                                parkhaus1.GetParkplatzInfo(userInputKennzeichen);
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                ParkhausMenu();
                                break;
                            case "4":
                                Console.Clear();
                                Draw.Line("-");
                                Console.WriteLine("Fahrzeugtyp?");
                                string typ = Console.ReadLine();
                                Console.WriteLine("Hersteller?");
                                string hersteller = Console.ReadLine();
                                Console.WriteLine("Modell?");
                                string modell = Console.ReadLine();
                                Console.WriteLine("Kennzeichen?");
                                string kennzeichen = Console.ReadLine();
                                Console.WriteLine("Erstzulassung?");
                                int year = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Anschaffungspreis?");
                                double anschaffungspreis = Convert.ToDouble(Console.ReadLine());

                                if (typ == "PKW")
                                {
                                    Console.WriteLine("Hubraum?");
                                    int hubraum = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Leistung?");
                                    int leistung = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Schadstoffklasse?");
                                    int sk = Convert.ToInt32(Console.ReadLine());
                                    PKW newPKW = new PKW(
                                        hersteller, modell, kennzeichen, year, anschaffungspreis,
                                        hubraum, leistung, sk
                                    );
                                    parkhaus1.SetParkplatz(newPKW);
                                }

                                if(typ == "Motorrad")
                                {
                                    Console.WriteLine("Hubraum?");
                                    int hubraum = Convert.ToInt32(Console.ReadLine());

                                    Motorrad newMotorrad = new Motorrad(
                                        hersteller, modell, kennzeichen, year, anschaffungspreis,
                                        hubraum
                                    );
                                    parkhaus1.SetParkplatz(newMotorrad);
                                }

                                if (typ == "LKW")
                                {
                                    Console.WriteLine("Achsen?");
                                    int achsen = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Zuladung?");
                                    double zuladung = Convert.ToDouble(Console.ReadLine());

                                    LKW newLKW = new LKW(
                                        hersteller, modell, kennzeichen, year, anschaffungspreis,
                                        achsen, zuladung
                                    );
                                    parkhaus1.SetParkplatz(newLKW);
                                }
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                ParkhausMenu();
                                break;
                            case "9":
                                MainMenu();
                                break;
                        }
                        isActive = false;
                    } else {
                        Console.Clear();
                        Console.WriteLine("Ihre Eingabe war falsch!\n");
                    }
                }
            }

            // TODO:
            void SteuerschuldMenu()
            {
                Console.Clear();
                bool isActive = true;
                while (isActive)
                {
                    Console.Clear();
                    Draw.Line("-");
                    Console.WriteLine(
                        "--> STEUERSCHULD-MENÜ\n"
                    );
                    Console.WriteLine(
                        "Bitte wählen Sie eine der unten stehenden Zahl aus:\n" +
                        "1: Ausgabe aller PKWs\n" +
                        "2: Ausgabe aller Motorräder\n" +
                        "3: Ausgabe aller LKWs\n" +
                        "4: Ausgabe aller Fahrzeuge\n" +
                        "5: Fahrzeugsuche nach Kennzeichen\n"
                    );
                    Console.WriteLine("<-- Zurück (9)\n");
                    Draw.Line("-");   

                    string userInput = Console.ReadLine();
                    string userInputKennzeichen;
                    string[] allowedInput = { "1", "2", "3", "4", "5", "6", "7", "9" };
                    if (allowedInput.Contains(userInput))
                    {
                        
                    }
                }
            }
        }
    }
}