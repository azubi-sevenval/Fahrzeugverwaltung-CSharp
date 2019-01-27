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

        public bool GetPKW(string kennzeichen)
        {
            foreach (PKW p in pkws)
            {
                if (p.Kennzeichen.Equals(kennzeichen))
                {
                    Notification.SuccessMessage("Es wurde ein PKW gefunden!\n");
                    p.GetInfos();
                    return true;
                } 
            }

            Notification.ErrorMessage("Das Kennzeichen wurde nicht gefunden.\n");
            return false;
        }

        public void GetMotorrad()
        {
            foreach (Motorrad m in motorraeder)
            {
                m.GetInfos();
            }
        }

        public bool GetMotorrad(string kennzeichen)
        {
            foreach (Motorrad m in motorraeder)
            {
                if (m.Kennzeichen.Equals(kennzeichen))
                {
                    Notification.SuccessMessage("Es wurde ein Motorrad gefunden!\n");
                    m.GetInfos();
                    return true;
                }
            }

            Notification.ErrorMessage("Das Kennzeichen wurde nicht gefunden.\n");
            return false;
        }

        public void GetLKW()
        {
            foreach (LKW l in lkws)
            {
                l.GetInfos();
            };
        }

        public bool GetLKW(string kennzeichen)
        {
            foreach (LKW l in lkws)
            {
                if (l.Kennzeichen.Equals(kennzeichen))
                {
                    Notification.SuccessMessage("Es wurde ein LKW gefunden!\n");
                    l.GetInfos();
                    return true;
                }
            }

            Notification.ErrorMessage("Das Kennzeichen wurde nicht gefunden.\n");
            return false;
        }

        public void GetAll()
        {
            Console.WriteLine("PKWs:\n");
            GetPKW();
            Draw.Line("-");
            Console.WriteLine("\nLKWs:\n");
            GetLKW();
            Draw.Line("-");
            Console.WriteLine("\nMotorräder:\n");
            GetMotorrad();
        }
    }
}
