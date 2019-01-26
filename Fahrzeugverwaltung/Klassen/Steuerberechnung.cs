using System;
namespace Fahrzeugverwaltung.Klassen
{
    public static class Steuerberechnung
    {
        static int count;

        // Berechnung der Steuerschuld für alle Fahrzeuge
        public static void CalcSteuerschuld(Fahrzeugliste fl)
        {
            double result = 0;

            foreach (PKW p in fl.pkws)
            {
                count++;
                result += (p.Hubraum + 99) / 100 * 10 * (p.Schadstoffklasse + 1);
            }

            foreach (Motorrad m in fl.motorraeder)
            {
                count++;
                result += (m.Hubraum + 99) / 100 * 20;
            }

            foreach (LKW l in fl.lkws)
            {
                count++;
                result += l.Zuladung * 100;
            }

            Console.WriteLine(
                "Es wurden insgesamt {0} Fahrzeuge gefunden.\nDie Gesamtsumme beträgt: {1} Euro.\n", 
                count, result
            );
        }

        // Berechnung der Steuerschuld (Eingabe KFZ-Kennzeichen)
        public static void CalcSteuerschuld(Fahrzeugliste fl, string kennzeichen)
        {
            double result = 0;

            foreach (PKW p in fl.pkws)
            {
                if (p.Kennzeichen.Equals(kennzeichen))
                {
                    result = (p.Hubraum + 99) / 100 * 10 * (p.Schadstoffklasse + 1);
                    Console.WriteLine(
                        "Bei dem Kennzeichen {0} handelt es sich um ein {1}.\nDie Steuerschuld beträgt: {2} Euro.\n",
                        kennzeichen, p.GetType().Name, result
                    );
                }
            }

            foreach (Motorrad m in fl.motorraeder)
            {
                if(m.Kennzeichen.Equals(kennzeichen))
                {
                    result = (m.Hubraum + 99) / 100 * 20;
                    Console.WriteLine(
                        "Bei dem Kennzeichen {0} handelt es sich um ein {1}.\nDie Steuerschuld beträgt: {2} Euro.\n",
                        kennzeichen, m.GetType().Name, result
                    );
                }
            }

            foreach (LKW l in fl.lkws)
            {
                if(l.Kennzeichen.Equals(kennzeichen))
                {
                    result = l.Zuladung * 100;
                    Console.WriteLine(
                        "Bei dem Kennzeichen {0} handelt es sich um ein {1}.\nDie Steuerschuld beträgt: {2} Euro.\n",
                        kennzeichen, l.GetType().Name, result
                    );
                }
            }
        }
    }
}
