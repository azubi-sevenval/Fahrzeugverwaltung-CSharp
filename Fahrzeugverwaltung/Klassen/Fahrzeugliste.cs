using System;
using System.Collections.Generic;

namespace Fahrzeugverwaltung.Klassen
{
    public class Fahrzeugliste
    {
        public List<PKW> pkws = new List<PKW>();
        public List<Motorrad> motorraeder = new List<Motorrad>();
        public List<LKW> lkws = new List<LKW>();

        public void AddPKW(PKW pkw)
        {
            pkws.Add(pkw);
        }

        public void AddMotorrad(Motorrad motorrad)
        {
            motorraeder.Add(motorrad);
        }

        public void AddLKW(LKW lkw)
        {
            lkws.Add(lkw);
        }

        public void GetPKW()
        {
            foreach (PKW p in pkws)
            {
                p.GetInfos();
            }
        }

        public void GetPKW(string kennzeichen)
        {
            foreach (PKW p in pkws)
            {
                if (p.Kennzeichen.Equals(kennzeichen))
                {
                    p.GetInfos();
                }
            }
        }

        public void GetMotorrad()
        {
            foreach (Motorrad m in motorraeder)
            {
                m.GetInfos();
            }
        }

        public void GetMotorrad(string kennzeichen)
        {
            foreach (Motorrad m in motorraeder)
            {
                if (m.Kennzeichen.Equals(kennzeichen))
                {
                    m.GetInfos();
                }
            }
        }

        public void GetLKW()
        {
            foreach (LKW l in lkws)
            {
                l.GetInfos();
            };
        }

        public void GetLKW(string kennzeichen)
        {
            foreach (LKW l in lkws)
            {
                if (l.Kennzeichen.Equals(kennzeichen))
                {
                    l.GetInfos();
                }
            }
        }

        public void GetAll()
        {
            Console.WriteLine("PKWs:\n");
            GetPKW();
            DrawLine();
            Console.WriteLine("\nLKWs:\n");
            GetLKW();
            DrawLine();
            Console.WriteLine("\nMotorräder:\n");
            GetMotorrad();
            DrawLine();
        }

        public List<Fahrzeug> GetList()
        {
            List<Fahrzeug> listRange = new List<Fahrzeug>();
            listRange.AddRange(pkws);
            listRange.AddRange(lkws);
            listRange.AddRange(motorraeder);
            return listRange;
        }

        void DrawLine() {
            int consoleWidth = Console.WindowWidth;
            for (int i = 0; i < consoleWidth; i++) 
            {
                Console.Write("-");
            }
        }
    }
}
