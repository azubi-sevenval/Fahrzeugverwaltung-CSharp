using System;
using System.Collections.Generic;
using System.Linq;
namespace Fahrzeugverwaltung.Klassen
{
    public class Parkhaus
    {
        public Parkhaus(string _ort, string _plz, string _straße)
        {
            Ort = _ort;
            PLZ = _plz;
            Straße = _straße;
        }

        List<Parkplatz> parkplatzListe = new List<Parkplatz>();

        string Ort { get; set; }
        string PLZ { get; set; }
        string Straße { get; set; }

        public void AddParkplatz(Parkplatz parkplatz)
        {
            if(parkplatzListe.Any(p => parkplatz.Id == p.Id))
            {
                Console.WriteLine(
                    "Die Parkplatz-ID ({0}) wird bereits verwendet.",
                    parkplatz.Id
                );
            } else {
                parkplatzListe.Add(parkplatz);
            }
        }

        public void RemoveParkplatz(int id)
        {
            foreach(Parkplatz p in parkplatzListe.ToList())
            {
                if(p.Id == id)
                {
                    parkplatzListe.Remove(p);
                    Console.WriteLine(
                        "Der Parkplatz mit der ID {0} wurde erfolgreich entfernt.",
                        p.Id
                    );
                }
            }
        }

        public void GetParkhausInfo()
        {
            Console.WriteLine(
                "--- Parkhausdaten ---\n" +
                "Ort: {0}\n" +
                "PLZ: {1}\n" +
                "Straße: {2}\n",
                Ort, PLZ, Straße
            );
        }

        // Listet die Parkplatzdaten für alle Fahrzeuge
        public void GetParkplatzInfo()
        {
            foreach(Parkplatz p in parkplatzListe)
            {
                p.GetInfos();
            }
        }

        // Listet die Parkplatzdaten für ein bestimmtes Kennzeichen
        public void GetParkplatzInfo(string kennzeichen)
        {
            foreach(Parkplatz p in parkplatzListe)
            {
                if(p.Fahrzeug != null && p.Fahrzeug.Kennzeichen.Equals(kennzeichen))
                {
                    Console.WriteLine(
                        "Für das Kennzeichen {0} wurden folgende Daten gefunden:\n",
                        kennzeichen
                    );
                    GetParkhausInfo();
                    p.GetInfos();
                    Console.WriteLine("--- Fahrzeugdaten ---");
                    p.Fahrzeug.GetInfos();
                }
            }
        }

        // Das Fahrzeug wird an der ersten verfügbaren Stelle geparkt
        public void SetParkplatz(Fahrzeug fahrzeug)
        {
            foreach (Parkplatz p in parkplatzListe)
            {
                if (fahrzeug.GetType().Name == p.Typ && !p.isOccupied)
                {
                    p.SetFahrzeug(fahrzeug);
                    Console.WriteLine(
                        "Das Fahrzeug mit dem Kennzeichen {0} parkt nun am Stellplatz: {1}.", 
                        fahrzeug.Kennzeichen, p.Id
                    );
                    break;
                }
            }

            if (parkplatzListe.Any(p => fahrzeug.GetType().Name != p.Typ))
            {
                Console.WriteLine(
                    "Ihr {0} konnte nicht geparkt werden. Möglicherweise ist dieser Parkplatz nicht für {0}s bestimmt oder der Parkplatz ist bereits vergeben.",
                    fahrzeug.GetType().Name
                );
            }
        }

        // Das Fahrzeug wird an der angegebenen Parkplatznummer geparkt
        public void SetParkplatz(Fahrzeug fahrzeug, int id)
        {
            foreach(Parkplatz p in parkplatzListe)
            {
                if(fahrzeug.GetType().Name == p.Typ && !p.isOccupied && p.Id == id)
                {
                    p.SetFahrzeug(fahrzeug);
                    Console.WriteLine(
                        "Das Fahrzeug mit dem Kennzeichen {0} parkt nun am Stellplatz: {1}.",
                        fahrzeug.Kennzeichen, id
                    );
                    break;
                }
            }

            if(parkplatzListe.Any(p => fahrzeug.GetType().Name != p.Typ))
            {
                Console.WriteLine(
                    "Ihr {0} konnte nicht am Stellplatz {1} geparkt werden. Möglicherweise ist dieser Parkplatz nicht für {0}s bestimmt oder der Parkplazt ist bereits vergeben.",
                    fahrzeug.GetType().Name,
                    id
                );
            }
        }
    }
}
