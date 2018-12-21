using System;
namespace Fahrzeugverwaltung.Klassen
{
    public class Parkplatz
    {
        public Parkplatz( int _id, Fahrzeug _fahrzeug, string _typ)
        {
            Id = _id;
            Fahrzeug = _fahrzeug;
            Typ = _typ;
            isOccupied = Fahrzeug != null;
        }

        public Parkplatz(int _id, string _typ) : this(_id, null, _typ)
        {
            Id = _id;
            Typ = _typ;
        }

        public Parkplatz(int _id): this(_id, null, "Fahrzeug")
        {
            Id = _id;
        }

        public int Id { get; set; }
        public Fahrzeug Fahrzeug { get; set; }
        public string Typ { get; set; }
        public bool isOccupied { get; set; }

        public void GetInfos() {
            Console.WriteLine(
                "--- Parkplatzdaten ---\n" +
                "ID: {0}\n" +
                "Belegt: {1}\n" +
                "Parkplatztyp: {2}",
                Id, isOccupied, Typ
            );

            if(isOccupied)
            {
                Console.Write(
                    "Fahrzeug: {0}\n",
                    Fahrzeug.Kennzeichen
                );
            }
            Console.Write("\n");
        }

        public void SetFahrzeug(Fahrzeug f)
        {
            Fahrzeug = f;
            isOccupied = true;
        }
    }
}
