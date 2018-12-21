using System;
namespace Fahrzeugverwaltung.Klassen
{
    public class Motorrad : Fahrzeug
    {
        public Motorrad(
            string _Hersteller,
            string _Modell,
            string _Kennzeichen,
            int _Erstzulassung,
            double _Anschaffungspreis,
            int _Hubraum
        ) :base(_Hersteller, _Modell, _Kennzeichen, _Erstzulassung, _Anschaffungspreis)
        {
            Hubraum = _Hubraum;
        }

        public int Hubraum{ get; set; }

        public override void GetInfos()
        {
            base.GetInfos();
            Console.WriteLine(
                "Hubraum: {0}\n",
                Hubraum
            );
        }
    }
}
