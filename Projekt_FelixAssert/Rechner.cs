using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_FelixAssert
{
    [Version("F. Assert", classVersion = "1.1.0")]
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
                ClearLine(error: true);
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
                ClearLine(error: true);
                GetI();
            }
            return I;
        }


        //U = R * I
        public static double Wiederstand(string header)
        {
            Console.Clear();
            Console.WriteLine(header);
            double rechnen = (GetU() / GetI());
            if (rechnen <= 0)
            {
                Console.CursorTop += 2;
                Console.Write("Physikalisch nicht möglisch!");
                Thread.Sleep(1000);
                Wiederstand(header);
            }
            return rechnen;
        }
        public static double Stromstaerke(string header)
        {
            Console.Clear();
            Console.WriteLine(header);
            return GetU() / GetR();
        }
        public static double Spannung(string header)
        {
            Console.Clear();
            Console.WriteLine(header);
            return GetR() * GetI();
        }

        public static void ClearLine(bool error)
        {
            if(error)
            {
                Console.CursorTop += 2;
                Console.Write("Ungueltige eingabe!");
                Thread.Sleep(1000);
                Clear();
                Console.CursorTop -= 2;
            }
            Clear();
            Console.CursorTop--;
        }
        private static void Clear()
        {
            for (int i = Console.CursorLeft, l = 0; i > 0; i--, l++)
            {
                Console.CursorLeft = l;
                Console.Write(' ');
            }
        }
    }
}
