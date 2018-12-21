using System;
namespace Fahrzeugverwaltung.Klassen
{
    public abstract class Fahrzeug
    {
        protected Fahrzeug(string _Hersteller, string _Modell, string _Kennzeichen, int _Erstzulassung, double _Anschaffungspreis)
        {
            Hersteller = _Hersteller;
            Modell = _Modell;
            Kennzeichen = _Kennzeichen;
            Erstzulassung = _Erstzulassung;
            Anschaffungspreis = _Anschaffungspreis;
        }

        protected string Hersteller { get; set; }
        protected string Modell { get; set; }
        protected int Erstzulassung { get; set; }
        protected double Anschaffungspreis { get; set; }
        public string Kennzeichen { get; set; }

        public virtual void GetInfos() {
            Console.WriteLine(
                "Hersteller: {0}\n" +
                "Modell: {1}\n" +
                "Kennzeichen: {2}\n" +
                "Erstzulassung (Jahr): {3}\n" +
                "Anschaffungspreis: {4}€",
                Hersteller, Modell, Kennzeichen, Erstzulassung, Anschaffungspreis
            );
        }
    }
}
