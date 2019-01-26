﻿using System;
namespace Fahrzeugverwaltung.Klassen
{
    public static class Draw
    {
        private static int consoleWidth = Console.WindowWidth;
        public static void Line(string c)
        {
            for (int i = 0; i < consoleWidth; i++)
            {
                Console.Write(c);
            }
            Console.WriteLine("\n");
        }
    }
}
