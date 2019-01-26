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

        // Ein Parkhaus besteht aus vielen Parkplätzen
        List<Parkplatz> parkplatzListe = new List<Parkplatz>();

        string Ort { get; set; }
        string PLZ { get; set; }
        string Straße { get; set; }

        // Fügt dem Parkhaus ein Parkplatz hinzu
        public void AddParkplatz(Parkplatz parkplatz)
        {
            if(parkplatzListe.Any(p => parkplatz.Id == p.Id))
            {
                Notification.ErrorMessage($"Die Parkplatz-ID ({parkplatz.Id}) wird bereits verwendet.");
            } else {
                parkplatzListe.Add(parkplatz);
            }
        }

        // Entfernt dem Parkhaus ein Parkplatz
        public void RemoveParkplatz(int id)
        {
            foreach(Parkplatz p in parkplatzListe.ToList())
            {
                if(p.Id == id)
                {
                    parkplatzListe.Remove(p);
                    Notification.SuccessMessage($"Der Parkplatz mit der ID {p.Id} wurde erfolgreich entfernt.");
                }
            }
        }

        // Listet die Parkhaus-Adresse
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
                    Notification.SuccessMessage($"Für das Kennzeichen {kennzeichen} wurden folgende Daten gefunden:\n");
                    GetParkhausInfo();
                    p.GetInfos();
                    Console.WriteLine("--- Fahrzeugdaten ---");
                    p.Fahrzeug.GetInfos();
                }
            }
        }

        // Das Fahrzeug wird an der ersten verfügbaren Stelle geparkt
        public bool SetParkplatz(Fahrzeug fahrzeug)
        {
            foreach (Parkplatz p in parkplatzListe)
            {
                if (fahrzeug.GetType().Name == p.Typ && !p.isOccupied)
                {
                    p.SetFahrzeug(fahrzeug);
                    Notification.SuccessMessage($"Das Fahrzeug mit dem Kennzeichen {fahrzeug.Kennzeichen} parkt nun am Stellplatz: {p.Id}.\n");
                    return true;
                }
            }

            if (parkplatzListe.Any(p => fahrzeug.GetType().Name != p.Typ))
            {
                Console.WriteLine(
                    "Ihr {0} konnte nicht geparkt werden. Möglicherweise ist dieser Parkplatz nicht für {0}s bestimmt oder der Parkplatz ist bereits vergeben.\n",
                    fahrzeug.GetType().Name
                );
            }
            return false;
        }

        // Das Fahrzeug wird an der angegebenen Parkplatznummer geparkt
        public bool SetParkplatz(Fahrzeug fahrzeug, int id)
        {
            foreach (Parkplatz p in parkplatzListe)
            {
                if (fahrzeug.GetType().Name == p.Typ && !p.isOccupied && p.Id == id)
                {
                    p.SetFahrzeug(fahrzeug);
                    Notification.SuccessMessage($"Das Fahrzeug mit dem Kennzeichen {fahrzeug.Kennzeichen} parkt nun am Stellplatz: {id}.\n");
                    return true;
                }
            }

            if (parkplatzListe.Any(p => fahrzeug.GetType().Name != p.Typ))
            {
                Notification.ErrorMessage($"Ihr {fahrzeug.GetType().Name} konnte nicht am Stellplatz {id} geparkt werden. Möglicherweise ist dieser Parkplatz nicht für {fahrzeug.GetType().Name}s bestimmt oder der Parkplatz ist bereits vergeben.\n");
            }
            return false;
        }
    }
}
