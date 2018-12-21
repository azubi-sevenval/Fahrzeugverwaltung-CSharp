using System;
namespace Fahrzeugverwaltung.Klassen
{
    public class LKW : Fahrzeug
    {
        public LKW(
            string _Hersteller,
            string _Modell,
            string _Kennzeichen,
            int _Erstzulassung,
            double _Anschaffungspreis,
            int _Achsen,
            double _Zuladung
        ): base(_Hersteller, _Modell, _Kennzeichen, _Erstzulassung, _Anschaffungspreis)
        {
            Achsen = _Achsen;
            Zuladung = _Zuladung;
        }

        private int Achsen { get; set; }
        public double Zuladung { get; set; }

        public override void GetInfos()
        {
            base.GetInfos();
            Console.WriteLine(
                "Achsen: {0}\n" +
                "Zuladung: {1} Tonnen\n",
                Achsen, Zuladung
            );
        }
    }
}
