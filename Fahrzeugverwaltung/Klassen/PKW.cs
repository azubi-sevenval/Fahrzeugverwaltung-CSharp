using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung.Klassen
{
    public class PKW : Fahrzeug
    {
        public PKW(
            string hersteller,
            string modell,
            string kennzeichen,
            int erstzulassung,
            double anschaffungspreis,
            int hubraum,
            int leistung,
            int schadstoffklasse
        ) : base(hersteller, modell, kennzeichen, erstzulassung, anschaffungspreis)
        {
            Hubraum = hubraum;
            Leistung = leistung;
            Schadstoffklasse = schadstoffklasse;
        }

        public int Hubraum { get; set; }
        private int Leistung { get; set; }
        public int Schadstoffklasse { get; set; }
        private string Schadstoffbezeichnung 
        {
            get { return Enum.GetName(typeof(Schadstoff), Schadstoffklasse); }
        }

        public enum Schadstoff { schadstoffarm, normal, Diesel };

        public override void GetInfos()
        {
            base.GetInfos();
            Console.WriteLine(
                "Hubraum: {0}\n" +
                "Leistung: {1}PS\n" +
                "Schadstoffklasse: {2}-{3}\n",
                Hubraum, Leistung, Schadstoffklasse, Schadstoffbezeichnung
            );
        }
    }
}
