using System;
using System.Linq;
namespace Fahrzeugverwaltung.Klassen
{
    public static class Verwaltung
    {
        public static void Start()
        {
            // Initialisierung der vorgegebenen Objekte
            Fahrzeugliste fl = new Fahrzeugliste();
            Parkhaus parkhaus1 = new Parkhaus("Köln", "51105", "Westerwaldstr. 99");
            PKW pkw1 = new PKW("VW", "Käfer", "K-GS-01", 1965, 9999, 1000, 30, 1);
            PKW pkw2 = new PKW("Opel", "Kadett", "K-GS-02", 1964, 12000, 1600, 60, 2);
            Motorrad mr1 = new Motorrad("BMW", "R1200r", "K-GS-03", 1999, 6000, 1170);
            LKW lkw1 = new LKW("Mercedes", "LG 315", "K-GS-04", 1960, 23000, 2, 5.5);

            // Die vorgegebenen Fahrzeuge werden in die Fahrzeugliste eingetragen
            fl.AddPKW(pkw1);
            fl.AddPKW(pkw2);
            fl.AddMotorrad(mr1);
            fl.AddLKW(lkw1);

            // Das Parkhaus 1 soll beispielhaft mit 300 Stellplätzen initialisiert werden.
            // Die vorgegebenen Fahrzeuge werden an ihre korrekten Stellplätze geparkt.
            // 0-199 für PKWs
            for (int i = 0; i < 200; i++)
            {
                if (i == 100)
                {
                    Parkplatz p1 = new Parkplatz(100, pkw1, "PKW");
                    parkhaus1.AddParkplatz(p1);
                    continue;
                }

                if (i == 101)
                {
                    Parkplatz p2 = new Parkplatz(101, pkw2, "PKW");
                    parkhaus1.AddParkplatz(p2);
                    continue;
                }

                Parkplatz pPkw = new Parkplatz(i, "PKW");
                parkhaus1.AddParkplatz(pPkw);
            }

            // 200-249 für Motorräder
            for (int i = 200; i < 250; i++)
            {
                if (i == 200)
                {
                    Parkplatz p3 = new Parkplatz(200, mr1, "Motorrad");
                    parkhaus1.AddParkplatz(p3);
                    continue;
                }
                Parkplatz pMotorrad = new Parkplatz(i, "Motorrad");
                parkhaus1.AddParkplatz(pMotorrad);
            }

            // 250 - 300 für LKWs
            for (int i = 250; i < 301; i++)
            {
                if (i == 300)
                {
                    Parkplatz p4 = new Parkplatz(300, lkw1, "LKW");
                    parkhaus1.AddParkplatz(p4);
                    continue;
                }
                Parkplatz pLkw = new Parkplatz(i, "LKW");
                parkhaus1.AddParkplatz(pLkw);
            }

            /*
             * Das Hauptmenü wird beim Start als erstes angezeigt. 
             * Die Menüführung wird in einzelne Segmente unterteilt und über 
             * lokale Methoden zugänglich gemacht.
             */
            MainMenu();

            void MainMenu()
            {
                Console.Clear();
                bool isActive = true;
                while (isActive)
                {
                    Draw.Line("-");
                    Console.WriteLine("HAUPTMENÜ\n");
                    Draw.Line("-");
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
                        Notification.ErrorMessage("Ihre Eingabe war falsch!\n");
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
                        "HAUPTMENÜ >> FAHRZEUG-MENÜ\n"
                    );
                    Draw.Line("-");
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
                    Draw.Line("-");
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
                                Console.WriteLine(
                                    "HAUPTMENÜ >> FAHRZEUG-MENÜ >> ALLE PKWs\n"
                                );
                                Draw.Line("-");
                                fl.GetPKW();
                                Draw.Line("-");
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                FahrzeugMenu();
                                break;
                            case "2":
                                Console.Clear();
                                Draw.Line("-");
                                Console.WriteLine(
                                    "HAUPTMENÜ >> FAHRZEUG-MENÜ >> ALLE MOTORRÄDER\n"
                                );
                                Draw.Line("-");
                                fl.GetMotorrad();
                                Draw.Line("-");
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                FahrzeugMenu();
                                break;
                            case "3":
                                Console.Clear();
                                Draw.Line("-");
                                Console.WriteLine(
                                    "HAUPTMENÜ >> FAHRZEUG-MENÜ >> ALLE LKWs\n"
                                );
                                Draw.Line("-");
                                fl.GetLKW();
                                Draw.Line("-");
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                FahrzeugMenu();
                                break;
                            case "4":
                                Console.Clear();
                                Draw.Line("-");
                                Console.WriteLine(
                                    "HAUPTMENÜ >> FAHRZEUG-MENÜ >> ALLE FAHRZEUGE\n"
                                );
                                Draw.Line("-");
                                fl.GetAll();
                                Draw.Line("-");
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
                                Console.WriteLine(
                                    "HAUPTMENÜ >> FAHRZEUG-MENÜ >> PKW\n"
                                );
                                Draw.Line("-");
                                fl.GetPKW(userInputKennzeichen);
                                Draw.Line("-");
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
                                Console.WriteLine(
                                    "HAUPTMENÜ >> FAHRZEUG-MENÜ >> MOTORRAD\n"
                                );
                                Draw.Line("-");
                                fl.GetMotorrad(userInputKennzeichen);
                                Draw.Line("-");
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
                                Console.WriteLine(
                                    "HAUPTMENÜ >> FAHRZEUG-MENÜ >> LKW\n"
                                );
                                Draw.Line("-");
                                fl.GetLKW(userInputKennzeichen);
                                Draw.Line("-");
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
                        Notification.ErrorMessage("Ihre Eingabe war falsch!\n");
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
                        "HAUPTMENÜ >> PARKHAUS-MENÜ\n"
                    );
                    Draw.Line("-");
                    Console.WriteLine(
                        "Bitte wählen Sie eine der unten stehenden Zahl aus:\n" +
                        "1: Ausgabe der Parkhaus-Adresse\n" +
                        "2: Ausgabe aller Stellplatz-Daten\n" +
                        "3: Ausgabe der Stellplatz-Daten nach Kennzeichen\n" +
                        "4: Anlegen und Zuweisen eines Fahrzeugs für ein Parkhaus-Stellplatz\n"
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
                                Console.WriteLine(
                                    "HAUPTMENÜ >> PARKHAUS-MENÜ >> PARKHAUS-INFORMATIONEN\n"
                                );
                                Draw.Line("-");
                                parkhaus1.GetParkhausInfo();
                                Draw.Line("-");
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                ParkhausMenu();
                                break;
                            case "2":
                                Console.Clear();
                                Draw.Line("-");
                                Console.WriteLine(
                                    "HAUPTMENÜ >> PARKHAUS-MENÜ >> PARKPLATZDATEN\n"
                                );
                                Draw.Line("-");
                                parkhaus1.GetParkplatzInfo();
                                Draw.Line("-");
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
                                Console.WriteLine(
                                    "HAUPTMENÜ >> PARKHAUS-MENÜ >> PARKPLATZDATEN\n"
                                );
                                Draw.Line("-");
                                parkhaus1.GetParkplatzInfo(userInputKennzeichen);
                                Draw.Line("-");
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                ParkhausMenu();
                                break;
                            case "4":
                                Console.Clear();
                                Draw.Line("-");
                                Console.WriteLine(
                                        "HAUPTMENÜ >> PARKHAUS-MENÜ >> PARKPLATZ-ZUWEISUNG\n"
                                    );
                                Draw.Line("-");

                                string stellplatzID = "";
                                Console.WriteLine("Haben Sie einen Stellplatz reserviert? (j/n)");
                                string userConfirmation = Console.ReadLine();
                                if (userConfirmation == "j")
                                {
                                    Console.WriteLine("Geben Sie Ihre Stellplatz-ID ein.");
                                    stellplatzID = Console.ReadLine();
                                }

                                Console.WriteLine("Fahrzeugtyp? (PKW / Motorrad / LKW)");
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

                                    Console.Clear();
                                    Draw.Line("-");
                                    Console.WriteLine(
                                        "HAUPTMENÜ >> PARKHAUS-MENÜ >> PARKPLATZ-ZUWEISUNG\n"
                                    );
                                    Draw.Line("-");

                                    if(stellplatzID != "")
                                    {
                                        parkhaus1.SetParkplatz(newPKW, Convert.ToInt32(stellplatzID));
                                    } else {
                                        parkhaus1.SetParkplatz(newPKW);
                                    }
                                }

                                if(typ == "Motorrad")
                                {
                                    Console.WriteLine("Hubraum?");
                                    int hubraum = Convert.ToInt32(Console.ReadLine());

                                    Motorrad newMotorrad = new Motorrad(
                                        hersteller, modell, kennzeichen, year, anschaffungspreis,
                                        hubraum
                                    );

                                    Console.Clear();
                                    Draw.Line("-");
                                    Console.WriteLine(
                                        "HAUPTMENÜ >> PARKHAUS-MENÜ >> PARKPLATZ-ZUWEISUNG\n"
                                    );
                                    Draw.Line("-");

                                    if (stellplatzID != "")
                                    {
                                        parkhaus1.SetParkplatz(newMotorrad, Convert.ToInt32(stellplatzID));
                                    }
                                    else
                                    {
                                        parkhaus1.SetParkplatz(newMotorrad);
                                    }
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

                                    Console.Clear();
                                    Draw.Line("-");
                                    Console.WriteLine(
                                        "HAUPTMENÜ >> PARKHAUS-MENÜ >> PARKPLATZ-ZUWEISUNG\n"
                                    );
                                    Draw.Line("-");

                                    if (stellplatzID != "")
                                    {
                                        parkhaus1.SetParkplatz(newLKW, Convert.ToInt32(stellplatzID));
                                    }
                                    else
                                    {
                                        parkhaus1.SetParkplatz(newLKW);
                                    }
                                }
                                Draw.Line("-");
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
                        Notification.ErrorMessage("Ihre Eingabe war falsch!\n");
                    }
                }
            }

            void SteuerschuldMenu()
            {
                Console.Clear();
                bool isActive = true;
                while (isActive)
                {
                    Console.Clear();
                    Draw.Line("-");
                    Console.WriteLine(
                        "HAUPTMENÜ >> STEUERSCHULD-MENÜ\n"
                    );
                    Draw.Line("-");   
                    Console.WriteLine(
                        "Bitte wählen Sie eine der unten stehenden Zahl aus:\n" +
                        "1: Berechnung der Steuerschuld (Eingabe KFZ-Kennzeichen)\n" +
                        "2: Berechnung der Steuerschuld für alle Fahrzeuge\n"
                    );
                    Draw.Line("-");   
                    Console.WriteLine("<-- Zurück (9)\n");
                    Draw.Line("-");   

                    string userInput = Console.ReadLine();
                    string userInputKennzeichen;
                    string[] allowedInput = { "1", "2", "9" };
                    if (allowedInput.Contains(userInput))
                    {
                        switch (userInput)
                        {
                            case "1":
                                Console.WriteLine("Bitte geben Sie ein Kennzeichen ein:");
                                userInputKennzeichen = Console.ReadLine();
                                Console.Clear();
                                Draw.Line("-");
                                Console.WriteLine(
                                    "HAUPTMENÜ >> STEUERSCHULD-MENÜ >> STEUERSCHULD (KFZ-KENNZEICHEN)\n"
                                );
                                Draw.Line("-");
                                Steuerberechnung.CalcSteuerschuld(fl, userInputKennzeichen);
                                Draw.Line("-");
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                SteuerschuldMenu();
                                break;
                            case "2":
                                Console.Clear();
                                Draw.Line("-");
                                Console.WriteLine(
                                    "HAUPTMENÜ >> STEUERSCHULD-MENÜ >> STEUERSCHULD (GESAMT)\n"
                                );
                                Draw.Line("-");
                                Steuerberechnung.CalcSteuerschuld(fl);
                                Draw.Line("-");
                                Console.WriteLine("<-- Zurück (Beliebige Taste)\n");
                                Draw.Line("-");

                                Console.ReadLine();
                                SteuerschuldMenu();
                                break;
                            case "9":
                                MainMenu();
                                break;
                        }
                        isActive = false;
                    } else {
                        Console.Clear();
                        Notification.ErrorMessage("Ihre Eingabe war falsch!\n");
                    }
                }
            }
        }
    }
}