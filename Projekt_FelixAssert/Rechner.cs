using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_FelixAssert
{
    [Version("F. Assert", classVersion = "1.0.0")]
    internal class Rechner
    {
        private double u;
        public static double U { get; set; }

        private double r;
        public static double R { get; set; }

        private double i;
        public static double I { get; set; }

        private static double GetU()
        {
            Console.Write("\nBitte gib den Spannung ein: ");
            U = WerteEingabe.GetDouble();
            Console.Write(" A");
            return U;
        }
        private static double GetR()
        {
            Console.Write("\nBitte gib die Wiederstand ein: ");
            R = WerteEingabe.GetDouble();
            Console.Write(" Ohm");
            if (R <= 0)
            {
                ClearLine();
                GetR();
            }
            return R;
        }
        private static double GetI()
        {
            Console.Write("\nBitte gib die Strommstärke ein: ");
            I = WerteEingabe.GetDouble();
            Console.Write(" V");
            if (I == 0)
            {
                ClearLine();
                GetI();
            }
            return I;
        }


        //U = R * I
        public static double Wiederstand()
        {
            Console.Clear();
            Console.WriteLine("Wiederstand");
            double rechnen = (GetU() / GetI());
            if (rechnen < 0)
            {
                Console.WriteLine("\nPhysikalisch nicht möglich! Wiederstand muss positive sein.");
                Thread.Sleep(100);
                Wiederstand();
            }
            return rechnen;
        }
        public static double Stromstaerke()
        {
            Console.Clear();
            Console.WriteLine("Stromstärke");
            return GetU() / GetR();
        }
        public static double Spannung()
        {
            Console.Clear();
            Console.WriteLine("Spannung");
            return GetR() * GetI();
        }

        public static void ClearLine()
        {
            for(int i = Console.CursorLeft, l = 0; i > 0; i--, l++)
            {
                Console.CursorLeft = l;
                Console.Write(' ');
            }
            Console.CursorTop--;
        }
    }
}
